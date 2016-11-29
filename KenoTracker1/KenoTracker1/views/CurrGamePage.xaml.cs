// ***********************************************************************
// Assembly         : KenoTracker1.Droid
// Author           : Bill
// Created          : 11-10-2016
//
// Last Modified By : Bill
// Last Modified On : 11-14-2016
// ***********************************************************************
// <copyright file="CurrGamePage.xaml.cs" company="">
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

using Xamarin.Forms;

namespace KenoTracker1.views
{
    /// <summary>
    /// Class CurrGamePage.
    /// </summary>
    public partial class CurrGamePage : ContentPage
    {
        /// <summary>
        /// The game number list
        /// </summary>
        public ObservableCollection<string> xList;
        /// <summary>
        /// Initializes a new instance of the <see cref="CurrGamePage"/> class.
        /// </summary>
        /// <param name="iList">The i list.</param>
        public CurrGamePage (ObservableCollection<string> iList )
        {
            InitializeComponent ();
            xList = iList;
            
             ListViewx.ItemsSource = xList;
        }

        /// <summary>
        /// Handles the OnItemSelected event of the ListViewx control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="SelectedItemChangedEventArgs"/> instance containing the event data.</param>
        private void ListViewx_OnItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            ListViewx.SelectedItem = null;
        }

        /// <summary>
        /// Handles the OnItemTapped event of the ListViewx control.
        /// Remove a number
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="ItemTappedEventArgs"/> instance containing the event data.</param>
        private void ListViewx_OnItemTapped(object sender, ItemTappedEventArgs e)
        {
            var numx = e.Item as string;
            xList.Remove(numx);
            
        }
    }
}
