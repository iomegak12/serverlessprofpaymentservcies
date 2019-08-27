using System;
using System.Collections.Generic;
using System.Text;

namespace Microsoft.Libraries.API.Controllers.Interfaces
{
    /// <summary>
    /// Input Model for API Requests (Credit Card Info)
    /// </summary>
    public class TransactionInfo
    {
        /// <summary>
        /// Credit Card Number
        /// </summary>
        public string CreditCardNumber { get; set; }
        /// <summary>
        /// CVV Code
        /// </summary>
        public int CVVCode { get; set; }
        /// <summary>
        /// Expiry Date
        /// </summary>
        public DateTime ExpiryDate { get; set; }
        /// <summary>
        /// Transaction Amount
        /// </summary>
        public int TransactionAmount { get; set; }

        /// <summary>
        /// Formatted String of the Model
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return string.Format(@"{0}, {1}, {2}, {3}",
                this.CreditCardNumber, this.CVVCode,
                this.ExpiryDate.ToString(), this.TransactionAmount);
        }
    }
}
