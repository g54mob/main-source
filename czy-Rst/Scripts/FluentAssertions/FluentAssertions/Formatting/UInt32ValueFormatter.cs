using System.Globalization;

namespace FluentAssertions.Formatting
{
	public class UInt32ValueFormatter : IValueFormatter
	{
		public bool CanHandle(object value)
		{
			return value is uint;
		}

		public void Format(object value, FormattedObjectGraph formattedGraph, FormattingContext context, FormatChild formatChild)
		{
			formattedGraph.AddFragment(((uint)value).ToString(CultureInfo.InvariantCulture) + "u");
		}
	}
}
