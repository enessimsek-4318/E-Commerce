using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccesLayer
{
    public class Repository<T> where T : class // T tipinin içerisine entity tarafında oluşturmuş olduğumuz classlardan geleceğini belirtmiş oluyoruz. (Product,Admin vs...)
    {
        private DataContext db = new DataContext();
        //Birden fazla kullanıcı aynı anda database bağlantısı yapması durumunda lock kullanarak bunun önüne geçebiliriz.
        //Yine database için aynı anda iki farklı bağlantı açamaz. bunun için database connection varsa tekrar bağlantı açmaya çalışma diye belirtebiliyoruz.
        //ERP içerisinde bunun örneği mevcut. RepositoryBase class açıldı bu işlemler için. Bu projede bu işlemlere ihtiyaç duyulmamaktadır.
        public List<T> List()
        {
            return db.Set<T>().ToList();
        }
        public List<T> List(Expression<Func<T,bool>> where) // Bir koşul vererek listeleme yapmak için kullanılmaktadır.
        {
            return db.Set<T>().Where(where).ToList();
        }
        public T Find(Expression<Func<T, bool>> where) // Dönüş tipi olarak liste döndermemize gerek kalmadığı için tek bir veri geri dönderecektir.
        {
            return db.Set<T>().FirstOrDefault(where);
        }
        public int Insert(T obj)
        {
            db.Set<T>().Add(obj);
            
            return db.SaveChanges();
        }
        public int Edit(T obj)
        {
            return db.SaveChanges();
        }
        public int Delete(T obj)
        {
            db.Set<T>().Remove(obj);
            return db.SaveChanges();
        }
    }
}
