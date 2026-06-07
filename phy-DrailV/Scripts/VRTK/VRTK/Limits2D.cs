using System;
using UnityEngine;

namespace VRTK
{
	[Serializable]
	public class Limits2D
	{
		public float minimum;

		public float maximum;

		public static Limits2D zero => new Limits2D(0f, 0f);

		public Limits2D(float min, float max)
		{
			minimum = min;
			maximum = max;
		}

		public Limits2D(Vector2 limits)
		{
			minimum = limits.x;
			maximum = limits.y;
		}

		public bool WithinLimits(float value)
		{
			if (value >= minimum)
			{
				return value <= maximum;
			}
			return false;
		}

		public Vector2 AsVector2()
		{
			return new Vector2(minimum, maximum);
		}
	}
}
