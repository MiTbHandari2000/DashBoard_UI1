using AndroidX.RecyclerView.Widget;
using Android.Views;
using Android.Widget;
using DashBoard_UI1.DataProvider;
using System;
using System.Collections.Generic;
using Android.Content;
using AndroidX.CardView.Widget;

namespace DashBoard_UI1.Adapters
{
    public class AdapterForWishlist : RecyclerView.Adapter
    {
        public event EventHandler<AdapterForWishlistClickEventArgs> ItemClick;
        public event EventHandler<AdapterForWishlistClickEventArgs> ItemLongClick;
        List<DataProviderClass> items;
        Context cont;

        public AdapterForWishlist(List<DataProviderClass> mydataproviderlistIn, Context con)
        {
            this.items = mydataproviderlistIn;
            this.cont = con;
        }

        // Create new views (invoked by the layout manager)
        public override RecyclerView.ViewHolder OnCreateViewHolder(ViewGroup parent, int viewType)
        {

            //Setup your layout here
            View itemView = null;
            var id = Resource.Layout.rowitem;
            itemView = LayoutInflater.From(parent.Context).Inflate(id, parent, false);

            var vh = new AdapterForWishlistViewHolder(itemView, OnClick, OnLongClick);
            return vh;
        }

        // Replace the contents of a view (invoked by the layout manager)
        public override void OnBindViewHolder(RecyclerView.ViewHolder viewHolder, int position)
        {
            var item = items[position];

            // Replace the contents of the view with that element
            var holder = viewHolder as AdapterForWishlistViewHolder;
            //holder.TextView.Text = items[position];
            holder.thumbnail.Text = item.name;
            holder.image.SetImageResource(item.image);
            if (position % 2 == 0)
            {
                holder.cardview.SetBackgroundDrawable(cont.GetDrawable(Resource.Drawable.background1));
            }
            else
            {
                holder.cardview.SetBackgroundDrawable(cont.GetDrawable(Resource.Drawable.background2));
            }
        }

        public override int ItemCount => items.Count;

        void OnClick(AdapterForWishlistClickEventArgs args) => ItemClick?.Invoke(this, args);
        void OnLongClick(AdapterForWishlistClickEventArgs args) => ItemLongClick?.Invoke(this, args);

    }

    public class AdapterForWishlistViewHolder : RecyclerView.ViewHolder
    {
        public TextView thumbnail;
        public ImageView image;
        public CardView cardview;

        public AdapterForWishlistViewHolder(View itemView, Action<AdapterForWishlistClickEventArgs> clickListener,
                            Action<AdapterForWishlistClickEventArgs> longClickListener) : base(itemView)
        {
            //TextView = v;
            cardview = itemView.FindViewById<CardView>(Resource.Id.cardimage0);
            thumbnail = itemView.FindViewById<TextView>(Resource.Id.rowitemtextview);
            image = itemView.FindViewById<ImageView>(Resource.Id.rowitemimageView);
            itemView.Click += (sender, e) => clickListener(new AdapterForWishlistClickEventArgs { View = itemView, Position = AdapterPosition });
            itemView.LongClick += (sender, e) => longClickListener(new AdapterForWishlistClickEventArgs { View = itemView, Position = AdapterPosition });
        }
    }

    public class AdapterForWishlistClickEventArgs : EventArgs
    {
        public View View { get; set; }
        public int Position { get; set; }
    }
}