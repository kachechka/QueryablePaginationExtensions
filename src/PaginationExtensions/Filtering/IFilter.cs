using System.Linq;

namespace PaginationExtensions.Filtering
{
    public interface IFilter<T>
    {
        IQueryable<T> ApplyTo(IQueryable<T>? source);
    }
}