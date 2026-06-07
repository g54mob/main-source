using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Xml;
using System.Xml.Linq;
using ModApi.Common.Extensions;
using UnityEngine;

namespace ModApi.CelestialData
{
	public class CelestialDatabase
	{
		public enum CelestialDatabaseLogLevel
		{
			None = 0,
			Minimal = 1,
			Standard = 2,
			Verbose = 3
		}

		public class CelestialDatabasePaths
		{
			public class GameDataPaths
			{
				public string CelestialBodies { get; }

				public string DatabaseXml { get; }

				public string GeneratedData { get; }

				public string PlanetarySystems { get; }

				public string Root { get; }

				public string SupportFiles { get; }

				public string UploadTemp { get; }

				public GameDataPaths(string rootPath)
				{
					Root = Path.Combine(rootPath, "CelestialDatabase");
					DatabaseXml = Path.Combine(Root, "CelestialDatabase.xml");
					GeneratedData = Path.Combine(Root, "GeneratedData");
					PlanetarySystems = Path.Combine(Root, "PlanetarySystems");
					CelestialBodies = Path.Combine(Root, "CelestialBodies");
					SupportFiles = Path.Combine(Root, "SupportFiles");
					UploadTemp = Path.Combine(Root, "TempUpload");
				}
			}

			public class StreamingAssetsPaths
			{
				public string Root { get; }

				public string StockFilesXml { get; }

				public StreamingAssetsPaths()
				{
					Root = "CelestialDatabase/";
					StockFilesXml = Root + "StockFileList.xml";
				}
			}

			public class UserDataPaths
			{
				public string CelestialBodies { get; }

				public string PlanetarySystems { get; }

				public string Root { get; }

				public string SupportFiles { get; }

				public UserDataPaths(string rootPath)
				{
					Root = Path.Combine(rootPath, "CelestialDatabase");
					PlanetarySystems = Path.Combine(Root, "PlanetarySystems");
					CelestialBodies = Path.Combine(Root, "CelestialBodies");
					SupportFiles = Path.Combine(Root, "SupportFiles");
				}
			}

			public GameDataPaths GameData { get; }

			public StreamingAssetsPaths StreamingAssets { get; }

			public UserDataPaths UserData { get; }

			public CelestialDatabasePaths(string userDataPath, string gameDataPath)
			{
				UserData = new UserDataPaths(userDataPath);
				GameData = new GameDataPaths(gameDataPath);
				StreamingAssets = new StreamingAssetsPaths();
			}
		}

		public class CelestialDatabaseSpecialFile
		{
			public Guid Id { get; }

			public string RelativePath { get; }

			public CelestialDatabaseSpecialFile(string relativePath, Guid id)
			{
				RelativePath = relativePath;
				Id = id;
			}
		}

		public class CelestialDatabaseSpecialFiles
		{
			private List<CelestialDatabaseSpecialFile> _allFiles;

			public IReadOnlyList<CelestialDatabaseSpecialFile> AllFiles => _allFiles;

			public CelestialDatabaseSpecialFile CelestialBodyCubemapModifierTemp { get; }

			public CelestialDatabaseSpecialFile PlanetStudioCelestialBody { get; }

			public CelestialDatabaseSpecialFile PlanetStudioPlanetarySystem { get; }

			public CelestialDatabaseSpecialFiles(CelestialDatabase database)
			{
				_allFiles = new List<CelestialDatabaseSpecialFile>();
				PlanetStudioCelestialBody = Create(database, (CelestialDatabasePaths.GameDataPaths x) => x.CelestialBodies, "__PlanetStudioCelestialBody.xml", "00000000-0000-0000-0000-000000000001");
				CelestialBodyCubemapModifierTemp = Create(database, (CelestialDatabasePaths.GameDataPaths x) => x.CelestialBodies, "__CelestialBodyCubemapModifierTemp.xml", "00000000-0000-0000-0000-000000000003");
				PlanetStudioPlanetarySystem = Create(database, (CelestialDatabasePaths.GameDataPaths x) => x.PlanetarySystems, "__PlanetStudioPlanetarySystem.xml", "f330407c-ff31-640c-697f-8c42c9deaf11");
			}

			private CelestialDatabaseSpecialFile Create(CelestialDatabase database, Func<CelestialDatabasePaths.GameDataPaths, string> directorySelector, string fileName, string fileId)
			{
				CelestialDatabaseSpecialFile celestialDatabaseSpecialFile = new CelestialDatabaseSpecialFile(CelestialFilePath.FromFullPath(Path.Combine(directorySelector(database.Paths.GameData), fileName)).RelativePath, Guid.Parse(fileId));
				_allFiles.Add(celestialDatabaseSpecialFile);
				return celestialDatabaseSpecialFile;
			}
		}

		protected class StockFileInfo
		{
			public Guid FileId { get; }

			public string LegacyPath { get; }

			public string StreamingAssetsPath { get; }

			public CelestialFileType Type { get; }

			public StockFileInfo(Guid fileId, CelestialFileType type, string legacyPath, string streamingAssetsPath)
			{
				FileId = fileId;
				Type = type;
				LegacyPath = legacyPath;
				StreamingAssetsPath = streamingAssetsPath;
			}
		}

		private class FilesByPathDictionary : IEnumerable<KeyValuePair<string, CelestialFile>>, IEnumerable
		{
			private Dictionary<string, CelestialFile> _dictionary;

			public int Count => _dictionary.Count;

			public IReadOnlyCollection<CelestialFile> Values => _dictionary.Values;

			public FilesByPathDictionary()
			{
				_dictionary = new Dictionary<string, CelestialFile>();
			}

			public void Add(string relativePath, CelestialFile file)
			{
				_dictionary.Add(ProcessKey(relativePath), file);
			}

			public bool ContainsKey(string relativePath)
			{
				return _dictionary.ContainsKey(ProcessKey(relativePath));
			}

			public IEnumerator<KeyValuePair<string, CelestialFile>> GetEnumerator()
			{
				return _dictionary.GetEnumerator();
			}

			IEnumerator IEnumerable.GetEnumerator()
			{
				return ((IEnumerable)_dictionary).GetEnumerator();
			}

			public bool Remove(string relativePath)
			{
				return _dictionary.Remove(ProcessKey(relativePath));
			}

			public bool TryGetValue(string relativePath, out CelestialFile file)
			{
				return _dictionary.TryGetValue(ProcessKey(relativePath), out file);
			}

			private static string ProcessKey(string key)
			{
				return key?.ToLower();
			}
		}

		public const int CurrentXmlVersion = 3;

		public const string HiddenFilePrefix = "__";

		public const string NewPlanetarySystemFileName = "__new";

		private Dictionary<Guid, CelestialBodyFileData> _celestialBodyFileDatas;

		private Dictionary<Guid, CelestialFile> _filesById;

		private FilesByPathDictionary _filesByPath;

		private Dictionary<Guid, PlanetarySystemFileData> _planetarySystemFileDatas;

		private Dictionary<Guid, SupportFileData> _supportFileDatas;

		public static CelestialDatabaseLogLevel LogLevel { get; set; }

		public IReadOnlyCollection<CelestialBodyFileData> CelestialBodies => _celestialBodyFileDatas.Values;

		public Guid DefaultPlanetarySystemV1Id { get; private set; }

		public Guid DefaultPlanetarySystemV2Id { get; private set; }

		public Guid DefaultSunId { get; private set; }

		public Guid NewPlanetarySystemId { get; private set; }

		public string NewPlanetarySystemPath { get; private set; }

		public CelestialDatabasePaths Paths { get; }

		public IReadOnlyCollection<PlanetarySystemFileData> PlanetarySystems => _planetarySystemFileDatas.Values;

		public CelestialDatabaseSpecialFiles SpecialFiles { get; private set; }

		public IReadOnlyList<Guid> StockFileIds { get; private set; }

		public IReadOnlyCollection<SupportFileData> SupportFiles => _supportFileDatas.Values;

		protected IReadOnlyList<StockFileInfo> StockFiles { get; private set; }

		public event EventHandler<EventArgs> Refreshed;

		private CelestialDatabase()
		{
			LogLevel = (Device.IsUnityEditor ? CelestialDatabaseLogLevel.Minimal : CelestialDatabaseLogLevel.Standard);
			_filesById = new Dictionary<Guid, CelestialFile>();
			_filesByPath = new FilesByPathDictionary();
			_planetarySystemFileDatas = new Dictionary<Guid, PlanetarySystemFileData>();
			_celestialBodyFileDatas = new Dictionary<Guid, CelestialBodyFileData>();
			_supportFileDatas = new Dictionary<Guid, SupportFileData>();
			Paths = new CelestialDatabasePaths(Path.Combine(Game.PersistentDataPath, "UserData/"), Path.Combine(Game.PersistentDataPath, "GameData/"));
		}

		public static CelestialDatabase Create(bool isNewVersion)
		{
			CelestialDatabase celestialDatabase = new CelestialDatabase();
			celestialDatabase.Initialize(isNewVersion);
			return celestialDatabase;
		}

		public static void Log(string message, CelestialDatabaseLogLevel logLevel = CelestialDatabaseLogLevel.Standard)
		{
			if (LogLevel >= logLevel)
			{
				UnityEngine.Debug.Log("Celestial Database: " + message);
			}
		}

		public static void LogError(string message, Exception exception = null)
		{
			UnityEngine.Debug.LogError("Celestial Database: " + message);
			if (exception != null)
			{
				UnityEngine.Debug.LogException(exception);
			}
		}

		public Guid AddFile(string filePath, CelestialFileType type, bool isUserData, string fileName)
		{
			byte[] fileData = File.ReadAllBytes(filePath);
			return AddFile(fileData, type, isUserData, fileName);
		}

		public Guid AddFile(XDocument xml, CelestialFileType type, bool isUserData, string fileName)
		{
			using MemoryStream memoryStream = new MemoryStream();
			xml.Save(memoryStream);
			return AddFile(memoryStream.ToArray(), type, isUserData, fileName);
		}

		public Guid AddFile(XElement xml, CelestialFileType type, bool isUserData, string fileName)
		{
			return AddFile(new XDocument(xml), type, isUserData, fileName);
		}

		public Guid AddFile(byte[] fileData, CelestialFileType type, bool isUserData, string fileName)
		{
			Guid guid = CelestialFileIdGenerator.GenerateId(fileData, type);
			CelestialFilePath celestialFilePath = AddFile(guid, type, GetFileDirectory(type, isUserData), fileName, fileData);
			if (celestialFilePath != null)
			{
				CelestialFile file = CelestialFile.Create(celestialFilePath, guid);
				_filesByPath.Add(celestialFilePath.RelativePath, file);
			}
			return guid;
		}

		public void AddOrUpdateFile(CelestialFilePath path, bool refreshDatabase)
		{
			if (!File.Exists(path.FullPath))
			{
				throw new FileNotFoundException("Could not find the celestial database file to add or update.", path.FullPath);
			}
			Guid? specialFileId = GetSpecialFileId(path);
			CelestialFile file = CelestialFile.Create(path, specialFileId);
			_filesByPath.Remove(path.RelativePath);
			_filesByPath.Add(path.RelativePath, file);
			if (specialFileId.HasValue)
			{
				ClearFileData(specialFileId.Value);
			}
			if (refreshDatabase)
			{
				RefreshDatabase();
			}
		}

		public CelestialFile AddSupportFile(string filePath)
		{
			Guid id = CelestialFileIdGenerator.GenerateId(CelestialFilePath.FromFullPath(filePath), CelestialFileType.SupportFile);
			CelestialFile file = GetFile(id);
			if (file == null)
			{
				id = AddFile(filePath, CelestialFileType.SupportFile, isUserData: true, new FileInfo(filePath).Name);
				RefreshDatabase();
				file = GetFile(id);
				if (file == null)
				{
					throw new Exception("An error occurred adding support file '" + filePath + "' to the celestial database.");
				}
			}
			return file;
		}

		public void CleanupGeneratedData(bool forceDeleteAll = false)
		{
			foreach (var directory in CelestialDatabaseGeneratedData.GetDirectories(Paths.GameData.GeneratedData))
			{
				if (!forceDeleteAll && _filesById.ContainsKey(directory.Id))
				{
					continue;
				}
				try
				{
					Directory.Delete(directory.Path, recursive: true);
					if (forceDeleteAll)
					{
						Log("Deleted directory: " + directory.Path);
					}
					else
					{
						Log($"Deleted directory '{directory.Path}' because there are no files with id '{directory.Id}' currently installed.");
					}
				}
				catch (Exception exception)
				{
					LogError("Unable to delete directory '" + directory.Path + "'", exception);
				}
			}
		}

		public void ClearGeneratedData(Guid fileId)
		{
			CelestialDatabaseGeneratedData generatedData = GetGeneratedData(fileId);
			if (Directory.Exists(generatedData.RootPath))
			{
				try
				{
					Directory.Delete(generatedData.RootPath, recursive: true);
				}
				catch (Exception exception)
				{
					LogError("Unable to delete directory '" + generatedData.RootPath + "'", exception);
				}
			}
		}

		public void DeleteFile(CelestialFile file, bool refreshDatabase)
		{
			_filesByPath.Remove(file.Path.RelativePath);
			if (file.Exists)
			{
				File.Delete(file.Path.FullPath);
			}
			if (refreshDatabase)
			{
				RefreshDatabase();
			}
		}

		public List<CelestialFile> GetAllFiles(bool includingDuplicates, CelestialFileType? type)
		{
			if (includingDuplicates)
			{
				return _filesByPath.Values.Where((CelestialFile x) => !type.HasValue || x.Type == type).ToList();
			}
			return _filesById.Values.Where((CelestialFile x) => !type.HasValue || x.Type == type).ToList();
		}

		public CelestialBodyFileData GetCelestialBody(Guid id)
		{
			_celestialBodyFileDatas.TryGetValue(id, out var value);
			return value;
		}

		public CelestialFile GetFile(Guid id)
		{
			_filesById.TryGetValue(id, out var value);
			return value;
		}

		public CelestialFile GetFile(CelestialFileReference fileReference)
		{
			if (fileReference.FilePath != null)
			{
				return GetFile(fileReference.FilePath);
			}
			return GetFile(fileReference.FileId.Value);
		}

		public CelestialFile GetFile(CelestialFilePath filePath)
		{
			_filesByPath.TryGetValue(filePath.RelativePath, out var file);
			return file;
		}

		public CelestialDatabaseGeneratedData GetGeneratedData(Guid associatedFileId)
		{
			return new CelestialDatabaseGeneratedData(Paths.GameData.GeneratedData, associatedFileId);
		}

		public PlanetarySystemFileData GetPlanetarySystem(Guid id)
		{
			_planetarySystemFileDatas.TryGetValue(id, out var value);
			return value;
		}

		public PlanetarySystemFileData GetPlanetarySystem(CelestialFileReference planetarySystemFileReference)
		{
			CelestialFile file = GetFile(planetarySystemFileReference);
			if (file != null)
			{
				return GetPlanetarySystem(file.Id);
			}
			return null;
		}

		public Guid? GetSpecialFileId(CelestialFilePath filePath)
		{
			string relativePath = filePath.RelativePath;
			IReadOnlyList<CelestialDatabaseSpecialFile> allFiles = SpecialFiles.AllFiles;
			int count = allFiles.Count;
			for (int i = 0; i < count; i++)
			{
				if (allFiles[i].RelativePath == relativePath)
				{
					return allFiles[i].Id;
				}
			}
			return null;
		}

		public SupportFileData GetSupportFile(Guid id)
		{
			_supportFileDatas.TryGetValue(id, out var value);
			return value;
		}

		public void Initialize(bool isNewVersion)
		{
			Log("Initializing...", CelestialDatabaseLogLevel.Verbose);
			Stopwatch stopwatch = Stopwatch.StartNew();
			try
			{
				ClearUploadTempDirectory();
				LoadDatabase();
				CreateAllDirectories();
				ConfigureSpecialFiles();
				ScanAllFiles();
				if (isNewVersion)
				{
					RefreshDatabase();
					RemoveStockTemplates();
				}
				InstallStockFiles();
				UpdateDefaultFiles();
				UpgradeAllLegacySolarSystems();
				RefreshDatabase();
				CleanupGeneratedData();
				Log($"Initialization Complete ({stopwatch.Elapsed.TotalSeconds:F2} seconds)", CelestialDatabaseLogLevel.Minimal);
			}
			catch (Exception exception)
			{
				LogError("Error initializing database.", exception);
			}
		}

		public Guid InstallLegacySolarSystem(string solarSystemPath)
		{
			XDocument xDocument = XDocument.Load(solarSystemPath);
			XDocument xDocument2 = new XDocument(new XElement("PlanetarySystem"));
			string text = ((string)xDocument.Root.Attribute("name")) ?? "Unknown Solar System";
			xDocument2.Root.SetAttributeValue("name", text);
			xDocument2.Root.SetAttributeValue("author", "Unknown");
			xDocument2.Root.SetAttributeValue("version", new Version(0, 0).ToString());
			xDocument2.Root.SetAttributeValue("versionTag", string.Empty);
			xDocument2.Root.SetAttributeValue("xmlVersion", 1);
			XElement xElement = new XElement("FileReferences");
			xDocument2.Root.Add(xElement);
			XElement xElement2 = new XElement("CelestialBodies");
			xDocument2.Root.Add(xElement2);
			xDocument2.Root.Add(xDocument.Root.Element("Scale"));
			foreach (XElement item in xDocument.Root.Elements("Planet"))
			{
				XElement xElement3 = XElement.Parse(item.ToString());
				xElement3.Name = "CelestialBody";
				XAttribute xAttribute = xElement3.Attribute("parent");
				xAttribute?.Remove();
				XElement xElement4 = xElement3.Element("Orbit");
				xElement4?.Remove();
				xElement3.Attribute("planetType")?.Remove();
				xElement3.SetAttributeValue("author", "Unknown");
				xElement3.SetAttributeValue("version", new Version(0, 0).ToString());
				xElement3.SetAttributeValue("versionTag", string.Empty);
				xElement3.SetAttributeValue("xmlVersion", 1);
				XElement xElement5 = new XElement("FileReferences");
				xElement3.AddFirst(xElement5);
				foreach (StockFileInfo item2 in StockFiles.Where((StockFileInfo x) => x.Type == CelestialFileType.SupportFile))
				{
					xElement5.Add(new XElement("File", new XAttribute("id", item2.LegacyPath), new XAttribute("hash", item2.FileId)));
				}
				string text2 = ((string)xElement3.Attribute("name")) ?? "Unknown Celestial Body";
				string value = (string)xAttribute;
				if (text2 == "Droo")
				{
					xElement3.Add(new XElement("StructureNodes", XElement.Parse("<StructureNode name=\"Home Base\" prefabPath=\"Flight/GameView/Structures/PrimaryLaunchSite\" latitude=\"0\" longitude=\"0\" elevation=\"-1\" elevationType=\"AboveGroundLevel\" heading=\"0\" />"), XElement.Parse("<StructureNode name=\"Drone Ship\" prefabPath=\"Flight/GameView/Structures/DroneShip\" latitude=\"19.2042547821147\" longitude=\"106.640933206882\" elevation=\"32\" elevationType=\"AboveGroundLevel\" heading=\"0\" />")));
				}
				Guid guid = AddFile(xElement3, CelestialFileType.CelestialBody, isUserData: true, text2 + ".xml");
				xElement.Add(new XElement("File", new XAttribute("id", text2), new XAttribute("hash", guid)));
				xElement2.Add(new XElement("CelestialBody", new XAttribute("id", text2), string.IsNullOrWhiteSpace(value) ? null : new XAttribute("parent", value), new XElement("Data", xElement4)));
			}
			XElement xElement6 = new XElement("LaunchLocations");
			xElement6.Add(XElement.Parse("<LaunchLocation name=\"Launch Pad\" userCreated=\"false\" planetName=\"Droo\" latitude=\"-0.028377192598304107\" longitude=\"-0.015222627428231467\" agl=\"1.2012575913686305\" heading=\"180\" type=\"SurfaceLockedGround\" />"));
			xElement6.Add(XElement.Parse("<LaunchLocation name=\"Runway\" userCreated=\"false\" planetName=\"Droo\" latitude=\"0.01278591598756345\" longitude=\"-0.029757386507285804\" agl=\"1.2036165026947856\" heading=\"270\" type=\"SurfaceLockedGround\" />"));
			xElement6.Add(XElement.Parse("<LaunchLocation name=\"Water\" userCreated=\"false\" planetName=\"Droo\" latitude=\"-0.23527246629746099\" longitude=\"22.659767289163405\" agl=\"0\" heading=\"0\" type=\"SurfaceLockedGround\" />"));
			xElement6.Add(XElement.Parse("<LaunchLocation name=\"Luna\" userCreated=\"false\" planetName=\"Luna\" latitude=\"1.4933557863774731\" longitude=\"91.161143203321316\" agl=\"0\" heading=\"0\" type=\"SurfaceLockedGround\" />"));
			xDocument2.Root.Add(xElement6);
			return AddFile(xDocument2, CelestialFileType.PlanetarySystem, isUserData: true, text + ".xml");
		}

		public bool IsMissingFiles(PlanetarySystemFileData planetarySystem)
		{
			return IsMissingFiles(planetarySystem.FileId);
		}

		public bool IsMissingFiles(CelestialBodyFileData celestialBody)
		{
			return IsMissingFiles(celestialBody.FileId);
		}

		public bool IsMissingFiles(Guid fileId)
		{
			CelestialFile file = GetFile(fileId);
			if (file != null)
			{
				return IsMissingFiles(file);
			}
			return true;
		}

		public bool IsMissingFiles(CelestialFile file)
		{
			if (file.Type == CelestialFileType.PlanetarySystem)
			{
				PlanetarySystemFileData planetarySystem = GetPlanetarySystem(file.Id);
				if (planetarySystem == null)
				{
					LogError($"Missing planetary system data for file: {file.Id}: {file.Path.FullPath}");
					return true;
				}
				return planetarySystem.AllFileReferences.Any((KeyValuePair<string, CelestialFileReference> x) => IsMissingFiles(x.Value));
			}
			if (file.Type == CelestialFileType.CelestialBody)
			{
				CelestialBodyFileData celestialBody = GetCelestialBody(file.Id);
				if (celestialBody == null)
				{
					LogError($"Missing celestial body data for file: {file.Id}: {file.Path.FullPath}");
					return true;
				}
				return celestialBody.SupportFileReferences.Any((KeyValuePair<string, CelestialFileReference> x) => IsMissingFiles(x.Value));
			}
			return false;
		}

		public bool IsMissingFiles(CelestialFileReference fileReference)
		{
			CelestialFile file = GetFile(fileReference);
			if (file != null)
			{
				return IsMissingFiles(file);
			}
			return true;
		}

		public void LogMissingFiles(CelestialFileType fileType, CelestialFileReference fileReference)
		{
			CelestialFile file = GetFile(fileReference);
			if (file == null)
			{
				UnityEngine.Debug.Log($"{fileType}: {((!fileReference.FileId.HasValue) ? fileReference.FilePath.RelativePath : fileReference.FileId.Value.ToString())}");
				return;
			}
			switch (fileType)
			{
			case CelestialFileType.PlanetarySystem:
			{
				PlanetarySystemFileData planetarySystem = GetPlanetarySystem(file.Id);
				foreach (CelestialFileReference value in planetarySystem.CelestialBodyFileReferences.Values)
				{
					LogMissingFiles(CelestialFileType.CelestialBody, value);
				}
				{
					foreach (CelestialFileReference value2 in planetarySystem.SupportFileReferences.Values)
					{
						LogMissingFiles(CelestialFileType.SupportFile, value2);
					}
					break;
				}
			}
			case CelestialFileType.CelestialBody:
			{
				foreach (CelestialFileReference value3 in GetCelestialBody(file.Id).SupportFileReferences.Values)
				{
					LogMissingFiles(CelestialFileType.SupportFile, value3);
				}
				break;
			}
			case CelestialFileType.SupportFile:
				break;
			}
		}

		public void RefreshDatabase()
		{
			Log("Refreshing the database...", CelestialDatabaseLogLevel.Verbose);
			try
			{
				_filesById.Clear();
				foreach (CelestialFile value5 in _filesByPath.Values)
				{
					if (_filesById.TryGetValue(value5.Id, out var value))
					{
						Log("Duplicate file found. File: '" + value.Path.FullPath + "'  Duplicate: " + value5.Path.FullPath);
					}
					else
					{
						_filesById.Add(value5.Id, value5);
					}
				}
				Dictionary<Guid, PlanetarySystemFileData> dictionary = new Dictionary<Guid, PlanetarySystemFileData>(_planetarySystemFileDatas);
				_planetarySystemFileDatas.Clear();
				List<(CelestialFile, PlanetarySystemFileData)> list = new List<(CelestialFile, PlanetarySystemFileData)>();
				foreach (CelestialFile item in _filesById.Values.Where((CelestialFile x) => x.Type == CelestialFileType.PlanetarySystem))
				{
					if (!dictionary.TryGetValue(item.Id, out var value2))
					{
						try
						{
							value2 = new PlanetarySystemFileData(item);
						}
						catch (Exception exception)
						{
							LogError("An error occurred reading planetary system data for file: " + item.Path.FullPath, exception);
							continue;
						}
					}
					_planetarySystemFileDatas.Add(item.Id, value2);
					list.Add((item, value2));
				}
				Dictionary<Guid, CelestialBodyFileData> dictionary2 = new Dictionary<Guid, CelestialBodyFileData>(_celestialBodyFileDatas);
				_celestialBodyFileDatas.Clear();
				List<(CelestialFile, CelestialBodyFileData)> list2 = new List<(CelestialFile, CelestialBodyFileData)>();
				foreach (CelestialFile item2 in _filesById.Values.Where((CelestialFile x) => x.Type == CelestialFileType.CelestialBody))
				{
					if (!dictionary2.TryGetValue(item2.Id, out var value3))
					{
						try
						{
							value3 = new CelestialBodyFileData(item2);
						}
						catch (Exception exception2)
						{
							LogError("An error occurred reading celestial body data for file: " + item2.Path.FullPath, exception2);
							continue;
						}
					}
					_celestialBodyFileDatas.Add(item2.Id, value3);
					list2.Add((item2, value3));
				}
				Dictionary<Guid, SupportFileData> dictionary3 = new Dictionary<Guid, SupportFileData>(_supportFileDatas);
				_supportFileDatas.Clear();
				foreach (CelestialFile item3 in _filesById.Values.Where((CelestialFile x) => x.Type == CelestialFileType.SupportFile))
				{
					if (dictionary3.TryGetValue(item3.Id, out var value4))
					{
						_supportFileDatas.Add(item3.Id, value4);
						continue;
					}
					try
					{
						_supportFileDatas.Add(item3.Id, new SupportFileData(item3, this));
					}
					catch (Exception exception3)
					{
						LogError("An error occurred reading support file data for file: " + item3.Path.FullPath, exception3);
					}
				}
				ConfigureLatestVersionsAndUpgrades(list);
				ConfigureLatestVersionsAndUpgrades(list2);
				Log("Database Refreshed." + Environment.NewLine + $"Planetary Systems: {_planetarySystemFileDatas.Count}{Environment.NewLine}" + $"Celestial Bodies: {_celestialBodyFileDatas.Count}{Environment.NewLine}" + $"Support Files: {_supportFileDatas.Count}{Environment.NewLine}" + $"Total Files: {_filesByPath.Count}");
			}
			catch (Exception exception4)
			{
				LogError("An error occurred refreshing the database.", exception4);
			}
			SaveDatabase();
			this.Refreshed?.Invoke(this, EventArgs.Empty);
		}

		public void ScanAllFiles()
		{
			ScanFiles(Paths.GameData.PlanetarySystems);
			ScanFiles(Paths.GameData.CelestialBodies);
			ScanFiles(Paths.GameData.SupportFiles);
			ScanFiles(Paths.UserData.PlanetarySystems);
			ScanFiles(Paths.UserData.CelestialBodies);
			ScanFiles(Paths.UserData.SupportFiles);
		}

		public void ScanFiles(string directoryPath)
		{
			if (!Directory.Exists(directoryPath))
			{
				LogError("Scan directory does not exist: " + directoryPath);
				return;
			}
			Log("Scan started: " + directoryPath, CelestialDatabaseLogLevel.Verbose);
			try
			{
				string[] files = Directory.GetFiles(directoryPath, "*", SearchOption.AllDirectories);
				foreach (string text in files)
				{
					try
					{
						CelestialFilePath celestialFilePath = CelestialFilePath.FromFullPath(text);
						string relativePath = celestialFilePath.RelativePath;
						DateTime lastWriteTime = File.GetLastWriteTime(text);
						if (_filesByPath.TryGetValue(relativePath, out var file))
						{
							if (file.LastModified == lastWriteTime)
							{
								Log($"File up to date. Path: {relativePath},  Last Modified: {lastWriteTime}", CelestialDatabaseLogLevel.Verbose);
								continue;
							}
							Log($"File changed. Updating database... Path: {relativePath},  Last Modified: {lastWriteTime}", CelestialDatabaseLogLevel.Minimal);
							_filesByPath.Remove(relativePath);
							goto IL_00d8;
						}
						Log($"File added. Updating database... Path: {relativePath},  Last Modified: {lastWriteTime}", CelestialDatabaseLogLevel.Minimal);
						goto IL_00d8;
						IL_00d8:
						Guid? specialFileId = GetSpecialFileId(celestialFilePath);
						CelestialFile file2 = CelestialFile.Create(celestialFilePath, specialFileId);
						_filesByPath.Add(relativePath, file2);
					}
					catch (Exception exception)
					{
						LogError("An error occurred scanning file: " + text, exception);
					}
				}
				Log("Scan finished: " + directoryPath, CelestialDatabaseLogLevel.Verbose);
			}
			catch (Exception exception2)
			{
				LogError("An error occurred scanning files: " + directoryPath, exception2);
			}
		}

		private CelestialFilePath AddFile(Guid id, CelestialFileType type, string directory, string fileName, byte[] fileData, int attempt = 0)
		{
			string path = CelestialFileNameUtility.ToDatabaseFileName(fileName, id, type, attempt);
			CelestialFilePath celestialFilePath = CelestialFilePath.FromFullPath(Path.Combine(directory, path));
			if (_filesByPath.TryGetValue(celestialFilePath.RelativePath, out var file))
			{
				if (file.Id == id)
				{
					Log($"File with ID '{id}' already exists at path '{file.Path.FullPath}'. The file will not be added.");
					return null;
				}
				return AddFile(id, type, directory, fileName, fileData, attempt + 1);
			}
			File.WriteAllBytes(celestialFilePath.FullPath, fileData);
			return celestialFilePath;
		}

		private void ClearFileData(Guid id)
		{
			_planetarySystemFileDatas.Remove(id);
			_celestialBodyFileDatas.Remove(id);
			_supportFileDatas.Remove(id);
		}

		private void ClearUploadTempDirectory()
		{
			try
			{
				if (Directory.Exists(Paths.GameData.UploadTemp))
				{
					Directory.Delete(Paths.GameData.UploadTemp);
				}
			}
			catch (Exception exception)
			{
				UnityEngine.Debug.LogException(exception);
			}
		}

		private void ConfigureLatestVersionsAndUpgrades<T>(List<(CelestialFile File, T Data)> items) where T : class, ICelestialObjectFileData
		{
			List<(CelestialFile File, T Data)> itemsSpecial = items.Where(((CelestialFile File, T Data) x) => x.File.Path.FileName.StartsWith("__")).ToList();
			foreach (var item in itemsSpecial)
			{
				item.Data.IsLatestVersion = true;
				item.Data.UpgradeVersion = null;
			}
			items = items.Where(((CelestialFile File, T Data) x) => !itemsSpecial.Contains(x)).ToList();
			foreach (var item2 in (from x in items
				group x by new
				{
					x.Data.Author,
					x.Data.VersionTag,
					x.File.Path.InGameData
				}).ToList())
			{
				List<IGrouping<Version, (CelestialFile, T)>> list = (from x in item2
					group x by x.Data.Version into x
					orderby x.Key
					select x).ToList();
				IGrouping<Version, (CelestialFile, T)> grouping = list.Last();
				foreach (var item3 in grouping)
				{
					item3.Item2.IsLatestVersion = true;
					item3.Item2.UpgradeVersion = null;
				}
				T val = ((grouping.Count() == 1) ? grouping.First().Item2 : null);
				for (int num = list.Count - 2; num >= 0; num--)
				{
					foreach (var item4 in list[num])
					{
						item4.Item2.IsLatestVersion = false;
						item4.Item2.UpgradeVersion = (item2.Key.InGameData ? val : null);
					}
					if (val == null && list[num].Count() == 1)
					{
						val = list[num].First().Item2;
					}
				}
			}
		}

		private void ConfigureSpecialFiles()
		{
			SpecialFiles = new CelestialDatabaseSpecialFiles(this);
		}

		private void CreateAllDirectories()
		{
			CreateDirectoryIfMissing(Paths.GameData.GeneratedData);
			CreateDirectoryIfMissing(Paths.GameData.PlanetarySystems);
			CreateDirectoryIfMissing(Paths.GameData.CelestialBodies);
			CreateDirectoryIfMissing(Paths.GameData.SupportFiles);
			CreateDirectoryIfMissing(Paths.UserData.PlanetarySystems);
			CreateDirectoryIfMissing(Paths.UserData.CelestialBodies);
			CreateDirectoryIfMissing(Paths.UserData.SupportFiles);
		}

		private void CreateDirectoryIfMissing(string directoryPath)
		{
			try
			{
				DirectoryInfo directoryInfo = new DirectoryInfo(directoryPath);
				if (!directoryInfo.Exists)
				{
					directoryInfo.Create();
				}
			}
			catch (Exception exception)
			{
				LogError("Failed to create directory: " + directoryPath, exception);
			}
		}

		private void DebugLatestVersionsAndUpgrades<T>(List<T> items) where T : ICelestialObjectFileData
		{
			(from x in items
				select GetInfo(x) into x
				orderby x
				select x).Foreach(delegate(string x)
			{
				UnityEngine.Debug.Log(x);
			});
			static string GetInfo(ICelestialObjectFileData x)
			{
				if (x != null)
				{
					return $"{x.Name} ({x.Author}) [{x.VersionTag}] - {x.Version} " + (x.IsLatestVersion ? " Latest" : (" ===> " + GetInfo(x.UpgradeVersion)));
				}
				return "(null)";
			}
		}

		private string GetFileDirectory(CelestialFileType fileType, bool isUserData)
		{
			switch (fileType)
			{
			case CelestialFileType.PlanetarySystem:
				if (!isUserData)
				{
					return Paths.GameData.PlanetarySystems;
				}
				return Paths.UserData.PlanetarySystems;
			case CelestialFileType.CelestialBody:
				if (!isUserData)
				{
					return Paths.GameData.CelestialBodies;
				}
				return Paths.UserData.CelestialBodies;
			case CelestialFileType.SupportFile:
				if (!isUserData)
				{
					return Paths.GameData.SupportFiles;
				}
				return Paths.UserData.SupportFiles;
			default:
				throw new NotSupportedException($"Celestial file type '{fileType}' is not currently supported");
			}
		}

		private string GetFlightStateLegacySolarSystemId(string flightStatePath)
		{
			using (FileStream input = File.Open(flightStatePath, FileMode.Open, FileAccess.Read, FileShare.Read))
			{
				using XmlReader xmlReader = XmlReader.Create(input);
				if (xmlReader.MoveToContent() == XmlNodeType.Element)
				{
					_ = xmlReader.Name;
					if (xmlReader.Name == "FlightState")
					{
						return xmlReader.GetAttribute("solarSystemId");
					}
				}
			}
			return null;
		}

		private string GetLegacySolarSystemId(string legacySolarSystemXmlPath)
		{
			using (FileStream input = File.Open(legacySolarSystemXmlPath, FileMode.Open, FileAccess.Read, FileShare.Read))
			{
				using XmlReader xmlReader = XmlReader.Create(input);
				if (xmlReader.MoveToContent() == XmlNodeType.Element)
				{
					_ = xmlReader.Name;
					if (xmlReader.Name == "SolarSystem")
					{
						return xmlReader.GetAttribute("id");
					}
				}
			}
			return null;
		}

		private void InstallStockFiles()
		{
			Log("Installing stock files...", CelestialDatabaseLogLevel.Verbose);
			try
			{
				HashSet<Guid> hashSet = new HashSet<Guid>();
				foreach (KeyValuePair<string, CelestialFile> item in _filesByPath)
				{
					hashSet.Add(item.Value.Id);
				}
				var enumerable = from x in XDocument.Parse(Utilities.ReadStreamingAssetsFileAsText(Paths.StreamingAssets.StockFilesXml)).Root.Elements().Elements()
					select new
					{
						ID = (Guid)x.Attribute("id"),
						Path = (string)x.Attribute("path"),
						LegacyPath = (string)x.Attribute("legacyPath"),
						Type = (Enum.TryParse<CelestialFileType>(x.Name.LocalName, out var result) ? result : CelestialFileType.Unknown),
						Xml = x
					};
				List<StockFileInfo> list = new List<StockFileInfo>();
				foreach (var item2 in enumerable)
				{
					list.Add(new StockFileInfo(item2.ID, item2.Type, item2.LegacyPath, item2.Path));
					if (!hashSet.Contains(item2.ID))
					{
						if (item2.Type == CelestialFileType.Unknown)
						{
							LogError($"Unknown stock file type: {item2.Xml}");
							continue;
						}
						string fileName = item2.Path.Substring(System.Math.Max(0, item2.Path.LastIndexOf('/')));
						byte[] fileData = Utilities.ReadStreamingAssetsFileAsBytes(Paths.StreamingAssets.Root + item2.Path);
						AddFile(fileData, item2.Type, isUserData: false, fileName);
					}
				}
				StockFiles = list;
				StockFileIds = list.Select((StockFileInfo x) => x.FileId).ToList();
				Log("Stock files installed.", CelestialDatabaseLogLevel.Verbose);
			}
			catch (Exception exception)
			{
				LogError("Error installing stock files.", exception);
			}
		}

		private void LoadCelestialBodyFromXml(XElement celestialBodyXml)
		{
			CelestialBodyFileData celestialBodyFileData = null;
			try
			{
				celestialBodyFileData = CelestialBodyFileData.LoadFromXml(celestialBodyXml);
			}
			catch (Exception exception)
			{
				LogError("Unable to read the celestial body XML: " + celestialBodyXml, exception);
				return;
			}
			try
			{
				_celestialBodyFileDatas.Add(celestialBodyFileData.FileId, celestialBodyFileData);
			}
			catch (Exception exception2)
			{
				LogError($"An error occurred adding celestial body '{celestialBodyFileData.Name}' with id '{celestialBodyFileData.FileId}' to the database.", exception2);
			}
		}

		private void LoadDatabase()
		{
			Log("Loading the database...", CelestialDatabaseLogLevel.Verbose);
			try
			{
				XDocument xDocument = null;
				if (!(Game.Instance.Settings.AppVersionLastRun <= new Version(0, 9, 304, 2)))
				{
					string databaseXml = Paths.GameData.DatabaseXml;
					if (File.Exists(databaseXml))
					{
						try
						{
							xDocument = XDocument.Load(databaseXml);
						}
						catch (Exception exception)
						{
							LogError("An error occurred loading the database XML file", exception);
						}
					}
				}
				if (Game.Instance.Settings.AppVersionLastRun < new Version(0, 9, 920, 0))
				{
					CleanupGeneratedData(forceDeleteAll: true);
				}
				if (xDocument == null)
				{
					xDocument = new XDocument(new XElement("CelestialDatabase"));
				}
				xDocument.Root.GetIntAttribute("xmlVersion", 1);
				_ = 3;
				foreach (XElement item in xDocument.Root.Elements("Files").Elements("File"))
				{
					LoadDatabaseFileFromXml(item);
				}
				foreach (XElement item2 in xDocument.Root.Elements("PlanetarySystems").Elements("PlanetarySystem"))
				{
					LoadPlanetarySystemFromXml(item2);
				}
				foreach (XElement item3 in xDocument.Root.Elements("CelestialBodies").Elements("CelestialBody"))
				{
					LoadCelestialBodyFromXml(item3);
				}
				foreach (XElement item4 in xDocument.Root.Elements("SupportFiles").Elements("SupportFile"))
				{
					LoadSupportFileDataFromXml(item4);
				}
				foreach (CelestialFile item5 in _filesByPath.Values.ToList())
				{
					if (!item5.Exists)
					{
						_filesByPath.Remove(item5.Path.RelativePath);
					}
				}
				Log("Database loaded.", CelestialDatabaseLogLevel.Verbose);
			}
			catch (Exception exception2)
			{
				LogError("An error occurred loading the database.", exception2);
			}
		}

		private void LoadDatabaseFileFromXml(XElement fileXml)
		{
			CelestialFile celestialFile = null;
			try
			{
				celestialFile = CelestialFile.LoadFromXml(fileXml);
			}
			catch (Exception exception)
			{
				LogError("Unable to read file XML: " + fileXml, exception);
				return;
			}
			if (celestialFile == null)
			{
				LogError("Unable to read file XML: " + fileXml);
				return;
			}
			if (celestialFile.Id == Guid.Empty)
			{
				LogError("Could not load the ID from the file XML: " + fileXml);
				return;
			}
			if (celestialFile.Type == CelestialFileType.Unknown)
			{
				LogError("Could not load the type of the file XML: " + fileXml);
				return;
			}
			if (_filesByPath.ContainsKey(celestialFile.Path.RelativePath))
			{
				LogError("File '" + celestialFile.Path.RelativePath + "' could not be added to the database because a file with that path already exists.");
				return;
			}
			try
			{
				_filesByPath.Add(celestialFile.Path.RelativePath, celestialFile);
			}
			catch (Exception exception2)
			{
				LogError("An error occurred adding file '" + celestialFile.Path.RelativePath + "' to the database", exception2);
			}
		}

		private void LoadPlanetarySystemFromXml(XElement planetarySystemXml)
		{
			PlanetarySystemFileData planetarySystemFileData = null;
			try
			{
				planetarySystemFileData = PlanetarySystemFileData.LoadFromXml(planetarySystemXml);
			}
			catch (Exception exception)
			{
				LogError("Unable to read the planetary system XML: " + planetarySystemXml, exception);
				return;
			}
			try
			{
				_planetarySystemFileDatas.Add(planetarySystemFileData.FileId, planetarySystemFileData);
			}
			catch (Exception exception2)
			{
				LogError($"An error occurred adding planetary system '{planetarySystemFileData.Name}' with id '{planetarySystemFileData.FileId}' to the database.", exception2);
			}
		}

		private void LoadSupportFileDataFromXml(XElement supportFileXml)
		{
			SupportFileData supportFileData = null;
			try
			{
				supportFileData = new SupportFileData(supportFileXml);
			}
			catch (Exception exception)
			{
				LogError("Unable to read the support file data XML: " + supportFileXml, exception);
				return;
			}
			try
			{
				_supportFileDatas.Add(supportFileData.FileId, supportFileData);
			}
			catch (Exception exception2)
			{
				LogError($"An error occurred adding support file data '{supportFileData.FriendlyName}' with id '{supportFileData.FileId}' to the database.", exception2);
			}
		}

		private void RemoveStockTemplates()
		{
			foreach (CelestialFile allFile in GetAllFiles(includingDuplicates: false, CelestialFileType.CelestialBody))
			{
				if (allFile.Path.InGameData && GetCelestialBody(allFile.Id).IsTemplate)
				{
					try
					{
						UnityEngine.Debug.Log("Removing stock template at path " + allFile.Path.FullPath);
						DeleteFile(allFile, refreshDatabase: false);
					}
					catch (Exception ex)
					{
						UnityEngine.Debug.LogError("Unable to delete stock template at path " + allFile.Path.FullPath + ".\n" + ex.ToString());
					}
				}
			}
			RefreshDatabase();
		}

		private void SaveDatabase()
		{
			Log("Saving the database...", CelestialDatabaseLogLevel.Verbose);
			try
			{
				new XDocument(new XElement("CelestialDatabase", new XAttribute("xmlVersion", 3), new XElement("Files", _filesByPath.Select((KeyValuePair<string, CelestialFile> x) => x.Value.SaveToXml("File"))), new XElement("PlanetarySystems", _planetarySystemFileDatas.Select((KeyValuePair<Guid, PlanetarySystemFileData> x) => x.Value.SaveToXml("PlanetarySystem"))), new XElement("CelestialBodies", _celestialBodyFileDatas.Select((KeyValuePair<Guid, CelestialBodyFileData> x) => x.Value.SaveToXml("CelestialBody"))), new XElement("SupportFiles", _supportFileDatas.Select((KeyValuePair<Guid, SupportFileData> x) => x.Value.SaveToXml("SupportFile"))))).Save(Paths.GameData.DatabaseXml);
				Log("Database saved.", CelestialDatabaseLogLevel.Verbose);
			}
			catch (Exception exception)
			{
				LogError("An error occurred saving the database.", exception);
			}
		}

		private void UpdateDefaultFiles()
		{
			NewPlanetarySystemId = StockFiles.First((StockFileInfo x) => x.StreamingAssetsPath == "PlanetarySystems/__new.xml").FileId;
			NewPlanetarySystemPath = Path.Combine(Paths.GameData.PlanetarySystems, "__new-{" + NewPlanetarySystemId.ToString() + "}.xml");
			DefaultPlanetarySystemV1Id = StockFiles.First((StockFileInfo x) => x.StreamingAssetsPath == "PlanetarySystems/JunoSystem.xml").FileId;
			DefaultPlanetarySystemV2Id = StockFiles.First((StockFileInfo x) => x.StreamingAssetsPath == "PlanetarySystems/Juno System v2.xml").FileId;
			DefaultSunId = StockFiles.First((StockFileInfo x) => x.StreamingAssetsPath == "CelestialBodies/Juno v2.xml").FileId;
		}

		private void UpgradeAllLegacySolarSystems()
		{
			if (File.Exists(Paths.GameData.DatabaseXml))
			{
				return;
			}
			try
			{
				string path = Path.Combine(Game.PersistentDataPath, "UserData/GameStates/");
				if (Directory.Exists(path))
				{
					string[] files = Directory.GetFiles(path, "SolarSystem.xml", SearchOption.AllDirectories);
					foreach (string solarSystemPath in files)
					{
						UpgradeLegacyFlightStateSolarSystem(solarSystemPath);
					}
				}
				string path2 = Path.Combine(Game.PersistentDataPath, "UserData/SolarSystems/");
				if (Directory.Exists(path2))
				{
					string[] files2 = Directory.GetFiles(path2, "SolarSystem.xml", SearchOption.AllDirectories);
					UpgradeLegacyCommonSolarSystems(files2);
				}
			}
			catch (Exception exception)
			{
				LogError("An error occurred trying to upgrade all legacy solar systems.", exception);
			}
		}

		private void UpgradeLegacyCommonSolarSystems(string[] solarSystemPaths)
		{
			try
			{
				Dictionary<string, Guid> dictionary = new Dictionary<string, Guid>();
				dictionary.Add("__default__", DefaultPlanetarySystemV1Id);
				string[] array = solarSystemPaths;
				foreach (string text in array)
				{
					try
					{
						string legacySolarSystemId = GetLegacySolarSystemId(text);
						if (string.IsNullOrWhiteSpace(legacySolarSystemId))
						{
							LogError("An error occurred trying to read the legacy solar system id for solar system: " + text);
						}
						else if (!(legacySolarSystemId == "__default__"))
						{
							Guid value = InstallLegacySolarSystem(text);
							dictionary.Add(legacySolarSystemId, value);
						}
					}
					catch (Exception exception)
					{
						LogError("An error occurred upgrading legacy common solar system: " + text, exception);
					}
				}
				array = Directory.GetFiles(Path.Combine(Game.PersistentDataPath, "UserData/GameStates/"), "FlightState.xml", SearchOption.AllDirectories);
				foreach (string text2 in array)
				{
					try
					{
						string flightStateLegacySolarSystemId = GetFlightStateLegacySolarSystemId(text2);
						if (flightStateLegacySolarSystemId != null)
						{
							if (!dictionary.ContainsKey(flightStateLegacySolarSystemId))
							{
								LogError("Unable to upgrade flight state '" + text2 + "'. It points to a solar system with id '" + flightStateLegacySolarSystemId + "' that can't be found.");
							}
							else
							{
								XDocument xDocument = XDocument.Load(text2);
								xDocument.Root.Attribute("solarSystemId")?.Remove();
								xDocument.Root.AddFirst(CelestialFileReference.CreateWithFileId(null, dictionary[flightStateLegacySolarSystemId]).SaveToXml("PlanetarySystem"));
								xDocument.Save(text2);
							}
						}
					}
					catch (Exception exception2)
					{
						LogError("An error occurred trying to upgrade flight state: " + text2, exception2);
					}
				}
				array = solarSystemPaths;
				foreach (string obj in array)
				{
					File.Copy(obj, obj + ".backup", overwrite: true);
					File.Delete(obj);
				}
			}
			catch (Exception exception3)
			{
				LogError("An error occurred upgrading legacy common solar systems", exception3);
			}
		}

		private void UpgradeLegacyFlightStateSolarSystem(string solarSystemPath)
		{
			try
			{
				FileInfo fileInfo = new FileInfo(solarSystemPath);
				FileInfo fileInfo2 = new FileInfo(Path.Combine(fileInfo.Directory.FullName, "FlightState.xml"));
				if (!fileInfo2.Exists)
				{
					LogError("Unable to find the flight state associated with the legacy solar system at path: " + fileInfo.FullName);
					return;
				}
				Guid fileId = InstallLegacySolarSystem(solarSystemPath);
				XDocument xDocument = XDocument.Load(fileInfo2.FullName);
				xDocument.Root.Attribute("solarSystemId")?.Remove();
				xDocument.Root.AddFirst(CelestialFileReference.CreateWithFileId(null, fileId).SaveToXml("PlanetarySystem"));
				xDocument.Save(fileInfo2.FullName);
				File.Copy(solarSystemPath, solarSystemPath + ".backup", overwrite: true);
				File.Delete(solarSystemPath);
			}
			catch (Exception exception)
			{
				LogError("An error occurred upgrading legacy flight state solar system: " + solarSystemPath, exception);
			}
		}
	}
}
