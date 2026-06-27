using System.Globalization;

namespace FluentAssertions.Formatting
{
	public class UInt16ValueFormatter : IValueFormatter
	{
		public bool CanHandle(object value)
		{
			return value is ushort;
		}

		public void Format(object value, FormattedObjectGraph formattedGraph, FormattingContext context, FormatChild formatChild)
		{
			formattedGraph.AddFragment(((ushort)value).ToString(CultureInfo.InvariantCulture) + "us");
		}
	}
}
