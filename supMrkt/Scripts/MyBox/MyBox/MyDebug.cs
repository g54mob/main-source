using System.Collections.Generic;
using System.Text;
using UnityEngine;

namespace MyBox
{
	public static class MyDebug
	{
		private static StringBuilder _stringBuilder;

		private static void PrepareStringBuilder()
		{
		}

		public static void LogArray<T>(T[] toLog)
		{
		}

		public static void LogArray<T>(IList<T> toLog)
		{
		}

		public static void LogColor(Color color)
		{
		}

		public static void DrawDebugBounds(MeshFilter mesh, Color color)
		{
		}

		public static void DrawDebugBounds(MeshRenderer renderer, Color color)
		{
		}

		public static void DrawDebugBounds(Bounds bounds, Color color)
		{
		}

		public static void DrawString(string text, Vector3 worldPos, Color? colour = null)
		{
		}

		public static void DrawArrowRay(Vector3 position, Vector3 direction, float headLength = 0.25f, float headAngle = 20f)
		{
		}

		public static void DrawDimensionalCross(Vector3 position, float size)
		{
		}
	}
}
