using UnityEngine;

namespace MyBox
{
	public static class MyGizmos
	{
		public static void DrawArrow(Vector3 from, Vector3 direction, float headLength = 0.25f, float headAngle = 20f)
		{
		}

		public static void DrawBoxCollider2D(BoxCollider2D collider, bool fill = true)
		{
			Transform transform = collider.transform;
			Gizmos.matrix = Matrix4x4.TRS(transform.position, transform.rotation, transform.lossyScale);
			if (fill)
			{
				Gizmos.DrawCube(collider.offset, collider.size);
			}
			else
			{
				Gizmos.DrawWireCube(collider.offset, collider.size);
			}
			Gizmos.matrix = Matrix4x4.identity;
		}
	}
}
