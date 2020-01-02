using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class EFProductRepository : IRepository<Product>
    {
        private ProductDBContext _db;
        private bool disposed = false;

        public EFProductRepository(ProductDBContext db)
        {
            if (db != null)
                _db = db;
            else
                throw new ArgumentNullException();
        }

        public void Create(Product item)
        {
            //var entity = GetList().Where(x => (x.Name == item.Name) && (x.Price == item.Price) && (_db.Providers.Where(y => (y.Name == item.Provider.Name) && (y.Description == item.Provider.Description)).Count() != 0));
            var entity = GetList().Where(x => (x.Name == item.Name) && (x.Price == item.Price) && (x.Provider.Name == item.Provider.Name));
            if (entity.Count() == 0)
            {
                _db.Products.Add(item);
                Save();
            }
            else
            { throw new Exception("There is already the same element in db"); }

        }

        public void Delete(int id)
        {
            Product item = _db.Products.Find(id);
            if (item == null)
                _db.Products.Remove(item);
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }

        public Product Get(int id)
        {
            return _db.Products.Find(id);
        }

        public IEnumerable<Product> GetList()
        {
            return _db.Products;
        }

        public void Save()
        {
            _db.SaveChanges();
        }

        public void Update(Product item)
        {
            _db.Entry(item).State = EntityState.Modified;
        }
    }
}
