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
    /// Interaction logic for FounderForm.xaml
    /// </summary>
    public partial class FounderForm : Window
    {
        public string conString = "Data Source=MONYO\\SQLEXPRESS;Initial Catalog=yes;Integrated Security=True";
        public FounderForm()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            PostedPage objPostedPage = new PostedPage();
            this.Visibility = Visibility.Hidden;
            objPostedPage.Show();
        }

        private void nameBox_MouseDown(object sender, MouseButtonEventArgs e)
        {
            nameBox.Focus();
        }

        private void nameBox_TextChanged(object sender, System.Windows.Controls.TextChangedEventArgs e)
        {
            if (!string.IsNullOrEmpty(nameBox.Text) && nameBox.Text.Length > 0)
                name.Visibility = Visibility.Collapsed;
            else
                name.Visibility = Visibility.Visible;
        }

        private void ItemNameBox_TextChanged(object sender, System.Windows.Controls.TextChangedEventArgs e)
        {
            if (!string.IsNullOrEmpty(ItemNameBox.Text) && ItemNameBox.Text.Length > 0)
                ItemName.Visibility = Visibility.Collapsed;
            else
                ItemName.Visibility = Visibility.Visible;
        }

        private void ItemName_MouseDown(object sender, MouseButtonEventArgs e)
        {
            ItemNameBox.Focus();
        }

        private void VenueBox_TextChanged(object sender, System.Windows.Controls.TextChangedEventArgs e)
        {
            if (!string.IsNullOrEmpty(VenueBox.Text) && VenueBox.Text.Length > 0)
                Venue.Visibility = Visibility.Collapsed;
            else
                Venue.Visibility = Visibility.Visible;
        }

        private void Venue_MouseDown(object sender, MouseButtonEventArgs e)
        {
            VenueBox.Focus();
        }

        private void TimeLastSeen_MouseDown(object sender, MouseButtonEventArgs e)
        {
            TimeLastSeenBox.Focus();
        }

        private void TimeLastSeenBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (!string.IsNullOrEmpty(TimeLastSeenBox.Text) && TimeLastSeenBox.Text.Length > 0)
                TimeLastSeen.Visibility = Visibility.Collapsed;
            else
                TimeLastSeen.Visibility = Visibility.Visible;
        }

        private void Brand_MouseDown(object sender, MouseButtonEventArgs e)
        {
            BrandBox.Focus();
        }

        private void BrandBox_TextChanged(object sender, System.Windows.Controls.TextChangedEventArgs e)
        {
            if (!string.IsNullOrEmpty(BrandBox.Text) && BrandBox.Text.Length > 0)
                Brand.Visibility = Visibility.Collapsed;
            else
                Brand.Visibility = Visibility.Visible;
        }

        private void Color_MouseDown(object sender, MouseButtonEventArgs e)
        {
            ColorBox.Focus();
        }

        private void ColorBox_TextChanged(object sender, System.Windows.Controls.TextChangedEventArgs e)
        {
            if (!string.IsNullOrEmpty(ColorBox.Text) && ColorBox.Text.Length > 0)
                Color.Visibility = Visibility.Collapsed;
            else
                Color.Visibility = Visibility.Visible;
        }

        private void Material_MouseDown(object sender, MouseButtonEventArgs e)
        {
            MaterialBox.Focus();
        }

        private void MaterialBox_TextChanged(object sender, System.Windows.Controls.TextChangedEventArgs e)
        {
            if (!string.IsNullOrEmpty(MaterialBox.Text) && MaterialBox.Text.Length > 0)
                Material.Visibility = Visibility.Collapsed;
            else
                Material.Visibility = Visibility.Visible;
        }

        private void Quantity_MouseDown(object sender, MouseButtonEventArgs e)
        {
            QuantityBox.Focus();
        }

        private void QuantityBox_TextChanged(object sender, System.Windows.Controls.TextChangedEventArgs e)
        {
            if (!string.IsNullOrEmpty(QuantityBox.Text) && QuantityBox.Text.Length > 0)
                Quantity.Visibility = Visibility.Collapsed;
            else
                Quantity.Visibility = Visibility.Visible;
        }

        private void BtnClick_Home(object sender, RoutedEventArgs e)
        {
            PostedPage objPostedPage = new PostedPage();
            this.Visibility = Visibility.Hidden;
            objPostedPage.Show();
        }

        private void BtnClick_Profile(object sender, RoutedEventArgs e)
        {
            Profile objProfile = new Profile();
            this.Visibility = Visibility.Hidden;
            objProfile.Show();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            //not tested yet, di makita button

            PostedPage objPostedPage = new PostedPage();
            try
            {
                if ((String.IsNullOrEmpty(nameBox.Text)) ||
                (String.IsNullOrEmpty(ItemNameBox.Text)) ||
                (String.IsNullOrEmpty(categoryComboBox.Text)) ||
                (String.IsNullOrEmpty(VenueBox.Text)) ||
                (String.IsNullOrEmpty(TimeLastSeenBox.Text)) ||
                (datePicker.SelectedDate == null) ||
                (String.IsNullOrEmpty(BrandBox.Text)) ||
                (String.IsNullOrEmpty(ColorBox.Text)) ||
                (String.IsNullOrEmpty(MaterialBox.Text)) ||
                (String.IsNullOrEmpty(QuantityBox.Text)))
                {
                    MessageBox.Show("All fields are required. Please try again.");
                    clearInputs();
                }
                else
                {
                    SqlConnection con = new SqlConnection(conString);
                    con.Open();
                    string query = "INSERT INTO lostItem(itemName, itemLocationFound, itemCategory, founderName, timeLastSeen, color, brand, material, quantity, dateLastSeen) VALUES ('" + ItemNameBox.Text.ToString() + "','" + VenueBox.Text.ToString() + "','" + categoryComboBox.Text.ToString() + "', '" + nameBox.Text.ToString() + "', '" + TimeLastSeenBox.Text.ToString() + "', '" + ColorBox.Text.ToString() + "', '" + BrandBox.Text.ToString() + "', '" + MaterialBox.Text.ToString() + "','" + QuantityBox.Text.ToString() + "', '" + datePicker.SelectedDate + "')";
                    SqlCommand cmd = new SqlCommand(query, con);
                    cmd.ExecuteNonQuery();

                    MessageBox.Show("Information Added");
                    this.Visibility = Visibility.Hidden;
                    objPostedPage.Show();
                    con.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Connection Error");
            }
            //Checks if inputs have values


        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            MainWindow objMainWindow = new MainWindow();
            this.Visibility = Visibility.Hidden;
            objMainWindow.Show();
        }

        public void clearInputs()
        {
            nameBox.Clear();
            ItemNameBox.Clear();
            categoryComboBox.Items.Clear();
            VenueBox.Clear();
            TimeLastSeenBox.Clear();
            //SelectedDate.Items.Clear();
            BrandBox.Clear();
            ColorBox.Clear();
            MaterialBox.Clear();
            QuantityBox.Clear();

        }


    }
}