using System.Xml.Linq;

namespace FluentAssertions.Formatting
{
	public class XAttributeValueFormatter : IValueFormatter
	{
		public bool CanHandle(object value)
		{
			return value is XAttribute;
		}

		public void Format(object value, FormattedObjectGraph formattedGraph, FormattingContext context, FormatChild formatChild)
		{
			formattedGraph.AddFragment(((XAttribute)value).ToString());
		}
	}
}
