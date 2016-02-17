using System;
using System.Threading;

using Android.App;
using Android.Widget;
using Android.OS;

namespace ThreadDemo
{
	[Activity (Label = "ThreadDemo", MainLauncher = true, Icon = "@mipmap/icon")]
	public class MainActivity : Activity
	{
		TextView textView;

		protected override void OnCreate (Bundle savedInstanceState)
		{
			base.OnCreate (savedInstanceState);

			// Set our view from the "main" layout resource
			SetContentView (Resource.Layout.Main);

			// Get our button from the layout resource,
			// and attach an event to it
			Button button = FindViewById<Button> (Resource.Id.myButton);
			textView = FindViewById<TextView> (Resource.Id.value);

			button.Click += (sender, e) => ThreadPool.QueueUserWorkItem (o => SlowMethod ());


		}

		private void SlowMethod()
		{
			Thread.Sleep (5000);
			RunOnUiThread (() => {
				textView.Text = "Method complete";
			});

		}
	}
}


