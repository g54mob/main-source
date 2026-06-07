using UnityEngine;

namespace MalbersAnimations
{
	public static class MDebug
	{
		public static void Gizmo_Arrow(Vector3 pos, Vector3 direction, float arrowHeadLength = 0.2f, float arrowHeadAngle = 20f)
		{
		}

		public static void Draw_Arrow(Vector3 pos, Vector3 direction, Color color, float duration = 0f, float arrowHeadLength = 0.25f, float arrowHeadAngle = 20f)
		{
		}

		public static void DrawRay(Vector3 pos, Vector3 direction, Color color, float duration = 0f)
		{
		}

		public static void DrawLine(Vector3 pos1, Vector3 pos2, Color color, float duration = 0f)
		{
		}

		public static void DrawCircle(Vector3 position, Quaternion rotation, float radius, Color color, float duration = 0f, int Steps = 36)
		{
		}

		public static void DrawCircle(Vector3 position, Vector3 normal, float radius, Color color, bool cross = false, float duration = 0f, int steps = 36)
		{
		}

		public static void DrawWireSphere(Vector3 position, Color color, float radius = 1f, float drawDuration = 0f, int Steps = 36)
		{
			DrawWireSphere(position, Quaternion.identity, color, radius, 1f, drawDuration, Steps);
		}

		public static void DrawWireSphere(Vector3 position, float radius, Color color, float drawDuration = 0f, int Steps = 36)
		{
			DrawWireSphere(position, Quaternion.identity, color, radius, 1f, drawDuration, Steps);
		}

		public static void DrawWireSphere(Vector3 position, Quaternion rotation, float radius, Color color, float drawDuration = 0f, int Steps = 36)
		{
			DrawWireSphere(position, rotation, color, radius, 1f, drawDuration, Steps);
		}

		public static void DrawWireSphere(Vector3 position, Quaternion rotation, Color color, float radius = 1f, float scale = 1f, float drawDuration = 0f, int Steps = 1)
		{
		}

		public static void DrawCapsule(Vector3 Center, Quaternion rotation, float height, float radius, Color color, int direction = 1, int Steps = 36)
		{
			height = Mathf.Clamp(height, radius * 2f, height);
			switch (direction)
			{
			case 0:
			{
				Vector3 point4 = Center + rotation * (Vector3.right * (height / 2f - radius));
				Vector3 point2 = Center + rotation * (-Vector3.right * (height / 2f - radius));
				DrawCapsule(point4, point2, rotation * Quaternion.Euler(0f, 0f, -90f), radius, color, Steps);
				break;
			}
			case 1:
			{
				Vector3 point3 = Center + rotation * (Vector3.up * (height / 2f - radius));
				Vector3 point2 = Center + rotation * (-Vector3.up * (height / 2f - radius));
				DrawCapsule(point3, point2, rotation, radius, color, Steps);
				break;
			}
			default:
			{
				Vector3 point = Center + rotation * (Vector3.forward * (height / 2f - radius));
				Vector3 point2 = Center + rotation * (-Vector3.forward * (height / 2f - radius));
				DrawCapsule(point, point2, rotation * Quaternion.Euler(90f, 0f, 0f), radius, color, Steps);
				break;
			}
			}
		}

		public static void DrawCapsule(Vector3 point1, Vector3 point2, Quaternion rot, float radius, Color color, int Steps = 36)
		{
		}

		public static void GizmoWireSphere(Vector3 position, Quaternion rotation, float radius, Color color, float scale = 1f, int Steps = 36)
		{
		}

		public static void GizmoCircle(Vector3 position, Quaternion rotation, float radius, Color color, float scale = 1f, int Steps = 36)
		{
		}

		public static void GizmoWireHemiSphere(Vector3 position, Quaternion rotation, float radius, Color color, int Steps = 36)
		{
		}

		public static void GizmoCross(Transform m_transform)
		{
		}

		public static void DrawCone(Vector3 position, Quaternion rotation, float FOV, float length, Color color, float scale = 1f, int Steps = 4)
		{
		}

		public static void DrawTriggers(Transform transform, Collider col, Color DebugColor, bool always = false)
		{
		}

		public static void DebugCross(Vector3 center, float radius, Color color)
		{
		}

		public static void DebugPlane(Vector3 center, float radius, Color color, bool cross = false)
		{
		}

		public static void DebugTriangle(Vector3 center, float radius, Color color)
		{
		}

		public static void GizmoRay(Vector3 p1, Vector3 dir, float width = 2f)
		{
		}

		public static void DrawLine(Vector3 p1, Vector3 p2, float width = 2f)
		{
		}
	}
}
