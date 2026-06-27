using System;
using System.Xml.Linq;
using FluentAssertions.Common;

namespace FluentAssertions.Formatting
{
	public class XElementValueFormatter : IValueFormatter
	{
		public bool CanHandle(object value)
		{
			return value is XElement;
		}

		public void Format(object value, FormattedObjectGraph formattedGraph, FormattingContext context, FormatChild formatChild)
		{
			XElement xElement = (XElement)value;
			formattedGraph.AddFragment(xElement.HasElements ? FormatElementWithChildren(xElement) : FormatElementWithoutChildren(xElement));
		}

		private static string FormatElementWithoutChildren(XElement element)
		{
			return element.ToString().EscapePlaceholders();
		}

		private static string FormatElementWithChildren(XElement element)
		{
			string[] array = SplitIntoSeparateLines(element);
			string text = array[0].RemoveNewLines();
			string text2 = array[^1].RemoveNewLines();
			return (text + "…" + text2).EscapePlaceholders();
		}

		private static string[] SplitIntoSeparateLines(XElement element)
		{
			return SystemExtensions.Split(element.ToString(), Environment.NewLine);
		}
	}
}
