using System;
using UnityEngine;

namespace Polarith.UnityUtils
{
	[Serializable]
	public sealed class VelocityGizmo
	{
		[Tooltip("Determines whether this gizmo is enabled.")]
		public bool Enabled;

		[Tooltip("The color of the drawn visualizations.")]
		public Color Color = Color.Lerp(Color.cyan, Color.magenta, 0.5f);

		[Tooltip("The scale of the direction indication. If the scale is 1, this line segment directly displays the velocity vector unscaled in Unity units.")]
		public float DirectionScale = 1f;

		[Tooltip("Scales the sphere indicating the predicted position, which is independent from the 'Direction Scale'.")]
		public float PointSize = 0.2f;

		public void Draw(Vector3 point, Vector3 direction, float velocityMagnitude, float predictionMagnitude)
		{
			if (Enabled)
			{
				Gizmos.color = Color;
				Gizmos.DrawLine(point, point + direction * velocityMagnitude * DirectionScale);
				Gizmos.DrawSphere(point + direction * predictionMagnitude, PointSize);
			}
		}
	}
}
