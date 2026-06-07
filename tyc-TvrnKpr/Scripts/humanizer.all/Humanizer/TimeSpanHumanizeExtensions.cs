using System;
using System.Collections.Generic;
using System.Globalization;
using Humanizer.Localisation;
using Humanizer.Localisation.Formatters;

namespace Humanizer
{
	public static class TimeSpanHumanizeExtensions
	{
		private const int _daysInAWeek = 7;

		private const double _daysInAYear = 365.2425;

		private const double _daysInAMonth = 30.436875;

		public static string Humanize(this TimeSpan timeSpan, int precision = 1, CultureInfo culture = null, TimeUnit maxUnit = TimeUnit.Week, TimeUnit minUnit = TimeUnit.Millisecond, string collectionSeparator = ", ", bool toWords = false)
		{
			return null;
		}

		public static string Humanize(this TimeSpan timeSpan, int precision, bool countEmptyUnits, CultureInfo culture = null, TimeUnit maxUnit = TimeUnit.Week, TimeUnit minUnit = TimeUnit.Millisecond, string collectionSeparator = ", ", bool toWords = false)
		{
			return null;
		}

		private static IEnumerable<string> CreateTheTimePartsWithUpperAndLowerLimits(TimeSpan timespan, CultureInfo culture, TimeUnit maxUnit, TimeUnit minUnit, bool toWords = false)
		{
			return null;
		}

		private static IEnumerable<TimeUnit> GetEnumTypesForTimeUnit()
		{
			return null;
		}

		private static string GetTimeUnitPart(TimeUnit timeUnitToGet, TimeSpan timespan, TimeUnit maximumTimeUnit, TimeUnit minimumTimeUnit, IFormatter cultureFormatter, bool toWords = false)
		{
			return null;
		}

		private static int GetTimeUnitNumericalValue(TimeUnit timeUnitToGet, TimeSpan timespan, TimeUnit maximumTimeUnit)
		{
			return 0;
		}

		private static int GetSpecialCaseMonthAsInteger(TimeSpan timespan, bool isTimeUnitToGetTheMaximumTimeUnit)
		{
			return 0;
		}

		private static int GetSpecialCaseYearAsInteger(TimeSpan timespan)
		{
			return 0;
		}

		private static int GetSpecialCaseWeeksAsInteger(TimeSpan timespan, bool isTimeUnitToGetTheMaximumTimeUnit)
		{
			return 0;
		}

		private static int GetSpecialCaseDaysAsInteger(TimeSpan timespan, TimeUnit maximumTimeUnit)
		{
			return 0;
		}

		private static int GetNormalCaseTimeAsInteger(int timeNumberOfUnits, double totalTimeNumberOfUnits, bool isTimeUnitToGetTheMaximumTimeUnit)
		{
			return 0;
		}

		private static string BuildFormatTimePart(IFormatter cultureFormatter, TimeUnit timeUnitType, int amountOfTimeUnits, bool toWords = false)
		{
			return null;
		}

		private static List<string> CreateTimePartsWithNoTimeValue(string noTimeValue)
		{
			return null;
		}

		private static bool IsContainingOnlyNullValue(IEnumerable<string> timeParts)
		{
			return false;
		}

		private static IEnumerable<string> SetPrecisionOfTimeSpan(IEnumerable<string> timeParts, int precision, bool countEmptyUnits)
		{
			return null;
		}

		private static string ConcatenateTimeSpanParts(IEnumerable<string> timeSpanParts, CultureInfo culture, string collectionSeparator)
		{
			return null;
		}
	}
}
