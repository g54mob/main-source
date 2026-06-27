using System;
using System.Collections;
using System.Collections.Generic;

namespace FluentAssertions.Common
{
	internal sealed class Iterator<T> : IEnumerator<T>, IEnumerator, IDisposable
	{
		private const int InitialIndex = -1;

		private readonly IEnumerable<T> enumerable;

		private readonly int? maxItems;

		private IEnumerator<T> enumerator;

		private T current;

		private T next;

		private bool hasNext;

		private bool hasCurrent;

		private bool hasCompleted;

		public int Index { get; private set; }

		public bool IsFirst => Index == 0;

		public bool IsLast
		{
			get
			{
				if (!hasCurrent || hasNext)
				{
					return HasReachedMaxItems;
				}
				return true;
			}
		}

		object IEnumerator.Current => Current;

		public T Current
		{
			get
			{
				if (!hasCurrent)
				{
					throw new InvalidOperationException("Please call MoveNext first");
				}
				return current;
			}
			private set
			{
				current = value;
				hasCurrent = true;
			}
		}

		public bool HasReachedMaxItems => Index == maxItems;

		public bool IsEmpty
		{
			get
			{
				if (!hasCurrent && !hasCompleted)
				{
					throw new InvalidOperationException("Please call MoveNext first");
				}
				return Index == -1;
			}
		}

		public Iterator(IEnumerable<T> enumerable, int maxItems = int.MaxValue)
		{
			this.enumerable = enumerable;
			this.maxItems = maxItems;
			Reset();
		}

		public void Reset()
		{
			Index = -1;
			enumerator = enumerable.GetEnumerator();
			hasCurrent = false;
			hasNext = false;
			hasCompleted = false;
			current = default(T);
			next = default(T);
		}

		public bool MoveNext()
		{
			if (!hasCompleted && FetchCurrent())
			{
				PrefetchNext();
				return true;
			}
			hasCompleted = true;
			return false;
		}

		private bool FetchCurrent()
		{
			if (hasNext && !HasReachedMaxItems)
			{
				Current = next;
				Index++;
				return true;
			}
			if (enumerator.MoveNext() && !HasReachedMaxItems)
			{
				Current = enumerator.Current;
				Index++;
				return true;
			}
			hasCompleted = true;
			return false;
		}

		private void PrefetchNext()
		{
			if (enumerator.MoveNext())
			{
				next = enumerator.Current;
				hasNext = true;
			}
			else
			{
				next = default(T);
				hasNext = false;
			}
		}

		public void Dispose()
		{
			enumerator.Dispose();
		}
	}
}
