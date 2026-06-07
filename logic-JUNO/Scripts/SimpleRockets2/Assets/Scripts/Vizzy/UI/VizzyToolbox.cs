using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;
using ModApi.Common.Extensions;
using ModApi.Craft.Program;
using UnityEngine;

namespace Assets.Scripts.Vizzy.UI
{
	public class VizzyToolbox
	{
		public class NodeCategory
		{
			public string IconPath { get; set; }

			public string Name { get; set; }

			public List<ProgramNode> Nodes { get; private set; } = new List<ProgramNode>();

			public NodeCategory(XElement xml)
			{
				Name = xml.GetStringAttribute("name");
				IconPath = xml.GetStringAttribute("icon");
				foreach (XElement item2 in xml.Elements())
				{
					ProgramNode item = ProgramSerializer.DeserializeProgramNode(item2);
					Nodes.Add(item);
				}
			}
		}

		private Dictionary<string, Color> _colors = new Dictionary<string, Color>();

		private Dictionary<string, NodeStyle> _styles = new Dictionary<string, NodeStyle>();

		public List<NodeCategory> Categories { get; private set; } = new List<NodeCategory>();

		public VizzyToolbox(XElement xml, bool showMfdCategory)
		{
			foreach (XElement item in xml.Element("Colors").Elements())
			{
				string stringAttribute = item.GetStringAttribute("id");
				_colors[stringAttribute] = item.GetColorAttribute("color", Color.magenta, XmlColorFormat.HexRGBA);
			}
			foreach (XElement item2 in xml.Element("Styles").Elements())
			{
				NodeStyle nodeStyle = new NodeStyle(item2, _colors);
				if (!_styles.ContainsKey(nodeStyle.Id))
				{
					_styles[nodeStyle.Id] = nodeStyle;
					continue;
				}
				Debug.LogErrorFormat("Styles dictionary already contains style with ID '{0}'", nodeStyle.Id);
			}
			foreach (XElement item3 in xml.Element("Categories").Elements())
			{
				NodeCategory nodeCategory = new NodeCategory(item3);
				if (nodeCategory.Name != "Multi-function Display" || showMfdCategory)
				{
					Categories.Add(nodeCategory);
				}
			}
		}

		public NodeCategory GetCategory(string category)
		{
			return Categories.Where((NodeCategory x) => x.Name == category).FirstOrDefault();
		}

		public NodeStyle GetStyle(string id)
		{
			if (_styles.ContainsKey(id))
			{
				return _styles[id];
			}
			return null;
		}
	}
}
