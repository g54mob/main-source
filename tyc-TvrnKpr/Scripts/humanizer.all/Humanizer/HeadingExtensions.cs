using System.Globalization;

namespace Humanizer
{
	public static class HeadingExtensions
	{
		internal static readonly string[] headings;

		internal static readonly char[] headingArrows;

		public static string ToHeading(this double heading, HeadingStyle style = HeadingStyle.Abbreviated, CultureInfo culture = null)
		{
			return null;
		}

		public static char ToHeadingArrow(this double heading)
		{
			return '\0';
		}

		public static double FromAbbreviatedHeading(this string heading)
		{
			return 0.0;
		}

		public static double FromAbbreviatedHeading(this string heading, CultureInfo culture = null)
		{
			return 0.0;
		}

		public static double FromHeadingArrow(this char heading)
		{
			return 0.0;
		}

		public static double FromHeadingArrow(this string heading)
		{
			return 0.0;
		}
	}
}
