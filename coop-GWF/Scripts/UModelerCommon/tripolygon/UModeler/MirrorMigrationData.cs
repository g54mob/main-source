using System;
using UnityEngine;

namespace tripolygon.UModeler
{
	[Serializable]
	public class MirrorMigrationData
	{
		public Vector3 normal;

		public float distance;

		public MirrorMigrationData(MirrorMode mirrorMode)
		{
			normal = mirrorMode.plane.normal;
			distance = mirrorMode.plane.distance;
		}
	}
}
