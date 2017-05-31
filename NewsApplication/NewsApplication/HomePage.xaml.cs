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
using HtmlAgilityPack;
using System.IO;
using System.Net;

namespace NewsApplication
{
    /// <summary>
    /// Логика взаимодействия для HomePage.xaml
    /// </summary>
    public partial class HomePage : Page
    {
        public HomePage()
        {
            InitializeComponent();
        }
        public static int index_news;
        public static int ID_news;
        private void VK(object sender, MouseButtonEventArgs e)
        {

            VK_Auth obj = new VK_Auth();
            obj.ShowDialog();
        }
        //+
        private void ButtonLoacalArticleMethod(object sender, RoutedEventArgs e)
        {
            try
            {
                if (listBox.SelectedIndex == -1)
                {
                    MessageBox.Show("Выберите элемент");
                    return;
                }
                else
                {
                    using (NewsApplicationEntities db = new NewsApplicationEntities())
                    {
                        var news = db.News;
                        foreach (var item in news)
                        {
                            if (item.Section == listBox.SelectedItem.ToString())
                            {
                                listBox.Visibility = Visibility.Hidden;
                                buttonLocalArticle.Visibility = Visibility.Hidden;
                                Caption.Text = string.Empty;
                                Content.Text = string.Empty;
                                Caption.Text = item.Section;
                                Content.Text = item.Article;
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
        //+
        private void Media368MethodLabelClick(object sender, MouseButtonEventArgs e)
        {
            try
            {

                listBox.Items.Clear();
                Caption.Text = "368.Media";
                Content.Text = string.Empty;
                button_MSDN.Visibility = Visibility.Hidden;
                buttonLocalArticle.Visibility = Visibility.Hidden;
                buttonBELSAT.Visibility = Visibility.Hidden;
                System.Net.WebClient web = new System.Net.WebClient();
                web.Encoding = UTF8Encoding.UTF8;
                HtmlDocument site = new HtmlDocument();
                string str = string.Empty;
                try
                {
                    str = web.DownloadString("https://368.media/?gclid=CLHNn7-S8tMCFRIdGAodu-4L9A");
                    site.LoadHtml(str);
                }
                catch
                {
                    MessageBox.Show("Ошибка, проверьте интернет-соединение!");
                    return;
                }
                var menu = site.DocumentNode.SelectNodes("//ul[@id='menu-main-menu']//li//a");
                foreach (var item in menu)
                {
                    listBox.Items.Add(item.InnerText);
                }
                listBox.Visibility = Visibility.Visible;
                buttonSelectMenu368.Visibility = Visibility.Visible;
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
        //+
        private void MSDNMethodLabelClick(object sender, MouseButtonEventArgs e)
        {
            try
            {
                Caption.Text = "MSDN";
                Content.Text = string.Empty;
                buttonSelectNews368.Visibility = Visibility.Hidden;
                buttonBELSAT.Visibility = Visibility.Hidden;
                buttonLocalArticle.Visibility = Visibility.Hidden;
                buttonSelectMenu368.Visibility = Visibility.Hidden;
                listBox.Items.Clear();
                buttonLocalArticle.Visibility = Visibility.Hidden;
                System.Net.WebClient web = new System.Net.WebClient();
                web.Encoding = UTF8Encoding.UTF8;
                HtmlDocument links = new HtmlDocument();
                string str = string.Empty;
                try
                {
                    str = web.DownloadString("https://msdn.microsoft.com/ru-ru/library/ms123401.aspx");
                    links.LoadHtml(str);
                }
                catch
                {
                    MessageBox.Show("Ошибка, проверьте интернет-соединение!");
                    return;
                }
                var div = links.DocumentNode.SelectNodes("//div[@class='catalog']//ul//li//a");
                foreach (var item in div)
                {
                    listBox.Items.Add(item.InnerText);
                }
                listBox.Visibility = Visibility.Visible;
                button_MSDN.Visibility = Visibility.Visible;
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
        //+
        private void HomePageMethodLabelClick(object sender, MouseButtonEventArgs e)
        {
            listBox.Items.Clear();
            listBox.Visibility = Visibility.Hidden;
            button_MSDN.Visibility = Visibility.Hidden;
            buttonLocalArticle.Visibility = Visibility.Hidden;
            buttonSelectMenu368.Visibility = Visibility.Hidden;
            buttonBELSAT.Visibility = Visibility.Hidden;
            Caption.Text = string.Empty;
            Content.Text = string.Empty;
        }
        //+
        private void LocalArticleLabelClick(object sender, MouseButtonEventArgs e)
        {
            try
            {
                buttonSelectMenu368.Visibility = Visibility.Hidden;
                buttonSelectNews368.Visibility = Visibility.Hidden;
                Caption.Text = "OFFLINE";
                Content.Text = string.Empty;
                listBox.Items.Clear();
                button_MSDN.Visibility = Visibility.Hidden;
                buttonSelectMenu368.Visibility = Visibility.Hidden;
                buttonBELSAT.Visibility = Visibility.Hidden;
                buttonLocalArticle.Visibility = Visibility.Visible;
                using (NewsApplicationEntities db = new NewsApplicationEntities())
                {
                    var news = db.News;
                    foreach (var item in news)
                    {
                        listBox.Items.Add(item.Section);
                    }
                }
                listBox.Visibility = Visibility.Visible;
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
        //+
        private void ButtonMSDNMethod(object sender, RoutedEventArgs e)
        {try
            {
                Caption.Text = string.Empty;
                Content.Text = string.Empty;
                listBox.Visibility = Visibility.Hidden;
                button_MSDN.Visibility = Visibility.Hidden;
                buttonLocalArticle.Visibility = Visibility.Hidden;
                HtmlDocument links = new HtmlDocument();
                string str = string.Empty;
                System.Net.WebClient web = new System.Net.WebClient();
                try
                {
                    web.Encoding = UTF8Encoding.UTF8;
                    str = web.DownloadString("https://msdn.microsoft.com/ru-ru/library/ms123401.aspx");
                    links.LoadHtml(str);
                }
                catch
                {
                    MessageBox.Show("Ошибка, проверьте интернет-соединение!");
                    listBox.Items.Clear();
                    listBox.Visibility = Visibility.Hidden;
                    button_MSDN.Visibility = Visibility.Hidden;
                    return;
                }
                var div = links.DocumentNode.SelectNodes("//div[@class='catalog']//ul//li//a");

                System.Net.WebClient web_2 = new System.Net.WebClient();
                web_2.Encoding = UTF8Encoding.UTF8;
                HtmlDocument DoubleLinks = new HtmlDocument();
                if (listBox.SelectedIndex != -1)
                {
                    string StringList = web_2.DownloadString(div[listBox.SelectedIndex].GetAttributeValue("href", "Извините произошла ошибка!"));
                    DoubleLinks.LoadHtml(StringList);
                    Caption.Text = string.Empty;
                    Content.Text = string.Empty;
                    var CaptionWeb = DoubleLinks.DocumentNode.SelectSingleNode("//h1");
                    var ContentWeb = DoubleLinks.DocumentNode.SelectNodes("//div[@class='content']");
                    try
                    {
                        Caption.Text = CaptionWeb.InnerText;
                        foreach (var item in ContentWeb)
                        {
                            if (item.InnerText == string.Empty)
                                Content.Text += item.InnerText;
                            else
                                Content.Text += item.InnerText + "\n";
                        }
                    }
                    catch (NullReferenceException)
                    {
                        Caption.Text = string.Empty;
                        Content.Text = string.Empty;
                        MessageBox.Show("Произоошла ошибка считывания информации! Приносим извинения");
                        listBox.Items.Clear();
                        listBox.Visibility = Visibility.Hidden;
                        button_MSDN.Visibility = Visibility.Hidden;
                        return;
                    }
                    using (NewsApplicationEntities db = new NewsApplicationEntities())
                    {
                        bool flag = true;
                        int i = 0;
                        var news = db.News;
                        foreach (var item in news)
                        {

                            if (item.Section == CaptionWeb.InnerText)
                                flag = false;
                            i++;
                        }
                        ID_news = i;
                        if (flag == true)
                        {
                            db.News.Add(new News { Id = ID_news + 1, Section = CaptionWeb.InnerText, Article = Content.Text, Link = div[listBox.SelectedIndex].GetAttributeValue("href", "Извините произошла ошибка!") });
                            db.SaveChanges();
                        }
                    }
                    MessageBox.Show("Страница получена");
                }
                else MessageBox.Show("Выберите элемент списка!");
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
        //+
        private void ChangeUserLabelClick(object sender, MouseButtonEventArgs e)
        {
            NavigationService.Navigate(new Uri("Authorization.xaml", UriKind.Relative));
        }
        //+
        private void ButtonSelectMenu(object sender, RoutedEventArgs e)
        {
            try
            {
                System.Net.WebClient web = new System.Net.WebClient();
                web.Encoding = UTF8Encoding.UTF8;
                HtmlDocument site = new HtmlDocument();
                string str = string.Empty;
                try
                {
                    str = web.DownloadString("https://368.media/?gclid=CLHNn7-S8tMCFRIdGAodu-4L9A");
                    site.LoadHtml(str);
                }
                catch
                {
                    MessageBox.Show("Ошибка, проверьте интернет-соединение!");
                    listBox.Items.Clear();
                    listBox.Visibility = Visibility.Hidden;
                    buttonSelectMenu368.Visibility = Visibility.Hidden;
                    return;
                }
                var menu = site.DocumentNode.SelectNodes("//ul[@id='menu-main-menu']//li//a");

                System.Net.WebClient web_2 = new System.Net.WebClient();
                web_2.Encoding = UTF8Encoding.UTF8;
                string StringList = string.Empty;
                HtmlDocument DoubleLinks = new HtmlDocument();
                if (listBox.SelectedIndex == -1)
                {
                    MessageBox.Show("Укажите элемент списка!");
                    return;
                }
                else
                {
                    try
                    {
                        StringList = web_2.DownloadString(menu[listBox.SelectedIndex].GetAttributeValue("href", "Извините произошла ошибка"));
                        DoubleLinks.LoadHtml(StringList);
                    }
                    catch
                    {
                        MessageBox.Show("Ошибка, проверьте интернет-соединение!");
                        listBox.Items.Clear();
                        listBox.Visibility = Visibility.Hidden;
                        buttonSelectMenu368.Visibility = Visibility.Hidden;
                        return;
                    }
                    index_news = listBox.SelectedIndex;
                    listBox.Items.Clear();
                    var news = DoubleLinks.DocumentNode.SelectNodes("//h2//a");

                    foreach (var item in news)
                    {
                        listBox.Items.Add(item.InnerText);
                    }
                }
                buttonSelectMenu368.Visibility = Visibility.Hidden;
                buttonSelectNews368.Visibility = Visibility.Visible;
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
        //+
        private void ButtonSelectNews(object sender, RoutedEventArgs e)
        {
            try
            {
                System.Net.WebClient web = new System.Net.WebClient();
                web.Encoding = UTF8Encoding.UTF8;
                HtmlDocument site = new HtmlDocument();
                string str = string.Empty;
                try
                {
                    str = web.DownloadString("https://368.media/?gclid=CLHNn7-S8tMCFRIdGAodu-4L9A");
                    site.LoadHtml(str);
                }
                catch
                {
                    MessageBox.Show("Ошибка, проверьте интернет-соединение!");
                    listBox.Items.Clear();
                    listBox.Visibility = Visibility.Hidden;
                    buttonSelectNews368.Visibility = Visibility.Hidden;
                    return;
                }
                var menu = site.DocumentNode.SelectNodes("//ul[@id='menu-main-menu']//li//a");

                System.Net.WebClient web_2 = new System.Net.WebClient();
                web_2.Encoding = UTF8Encoding.UTF8;
                string StringList = string.Empty;
                HtmlDocument DoubleLinks = new HtmlDocument();
                try
                {
                    StringList = web_2.DownloadString(menu[index_news].GetAttributeValue("href", "Извините произошла ошибка"));
                    DoubleLinks.LoadHtml(StringList);
                }
                catch
                {
                    MessageBox.Show("Ошибка, проверьте интернет-соединение!");
                    listBox.Items.Clear();
                    listBox.Visibility = Visibility.Hidden;
                    buttonSelectNews368.Visibility = Visibility.Hidden;
                    return;
                }

                var news = DoubleLinks.DocumentNode.SelectNodes("//h2//a");

                System.Net.WebClient web_3 = new System.Net.WebClient();
                web_3.Encoding = UTF8Encoding.UTF8;
                HtmlDocument TripleLinks = new HtmlDocument();
                string StringNews = string.Empty;
                if (listBox.SelectedIndex == -1)
                {
                    MessageBox.Show("Укажите элемент списка");
                    return;
                }
                else
                {
                    try
                    {
                        StringNews = web_3.DownloadString(news[listBox.SelectedIndex].GetAttributeValue("href", "Извините, произошла ошибка"));
                        TripleLinks.LoadHtml(StringNews);
                    }
                    catch
                    {
                        MessageBox.Show("Ошибка, проверьте интернет-соединение!");
                        listBox.Items.Clear();
                        listBox.Visibility = Visibility.Hidden;
                        buttonSelectNews368.Visibility = Visibility.Hidden;
                        return;
                    }
                    var CaptionWeb = TripleLinks.DocumentNode.SelectSingleNode("//h1");
                    var ContentWeb = TripleLinks.DocumentNode.SelectNodes("//div[@class='container']//div[@class='content']//div[@class='content-block']//p");
                    listBox.Visibility = Visibility.Hidden;
                    buttonSelectNews368.Visibility = Visibility.Hidden;
                    try
                    {
                        Caption.Text = CaptionWeb.InnerText;
                        foreach (var item in ContentWeb)
                        {
                            Content.Text += item.InnerText;
                        }
                    }
                    catch (NullReferenceException)
                    {
                        MessageBox.Show("Возникли неизвестные нам неполадки! Попробуйте воспользоваться другой ссылкой!");
                        listBox.Visibility = Visibility.Hidden;
                        buttonSelectNews368.Visibility = Visibility.Hidden;
                        return;
                    }
                    using (NewsApplicationEntities db = new NewsApplicationEntities())
                    {
                        bool flag = true;
                        var NewsDB = db.News;
                        int i = 0;
                        foreach (var item in NewsDB)
                        {
                            if (item.Section == CaptionWeb.InnerText)
                                flag = false;
                            i++;
                        }
                        ID_news = i;
                        if (flag == true)
                        {
                            db.News.Add(new News { Id = ID_news + 1, Section = CaptionWeb.InnerText, Article = Content.Text, Link = news[listBox.SelectedIndex].GetAttributeValue("href", "Извините произошла ошибка!") });
                            db.SaveChanges();
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
        //+
        private void BelsatLabelTouch(object sender, MouseButtonEventArgs e)
        {
            try
            {
                buttonSelectNews368.Visibility = Visibility.Hidden;
                buttonBELSAT.Visibility = Visibility.Hidden;
                buttonLocalArticle.Visibility = Visibility.Hidden;
                button_MSDN.Visibility = Visibility.Hidden;
                Caption.Text = "BELSAT";
                buttonSelectMenu368.Visibility = Visibility.Hidden;
                Content.Text = string.Empty;
                System.Net.WebClient web = new System.Net.WebClient();
                web.Encoding = UTF8Encoding.UTF8;
                HtmlDocument site = new HtmlDocument();
                string str = string.Empty;
                try
                {
                    str = web.DownloadString("http://belsat.eu/ru/news/");
                    site.LoadHtml(str);
                }
                catch
                {
                    MessageBox.Show("Ошибка, проверьте интернет-соединение!");
                    listBox.Items.Clear();
                    listBox.Visibility = Visibility.Hidden;
                    buttonBELSAT.Visibility = Visibility.Hidden;
                    return;
                }
                var news = site.DocumentNode.SelectNodes("//div[@class='row news-thumbnail']//h2//a");
                listBox.Items.Clear();
                listBox.Visibility = Visibility.Visible;
                foreach (var item in news)
                {
                    listBox.Items.Add(item.InnerText);
                }
                buttonBELSAT.Visibility = Visibility.Visible;
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

        private void ButtonBelsatMethod(object sender, RoutedEventArgs e)
        {
            try
            {
                Caption.Text = string.Empty;
                Content.Text = string.Empty;
                System.Net.WebClient web = new System.Net.WebClient();
                web.Encoding = UTF8Encoding.UTF8;
                HtmlDocument site = new HtmlDocument();
                string str = string.Empty;
                try
                {
                    str = web.DownloadString("http://belsat.eu/ru/news/");
                    site.LoadHtml(str);
                }
                catch
                {
                    MessageBox.Show("Ошибка, проверьте интернет-соединение!");
                    listBox.Items.Clear();
                    listBox.Visibility = Visibility.Hidden;
                    buttonBELSAT.Visibility = Visibility.Hidden;
                    return;
                }
                var news = site.DocumentNode.SelectNodes("//div[@class='row news-thumbnail']//h2//a");

                System.Net.WebClient web_2 = new System.Net.WebClient();
                web_2.Encoding = UTF8Encoding.UTF8;
                string StringList = string.Empty;
                HtmlDocument DoubleLinks = new HtmlDocument();
                if (listBox.SelectedIndex == -1)
                {
                    MessageBox.Show("Выберите элемент списка");
                    return;
                }
                else
                {
                    try
                    {
                        StringList = web_2.DownloadString(news[listBox.SelectedIndex].GetAttributeValue("href", "Извините произошла ошибка"));
                        DoubleLinks.LoadHtml(StringList);
                    }
                    catch
                    {
                        MessageBox.Show("Ошибка, проверьте интернет-соединение!");
                        listBox.Items.Clear();
                        listBox.Visibility = Visibility.Hidden;
                        buttonBELSAT.Visibility = Visibility.Hidden;
                        return;
                    }
                    var CaptionWeb = DoubleLinks.DocumentNode.SelectSingleNode("//div[@class='row']//h1");
                    var ContentWeb = DoubleLinks.DocumentNode.SelectNodes("//div[@class='article_text_container']//p");
                    int index = listBox.SelectedIndex;
                    listBox.Items.Clear();
                    listBox.Visibility = Visibility.Hidden;
                    buttonBELSAT.Visibility = Visibility.Hidden;
                    Caption.Text = CaptionWeb.InnerText;
                    try
                    {
                        foreach (var item in ContentWeb)
                        {
                            Content.Text += item.InnerText;
                        }
                    }
                    catch (NullReferenceException)
                    {
                        MessageBox.Show("Возникли неизвестные нам неполадки! Попробуйте воспользоваться другой ссылкой!");
                        return;
                    }
                    using (NewsApplicationEntities db = new NewsApplicationEntities())
                    {
                        bool flag = true;
                        var NewsDB = db.News;
                        int i = 0;
                        foreach (var item in NewsDB)
                        {
                            if (item.Section == CaptionWeb.InnerText)
                                flag = false;
                            i++;
                        }
                        ID_news = i;
                        if (flag == true)
                        {
                            db.News.Add(new News { Id = ID_news + 1, Section = CaptionWeb.InnerText, Article = Content.Text, Link = news[index].GetAttributeValue("href", "Извините произошла ошибка!") });
                            db.SaveChanges();
                        }
                    }
                    buttonBELSAT.Visibility = Visibility.Hidden;

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

        private void Develop(object sender, MouseButtonEventArgs e)
        {
            NavigationService.Navigate(new Uri("Development.xaml", UriKind.Relative));
        }

        private void Myprofile(object sender, MouseButtonEventArgs e)
        {
            NavigationService.Navigate(new Uri("MyAccount.xaml", UriKind.Relative));
        }
    }
}
