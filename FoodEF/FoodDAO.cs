using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodEF
{
    public class FoodDAO
    {
        public List<Food> GetAll ()
        {
            using (FoodDBEntities fd = new FoodDBEntities())
            {
                 return fd.Foods.ToList();
            }
        }

        public Food GetFoodById (int id)
        {
            using (FoodDBEntities fd = new FoodDBEntities())
            {
                return fd.Foods.FirstOrDefault(f => f.ID == id);
            }
        }

        public void AddFood (Food f)
        {
            using (FoodDBEntities fd = new FoodDBEntities())
            {
                fd.Foods.Add(f);
                fd.SaveChanges();
            }
        }

        public void UpdateFood (Food f)
        {
            Food food = new Food();
            using (FoodDBEntities fd = new FoodDBEntities())
            {
                food = fd.Foods.FirstOrDefault(fo => fo.ID == f.ID);
                food.Calories = f.Calories;
                food.Grade = f.Grade;
                food.Ingridients = f.Ingridients;
                food.Name = f.Name;
                fd.SaveChanges();
            }
        }

        public void Delete (int id)
        {
            using (FoodDBEntities fd = new FoodDBEntities())
            {
                Food food = fd.Foods.FirstOrDefault(f => f.ID == id);
                fd.Foods.Remove(food);
                fd.SaveChanges();
                
            }
        }

        public List<Food> GetByName (string name)
        {
            using (FoodDBEntities fd = new FoodDBEntities())
            {
               return fd.Foods.Where(f => f.Name.ToUpper().Contains(name.ToUpper())).ToList();
            }
        }

        public List<Food> BiggetThanCalories (int calories)
        {
            List<Food> foods = new List<Food>();
            using (FoodDBEntities fd = new FoodDBEntities())
            {
              return  foods = fd.Foods.Where(f => f.Calories > calories).ToList();
            }
        }

        public List<Food> GetAllBySearch (int maxCalories, string name, int minGrade, int minCalories)
        {
            List<Food> foods = new List<Food>();
            using (FoodDBEntities fd = new FoodDBEntities())
            {
                foods = fd.Foods.Where(f => f.Grade > minGrade &&
                f.Calories > minCalories && f.Calories < maxCalories &&
                (f.Name == "" || f.Name.ToUpper().Contains(name.ToUpper()))).ToList();
            }
            return foods;
               
        }
    }
}
