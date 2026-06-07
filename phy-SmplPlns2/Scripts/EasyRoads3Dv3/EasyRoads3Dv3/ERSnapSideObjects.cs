using System;
using System.Collections.Generic;
using UnityEngine;

namespace EasyRoads3Dv3
{
	[Serializable]
	public class ERSnapSideObjects
	{
		public ERCrossingPrefabs instance;

		public int el1;

		public int el2;

		public ERSORoadExt soData1;

		public ERSORoadExt soData2;

		public List<int> ints1;

		public List<int> ints2;

		public Mesh mesh1;

		public Mesh mesh2;

		public int side1;

		public int side2;

		public GameObject road1;

		public GameObject road2;

		public ERSnapSideObjects(ERCrossingPrefabs _instance, int _el1, int _el2, ERSORoadExt _soData1, ERSORoadExt _soData2, Mesh _mesh1, Mesh _mesh2, List<int> _ints1, List<int> _ints2, int _side)
		{
			instance = _instance;
			el1 = _el1;
			el2 = _el2;
			soData1 = _soData1;
			soData2 = _soData2;
			mesh1 = _mesh1;
			mesh2 = _mesh2;
			ints1 = _ints1;
			ints2 = _ints2;
			side1 = _side;
			if (_side == 0)
			{
				side2 = 1;
			}
			else
			{
				side2 = 0;
			}
		}

		public static ERSnapSideObjects ERGetSnapObject(List<ERSnapSideObjects> lst, ERSORoadExt soData, ERCrossingPrefabs _instance, int el, int side)
		{
			int num = 0;
			if (side == 0)
			{
				num = 1;
			}
			foreach (ERSnapSideObjects item in lst)
			{
				if (_instance == item.instance && item.el2 == el && num == item.side1 && ((soData == item.soData1 && el == item.el1) || (soData == item.soData2 && el == item.el2)))
				{
					return item;
				}
			}
			return null;
		}

		public void ERSetIndexes(ERSORoadExt soData, List<int> indexes)
		{
			if (soData1 == soData && ints1.Count == 0)
			{
				ints1 = indexes;
			}
			else if (soData2 == soData)
			{
				ints2 = indexes;
			}
		}

		public void ERSetMesh(ERSORoadExt soData, Mesh mesh, ERModularRoad road)
		{
			if (soData1 == soData && mesh1 == null)
			{
				mesh1 = mesh;
				road1 = road.gameObject;
			}
			if (soData2 == soData)
			{
				mesh2 = mesh;
				road2 = road.gameObject;
			}
		}
	}
}
