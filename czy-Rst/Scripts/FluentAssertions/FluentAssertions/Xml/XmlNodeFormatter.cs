using System;
using System.Xml;
using FluentAssertions.Common;
using FluentAssertions.Formatting;

namespace FluentAssertions.Xml
{
	public class XmlNodeFormatter : IValueFormatter
	{
		public bool CanHandle(object value)
		{
			return value is XmlNode;
		}

		public void Format(object value, FormattedObjectGraph formattedGraph, FormattingContext context, FormatChild formatChild)
		{
			string text = ((XmlNode)value).OuterXml;
			if (text.Length > 20)
			{
				text = text.Substring(0, 20).TrimEnd(Array.Empty<char>()) + "…";
			}
			formattedGraph.AddLine(text.EscapePlaceholders());
		}
	}
}
