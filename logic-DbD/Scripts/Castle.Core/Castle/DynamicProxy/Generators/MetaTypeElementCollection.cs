using System;
using System.Collections;
using System.Collections.Generic;

namespace Castle.DynamicProxy.Generators
{
	internal class MetaTypeElementCollection<TElement> : IEnumerable<TElement>, IEnumerable where TElement : MetaTypeElement, IEquatable<TElement>
	{
		private readonly ICollection<TElement> items = new List<TElement>();

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
					throw new DynamicProxyException("Duplicate element: " + item);
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

		IEnumerator IEnumerable.GetEnumerator()
		{
			return GetEnumerator();
		}
	}
}
