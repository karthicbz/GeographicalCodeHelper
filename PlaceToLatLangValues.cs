using System.Net;
using Newtonsoft.Json;

using Android.App;
using Android.Widget;

namespace GeoCoder
{
    class PlaceToLatLangValues
    {
        public string PlaceName { get; set; }
        public double Latitude { get; set; }
        public double Longitude { get; set; }

        WebClient client = new WebClient();

        public PlaceToLatLangValues(string placeName)
        {
            PlaceName = placeName;
        }

        public void getLatLongValues()
        {
            client.Headers.Add("User-Agent: Other");
            var url = "https://nominatim.openstreetmap.org/search?q=" + PlaceName + "&format=json&polygon=1&addressdetails=1";
            var response = client.DownloadString(url);
            if (response != "[]")
            {
                var CoordinatesData = JsonConvert.DeserializeObject<dynamic>(response);
                Latitude = CoordinatesData[0]["lat"];
                Longitude = CoordinatesData[0]["lon"];
            }
            else
            {
                Toast.MakeText(Application.Context, "Please check the Place name", ToastLength.Long).Show();
                Latitude = 0;
                Longitude = 0;
            }

        }
    }
}