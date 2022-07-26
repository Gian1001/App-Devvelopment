using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
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

namespace FoundIT_Desktop_App
{
    public partial class MainWindow : Window
    {

        public MainWindow()
        {
            InitializeComponent();
        }
        public string conString = "Data Source=MONYO\\SQLEXPRESS;Initial Catalog=yes;Integrated Security=True";
        public static string passUserEmail;
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

            try
            {
                passUserEmail = txtEmail.Text;
                PostedPage objPostedPage = new PostedPage();

                SqlConnection con = new SqlConnection(conString);
                con.Open();
                string query = "SELECT * FROM userInfo where email = '" + txtEmail.Text.ToString() + "' AND password = '" + passwordBox.Password.ToString() + "'";
                SqlDataAdapter sda = new SqlDataAdapter(query, con);
                DataTable dtable = new DataTable();
                sda.Fill(dtable);
                if (dtable.Rows.Count > 0)
                {
                    

                    this.Visibility = Visibility.Hidden;
                    objPostedPage.Show();
                }
                else
                {
                    MessageBox.Show("Username or Password is Incorrect");
                    clearInputs();
                }

                //SqlConnection con = new SqlConnection(conString);
                //con.Open();
            }
            catch
            {
                MessageBox.Show("Connection Error");
            }


        }

        //gawing public static para accessible sa lhat, to edit later. 
        public void clearInputs()
        {

            passwordBox.Clear();
            txtEmail.Clear();

        }

       
    }

}
