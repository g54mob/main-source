using UnityEngine;

namespace Libs
{
	public static class CameraExtension
	{
		public static Vector3 ScreenToWorldPoint(this Camera camera, Vector3 position, Plane plane)
		{
			return default(Vector3);
		}

		public static Vector3[] ScreenToWorldCornerPoints(this Camera camera, Rect screenRect, Plane plane, float z)
		{
			return null;
		}
	}
}
