using System.Diagnostics;
using UnityEngine;

namespace CTS.Core.Utilities
{
	public static class GizmosPlus
	{
		[Conditional("UNITY_EDITOR")]
		public static void DrawWireSphere(Vector3 p_position, Quaternion p_rotation, float p_radius)
		{
		}

		[Conditional("UNITY_EDITOR")]
		public static void DrawSSCircle(Vector3 p_position, float p_radius)
		{
		}

		[Conditional("UNITY_EDITOR")]
		public static void DrawWireCapsule(Vector3 _pos, Quaternion _rot, float _radius, float _height, Color _color = default(Color))
		{
		}

		[Conditional("UNITY_EDITOR")]
		public static void DrawCoordinateArrows(Vector3 position, Quaternion rotation, float scale = 1f)
		{
		}

		[Conditional("UNITY_EDITOR")]
		public static void DrawLabel(Vector3 position, string label)
		{
		}
	}
}
