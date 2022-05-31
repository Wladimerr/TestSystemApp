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
using TestSystemApp.Classes;
using TestSystemApp.Model.DAO;
using TestSystemApp.Model.DataSource;

namespace TestSystemApp.Users.Pages
{
    /// <summary>
    /// Логика взаимодействия для PageTest.xaml
    /// </summary>
    public partial class PageTest : Page
    {
        Tests test;
        Model.DataSource.Users user;

        public PageTest(Model.DataSource.Users _user, Tests _test)
        {
            InitializeComponent();
            user = _user;
            tbFIO.Text = user.last_name + " " + user.first_name + " " + user.patronymic;
            test = _test;
            tbTestName.Text = test.name;
        }

        private void bStop_Click(object sender, RoutedEventArgs e)
        {
            if(MessageBox.Show("Завершить тест?", "Подтверждение выхода", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
            {
                endTest();
            }
        }

        private void endTest()
        {
            this.NavigationService.Navigate(new Uri("/Users/Pages/PageMainTests.xaml", UriKind.Relative));
            CurrentTest.numberQuestion = 1;
            CurrentTest.result = 0;
        }

        private void bNext_Click(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new PageTest(user, test));
            CurrentTest.numberQuestion++;
            checkAnswer();
        }

        private void checkAnswer()
        {
            foreach(RadioButton rb in wpAnswers.Children)
            {
                if(rb.IsChecked == true && rb.Name == "rbVar0")
                {
                    CurrentTest.result++;
                }
            }
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            if(db.GetContext().Questions.ToList().Where(t => t.test_id == test.id).Count() > CurrentTest.numberQuestion - 1)
            {
                var quest = db.GetContext().Questions.ToList().Find(t => t.number == CurrentTest.numberQuestion && t.test_id == test.id);
                tbNumber.Text = "Вопрос №" + CurrentTest.numberQuestion.ToString();
                tbQuestion.Text = quest.question;

                generateRandomRB(quest);
            }
            else if(db.GetContext().Questions.ToList().Where(t => t.test_id == test.id).Count() != 0)
            {
                var newPassedTest = new PassedTests
                {
                    id_test = test.id,
                    id_user = user.id,
                    result = CurrentTest.result,
                    score = Convert.ToDouble(CurrentTest.result) / Convert.ToDouble(db.GetContext().Questions.ToList().Where(t => t.test_id == test.id).Count()) * 100,
                    time_spent_sec = 0,
                    date = DateTime.Now
                };
                db.GetContext().PassedTests.Add(newPassedTest);
                db.GetContext().SaveChanges();
                MessageBox.Show($"Result {CurrentTest.result} / {db.GetContext().Questions.ToList().Where(t => t.test_id == test.id).Count()}");
                endTest();
            }
        }

        private void generateRandomRB(Questions quest)
        {
            var listRadioButton = new List<RadioButton>();
            var listRadioButtonRandom = new List<RadioButton>();
            var listQuestions = new List<string>();
            Random random = new Random();

            listQuestions.Add(quest.answer);
            listQuestions.Add(quest.answer_v1);
            listQuestions.Add(quest.answer_v2);
            listQuestions.Add(quest.answer_v3);

            for (int i = 0; i < 4; i++)
            {
                RadioButton b = new RadioButton();
                b.Content = listQuestions[i];
                b.Name = "rbVar" + i;
                b.Margin = new Thickness(15, 0, 15, 0);
                listRadioButton.Add(b);
            }

            foreach (var rb in listRadioButton)
            {
                int j = random.Next(listRadioButtonRandom.Count + 1);
                if (j == listRadioButtonRandom.Count)
                {
                    listRadioButtonRandom.Add(rb);
                }
                else
                {
                    listRadioButtonRandom.Add(listRadioButtonRandom[j]);
                    listRadioButtonRandom[j] = rb;
                }
            }
            foreach (RadioButton b in listRadioButtonRandom)
            {
                wpAnswers.Children.Add(b);
            }
        }
    }
}
