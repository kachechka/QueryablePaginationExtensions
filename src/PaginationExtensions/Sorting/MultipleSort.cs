using PaginationExtensions.Helpers;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;

namespace PaginationExtensions.Sorting
{
    public class MultipleSort<T> : IMultipleSort<T>
    {
        private readonly ICollection<ISort<T, object>> _sorts;

        public MultipleSort()
        {
            _sorts = new List<ISort<T, object>>();
        }

        public MultipleSort(int capacity)
        {
            _sorts = new List<ISort<T, object>>(capacity);
        }

        public void AddSort([NotNull] ISort<T, object>? sort)
        {
            ThrowHelper.ThrowIfIsNull(sort, nameof(sort));

            _sorts.Add(sort);
        }

        public IQueryable<T> ApplyTo([NotNull] IQueryable<T>? source)
        {
            ThrowHelper.ThrowIfIsNull(source, nameof(source));

            if (_sorts.Count == 0)
            {
                return source;
            }

            var sorted = source;

            foreach (var sort in _sorts)
            {
                sorted = sort.ApplyTo(source);
            }

            return sorted;
        }

        public IQueryable<T> ApplyTo(IQueryable<T>? source, IComparer<object>? comparer)
        {
            ThrowHelper.ThrowIfIsNull(source, nameof(source));
            ThrowHelper.ThrowIfIsNull(comparer, nameof(comparer));

            if (_sorts.Count == 0)
            {
                return source;
            }

            var sorted = source;

            foreach (var sort in _sorts)
            {
                sorted = sort.ApplyTo(source, comparer);
            }

            return sorted;
        }
    }
}