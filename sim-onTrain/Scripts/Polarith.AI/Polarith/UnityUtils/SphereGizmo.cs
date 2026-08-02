using System;
using UnityEngine;

namespace Polarith.UnityUtils
{
	[Serializable]
	public sealed class SphereGizmo
	{
		[Tooltip("Determines whether this gizmo is enabled.")]
		public bool Enabled;

		[Tooltip("The size of the drawn target sphere.")]
		public float Size = 0.1f;

		[Tooltip("The color of the drawn target sphere.")]
		public Color Color = Colors.Yellow;

		public void Draw(Vector3 center, bool wired = false)
		{
			Gizmos.color = Color;
			if (wired)
			{
				Gizmos.DrawWireSphere(center, Size);
			}
			else
			{
				Gizmos.DrawSphere(center, Size);
			}
		}
	}
}
