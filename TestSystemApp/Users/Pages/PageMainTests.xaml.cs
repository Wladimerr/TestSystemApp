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
using TestSystemApp.Users.Windows;

namespace TestSystemApp.Users.Pages
{
    /// <summary>
    /// Логика взаимодействия для PageMainTests.xaml
    /// </summary>
    public partial class PageMainTests : Page
    {
        public PageMainTests()
        {
            InitializeComponent();
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            init();
        }

        private void init()
        {
            lvPassedTests.ItemsSource = db.GetContext().PassedTests.ToList().Where(i => i.id_user == CurrentUser.CurUser.id);
            tbLogin.Text = CurrentUser.CurUser.login;
            tbUserFIO.Text = CurrentUser.CurUser.last_name + " " + CurrentUser.CurUser.first_name + " " + CurrentUser.CurUser.patronymic;
            cbTests.ItemsSource = db.GetContext().Tests.ToList().Select(x => x.name);
        }

        private void bUpdate_Click(object sender, RoutedEventArgs e)
        {
            init();
        }

        private void bEdit_Click(object sender, RoutedEventArgs e)
        {
            new WindowEditUserData().ShowDialog();
            init();
        }

        private void bStartTest_Click(object sender, RoutedEventArgs e)
        {
            if(cbTests.SelectedItem != null)
            {
                this.NavigationService.Navigate(new PageTest(CurrentUser.CurUser, db.GetContext().Tests.ToList().Find(i => i.id == (db.GetContext().Tests.ToList().Find(n => n.name == cbTests.SelectedItem.ToString())).id)));
            }
            else
            {
                MessageBox.Show("Выберите тест!", "Ошибка");
            }
        }
    }
}
