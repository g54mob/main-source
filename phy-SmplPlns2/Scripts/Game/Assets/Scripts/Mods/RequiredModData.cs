using System;
using System.Xml.Linq;

namespace Assets.Scripts.Mods
{
	public class RequiredModData
	{
		public const string XmlElementName = "RequiredMod";

		public string Author { get; private set; }

		public DateTime LastModified { get; private set; }

		public string Name { get; private set; }

		public bool RequiresCodeExecution { get; set; }

		public ulong? SteamWorkshopItemId { get; private set; }

		public Version Version { get; private set; }

		public RequiredModData(XElement xml)
		{
			Name = (string)xml.Attribute("name");
			Author = (string)xml.Attribute("author");
			Version = new Version((string)xml.Attribute("version"));
			LastModified = (DateTime)xml.Attribute("lastModified");
			SteamWorkshopItemId = (ulong?)xml.Attribute("steamWorkshopItemId");
			RequiresCodeExecution = (bool)xml.Attribute("requiresCodeExecution");
		}

		public RequiredModData(RequiredMod requiredMod)
		{
			ModInfo mod = requiredMod.Mod;
			Name = mod.Name;
			Author = mod.Author;
			Version = mod.Version;
			LastModified = mod.LastUpdated;
			SteamWorkshopItemId = mod.SteamWorkshopItemId;
			RequiresCodeExecution = requiredMod.RequiresCodeExecution;
		}

		public RequiredModData(ModInfo modInfo, bool requiresCodeExecution)
			: this(modInfo.Name, modInfo.Author, modInfo.Version, modInfo.LastUpdated, modInfo.SteamWorkshopItemId, requiresCodeExecution)
		{
		}

		public RequiredModData(string name, string author, Version version, DateTime lastModified, ulong? steamWorkshopId, bool requiresCodeExecution)
		{
			Name = name;
			Author = author;
			Version = version;
			LastModified = lastModified;
			SteamWorkshopItemId = steamWorkshopId;
			RequiresCodeExecution = requiresCodeExecution;
		}

		public XElement GenerateXml()
		{
			return new XElement("RequiredMod", new XAttribute("name", Name), new XAttribute("author", Author), new XAttribute("version", Version.ToString()), new XAttribute("lastModified", LastModified), (!SteamWorkshopItemId.HasValue) ? null : new XAttribute("steamWorkshopItemId", SteamWorkshopItemId.Value), new XAttribute("requiresCodeExecution", RequiresCodeExecution));
		}
	}
}
