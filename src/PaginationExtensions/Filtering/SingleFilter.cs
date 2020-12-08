using PaginationExtensions.Helpers;
using System;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Linq.Expressions;

namespace PaginationExtensions.Filtering
{
    public class SingleFilter<T> : IFilter<T>
    {
        private readonly Expression<Func<T, bool>> _predicate;

        public SingleFilter([NotNull] Expression<Func<T, bool>>? predicate)
        {
            _predicate = predicate ?? throw new ArgumentNullException(nameof(predicate));
        }

        public IQueryable<T> ApplyTo([NotNull] IQueryable<T>? source)
        {
            ThrowHelper.ThrowIfIsNull(source, nameof(source));

            return source.Where(_predicate);
        }
    }
}