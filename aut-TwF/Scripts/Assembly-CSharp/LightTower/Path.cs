using System;
using System.Collections.Generic;
using UnityEngine;

namespace LightTower
{
	[Serializable]
	public class Path : ISavable
	{
		[SerializeField]
		[Savable("positions", true, false)]
		public Vector3[] positions;

		[Savable("distanceToPosition", true, false)]
		public float[] distanceToPosition;

		public void OnSave()
		{
		}

		public void OnPreLoad()
		{
		}

		public void OnLoad(Dictionary<string, object> data, bool hasLoadedSomething)
		{
		}
	}
}
