using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;

namespace Assets.Scripts.Craft
{
	public class RequiredModInfo
	{
		public string Author { get; private set; }

		public DateTime LastModified { get; private set; }

		public string Name { get; private set; }

		public ulong? SteamWorkshopItemId { get; private set; }

		public Version Version { get; private set; }

		public RequiredModInfo(string name, string author, Version version, DateTime lastModified, ulong? steamWorkshopId)
		{
			Name = name;
			Author = author;
			Version = version;
			LastModified = lastModified;
			SteamWorkshopItemId = steamWorkshopId;
		}

		public static XElement GenerateXml(IEnumerable<RequiredModInfo> requiredMods)
		{
			return new XElement("RequiredMods", requiredMods.Select((RequiredModInfo x) => x.GenerateXml()));
		}

		public XElement GenerateXml()
		{
			return new XElement("RequiredMod", new XAttribute("name", Name), new XAttribute("author", Author), new XAttribute("version", Version.ToString()), new XAttribute("lastModified", LastModified), SteamWorkshopItemId.HasValue ? new XAttribute("steamWorkshopItemId", SteamWorkshopItemId.Value) : null);
		}
	}
}
