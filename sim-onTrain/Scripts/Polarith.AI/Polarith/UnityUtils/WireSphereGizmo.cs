using System;
using UnityEngine;

namespace Polarith.UnityUtils
{
	[Serializable]
	public sealed class WireSphereGizmo
	{
		[Tooltip("Determines whether this gizmo is enabled.")]
		public bool Enabled;

		[Tooltip("The color of the drawn target sphere.")]
		public Color Color = Colors.Green;

		public void Draw(Vector3 center, float radius)
		{
			Gizmos.color = Color;
			Gizmos.DrawWireSphere(center, radius);
		}
	}
}
