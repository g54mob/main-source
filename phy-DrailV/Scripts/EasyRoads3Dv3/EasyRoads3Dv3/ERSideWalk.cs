using System;
using System.Collections.Generic;
using UnityEngine;

namespace EasyRoads3Dv3
{
	[Serializable]
	public class ERSideWalk : ScriptableObject
	{
		public new string name = "";

		public double id;

		public double timestamp;

		public float sidewalkWidth = 1.5f;

		public float curbHeight = 0.25f;

		public float curbDepth = 0.25f;

		public bool beveledCurb = false;

		public float beveledHeight = 0f;

		public float beveledDepth = 0f;

		public bool outerCurb = false;

		public bool roadSideCurbUVControl = false;

		public bool outerSideCurbUVControl = false;

		public Material material;

		public bool hardEdges = false;

		public List<Vector2> shape = new List<Vector2>();

		public List<float> sidewalkUVs = new List<float>();

		public List<float> curbUVs = new List<float>();

		public Rect tileRect = default(Rect);

		public float tileSize = 0f;

		public float minEnd = 1f;

		public float maxEnd = 1f;

		public bool lockUVs = false;

		public static ERSideWalk CreateInstance(int count)
		{
			ERSideWalk eRSideWalk = ScriptableObject.CreateInstance<ERSideWalk>();
			eRSideWalk.name = "Sidewalk " + count;
			eRSideWalk.timestamp = DateTime.UtcNow.Subtract(new DateTime(1970, 1, 1)).TotalSeconds;
			eRSideWalk.id = eRSideWalk.timestamp;
			return eRSideWalk;
		}

		public void UpdateTimestamp()
		{
			timestamp = DateTime.UtcNow.Subtract(new DateTime(1970, 1, 1)).TotalSeconds;
		}

		public static string[] SidewalkNames(List<ERSideWalk> sidewalks)
		{
			List<string> list = new List<string>();
			if (sidewalks.Count > 0)
			{
				list.Add("Select Sidewalk");
				int num = 1;
				for (int i = 0; i < sidewalks.Count; i++)
				{
					list.Add(num + ".  " + sidewalks[i].name);
					num++;
				}
			}
			else
			{
				list.Add("No Sidewalks Available");
			}
			return list.ToArray();
		}
	}
}
