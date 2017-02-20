using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.EF;
using DAL.Tests.Helpers;
using Xunit;

namespace DAL.Tests.UpdateTests
{
    [Collection(Constants.CollectionName)]
    public class ConcurrencyTests : IDisposable
    {
        private readonly IntroToEfContext _db;

        public ConcurrencyTests()
        {
            _db = new IntroToEfContext();
        }

        public void Dispose()
        {
            _db.Database.ExecuteSqlCommand("delete from store.categories");
            _db.Database.ExecuteSqlCommand("DBCC CHECKIDENT ('Store.Categories', RESEED, 1)");
        }

        [Fact]
        public void ShouldThrowConcurrencyError()
        {
            var cat = new Category { CategoryName = "Foo" };
            Assert.Equal(0, cat.Id);
            _db.Categories.Add(cat);
            _db.SaveChanges();
            var newCat = _db.Categories.First(c => c.Id == cat.Id);
            _db.Database.ExecuteSqlCommand($"Update Store.Categories set CategoryName = 'Bar' where Id = {cat.Id}");
            newCat.CategoryName = "FooBar";
            var ex = Assert.Throws<DbUpdateConcurrencyException>(() => _db.SaveChanges());
        }
    }
}
