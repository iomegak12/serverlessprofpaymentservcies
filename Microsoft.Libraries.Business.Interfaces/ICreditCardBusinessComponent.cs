using System;

namespace Microsoft.Libraries.Business.Interfaces
{
    /// <summary>
    /// Business Interface for Credit Cards
    /// </summary>
    public interface ICreditCardBusinessComponent : IDisposable
    {
        /// <summary>
        /// Validates Credit Card Info for Payment Processing
        /// </summary>
        /// <param name="creditCardNumber"></param>
        /// <param name="cvvCode"></param>
        /// <param name="expiryDate"></param>
        /// <param name="transactionAmount"></param>
        /// <returns>Status</returns>
        bool ValidateCreditCard(string creditCardNumber,
            int cvvCode, DateTime expiryDate, int transactionAmount);
    }
}
