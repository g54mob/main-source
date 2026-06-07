using System;
using System.Collections.Generic;

namespace Humanizer
{
	public static class MetricNumeralExtensions
	{
		private struct UnitPrefix
		{
			private readonly string _longScaleWord;

			public string Name { get; }

			public string ShortScaleWord { get; }

			public string LongScaleWord => null;

			public UnitPrefix(string name, string shortScaleWord, string longScaleWord = null)
			{
				_longScaleWord = null;
				Name = null;
				ShortScaleWord = null;
			}
		}

		private static readonly double BigLimit;

		private static readonly double SmallLimit;

		private static readonly List<char>[] Symbols;

		private static readonly Dictionary<char, UnitPrefix> UnitPrefixes;

		static MetricNumeralExtensions()
		{
		}

		public static double FromMetric(this string input)
		{
			return 0.0;
		}

		[Obsolete("Please use overload with MetricNumeralFormats")]
		public static string ToMetric(this int input, bool hasSpace, bool useSymbol = true, int? decimals = null)
		{
			return null;
		}

		public static string ToMetric(this int input, MetricNumeralFormats? formats = null, int? decimals = null)
		{
			return null;
		}

		[Obsolete("Please use overload with MetricNumeralFormats")]
		public static string ToMetric(this double input, bool hasSpace, bool useSymbol = true, int? decimals = null)
		{
			return null;
		}

		public static string ToMetric(this double input, MetricNumeralFormats? formats = null, int? decimals = null)
		{
			return null;
		}

		private static string CleanRepresentation(string input)
		{
			return null;
		}

		private static double BuildNumber(string input, char last)
		{
			return 0.0;
		}

		private static double BuildMetricNumber(string input, char last)
		{
			return 0.0;
		}

		private static string ReplaceNameBySymbol(string input)
		{
			return null;
		}

		private static string BuildRepresentation(double input, MetricNumeralFormats? formats, int? decimals)
		{
			return null;
		}

		private static string BuildMetricRepresentation(double input, int exponent, MetricNumeralFormats? formats, int? decimals)
		{
			return null;
		}

		private static string GetUnitText(char symbol, MetricNumeralFormats? formats)
		{
			return null;
		}

		private static bool IsOutOfRange(this double input)
		{
			return false;
		}

		private static bool IsInvalidMetricNumeral(this string input)
		{
			return false;
		}
	}
}
