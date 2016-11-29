// ***********************************************************************
// Assembly         : KenoTracker1.Droid
// Author           : Bill
// Created          : 11-09-2016
//
// Last Modified By : Bill
// Last Modified On : 11-09-2016
// ***********************************************************************
// <copyright file="Gamedata.cs" company="">
//     Copyright ©  2014
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;
using System.Collections.Generic;
using System.Text;
using SQLite;
using SQLite.Net.Attributes;

namespace KenoTracker1.models
{
    /// <summary>
    /// Class Gamedata.
    /// </summary>
    class Gamedata
    {



        /// <summary>
        /// Gets or sets the identifier.
        /// </summary>
        /// <value>The identifier.</value>
        [PrimaryKey, AutoIncrement]
        public int id { get; set; }
        /// <summary>
        /// Gets or sets the gameno.
        /// </summary>
        /// <value>The gameno.</value>
        public int gameno { get; set; }
        /// <summary>
        /// Gets or sets the number.
        /// </summary>
        /// <value>The number.</value>
        public string number { get; set; }

     
        
    }
}
