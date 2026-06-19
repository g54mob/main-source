using System.Diagnostics;
using UnityEngine;

namespace Aggro.Core
{
	public static class GizmosUtil
	{
		[Conditional("UNITY_EDITOR")]
		public static void DrawText(Vector3 position, string text)
		{
		}

		[Conditional("UNITY_EDITOR")]
		public static void DrawText(Vector3 position, string text, GUIStyle style)
		{
		}

		[Conditional("UNITY_EDITOR")]
		public static void DrawCapsule(Vector3 point1, Vector3 point2, float radius)
		{
		}
	}
}
