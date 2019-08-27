using Microsoft.AspNetCore.Mvc;
using Microsoft.Libraries.API.Controllers.Interfaces;
using Microsoft.Libraries.Business.Interfaces;
using System;

namespace Microsoft.Libraries.API.Controllers.Impl
{
    /// <summary>
    /// API Controller Implementation for Credit Card Info Services
    /// </summary>
    [ApiController]
    [Route("api/credit-cards")]
    public class CreditCardApiController : Controller, ICreditCardApiController
    {
        private ICreditCardBusinessComponent creditCardBusinessComponent = default(ICreditCardBusinessComponent);

        public CreditCardApiController(ICreditCardBusinessComponent creditCardBusinessComponent)
        {
            if (creditCardBusinessComponent == default(ICreditCardBusinessComponent))
                throw new ArgumentNullException(nameof(creditCardBusinessComponent));

            this.creditCardBusinessComponent = creditCardBusinessComponent;
        }

        /// <summary>
        /// Validates Credit Card for Payment Services
        /// </summary>
        /// <param name="transactionInfo"></param>
        /// <returns>Status</returns>
        [HttpPost]
        [Route("validate")]
        public IActionResult ValidatePayment([FromBody] TransactionInfo transactionInfo)
        {
            var result = default(IActionResult);
            var validation = transactionInfo != default(TransactionInfo);

            if (!validation)
                result = new BadRequestResult();
            else
            {
                var creditValidation = this.creditCardBusinessComponent.ValidateCreditCard(
                    transactionInfo.CreditCardNumber, transactionInfo.CVVCode,
                    transactionInfo.ExpiryDate, transactionInfo.TransactionAmount);

                if (!creditValidation)
                    result = new BadRequestObjectResult(new
                    {
                        message = "Invalid Credit Card Details",
                        status = "FAILED"
                    });
                else
                    result = new OkObjectResult(new
                    {
                        status = "VALID"
                    });
            }

            return result;
        }
    }
}
