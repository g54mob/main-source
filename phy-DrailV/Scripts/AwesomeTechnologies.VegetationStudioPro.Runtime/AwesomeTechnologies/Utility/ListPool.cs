using System;
using System.Collections.Generic;

namespace AwesomeTechnologies.Utility
{
	[Serializable]
	public class ListPool<T>
	{
		public List<List<T>> PoolList = new List<List<T>>();

		public int MaxCapasity;

		public int CreateCount;

		private List<T> _returnList;

		public ListPool(int poolCount, int capasity)
		{
			CreateCount = 0;
			MaxCapasity = capasity;
			for (int i = 0; i <= poolCount - 1; i++)
			{
				CreateList();
			}
		}

		private void CreateList()
		{
			CreateCount++;
			List<T> item = new List<T>(MaxCapasity);
			PoolList.Add(item);
		}

		public List<T> GetList()
		{
			if (PoolList.Count == 0)
			{
				CreateList();
			}
			_returnList = PoolList[PoolList.Count - 1];
			PoolList.RemoveAt(PoolList.Count - 1);
			return _returnList;
		}

		public void ReturnList(List<T> list)
		{
			if (list.Capacity > MaxCapasity)
			{
				MaxCapasity = list.Capacity;
			}
			list.Clear();
			PoolList.Add(list);
		}
	}
}
