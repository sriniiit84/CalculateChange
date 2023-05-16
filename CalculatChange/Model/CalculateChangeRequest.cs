namespace CalculateChange.Domain
{
    /// <summary>
    /// Object to hold the request values
    /// </summary>
    public class CalculateChangeRequest
    {
        public decimal GivenAmount { get; set; }
        public decimal ProductPrice { get; set; }
    }
}