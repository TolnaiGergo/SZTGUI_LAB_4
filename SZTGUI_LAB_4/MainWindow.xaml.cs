using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace SZTGUI_LAB_4
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            this.DataContext = new ViewModel();
        }

        private void CheckBox_Unchecked(object sender, RoutedEventArgs e)
        {
            (DataContext as ViewModel).IsFilterOn = false;
        }

        private void CheckBox_Checked(object sender, RoutedEventArgs e)
        {
            (DataContext as ViewModel).IsFilterOn = true;
        }

        private void menuBox_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            var item = ItemsControl.ContainerFromElement(sender as ListBox, e.OriginalSource as DependencyObject) as ListBoxItem;
            if (item != null)
            {
                new FoodEditor(item.DataContext as Food).ShowDialog();
            }
        }
    }
}
