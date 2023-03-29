using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SZTGUI_LAB_4
{
    public class ViewModel
    {
        private List<Food> menu;
        public ViewModel()
        {
            menu = new List<Food>()
            {
                new Food("Sör", Food.Foods.Drink, 890),
                new Food("Kóla", Food.Foods.Drink, 690),
                new Food("Víz", Food.Foods.Drink, 450),
                new Food("Lángos", Food.Foods.MainCourse, 1100),
                new Food("Bolognai", Food.Foods.MainCourse, 1250),
                new Food("Marlenka", Food.Foods.Dessert, 990),
                new Food("Burger", Food.Foods.Appetizer, 890)
            };
        }

    }
    public class Food
    {
        private string name;
        private Foods type;
        private int price;

        public Food(string name, Foods type, int price)
        {
            this.name = name;
            this.type = type;
            this.price = price;
        }

        public string Name
        {
            get { return name; }
            set { name = value; }
        }
        public Foods Type
        {
            get { return type; }
            set { type = value; }
        }
        public int Price
        {
            get { return price; }
            set { price = value; }




    }
    public enum Foods
    {
        Appetizer, Drink, MainCourse, Dessert
    }
}
