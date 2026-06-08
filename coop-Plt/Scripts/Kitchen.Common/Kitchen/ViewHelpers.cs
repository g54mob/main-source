using UnityEngine;

namespace Kitchen
{
	public static class ViewHelpers
	{
		private static Bounds Bounds;

		private static float PreviousOrthagraphicSize;

		private static float PreviousAspect;

		public static Vector3 WorldToScreen(Camera camera, Vector3 position)
		{
			Vector3 vector = camera.WorldToScreenPoint(position);
			return new Vector3(vector.x / (float)camera.pixelWidth, vector.y / (float)camera.pixelHeight, 0f);
		}

		public static Vector3 ScaleToBounds(Bounds bounds, Vector3 position)
		{
			return new Vector3(position.x * bounds.size.x + bounds.min.x, position.y * bounds.size.y + bounds.min.y, 0f);
		}

		public static Bounds GetOrthoCameraBounds(Camera camera)
		{
			_ = Bounds;
			if (PreviousOrthagraphicSize == camera.orthographicSize && PreviousAspect == camera.aspect)
			{
				return Bounds;
			}
			PreviousOrthagraphicSize = camera.orthographicSize;
			PreviousAspect = camera.aspect;
			float num = camera.orthographicSize * 2f;
			float x = num * camera.aspect;
			float num2 = num * 0.99f;
			float y = (num2 - num) * 0.5f;
			Vector3 center = new Vector3(0f, y);
			Vector3 size = new Vector3(x, num2);
			Bounds = new Bounds(center, size);
			return Bounds;
		}
	}
}
