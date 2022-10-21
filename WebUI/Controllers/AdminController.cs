using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BusinessLogicLayer;
using Entity;

namespace WebUI.Controllers
{
    public class AdminController : Controller
    {
        private AdminManager adminManager = new AdminManager();
        private ProductManager productManager = new ProductManager();
        private CategoryManager categoryManager = new CategoryManager();
        public ActionResult AdminLogin()
        {
            Admin admin = new Admin();
            return View(admin);
        }

        [HttpPost]
        public ActionResult AdminLogin(Admin admin)
        {
            int answer = adminManager.AdminLogin(admin);
            if (answer == 1)
            {
                return RedirectToAction("ProductList", "Admin");
                //Giriş başarılı ve ürün listeleme ekranına aktarılacaktır.
            }
            else if (answer == 0)
            {
                //Kayıtlı Admin Bulunamadı
                return View(admin);
            }
            else
            {
                //Şifre Yanlış
                return View(admin);
            }
            return View(admin);
        }

        public ActionResult ProductList()
        {
            var productList = productManager.ProductList();
            return View(productList);
        }

        public ActionResult ProductSave()
        {
            List<Category> category = categoryManager.List();
            ViewBag.category = category;
            return View();
        }

        [HttpPost]
        public ActionResult ProductSave(Product product)
        {
            if (product.productPhoto != null)
            {
                if (Request.Files.Count > 0)
                {
                    string fileName = Path.GetFileName(Request.Files[0].FileName);
                    //string fileExtention=Path.GetExtension(Request.Files[0].FileName);
                    string path = "~/photo/" + fileName;//+ fileExtention;
                    Request.Files[0].SaveAs(Server.MapPath(path));
                    product.productPhoto = "/photo/" + fileName;//+ fileExtention;
                }
            }
            productManager.ProductSave(product);
            return RedirectToAction("ProductList", "Admin");
        }

        public ActionResult ProductEdit(int Id)
        {
            List<Category> category = categoryManager.List();
            ViewBag.category = category;
            var product = productManager.ProductFind(Id);
            return View(product);
        }
        // ? bu işaret Id kısmının null gelebileceği anlamına gelmektedir.
        [HttpPost]
        public ActionResult ProductEdit(Product editProduct)
        {
            if (editProduct.productPhoto!=null)
            {
                if (Request.Files.Count > 0)
                {
                    string fileName = Path.GetFileName(Request.Files[0].FileName);
                    //string fileExtention=Path.GetExtension(Request.Files[0].FileName);
                    string path = "~/photo/" + fileName;//+ fileExtention;
                    Request.Files[0].SaveAs(Server.MapPath(path));
                    editProduct.productPhoto = "/photo/" + fileName;//+ fileExtention;
                }
            }
            productManager.ProductEdit(editProduct);
            return RedirectToAction("ProductList", "Admin");
        }

        public ActionResult ProductDelete(int? Id)
        {
            productManager.ProductDelete(Id.Value);
            return RedirectToAction("ProductList", "Admin");
        }
        // Bu kısımda admin tarafından ürünlerin listesi görüntülenmesi lazım ürün eklemek için yukarı kısımdan productsave kullanılabilir.
        // Listede bulunan ürünlerin edit delete işlemleri içinde controller gerekmektedir. 
    }
}