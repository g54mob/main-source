using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;

namespace Jundroo.Juicy
{
	public class WidgetStyle
	{
		private static string[] _reservedAttributes = new string[4] { "style", "class", "id", "device" };

		public Dictionary<string, string> Attributes { get; private set; } = new Dictionary<string, string>();

		public List<WidgetStyle> Children { get; } = new List<WidgetStyle>();

		public string Name { get; }

		public string NestedName { get; set; }

		public int Order { get; set; }

		public WidgetStyle(string name)
		{
			Name = name;
		}

		public WidgetStyle(string styleName, XElement e)
		{
			Name = styleName;
			foreach (XAttribute item in e.Attributes())
			{
				string localName = item.Name.LocalName;
				if (!_reservedAttributes.Contains(localName))
				{
					Attributes[localName] = item.Value;
				}
			}
		}

		public void Absorb(WidgetStyle widgetStyle)
		{
			foreach (KeyValuePair<string, string> attribute in widgetStyle.Attributes)
			{
				Attributes[attribute.Key] = attribute.Value;
			}
		}

		public string GetAttribute(string key)
		{
			if (Attributes.TryGetValue(key, out var value))
			{
				return value;
			}
			return null;
		}
	}
}
