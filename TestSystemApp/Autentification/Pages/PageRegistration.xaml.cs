using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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
using TestSystemApp.Model.DataSource;
using TestSystemApp.Model.DAO;
using TestSystemApp.Users.Windows;
using TestSystemApp.Classes;

namespace TestSystemApp.Autentification.Pages
{
    /// <summary>
    /// Логика взаимодействия для PageRegistration.xaml
    /// </summary>
    public partial class PageRegistration : Page
    {
        public PageRegistration()
        {
            InitializeComponent();
        }

        private void bLogin_Click(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new Uri("Autentification/Pages/PageAutorization.xaml", UriKind.Relative));
        }

        private void bClear_Click(object sender, RoutedEventArgs e)
        {
            ClearField();
        }

        private void bRegistration_Click(object sender, RoutedEventArgs e)
        {
            if(checkEmptyFields())
            {
                if (Validator.IsEqualPass(pbRepeatPassword.Password, pbPassword.Password))
                {
                    if (Validator.IsValidatePass(pbPassword.Password))
                    {
                        if(db.GetContext().Users.ToList().Find(x => x.login == tbLogin.Text) == null)
                        {
                            var fio = Validator.SeparateFIO(tbFIO.Text);

                            if (fio != null && fio.Length == 3)
                            {
                                var newUser = new Model.DataSource.Users()
                                {
                                    role_id = 2,
                                    first_name = fio[1],
                                    last_name = fio[0],
                                    patronymic = fio[2],
                                    login = tbLogin.Text,
                                    password = pbPassword.Password
                                };

                                SaveUserAndOpenWindow(newUser);
                            }
                            else if(fio != null && fio.Length == 2)
                            {
                                var newUser = new Model.DataSource.Users()
                                {
                                    role_id = 2,
                                    first_name = fio[1],
                                    last_name = fio[0],
                                    login = tbLogin.Text,
                                    password = pbPassword.Password
                                };

                                SaveUserAndOpenWindow(newUser);
                            }
                            else
                            {
                                MessageBox.Show("Заполните поле ФИО корректно!");
                            }
                        }
                        else
                        {
                            MessageBox.Show("Пользователь с таким логином уже существует!");
                        }
                    }
                    else
                    {
                        MessageBox.Show("Пароль должен содержать больше 6 символов, цифры, заглавные и строчные латинские буквы!");
                    }
                }
                else
                {
                    MessageBox.Show("Пароли не совпадают!");
                }
            }
            else
            {
                MessageBox.Show("Заполните поля!");
            }
        }
        
        private void SaveUserAndOpenWindow(Model.DataSource.Users user)
        {
            db.GetContext().Users.Add(user);
            db.GetContext().SaveChangesAsync();
            CurrentUser.CurUser = user;
            new WindowMainForUser().Show();
            Application.Current.MainWindow.Hide();
        }

        private bool checkEmptyFields()
        {
            if(tbLogin.Text.Length > 0 &&
                pbPassword.Password.Length > 0 &&
                pbRepeatPassword.Password.Length > 0 &&
                tbFIO.Text.Length > 0)
            {
                return true;
            }
            else
            {
               // MessageBox.Show("Заполните поля!");
                return false;
            }
        }

        private void ClearField()
        {
            tbLogin.Text = "";
            tbFIO.Text = "";
            pbPassword.Password = "";
            pbRepeatPassword.Password = "";
        }
    }
}
