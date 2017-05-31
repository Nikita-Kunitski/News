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
using System.ComponentModel.DataAnnotations;
using System.Windows.Shapes;

namespace NewsApplication
{
    /// <summary>
    /// Логика взаимодействия для Registration.xaml
    /// </summary>
    public partial class Registration : Page
    {
        public Registration()
        {
            InitializeComponent();
        }
        private void back(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Uri("Authorization.xaml", UriKind.Relative));
        }

        private void Registration_(object sender, RoutedEventArgs e)
        {
            RegistrationUser user = new RegistrationUser
            {
                Login = RegistrationLogin.Text,
                Email = RegistrationEmail.Text,
                Last_Name = RegistrationLastName.Text,
                Name = RegistrationName.Text
            };
            if (Validate(user))
            {
                Repo.Helpers.Hashing.SaltedHash obj = new Repo.Helpers.Hashing.SaltedHash(RegistrationPassword.Password);
                using (NewsApplicationEntities db = new NewsApplicationEntities())
                {
                    db.Profiles.Add(new Profile
                    {
                        Login = user.Login,
                        Email = user.Email,
                        Hash = obj.Hash,
                        Salt = obj.Salt,
                        Last_Name = user.Last_Name,
                        Name = user.Name
                    });
                    db.SaveChanges();
                    MessageBox.Show("Регистрация прошла успешно!");
                    NavigationService.Navigate(new Uri("Authorization.xaml", UriKind.Relative));
                }

            }
        }
        private static bool Validate(RegistrationUser user)
        {
            var results = new List<System.ComponentModel.DataAnnotations.ValidationResult>();
            var context = new ValidationContext(user);
            if (!Validator.TryValidateObject(user, context, results, true))
            {
                foreach (var item in results)
                {
                    MessageBox.Show(item.ErrorMessage);
                    return false;
                }
            }
            return true;
        }
    }
}
