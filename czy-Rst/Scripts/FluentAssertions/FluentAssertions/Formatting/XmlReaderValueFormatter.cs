using System.Xml;

namespace FluentAssertions.Formatting
{
	public class XmlReaderValueFormatter : IValueFormatter
	{
		public bool CanHandle(object value)
		{
			return value is XmlReader;
		}

		public void Format(object value, FormattedObjectGraph formattedGraph, FormattingContext context, FormatChild formatChild)
		{
			XmlReader xmlReader = (XmlReader)value;
			if (xmlReader.ReadState == ReadState.Initial)
			{
				xmlReader.Read();
			}
			string fragment = "\"" + xmlReader.ReadOuterXml() + "\"";
			formattedGraph.AddFragment(fragment);
		}
	}
}
