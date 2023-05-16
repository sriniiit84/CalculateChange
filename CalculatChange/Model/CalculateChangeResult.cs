using System.Collections.Generic;

namespace CalculateChange.Domain
{
    /// <summary>
    /// Object to hold the return value
    /// </summary>
    public class CalculateChangeResult
    {
        public Dictionary<string, int> ChangeDenominations { get; set; }

    }
}