using System;
using System.Xml.Linq;
using Assets.Scripts.Mods;

namespace Assets.Scripts.Settings
{
	public class EnabledMod
	{
		public DateTime LastUpdated { get; private set; }

		public string Name { get; private set; }

		public string Path { get; private set; }

		public Version Version { get; private set; }

		public EnabledMod(string name, Version version, DateTime lastUpdated, string path)
		{
			Name = name;
			Version = version;
			LastUpdated = lastUpdated;
			Path = path;
		}

		public static EnabledMod ReadXml(XElement xml)
		{
			return new EnabledMod((string)xml.Attribute("name"), new Version((string)xml.Attribute("version")), (DateTime)xml.Attribute("lastUpdated"), (string)xml.Attribute("path"));
		}

		public XElement GenerateXml()
		{
			return new XElement("EnabledMod", new XAttribute("name", Name), new XAttribute("version", Version.ToString()), new XAttribute("lastUpdated", LastUpdated.ToString()), new XAttribute("path", Path));
		}

		public bool IsExactMatch(ModInfo mod, bool ignoreVersionAndDate = false)
		{
			if (Name == mod.Name && Path == mod.Path)
			{
				if (!ignoreVersionAndDate)
				{
					if (Version == mod.Version)
					{
						return LastUpdated == mod.LastUpdated;
					}
					return false;
				}
				return true;
			}
			return false;
		}
	}
}
