using System;
using System.Globalization;

namespace Humanizer.DateTimeHumanizeStrategy
{
	public interface IDateTimeOffsetHumanizeStrategy
	{
		string Humanize(DateTimeOffset input, DateTimeOffset comparisonBase, CultureInfo culture);
	}
}
