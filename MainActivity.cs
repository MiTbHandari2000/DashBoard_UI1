using Android.App;
using Android.OS;
using Android.Runtime;
using AndroidX.AppCompat.App;
using AndroidX.RecyclerView.Widget;
using DashBoard_UI1.Adapters;
using DashBoard_UI1.DataProvider;
using System;
using System.Collections.Generic;

using static AndroidX.RecyclerView.Widget.RecyclerView;

namespace DashBoard_UI1
{
    [Activity(Label = "@string/app_name", Theme = "@style/AppTheme.NoActionBar", MainLauncher = true)]
    public class MainActivity : AppCompatActivity
    {
        public RecyclerView myrecycler;
        public AdapterForWishlist myadapter;
        public List<DataProviderClass> mydataproviderlist;
        public LinearLayoutManager layoutmanager;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            Xamarin.Essentials.Platform.Init(this, savedInstanceState);
            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.activity_main);
            myrecycler = FindViewById<RecyclerView>(Resource.Id.recyclerViewforwishlist);
            inputData();
            myadapter = new AdapterForWishlist(mydataproviderlist, this);
            layoutmanager = new LinearLayoutManager(this, LinearLayoutManager.Horizontal, false);
            myrecycler.SetLayoutManager(layoutmanager);
            myrecycler.SetAdapter(myadapter);
        }

        private void inputData()
        {
            mydataproviderlist = new List<DataProviderClass>
            {
                new DataProviderClass{name ="Tee",image = Resource.Drawable.clothes},
                new DataProviderClass{name ="Gym",image = Resource.Drawable.ic_dumbell},
                new DataProviderClass{name ="Bike",image = Resource.Drawable.ic_bike},
                new DataProviderClass{name ="Savings",image = Resource.Drawable.bitcoin},
                new DataProviderClass{name ="Tee",image = Resource.Drawable.clothes},
                new DataProviderClass{name ="Gym",image = Resource.Drawable.ic_dumbell},
                new DataProviderClass{name ="Bike",image = Resource.Drawable.ic_bike},
                new DataProviderClass{name ="Tee",image = Resource.Drawable.clothes},
                new DataProviderClass{name ="Gym",image = Resource.Drawable.ic_dumbell},
                new DataProviderClass{name ="Bike",image = Resource.Drawable.ic_bike}
            };
        }
    }
}