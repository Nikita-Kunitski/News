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
using System.Net;
using System.Text.RegularExpressions;

namespace NewsApplication
{
    /// <summary>
    /// Логика взаимодействия для VK.xaml
    /// </summary>
    public partial class VK : Page
    {
        public VK()
        {
            InitializeComponent();
        }
        private int appId = 6032180; ///id приложения
        private int userid;
        private string accessToken;

        private enum VkontakteScopeList
        {
            notify = 1,
            friends = 2,
            photos = 4,
            audio = 8,
            video = 16,
            offers = 32,
            questions = 64,
            pages = 128,
            link = 256,
            notes = 2048,
            messages = 4096,
            wall = 8192,
            docs = 131072
        }
        private void Load(object sender, RoutedEventArgs e)
        {
            try
            {
                webBrowser1.Navigate(string.Format("https://api.vk.com/oauth/authorize?client_id={0}&scope={1}&display=page&response_type=token&revoke=1", appId, VkontakteScopeList.wall));
            }
            catch
            {
                MessageBox.Show("Проверьте соединение!");
                NavigationService.Navigate(new Uri("HomePage.xaml", UriKind.Relative));
            }
        }

        private void webBrowser1_LoadCompleted(object sender, NavigationEventArgs e)
        {
            if (e.Uri.ToString().IndexOf("access_token") != -1)
            {
                Regex myReg = new Regex(@"(?<name>[\w\d\x5f]+)=(?<value>[^\x26\s]+)", RegexOptions.IgnoreCase | RegexOptions.Singleline);
                foreach (Match m in myReg.Matches(e.Uri.ToString()))
                {
                    if (m.Groups["name"].Value == "access_token")
                    {
                        accessToken = m.Groups["value"].Value;
                    }
                    else if (m.Groups["name"].Value == "user_id")
                    {
                        userid = Convert.ToInt32(m.Groups["value"].Value);
                    }
                }

                Console.WriteLine(accessToken);

                string s = "Post made using the application 'News'© | 2017 \n Author:Nikita Kunitski";

                WebRequest req = WebRequest.Create(String.Format("https://api.vk.com/method/wall.post?owner_id={0}&message={1}&access_token={2}&v=5.64", userid, s, accessToken));

                WebResponse response = req.GetResponse();
                NavigationService.Navigate(new Uri("HomePage.xaml", UriKind.Relative));
            }
        }
    }
}
