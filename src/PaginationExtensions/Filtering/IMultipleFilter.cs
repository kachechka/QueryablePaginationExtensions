namespace PaginationExtensions.Filtering
{
    public interface IMultipleFilter<T>
    {
        void AddFilter(IFilter<T>? filter);
    }
}