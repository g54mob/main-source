using System.Collections.Generic;

namespace Aggro.Core
{
	public struct EntityBuffer<T> where T : struct, IBufferItem
	{
		internal List<T> Items;

		public int Count => Items.Count;

		public T this[int index]
		{
			get
			{
				return Items[index];
			}
			set
			{
				Items[index] = value;
			}
		}

		public void Add(T item)
		{
			Items.Add(item);
		}

		public void Clear()
		{
			Items.Clear();
		}
	}
}
