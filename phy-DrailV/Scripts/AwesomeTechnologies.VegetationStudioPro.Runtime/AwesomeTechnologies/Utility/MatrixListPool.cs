using System;
using System.Collections.Generic;
using UnityEngine;

namespace AwesomeTechnologies.Utility
{
	[Serializable]
	public class MatrixListPool
	{
		public List<List<Matrix4x4>> PoolList = new List<List<Matrix4x4>>();

		public int MaxCapasity;

		public int CreateCount;

		private List<Matrix4x4> _returnList;

		public MatrixListPool(int poolCount, int capasity)
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
			List<Matrix4x4> item = new List<Matrix4x4>(MaxCapasity);
			PoolList.Add(item);
		}

		public List<Matrix4x4> GetList()
		{
			if (PoolList.Count == 0)
			{
				CreateList();
			}
			_returnList = PoolList[PoolList.Count - 1];
			PoolList.RemoveAt(PoolList.Count - 1);
			return _returnList;
		}

		public void ReturnList(List<Matrix4x4> list)
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
