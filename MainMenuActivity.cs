using System;
using Android.App;
using Android.OS;
using Android.Runtime;
using Android.Support.Design.Widget;
using Android.Support.V7.App;
using Android.Views;
using Android.Widget;
using Android.Support.V7.Widget;
using Android.Content;

namespace XamarinApp
{
    [Activity(Label = "MainMenuActivity")]
    public class MainMenuActivity : AppCompatActivity
    {
        Android.Support.V7.Widget.RecyclerView mRecyclerview;
        Android.Support.V7.Widget.RecyclerView.LayoutManager mLayoutManager;
        Album mPhotoAlbum;
        PhotoAdapter mAdapter;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            mPhotoAlbum = new Album();


            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.MainMenuPage);


            mLayoutManager = new LinearLayoutManager(this);

            mAdapter = new PhotoAdapter(mPhotoAlbum);
            mAdapter.ItemClick += MAdapter_ItemClick;

            mRecyclerview = FindViewById<Android.Support.V7.Widget.RecyclerView>(Resource.Id.RvList);
            mRecyclerview.SetLayoutManager(mLayoutManager); ;
            mRecyclerview.SetAdapter(mAdapter);
        }
        private void MAdapter_ItemClick(object sender, int e)
        {
            int photoNum = e + 1;
            Toast.MakeText(this, "This is a Mouse " + photoNum, ToastLength.Short).Show();
            Intent ItemView = new Intent(this, typeof(ItemViewActivity));
            StartActivity(ItemView);
        }
    }
}