using UnityEngine;

namespace DV.TerrainTools
{
	public class BezierPointData
	{
		public Vector3 pos;

		public Vector3 h1;

		public Vector3 h2;

		public float distanceFromStart;

		public float lerpFactor;

		public int originalPointIndex;

		public BezierPointData(Vector3 pos, Vector3 h1, Vector3 h2)
		{
			this.pos = pos;
			this.h1 = h1;
			this.h2 = h2;
		}
	}
}
