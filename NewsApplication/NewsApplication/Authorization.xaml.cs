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
using System.IO;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace NewsApplication
{

    /// <summary>
    /// Логика взаимодействия для Authorization.xaml
    /// </summary>
    public partial class Authorization : Page
    {

        public Authorization()
        {
            InitializeComponent();
        }
        private void registration_(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Uri("Registration.xaml", UriKind.Relative));
        }

        private void authorization_(object sender, RoutedEventArgs e)
        {
            try
            {
                if (AuthorizationLogin.Text == string.Empty || AuthorizationPassword.Password == string.Empty)
                    MessageBox.Show("Заполните поля!");
                else
                {
                    using (NewsApplicationEntities db = new NewsApplicationEntities())
                    {
                        var table = db.Profiles;
                        bool flag_login = false;
                        bool flag_password = false;
                        foreach (var item in table)
                        {
                            if (Equals(AuthorizationLogin.Text, item.Login))
                            {
                                flag_login = true;
                                if (Repo.Helpers.Hashing.SaltedHash.Verify(item.Hash, AuthorizationPassword.Password, item.Salt))
                                    flag_password = true;
                            }
                        }
                        if (flag_login == false)
                            MessageBox.Show("Пользователя с таким логином не существует");
                        else
                        {
                            if (flag_password == false)
                                MessageBox.Show("Неверный пароль!");
                            else
                            {
                                foreach (var item in table)
                                {
                                    if (item.Login == AuthorizationLogin.Text)
                                    {
                                        MainWindow.user = item;
                                    }
                                }
                                NavigationService.Navigate(new Uri("HomePage.xaml", UriKind.Relative));

                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                using (StreamWriter sw = new StreamWriter("ErrorReport.txt", true, System.Text.Encoding.Default))
                {
                    sw.WriteLine(DateTime.Now);
                    sw.WriteLine(ex.ToString());
                }
                return;
            }
        }
    }
}
