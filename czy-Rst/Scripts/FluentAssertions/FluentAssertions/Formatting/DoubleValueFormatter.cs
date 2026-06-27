using System;
using System.Globalization;

namespace FluentAssertions.Formatting
{
	public class DoubleValueFormatter : IValueFormatter
	{
		public bool CanHandle(object value)
		{
			return value is double;
		}

		public void Format(object value, FormattedObjectGraph formattedGraph, FormattingContext context, FormatChild formatChild)
		{
			formattedGraph.AddFragment(Format(value));
		}

		private static string Format(object value)
		{
			double d = (double)value;
			if (double.IsPositiveInfinity(d))
			{
				return "Double.PositiveInfinity";
			}
			if (double.IsNegativeInfinity(d))
			{
				return "Double.NegativeInfinity";
			}
			if (double.IsNaN(d))
			{
				return d.ToString(CultureInfo.InvariantCulture);
			}
			string text = d.ToString("R", CultureInfo.InvariantCulture);
			if (SystemExtensions.Contains(text, '.', StringComparison.Ordinal) || SystemExtensions.Contains(text, 'E', StringComparison.Ordinal))
			{
				return text;
			}
			return text + ".0";
		}
	}
}
