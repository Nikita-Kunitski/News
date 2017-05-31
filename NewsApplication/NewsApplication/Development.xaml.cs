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
    /// Логика взаимодействия для Development.xaml
    /// </summary>
    public partial class Development : Page
    {

        public Development()
        {
            
            InitializeComponent();
        }

        private void Load(object sender, RoutedEventArgs e)
        {
            label.Content = MainWindow.user.Login;
            if (MainWindow.user.Login == "admin")
            {
                url.Visibility = Visibility.Hidden;
                label1.Visibility = Visibility.Visible;
                button.Visibility = Visibility.Hidden;
                button1.Visibility = Visibility.Hidden;
                button2.Visibility = Visibility.Visible;
                URL.Visibility = Visibility.Hidden;
                using (NewsApplicationEntities db = new NewsApplicationEntities())
                {
                    var tab = db.NewURLs;
                    foreach (var item in tab)
                    {
                        listBox.Items.Add(item.Login);
                        listBox1.Items.Add(item.New_URL);
                    }
                }
            }
            else {
                listBox.Visibility = Visibility.Hidden;
                listBox1.Visibility = Visibility.Hidden;
            }
        }

        private void Back(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Uri("HomePage.xaml", UriKind.Relative));
        }

        private void Add(object sender, RoutedEventArgs e)
        {
            if (url.Text == string.Empty)
            {
                MessageBox.Show("Заполните поле!");
                return;
            }
            else {
              
              
                    using (NewsApplicationEntities db = new NewsApplicationEntities())
                    {
                        var tab = db.NewURLs;
                        int i = 0;
                        foreach (var item in tab)
                        {
                            i++;
                        }
                        db.NewURLs.Add(new NewURL { Number = i, Login = MainWindow.user.Login, New_URL = url.Text });
                        db.SaveChanges();
                        MessageBox.Show("Ссылка успешно добавлена!");
                    }
               
            }
        }

        private void Back_admin(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Uri("HomePage.xaml", UriKind.Relative));
        }
    }
}
