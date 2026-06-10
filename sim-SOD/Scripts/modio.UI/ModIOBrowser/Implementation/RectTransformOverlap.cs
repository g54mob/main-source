using UnityEngine;

namespace ModIOBrowser.Implementation
{
	public class RectTransformOverlap
	{
		private Vector3[] vectors;

		public float xMin => 0f;

		public float xMax => 0f;

		public float yMin => 0f;

		public float yMax => 0f;

		public float width => 0f;

		public float height => 0f;

		public RectTransformOverlap(RectTransform rt)
		{
		}

		public static explicit operator RectTransformOverlap(RectTransform rt)
		{
			return null;
		}

		public static float DistanceFromEdgeY(RectTransformOverlap a, RectTransformOverlap b, float paddingPercentage)
		{
			return 0f;
		}

		public static float DistanceFromEdgeX(RectTransformOverlap a, RectTransformOverlap b, float paddingPercentage)
		{
			return 0f;
		}

		public bool IsOutsideOfRectY(RectTransformOverlap b, float paddingPercentage)
		{
			return false;
		}

		public bool IsOutsideOfRectX(RectTransformOverlap b, float paddingPercentage)
		{
			return false;
		}
	}
}
