using System.Globalization;

namespace FluentAssertions.Formatting
{
	public class SingleValueFormatter : IValueFormatter
	{
		public bool CanHandle(object value)
		{
			return value is float;
		}

		public void Format(object value, FormattedObjectGraph formattedGraph, FormattingContext context, FormatChild formatChild)
		{
			float f = (float)value;
			if (float.IsPositiveInfinity(f))
			{
				formattedGraph.AddFragment("Single.PositiveInfinity");
			}
			else if (float.IsNegativeInfinity(f))
			{
				formattedGraph.AddFragment("Single.NegativeInfinity");
			}
			else if (float.IsNaN(f))
			{
				formattedGraph.AddFragment(f.ToString(CultureInfo.InvariantCulture));
			}
			else
			{
				formattedGraph.AddFragment(f.ToString("R", CultureInfo.InvariantCulture) + "F");
			}
		}
	}
}
