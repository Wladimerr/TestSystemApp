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
using TestSystemApp.Classes;
using TestSystemApp.Model.DAO;
using TestSystemApp.Model.DataSource;

namespace TestSystemApp.Users.Windows
{
    /// <summary>
    /// Логика взаимодействия для WindowEditUserData.xaml
    /// </summary>
    public partial class WindowEditUserData : Window
    {
        Model.DataSource.Users user = CurrentUser.CurUser;

        public WindowEditUserData()
        {
            InitializeComponent();
        }

        private void bApply_Click(object sender, RoutedEventArgs e)
        {
            saveData();
        }

        private void bClear_Click(object sender, RoutedEventArgs e)
        {
            clearField();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            loadData();
        }

        private void Window_Closed(object sender, EventArgs e)
        {
            //if (MessageBox.Show("Вы действительно хотите выйти?\nИзменения не сохранятся!", "Выход", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
            //{
            //    Close();
            //}
        }

        private void loadData()
        {
            tbLogin.Text = user.login;
            tbFIO.Text = user.last_name + " " + user.first_name + " " + user.patronymic;
        }

        private void saveData()
        {
            if (checkEmptyFields())
            {
                if (Validator.IsEqualPass(pbRepeatPassword.Password, pbPassword.Password))
                {
                    if (Validator.IsValidatePass(pbPassword.Password))
                    {
                        if (db.GetContext().Users.ToList().Find(x => x.login == tbLogin.Text) == null)
                        {
                            var fio = Validator.SeparateFIO(tbFIO.Text);

                            if (fio != null && fio.Length == 3)
                            {
                                user.role_id = 2;
                                user.first_name = fio[1];
                                user.last_name = fio[0];
                                user.patronymic = fio[2];
                                user.login = tbLogin.Text;
                                user.password = pbPassword.Password;

                                SaveUser();
                            }
                            else if (fio != null && fio.Length == 2)
                            {
                                user.role_id = 2;
                                user.first_name = fio[1];
                                user.last_name = fio[0];
                                user.login = tbLogin.Text;
                                user.password = pbPassword.Password;

                                SaveUser();
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

        private void SaveUser()
        {
            db.GetContext().SaveChangesAsync();
            MessageBox.Show("Данные изменены!", "Успешно");
            this.Close();
        }

        private bool checkEmptyFields()
        {
            if (tbLogin.Text.Length > 0 &&
                pbPassword.Password.Length > 0 &&
                pbRepeatPassword.Password.Length > 0 &&
                tbFIO.Text.Length > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        private void clearField()
        {
            tbFIO.Text = "";
            tbLogin.Text = "";
            pbPassword.Password = null;
            pbRepeatPassword.Password = null;
        }
    }
}
