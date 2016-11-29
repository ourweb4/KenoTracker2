using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Xamarin.Forms;

namespace KenoTracker1
{
	public partial class App : Application
	{
	    const string Gamenokey = "Gameno";
	    const string pickmaxkey = "pickmax";
		public App ()
		{
			InitializeComponent();

			MainPage = new NavigationPage( new MainPage());
		}

		protected override void OnStart ()
		{
			// Handle when your app starts
		}

		protected override void OnSleep ()
		{
			// Handle when your app sleeps
		}

		protected override void OnResume ()
		{
			// Handle when your app resumes
		}

	    public string gameno
	    {
	        get
	        {
	            if (Properties.ContainsKey(Gamenokey))
	                return (string) Properties[Gamenokey];
	            return "0";
	        }
	        set { Properties[Gamenokey] = value; }
	    }

	    public string pickmax
	    {
	        get
	        {
	            if (Properties.ContainsKey(pickmaxkey))
	                return (string) Properties[pickmaxkey];
	            return "20";
	        }
            set { Properties[pickmaxkey] = value; }
	    }

	}
}
