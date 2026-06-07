using System;
using UnityEngine;

namespace EasyRoads3Dv3
{
	[Serializable]
	public class ERDecalClass
	{
		public int id = 0;

		public string name = "";

		public double roadType1 = 0.0;

		public double roadType2 = 0.0;

		public int connection = 0;

		public GameObject decalPrefab;

		public float baseWidth = 6f;

		public float meshWidth = 0f;

		public float scale = 1f;

		public Vector3 localScale = new Vector3(1f, 1f, 1f);

		public int priority = 0;

		public bool collapsed = false;

		public float heightOffset = 0f;

		public static void CopyDecal(ERDecal source, ERDecalClass target)
		{
			target.id = source.id;
			target.name = source.name;
			target.roadType1 = source.roadType1;
			target.roadType2 = source.roadType2;
			target.connection = source.connection;
			target.decalPrefab = source.decalPrefab;
			target.baseWidth = source.baseWidth;
			target.meshWidth = source.meshWidth;
			target.scale = source.scale;
			target.localScale = source.localScale;
			target.priority = source.priority;
			target.collapsed = source.collapsed;
			target.heightOffset = source.heightOffset;
		}
	}
}
