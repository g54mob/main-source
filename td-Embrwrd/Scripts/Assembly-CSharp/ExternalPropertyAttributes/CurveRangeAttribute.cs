using System;
using UnityEngine;

namespace ExternalPropertyAttributes
{
	[AttributeUsage(AttributeTargets.Field, AllowMultiple = false, Inherited = true)]
	public class CurveRangeAttribute : DrawerAttribute
	{
		public Vector2 Min { get; private set; }

		public Vector2 Max { get; private set; }

		public EColor Color { get; private set; }

		public CurveRangeAttribute(Vector2 min, Vector2 max, EColor color = EColor.Clear)
		{
		}

		public CurveRangeAttribute(EColor color)
		{
		}

		public CurveRangeAttribute(float minX, float minY, float maxX, float maxY, EColor color = EColor.Clear)
		{
		}
	}
}
