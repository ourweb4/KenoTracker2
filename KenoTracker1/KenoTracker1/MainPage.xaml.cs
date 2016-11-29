using System;
using System.Collections.ObjectModel;
using System.Linq;
using KenoTracker1.models;
using KenoTracker1.views;
using SQLite.Net.Async;
using Xamarin.Forms;

/// <summary>
/// The KenoTracker1 namespace.
/// </summary>
namespace KenoTracker1
{
    public partial class MainPage : ContentPage
    {
        private readonly SQLiteAsyncConnection _conn;
        private string curnum = "";
       // private int index = 1;
        public ObservableCollection<string> list = new ObservableCollection<string>();
        private string _s;

        public MainPage()
        {
            InitializeComponent();
            currnotxt.Text = "";

            _conn = DependencyService.Get<ISQLiteDb>().GetConnection();
        }

        /// <summary>
        /// Saves the specified number to database.
        /// </summary>
        /// <param name="numx">The numx.</param>
        /// <param name="gno">The gno.</param>
        private async void save(string numx, int gno = 0)
        {
            var temp = new Gamedata();
            temp.id = 0;
            temp.gameno = gno;
            temp.number = numx;


            await _conn.InsertAsync(temp);
        }

        /// <summary>
        /// Clear & saves the specified Current game.
        /// </summary>
        /// <param name="saveit">if set to <c>true</c> [saveit].</param>
        private void clearsave(bool saveit)
        {
            var app = Application.Current as App;
            var gnum = Convert.ToInt32(app.gameno);

            foreach (var numx in list)
            {
                
                if (saveit)
                {
                    save(numx, gnum);
                }
                list.Remove(numx);
            }
            if (saveit)
            {
                gnum++;
                app.gameno = gnum.ToString();
            }
         //   index = 1;
            indextxt.Text = list.Count.ToString();
        }

        protected override async void OnAppearing()
        {
            await _conn.CreateTableAsync<Gamedata>();
            indextxt.Text = list.Count.ToString();
            base.OnAppearing();
        }

        /// <summary>
        /// Sort Game.
        /// </summary>
        private void sortlist()
        {
            for (var X = 0; X < list.Count - 1; X++)
            {
                for (var y = X + 1; y < list.Count; y++)
                {
                    var xs = list[X];
                    var ys = list[y];
                    if (Convert.ToInt32(xs) > Convert.ToInt32(ys))
                    {
                        list[X] = ys;
                        list[y] = xs;
                    }
                }
            }
        }

        /// <summary>
        /// Checks the specified number.
        /// </summary>
        /// <param name="num">The number.</param>
        private void check(string num)
        {
            var no = Convert.ToInt32(num);
            if (no > 0 && no < 81)
            {
                var addno = true;
                foreach (var numxx in list)
                {
                    if (numxx == num)
                    {
                        addno = false;
                    }
                }

                if (addno)
                {
                    list.Add(num);
            //        index++;
                    indextxt.Text = list.Count.ToString();
                }
                else
                {
                    currnotxt.Text = "Dup";
                }
            }
            else
            {
                DisplayAlert("Invalid entry", "Number must be 80 or less", "OK");
                currnotxt.Text = "";
            }
            if (list.Count > 20)
            {
                clearsave(true);
            }
        }

        /// <summary>
        /// Get a number
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void num_click(object sender, EventArgs e)
        {
            var nbum = (Button) sender;
            var num = nbum.Text;
            curnum = curnum + num;
            currnotxt.Text = curnum;
            if (curnum.Length == 2)
            {
                check(curnum);
                curnum = "";
            }
        }

        /// <summary>
        /// Clear current number.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void clear_click(object sender, EventArgs e)
        {
            if (curnum.Length == 1)
            {
                curnum = "";
                currnotxt.Text = "";
            }
            else
            {
                if (list.Count > 0)
                {
                    list.Remove(curnum);
                    // index--;
                    indextxt.Text = list.Count.ToString();
                    curnum = list.Last();

                    currnotxt.Text = curnum;
                }
            }
        }

        private async void settings_click(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new SettingsPage());
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
        /// <summary>
        /// Display current Game.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private async void curr_click(object sender, EventArgs e)
        {
            sortlist();
           var pg  = new  CurrGamePage(list);
            await Navigation.PushAsync(pg);
            list = pg.xList;
        }

        private async void stats_click(object sender, EventArgs e)
        {
            var pg = new  StatPage();
            await Navigation.PushAsync(pg);
        }

        private async void pick_click(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new PickPage());
        }

        /// <summary>
        /// Remove the current game
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void data_click(object sender, EventArgs e)
        {
            if (askit("Are you sure you want to remove data"))
            {
                clearsave(false);
            }
        }
    }
}