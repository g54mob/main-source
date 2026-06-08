using System.Collections.Generic;
using UnityEngine;

namespace LaundryBear.Math
{
	public abstract class StatisticalQueue<T>
	{
		private int m_capacity;

		protected List<T> m_list;

		public int Count { get; private set; }

		public StatisticalQueue(int capacity)
		{
			m_capacity = capacity;
			Count = 0;
			m_list = new List<T>(m_capacity);
		}

		public StatisticalQueue(int capacity, IEnumerable<T> startingValues)
		{
			m_capacity = capacity;
			List<T> list = new List<T>(startingValues);
			m_list = list.GetRange(Mathf.Max(0, list.Count - m_capacity), Mathf.Min(list.Count, m_capacity));
			Count = m_list.Count;
		}

		public void AddValue(T item)
		{
			m_list.Add(item);
			if (Count < m_capacity)
			{
				int count = Count + 1;
				Count = count;
			}
			else
			{
				m_list.RemoveAt(0);
			}
		}

		public void Reset()
		{
			m_list.Clear();
		}

		public bool IsEmpty()
		{
			return m_list.Count == 0;
		}

		public T GetMostRecent()
		{
			return m_list[m_list.Count - 1];
		}

		public abstract T GetMax();

		public abstract T GetMin();

		public abstract T GetAverage();

		public abstract T GetInstantPartialDerivative();

		public abstract T GetAveragePartialDerivative();
	}
}
