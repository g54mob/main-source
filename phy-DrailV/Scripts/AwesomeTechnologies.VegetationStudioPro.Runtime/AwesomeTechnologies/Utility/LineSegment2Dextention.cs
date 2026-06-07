using Unity.Mathematics;
using UnityEngine;

namespace AwesomeTechnologies.Utility
{
	public static class LineSegment2Dextention
	{
		public static float DistanceToPoint(this LineSegment2D lineSegment, Vector2 point)
		{
			return Mathf.Sqrt(SqrDistanceToPoint(point, lineSegment));
		}

		public static float SqrDistanceToPoint(Vector2 point, LineSegment2D segment)
		{
			Vector2 vector = point - segment.Center;
			float num = math.dot(segment.Direction, vector);
			Vector2 vector2 = ((!(0f - segment.Extent < num)) ? segment.Point0 : ((!(num < segment.Extent)) ? segment.Point1 : (segment.Center + num * segment.Direction)));
			return (vector2 - point).sqrMagnitude;
		}
	}
}
