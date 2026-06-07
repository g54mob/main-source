using System;

namespace PajamaLlama.Generic
{
	public class MinMaxRangeIntAttribute : Attribute
	{
		public int Min { get; private set; }

		public int Max { get; private set; }

		public MinMaxRangeIntAttribute(int min, int max)
		{
			Min = min;
			Max = max;
		}
	}
}
