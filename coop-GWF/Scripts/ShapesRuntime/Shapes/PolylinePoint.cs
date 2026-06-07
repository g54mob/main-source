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

		public static PolylinePoint operator +(PolylinePoint a, PolylinePoint b)
		{
			return new PolylinePoint(a.point + b.point, a.color + b.color, a.thickness + b.thickness);
		}

		public static PolylinePoint operator *(PolylinePoint a, float b)
		{
			return new PolylinePoint(a.point * b, a.color * b, a.thickness * b);
		}

		public static PolylinePoint operator *(float b, PolylinePoint a)
		{
			return a * b;
		}

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
