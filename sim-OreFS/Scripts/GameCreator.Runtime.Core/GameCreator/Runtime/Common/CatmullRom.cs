using System.Runtime.InteropServices;
using UnityEngine;

namespace GameCreator.Runtime.Common
{
	[StructLayout(LayoutKind.Sequential, Size = 1)]
	public readonly struct CatmullRom
	{
		public static Vector3 Get(float t, Vector3 p0, Vector3 p1, Vector3 p2, Vector3 p3)
		{
			Vector3 vector = 2f * p1;
			Vector3 vector2 = p2 - p0;
			Vector3 vector3 = 2f * p0 - 5f * p1 + 4f * p2 - p3;
			Vector3 vector4 = -p0 + 3f * p1 - 3f * p2 + p3;
			return 0.5f * (vector + vector2 * t + vector3 * t * t + vector4 * t * t * t);
		}

		public static Segment Get(float t, Segment s0, Segment s1, Segment s2, Segment s3)
		{
			Vector3 pointA = Get(t, s0.PointA, s1.PointA, s2.PointA, s3.PointA);
			Vector3 pointB = Get(t, s0.PointB, s1.PointB, s2.PointB, s3.PointB);
			return new Segment(pointA, pointB);
		}
	}
}
