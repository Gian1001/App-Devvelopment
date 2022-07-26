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
using System.Windows.Shapes;


namespace FoundIT_Desktop_App
{
    /// <summary>
    /// Interaction logic for PostedPage.xaml
    /// </summary>
    public partial class PostedPage : Window
    {
        public string[] categories { get; set; }
        public string PlaceholderText { get; set; }
        public PostedPage()
        {
            InitializeComponent();

            categories = new string[]
            {"Accessories", "Cash", "Clothing", "Electronic Devices", "Personal Belongings", "School Supplies"};

            DataContext = this;
        }
        public string conString = "Data Source=MONYO\\SQLEXPRESS;Initial Catalog=yes;Integrated Security=True";
        public static string passuserEmail, password, passLastName, passFirstName;
       



       

        private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void BtnClick_Form(object sender, RoutedEventArgs e)
        {
            FounderForm objFounderForm = new FounderForm();
            this.Visibility = Visibility.Hidden;
            objFounderForm.Show();
        }

        private void BtnClick_Profile(object sender, RoutedEventArgs e)
        {

            Profile objProfile = new Profile();
            try
            {
                PostedPage objPostedPage = new PostedPage();

                SqlConnection con = new SqlConnection(conString);
                con.Open();
                string query = "SELECT * FROM userInfo where email = '" +MainWindow.passUserEmail+ "'";
                SqlDataAdapter sda = new SqlDataAdapter(query, con);
                DataTable dtable = new DataTable();
                sda.Fill(dtable);
                if (dtable.Rows.Count > 0)
                {
                    passuserEmail = dtable.Rows[0]["email"].ToString();
                    passFirstName = dtable.Rows[0]["firstName"].ToString();
                    passLastName = dtable.Rows[0]["lastName"].ToString();
                    password = dtable.Rows[0]["password"].ToString();

                    this.Visibility = Visibility.Hidden;
                    objProfile.Show();
                }

                //SqlConnection con = new SqlConnection(conString);
                //con.Open();
            }
            catch
            {
                MessageBox.Show("Connection Error");
            }
        }

        private void loadbtn_Click(object sender, RoutedEventArgs e)
        {
            using (SqlConnection con = new SqlConnection(conString))
            {
                con.Open();
                string query = "SELECT itemName,itemLocationFound,itemCategory,timeLastSeen FROM lostItem ";
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
            var claimingId = Guid.NewGuid().ToString("N").Substring(0, 7);
            MessageBox.Show("Reference ID is " + claimingId  + "." + "\n" +" Present this reference no. when claiming this item." + "\n" +
                "Deposited at Homeowners Association");
        }

        private void datagrid1_CellEditEnding(object sender, DataGridCellEditEndingEventArgs e)
        {

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Popup_one objPopup = new Popup_one();
            this.Visibility = Visibility.Visible;
            objPopup.Show();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            MainWindow objMainWindow = new MainWindow();
            this.Visibility = Visibility.Hidden;
            objMainWindow.Show();
        
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            MainWindow objMainWindow = new MainWindow();
            this.Visibility = Visibility.Hidden;
            objMainWindow.Show();
        }
    }
}
