using System;
using UnityEngine;

namespace ModApi.Math
{
	public struct Polar2d
	{
		public double Angle { get; set; }

		public double Radius { get; set; }

		public Polar2d(double angle, double radius)
		{
			Angle = angle;
			Radius = radius;
		}

		public Polar2d(Vector2d point)
		{
			Angle = System.Math.Atan2(point.y, point.x);
			Radius = point.magnitude;
		}

		public Vector2d ToVector2d()
		{
			return new Vector2d
			{
				x = System.Math.Cos(Angle) * Radius,
				y = System.Math.Sin(Angle) * Radius
			};
		}
	}
}
