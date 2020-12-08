namespace PaginationExtensions.Sorting
{
    public interface IMultipleSort<T> : ISort<T, object>
    {
        void AddSort(ISort<T, object>? sort);
    }
}