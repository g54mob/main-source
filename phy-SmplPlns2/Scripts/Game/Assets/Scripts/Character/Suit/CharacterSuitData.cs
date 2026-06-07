using System;
using System.Collections.Generic;
using System.Xml.Linq;
using Jundroo.Common.Utils;
using UnityEngine;

namespace Assets.Scripts.Character.Suit
{
	[Serializable]
	public class CharacterSuitData
	{
		[Serializable]
		public class CharacterSuitItemData
		{
			public List<SuitItemDataColor> Colors = new List<SuitItemDataColor>();

			public bool Enabled;

			public string Name;

			public XElement GenerateXml()
			{
				XElement xElement = new XElement("Item", new XAttribute("name", Name), new XAttribute("enabled", Enabled.ToString()));
				for (int i = 0; i < Colors.Count; i++)
				{
					xElement.Add(new XElement("Color", new XAttribute("index", Colors[i].Index.ToString()), new XAttribute("value", Colors[i].Color.ToXAttributeValue(ColorStringFormat.HexRGB))));
				}
				return xElement;
			}

			public void RestoreFromXml(XElement xml, int xmlVersion = 0)
			{
				Name = xml.GetStringAttribute("name");
				Enabled = xml.GetBoolAttribute("enabled");
				if (Name == "Shoulder Pads")
				{
					Name = "Epaulets";
				}
				Colors.Clear();
				foreach (XElement item in xml.Elements("Color"))
				{
					if (ColorsUtility.TryParse(item.Attribute("value").Value, ColorStringFormat.HexRGB, out var color))
					{
						SuitItemDataColor suitItemDataColor = new SuitItemDataColor();
						suitItemDataColor.Color = color;
						suitItemDataColor.Index = item.GetIntAttribute("index");
						if (xmlVersion == 0)
						{
							suitItemDataColor.Index++;
						}
						Colors.Add(suitItemDataColor);
					}
					else
					{
						Debug.Log("Invalid CharacterSuitItem Color: " + item.Attribute("value").Value);
					}
				}
			}
		}

		[Serializable]
		public class SuitItemDataColor
		{
			public Color Color;

			public int Index;
		}

		public const int CurrentXmlVersion = 1;

		public List<CharacterSuitItemData> Items = new List<CharacterSuitItemData>();

		public XElement GenerateXml(string name)
		{
			XElement xElement = new XElement("Config");
			xElement.Add(new XAttribute("name", name));
			xElement.Add(new XAttribute("xmlVersion", 1));
			foreach (CharacterSuitItemData item in Items)
			{
				xElement.Add(item.GenerateXml());
			}
			return xElement;
		}

		public void RestoreFromXml(XElement xml)
		{
			Items.Clear();
			int intAttribute = xml.GetIntAttribute("xmlVersion");
			foreach (XElement item in xml.Elements("Item"))
			{
				CharacterSuitItemData characterSuitItemData = new CharacterSuitItemData();
				characterSuitItemData.RestoreFromXml(item, intAttribute);
				Items.Add(characterSuitItemData);
			}
		}
	}
}
