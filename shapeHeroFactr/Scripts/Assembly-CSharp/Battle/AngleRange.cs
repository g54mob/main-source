using System;
using UnityEngine;

namespace Battle
{
	[Serializable]
	public class AngleRange
	{
		[Range(-180f, 180f)]
		public float axis;

		[Range(-180f, 180f)]
		public float enableAngle;

		public AngleRange(float axis, float enableAngle)
		{
		}

		public float RandomRangeDegree()
		{
			return 0f;
		}

		public bool Equal(AngleRange angleRange)
		{
			return false;
		}
	}
}
