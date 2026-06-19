using System;
using UnityEngine;

namespace WorldGen
{
	[Serializable]
	public class IslandPrefabEntry
	{
		public GameObject prefab;

		[Range(0f, 1f)]
		public float weight = 1f;
	}
}
