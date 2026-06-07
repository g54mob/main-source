using System;

namespace ModApi.Ui.Inspector
{
	public class NumericRangeAttribute : Attribute
	{
		public double? Max { get; }

		public double? Min { get; }

		public NumericRangeAttribute(double min, double max)
		{
			Min = min;
			Max = max;
		}
	}
}
