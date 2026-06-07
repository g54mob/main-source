using System;
using System.Collections.Generic;
using System.Xml.Linq;

namespace Web.Client.Models.SimpleRockets
{
	public class CreateResourceFileModel
	{
		public const int CurrentVersion = 1;

		public Guid FileHash { get; set; }

		public bool IsCompressed { get; set; }

		public List<string> RequirementHashes { get; private set; }

		public byte ResourceType { get; set; }

		public int UncompressedFileSizeInBytes { get; set; }

		public int Version { get; set; }

		public CreateResourceFileModel()
		{
			Version = 1;
			RequirementHashes = new List<string>();
		}

		public CreateResourceFileModel(string xmlString)
			: this()
		{
			XElement xElement = XDocument.Parse(xmlString).Element("CreateResourceFile");
			Version = int.Parse(xElement.Attribute("Version").Value);
			FileHash = Guid.Parse(xElement.Attribute("FileHash").Value);
			IsCompressed = (bool?)xElement.Attribute("IsCompressed") == true;
			ResourceType = (byte)((int?)xElement.Attribute("ResourceType")).GetValueOrDefault();
			UncompressedFileSizeInBytes = ((int?)xElement.Attribute("UncompressedFileSizeInBytes")).GetValueOrDefault();
			IEnumerable<XElement> enumerable = xElement.Element("Requirements")?.Elements("Requirement");
			if (enumerable == null)
			{
				return;
			}
			foreach (XElement item in enumerable)
			{
				RequirementHashes.Add(item.Attribute("hash").Value);
			}
		}

		public string GenerateXml()
		{
			XElement xElement = new XElement("CreateResourceFile");
			xElement.SetAttributeValue("Version", Version);
			xElement.SetAttributeValue("FileHash", FileHash.ToString());
			xElement.SetAttributeValue("IsCompressed", IsCompressed);
			xElement.SetAttributeValue("ResourceType", ResourceType);
			xElement.SetAttributeValue("UncompressedFileSizeInBytes", UncompressedFileSizeInBytes);
			XElement xElement2 = new XElement("Requirements");
			xElement.Add(xElement2);
			foreach (string requirementHash in RequirementHashes)
			{
				xElement2.Add(new XElement("Requirement", new XAttribute("hash", requirementHash)));
			}
			return xElement.ToString();
		}
	}
}
