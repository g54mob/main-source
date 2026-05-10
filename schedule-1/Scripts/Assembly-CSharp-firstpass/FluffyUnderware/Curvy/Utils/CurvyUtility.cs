using System.Runtime.CompilerServices;
using UnityEngine;

namespace FluffyUnderware.Curvy.Utils
{
	public static class CurvyUtility
	{
		public static float ClampTF(float tf, CurvyClamping clamping)
		{
			return 0f;
		}

		public static float ClampTF(float tf, ref int dir, CurvyClamping clamping)
		{
			return 0f;
		}

		public static float ClampValue(float tf, CurvyClamping clamping, float minTF, float maxTF)
		{
			return 0f;
		}

		public static float ClampDistance(float distance, CurvyClamping clamping, float length)
		{
			return 0f;
		}

		public static float ClampDistance(float distance, CurvyClamping clamping, float length, float min, float max)
		{
			return 0f;
		}

		public static float ClampDistance(float distance, ref int dir, CurvyClamping clamping, float length)
		{
			return 0f;
		}

		public static float ClampDistance(float distance, ref int dir, CurvyClamping clamping, float length, float min, float max)
		{
			return 0f;
		}

		public static Material GetDefaultMaterial()
		{
			return null;
		}

		public static bool Approximately(this float x, float y)
		{
			return false;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static int InterpolationSearch(float[] array, float x)
		{
			return 0;
		}

		public static int InterpolationSearch(float[] array, int elementsCount, float x)
		{
			return 0;
		}

		public static Mesh SplineToMesh(this CurvySpline spline)
		{
			return null;
		}

		public static void GetNearestPointIndex(Vector3 point, Vector3[] points, int pointsCount, out int index, out float fragement)
		{
			index = default(int);
			fragement = default(float);
		}
	}
}
