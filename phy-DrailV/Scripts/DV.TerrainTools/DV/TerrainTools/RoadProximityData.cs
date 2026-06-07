using UnityEngine;

namespace DV.TerrainTools
{
	public struct RoadProximityData
	{
		public Vector3 queriedFor;

		public Point closest;

		public Point secondClosest;

		public float distToLine;

		public bool isPastEnd;

		public int insertIndex;

		public RoadProximityData(Vector3 queriedFor, Point closest, Point secondClosest, float distToLine, bool isPastEnd, int insertIndex)
		{
			this.queriedFor = queriedFor;
			this.closest = closest;
			this.secondClosest = secondClosest;
			this.distToLine = distToLine;
			this.isPastEnd = isPastEnd;
			this.insertIndex = insertIndex;
		}
	}
}
