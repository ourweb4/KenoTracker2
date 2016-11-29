// ***********************************************************************
// Assembly         : KenoTracker1.Droid
// Author           : Bill
// Created          : 11-09-2016
//
// Last Modified By : Bill
// Last Modified On : 11-09-2016
// ***********************************************************************
// <copyright file="ISQLiteDb.cs" company="">
//     Copyright ©  2014
// </copyright>
// <summary></summary>
// ***********************************************************************

using SQLite.Net.Async;

namespace KenoTracker1
{
    /// <summary>
    /// Interface ISQLiteDb
    /// </summary>
    public interface ISQLiteDb
    {
        /// <summary>
        /// Gets the connection.
        /// </summary>
        /// <returns>SQLiteAsyncConnection.</returns>
        SQLiteAsyncConnection GetConnection();
    }
}

