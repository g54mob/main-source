using System;
using System.Collections;
using System.Collections.Generic;

namespace Castle.DynamicProxy.Generators
{
	public class TypeElementCollection<TElement> : ICollection<TElement>, IEnumerable<TElement>, IEnumerable where TElement : MetaTypeElement, IEquatable<TElement>
	{
		private readonly ICollection<TElement> items = new List<TElement>();

		public int Count => items.Count;

		bool ICollection<TElement>.IsReadOnly => false;

		public void Add(TElement item)
		{
			if (!item.CanBeImplementedExplicitly)
			{
				items.Add(item);
				return;
			}
			if (Contains(item))
			{
				item.SwitchToExplicitImplementation();
				if (Contains(item))
				{
					throw new ProxyGenerationException("Duplicate element: " + item);
				}
			}
			items.Add(item);
		}

		public bool Contains(TElement item)
		{
			foreach (TElement item2 in items)
			{
				if (item2.Equals(item))
				{
					return true;
				}
			}
			return false;
		}

		public IEnumerator<TElement> GetEnumerator()
		{
			return items.GetEnumerator();
		}

		void ICollection<TElement>.Clear()
		{
			throw new NotSupportedException();
		}

		void ICollection<TElement>.CopyTo(TElement[] array, int arrayIndex)
		{
			throw new NotSupportedException();
		}

		bool ICollection<TElement>.Remove(TElement item)
		{
			throw new NotSupportedException();
		}

		IEnumerator IEnumerable.GetEnumerator()
		{
			return GetEnumerator();
		}
	}
}
