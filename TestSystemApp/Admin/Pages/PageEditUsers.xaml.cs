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
using TestSystemApp.Model.DAO;

namespace TestSystemApp.Admin.Pages
{
    /// <summary>
    /// Логика взаимодействия для PageEditUsers.xaml
    /// </summary>
    public partial class PageEditUsers : Page
    {
        public PageEditUsers()
        {
            InitializeComponent();
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            dgUsers.ItemsSource = db.GetContext().Users.ToList();
        }

        private void dgUsers_DataContextChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            db.GetContext().SaveChangesAsync();
        }
    }
}
