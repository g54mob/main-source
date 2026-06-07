using UnityEngine;

namespace Simulator
{
	public static class RectTransformExtension
	{
		public static RectBoundary GetRectBoundaryInWorldSpace(this RectTransform rectTransform)
		{
			Vector3 min = rectTransform.TransformPoint(rectTransform.rect.min);
			Vector3 max = rectTransform.TransformPoint(rectTransform.rect.max);
			return new RectBoundary(min, max);
		}

		public static RectBoundary GetRectBoundaryInTargetLocalSpace(this RectTransform rectTransform, RectTransform target)
		{
			RectBoundary rectBoundaryInWorldSpace = rectTransform.GetRectBoundaryInWorldSpace();
			Vector3 min = target.InverseTransformPoint(rectBoundaryInWorldSpace.Min);
			Vector3 max = target.InverseTransformPoint(rectBoundaryInWorldSpace.Max);
			return new RectBoundary(min, max);
		}
	}
}
