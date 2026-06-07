using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Xml.Linq;
using ModApi.Common.Extensions;
using ModApi.Mods;
using UnityEngine;

namespace ModApi.CelestialData
{
	public class CelestialBodyFileData : ICelestialObjectFileData
	{
		public string Author { get; }

		public string Description { get; }

		public Guid FileId { get; }

		public bool HashReferencesOnly
		{
			get
			{
				if (SupportFileReferences.Count != 0)
				{
					return SupportFileReferences.Values.All((CelestialFileReference x) => x.FileId.HasValue && x.FilePath == null);
				}
				return true;
			}
		}

		public bool IsLatestVersion { get; set; }

		public bool IsTemplate { get; }

		public string Name { get; }

		public RequiredModsData RequiredMods { get; }

		public IReadOnlyDictionary<string, CelestialFileReference> SupportFileReferences { get; }

		public CelestialBodyFileData UpgradeVersion { get; set; }

		ICelestialObjectFileData ICelestialObjectFileData.UpgradeVersion
		{
			get
			{
				return UpgradeVersion;
			}
			set
			{
				UpgradeVersion = (CelestialBodyFileData)value;
			}
		}

		public Version Version { get; }

		public string VersionTag { get; }

		public CelestialBodyFileData(CelestialFile file)
		{
			XDocument xDocument = XDocument.Load(file.Path.FullPath);
			FileId = file.Id;
			Name = (string)xDocument.Root.Attribute("name");
			Author = ((string)xDocument.Root.Attribute("author")) ?? "Unknown";
			Version = xDocument.Root.GetVersionAttribute("version", new Version(1, 0));
			VersionTag = (string)xDocument.Root.Attribute("versionTag");
			IsTemplate = (bool?)xDocument.Root.Attribute("isTemplate") == true;
			Description = xDocument.Root.Element("Description")?.Value;
			SupportFileReferences = (from x in xDocument.Root.Elements("FileReferences").Elements("File")
				select new CelestialFileReference(x)).ToDictionary((CelestialFileReference x) => x.LocalId, (CelestialFileReference x) => x);
			RequiredMods = new RequiredModsData(xDocument.Root.Element("RequiredMods"));
			if (string.IsNullOrWhiteSpace(VersionTag))
			{
				VersionTag = Name;
			}
		}

		public CelestialBodyFileData(XElement xml, Guid? fileId = null)
		{
			FileId = (fileId.HasValue ? fileId.Value : xml.GetGuidAttribute("fileId", Guid.Empty));
			Name = xml.GetStringAttribute("name");
			Author = xml.GetStringAttribute("author", "Unknown");
			Version = xml.GetVersionAttribute("version", new Version(1, 0));
			VersionTag = (string)xml.Attribute("versionTag");
			IsTemplate = (bool?)xml.Attribute("isTemplate") == true;
			Description = xml.Element("Description")?.Value;
			SupportFileReferences = (from x in xml.Elements("FileReferences").Elements("File")
				select CelestialFileReference.LoadFromXml(x)).ToDictionary((CelestialFileReference x) => x.LocalId, (CelestialFileReference x) => x);
			RequiredMods = new RequiredModsData(xml.Element("RequiredMods"));
			if (string.IsNullOrWhiteSpace(VersionTag))
			{
				VersionTag = Name;
			}
		}

		public static CelestialBodyFileData LoadFromXml(XElement element, Guid? fileId = null)
		{
			return new CelestialBodyFileData(element, fileId);
		}

		public Guid GetHashBasedFileId()
		{
			if (HashReferencesOnly)
			{
				return FileId;
			}
			CelestialDatabase celestialDatabase = Game.Instance.CelestialDatabase;
			CelestialFile file = celestialDatabase.GetFile(FileId);
			if (file == null)
			{
				string message = $"Unable to find celestial database file with id '{FileId}'";
				Debug.LogError(message);
				throw new Exception(message);
			}
			XDocument xDocument = XDocument.Load(file.Path.FullPath);
			XElement xElement = xDocument.Root.Element("FileReferences");
			if (xElement == null)
			{
				return FileId;
			}
			List<CelestialFileReference> list = (from x in xElement.Elements("File")
				select CelestialFileReference.LoadFromXml(x)).ToList();
			if (list.Count == 0)
			{
				return FileId;
			}
			List<CelestialFileReference> list2 = new List<CelestialFileReference>(list.Count);
			foreach (CelestialFileReference item in list)
			{
				CelestialFile file2 = celestialDatabase.GetFile(item);
				if (file2 == null)
				{
					string message2 = $"Unable to find celestial database file: {item}";
					Debug.LogError(message2);
					throw new Exception(message2);
				}
				list2.Add(CelestialFileReference.CreateWithFileId(item.LocalId, file2.Id));
			}
			xElement.RemoveAll();
			xElement.Add(list2.Select((CelestialFileReference x) => x.SaveToXml("File")));
			using MemoryStream memoryStream = new MemoryStream();
			xDocument.Save(memoryStream);
			memoryStream.Position = 0L;
			return CelestialFileIdGenerator.GenerateId(memoryStream, CelestialFileType.CelestialBody);
		}

		public CelestialFile GetSupportFile(string localId)
		{
			if (!SupportFileReferences.TryGetValue(localId, out var value))
			{
				return null;
			}
			return Game.Instance.CelestialDatabase.GetFile(value);
		}

		public XElement SaveToXml(string elementName)
		{
			return new XElement(elementName, new XAttribute("fileId", FileId), new XAttribute("name", Name), new XAttribute("author", Author), new XAttribute("version", Version?.ToString() ?? "1.0"), new XAttribute("versionTag", string.IsNullOrWhiteSpace(VersionTag) ? Name : VersionTag), IsTemplate ? new XAttribute("isTemplate", IsTemplate) : null, new XElement("Description", Description ?? string.Empty), new XElement("FileReferences", SupportFileReferences.Values.Select((CelestialFileReference x) => x.SaveToXml("File"))), RequiredMods.GenerateXml());
		}
	}
}
