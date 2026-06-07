using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;

namespace ZLinq.Linq
{
	[DebuggerDisplay("Key = {Key}")]
	[DebuggerTypeProxy(typeof(GroupingDebugView<, >))]
	internal sealed class Grouping<TKey, TElement> : IGrouping<TKey, TElement>, IEnumerable<TElement>, IEnumerable, IList<TElement>, ICollection<TElement>, IReadOnlyList<TElement>, IReadOnlyCollection<TElement>
	{
		private TKey key;

		private uint hashCode;

		private TElement[] elements;

		private int count;

		public Grouping<TKey, TElement>? NextGroupInAddOrder;

		public Grouping<TKey, TElement>? NextGroupInSameHashCode;

		public TKey Key => key;

		public uint HashCode => hashCode;

		public int Count => count;

		public bool IsReadOnly => true;

		public TElement this[int index]
		{
			get
			{
				return elements.AsSpan(0, count)[index];
			}
			set
			{
				throw new NotSupportedException();
			}
		}

		public Grouping(TKey key, uint hashCode, TElement value)
		{
			this.key = key;
			this.hashCode = hashCode;
			elements = new TElement[1] { value };
			count = 1;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public void Add(TElement value)
		{
			if (elements.Length == count)
			{
				Array.Resize(ref elements, checked(count * 2));
			}
			elements[count] = value;
			count++;
		}

		IEnumerator IEnumerable.GetEnumerator()
		{
			return GetEnumerator();
		}

		public IEnumerator<TElement> GetEnumerator()
		{
			for (int i = 0; i < count; i++)
			{
				yield return elements[i];
			}
		}

		public int IndexOf(TElement item)
		{
			return Array.IndexOf<TElement>(elements, item, 0, count);
		}

		public void Insert(int index, TElement item)
		{
			throw new NotSupportedException();
		}

		public void RemoveAt(int index)
		{
			throw new NotSupportedException();
		}

		void ICollection<TElement>.Add(TElement item)
		{
			throw new NotSupportedException();
		}

		public void Clear()
		{
			throw new NotSupportedException();
		}

		public bool Contains(TElement item)
		{
			return elements.Contains<TElement>(item);
		}

		public void CopyTo(TElement[] array, int arrayIndex)
		{
			elements.AsSpan(0, count).CopyTo(array.AsSpan(arrayIndex));
		}

		public bool Remove(TElement item)
		{
			throw new NotSupportedException();
		}
	}
}
