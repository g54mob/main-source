using System;
using System.Collections.Generic;
using System.Xml.Linq;
using UnityEngine;

namespace Assets.Scripts.Settings
{
	public class CraftSettings
	{
		private List<string> _discoverable;

		private List<string> _discovered;

		public int DiscoverableCount => _discoverable.Count;

		public int DiscoveredCount => _discovered.Count;

		public bool HasUnsavedChanges { get; private set; }

		public int GetDiscoverableIndex(string id)
		{
			if (!_discoverable.Contains(id))
			{
				return -1;
			}
			return _discoverable.IndexOf(id);
		}

		public bool HasDiscoveredCraft(string id)
		{
			if (_discovered.Contains(id) || !_discoverable.Contains(id))
			{
				return true;
			}
			return false;
		}

		public bool IsUndiscoveredDiscoverable(string id)
		{
			if (id.EndsWith(".xml"))
			{
				string text = id.Replace('\\', '/');
				string text2 = "Stock Craft".Replace('\\', '/') + "/";
				if (text.StartsWith(text2))
				{
					id = text.Substring(text2.Length, text.Length - text2.Length - ".xml".Length);
				}
			}
			if (_discoverable.Contains(id) && !_discovered.Contains(id))
			{
				return true;
			}
			return false;
		}

		public void LoadSettingsFromXml(XElement xml)
		{
			if (_discoverable == null)
			{
				_discoverable = LoadDiscoverableCrafts();
			}
			_discovered = LoadDiscoveredCrafts(xml);
			HasUnsavedChanges = false;
		}

		public XElement SaveXml(XElement xml)
		{
			XElement xElement = new XElement("Discovered");
			foreach (string item in _discovered)
			{
				xElement.Add(new XElement("Craft", new XAttribute("id", item)));
			}
			xml.Add(xElement);
			HasUnsavedChanges = false;
			return xml;
		}

		public void UnlockDiscoverableCraft(string id)
		{
			if (!_discoverable.Contains(id))
			{
				Debug.LogError("\"" + id + "\" is not a discoverable craft and therefore cannot be unlocked as such.");
				return;
			}
			if (_discovered.Contains(id))
			{
				Debug.LogWarning("Already discovered craft \"" + id + "\"");
				return;
			}
			_discovered.Add(id);
			HasUnsavedChanges = true;
		}

		private static List<string> LoadDiscoverableCrafts()
		{
			List<string> list = new List<string>();
			foreach (XElement item in XDocument.Parse(Game.Instance.ResourceLoader.LoadText("Data/DiscoverableCrafts"))?.Elements("Crafts")?.Elements("Craft") ?? Array.Empty<XElement>())
			{
				string stringAttribute = item.GetStringAttribute("id");
				list.Add(stringAttribute);
			}
			return list;
		}

		private List<string> LoadDiscoveredCrafts(XElement xml)
		{
			List<string> list = new List<string>();
			foreach (XElement item in xml?.Element("Discovered")?.Elements("Craft") ?? Array.Empty<XElement>())
			{
				string stringAttribute = item.GetStringAttribute("id");
				if (!string.IsNullOrWhiteSpace(stringAttribute))
				{
					list.Add(stringAttribute);
				}
			}
			return list;
		}
	}
}
