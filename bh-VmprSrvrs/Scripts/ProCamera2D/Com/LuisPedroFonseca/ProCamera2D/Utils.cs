using System.Collections.Generic;
using UnityEngine;

namespace Com.LuisPedroFonseca.ProCamera2D
{
	public static class Utils
	{
		public static float EaseFromTo(float start, float end, float value, EaseType type = EaseType.EaseInOut)
		{
			return 0f;
		}

		public static float SmoothApproach(float pastPosition, float pastTargetPosition, float targetPosition, float speed, float deltaTime)
		{
			return 0f;
		}

		public static float Remap(this float value, float from1, float to1, float from2, float to2)
		{
			return 0f;
		}

		public static void DrawArrowForGizmo(Vector3 pos, Vector3 direction, float arrowHeadLength = 0.25f, float arrowHeadAngle = 20f)
		{
		}

		public static void DrawArrowForGizmo(Vector3 pos, Vector3 direction, Color color, float arrowHeadLength = 0.25f, float arrowHeadAngle = 20f)
		{
		}

		public static void DrawArrowForDebug(Vector3 pos, Vector3 direction, float arrowHeadLength = 0.25f, float arrowHeadAngle = 20f)
		{
		}

		public static void DrawArrowForDebug(Vector3 pos, Vector3 direction, Color color, float arrowHeadLength = 0.25f, float arrowHeadAngle = 20f)
		{
		}

		private static void DrawArrowEnd(bool gizmos, Vector3 pos, Vector3 direction, Color color, float arrowHeadLength = 0.25f, float arrowHeadAngle = 20f)
		{
		}

		public static bool AreNearlyEqual(float a, float b, float tolerance = 0.02f)
		{
			return false;
		}

		public static Vector2 GetScreenSizeInWorldCoords(Camera gameCamera, float distance = 10f)
		{
			return default(Vector2);
		}

		public static Vector3 GetVectorsSum(IList<Vector3> input)
		{
			return default(Vector3);
		}

		public static float AlignToGrid(float input, float gridSize)
		{
			return 0f;
		}

		public static bool IsInsideRectangle(float x, float y, float width, float height, float pointX, float pointY)
		{
			return false;
		}

		public static bool IsInsideCircle(float x, float y, float radius, float pointX, float pointY)
		{
			return false;
		}
	}
}
