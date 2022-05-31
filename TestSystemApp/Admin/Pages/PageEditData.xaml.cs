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
    /// Логика взаимодействия для PageEditData.xaml
    /// </summary>
    public partial class PageEditData : Page
    {
        public PageEditData()
        {
            InitializeComponent();
        }

        private void dgTests_DataContextChanged(object sender, DependencyPropertyChangedEventArgs e)
        {

        }

        private void dgQuestions_DataContextChanged(object sender, DependencyPropertyChangedEventArgs e)
        {

        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            dgTests.ItemsSource = db.GetContext().Tests.ToList();
        }

        private void dgTests_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            dgQuestions.ItemsSource = db.GetContext().Questions.ToList().Where(i => i.test_id == ((Model.DataSource.Tests)dgTests.SelectedItem).id);
            tbQuestions.Text = ("Вопросы к тесту: \"" + ((Model.DataSource.Tests)dgTests.SelectedItem).name + "\"");
        }
    }
}
