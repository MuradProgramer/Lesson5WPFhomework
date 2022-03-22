using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
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

namespace Lesson5WPFhomework
{
    /// <summary>
    /// Interaction logic for AddEdit.xaml
    /// </summary>
    public partial class AddEdit : Window
    {
        private Product tProduct;

        public Product TProduct 
        { 
            get => tProduct;
            set
            {
                tProduct = value;
                OnPropertyChanged();
            }
        }

        public AddEdit(Product product)
        {
            TProduct = product;

            InitializeComponent();
            DataContext = this;
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null) handler(this, new PropertyChangedEventArgs(propertyName));
        }

        private void Border_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (Name.Text != "" && Price.Text != "" && Count.Text != "")
            {
                double number;
                var succes1 = double.TryParse(Price.Text, out number);
                int number2;
                var succes2 = int.TryParse(Count.Text, out number2);
                if (succes1 && succes2)
                {
                    TProduct = new Product(Name.Text, number, number2);
                    Close();
                }
            }
        }
    }
}
