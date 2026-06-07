using UnityEngine;

namespace AwesomeTechnologies.Utility
{
	public struct LineSegment3D
	{
		public Vector3 Point0;

		public Vector3 Point1;

		public Vector3 Center;

		public Vector3 Direction;

		public float Extent;

		public LineSegment3D(Vector3 point0, Vector3 point1)
		{
			Point0 = point0;
			Point1 = point1;
			Center = (Direction = Vector3.zero);
			Extent = 0f;
			CalcDir();
		}

		public void CalcDir()
		{
			Center = 0.5f * (Point0 + Point1);
			Direction = Point1 - Point0;
			float magnitude = Direction.magnitude;
			float num = 1f / magnitude;
			Direction *= num;
			Extent = 0.5f * magnitude;
		}

		public float DistanceTo(Vector3 point)
		{
			return Mathf.Sqrt(SqrPoint3Segment3(ref point, ref this));
		}

		public static float SqrPoint3Segment3(ref Vector3 point, ref LineSegment3D segment)
		{
			Vector3 rhs = point - segment.Center;
			float num = Vector3.Dot(segment.Direction, rhs);
			Vector3 vector = ((!(0f - segment.Extent < num)) ? segment.Point0 : ((!(num < segment.Extent)) ? segment.Point1 : (segment.Center + num * segment.Direction)));
			return (vector - point).sqrMagnitude;
		}
	}
}
