using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Xml;

namespace Loxodon.Framework.Localizations
{
	public class XmlDocumentParser : AbstractDocumentParser
	{
		public XmlDocumentParser()
			: this(null)
		{
		}

		public XmlDocumentParser(List<ITypeConverter> converters)
			: base(converters)
		{
		}

		public override Dictionary<string, object> Parse(Stream input, CultureInfo cultureInfo)
		{
			Dictionary<string, object> dictionary = new Dictionary<string, object>();
			using XmlTextReader xmlTextReader = new XmlTextReader(input);
			string text = null;
			string typeName = null;
			string text2 = null;
			string text3 = null;
			List<string> list = new List<string>();
			while (xmlTextReader.Read())
			{
				switch (xmlTextReader.NodeType)
				{
				case XmlNodeType.Element:
					text = xmlTextReader.Name;
					if (string.IsNullOrEmpty(text) || text.Equals("resources"))
					{
						break;
					}
					if (text.Equals("item"))
					{
						string item = xmlTextReader.ReadElementString();
						list.Add(item);
						break;
					}
					text2 = xmlTextReader.GetAttribute("name");
					if (string.IsNullOrEmpty(text2))
					{
						throw new XmlException("The attribute of name is null.");
					}
					if (text.EndsWith("-array"))
					{
						typeName = text.Replace("-array", "");
						list.Clear();
					}
					else
					{
						typeName = text;
						text3 = xmlTextReader.ReadElementString();
						dictionary[text2] = Parse(typeName, text3);
					}
					break;
				case XmlNodeType.EndElement:
					text = xmlTextReader.Name;
					if (!string.IsNullOrEmpty(text) && text.EndsWith("-array"))
					{
						dictionary[text2] = Parse(typeName, list);
						list.Clear();
					}
					break;
				}
			}
			return dictionary;
		}
	}
}
