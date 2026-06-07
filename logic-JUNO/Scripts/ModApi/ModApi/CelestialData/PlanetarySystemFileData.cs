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
	public class PlanetarySystemFileData : ICelestialObjectFileData
	{
		public IReadOnlyDictionary<string, CelestialFileReference> AllFileReferences { get; }

		public string Author { get; }

		public IReadOnlyDictionary<string, CelestialFileReference> CelestialBodyFileReferences { get; }

		public string Description { get; }

		public Guid FileId { get; }

		public bool HashReferencesOnly
		{
			get
			{
				if (AllFileReferences.Count != 0)
				{
					return AllFileReferences.Values.All((CelestialFileReference x) => x.FileId.HasValue && x.FilePath == null);
				}
				return true;
			}
		}

		public bool IsLatestVersion { get; set; }

		public string Name { get; }

		public RequiredModsData RequiredMods { get; }

		public IReadOnlyDictionary<string, CelestialFileReference> SupportFileReferences { get; }

		public PlanetarySystemFileData UpgradeVersion { get; set; }

		ICelestialObjectFileData ICelestialObjectFileData.UpgradeVersion
		{
			get
			{
				return UpgradeVersion;
			}
			set
			{
				UpgradeVersion = (PlanetarySystemFileData)value;
			}
		}

		public Version Version { get; }

		public string VersionTag { get; }

		public PlanetarySystemFileData(CelestialFile file)
			: this(XDocument.Load(file.Path.FullPath).Root, file.Id)
		{
		}

		public PlanetarySystemFileData(XElement xml)
			: this(xml, xml.GetGuidAttribute("fileId", Guid.Empty))
		{
		}

		private PlanetarySystemFileData(XElement xml, Guid fileId)
		{
			FileId = fileId;
			Name = xml.GetStringAttribute("name");
			Author = xml.GetStringAttribute("author", "Unknown");
			Version = xml.GetVersionAttribute("version", new Version(1, 0));
			VersionTag = xml.GetStringAttribute("versionTag");
			Description = xml.Element("Description")?.Value;
			AllFileReferences = (from x in xml.Elements("FileReferences").Elements("File")
				select CelestialFileReference.LoadFromXml(x)).ToDictionary((CelestialFileReference x) => x.LocalId, (CelestialFileReference x) => x);
			RequiredMods = new RequiredModsData(xml.Element("RequiredMods"));
			if (string.IsNullOrWhiteSpace(VersionTag))
			{
				VersionTag = Name;
			}
			List<string> celestialBodyIds = (from x in xml.Elements("CelestialBodies").Elements("CelestialBody")
				select (string)x.Attribute("id")).ToList();
			CelestialBodyFileReferences = AllFileReferences.Where((KeyValuePair<string, CelestialFileReference> x) => celestialBodyIds.Contains(x.Key)).ToDictionary((KeyValuePair<string, CelestialFileReference> x) => x.Key, (KeyValuePair<string, CelestialFileReference> x) => x.Value);
			SupportFileReferences = AllFileReferences.Where((KeyValuePair<string, CelestialFileReference> x) => !celestialBodyIds.Contains(x.Key)).ToDictionary((KeyValuePair<string, CelestialFileReference> x) => x.Key, (KeyValuePair<string, CelestialFileReference> x) => x.Value);
		}

		public static PlanetarySystemFileData LoadFromXml(XElement element)
		{
			return new PlanetarySystemFileData(element);
		}

		public List<CelestialBodyFileData> GetAllCelestialBodyFileData()
		{
			CelestialDatabase db = Game.Instance.CelestialDatabase;
			return (from x in CelestialBodyFileReferences.Values
				select db.GetFile(x) into x
				where x != null
				select db.GetCelestialBody(x.Id) into x
				where x != null
				select x).ToList();
		}

		public CelestialFile GetCelestialBodyFile(string localId)
		{
			if (!CelestialBodyFileReferences.TryGetValue(localId, out var value))
			{
				return null;
			}
			return Game.Instance.CelestialDatabase.GetFile(value);
		}

		public CelestialBodyFileData GetCelestialBodyFileData(string localId)
		{
			if (CelestialBodyFileReferences.TryGetValue(localId, out var value))
			{
				CelestialDatabase celestialDatabase = Game.Instance.CelestialDatabase;
				CelestialFile file = celestialDatabase.GetFile(value);
				if (file != null)
				{
					return celestialDatabase.GetCelestialBody(file.Id);
				}
				return null;
			}
			return null;
		}

		public Guid GetHashBasedFileId()
		{
			CelestialDatabase celestialDatabase = Game.Instance.CelestialDatabase;
			bool flag = true;
			List<(string, Guid)> list = new List<(string, Guid)>();
			foreach (KeyValuePair<string, CelestialFileReference> allFileReference in AllFileReferences)
			{
				CelestialFile file = celestialDatabase.GetFile(allFileReference.Value);
				if (file == null)
				{
					string message = "Unable to find celestial database file: " + allFileReference.Value.ToString();
					Debug.LogError(message);
					throw new Exception(message);
				}
				Guid guid = file.Id;
				if (CelestialBodyFileReferences.ContainsKey(allFileReference.Key))
				{
					CelestialBodyFileData celestialBody = celestialDatabase.GetCelestialBody(file.Id);
					if (celestialBody == null)
					{
						string message2 = $"Unable to find celestial body data file with id '{file.Id}'";
						Debug.LogError(message2);
						throw new Exception(message2);
					}
					guid = celestialBody.GetHashBasedFileId();
					flag &= guid == celestialBody.FileId;
				}
				list.Add((allFileReference.Value.LocalId, guid));
			}
			if (HashReferencesOnly && flag)
			{
				return FileId;
			}
			CelestialFile file2 = celestialDatabase.GetFile(FileId);
			if (file2 == null)
			{
				string message3 = $"Unable to find celestial database file with id '{FileId}'";
				Debug.LogError(message3);
				throw new Exception(message3);
			}
			XDocument xDocument = XDocument.Load(file2.Path.FullPath);
			XElement xElement = xDocument.Root.Element("FileReferences");
			if (xElement == null)
			{
				return FileId;
			}
			if ((from x in xElement.Elements("File")
				select CelestialFileReference.LoadFromXml(x)).ToList().Count == 0)
			{
				return FileId;
			}
			IEnumerable<CelestialFileReference> source = list.Select<(string, Guid), CelestialFileReference>(((string LocalId, Guid FileId) x) => CelestialFileReference.CreateWithFileId(x.LocalId, x.FileId));
			xElement.RemoveAll();
			xElement.Add(source.Select((CelestialFileReference x) => x.SaveToXml("File")));
			using MemoryStream memoryStream = new MemoryStream();
			xDocument.Save(memoryStream);
			memoryStream.Position = 0L;
			return CelestialFileIdGenerator.GenerateId(memoryStream, CelestialFileType.PlanetarySystem);
		}

		public CelestialFile GetReferencedFile(string localId)
		{
			if (!AllFileReferences.TryGetValue(localId, out var value))
			{
				return null;
			}
			return Game.Instance.CelestialDatabase.GetFile(value);
		}

		public XElement SaveToXml(string elementName)
		{
			return new XElement(elementName, new XAttribute("fileId", FileId), new XAttribute("name", Name), new XAttribute("author", Author), new XAttribute("version", Version?.ToString() ?? "1.0"), new XAttribute("versionTag", string.IsNullOrWhiteSpace(VersionTag) ? Name : VersionTag), new XElement("Description", Description ?? string.Empty), new XElement("FileReferences", AllFileReferences.Values.Select((CelestialFileReference x) => x.SaveToXml("File"))), new XElement("CelestialBodies", CelestialBodyFileReferences.Keys.Select((string x) => new XElement("CelestialBody", new XAttribute("id", x)))), RequiredMods.GenerateXml());
		}
	}
}
