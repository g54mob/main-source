using UnityEngine;

namespace Assets.Scripts.XR.UI
{
	public class RadialButtonRaycastFiller : MonoBehaviour, ICanvasRaycastFilter
	{
		public float angleWidth;

		public float maxRadius;

		public float minRadius;

		public RectTransform reference;

		public float startAngle;

		public bool IsRaycastLocationValid(Vector2 sp, Camera eventCamera)
		{
			if (RectTransformUtility.ScreenPointToLocalPointInRectangle(reference, sp, eventCamera, out var localPoint))
			{
				float sqrMagnitude = localPoint.sqrMagnitude;
				if (sqrMagnitude < minRadius * minRadius || sqrMagnitude > maxRadius * maxRadius)
				{
					return false;
				}
				float num;
				for (num = Mathf.DeltaAngle(startAngle, Mathf.Atan2(localPoint.x, localPoint.y) * 57.29578f); num < 0f; num += 360f)
				{
				}
				return num < angleWidth;
			}
			return false;
		}
	}
}
