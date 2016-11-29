// ***********************************************************************
// Assembly         : KenoTracker1.Droid
// Author           : Bill
// Created          : 11-24-2016
//
// Last Modified By : Bill
// Last Modified On : 11-24-2016
// ***********************************************************************
// <copyright file="StatPage.xaml.cs" company="">
//     Copyright ©  2014
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KenoTracker1.models;
using SQLite.Net.Async;
using Xamarin.Forms;

namespace KenoTracker1.views
{
    /// <summary>
    /// Class StatPage.
    /// </summary>
    public partial class StatPage : ContentPage
    {

        /// <summary>
        /// The connection
        /// </summary>
        private readonly SQLiteAsyncConnection _conn;
        /// <summary>
        /// The nums
        /// </summary>
        public ObservableCollection<numbersstats>  Nums = new ObservableCollection<numbersstats>();

        /// <summary>
        /// Initializes a new instance of the <see cref="StatPage"/> class.
        /// </summary>
        public StatPage ()
        {
            InitializeComponent ();
            _conn = DependencyService.Get<ISQLiteDb>().GetConnection();

        }

        /// <summary>
        /// Called when [appearing].
        /// </summary>
        protected override void OnAppearing()
        {
            base.OnAppearing();
            clearstats();
            loaddata();
            sortstats();
            listviewxx.ItemsSource = Nums;
        }

        /// <summary>
        /// Load history of numbers.
        /// </summary>
        private async void loaddata()
        {

            var database = await _conn.Table<Gamedata>().ToListAsync();
            foreach (var data in database)
            {
                var num = Convert.ToInt16(data.number);
                Nums[num - 1].add();
            }
        }
        /// <summary>
        /// Clear stats.
        /// </summary>
        private void clearstats()
        {
            //var bn = new numbersstats();
            var yy = 1;
            for (var x = 0; x < 80; x++)
            {
                var ys = yy.ToString();
                yy++;
             
                 Nums.Add(new numbersstats(ys));
            }
        }

        /// <summary>
        /// Sortstats .
        /// </summary>
        private void sortstats()
        {
            //var temp = new numbersstats();

            for (var  i = 0; i < 79; i++)
            {
                for (var x = i + 1; x < 80; x++)
                {
                    var xc = Nums[x].Count;
                    var ic = Nums[i].Count;
                    if (ic < xc)
                    {
                      var  temp = Nums[i];
                        Nums[i] = Nums[x];
                        Nums[x] = temp;
                    }
                }
            }


        }

    }
}
