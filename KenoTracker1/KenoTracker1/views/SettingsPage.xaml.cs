
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Permissions;
using System.Text;
using System.Threading.Tasks;
using KenoTracker1.models;
using SQLite.Net.Async;
using Xamarin.Forms;

namespace KenoTracker1.views
{
    public partial class SettingsPage : ContentPage
    {
        private readonly SQLiteAsyncConnection _conn;

        public SettingsPage ()
        {
            InitializeComponent ();
            _conn = DependencyService.Get<ISQLiteDb>().GetConnection();

        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
           var  _conn = DependencyService.Get<ISQLiteDb>().GetConnection();
            var app = Application.Current as App;
            gamenox.Text = app.gameno;
            amountno.Text = app.pickmax;
        }

        protected override void OnDisappearing()
        {
            base.OnDisappearing();
            var app = Application.Current as App;
            app.gameno = gamenox.Text;
            app.pickmax = amountno.Text;
        }

        /// <summary>
        /// Askits the specified message.
        /// </summary>
        /// <param name="message">The message.</param>
        /// <returns><c>true</c> if XXXX, <c>false</c> otherwise.</returns>
        public bool askit(string message)
        {
            var anser = DisplayAlert("Alert", message, "Yes", "No").Result;
            return anser;
        }

        private async void database_OnClicked(object sender, EventArgs e)
        {
            if (askit("Are you sure to delete"))
            {
                await _conn.DeleteAllAsync<Gamedata>();
            }
        }
    }
}
