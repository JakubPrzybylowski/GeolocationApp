using GeolocationApp.Dto;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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

namespace GeolocationApp
{
    /// <summary>
    /// Interaction logic for Main.xaml
    /// </summary>
    public partial class Main : Window
    {
        private ObservableCollection<Geolocation> ipDetailsList;

        public Main()
        {
            InitializeComponent();

            GeolocationManagementDBEntities db = new GeolocationManagementDBEntities();
            // Initialize the IP details list
            var ipDetails = from g in db.Geolocations select g;
            var ipDetailsDto = new List<GeolocationDto>() { new GeolocationDto(ipDetails.First()) };
            lvIPDetails.ItemsSource = ipDetailsDto.ToList();
        }

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            // Add button click event handler
            string ipAddress = txtIP.Text; // Get the IP address from the textbox

            // Perform the necessary logic to retrieve the IP details and create an IPDetails object
            Geolocation ipDetails = RetrieveIPDetails(ipAddress);

            if (ipDetails != null)
            {
                // Add the IP details to the list
                ipDetailsList.Add(ipDetails);
            }
        }

        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            // Delete button click event handler
            if (lvIPDetails.SelectedIndex != -1)
            {
                // Remove the selected item from the list
                ipDetailsList.RemoveAt(lvIPDetails.SelectedIndex);
            }
        }

        private void btnGet_Click(object sender, RoutedEventArgs e)
        {
            // Get button click event handler
            if (lvIPDetails.SelectedIndex != -1)
            {
                // Get the selected item from the list
                Geolocation selectedIPDetails = ipDetailsList[lvIPDetails.SelectedIndex];

                // Display the selected IP details in a message box or perform any desired action
                MessageBox.Show($"Selected IP Details:\n\n" +
                                $"ID: {selectedIPDetails.Id}\n" +
                                $"IP Address: {selectedIPDetails.Ip_address}\n" +
                                $"Hostname: {selectedIPDetails.Hostname}\n" +
                                $"Type: {selectedIPDetails.Type}\n" +
                                $"Continent Code: {selectedIPDetails.Continent_code}\n" +
                                $"Continent Name: {selectedIPDetails.Continent_name}\n" +
                                $"Region Code: {selectedIPDetails.Region_code}\n" +
                                $"Region Name: {selectedIPDetails.Region_name}\n" +
                                $"City: {selectedIPDetails.City}\n" +
                                $"Zip: {selectedIPDetails.Zip}");
            }
        }

        // Method to retrieve IP details based on the provided IP address
        private Geolocation RetrieveIPDetails(string ipAddress)
        {
            // Implement the logic to retrieve the IP details based on the provided IP address
            // You can use any IP geolocation service or API to fetch the details

            var ipDetails = new Geolocation
            {
                Id = ipDetailsList.Count + 1,
                Ip_address = ipAddress,
                Hostname = "example.com",
                Type = "IPv4",
                Continent_code = "NA",
                Continent_name = "North America",
                Region_code = "NY",
                Region_name = "New York",
                City = "New York City",
                Zip = "10001"
            };

            return ipDetails;
        }
    }
}
