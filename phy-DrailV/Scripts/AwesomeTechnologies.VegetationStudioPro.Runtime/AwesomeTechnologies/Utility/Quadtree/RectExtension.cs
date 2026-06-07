using UnityEngine;

namespace AwesomeTechnologies.Utility.Quadtree
{
	public static class RectExtension
	{
		public static bool Contains(this Rect self, Rect rect)
		{
			if (self.Contains(new Vector2(rect.xMin, rect.yMin)))
			{
				return self.Contains(new Vector2(rect.xMax, rect.yMax));
			}
			return false;
		}

		public static void FromBounds(this Rect self, Bounds bounds)
		{
			self.xMin = bounds.center.x - bounds.extents.x;
			self.yMin = bounds.center.z - bounds.extents.z;
			self.width = bounds.size.x;
			self.height = bounds.size.z;
		}

		public static Rect CreateRectFromBounds(Bounds bounds)
		{
			return new Rect(bounds.center.x - bounds.extents.x, bounds.center.z - bounds.extents.z, bounds.size.x, bounds.size.z);
		}

		public static Bounds CreateBoundsFromRect(Rect rect)
		{
			return new Bounds(size: new Vector3(rect.size.x, 0f, rect.size.y), center: new Vector3(rect.center.x, 0f, rect.center.y));
		}

		public static Bounds CreateBoundsFromRect(Rect rect, float centerY)
		{
			return new Bounds(size: new Vector3(rect.size.x, 0f, rect.size.y), center: new Vector3(rect.center.x, centerY, rect.center.y));
		}

		public static Bounds CreateBoundsFromRect(Rect rect, float centerY, float sizeY)
		{
			return new Bounds(size: new Vector3(rect.size.x, sizeY, rect.size.y), center: new Vector3(rect.center.x, centerY, rect.center.y));
		}
	}
}
