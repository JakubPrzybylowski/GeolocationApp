using GeolocationApp.Dto;
using GeolocationApp.Mappers;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Configuration;
using System.Linq;
using System.Net.Http;
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
        private GeolocationManagementDBEntities _db;
        private GeolocationMapper _mapper;
        private List<GeolocationDto> _ipDetails;
        public Main()
        {
            InitializeComponent();

            _db = new GeolocationManagementDBEntities();
            _mapper = new GeolocationMapper();
            // Initialize the IP details list
            var ipDetails = from g in _db.Geolocations select g;
            _ipDetails = new List<GeolocationDto>();
            foreach (var geolocation in _db.Geolocations.ToList())
            {
                var geolocationDto = _mapper.Map(geolocation);
                _ipDetails.Add(geolocationDto);

            }; 
            
            lvIPDetails.ItemsSource = _ipDetails.ToList();
        }

        private async void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            // Add button click event handler
            string ipAddress = txtIP.Text; // Get the IP address from the textbox

            // Replace 'YOUR_ACCESS_KEY' with your actual access key from ipstack.com
            string accessKey = ConfigurationManager.AppSettings.Get("accessKey"); ;

            string url = $"http://api.ipstack.com/{ipAddress}?access_key={accessKey}";

            try
            {
                using (HttpClient client = new HttpClient())
                {
                    // Send the HTTP GET request
                    HttpResponseMessage response = await client.GetAsync(url);

                    // Check if the request was successful (status code 200)
                    if (response.IsSuccessStatusCode)
                    {
                        // Access and print the JSON response
                        string responseBody = await response.Content.ReadAsStringAsync();
                        var ipDetail = JsonConvert.DeserializeObject<Geolocation>(responseBody);
                        if (ipDetail != null)
                        {
                            _db.Geolocations.Add(ipDetail);
                            _db.SaveChanges();
                            var ipDetailDto = _mapper.Map(ipDetail);
                            _ipDetails.Add(ipDetailDto);

                        }
                        _db.Geolocations.Add(ipDetail);
                        _db.SaveChanges();
                        
                        lvIPDetails.ItemsSource = _ipDetails;
                    }
                    else
                    {
                        string errorMessage = $@"{response.RequestMessage.Content}
                                              Error: {response.StatusCode}";                      
                        MessageBox.Show(errorMessage);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}");
            }
        }

        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            // Delete button click event handler

        }

        private void btnGet_Click(object sender, RoutedEventArgs e)
        {
            // Get button click event handler
            if (lvIPDetails.SelectedIndex != -1)
            {
                // Get the selected item from the list

                // Display the selected IP details in a message box or perform any desired action
            }
        }
    }
}
