using System;

namespace Microsoft.Libraries.Models
{
    /// <summary>
    /// CreditCardInfo Model
    /// </summary>
    public class CreditCardInfo
    {
        /// <summary>
        /// Unique Credit Card Number Reference
        /// </summary>
        public string CreditCardNumber { get; set; }
        /// <summary>
        /// Expiry Date
        /// </summary>
        public DateTime ExpiryDate { get; set; }
        /// <summary>
        /// Valid Customer Name
        /// </summary>
        public string CustomerName { get; set; }
        /// <summary>
        /// Assigned CVV Code
        /// </summary>
        public int CVVCode { get; set; }
        /// <summary>
        /// Credit Limit
        /// </summary>
        public int CreditLimit { get; set; }
        /// <summary>
        /// Active Status
        /// </summary>
        public bool IsActive { get; set; }

        /// <summary>
        /// String Formatted Message of Model
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return string.Format(@"{0}, {1}, {2}, {3}, {4}, {5}",
                this.CreditCardNumber, this.ExpiryDate.ToString(),
                this.CVVCode,
                this.CustomerName, this.CreditCardNumber, this.IsActive);
        }
    }
}
