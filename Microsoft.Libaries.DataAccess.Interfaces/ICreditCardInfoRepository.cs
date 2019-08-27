using Microsoft.Libraries.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Microsoft.Libraries.DataAccess.Interfaces
{
    /// <summary>
    /// Provides Seemless Access to Entity
    /// </summary>
    public interface ICreditCardInfoRepository : IDisposable
    {
        /// <summary>
        /// Provides Credit Card Info
        /// </summary>
        /// <param name="creditCardNumber">CC Number</param>
        /// <param name="cvvCode">CVV Code for Validation</param>
        /// <returns>Credit Card Details</returns>
        CreditCardInfo GetCreditCardInfo(string creditCardNumber, int cvvCode);
    }
}
