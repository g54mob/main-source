using System;
using UnityEngine;

namespace EasyRoads3Dv3
{
	[Serializable]
	public struct ERVSData
	{
		public Vector3 position;

		public bool active;

		public float width;

		public ERVSData(Vector3 node, bool active, float width)
		{
			position = node;
			this.active = active;
			this.width = width;
		}
	}
}
