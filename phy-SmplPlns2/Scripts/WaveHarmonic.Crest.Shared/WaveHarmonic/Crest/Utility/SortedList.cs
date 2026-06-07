using System;
using System.Collections;
using System.Collections.Generic;

namespace WaveHarmonic.Crest.Utility
{
	internal sealed class SortedList<TKey, TValue> : IEnumerable<KeyValuePair<TKey, TValue>>, IEnumerable
	{
		private readonly List<KeyValuePair<TKey, TValue>> _BackingList = new List<KeyValuePair<TKey, TValue>>();

		private readonly Comparison<TKey> _Comparison;

		private bool _NeedsSorting;

		public int Count => _BackingList.Count;

		private int Comparison(KeyValuePair<TKey, TValue> x, KeyValuePair<TKey, TValue> y)
		{
			return _Comparison(x.Key, y.Key);
		}

		public SortedList(Comparison<TKey> comparison)
		{
			_Comparison = comparison;
		}

		public void Add(TKey key, TValue value)
		{
			_BackingList.Add(new KeyValuePair<TKey, TValue>(key, value));
			_NeedsSorting = true;
		}

		public bool Contains(TValue value)
		{
			foreach (KeyValuePair<TKey, TValue> backing in _BackingList)
			{
				if (backing.Value.Equals(value))
				{
					return true;
				}
			}
			return false;
		}

		public bool Remove(TValue value)
		{
			int num = -1;
			int num2 = 0;
			foreach (KeyValuePair<TKey, TValue> backing in _BackingList)
			{
				if (backing.Value.Equals(value))
				{
					num = num2;
				}
				num2++;
			}
			if (num > -1)
			{
				_BackingList.RemoveAt(num);
			}
			return num > -1;
		}

		public void Clear()
		{
			_BackingList.Clear();
			_NeedsSorting = false;
		}

		public List<KeyValuePair<TKey, TValue>>.Enumerator GetEnumerator()
		{
			ResortArrays();
			return _BackingList.GetEnumerator();
		}

		IEnumerator<KeyValuePair<TKey, TValue>> IEnumerable<KeyValuePair<TKey, TValue>>.GetEnumerator()
		{
			return GetEnumerator();
		}

		IEnumerator IEnumerable.GetEnumerator()
		{
			return GetEnumerator();
		}

		private void ResortArrays()
		{
			if (_NeedsSorting)
			{
				_BackingList.Sort(Comparison);
			}
			_NeedsSorting = false;
		}
	}
}
