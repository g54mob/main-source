using System;

namespace Humanizer
{
	[Flags]
	public enum MetricNumeralFormats
	{
		UseLongScaleWord = 1,
		UseName = 2,
		UseShortScaleWord = 4,
		WithSpace = 8
	}
}
