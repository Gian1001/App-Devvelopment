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
    /// Interaction logic for AdminWindow.xaml
    /// </summary>
    public partial class AdminWindow : Window
    {

        
        public AdminWindow()
        {
            InitializeComponent();
        }
        string conString = "Data Source=MONYO\\SQLEXPRESS;Initial Catalog=yes;Integrated Security=True";
        int ID = 0;
        private void loadbtn_Click(object sender, RoutedEventArgs e)
        {
           
            using (SqlConnection con = new SqlConnection(conString))
            {
                con.Open();
                string query = "SELECT email,password,firstName,lastName FROM userInfo ";
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.ExecuteNonQuery();


                SqlDataAdapter sda = new SqlDataAdapter(query, con);
                DataTable dt = new DataTable("userinfo");
                sda.Fill(dt);
                datagrid1.ItemsSource = dt.DefaultView;
                sda.Update(dt);
                con.Close();



            }
        }


       



        private void deletebtn_click(object sender, RoutedEventArgs e)
        {
            
            using (SqlConnection con = new SqlConnection(conString))
            {
                con.Open();
                using (SqlCommand cmd = new SqlCommand("DELETE FROM userinfo WHERE email =  email  ", con))
                {
                    cmd.ExecuteNonQuery();
                }
                con.Close();
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            AdminWindow objAdminWindow = new AdminWindow();
            this.Visibility = Visibility.Hidden;
            objAdminWindow.Close();
        }

        private void BtnClick_Form(object sender, RoutedEventArgs e)
        {

        }

        private void drgrid_selection(object sender, SelectionChangedEventArgs e)
        {
           
        }
    }
}
