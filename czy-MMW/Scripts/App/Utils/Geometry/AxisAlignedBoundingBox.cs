using UnityEngine;

namespace Utils.Geometry
{
	public class AxisAlignedBoundingBox
	{
		public Vector2 min;

		public Vector2 max;

		public Vector2 TopLeft => new Vector2(min.x, max.y);

		public Vector2 TopRight => new Vector2(max.x, max.y);

		public Vector2 BottomLeft => new Vector2(min.x, min.y);

		public Vector2 BottomRight => new Vector2(max.x, min.y);

		public AxisAlignedBoundingBox(Vector2 min, Vector2 max)
		{
			this.min = min;
			this.max = max;
		}

		public bool IntersectWithLine(Vector2 start, Vector2 end)
		{
			if (LineIntersection.LineLineIntersection(start, end - start, BottomLeft, BottomRight - BottomLeft).type != LineIntersection.IntersectionInfo.IntersectionType.None)
			{
				return true;
			}
			if (LineIntersection.LineLineIntersection(start, end - start, BottomLeft, TopLeft - BottomLeft).type != LineIntersection.IntersectionInfo.IntersectionType.None)
			{
				return true;
			}
			if (LineIntersection.LineLineIntersection(start, end - start, BottomRight, TopRight - BottomRight).type != LineIntersection.IntersectionInfo.IntersectionType.None)
			{
				return true;
			}
			if (LineIntersection.LineLineIntersection(start, end - start, TopLeft, TopRight - TopLeft).type != LineIntersection.IntersectionInfo.IntersectionType.None)
			{
				return true;
			}
			if (start.x >= min.x && start.x <= max.x && start.y >= min.y && start.y <= max.y)
			{
				if (end.x >= min.x && end.x <= max.x && end.y >= min.y)
				{
					return end.y <= max.y;
				}
				return false;
			}
			return false;
		}
	}
}
