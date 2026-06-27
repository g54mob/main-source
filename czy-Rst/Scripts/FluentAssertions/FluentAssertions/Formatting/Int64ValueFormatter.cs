using System.Globalization;

namespace FluentAssertions.Formatting
{
	public class Int64ValueFormatter : IValueFormatter
	{
		public bool CanHandle(object value)
		{
			return value is long;
		}

		public void Format(object value, FormattedObjectGraph formattedGraph, FormattingContext context, FormatChild formatChild)
		{
			formattedGraph.AddFragment(((long)value).ToString(CultureInfo.InvariantCulture) + "L");
		}
	}
}
