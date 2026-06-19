using System;
using System.Collections.Generic;

namespace TH20
{
	public class DisjointSetOfInts
	{
		private class IntEqualityComparer : IEqualityComparer<int>
		{
			public bool Equals(int x, int y)
			{
				return x == y;
			}

			public int GetHashCode(int obj)
			{
				return obj.GetHashCode();
			}
		}

		private static readonly IntEqualityComparer IntEqualityComparerInstance = new IntEqualityComparer();

		private Dictionary<int, int> _map = new Dictionary<int, int>(IntEqualityComparerInstance);

		private Dictionary<int, int> _rank = new Dictionary<int, int>(IntEqualityComparerInstance);

		public void MakeSet(int value)
		{
			if (_map.ContainsKey(value))
			{
				throw new Exception("Set has already been made");
			}
			_map[value] = value;
			_rank[value] = 0;
		}

		public int Find(int value)
		{
			if (!_map.ContainsKey(value))
			{
				throw new Exception("Value not present in any set");
			}
			int num = FindRoot(value);
			_map[value] = num;
			return num;
		}

		private int FindRoot(int value)
		{
			if (_map[value] != value)
			{
				return Find(_map[value]);
			}
			return value;
		}

		public void Union(int set1, int set2)
		{
			if (set1 == set2)
			{
				return;
			}
			if (!_map.ContainsKey(set1) || !_map.ContainsKey(set2))
			{
				throw new Exception("One or both of the 2 supplied sets are not present");
			}
			int num = Find(set1);
			int num2 = Find(set2);
			if (num != num2)
			{
				if (_rank[num] > _rank[num2])
				{
					_map[num2] = num;
					return;
				}
				if (_rank[num2] > _rank[num])
				{
					_map[num] = num2;
					return;
				}
				_map[num] = num2;
				_rank[num2]++;
			}
		}
	}
}
