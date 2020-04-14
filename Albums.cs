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

namespace XamarinApp
{
    public class Photo
    {
        public int mPhotoID { get; set; }
        public string mCaption { get; set; }
    }
    public class Album
    {
        static Photo[] listPhoto =
           {
            new Photo() {mPhotoID = Resource.Drawable.P1, mCaption = "Item 1"},
            new Photo() {mPhotoID = Resource.Drawable.P2, mCaption = "Item 2"},
            new Photo() {mPhotoID = Resource.Drawable.P3, mCaption = "Item 3"},
            new Photo() {mPhotoID = Resource.Drawable.P4, mCaption = "Item 4"},
        };
        private Photo[] photos;
        public Album()
        {
            this.photos = listPhoto;

        }
        public int numPhoto
        {
            get
            {
                return photos.Length;
            }
        }
        public Photo this[int i]
        {
            get { return photos[i]; }
        }
    }
    public class PhotoViewHolder : Android.Support.V7.Widget.RecyclerView.ViewHolder
    {
        public ImageView Image { get; set; }
        public TextView Caption { get; set; }

        [Obsolete]
        public PhotoViewHolder(View itemview, Action<int> listener) : base(itemview)
        {
            Image = itemview.FindViewById<ImageView>(Resource.Id.imageView);
            Caption = itemview.FindViewById<TextView>(Resource.Id.ItemName);
            itemview.Click += (sender, e) => listener(Position);
        }
    }
}