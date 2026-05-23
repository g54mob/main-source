using System.Collections.Generic;
using System.Xml.Linq;

namespace Namotion.Reflection
{
	internal sealed class CachingXDocument
	{
		private static readonly XName XNameDoc = "doc";

		private static readonly XName XNameMembers = "members";

		private static readonly XName XNameMember = "member";

		private static readonly XName XNameName = "name";

		private readonly object _lock = new object();

		private readonly Dictionary<string, XElement?> _elementByNameCache = new Dictionary<string, XElement>();

		private readonly XDocument _document;

		internal CachingXDocument(string? pathToXmlFile)
		{
			XDocument document = XDocument.Load(pathToXmlFile, LoadOptions.PreserveWhitespace);
			_document = document;
		}

		internal XElement? GetXmlDocsElement(string name)
		{
			lock (_lock)
			{
				if (!_elementByNameCache.TryGetValue(name, out XElement value))
				{
					value = GetXmlDocsElement(_document, name);
					_elementByNameCache[name] = value;
				}
				return value;
			}
		}

		internal static XElement? GetXmlDocsElement(XDocument document, string name)
		{
			foreach (XElement item in document.Element(XNameDoc).Element(XNameMembers).Elements(XNameMember))
			{
				if (item.Attribute(XNameName)?.Value == name)
				{
					return item;
				}
			}
			return null;
		}
	}
}
