using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.EF;
using DAL.Tests.Helpers;
using Xunit;

namespace DAL.Tests.UpdateTests
{
    [Collection(Constants.CollectionName)]
    public class UpdateDataTests : IDisposable
    {
        private readonly IntroToEfContext _db;

        public UpdateDataTests()
        {
            _db = new IntroToEfContext();
        }

        public void Dispose()
        {
            _db.Database.ExecuteSqlCommand("delete from store.categories");
            _db.Database.ExecuteSqlCommand("DBCC CHECKIDENT ('Store.Categories', RESEED, 1)");
        }

    }
}
