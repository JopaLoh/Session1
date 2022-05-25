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

namespace ResortForestPark.Pages
{
    /// <summary>
    /// Логика взаимодействия для LoginPage.xaml
    /// </summary>
    public partial class LoginPage : Page
    {
        public Employee Employee {get; set;}
        public LoginPage()
        {
            InitializeComponent();
            DataContext = this;
        }

        private void BtnLogin_Click(object sender, RoutedEventArgs e)
        {
            if(TxbLogin.Text !="" && TxbPassword.Password !="")
            {
                var query = from Employee in App.Context.Employee
                            where Employee.Login == TxbLogin.Text
                            select Employee;
                if(query.FirstOrDefault()!=null)
                {
                    if(query.First().Password==TxbPassword.Password)
                    {
                        if(query.First().PostID==1)
                        {
                            (App.Current.MainWindow as MainWindow).Presenter.Navigate(new Pages.Seller());
                        }
                        if (query.First().PostID == 3)
                        {
                            (App.Current.MainWindow as MainWindow).Presenter.Navigate(new Pages.SeniorShiftPage());
                        }
                        if (query.First().PostID == 2)
                        {
                            (App.Current.MainWindow as MainWindow).Presenter.Navigate(new Pages.AdminPage());
                        }
                        MessageBox.Show(query.First().Post.Name,"Ds");
                    }
                    else
                    {
                        MessageBox.Show("", "");
                    }
                }
                else
                {
                    MessageBox.Show("", "");
                }
            }
            else
            {
                MessageBox.Show("", "");
            }

        }
    }
}
