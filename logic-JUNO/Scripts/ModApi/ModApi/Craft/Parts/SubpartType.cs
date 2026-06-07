using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;
using UnityEngine;

namespace ModApi.Craft.Parts
{
	[Serializable]
	public class SubpartType
	{
		public class SubpartTypeXmlNames
		{
			public string Base { get; private set; }

			public string Style { get; private set; }

			public string TextureOffset { get; private set; }

			public string TextureStyle { get; private set; }

			public string TextureTiling { get; private set; }

			public SubpartTypeXmlNames(string baseName)
			{
				bool flag = string.IsNullOrWhiteSpace(baseName);
				Base = (flag ? string.Empty : baseName);
				Style = (flag ? "style" : (baseName + "Style"));
				TextureStyle = (flag ? "texture" : (baseName + "Texture"));
				TextureTiling = (flag ? "textureTiling" : (baseName + "TextureTiling"));
				TextureOffset = (flag ? "textureOffset" : (baseName + "TextureOffset"));
			}
		}

		[SerializeField]
		[Tooltip("The display name for the subpart type.")]
		private string _displayName;

		[SerializeField]
		[Tooltip("The base XML name of the subpart type.")]
		private string _xmlName;

		private SubpartTypeXmlNames _xmlNames;

		public static int MaxCountPerPart { get; private set; }

		public string DisplayName => _displayName;

		public SubpartTypeXmlNames XmlNames
		{
			get
			{
				if (_xmlNames == null)
				{
					_xmlNames = new SubpartTypeXmlNames(_xmlName);
				}
				return _xmlNames;
			}
		}

		public static SubpartType Create(string xmlName, string displayName)
		{
			return new SubpartType
			{
				_xmlName = xmlName,
				_xmlNames = new SubpartTypeXmlNames(xmlName),
				_displayName = displayName
			};
		}

		public static List<SubpartType> CreateFromXml(XElement xml, bool createDefault = false)
		{
			List<SubpartType> list;
			if (xml == null)
			{
				list = new List<SubpartType>(0);
			}
			else
			{
				List<XElement> list2 = xml.Elements("SubpartTypes").Elements("SubpartType").ToList();
				list = new List<SubpartType>(new SubpartType[list2.Count]);
				foreach (XElement item in list2)
				{
					int index = (int)item.Attribute("index");
					SubpartType value = Create((string)item.Attribute("xmlName"), (string)item.Attribute("displayName"));
					list[index] = value;
				}
			}
			if (createDefault && list.Count == 0)
			{
				list.Add(Create(string.Empty, "Part"));
			}
			MaxCountPerPart = System.Math.Max(MaxCountPerPart, list.Count);
			return list;
		}

		public static void SaveToXml(XElement xml, IReadOnlyList<SubpartType> items)
		{
			if (items != null && items.Count != 0)
			{
				XElement xElement = new XElement("SubpartTypes");
				xml.Add(xElement);
				for (int i = 0; i < items.Count; i++)
				{
					xElement.Add(new XElement("SubpartType", new XAttribute("index", i), new XAttribute("xmlName", items[i]._xmlName), new XAttribute("displayName", items[i].DisplayName)));
				}
			}
		}
	}
}
