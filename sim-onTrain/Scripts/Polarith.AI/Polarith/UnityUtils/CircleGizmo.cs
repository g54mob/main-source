using System;
using Polarith.Utils;
using UnityEngine;

namespace Polarith.UnityUtils
{
	[Serializable]
	public sealed class CircleGizmo
	{
		[Tooltip("Determines whether this gizmo is enabled.")]
		public bool Enabled;

		[Tooltip("The color of the drawn circle.")]
		public Color Color = Colors.Green;

		private const float minResolution = 50f;

		private const float maxResolution = 70f;

		private float stepSize;

		private float counter;

		private Vector3 startPoint;

		private Vector3 endPoint;

		public void Draw(Vector3 center, Quaternion rotation, float radius)
		{
			stepSize = 0f;
			if (radius < 1f)
			{
				stepSize = 7.2f;
			}
			else if (radius >= 1f && radius <= 30f)
			{
				stepSize = 360f / Mathf2.MapLinear(50f, 70f, 1f, 100f, radius, clamp: false);
			}
			else if (radius > 30f)
			{
				stepSize = 5.142857f;
			}
			Gizmos.color = Color;
			counter = 0f;
			while (counter < 360f)
			{
				startPoint.x = radius * Mathf.Cos(counter * ((float)Math.PI / 180f));
				startPoint.y = radius * Mathf.Sin(counter * ((float)Math.PI / 180f));
				counter += stepSize;
				endPoint.x = radius * Mathf.Cos(counter * ((float)Math.PI / 180f));
				endPoint.y = radius * Mathf.Sin(counter * ((float)Math.PI / 180f));
				Gizmos.DrawLine(rotation * startPoint + center, rotation * endPoint + center);
			}
		}
	}
}
