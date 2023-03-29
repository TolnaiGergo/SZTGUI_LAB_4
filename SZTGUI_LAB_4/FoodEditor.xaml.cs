using System;
using System.Collections.Generic;
using System.Linq;
using System.Printing;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace SZTGUI_LAB_4
{
    /// <summary>
    /// Interaction logic for FoodEditor.xaml
    /// </summary>
    public partial class FoodEditor : Window
    {
        private Food food;
        public Foods selectedType { get; set; }
        private List<Foods> foods;
        public FoodEditor(Food food)
        {
            this.food = food;
            InitializeComponent();
            this.DataContext = food;
            foods = new List<Foods>()
            {
                Foods.Appetizer,
                Foods.Drink,
                Foods.MainCourse,
                Foods.Dessert
            };
            typeBox.ItemsSource = foods;
            typeBox.SelectedIndex = (int)food.Type;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            food.Name = nameBox.Text;
            food.Type = typeBox.SelectedIndex >= 0 ? foods[typeBox.SelectedIndex] : food.Type;
            int price = 0;
            food.Price = int.TryParse(priceBox.Text, out price) ? price : food.Price;
            this.DialogResult = true;
        }
    }
}
