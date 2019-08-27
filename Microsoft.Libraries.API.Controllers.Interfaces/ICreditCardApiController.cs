using Microsoft.AspNetCore.Mvc;
using System;

namespace Microsoft.Libraries.API.Controllers.Interfaces
{
    /// <summary>
    /// API Controller Interface for Credit Card Info Services
    /// </summary>
    public interface ICreditCardApiController
    {
        /// <summary>
        /// Validates Credit Card for Payment Services
        /// </summary>
        /// <param name="transactionInfo"></param>
        /// <returns>Status</returns>
        IActionResult ValidatePayment(TransactionInfo transactionInfo);
    }
}
