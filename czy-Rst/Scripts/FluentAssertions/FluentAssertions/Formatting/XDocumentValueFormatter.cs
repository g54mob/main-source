using System.Xml.Linq;

namespace FluentAssertions.Formatting
{
	public class XDocumentValueFormatter : IValueFormatter
	{
		public bool CanHandle(object value)
		{
			return value is XDocument;
		}

		public void Format(object value, FormattedObjectGraph formattedGraph, FormattingContext context, FormatChild formatChild)
		{
			XDocument xDocument = (XDocument)value;
			if (xDocument.Root != null)
			{
				formatChild("root", xDocument.Root, formattedGraph);
			}
			else
			{
				formattedGraph.AddFragment("[XML document without root element]");
			}
		}
	}
}
