using DataAccesLayer;
using Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer
{
    public class CategoryManager
    {
        Repository<Category> repCategory = new Repository<Category>();
        string[] categories = { "Giyim", "Ayakkabı", "Kişisel Bakım", "Saat & Aksesuar", "İç Giyim" };
        public CategoryManager()
        {
            Category cat = new Category();
            if ((repCategory.Find(i => i.categoryName == "Giyim"))==null)
            {
                int counter = 0;
                for (int i = 0; i < categories.Length; i++)
                {
                    while (counter<5)
                    {
                        cat.categoryName = categories[counter];
                        counter++;
                        repCategory.Insert(cat);
                        break;
                    }
                }
            } 
        }
        public List<Category> List()
        {
            return repCategory.List();
        }
    }
}
