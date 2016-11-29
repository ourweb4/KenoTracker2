using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using KenoTracker1.models;
using SQLite.Net.Async;
using Xamarin.Forms;

namespace KenoTracker1.views
{
    public partial class StatsPage : ContentPage
    {
        private readonly SQLiteAsyncConnection _conn;
        private numbersstats[] nums = new numbersstats[81];
        public StatsPage ()
        {
            InitializeComponent();
            _conn = DependencyService.Get<ISQLiteDb>().GetConnection();
            clearstats();
            loaddata();

            sorstats();
            listviewxx.ItemsSource = nums;
        }

        private async void loaddata()
        {

            var database = await _conn.Table<Gamedata>().ToListAsync();
            foreach (var data in database)
            {
                var num = Convert.ToInt16(data.number);
                nums[num - 1].add();
            }
        }
        private void clearstats()
        {
            for (var x = 0; x < 81; x++)
            {
                var yy = x + 1;
                nums[x].Number = yy.ToString();
                nums[x].Count = 0;
            }
        }

        private void sorstats()
        {
            var temp = new numbersstats();

            for (int i = 0; i < 80; i++)
            {
                for (var x = i + 1; x < 81; x++)
                {
                    if (nums[i].Count < nums[x].Count)
                    {
                        temp = nums[i];
                        nums[i] = nums[x];
                        nums[x] = temp;
                    }
                    
                }
            }
                
            
        }

        private class ListViewxx
        {
        }
    }

}
