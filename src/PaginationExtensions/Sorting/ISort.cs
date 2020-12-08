using System.Collections.Generic;
using System.Linq;

namespace PaginationExtensions.Sorting
{
    public interface ISort<T, TKey>
    {
        IQueryable<T> ApplyTo(IQueryable<T>? source);
        IQueryable<T> ApplyTo(IQueryable<T>? source, IComparer<TKey>? comparer);
    }
}