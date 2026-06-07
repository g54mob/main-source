using UnityEngine;

namespace ModApi.Common.Attributes
{
	public class MinMaxValueAttribute : PropertyAttribute
	{
		public float MaxValue { get; private set; }

		public float MinValue { get; private set; }

		public MinMaxValueAttribute(float minValue, float maxValue)
		{
			MinValue = minValue;
			MaxValue = maxValue;
		}
	}
}
