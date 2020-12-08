using PaginationExtensions.Filtering;
using PaginationExtensions.Helpers;
using PaginationExtensions.Sorting;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;

namespace PaginationExtensions
{
    public static class Extensions
    {
        public static IQueryable<T> LoadData<T>(this IQueryable<T> source, [NotNull] DataRequest<T>? request)
        {
            ThrowHelper.ThrowIfIsNull(request, nameof(request));

            var loaded = source;

            if (request.Filter is not null)
            {
                loaded = loaded.Filter(request.Filter);
            }

            if (request.Sort is not null)
            {
                loaded = source.Sort(request.Sort);
            }

            if (request.Skip is not null)
            {
                loaded = loaded.Skip(request.Skip.Value);
            }

            if (request.Take is not null)
            {
                loaded = loaded.Take(request.Take.Value);
            }

            return loaded;
        }

        public static IQueryable<T> Filter<T> (this IQueryable<T> source, [NotNull] IFilter<T>? filter)
        {
            ThrowHelper.ThrowIfIsNull(filter, nameof(filter));

            return filter.ApplyTo(source);
        }

        public static IQueryable<T> Sort<T, TKey>(this IQueryable<T> source, [NotNull] ISort<T, TKey>? sort)
        {
            ThrowHelper.ThrowIfIsNull(sort, nameof(sort));

            return sort.ApplyTo(source);
        }

        public static IQueryable<T> Sort<T, TKey>(this IQueryable<T> source, [NotNull] ISort<T, TKey>? sort, [NotNull] IComparer<TKey>? comparer)
        {
            ThrowHelper.ThrowIfIsNull(sort, nameof(sort));
            ThrowHelper.ThrowIfIsNull(comparer, nameof(comparer));

            return sort.ApplyTo(source, comparer);
        }
    }
}