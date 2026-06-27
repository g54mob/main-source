using System.Globalization;

namespace FluentAssertions.Formatting
{
	public class SByteValueFormatter : IValueFormatter
	{
		public bool CanHandle(object value)
		{
			return value is sbyte;
		}

		public void Format(object value, FormattedObjectGraph formattedGraph, FormattingContext context, FormatChild formatChild)
		{
			formattedGraph.AddFragment(((sbyte)value).ToString(CultureInfo.InvariantCulture) + "y");
		}
	}
}
