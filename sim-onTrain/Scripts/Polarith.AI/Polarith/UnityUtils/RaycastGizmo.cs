using System;
using UnityEngine;

namespace Polarith.UnityUtils
{
	[Serializable]
	public sealed class RaycastGizmo
	{
		[Tooltip("Determines whether this gizmo is enabled.")]
		public bool Enabled;

		[Tooltip("The color of the drawn line.")]
		public Color Color = Color.cyan;

		[Tooltip("The color of the sphere that is displayed if the ray hit something.")]
		public Color HitColor = Color.magenta;

		[Tooltip("Defines the size of the shown gizmos.")]
		public float Size = 0.2f;

		public void DrawRay(Vector3 position, Vector3 direction)
		{
			if (Enabled)
			{
				Gizmos.color = Color;
				Gizmos.DrawLine(position, position + direction);
			}
		}

		public void DrawRay(Vector3 position, Vector3 localDirection, Quaternion rotation)
		{
			if (Enabled)
			{
				Gizmos.color = Color;
				Gizmos.DrawLine(position, position + rotation * localDirection);
			}
		}

		public void DrawRayHit(Vector3 position)
		{
			if (Enabled)
			{
				Gizmos.color = HitColor;
				Gizmos.DrawSphere(position, Size);
			}
		}
	}
}
