using System;
using UnityEngine;

namespace Gh.Tk
{
	[Serializable]
	public class SpawnObject
	{
		public GameObject objectPrefab;

		public Vector3 position;

		public Vector3 rotation;

		public string parentName;
	}
}
