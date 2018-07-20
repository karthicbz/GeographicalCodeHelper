using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;

namespace GeoCoder
{
    [Activity(Label = "Place Name To LatLong Value")]
    public class LatLongToPlace : Activity
    {
        PlaceToLatLangValues placeToLatLongValues;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Create your application here
            SetContentView(Resource.Layout.LatLong);
            var placeBox = FindViewById<EditText>(Resource.Id.placeBox);
            var placeToLatLongButton = FindViewById<Button>(Resource.Id.placeToLatLongButton);
            var lattitudeTextView = FindViewById<TextView>(Resource.Id.latitudeTextView);
            var longitudeTextView = FindViewById<TextView>(Resource.Id.longitudeTextView);

            placeToLatLongButton.Click += (sender, e) =>
            {
                placeToLatLongValues = new PlaceToLatLangValues(placeBox.Text);
                placeToLatLongValues.getLatLongValues();
                lattitudeTextView.Text = placeToLatLongValues.Latitude.ToString();
                longitudeTextView.Text = placeToLatLongValues.Longitude.ToString();
            };

            placeBox.Click += (sender, e) =>
            {
                placeBox.Text = "";
            };
        }
    }
}