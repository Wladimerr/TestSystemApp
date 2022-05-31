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

namespace TestSystemApp.Users.Windows
{
    /// <summary>
    /// Логика взаимодействия для WindowMainForUser.xaml
    /// </summary>
    public partial class WindowMainForUser : Window
    {
        public WindowMainForUser()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            Title = "Пользователь - " + CurrentUser.CurUser.last_name + " " + CurrentUser.CurUser.first_name;
            fMainUser.NavigationService.Navigate(new Uri("Users/Pages/PageMainTests.xaml", UriKind.Relative));
        }

        private void Window_Closed(object sender, EventArgs e)
        {
            Application.Current.MainWindow.Close();
        }
    }
}
