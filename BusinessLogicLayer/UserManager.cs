using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccesLayer;
using Entity;

namespace BusinessLogicLayer
{
    public class UserManager
    {
        Repository<User> repUser = new Repository<User>();
        public int UserSave(User register)
        {
            var emailControl=repUser.Find(i=> i.email== register.email);
            if (emailControl==null)
            {
                return repUser.Insert(register);
            }
            else
            {
                return 0;
            }
        }
        public int LoginControl(string email,string password)
        {
            var user=repUser.Find(i => i.email == email);
            if (user==null)
            {
                return 0; // Verilen email adresi ile kullanıcı bulunamadı.
            }
            else
            {
                if (password==user.password)
                {
                    return 1; // Giriş başarılı
                }
                else
                {
                    return -1; // Şifre Yanlış.
                }
            }
        }
    }
}
