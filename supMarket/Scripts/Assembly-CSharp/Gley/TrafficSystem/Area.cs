using System;
using UnityEngine;

namespace Gley.TrafficSystem
{
	[Serializable]
	public struct Area
	{
		public Vector3 center;

		public float radius;

		[HideInInspector]
		public float sqrRadius;

		public Area(Vector3 center, float radius)
		{
			this.center = default(Vector3);
			this.radius = 0f;
			sqrRadius = 0f;
		}

		public Area(Area area)
		{
			center = default(Vector3);
			radius = 0f;
			sqrRadius = 0f;
		}
	}
}
