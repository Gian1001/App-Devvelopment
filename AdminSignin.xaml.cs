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

namespace FoundIT_Desktop_App
{
    /// <summary>
    /// Interaction logic for AdminSignin.xaml
    /// </summary>
    public partial class AdminSignin : Window
    {
        public AdminSignin()
        {
            InitializeComponent();
        }
        public static string adminUserName = "admin";
        public static string adminPassword = "admin";

        private void Border_MouseDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            if (e.ChangedButton == MouseButton.Left)
                this.DragMove();
        }

        private void Image_MouseUp(object sender, MouseButtonEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void PasswordBox_PasswordChanged(object sender, RoutedEventArgs e)
        {
            if (!string.IsNullOrEmpty(passwordBox.Password) && passwordBox.Password.Length > 0)
                textPassword.Visibility = Visibility.Collapsed;
            else
                textPassword.Visibility = Visibility.Visible;
        }

        private void textPassword_MouseDown(object sender, MouseButtonEventArgs e)
        {
            passwordBox.Focus();
        }

        private void txtEmail_TextChanged(object sender, System.Windows.Controls.TextChangedEventArgs e)
        {
            if (!string.IsNullOrEmpty(txtEmail.Text) && txtEmail.Text.Length > 0)
                textEmail.Visibility = Visibility.Collapsed;
            else
                textEmail.Visibility = Visibility.Visible;
        }

        private void textEmail_MouseDown(object sender, MouseButtonEventArgs e)
        {
            txtEmail.Focus();
        }

        private void BtnClickSignup(object sender, RoutedEventArgs e)
        {
            SignupWindow objSignupWindow = new SignupWindow();
            this.Visibility = Visibility.Hidden;
            objSignupWindow.Show();
        }

        private void BtnClick_Posted(object sender, RoutedEventArgs e)
        {
            PostedPage objPostedPage = new PostedPage();
            AdminSignin objadminSignin = new AdminSignin();
            try {
                if((txtEmail.Text != adminUserName) || 
                    (passwordBox.Password != adminPassword)){

                    MessageBox.Show("Username or Password is Incorrect. Try again.");
                    this.Visibility = Visibility.Hidden;
                    objadminSignin.Show(); 
                }else if ((String.IsNullOrEmpty(txtEmail.Text)) ||
                         (String.IsNullOrEmpty(passwordBox.Password)))
                {
                    this.Visibility = Visibility.Hidden;
                    objadminSignin = new AdminSignin();
                    MessageBox.Show("Username or Password is Empty. Try again.");
                }
                else
                {
                    MessageBox.Show("Welcome admin!");
                    AdminWindow objAdminWindow = new AdminWindow();
                    this.Visibility = Visibility.Hidden;
                    objAdminWindow.Show();

                }
            

            }catch (Exception ex)
            {
                MessageBox.Show("Error");
            }
            
        }
    }
}
