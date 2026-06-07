using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Linq;

namespace Namotion.Reflection
{
	internal static class XmlDocsFormatting
	{
		private static readonly Dictionary<XmlDocsFormattingMode, Func<StringBuilder, XElement, StringBuilder>> formattingFunctions = new Dictionary<XmlDocsFormattingMode, Func<StringBuilder, XElement, StringBuilder>>
		{
			{
				XmlDocsFormattingMode.None,
				AppendUnformattedElement
			},
			{
				XmlDocsFormattingMode.Html,
				AppendHtmlFormattedElement
			},
			{
				XmlDocsFormattingMode.Markdown,
				AppendMarkdownFormattedElement
			}
		};

		private static readonly Dictionary<string, Func<StringBuilder, XElement, StringBuilder>> htmlTagMap = new Dictionary<string, Func<StringBuilder, XElement, StringBuilder>>
		{
			{
				"c",
				(StringBuilder sb, XElement e) => AppendSimpleTaggedElement(sb, e, "<pre>", "</pre>")
			},
			{
				"b",
				(StringBuilder sb, XElement e) => AppendSimpleTaggedElement(sb, e, "<strong>", "</strong>")
			},
			{
				"strong",
				(StringBuilder sb, XElement e) => AppendSimpleTaggedElement(sb, e, "<strong>", "</strong>")
			},
			{
				"i",
				(StringBuilder sb, XElement e) => AppendSimpleTaggedElement(sb, e, "<i>", "</i>")
			}
		};

		private static readonly Dictionary<string, Func<StringBuilder, XElement, StringBuilder>> markdownTagMap = new Dictionary<string, Func<StringBuilder, XElement, StringBuilder>>
		{
			{
				"c",
				(StringBuilder sb, XElement e) => AppendSimpleTaggedElement(sb, e, "`", "`")
			},
			{
				"b",
				(StringBuilder sb, XElement e) => AppendSimpleTaggedElement(sb, e, "**", "**")
			},
			{
				"strong",
				(StringBuilder sb, XElement e) => AppendSimpleTaggedElement(sb, e, "**", "**")
			},
			{
				"i",
				(StringBuilder sb, XElement e) => AppendSimpleTaggedElement(sb, e, "*", "*")
			}
		};

		public static StringBuilder AppendFormattedElement(this StringBuilder stringBuilder, XElement element, XmlDocsFormattingMode formattingMode)
		{
			return formattingFunctions[formattingMode](stringBuilder, element);
		}

		private static StringBuilder AppendUnformattedElement(this StringBuilder stringBuilder, XElement element)
		{
			stringBuilder.Append(element.Value);
			return stringBuilder;
		}

		private static StringBuilder AppendHtmlFormattedElement(StringBuilder stringBuilder, XElement element)
		{
			return AppendMapFormattedElement(stringBuilder, element, htmlTagMap);
		}

		private static StringBuilder AppendMarkdownFormattedElement(StringBuilder stringBuilder, XElement element)
		{
			return AppendMapFormattedElement(stringBuilder, element, markdownTagMap);
		}

		private static StringBuilder AppendMapFormattedElement(StringBuilder stringBuilder, XElement element, Dictionary<string, Func<StringBuilder, XElement, StringBuilder>> map)
		{
			if (map.TryGetValue(element.Name.LocalName, out Func<StringBuilder, XElement, StringBuilder> value))
			{
				return value(stringBuilder, element);
			}
			return stringBuilder.AppendUnformattedElement(element);
		}

		private static StringBuilder AppendSimpleTaggedElement(StringBuilder stringBuilder, XElement element, string startTag, string endTag)
		{
			stringBuilder.Append(startTag, element.Value, endTag);
			return stringBuilder;
		}
	}
}
