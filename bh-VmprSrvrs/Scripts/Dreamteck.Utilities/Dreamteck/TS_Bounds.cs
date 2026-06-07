using System;
using UnityEngine;

namespace Dreamteck
{
	[Serializable]
	public class TS_Bounds
	{
		public Vector3 center;

		public Vector3 extents;

		public Vector3 max;

		public Vector3 min;

		public Vector3 size;

		public TS_Bounds()
		{
		}

		public TS_Bounds(Bounds bounds)
		{
		}

		public TS_Bounds(Vector3 c, Vector3 s)
		{
		}

		public TS_Bounds(Vector3 min, Vector3 max, Vector3 center)
		{
		}

		public void CreateFromMinMax(Vector3 min, Vector3 max)
		{
		}

		public bool Contains(Vector3 point)
		{
			return false;
		}
	}
}
