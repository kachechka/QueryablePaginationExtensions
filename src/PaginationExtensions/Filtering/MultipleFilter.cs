using PaginationExtensions.Helpers;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;

namespace PaginationExtensions.Filtering
{
    public class MultipleFilter<T> : IFilter<T>
    {
        private readonly ICollection<IFilter<T>> _filters;

        public MultipleFilter()
        {
            _filters = new List<IFilter<T>>();
        }

        public MultipleFilter(int capacity)
        {
            _filters = new List<IFilter<T>>(capacity);
        }

        public void AddFilter([NotNull] IFilter<T>? filter)
        {
            ThrowHelper.ThrowIfIsNull(filter, nameof(filter));

            _filters.Add(filter);
        }

        public IQueryable<T> ApplyTo([NotNull] IQueryable<T>? source)
        {
            ThrowHelper.ThrowIfIsNull(source, nameof(source));

            if (_filters.Count == 0)
            {
                return source;
            }

            var filtered = source;

            foreach (var filter in _filters)
            {
                filtered = filter.ApplyTo(filtered);
            }

            return filtered;
        }
    }
}