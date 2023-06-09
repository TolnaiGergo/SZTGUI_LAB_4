﻿using System;
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

        private void menuBox_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            var item = ItemsControl.ContainerFromElement(sender as ListBox, e.OriginalSource as DependencyObject) as ListBoxItem;
            if (item != null)
            {
                new FoodEditor(item.DataContext as Food).ShowDialog();
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if ((DataContext as ViewModel).SelectedMenu != null)
                (DataContext as ViewModel).OrderList.Add((DataContext as ViewModel).SelectedMenu);
            OrderChanged();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            if ((DataContext as ViewModel).SelectedOrder != null)
                (DataContext as ViewModel).OrderList.Remove((DataContext as ViewModel).SelectedOrder);
            OrderChanged();
        }

        private void OrderChanged()
        {
            if ((DataContext as ViewModel).OrderList != null)
            {
                int sum = 0;
                foreach (var item in (DataContext as ViewModel).OrderList)
                    sum += item.Price;
                if ((DataContext as ViewModel).OrderList.Count() != 0)
                    sumLabel.Content = $"{sum} Ft";
                else
                    sumLabel.Content = "0 Ft";
            }
            else
                sumLabel.Content = $"??? Ft";
        }
        private void selectionChanged(object sender, SelectionChangedEventArgs e)
        {
            addButton.IsEnabled = (DataContext as ViewModel).SelectedMenu != null;
            removeButton.IsEnabled = (DataContext as ViewModel).SelectedOrder != null;
        }
    }
}
