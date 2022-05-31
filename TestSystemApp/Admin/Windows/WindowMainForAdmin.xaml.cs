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

namespace TestSystemApp.Admin.Windows
{
    /// <summary>
    /// Логика взаимодействия для WindowMainForAdmin.xaml
    /// </summary>
    public partial class WindowMainForAdmin : Window
    {
        public WindowMainForAdmin()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            init();
            fEditData.Navigate(new Uri("/Admin/Pages/PageEditUsers.xaml", UriKind.Relative));
        }

        private void Window_Closed(object sender, EventArgs e)
        {
            Application.Current.MainWindow.Close();
        }

        private void init()
        {
            Title = "Панель Администратора - " + CurrentUser.CurUser.last_name + " " + CurrentUser.CurUser.first_name;
        }

        private void bEdit_Click(object sender, RoutedEventArgs e)
        {
            fEditData.Navigate(new Uri("/Admin/Pages/PageEditData.xaml", UriKind.Relative));
        }

        private void bEditUsers_Click(object sender, RoutedEventArgs e)
        {
            fEditData.Navigate(new Uri("/Admin/Pages/PageEditUsers.xaml", UriKind.Relative));
        }
    }
}
