using System.Collections.Generic;
using MiscUtil.Extensions;

namespace MiscUtil.Collections
{
	public sealed class ReverseComparer<T> : IComparer<T>
	{
		private readonly IComparer<T> originalComparer;

		public IComparer<T> OriginalComparer => originalComparer;

		public ReverseComparer(IComparer<T> original)
		{
			original.ThrowIfNull("original");
			originalComparer = original;
		}

		public int Compare(T x, T y)
		{
			return originalComparer.Compare(y, x);
		}
	}
}
