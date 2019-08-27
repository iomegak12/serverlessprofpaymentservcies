using Microsoft.Libraries.DataAccess.Interfaces;
using Microsoft.Libraries.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Microsoft.Libraries.DataAccess.Impl
{
    /// <summary>
    /// Credit Card Info Repo. Impl
    /// </summary>
    public class CreditCardInfoRepository : ICreditCardInfoRepository
    {
        private ICreditCardInfoContext creditCardInfoContext = default(ICreditCardInfoContext);

        /// <summary>
        /// DI and IoC Enabled Constructor for Respository
        /// </summary>
        /// <param name="creditCardInfoContext"></param>
        public CreditCardInfoRepository(ICreditCardInfoContext creditCardInfoContext)
        {
            if (creditCardInfoContext == default(ICreditCardInfoContext))
                throw new ArgumentNullException(nameof(creditCardInfoContext));

            this.creditCardInfoContext = creditCardInfoContext;
        }

        /// <summary>
        /// Dispose of Resources
        /// </summary>
        public void Dispose() => this.creditCardInfoContext?.Dispose();

        /// <summary>
        /// Provides Credit Card Info
        /// </summary>
        /// <param name="creditCardNumber">CC Number</param>
        /// <param name="cvvCode">CVV Code for Validation</param>
        /// <returns>Credit Card Details</returns>
        public CreditCardInfo GetCreditCardInfo(string creditCardNumber, int cvvCode)
        {
            var validation = !string.IsNullOrEmpty(creditCardNumber) && cvvCode != default(int);

            if (!validation)
                throw new ApplicationException("Invalid Input(s) Specified!");

            var filteredCreditCardInfo =
                this.
                    creditCardInfoContext.
                    CreditCardInfo.
                    Where(creditCardInfo => creditCardInfo.CreditCardNumber.Equals(creditCardNumber) &&
                        creditCardInfo.CVVCode == cvvCode).
                    FirstOrDefault();

            if (filteredCreditCardInfo == default(CreditCardInfo))
                throw new ApplicationException("Invalid Credit Card Details Specified!");

            return filteredCreditCardInfo;
        }
    }
}
