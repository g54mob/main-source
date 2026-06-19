using System;
using System.Collections.Generic;

namespace TH20
{
	public class WeightedList<T>
	{
		private int _cumulativeFrequency;

		private readonly Dictionary<T, int> _list = new Dictionary<T, int>();

		public Dictionary<T, int> List => _list;

		public void Add(T item, int weight)
		{
			_list.Add(item, weight);
			_cumulativeFrequency += weight;
		}

		public bool Remove(T item)
		{
			if (_list.ContainsKey(item))
			{
				_cumulativeFrequency -= _list[item];
				_list.Remove(item);
				return true;
			}
			return false;
		}

		public bool Contains(T item)
		{
			return _list.ContainsKey(item);
		}

		public T Choose(T defaultValue, Random random)
		{
			if (_list.Count != 0)
			{
				int num = 0;
				int num2 = random.Next(0, _cumulativeFrequency + 1);
				foreach (KeyValuePair<T, int> item in _list)
				{
					num += item.Value;
					if (num >= num2)
					{
						return item.Key;
					}
				}
			}
			return defaultValue;
		}
	}
}
