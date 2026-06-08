using System;
using UnityEngine;

namespace Shapes
{
	[Serializable]
	public struct PolylinePoint
	{
		public Vector3 point;

		[ShapesColorField(true)]
		public Color color;

		public float thickness;

		public static PolylinePoint Lerp(PolylinePoint a, PolylinePoint b, float t)
		{
			return new PolylinePoint
			{
				point = Vector3.LerpUnclamped(a.point, b.point, t),
				color = Color.LerpUnclamped(a.color, b.color, t),
				thickness = Mathf.LerpUnclamped(a.thickness, b.thickness, t)
			};
		}

		public PolylinePoint(Vector3 point)
		{
			this.point = point;
			color = Color.white;
			thickness = 1f;
		}

		public PolylinePoint(Vector2 point)
		{
			this.point = point;
			color = Color.white;
			thickness = 1f;
		}

		public PolylinePoint(Vector3 point, Color color)
		{
			this.point = point;
			this.color = color;
			thickness = 1f;
		}

		public PolylinePoint(Vector2 point, Color color)
		{
			this.point = point;
			this.color = color;
			thickness = 1f;
		}

		public PolylinePoint(Vector3 point, Color color, float thickness)
		{
			this.point = point;
			this.color = color;
			this.thickness = thickness;
		}

		public PolylinePoint(Vector2 point, Color color, float thickness)
		{
			this.point = point;
			this.color = color;
			this.thickness = thickness;
		}
	}
}
