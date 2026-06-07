using UnityEngine;

namespace Jundroo.Common.Utils
{
	public static class GizmosUtility
	{
		public static void DrawWireCapsule(Vector3 center, float height, float radius, Vector3 axis, Color? color = null, Matrix4x4? matrix = null)
		{
			Vector3 vector = axis * (height / 2f - radius);
			DrawWireCapsule(center + vector, center - vector, radius, color, matrix);
		}

		public static void DrawWireCapsule(Vector3 point1, Vector3 point2, float radius, Color? color = null, Matrix4x4? matrix = null)
		{
		}
	}
}
