
using Android.App;
using Android.OS;
using Android.Widget;

namespace GeoCoder
{
    [Activity(Label = "LatLong Values To Place Name")]
    public class PlaceToLatLong : Activity
    {
        LatLangValuesToPlaceName latLongValuesToPlaceName;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Create your application here
            SetContentView(Resource.Layout.Place);
            var latitudeText = FindViewById<EditText>(Resource.Id.latitudeText);
            var longitudeText = FindViewById<EditText>(Resource.Id.longitudeText);
            var addressButton = FindViewById<Button>(Resource.Id.addressButton);
            var addressView = FindViewById<TextView>(Resource.Id.addressView);

            addressButton.Click += (sender, e) =>
            {
                latLongValuesToPlaceName = new LatLangValuesToPlaceName(double.Parse(latitudeText.Text), double.Parse(longitudeText.Text));
                latLongValuesToPlaceName.getAddress();
                addressView.Text = latLongValuesToPlaceName.Address;
            };
        }
    }
}