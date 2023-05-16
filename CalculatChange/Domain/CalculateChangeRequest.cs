namespace CalculateChange.Domain
{
    public class CalculateChangeRequest
    {
        public decimal GivenAmount { get; set; }
        public decimal ProductPrice { get; set; }
    }
}