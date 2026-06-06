using System;

namespace PajamaLlama.Generic
{
	public class MinMaxRangeFloatAttribute : Attribute
	{
		public float Min { get; private set; }

		public float Max { get; private set; }

		public MinMaxRangeFloatAttribute(float min, float max)
		{
			Min = min;
			Max = max;
		}
	}
}
