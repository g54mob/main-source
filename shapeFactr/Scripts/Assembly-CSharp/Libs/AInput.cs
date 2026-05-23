using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Libs
{
	public static class AInput
	{
		private static readonly List<RaycastResult> CachedRaycastResults;

		private static int _lastRaycastFrame;

		private static readonly float WheelDelta;

		private static float _mouseScrollSensitivityY;

		private static float _padScrollSensitivityY;

		public static bool MouseLeft => false;

		public static bool MouseLeftEdge => false;

		public static bool MouseLeftRelease => false;

		public static bool MouseRight => false;

		public static bool MouseRightEdge => false;

		public static bool MouseRightRelease => false;

		public static bool Decide => false;

		public static bool Cancel => false;

		public static bool IsGameInputOk => false;

		public static Vector3 MousePosition(float z)
		{
			return default(Vector3);
		}

		public static void SetMouseScrollSensitivityY(float f)
		{
		}

		public static float GetMouseScrollSensitivityY()
		{
			return 0f;
		}

		public static float GetMouseScrollSensitivityYWithDelta()
		{
			return 0f;
		}

		public static float GetMouseScrollY()
		{
			return 0f;
		}

		public static float GetCameraZoom()
		{
			return 0f;
		}

		public static bool IsGameInputOkOrOnPauseDialog(Vector3 mousePosition)
		{
			return false;
		}

		public static bool IsGameInputOkOrOnPauseDialog()
		{
			return false;
		}

		private static bool IsPointerOverGameObject()
		{
			return false;
		}

		public static string DumpMouseLeft()
		{
			return null;
		}
	}
}
