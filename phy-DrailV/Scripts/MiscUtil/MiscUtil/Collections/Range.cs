using System;
using System.Collections.Generic;
using MiscUtil.Extensions;

namespace MiscUtil.Collections
{
	public sealed class Range<T>
	{
		private readonly T start;

		private readonly T end;

		private readonly IComparer<T> comparer;

		private readonly bool includesStart;

		private readonly bool includesEnd;

		public T Start => start;

		public T End => end;

		public IComparer<T> Comparer => comparer;

		public bool IncludesStart => includesStart;

		public bool IncludesEnd => includesEnd;

		public Range(T start, T end)
			: this(start, end, (IComparer<T>)Comparer<T>.Default, true, true)
		{
		}

		public Range(T start, T end, IComparer<T> comparer)
			: this(start, end, comparer, true, true)
		{
		}

		public Range(T start, T end, IComparer<T> comparer, bool includeStart, bool includeEnd)
		{
			if (comparer.Compare(start, end) > 0)
			{
				throw new ArgumentOutOfRangeException("end", "start must be lower than end according to comparer");
			}
			this.start = start;
			this.end = end;
			this.comparer = comparer;
			includesStart = includeStart;
			includesEnd = includeEnd;
		}

		public Range<T> ExcludeEnd()
		{
			if (!includesEnd)
			{
				return this;
			}
			return new Range<T>(start, end, comparer, includesStart, includeEnd: false);
		}

		public Range<T> ExcludeStart()
		{
			if (!includesStart)
			{
				return this;
			}
			return new Range<T>(start, end, comparer, includeStart: false, includesEnd);
		}

		public Range<T> IncludeEnd()
		{
			if (includesEnd)
			{
				return this;
			}
			return new Range<T>(start, end, comparer, includesStart, includeEnd: true);
		}

		public Range<T> IncludeStart()
		{
			if (includesStart)
			{
				return this;
			}
			return new Range<T>(start, end, comparer, includeStart: true, includesEnd);
		}

		public bool Contains(T value)
		{
			int num = comparer.Compare(value, start);
			if (num < 0 || (num == 0 && !includesStart))
			{
				return false;
			}
			int num2 = comparer.Compare(value, end);
			if (num2 >= 0)
			{
				if (num2 == 0)
				{
					return includesEnd;
				}
				return false;
			}
			return true;
		}

		public RangeIterator<T> FromStart(Func<T, T> step)
		{
			return new RangeIterator<T>(this, step);
		}

		public RangeIterator<T> FromEnd(Func<T, T> step)
		{
			return new RangeIterator<T>(this, step, ascending: false);
		}

		public RangeIterator<T> UpBy(T stepAmount)
		{
			return new RangeIterator<T>(this, (T t) => Operator.Add(t, stepAmount));
		}

		public RangeIterator<T> DownBy(T stepAmount)
		{
			return new RangeIterator<T>(this, (T t) => Operator.Subtract(t, stepAmount), ascending: false);
		}

		public RangeIterator<T> UpBy<TAmount>(TAmount stepAmount)
		{
			return new RangeIterator<T>(this, (T t) => Operator.AddAlternative(t, stepAmount));
		}

		public RangeIterator<T> DownBy<TAmount>(TAmount stepAmount)
		{
			return new RangeIterator<T>(this, (T t) => Operator.SubtractAlternative(t, stepAmount), ascending: false);
		}

		public RangeIterator<T> Step(Func<T, T> step)
		{
			step.ThrowIfNull("step");
			if (comparer.Compare(start, step(start)) >= 0)
			{
				return FromEnd(step);
			}
			return FromStart(step);
		}

		public RangeIterator<T> Step(T stepAmount)
		{
			return Step((T t) => Operator.Add(t, stepAmount));
		}

		public RangeIterator<T> Step<TAmount>(TAmount stepAmount)
		{
			return Step((T t) => Operator.AddAlternative(t, stepAmount));
		}
	}
}
