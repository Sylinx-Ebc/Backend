using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApi.Models;

namespace WebApi.Data
{
    public class DataAccessProvider : IDataAccessProvider
    {
        private readonly PostgreSqlContext _context;

        public DataAccessProvider(PostgreSqlContext context)
        {
            _context = context;
        }

        public void AddProductRecord(Product product)
        {
            _context.product.Add(product);
            _context.SaveChanges();
        }

        public void AddUserRecord(Account account)
        {
            _context.account.Add(account);
            _context.SaveChanges();
        }

        public void AddUserPurchase(Purchase purchases)
        {

            _context.purchase.Add(purchases);
            
            _context.SaveChanges();
        }

        public void DeleteProduct(int id)
        {
            var entity = _context.product.FirstOrDefault(p => p.productid.Equals(id));
            _context.product.Remove(entity);
            _context.SaveChanges();
        }

        public void DeleteUser(int id)
        {
            var entity = _context.account.FirstOrDefault(a=>a.accountid.Equals(id));
            _context.account.Remove(entity);
            _context.SaveChanges();
        }

        public List<Account> GetAccounts()
        {
            return _context.account.ToList();
        }

        public List<Product> GetProducts()
        {
            return _context.product.ToList();
        }

        public List<Purchase> GetPurchases(int id)
        {

            var result = _context.purchase.Where(prc => prc.accountid.Equals(id));

            return result.ToList();
        }

        public Account GetSingleAccount(int id)
        {
            return _context.account.FirstOrDefault(a => a.accountid.Equals(id));
        }

        public Product GetSingleProduct(int id)
        {
            return _context.product.FirstOrDefault(p => p.productid.Equals(id));
        }

        public void UpdateProduct(Product product)
        {
            _context.product.Update(product);
            _context.SaveChanges();
        }

        public void UpdateUser(Account account)
        {
            _context.account.Update(account);
            _context.SaveChanges();
        }



    }
}
