using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Helpers
{
	[Serializable]
	public class ShuffleBag<T> : IList<T>, ICollection<T>, IEnumerable<T>, IEnumerable
	{
		[SerializeField]
		private List<T> data = new List<T>();

		[SerializeField]
		private int cursor;

		public T this[int index]
		{
			get
			{
				return data[index];
			}
			set
			{
				data[index] = value;
			}
		}

		public int Count => data.Count;

		public bool IsReadOnly => false;

		public T Next()
		{
			if (cursor < 1)
			{
				ResetBag();
				if (data.Count >= 1)
				{
					return data[0];
				}
				return default(T);
			}
			int index = Mathf.FloorToInt(UnityEngine.Random.value * (float)(cursor + 1));
			T val = data[index];
			data[index] = data[cursor];
			data[cursor] = val;
			cursor--;
			return val;
		}

		public void ResetBag()
		{
			cursor = data.Count - 1;
		}

		public ShuffleBag()
		{
		}

		public ShuffleBag(int capacity)
		{
			data.Capacity = capacity;
		}

		public ShuffleBag(T[] initialValues)
		{
			AddRange(initialValues);
		}

		public void AddRange(T[] values)
		{
			for (int i = 0; i < values.Length; i++)
			{
				Add(values[i]);
			}
		}

		public void AddRange(IEnumerable<T> values)
		{
			data.AddRange(values);
			ResetBag();
		}

		public int IndexOf(T item)
		{
			return data.IndexOf(item);
		}

		public void Insert(int index, T item)
		{
			cursor = data.Count;
			data.Insert(index, item);
		}

		public void RemoveAt(int index)
		{
			cursor = data.Count - 2;
			data.RemoveAt(index);
		}

		IEnumerator<T> IEnumerable<T>.GetEnumerator()
		{
			return data.GetEnumerator();
		}

		public void Add(T item)
		{
			data.Add(item);
			ResetBag();
		}

		public void Clear()
		{
			data.Clear();
			ResetBag();
		}

		public bool Contains(T item)
		{
			return data.Contains(item);
		}

		public void CopyTo(T[] array, int arrayIndex)
		{
			foreach (T datum in data)
			{
				array.SetValue(datum, arrayIndex);
				arrayIndex++;
			}
		}

		public bool Remove(T item)
		{
			bool num = data.Remove(item);
			if (num)
			{
				ResetBag();
			}
			return num;
		}

		IEnumerator IEnumerable.GetEnumerator()
		{
			return data.GetEnumerator();
		}
	}
}
