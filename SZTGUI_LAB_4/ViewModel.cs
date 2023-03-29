using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace SZTGUI_LAB_4
{
    public class ViewModel
    {
        private List<Food> menu;
        private BindingList<Food> orderList;
        private List<Foods> filters;
        private bool isFilterOn;
        private Foods selectedFilter;
        private Food selectedMenu;
        private Food selectedOrder;
        public List<Food> Menu 
        { 
            get 
            {
                if(isFilterOn) 
                {
                    return GetFilteredMenu(selectedFilter);
                }
                else
                {
                    return menu;
                }
            } 
        }
        public List<Foods> Filters
        {
            get { return filters;}
        }
        public bool IsFilterOn
        {
            get { return isFilterOn; }
            set { isFilterOn = value; }
        }
        public BindingList<Food> OredrList
        {
            get { return orderList;}
        }
        public ViewModel()
        {
            menu = new List<Food>()
            {
                new Food("Sör", Foods.Drink, 890),
                new Food("Kóla", Foods.Drink, 690),
                new Food("Víz", Foods.Drink, 450),
                new Food("Lángos", Foods.MainCourse, 1100),
                new Food("Bolognai", Foods.MainCourse, 1250),
                new Food("Marlenka", Foods.Dessert, 990),
                new Food("Burger", Foods.Appetizer, 890)
            };
            filters = new List<Foods>()
            {
                Foods.Appetizer,
                Foods.Drink,
                Foods.MainCourse,
                Foods.Dessert
            };

        }
        public List<Food> GetFilteredMenu(Foods filter) 
        {
            return menu.FindAll(x => x.Type == filter);
        }
        public Foods SelectedFilter
        {
            get { return selectedFilter; }
            set { selectedFilter = value; }
        }
        public Food SelectedMenu
        {
            get { return selectedMenu; }
            set { selectedMenu = value; }
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



    }
    public enum Foods
    {
        Appetizer, Drink, MainCourse, Dessert
    }
}
