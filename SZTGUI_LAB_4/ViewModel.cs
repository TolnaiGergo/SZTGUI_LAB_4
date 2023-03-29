using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Media;

namespace SZTGUI_LAB_4
{
    public class ViewModel
    {
        private BindingList<Food> menu;
        private BindingList<Food> filteredList;
        private BindingList<Food> orderList;
        private List<Foods> filters;
        private bool isFilterOn;
        private Foods selectedFilter;
        private Food selectedMenu;
        private Food selectedOrder;
        public BindingList<Food> Menu 
        {
            get
            {
                if (isFilterOn)
                {
                    FilterMenu(selectedFilter);
                    return filteredList;
                }
                else
                {
                    filteredList.Clear();
                    foreach (var item in menu)
                    {
                        filteredList.Add(item);
                    };
                    return filteredList;
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
        public BindingList<Food> OrderList
        {
            get { return orderList;}
        }
        public ViewModel()
        {
            menu = new BindingList<Food>()
            {
                new Food("Sör", Foods.Drink, 890),
                new Food("Kóla", Foods.Drink, 690),
                new Food("Víz", Foods.Drink, 450),
                new Food("Lángos", Foods.MainCourse, 1100),
                new Food("Bolognai", Foods.MainCourse, 1250),
                new Food("Marlenka", Foods.Dessert, 990),
                new Food("Burger", Foods.Appetizer, 890)
            };
            filteredList = new BindingList<Food>();
            filters = new List<Foods>()
            {
                Foods.Appetizer,
                Foods.Drink,
                Foods.MainCourse,
                Foods.Dessert
            };
            orderList = new BindingList<Food>();

        }
        public void FilterMenu(Foods filter)
        { 
            filteredList.Clear();
            foreach(var item in menu.ToList().FindAll(x => x.Type == filter))
            {
                filteredList.Add(item);
            }
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
        public Food SelectedOrder
        {
            get { return selectedOrder; }
            set { selectedOrder = value; }
        }
    }
    public class Food : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler? PropertyChanged;
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
            set { name = value; OnPropertyChanged(); }
        }
        public Foods Type
        {
            get { return type; }
            set { type = value; OnPropertyChanged(); }
        }
        public int Price
        {
            get { return price; }
            set { price = value; OnPropertyChanged(); }
        }
        private void OnPropertyChanged([CallerMemberName] string propertyName = "")
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null)
                handler(this, new PropertyChangedEventArgs(propertyName));
        }

        
    }
    public enum Foods
    {
        Appetizer, Drink, MainCourse, Dessert
    }
}
