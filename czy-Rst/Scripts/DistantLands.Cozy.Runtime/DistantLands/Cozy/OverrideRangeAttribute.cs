using UnityEngine;

namespace DistantLands.Cozy
{
	public class OverrideRangeAttribute : PropertyAttribute
	{
		public float MinValue { get; private set; }

		public float MaxValue { get; private set; }

		public OverrideRangeAttribute(float minValue, float maxValue)
		{
			MinValue = minValue;
			MaxValue = maxValue;
		}
	}
}
