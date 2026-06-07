using System;
using System.Collections.Generic;
using MiscUtil.Extensions;

namespace MiscUtil.Collections
{
	public static class ProjectionComparer
	{
		public static ProjectionComparer<TSource, TKey> Create<TSource, TKey>(Func<TSource, TKey> projection)
		{
			return new ProjectionComparer<TSource, TKey>(projection);
		}

		public static ProjectionComparer<TSource, TKey> Create<TSource, TKey>(TSource ignored, Func<TSource, TKey> projection)
		{
			return new ProjectionComparer<TSource, TKey>(projection);
		}
	}
	public static class ProjectionComparer<TSource>
	{
		public static ProjectionComparer<TSource, TKey> Create<TKey>(Func<TSource, TKey> projection)
		{
			return new ProjectionComparer<TSource, TKey>(projection);
		}
	}
	public class ProjectionComparer<TSource, TKey> : IComparer<TSource>
	{
		private readonly Func<TSource, TKey> projection;

		private readonly IComparer<TKey> comparer;

		public ProjectionComparer(Func<TSource, TKey> projection)
			: this(projection, (IComparer<TKey>)null)
		{
		}

		public ProjectionComparer(Func<TSource, TKey> projection, IComparer<TKey> comparer)
		{
			projection.ThrowIfNull("projection");
			this.comparer = comparer ?? Comparer<TKey>.Default;
			this.projection = projection;
		}

		public int Compare(TSource x, TSource y)
		{
			if (x == null && y == null)
			{
				return 0;
			}
			if (x == null)
			{
				return -1;
			}
			if (y == null)
			{
				return 1;
			}
			return comparer.Compare(projection(x), projection(y));
		}
	}
}
