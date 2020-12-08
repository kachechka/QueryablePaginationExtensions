using PaginationExtensions.Filtering;
using PaginationExtensions.Sorting;

namespace PaginationExtensions
{
    public class DataRequest<T>
    {
        public int? Skip { get; set; }

        public int? Take { get; set; }

        public ISort<T, object>? Sort { get; set; }

        public IFilter<T>? Filter { get; set; }

        public DataRequest()
        { }

        public DataRequest(int skip, int take)
        {
            Skip = skip;
            Take = take;
        }
    }
}