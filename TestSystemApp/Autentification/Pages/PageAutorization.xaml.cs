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
using TestSystemApp.Admin.Windows;
using TestSystemApp.Model.DAO;
using TestSystemApp.Users.Windows;

namespace TestSystemApp.Autentification.Pages
{
    /// <summary>
    /// Логика взаимодействия для PageAutorization.xaml
    /// </summary>
    public partial class PageAutorization : Page
    {
        string loginCurUser, passwordCurUser;

        public PageAutorization()
        {
            InitializeComponent();
        }

        private void bRegistration_Click(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new Uri("Autentification/Pages/PageRegistration.xaml", UriKind.Relative));
        }

        private void bLogin_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (tbLogin.Text != "" && pbPassword.Password != "")
                {
                    loginCurUser = tbLogin.Text;
                    passwordCurUser = pbPassword.Password;
                    var user = db.GetContext().Users.ToList().Find(l => l.login == loginCurUser);

                    if (user != null)
                    {
                        if (passwordCurUser == user.password)
                        {
                            CurrentUser.CurUser = user;
                            OpenWindow(user.role_id);
                        }
                        else MessageBox.Show("Неверный пароль!");
                    }
                    else MessageBox.Show("Пользователь не найден!");
                }
                else MessageBox.Show("Заполните поля");
            }
            catch
            {
                MessageBox.Show("Неверный пароль!");
            }
        }

        private void ClearField()
        {
            tbLogin.Text = "";
            pbPassword.Password = "";
        }

        private void OpenWindow(int role_id)
        {
            switch (role_id)
            {
                case 1:
                    new WindowMainForAdmin().Show();
                    Application.Current.MainWindow.Hide();
                    break;
                case 2:
                    new WindowMainForUser().Show();
                    Application.Current.MainWindow.Hide();
                    break;
            }
        }

        private void bClear_Click(object sender, RoutedEventArgs e)
        {
            ClearField();
        }
    }
}
