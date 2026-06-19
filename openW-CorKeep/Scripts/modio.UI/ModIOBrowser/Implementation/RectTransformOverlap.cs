using UnityEngine;

namespace ModIOBrowser.Implementation
{
	public class RectTransformOverlap
	{
		private Vector3[] vectors = new Vector3[4];

		public float xMin => vectors[0].x;

		public float xMax => vectors[2].x;

		public float yMin => vectors[0].y;

		public float yMax => vectors[2].y;

		public float width => xMax - xMin;

		public float height => yMax - yMin;

		public RectTransformOverlap(RectTransform rt)
		{
			rt.GetWorldCorners(vectors);
		}

		public static explicit operator RectTransformOverlap(RectTransform rt)
		{
			return new RectTransformOverlap(rt);
		}

		public static float DistanceFromEdgeY(RectTransformOverlap a, RectTransformOverlap b, float paddingPercentage)
		{
			float num = b.height * paddingPercentage;
			if (a.yMax > b.yMax - num)
			{
				return b.yMax - num - a.yMax;
			}
			if (a.yMin < b.yMin + num)
			{
				return b.yMin + num - a.yMin;
			}
			return 0f;
		}

		public static float DistanceFromEdgeX(RectTransformOverlap a, RectTransformOverlap b, float paddingPercentage)
		{
			float num = b.width * paddingPercentage;
			if (a.xMax > b.xMax - num)
			{
				return b.xMax - num - a.xMax;
			}
			if (a.xMin < b.xMin + num)
			{
				return b.xMin + num - a.xMin;
			}
			return 0f;
		}

		public bool IsOutsideOfRectY(RectTransformOverlap b, float paddingPercentage)
		{
			float num = b.height * paddingPercentage;
			if (yMin < b.yMin + num || yMax > b.yMax - num)
			{
				return true;
			}
			return false;
		}

		public bool IsOutsideOfRectX(RectTransformOverlap b, float paddingPercentage)
		{
			float num = b.width * paddingPercentage;
			if (xMin < b.xMin + num || xMax > b.xMax - num)
			{
				return true;
			}
			return false;
		}
	}
}
