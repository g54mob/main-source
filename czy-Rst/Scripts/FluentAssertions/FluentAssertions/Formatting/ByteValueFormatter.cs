using System.Globalization;

namespace FluentAssertions.Formatting
{
	public class ByteValueFormatter : IValueFormatter
	{
		public bool CanHandle(object value)
		{
			return value is byte;
		}

		public void Format(object value, FormattedObjectGraph formattedGraph, FormattingContext context, FormatChild formatChild)
		{
			formattedGraph.AddFragment("0x" + ((byte)value).ToString("X2", CultureInfo.InvariantCulture));
		}
	}
}
