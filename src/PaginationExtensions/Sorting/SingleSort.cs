using PaginationExtensions.Helpers;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Linq.Expressions;

namespace PaginationExtensions.Sorting
{
    public class SingleSort<T, TKey> : ISort<T, TKey>
    {
        private readonly Expression<Func<T, TKey>> _accessor;
        private readonly SortDirection _direction;

        public SingleSort(Expression<Func<T, TKey>>? accessor, SortDirection direction = SortDirection.Ascending)
        {
            _accessor = accessor ?? throw new ArgumentNullException(nameof(accessor));
            _direction = direction;
        }

        public IQueryable<T> ApplyTo(IQueryable<T>? source)
        {
            ThrowHelper.ThrowIfIsNull(source, nameof(source));
           
            if (source is IOrderedQueryable<T> sortedSourse)
            {
                return _direction switch
                {
                    SortDirection.Ascending => sortedSourse.ThenBy(_accessor),
                    SortDirection.Descending => sortedSourse.ThenByDescending(_accessor),
                    _ => throw new InvalidOperationException("Unknown sort direction"),
                };
            }

            return _direction switch
            {
                SortDirection.Ascending => source.OrderBy(_accessor),
                SortDirection.Descending => source.OrderByDescending(_accessor),
                _ => throw new InvalidOperationException("Unknown sort direction"),
            };
        }

        public IQueryable<T> ApplyTo([NotNull] IQueryable<T>? source, [NotNull] IComparer<TKey>? comparer)
        {
            ThrowHelper.ThrowIfIsNull(source, nameof(source));
            ThrowHelper.ThrowIfIsNull(comparer, nameof(comparer));

            if (source is IOrderedQueryable<T> sortedSourse)
            {
                return _direction switch
                {
                    SortDirection.Ascending => sortedSourse.ThenBy(_accessor, comparer),
                    SortDirection.Descending => sortedSourse.ThenByDescending(_accessor, comparer),
                    _ => throw new InvalidOperationException("Unknown sort direction"),
                };
            }

            return _direction switch
            {
                SortDirection.Ascending => source.OrderBy(_accessor, comparer),
                SortDirection.Descending => source.OrderByDescending(_accessor, comparer),
                _ => throw new InvalidOperationException("Unknown sort direction"),
            };
        }
    }
}