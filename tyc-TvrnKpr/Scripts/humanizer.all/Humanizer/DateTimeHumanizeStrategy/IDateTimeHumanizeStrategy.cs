using System;
using System.Globalization;

namespace Humanizer.DateTimeHumanizeStrategy
{
	public interface IDateTimeHumanizeStrategy
	{
		string Humanize(DateTime input, DateTime comparisonBase, CultureInfo culture);
	}
}
