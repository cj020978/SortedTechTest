using System.Diagnostics.Contracts;

namespace SortedTechTest.Error
{
    public class ErrorDetail
    {
        public string? propertyName { set; get; }

        public string? message { set; get; }
    }
}
