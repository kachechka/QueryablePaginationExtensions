using System;
using System.Diagnostics.CodeAnalysis;

namespace PaginationExtensions.Helpers
{
    internal static class ThrowHelper
    {
        internal static void ThrowIfIsNull([NotNull] object? value, string? name = null)
        {
            if (value is not null)
            {
                return;
            }

            if (string.IsNullOrEmpty(name))
            {
                throw new ArgumentNullException();
            }

            throw new ArgumentNullException(name);
        }
    }
}