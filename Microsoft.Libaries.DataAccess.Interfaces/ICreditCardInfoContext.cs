using Microsoft.EntityFrameworkCore;
using Microsoft.Libraries.Models;
using System;

namespace Microsoft.Libraries.DataAccess.Interfaces
{
    /// <summary>
    /// Credit Card Info Context Interface
    /// </summary>
    public interface ICreditCardInfoContext : IDisposable
    {
        /// <summary>
        /// Gets Access to Credit Card Info Entity
        /// </summary>
        DbSet<CreditCardInfo> CreditCardInfo { get; set; }
    }
}
