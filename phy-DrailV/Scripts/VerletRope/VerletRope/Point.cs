using System;
using Unity.Mathematics;

namespace VerletRope
{
	[Serializable]
	public struct Point
	{
		public float3 curPos;

		public float3 oldPos;

		public bool pinned;

		public float3 pinLocalPos;

		public float3 localForward;

		public float3 localUp;

		public float addedBendingCorrection;

		public float floorBendingMultiplier;
	}
}
