using System;
using System.Xml.Linq;

namespace Web.Client.Models
{
	public class RequiredModModel
	{
		public string Author { get; private set; }

		public DateTime LastModified { get; private set; }

		public string Name { get; private set; }

		public bool RequiresCodeExecution { get; set; }

		public ulong? SteamWorkshopItemId { get; private set; }

		public string SteamWorkshopLink { get; set; }

		public Version Version { get; private set; }

		public string WebsiteLink { get; set; }

		public RequiredModModel(string name, string author, Version version, DateTime lastModified, ulong? steamWorkshopId, bool requiresCodeExecution)
		{
			Name = name;
			Author = author;
			Version = version;
			LastModified = lastModified;
			SteamWorkshopItemId = steamWorkshopId;
			RequiresCodeExecution = requiresCodeExecution;
		}

		public static RequiredModModel CreateFromXml(XElement xml)
		{
			string name = (string)xml.Attribute("name");
			string author = (string)xml.Attribute("author");
			Version version = new Version((string)xml.Attribute("version"));
			DateTime lastModified = (DateTime)xml.Attribute("lastModified");
			ulong? steamWorkshopId = (ulong?)xml.Attribute("steamWorkshopItemId");
			bool requiresCodeExecution = (bool?)xml.Attribute("requiresCodeExecution") == true;
			return new RequiredModModel(name, author, version, lastModified, steamWorkshopId, requiresCodeExecution);
		}

		public XElement GenerateXml()
		{
			return new XElement("RequiredMod", new XAttribute("name", Name), new XAttribute("author", Author), new XAttribute("version", Version.ToString()), new XAttribute("lastModified", LastModified), SteamWorkshopItemId.HasValue ? new XAttribute("steamWorkshopItemId", SteamWorkshopItemId.Value) : null, new XAttribute("requiresCodeExecution", RequiresCodeExecution));
		}
	}
}
