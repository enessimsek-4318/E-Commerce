using DataAccesLayer;
using Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer
{
    public class AdminManager
    {
        Repository<Admin> repAdmin = new Repository<Admin>();
        public AdminManager()
        {
            if ((repAdmin.Find(i=> i.adminName=="enes431811@gmail.com")==null))
            {
                repAdmin.Insert(new Admin { adminName = "enes431811@gmail.com", password = "Enes4318" });
            }
        }
        public int AdminLogin(Admin admin)
        {
            var adminControl=repAdmin.Find(i => i.adminName == admin.adminName);
            if (adminControl==null)
            {
                return 0; // Admin bulunamadı
            }
            else
            {
                if (adminControl.password==admin.password)
                {
                    return 1; // Admin girişi Başarılı
                }
                else
                {
                    return -1; // şifre yanlış
                }
            }
        }
    }
}
