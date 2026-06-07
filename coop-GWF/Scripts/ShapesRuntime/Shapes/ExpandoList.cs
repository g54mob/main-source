using System;
using System.Collections.Generic;

namespace Shapes
{
	public class ExpandoList<T>
	{
		public List<T> list = new List<T>();

		public T this[int i]
		{
			get
			{
				if (i < 0)
				{
					throw new IndexOutOfRangeException();
				}
				if (i >= list.Count)
				{
					return default(T);
				}
				return list[i];
			}
			set
			{
				if (i < 0)
				{
					throw new IndexOutOfRangeException();
				}
				int count = list.Count;
				if (i < count)
				{
					list[i] = value;
					return;
				}
				int num = i - count;
				if (num > 0)
				{
					for (int j = 0; j < num; j++)
					{
						list.Add(default(T));
					}
				}
				list.Add(value);
			}
		}

		public void SetCountToAtLeast(int minCount)
		{
			int count = list.Count;
			if (count < minCount)
			{
				int num = minCount - count;
				for (int i = 0; i < num; i++)
				{
					list.Add(default(T));
				}
			}
		}

		public void Add(T item)
		{
			list.Add(item);
		}

		public void Clear()
		{
			list.Clear();
		}

		public void ClearAndSetMinCapacity(int minCapacity)
		{
			list.Clear();
			if (list.Capacity < minCapacity)
			{
				list.Capacity = minCapacity;
			}
		}
	}
}
