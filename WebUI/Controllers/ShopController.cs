using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Entity;
using BusinessLogicLayer;

namespace WebUI.Controllers
{
    public class ShopController : Controller
    {
        private ProductManager productManager = new ProductManager();
        private UserManager userManager = new UserManager();
        public ActionResult Products()
        {
            return View();
        }
        public ActionResult ProductDetails()
        {
            return View();
        }
        public ActionResult Checkout()
        {
            return View();
        }
        public ActionResult Cart()
        {
            return View();
        }

        public ActionResult LoginUser()
        {
            return View(new User());
        }
        [HttpPost]
        public ActionResult LoginUser(string email, string password)
        {
            int answer=userManager.LoginControl(email, password); // bu işlem karşılığında int veri tipi dönecektir. 0,1,-1 değerlerine göre hata verecek veya giriş başarılı olacaktır.
            return View();
        }
        [HttpPost]
        public ActionResult Register(User register)
        {
            userManager.UserSave(register);// email adresi kontrol edilecektir. email başka biri tarafından kullanılıyorsa hata verecek yoksa kayıt işlemi gerçekleşecektir.
            return View();
        }
    }
}