﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrettyHair
{
    public class ProductTypeRepository
    {
        Dictionary<int, ProductType> listOfProducts = new Dictionary<int, ProductType>();
        public void Clear()
        {
            listOfProducts.Clear();
        }

        public ProductType CreateProduct(int id, double price, string description, int amount)
        {
            ProductType product = new ProductType(id, price, description, amount);
            listOfProducts.Add(id, product);
            return product;
        }

        public int CountProducts()
        {
            return listOfProducts.Count;
        }

        public ProductType Load(int id)
        {
            return listOfProducts[id];
        }

        public void ChangePrice(double price, int id)
        {
            listOfProducts[id].Price = price;
        }

        public void SubtractToAmount(int amount, int id)
        {
            listOfProducts[id].Amount = listOfProducts[id].Amount - amount;
            DB.ChangeProductAmount(id, listOfProducts[id].Amount);
        }

        public void ChangeAmount(int amount, int id)
        {
            listOfProducts[id].Amount = amount;
        }

        public void ChangeDescription(string description, int id)
        {
            listOfProducts[id].Description = description;
        }

        public Dictionary<int,ProductType> GetProductTypes()
        {
            return listOfProducts;
        }

        public Dictionary<int,IUi> GetProductAsIUi()
        {
            Dictionary<int, IUi> dictionaryOfProductsIUi = new Dictionary<int, PrettyHair.IUi>();
            foreach(KeyValuePair<int,ProductType> kvpProducts in listOfProducts)
            {
                dictionaryOfProductsIUi.Add(kvpProducts.Key, (IUi)kvpProducts.Value);
            }

            return dictionaryOfProductsIUi;
        }

        public bool CheckIfProductExists(int productTypeId)
        {
            return listOfProducts.ContainsKey(productTypeId);
        }

        public int AddStock(int productTypeId, int amount)
        {
            int newAmount;
            if(CheckIfProductExists(productTypeId) == false || amount < 0)
            {
                newAmount = -1;
            }
            else
            {
                listOfProducts[productTypeId].Amount = listOfProducts[productTypeId].Amount + amount;
                newAmount = listOfProducts[productTypeId].Amount;
            }
            return newAmount;
        }

        public bool CheckAmountOfProductsInOrder(Order ord)
        {
            bool haveEnoughProducts = true;
            for(int i = 0; i<ord.ListOfOrderLines.Count; i++)
            {
                
                if (ord.ListOfOrderLines[i].Quantity > listOfProducts[ord.ListOfOrderLines[i].Product.Id].Amount)
                {
                    haveEnoughProducts = false;
                }
            }
            return haveEnoughProducts;
        }

        internal void RemoveProductsFromOrder(List<OrderLine> listOfOrderLines)
        {
            for (int i = 0; i < listOfOrderLines.Count; i++)
            {
                SubtractToAmount(listOfOrderLines[i].Quantity, listOfOrderLines[i].Product.Id);
            }
        }
    }
}
