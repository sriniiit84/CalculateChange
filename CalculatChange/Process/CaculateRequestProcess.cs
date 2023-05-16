using CalculatChange.Model;
using CalculateChange.Domain;
using System;
using System.Collections.Generic;

namespace CalculateChange.ProcessChange
{
    /// <summary>
    /// Process to get the request and calculate change
    /// </summary>
    public class CaculateRequestProcess
    {

        /// <summary>
        /// Process the change by geting the request object
        /// </summary>
        /// <param name="request">Gets the change request as an object</param>
        /// <returns>CalculateChangeResult object</returns>
        public CalculateChangeResult ProcessChange(CalculateChangeRequest request)
        {
            var result = CalculateChangeRequest(request.GivenAmount, request.ProductPrice);

            return new CalculateChangeResult
            {
                ChangeDenominations = result
            };
        }


        /// <summary>
        /// Business logic to calculate the change
        /// </summary>
        /// <param name="currencyAmount"></param>
        /// <param name="productPrice"></param>
        /// <returns>Dictonary collection</returns>
        /// <exception cref="ArgumentException"></exception>
        public Dictionary<string, int> CalculateChangeRequest(decimal currencyAmount, decimal productPrice)
        {
            decimal change = currencyAmount - productPrice;

            if (change < 0)
                throw new ArgumentException("Insufficient currency amount.");

            var denominations = new decimal[] { 50, 20, 10, 5, 2, 1, 0.5m, 0.2m, 0.1m, 0.05m, 0.02m, 0.01m };
            var changeDictionary = new Dictionary<string, int>();

            foreach (decimal denomination in denominations)
            {
                int count = (int)(change / denomination);
                if (count > 0)
                {
                    changeDictionary.Add(GetDenominationString(denomination), count);
                    change -= count * denomination;
                }
            }

            return changeDictionary;
        }

        /// <summary>
        /// Append the pound or pence symbol 
        /// </summary>
        /// <param name="denomination"></param>
        /// <returns></returns>
        private string GetDenominationString(decimal denomination)
        {
            if (denomination >= 1)
                return CalculateChangeConstants.PoundSymbol + denomination;
            else
                return denomination * 100 + CalculateChangeConstants.PenceSymbol;
        }

    }
}