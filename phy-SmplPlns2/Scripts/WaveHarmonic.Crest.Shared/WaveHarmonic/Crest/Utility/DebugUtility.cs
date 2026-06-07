using UnityEngine;

namespace WaveHarmonic.Crest.Utility
{
	internal static class DebugUtility
	{
		public delegate void DrawLine(Vector3 position, Vector3 up, Color color, float duration);

		public static void DrawCross(DrawLine draw, Vector3 position, float r, Color color, float duration = 0f)
		{
			draw(position - Vector3.up * r, position + Vector3.up * r, color, duration);
			draw(position - Vector3.right * r, position + Vector3.right * r, color, duration);
			draw(position - Vector3.forward * r, position + Vector3.forward * r, color, duration);
		}

		public static void DrawCross(DrawLine draw, Vector3 position, Vector3 up, float r, Color color, float duration = 0f)
		{
			up.Normalize();
			Vector3 vector = Vector3.Normalize(Vector3.Cross(up, Vector3.forward));
			Vector3 vector2 = Vector3.Cross(up, vector);
			draw(position - up * r, position + up * r, color, duration);
			draw(position - vector * r, position + vector * r, color, duration);
			draw(position - vector2 * r, position + vector2 * r, color, duration);
		}
	}
}
