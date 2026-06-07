using UnityEngine;

namespace AwesomeTechnologies.Utility
{
	public struct LineSegment2D
	{
		public Vector2 Point0;

		public Vector2 Point1;

		public Vector2 Center;

		public Vector2 Direction;

		public readonly float Extent;

		public int DisableEdge;

		public LineSegment2D(Vector2 point0, Vector2 point1)
		{
			Point0 = point0;
			Point1 = point1;
			Center = 0.5f * (Point0 + Point1);
			Direction = Point1 - Point0;
			float magnitude = Direction.magnitude;
			float num = 1f / magnitude;
			Direction *= num;
			Extent = 0.5f * magnitude;
			DisableEdge = 0;
		}
	}
}
