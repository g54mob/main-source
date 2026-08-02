using System;
using UnityEngine;

namespace Polarith.UnityUtils
{
	[Serializable]
	public sealed class PlaneGizmo
	{
		[Tooltip("Determines whether this gizmo is enabled.")]
		public bool Enabled;

		[Tooltip("The color of the drawn plane.")]
		public Color Color = Colors.Green;

		[Tooltip("Defines the size of the shown gizmos.")]
		public float PlaneSize = 5f;

		public void Draw(Vector3 center, Vector3 direction1, Vector3 direction2)
		{
			if (Enabled)
			{
				Gizmos.color = Color;
				Gizmos.DrawLine(center + direction1 * (0f - PlaneSize), center + direction1 * PlaneSize);
				Gizmos.DrawLine(center + direction2 * (0f - PlaneSize), center + direction2 * PlaneSize);
				Vector3 vector = direction1 * (0f - PlaneSize) + direction2 * PlaneSize;
				Vector3 vector2 = direction1 * PlaneSize + direction2 * PlaneSize;
				Vector3 vector3 = direction1 * (0f - PlaneSize) + direction2 * (0f - PlaneSize);
				Vector3 vector4 = direction1 * PlaneSize + direction2 * (0f - PlaneSize);
				Gizmos.DrawLine(center + vector, center + vector2);
				Gizmos.DrawLine(center + vector, center + vector3);
				Gizmos.DrawLine(center + vector3, center + vector4);
				Gizmos.DrawLine(center + vector2, center + vector4);
			}
		}
	}
}
