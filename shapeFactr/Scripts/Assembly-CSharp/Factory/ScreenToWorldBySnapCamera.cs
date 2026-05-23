using UnityEngine;

namespace Factory
{
	public class ScreenToWorldBySnapCamera
	{
		private readonly Vector3 startScreenMousePosition;

		private readonly Vector3[] startWorldCornerPoints;

		private readonly Vector3 startWorldMousePosition;

		private readonly Vector3 startCameraPosition;

		private float _cameraLrLimit;

		private float _cameraUpLimit;

		private float _cameraDownLimit;

		private static readonly Vector2 MarginPer;

		public ScreenToWorldBySnapCamera(Camera camera, Plane plane, Vector3 screenMousePosition)
		{
		}

		public Vector3 GetCameraPosition(Camera camera, Vector3 mousePosition)
		{
			return default(Vector3);
		}

		public static void ClampCamera(ref Camera camera)
		{
		}

		public static bool RestrictCamera(ref Camera camera, ref Vector2 virtualMousePosition, ref Vector3Int gridPos, Plane plane)
		{
			return false;
		}
	}
}
