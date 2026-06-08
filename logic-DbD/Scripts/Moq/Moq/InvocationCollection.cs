using System;
using System.Collections;
using System.Collections.Generic;

namespace Moq
{
	internal sealed class InvocationCollection : IInvocationList, IReadOnlyList<IInvocation>, IEnumerable<IInvocation>, IEnumerable, IReadOnlyCollection<IInvocation>
	{
		private Invocation[] invocations;

		private int capacity;

		private int count;

		private readonly object invocationsLock = new object();

		private readonly Mock owner;

		public int Count
		{
			get
			{
				lock (invocationsLock)
				{
					return count;
				}
			}
		}

		public IInvocation this[int index]
		{
			get
			{
				lock (invocationsLock)
				{
					if (count <= index || index < 0)
					{
						throw new IndexOutOfRangeException();
					}
					return invocations[index];
				}
			}
		}

		public InvocationCollection(Mock owner)
		{
			this.owner = owner;
		}

		public void Add(Invocation invocation)
		{
			lock (invocationsLock)
			{
				if (count == capacity)
				{
					int newSize = ((capacity == 0) ? 4 : (capacity * 2));
					Array.Resize(ref invocations, newSize);
					capacity = newSize;
				}
				invocations[count] = invocation;
				count++;
			}
		}

		public void Clear()
		{
			lock (invocationsLock)
			{
				invocations = null;
				count = 0;
				capacity = 0;
				owner.MutableSetups.Reset();
			}
		}

		public Invocation[] ToArray()
		{
			lock (invocationsLock)
			{
				if (count == 0)
				{
					return new Invocation[0];
				}
				Invocation[] array = new Invocation[count];
				Array.Copy(invocations, array, count);
				return array;
			}
		}

		public Invocation[] ToArray(Func<Invocation, bool> predicate)
		{
			lock (invocationsLock)
			{
				if (count == 0)
				{
					return new Invocation[0];
				}
				List<Invocation> list = new List<Invocation>(count);
				for (int i = 0; i < count; i++)
				{
					Invocation invocation = invocations[i];
					if (predicate(invocation))
					{
						list.Add(invocation);
					}
				}
				return list.ToArray();
			}
		}

		public IEnumerator<IInvocation> GetEnumerator()
		{
			Invocation[] collection;
			int count;
			lock (invocationsLock)
			{
				collection = invocations;
				count = this.count;
			}
			for (int i = 0; i < count; i++)
			{
				yield return collection[i];
			}
		}

		IEnumerator IEnumerable.GetEnumerator()
		{
			return GetEnumerator();
		}
	}
}
