using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApi.Models;

namespace WebApi.Data
{
    public interface IDataAccessProvider
    {
        void AddProductRecord(Product product);
        void AddUserRecord(Account account);
        void AddUserPurchase(Purchase purchases);
        void DeleteProduct(int id);
        void DeleteUser(int id);
        void UpdateUser(Account account);
        void UpdateProduct(Product product);
        Product GetSingleProduct(int id);
        List<Product> GetProducts();
        Account GetSingleAccount(int id);
        List<Account> GetAccounts();
        List<Purchase> GetPurchases(int id);



    }
}
