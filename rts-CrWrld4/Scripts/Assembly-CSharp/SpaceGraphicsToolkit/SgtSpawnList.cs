using System.Collections.Generic;
using UnityEngine;

namespace SpaceGraphicsToolkit
{
	[ExecuteInEditMode]
	public class SgtSpawnList : SgtLinkedBehaviour<SgtSpawnList>
	{
		public string Category;

		public List<SgtFloatingSpawnable> Prefabs;

		public static SgtSpawnList Create(int layer = 0, Transform parent = null)
		{
			return null;
		}

		public static SgtSpawnList Create(int layer, Transform parent, Vector3 localPosition, Quaternion localRotation, Vector3 localScale)
		{
			return null;
		}
	}
}
