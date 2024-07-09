namespace SortedTechTest.Error
{
    public class ErrorManager
    {
        public static Error RaiseCountError()
        {
            ErrorDetail errorDetail = new ErrorDetail
            {
                propertyName = "Count",
                message = "The Count value must be between 1 and 100"
            };

            return new Error
            {
                message = "The value is outside the allowed range",
                detail = new ErrorDetail[] { errorDetail }
            };
        }

        public static Error RaiseNotFoundError()
        {
            ErrorDetail errorDetail = new ErrorDetail
            {
                propertyName = "Id",
                message = "No readings found for the specified stationId"
            };

            return new Error
            {
                message = "No Data Found",
                detail = new ErrorDetail[] { errorDetail }
            };
        }
    }
}
