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

namespace FoundIT_Desktop_App
{
    /// <summary>
    /// Interaction logic for SignupWindow.xaml
    /// </summary>
    public partial class SignupWindow : Window
    {
        
        public string conString = "Data Source=MONYO\\SQLEXPRESS;Initial Catalog=yes;Integrated Security=True";
        public SignupWindow()
        {
            InitializeComponent();
        }

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
            MainWindow objMainWindow = new MainWindow();
            this.Visibility = Visibility.Hidden;
            objMainWindow.Show();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            MainWindow objMainWindow = new MainWindow();
            if ((String.IsNullOrEmpty(txtEmail.Text)) || (String.IsNullOrEmpty(fname.Text)) || (String.IsNullOrEmpty(lname.Text)) || (String.IsNullOrEmpty(passwordBox.Password)))
            {
                MessageBox.Show("ALL fields are Required. Please try again.");
            }
            else
            {
                SqlConnection con = new SqlConnection(conString);
                con.Open();
                SqlCommand checkEmail = new SqlCommand("SELECT email FROM userInfo WHERE email='" + (txtEmail.Text) + "'", con);
                string checkResult = (string)checkEmail.ExecuteScalar();
                con.Close();
                if (checkResult == (txtEmail.Text))
                {
                    MessageBox.Show("Data Exist");
                    clearInputs();
                }
                else
                {
                    con.Open();
                    string query = "INSERT INTO userInfo(email,firstName,lastName,password) VALUES ('" + txtEmail.Text.ToString() + "','" + fnameBox.Text.ToString() + "','" + lnameBox.Text.ToString() + "','" + passwordBox.Password.ToString() + "')";
                    SqlCommand cmd = new SqlCommand(query, con);
                    cmd.ExecuteNonQuery();

                    MessageBox.Show("Registration Success!");
                    this.Visibility = Visibility.Hidden;
                    objMainWindow.Show();
                    con.Close();
                }
            }

        }
        public void clearInputs()
        {
            fnameBox.Clear();
            passwordBox.Clear();    
            txtEmail.Clear();
            lnameBox.Clear();
        }
    }
}
