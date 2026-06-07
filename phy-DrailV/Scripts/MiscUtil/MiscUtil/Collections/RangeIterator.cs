using System;
using System.Collections;
using System.Collections.Generic;
using MiscUtil.Collections.Extensions;
using MiscUtil.Extensions;

namespace MiscUtil.Collections
{
	public class RangeIterator<T> : IEnumerable<T>, IEnumerable
	{
		private readonly Range<T> range;

		private readonly Func<T, T> step;

		private readonly bool ascending;

		public Range<T> Range => range;

		public Func<T, T> Step => step;

		public bool Ascending => ascending;

		public RangeIterator(Range<T> range, Func<T, T> step)
			: this(range, step, true)
		{
		}

		public RangeIterator(Range<T> range, Func<T, T> step, bool ascending)
		{
			step.ThrowIfNull("step");
			if ((ascending && range.Comparer.Compare(range.Start, step(range.Start)) >= 0) || (!ascending && range.Comparer.Compare(range.End, step(range.End)) <= 0))
			{
				throw new ArgumentException("step does nothing, or progresses the wrong way");
			}
			this.ascending = ascending;
			this.range = range;
			this.step = step;
		}

		public IEnumerator<T> GetEnumerator()
		{
			bool includesStart = (ascending ? range.IncludesStart : range.IncludesEnd);
			bool includesEnd = (ascending ? range.IncludesEnd : range.IncludesStart);
			T start = (ascending ? range.Start : range.End);
			T end = (ascending ? range.End : range.Start);
			IComparer<T> comparer = (ascending ? range.Comparer : range.Comparer.Reverse());
			T value = start;
			if (includesStart && (includesEnd || comparer.Compare(value, end) < 0))
			{
				yield return value;
			}
			value = step(value);
			while (comparer.Compare(value, end) < 0)
			{
				yield return value;
				value = step(value);
			}
			if (includesEnd && comparer.Compare(value, end) == 0)
			{
				yield return value;
			}
		}

		IEnumerator IEnumerable.GetEnumerator()
		{
			return GetEnumerator();
		}
	}
}
