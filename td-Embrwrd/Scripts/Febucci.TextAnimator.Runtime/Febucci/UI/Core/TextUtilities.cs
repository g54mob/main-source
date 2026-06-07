using UnityEngine;

namespace Febucci.UI.Core
{
	public static class TextUtilities
	{
		public const int verticesPerChar = 4;

		public const int fakeRandomsCount = 25;

		internal static Vector3[] fakeRandoms;

		private static bool initialized;

		public static Vector3[] FakeRandoms => null;

		internal static void Initialize()
		{
		}

		public static Vector3 RotateAround(this Vector3 vec, Vector2 center, float rotDegrees)
		{
			return default(Vector3);
		}

		public static void MoveChar(this Vector3[] vec, Vector3 dir)
		{
		}

		public static void SetChar(this Vector3[] vec, Vector3 pos)
		{
		}

		public static void LerpUnclamped(this Vector3[] vec, Vector3 target, float pct)
		{
		}

		public static Vector3 GetMiddlePos(this Vector3[] vec)
		{
			return default(Vector3);
		}

		public static void RotateChar(this Vector3[] vec, float angle)
		{
		}

		public static void RotateChar(this Vector3[] vec, float angle, Vector3 pivot)
		{
		}

		public static void SetColor(this Color32[] col, Color32 target)
		{
		}

		public static void LerpUnclamped(this Color32[] col, Color32 target, float pct)
		{
		}

		public static float CalculateCurveDuration(this AnimationCurve curve)
		{
			return 0f;
		}
	}
}
