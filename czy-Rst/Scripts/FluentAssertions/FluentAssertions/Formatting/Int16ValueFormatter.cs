using System.Globalization;

namespace FluentAssertions.Formatting
{
	public class Int16ValueFormatter : IValueFormatter
	{
		public bool CanHandle(object value)
		{
			return value is short;
		}

		public void Format(object value, FormattedObjectGraph formattedGraph, FormattingContext context, FormatChild formatChild)
		{
			formattedGraph.AddFragment(((short)value).ToString(CultureInfo.InvariantCulture) + "s");
		}
	}
}
