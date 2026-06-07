using System.Collections.Generic;
using System.Xml;

namespace Tyd
{
	public static class TydXml
	{
		public static TydNode TydNodeFromXmlDocument(XmlDocument xmlDocument)
		{
			return TydNodeFromXmlNode(xmlDocument.DocumentElement);
		}

		public static IEnumerable<TydNode> TydNodesFromXmlDocument(XmlDocument xmlDocument)
		{
			foreach (XmlNode childNode in xmlDocument.DocumentElement.ChildNodes)
			{
				TydNode tydNode = TydNodeFromXmlNode(childNode);
				if (tydNode != null)
				{
					yield return tydNode;
				}
			}
		}

		public static TydNode TydNodeFromXmlNode(XmlNode xmlRoot)
		{
			if (xmlRoot is XmlComment)
			{
				return null;
			}
			string name = ((xmlRoot.Name != "li") ? xmlRoot.Name : null);
			Dictionary<string, string> dictionary = new Dictionary<string, string>();
			XmlAttributeCollection attributes = xmlRoot.Attributes;
			if (attributes != null)
			{
				foreach (XmlAttribute item in attributes)
				{
					dictionary[item.Name] = item.Value;
				}
			}
			if (xmlRoot.ChildNodes.Count == 1 && xmlRoot.FirstChild is XmlText)
			{
				return new TydString(name, xmlRoot.FirstChild.InnerText);
			}
			if (xmlRoot.HasChildNodes && xmlRoot.FirstChild.Name == "li")
			{
				TydList tydList = new TydList(name);
				tydList.SetupAttributes(dictionary);
				{
					foreach (XmlNode childNode in xmlRoot.ChildNodes)
					{
						tydList.AddChild(TydNodeFromXmlNode(childNode));
					}
					return tydList;
				}
			}
			TydTable tydTable = new TydTable(name);
			foreach (XmlNode childNode2 in xmlRoot.ChildNodes)
			{
				tydTable.AddChild(TydNodeFromXmlNode(childNode2));
			}
			return tydTable;
		}
	}
}
