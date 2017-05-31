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

namespace NewsApplication
{
    /// <summary>
    /// Логика взаимодействия для MyAccount.xaml
    /// </summary>
    public partial class MyAccount : Page
    {
        public MyAccount()
        {
            InitializeComponent();
        }

        private void Load(object sender, RoutedEventArgs e)
        {
            login.Content = MainWindow.user.Login;
            emailUser.Content = MainWindow.user.Email;
            nameUser.Content = MainWindow.user.Name;
            lastNameUser.Content = MainWindow.user.Last_Name;
            using (NewsApplicationEntities db = new NewsApplicationEntities())
            {
                var tab = db.Dates;
                foreach (var item in tab)
                {
                    if (item.Login == MainWindow.user.Login)
                        listBox.Items.Add(item.DATE1);
                }
            }
        }

        private void DateAdd(object sender, RoutedEventArgs e)
        {
            if (date.SelectedDate == null)
            {
                MessageBox.Show("Выберите дату");
                return;
            }
            else {
                using (NewsApplicationEntities db = new NewsApplicationEntities())
                {
                    var tab = db.Dates;
                    int i = 0;
                    foreach (var item in tab)
                    {
                        i++;
                    }
                    db.Dates.Add(new Date { DATE1=(DateTime)date.SelectedDate, ID=i+1, Login=MainWindow.user.Login});
                    db.SaveChanges();
                    MessageBox.Show("Дата добавлена!");
                }
            }
        }

        private void Back(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Uri("HomePage.xaml", UriKind.Relative));
        }
    }
}
