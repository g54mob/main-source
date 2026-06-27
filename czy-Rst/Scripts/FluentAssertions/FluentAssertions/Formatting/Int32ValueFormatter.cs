using System.Globalization;

namespace FluentAssertions.Formatting
{
	public class Int32ValueFormatter : IValueFormatter
	{
		public bool CanHandle(object value)
		{
			return value is int;
		}

		public void Format(object value, FormattedObjectGraph formattedGraph, FormattingContext context, FormatChild formatChild)
		{
			formattedGraph.AddFragment(((int)value).ToString(CultureInfo.InvariantCulture));
		}
	}
}
