using System.Globalization;

namespace FluentAssertions.Formatting
{
	public class DecimalValueFormatter : IValueFormatter
	{
		public bool CanHandle(object value)
		{
			return value is decimal;
		}

		public void Format(object value, FormattedObjectGraph formattedGraph, FormattingContext context, FormatChild formatChild)
		{
			formattedGraph.AddFragment(((decimal)value).ToString(CultureInfo.InvariantCulture) + "M");
		}
	}
}
