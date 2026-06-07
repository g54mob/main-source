using System.Collections.Generic;
using System.Xml.Linq;
using ModApi.Common.Extensions;
using UnityEngine;

namespace Assets.Scripts.Vizzy.UI
{
	public class NodeStyle
	{
		public Color Color { get; private set; }

		public string Format { get; private set; }

		public bool HasDynamicExpressionsSlots { get; private set; }

		public string Id { get; private set; }

		public bool RichText { get; private set; }

		public Color TextColor { get; private set; }

		public string Tooltip { get; private set; }

		public NodeStyle(XElement xml, Dictionary<string, Color> colors)
		{
			Id = xml.GetStringAttribute("id");
			string stringAttribute = xml.GetStringAttribute("color");
			Color = colors[stringAttribute];
			string stringAttribute2 = xml.GetStringAttribute("textColor");
			if (stringAttribute2 != null)
			{
				TextColor = colors[stringAttribute2];
			}
			else
			{
				TextColor = Color.white;
			}
			HasDynamicExpressionsSlots = xml.GetBoolAttribute("dynamicExpressionsSlots");
			Format = xml.GetStringAttribute("format");
			Tooltip = xml.GetStringAttribute("tooltip");
			RichText = xml.GetBoolAttribute("richText");
		}

		public NodeStyle(string id, string format, Color color)
		{
			Id = id;
			Format = format;
			Color = color;
			TextColor = Color.white;
		}
	}
}
