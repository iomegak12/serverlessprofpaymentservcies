using Microsoft.Libraries.Business.Interfaces;
using Microsoft.Libraries.DataAccess.Interfaces;
using Microsoft.Libraries.Models;
using System;

namespace Microsoft.Libraries.Business.Impl
{
    /// <summary>
    /// Business Implementation for Credit Cards
    /// </summary>
    public class CreditCardBusinessComponent : ICreditCardBusinessComponent
    {
        private ICreditCardInfoRepository creditCardInfoRepository = default(ICreditCardInfoRepository);

        public CreditCardBusinessComponent(ICreditCardInfoRepository creditCardInfoRepository)
        {
            if (creditCardInfoRepository == default(ICreditCardInfoRepository))
                throw new ArgumentNullException(nameof(creditCardInfoRepository));

            this.creditCardInfoRepository = creditCardInfoRepository;
        }

        public void Dispose() => this.creditCardInfoRepository?.Dispose();

        /// <summary>
        /// Validates Credit Card Info for Payment Processing
        /// </summary>
        /// <param name="creditCardNumber"></param>
        /// <param name="cvvCode"></param>
        /// <param name="expiryDate"></param>
        /// <param name="transactionAmount"></param>
        /// <returns>Status</returns>
        public bool ValidateCreditCard(string creditCardNumber, int cvvCode, DateTime expiryDate, int transactionAmount)
        {
            var validation = !string.IsNullOrEmpty(creditCardNumber) &&
                cvvCode != default(int) && expiryDate >= DateTime.Now.AddMonths(-12) &&
                transactionAmount != default(int);

            if (!validation)
                throw new ApplicationException("Invalid Input(s) Specified for Payment Transactions!");

            var filteredCreditCardInfo = this.creditCardInfoRepository.GetCreditCardInfo(creditCardNumber, cvvCode);

            if (filteredCreditCardInfo == default(CreditCardInfo))
                throw new ApplicationException("Invalid Credit Card Details Specified!");

            var creditValidation = filteredCreditCardInfo.ExpiryDate >= expiryDate &&
                filteredCreditCardInfo.CreditLimit >= transactionAmount &&
                filteredCreditCardInfo.IsActive;

            return creditValidation;
        }
    }
}
