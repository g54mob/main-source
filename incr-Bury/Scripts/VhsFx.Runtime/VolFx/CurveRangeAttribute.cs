using System;
using UnityEngine;

namespace VolFx
{
	[AttributeUsage(AttributeTargets.Field, AllowMultiple = false, Inherited = true)]
	public class CurveRangeAttribute : PropertyAttribute
	{
		public Vector2 Min { get; private set; }

		public Vector2 Max { get; private set; }

		public CurveRangeAttribute()
			: this(new Vector2(0f, 0f), new Vector2(1f, 1f))
		{
		}

		public CurveRangeAttribute(Vector2 min, Vector2 max)
		{
			Min = min;
			Max = max;
		}

		public CurveRangeAttribute(float minX, float minY, float maxX, float maxY)
			: this(new Vector2(minX, minY), new Vector2(maxX, maxY))
		{
		}
	}
}
