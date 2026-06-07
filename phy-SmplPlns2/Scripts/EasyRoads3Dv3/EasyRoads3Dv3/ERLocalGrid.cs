using System;
using System.Collections.Generic;
using UnityEngine;

namespace EasyRoads3Dv3
{
	[Serializable]
	public class ERLocalGrid : ScriptableObject
	{
		public int id = 0;

		public new string name;

		public bool gridActive = false;

		public bool gridGUIActive = false;

		public Color gridColor = new Color(0.35f, 0.5f, 0.9f, 0.9f);

		public float gridSize = 50f;

		public float gridRadius = 500f;

		public float gridRotation = 0f;

		public Vector3 tl;

		public Vector3 bl;

		public Vector3 br;

		public float xOffset = 0f;

		public float yOffset = 0f;

		public Vector3 OCCQQOCQDQ;

		public void Init(ERModularBase scr)
		{
			int minInclusive = 1;
			int maxExclusive = 999999999;
			id = UnityEngine.Random.Range(minInclusive, maxExclusive);
			name = "Local Grid " + (scr.localGrids.Count + 1);
		}

		public static ERLocalGrid CreateInstance(ERModularBase scr)
		{
			ERLocalGrid eRLocalGrid = ScriptableObject.CreateInstance<ERLocalGrid>();
			eRLocalGrid.Init(scr);
			return eRLocalGrid;
		}

		public static string[] GridNames(ERModularBase scr)
		{
			List<string> list = new List<string>();
			int num = 1;
			foreach (ERLocalGrid localGrid in scr.localGrids)
			{
				if (localGrid != null)
				{
					list.Add(num + ". " + localGrid.name);
					num++;
				}
			}
			if (list.Count == 0)
			{
				list.Add("No Local Grids available");
			}
			return list.ToArray();
		}

		public void SetOffsets(ERModularBase scr, Vector3 pos, Vector3 v)
		{
			xOffset = 0f;
			yOffset = 0f;
			xOffset = pos.x - v.x;
			yOffset = pos.z - v.z;
			OCCQQOCQDQ = pos;
		}
	}
}
