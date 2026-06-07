using System;
using System.Globalization;
using Humanizer.Localisation;

namespace Humanizer.DateTimeHumanizeStrategy
{
	internal static class DateTimeHumanizeAlgorithms
	{
		public static string PrecisionHumanize(DateTime input, DateTime comparisonBase, double precision, CultureInfo culture)
		{
			return null;
		}

		private static string PrecisionHumanize(TimeSpan ts, Tense tense, double precision, CultureInfo culture)
		{
			return null;
		}

		public static string DefaultHumanize(DateTime input, DateTime comparisonBase, CultureInfo culture)
		{
			return null;
		}

		private static string DefaultHumanize(TimeSpan ts, bool sameMonth, int days, Tense tense, CultureInfo culture)
		{
			return null;
		}
	}
}
