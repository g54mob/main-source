using System.Diagnostics;
using UnityEngine;

namespace CTS.Core.Utilities
{
	public static class DebugPlus
	{
		[Conditional("UNITY_EDITOR")]
		public static void DrawBox(BoxCollider p_boxCollider, float p_duration = 0f)
		{
		}

		[Conditional("UNITY_EDITOR")]
		public static void DrawBox(BoxCollider p_boxCollider, Color p_color, float p_duration = 0f)
		{
			Transform transform = p_boxCollider.transform;
			transform.lossyScale.Scale(p_boxCollider.size);
			transform.TransformPoint(p_boxCollider.center);
		}

		[Conditional("UNITY_EDITOR")]
		public static void DrawBox(Bounds p_bounds, float p_duration = 0f)
		{
		}

		[Conditional("UNITY_EDITOR")]
		public static void DrawBox(Bounds p_bounds, Color p_color, float p_duration = 0f)
		{
		}

		[Conditional("UNITY_EDITOR")]
		public static void DrawBox(Bounds p_bounds, Quaternion p_orientation, float p_duration = 0f)
		{
		}

		[Conditional("UNITY_EDITOR")]
		public static void DrawBox(Bounds p_bounds, Quaternion p_orientation, Color p_color, float p_duration = 0f)
		{
		}

		[Conditional("UNITY_EDITOR")]
		public static void DrawBox(Vector3 p_center, Vector3 p_halfExtents, float p_duration = 0f)
		{
		}

		[Conditional("UNITY_EDITOR")]
		public static void DrawBox(Vector3 p_center, Vector3 p_halfExtents, Color p_color, float p_duration = 0f)
		{
			Vector3 vector = p_halfExtents * 2f;
			Vector3 p_right = Vector3.right * vector.x;
			Vector3 p_up = Vector3.up * vector.y;
			Vector3 p_forward = Vector3.forward * vector.z;
			DoDrawBox(p_center + p_halfExtents, p_right, p_up, p_forward, p_color, p_duration);
		}

		[Conditional("UNITY_EDITOR")]
		public static void DrawBox(Vector3 p_center, Vector3 p_halfExtents, Quaternion p_orientation, float p_duration = 0f)
		{
		}

		[Conditional("UNITY_EDITOR")]
		public static void DrawBox(Vector3 p_center, Vector3 p_halfExtents, Quaternion p_orientation, Color p_color, float p_duration = 0f)
		{
			Vector3 vector = p_halfExtents * 2f;
			Vector3 p_right = p_orientation * (Vector3.right * vector.x);
			Vector3 p_up = p_orientation * (Vector3.up * vector.y);
			Vector3 p_forward = p_orientation * (Vector3.forward * vector.z);
			DoDrawBox(p_center + p_orientation * p_halfExtents, p_right, p_up, p_forward, p_color, p_duration);
		}

		private static void DoDrawBox(Vector3 p_corner, Vector3 p_right, Vector3 p_up, Vector3 p_forward, Color p_color, float p_duration)
		{
			DrawLine(p_corner - p_right);
			DrawLine(p_corner - p_up);
			DrawLine(p_corner - p_forward);
			p_corner = p_corner - p_right - p_up;
			DrawLine(p_corner + p_right);
			DrawLine(p_corner + p_up);
			DrawLine(p_corner - p_forward);
			p_corner = p_corner - p_forward + p_up;
			DrawLine(p_corner + p_right);
			DrawLine(p_corner - p_up);
			DrawLine(p_corner + p_forward);
			p_corner = p_corner + p_right - p_up;
			DrawLine(p_corner - p_right);
			DrawLine(p_corner + p_up);
			DrawLine(p_corner + p_forward);
			void DrawLine(Vector3 p_end)
			{
				UnityEngine.Debug.DrawLine(p_corner, p_end, p_color, p_duration);
			}
		}
	}
}
