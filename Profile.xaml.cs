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
using System.Data.SqlClient;
using System.Data;


namespace FoundIT_Desktop_App
{
    /// <summary>
    /// Interaction logic for Profile.xaml
    /// </summary>
    public partial class Profile : Window
    {
        public Profile()
        {
            InitializeComponent();
        }

        public static string conString = "Data Source=MONYO\\SQLEXPRESS;Initial Catalog=yes;Integrated Security=True";
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

        private void fnameBox_TextChanged(object sender, System.Windows.Controls.TextChangedEventArgs e)
        {
            if (!string.IsNullOrEmpty(fnameBox.Text) && fnameBox.Text.Length > 0)
                fname.Visibility = Visibility.Collapsed;
            else
                fname.Visibility = Visibility.Visible;
        }

        private void fnameBox_MouseDown(object sender, MouseButtonEventArgs e)
        {
            fnameBox.Focus();
            

        }

        private void lnameBox_TextChanged(object sender, System.Windows.Controls.TextChangedEventArgs e)
        {
            if (!string.IsNullOrEmpty(lnameBox.Text) && lnameBox.Text.Length > 0)
                lname.Visibility = Visibility.Collapsed;
            else
                lname.Visibility = Visibility.Visible;
        }

        private void lnameBox_MouseDown(object sender, MouseButtonEventArgs e)
        {
            lnameBox.Focus();
           
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

        private void BtnClickMain(object sender, RoutedEventArgs e)
        {

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                PostedPage objPostedPage = new PostedPage();
                MainWindow objMainWindow = new MainWindow();
                SqlConnection con = new SqlConnection(conString);
                con.Open();

                if ((String.IsNullOrEmpty(txtEmail.Text)) ||
                    (String.IsNullOrEmpty(lnameBox.Text)) ||
                    (String.IsNullOrEmpty(fnameBox.Text)) ||
                    (String.IsNullOrEmpty(passwordBox.Password)))
                {
                    MessageBox.Show("Some Fields are Blank. Cannot Proceed to Updating Account...");
                    passwordBox.Password = PostedPage.password;
                    txtEmail.Text = PostedPage.passuserEmail;
                    fnameBox.Text = PostedPage.passFirstName;
                    lnameBox.Text = PostedPage.passLastName;
                    this.Visibility = Visibility.Hidden;
                    objPostedPage.Show();
                }
                else if ((txtEmail.Text == PostedPage.passuserEmail) &&
                        (fnameBox.Text == PostedPage.passFirstName) &&
                        (lnameBox.Text == PostedPage.passLastName) &&
                        (passwordBox.Password == PostedPage.password)){

                    MessageBox.Show("No Inputs are changed. Returning to Posting Page");
                    this.Visibility = Visibility.Hidden;
                    objPostedPage.Show();
                }
                
                else
                {
                    string query = "UPDATE userInfo SET email = '" +txtEmail.Text.ToString() + "', firstName = '" +fnameBox.Text.ToString()+ "',lastName = '"+lnameBox.Text.ToString()+"' ,password = '" +passwordBox.Password.ToString()+ "' where email = '"+MainWindow.passUserEmail+"'";
                    SqlCommand updateCommand = new SqlCommand(query, con);

                    updateCommand.ExecuteNonQuery();

                    MessageBox.Show("Account "+fnameBox.Text+" "+lnameBox.Text+" is updated");
                    this.Visibility = Visibility.Hidden;
                    objPostedPage.Show();
                    con.Close();

                }
            }catch (Exception ex)
            {
                
                MessageBox.Show(ex.Message, "Error", MessageBoxButton.OK);
                
            }
        }

        private void Border_Loaded(object sender, RoutedEventArgs e)
        {
            passwordBox.Password = PostedPage.password;
            txtEmail.Text = PostedPage.passuserEmail;
            fnameBox.Text = PostedPage.passFirstName;
            lnameBox.Text = PostedPage.passLastName;
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {

        }

        private void dlt_btn(object sender, RoutedEventArgs e)
        {
            MainWindow objmainWindow = new MainWindow();
            using (SqlConnection con = new SqlConnection(conString))
            {
                con.Open();
                using (SqlCommand cmd = new SqlCommand("DELETE FROM userinfo WHERE email =  '" + MainWindow.passUserEmail + "'  ", con))
                {
                    cmd.ExecuteNonQuery();
                }
                con.Close();

                MessageBox.Show("Your account has been deleted");

                passwordBox.Clear();
                txtEmail.Clear();
                fnameBox.Clear();
                lnameBox.Clear();

                this.Close();
                objmainWindow.Show();
                
            }
        }
    }
}