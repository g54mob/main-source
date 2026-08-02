using System;
using System.Collections.Generic;
using UnityEngine;

namespace PWCommon5
{
	[Serializable]
	public class DropStack<T> : ISerializationCallbackReceiver
	{
		[NonSerialized]
		protected T[] m_items;

		[SerializeField]
		protected int m_topIndex = 0;

		[SerializeField]
		protected int m_count = 0;

		[SerializeField]
		protected bool _nullableType = false;

		[SerializeField]
		private int _capacity = 0;

		[SerializeField]
		private T[] _activeItems;

		public int Capacity => m_items.Length;

		public int Count => m_count;

		private DropStack()
		{
			if (default(T) == null)
			{
				_nullableType = true;
			}
		}

		public DropStack(int capacity)
			: this()
		{
			m_items = new T[capacity];
			m_count = 0;
		}

		public DropStack(int capacity, List<T> items)
			: this()
		{
			m_items = new T[capacity];
			m_count = Mathf.Clamp(items.Count, 0, capacity);
			for (int num = m_count - 1; num >= 0; num--)
			{
				m_items[m_topIndex] = items[num];
				m_topIndex = (m_topIndex + 1) % m_items.Length;
			}
		}

		public DropStack(int capacity, T[] items)
			: this()
		{
			m_items = new T[capacity];
			m_count = Mathf.Clamp(items.Length, 0, capacity);
			for (int num = m_count - 1; num >= 0; num--)
			{
				m_items[m_topIndex] = items[num];
				m_topIndex = (m_topIndex + 1) % m_items.Length;
			}
		}

		public void Push(T item)
		{
			m_items[m_topIndex] = item;
			m_topIndex = (m_topIndex + 1) % m_items.Length;
			m_count = ((m_count < m_items.Length) ? (m_count + 1) : m_items.Length);
		}

		public void Push(IEnumerable<T> items)
		{
			foreach (T item in items)
			{
				Push(item);
			}
		}

		public T Pop()
		{
			m_topIndex = (m_items.Length + m_topIndex - 1) % m_items.Length;
			m_count = ((m_count >= 2) ? (m_count - 1) : 0);
			T result = m_items[m_topIndex];
			m_items[m_topIndex] = default(T);
			return result;
		}

		public T Peek()
		{
			return m_items[(m_items.Length + m_topIndex - 1) % m_items.Length];
		}

		public List<T> ToList()
		{
			List<T> list = new List<T>();
			int num = m_topIndex;
			int num2 = m_count;
			while (num2 > 0)
			{
				num = (m_items.Length + num - 1) % m_items.Length;
				num2 = ((num2 >= 2) ? (num2 - 1) : 0);
				list.Add(m_items[num]);
			}
			return list;
		}

		public T[] ToArray()
		{
			T[] array = new T[m_count];
			int num = m_topIndex;
			for (int i = 0; i < m_count; i++)
			{
				num = (m_items.Length + num - 1) % m_items.Length;
				array[i] = m_items[num];
			}
			return array;
		}

		public void OnBeforeSerialize()
		{
			if (!_nullableType)
			{
				_activeItems = m_items;
				return;
			}
			_capacity = Capacity;
			_activeItems = ToArray();
		}

		public void OnAfterDeserialize()
		{
			if (!_nullableType)
			{
				m_items = _activeItems;
				return;
			}
			m_items = new T[_capacity];
			for (int i = 0; i < m_count; i++)
			{
				m_items[i] = _activeItems[i];
			}
			m_topIndex = m_count;
		}
	}
}
