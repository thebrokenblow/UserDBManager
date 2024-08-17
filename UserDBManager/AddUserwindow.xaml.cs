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
using System.Windows.Shapes;
using UserDBManager.ViewModel;

namespace UserDBManager
{
    /// <summary>
    /// Логика взаимодействия для AddUserwindow.xaml
    /// </summary>
    public partial class AddUserwindow : Window
    {
        public AddUserwindow()
        {
            InitializeComponent();
            DataContext = new AddUserViewModel();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var mainWindow = new MainWindow();
            mainWindow.Show();

            Close();
        }
    }
}
