using System.Globalization;

namespace FluentAssertions.Formatting
{
	public class UInt64ValueFormatter : IValueFormatter
	{
		public bool CanHandle(object value)
		{
			return value is ulong;
		}

		public void Format(object value, FormattedObjectGraph formattedGraph, FormattingContext context, FormatChild formatChild)
		{
			formattedGraph.AddFragment(((ulong)value).ToString(CultureInfo.InvariantCulture) + "UL");
		}
	}
}
