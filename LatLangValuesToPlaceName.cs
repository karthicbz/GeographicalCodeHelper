using System.Net;
using Newtonsoft.Json;

using Android.App;
using Android.Widget;

namespace GeoCoder
{
    class LatLangValuesToPlaceName
    {
        public double Latitude { get; set; }
        public double Longitude { get; set; }
        public string Address { get; set; }

        public LatLangValuesToPlaceName(double latitude, double longitude)
        {
            Latitude = latitude;
            Longitude = longitude;
        }

        WebClient client = new WebClient();
        public void getAddress()
        {
            client.Headers.Add("User-Agent: Another");
            var url = "https://nominatim.openstreetmap.org/reverse?format=json&lat=" + Latitude + "&lon=" + Longitude + "&zoom=18&addressdetails=1";
            var response = client.DownloadString(url);

            if (response != "[]")
            {
                var addressData = JsonConvert.DeserializeObject<dynamic>(response);
                Address = addressData["display_name"];
            }
            else
            {
                Toast.MakeText(Application.Context, "One of the Latitude or Longitude values must be wrong", ToastLength.Long).Show();
                Address = "Nothing here";
            }
        }
    }
}