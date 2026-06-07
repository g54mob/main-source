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

		public Vector3 leftPosition;

		public Vector3 rightPosition;

		public Vector3 dir;

		public ERVSData(Vector3 node, bool active, float width, Vector3 leftPosition, Vector3 rightPosition)
		{
			position = node;
			this.active = active;
			this.width = width;
			this.leftPosition = leftPosition;
			this.rightPosition = rightPosition;
			dir = (rightPosition - leftPosition).normalized;
		}
	}
}
