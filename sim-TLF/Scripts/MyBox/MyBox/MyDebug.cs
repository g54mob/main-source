using System.Collections.Generic;
using System.Text;
using JetBrains.Annotations;
using UnityEngine;
using UnityEngine.AI;

namespace MyBox
{
	[PublicAPI]
	public static class MyDebug
	{
		private static StringBuilder _stringBuilder;

		private static void PrepareStringBuilder()
		{
			if (_stringBuilder == null)
			{
				_stringBuilder = new StringBuilder();
			}
			else
			{
				_stringBuilder.Clear();
			}
		}

		public static void LogArray<T>(T[] toLog)
		{
			PrepareStringBuilder();
			_stringBuilder.Append("Log Array: ").Append(typeof(T).Name).Append(" (")
				.Append(toLog.Length)
				.Append(")\n");
			for (int i = 0; i < toLog.Length; i++)
			{
				_stringBuilder.Append("\n\t").Append(i.ToString().Colored(Colors.brown)).Append(": ")
					.Append(toLog[i]);
			}
			Debug.Log(_stringBuilder.ToString());
		}

		public static void LogArray<T>(IList<T> toLog)
		{
			PrepareStringBuilder();
			int count = toLog.Count;
			_stringBuilder.Append("Log Array: ").Append(typeof(T).Name).Append(" (")
				.Append(count)
				.Append(")\n");
			for (int i = 0; i < count; i++)
			{
				_stringBuilder.Append("\n\t" + i.ToString().Colored(Colors.brown) + ": " + toLog[i]);
			}
			Debug.Log(_stringBuilder.ToString());
		}

		public static void LogColor(Color color)
		{
			string text = ColorUtility.ToHtmlStringRGB(color);
			Color color2 = color;
			Debug.Log("<color=#" + text + ">████████████</color> = " + color2.ToString());
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

		public static void DrawDimensionalCross(Vector3 position, float size, float duration = 0f)
		{
		}

		public static void VisualizeNavMeshPath(NavMeshPath path)
		{
			Vector3[] corners = path.corners;
			for (int i = 1; i < corners.Length; i++)
			{
				Vector3 start = corners[i - 1];
				Vector3 end = corners[i];
				Debug.DrawLine(start, end);
			}
		}
	}
}
