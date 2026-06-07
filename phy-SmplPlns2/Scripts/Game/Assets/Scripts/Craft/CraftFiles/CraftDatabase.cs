using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Linq;
using Assets.Scripts.Craft.CraftFiles.Exceptions;
using Assets.Scripts.Net;
using Assets.Scripts.Settings;
using Assets.Scripts.Storage;
using Cysharp.Threading.Tasks;
using Jundroo.Common.Platform;
using Jundroo.Common.Pool;
using Jundroo.Common.Settings;
using Jundroo.Common.Utils;
using UnityEngine;
using Web.Client.Models;

namespace Assets.Scripts.Craft.CraftFiles
{
	public class CraftDatabase
	{
		private class SubdirectorySorter : IComparer<string>
		{
			public static readonly SubdirectorySorter Default = new SubdirectorySorter();

			public int Compare(string x, string y)
			{
				if (x == "None")
				{
					return -1;
				}
				if (y == "None")
				{
					return 1;
				}
				return string.Compare(x, y, Device.IsWindowsBuild ? StringComparison.OrdinalIgnoreCase : StringComparison.Ordinal);
			}
		}

		private class TagSorter : IComparer<string>
		{
			public static readonly TagSorter Default = new TagSorter();

			public int Compare(string x, string y)
			{
				if (x == "None")
				{
					return -1;
				}
				if (y == "None")
				{
					return 1;
				}
				return string.Compare(x, y, StringComparison.OrdinalIgnoreCase);
			}
		}

		public const string CraftFileExtension = ".xml";

		public const string NoSubdirectoryValue = "None";

		public const string NoTagsValue = "None";

		public const string RequiredCraftSubdirectory = "Required Craft";

		public const string StockCraftSubdirectory = "Stock Craft";

		public static readonly string[] ReadOnlyDirectories = new string[2] { "Stock Craft", "Required Craft" };

		private const string CraftFileBackupExtension = ".bak";

		private const string EditorCraftResourceName = "__editor__";

		private const string LogFilePrefix = "[CraftDatabase] ";

		private const string StockCraftResourcePath = "Data/AircraftDesigns/";

		private const string TagListPath = "Cache/CraftTags.xml";

		private static readonly XmlReaderSettings _xmlReaderSettings = new XmlReaderSettings();

		private readonly object _syncLock = new object();

		private (string Id, XElement Xml)[] _cachedCraftXml;

		private Dictionary<string, CraftFileInfo> _craftFiles;

		private Dictionary<string, List<CraftFileInfo>> _craftFilesBySubdirectory;

		private Dictionary<string, List<CraftFileInfo>> _craftFilesByTag;

		private CraftFilterSettings _filterSettings;

		private List<string> _fullTagList;

		private WebRequest _tagListWebRequest;

		public string CraftFilesRootPath { get; }

		public string CurrentSubdirectoryPath
		{
			get
			{
				StringSetting activeSubdirectory = _filterSettings.ActiveSubdirectory;
				if (activeSubdirectory == null)
				{
					return string.Empty;
				}
				return activeSubdirectory;
			}
			set
			{
				_filterSettings.ActiveSubdirectory.Value = value ?? string.Empty;
				_filterSettings.CommitChanges();
			}
		}

		public bool IsInitialized { get; private set; }

		public bool IsRescanInProgress { get; private set; }

		public event EventHandler<EventArgs> Initialized;

		public CraftDatabase()
		{
			CraftFilesRootPath = Path.GetFullPath(Path.Combine(GameData.PersistentDataPath, Device.IsDemoBuild ? "CraftsDemo" : "Crafts"));
			_craftFiles = new Dictionary<string, CraftFileInfo>(Device.IsWindowsBuild ? StringComparer.OrdinalIgnoreCase : StringComparer.Ordinal);
			_craftFilesByTag = new Dictionary<string, List<CraftFileInfo>>(StringComparer.OrdinalIgnoreCase) { 
			{
				"None",
				new List<CraftFileInfo>()
			} };
			_craftFilesBySubdirectory = new Dictionary<string, List<CraftFileInfo>>(Device.IsWindowsBuild ? StringComparer.OrdinalIgnoreCase : StringComparer.Ordinal) { 
			{
				"None",
				new List<CraftFileInfo>()
			} };
			_fullTagList = new List<string>(CraftTags.WebsiteTags.Count);
			_cachedCraftXml = new(string, XElement)[5];
			_filterSettings = Game.Instance.Settings.Gameplay.CraftFilters;
		}

		public void BeginAsyncInitialization(bool restoreStockCraft, bool restoreRequiredAircraft)
		{
			if (restoreStockCraft || !Directory.Exists(Path.Combine(CraftFilesRootPath, "Stock Craft")))
			{
				RestoreStockCraft();
			}
			if (restoreRequiredAircraft || !Directory.Exists(Path.Combine(CraftFilesRootPath, "Required Craft")))
			{
				Game.Instance.InstallXmlAssetsInFolderToDocuments("Data/RequiredAircraft/", Path.Combine(CraftFilesRootPath, "Required Craft"), overwrite: true);
			}
			InitializeCraftTagList(restoreStockCraft);
			InitializeAsync().Forget();
		}

		public void DeleteCraft(string id)
		{
			CraftFileInfo value = null;
			lock (_syncLock)
			{
				if (!_craftFiles.TryGetValue(id, out value))
				{
					UnityEngine.Debug.LogError("[CraftDatabase] Unable to delete craft file with id '" + id + "' because it could not be found.");
					return;
				}
			}
			DeleteCraft(value);
		}

		public void DeleteCraft(CraftFileInfo craftFile)
		{
			if (!File.Exists(craftFile.FullFilePath))
			{
				UnityEngine.Debug.LogError("[CraftDatabase] Unable to delete craft file at path '" + craftFile.FullFilePath + "' because the file could not be found.");
				return;
			}
			string[] readOnlyDirectories = ReadOnlyDirectories;
			foreach (string text in readOnlyDirectories)
			{
				string fullPath = Path.GetFullPath(Path.Combine(CraftFilesRootPath, text));
				char directorySeparatorChar = Path.DirectorySeparatorChar;
				string value = fullPath + directorySeparatorChar;
				if (craftFile.FullFilePath.StartsWith(value))
				{
					throw new CraftDatabaseException("The '" + text + "' directory is read only.");
				}
			}
			try
			{
				UpdateCraftXmlCache(craftFile.Id, null);
				RemoveCraftFileInfo(craftFile.Id);
				CloudStorageManager.PerformFileBatchAction(delegate
				{
					FileIOUtility.TryDeleteFile(craftFile.FullFilePath + ".bak", FileIOUtility.ExceptionHandling.Throw);
					FileIOUtility.TryDeleteFile(craftFile.FullFilePath, FileIOUtility.ExceptionHandling.Throw);
				});
				UnityEngine.Debug.Log("[CraftDatabase] Deleted craft file: " + craftFile.FullFilePath);
			}
			catch (Exception exception)
			{
				UnityEngine.Debug.LogException(exception);
				UnityEngine.Debug.LogError("[CraftDatabase] An error occurred while trying to delete the craft file at path: " + craftFile.FullFilePath);
			}
		}

		public List<CraftFileInfo> GetCrafts(IList<string> tags = null, IList<string> subdirectories = null)
		{
			lock (_syncLock)
			{
				int num = tags?.Count ?? 0;
				if (num == 0)
				{
					if (subdirectories != null && subdirectories.Count == 1)
					{
						if (_craftFilesBySubdirectory.TryGetValue(subdirectories[0], out var value))
						{
							return new List<CraftFileInfo>(value);
						}
						return new List<CraftFileInfo>(0);
					}
					List<CraftFileInfo> list = new List<CraftFileInfo>(_craftFiles.Values);
					FilterCraftsBySubdirectories(list, subdirectories);
					return list;
				}
				string key = tags[0];
				if (!_craftFilesByTag.TryGetValue(key, out var value2) || value2.Count == 0)
				{
					return new List<CraftFileInfo>(0);
				}
				if (num <= 1)
				{
					List<CraftFileInfo> list2 = new List<CraftFileInfo>(value2);
					FilterCraftsBySubdirectories(list2, subdirectories);
					return list2;
				}
				Dictionary<int, (CraftFileInfo, int)> value3;
				using (CollectionPool<Dictionary<int, (CraftFileInfo, int)>, KeyValuePair<int, (CraftFileInfo, int)>>.Get(out value3))
				{
					foreach (CraftFileInfo item in value2)
					{
						value3.Add(item.IdHash, (item, 1));
					}
					List<CraftFileInfo> list3 = new List<CraftFileInfo>(value3.Count);
					int num2 = num - 1;
					for (int i = 1; i < num; i++)
					{
						if (!_craftFilesByTag.TryGetValue(tags[i], out value2) || value2.Count == 0)
						{
							list3.Clear();
							break;
						}
						foreach (CraftFileInfo item2 in value2)
						{
							if (!value3.TryGetValue(item2.IdHash, out var value4))
							{
								continue;
							}
							int num3 = value4.Item2 + 1;
							if (i == num2)
							{
								if (num3 == num)
								{
									list3.Add(item2);
								}
							}
							else
							{
								value3[item2.IdHash] = (item2, num3);
							}
						}
					}
					FilterCraftsBySubdirectories(list3, subdirectories);
					return list3;
				}
			}
		}

		public void GetSubdirectories(List<string> subdirectories, bool sorted)
		{
			lock (_syncLock)
			{
				if (sorted)
				{
					subdirectories.AddRange(_craftFilesBySubdirectory.Keys.OrderBy((string s) => s, SubdirectorySorter.Default));
				}
				else
				{
					subdirectories.AddRange(_craftFilesBySubdirectory.Keys);
				}
			}
		}

		public void GetTags(List<string> tags, bool sorted, bool allTags)
		{
			lock (_syncLock)
			{
				if (allTags)
				{
					tags.AddRange(_fullTagList);
					foreach (string key in _craftFilesByTag.Keys)
					{
						if (!_fullTagList.Contains(key, StringComparer.OrdinalIgnoreCase))
						{
							tags.Add(key);
						}
					}
				}
				else
				{
					tags.AddRange(_craftFilesByTag.Keys);
				}
			}
			if (sorted)
			{
				tags.Sort(TagSorter.Default);
			}
		}

		public XElement LoadBuiltinCraftXml(string builtinCraftId, bool showErrorDialogs)
		{
			if (builtinCraftId != "__editor__.xml")
			{
				builtinCraftId = Path.Combine("Required Craft", builtinCraftId + ".xml");
			}
			return LoadCraftXml(builtinCraftId, showErrorDialogs);
		}

		public XElement LoadCraftXml(CraftFileInfo craftFile, bool showErrorDialogs)
		{
			lock (_syncLock)
			{
				for (int i = 0; i < _cachedCraftXml.Length; i++)
				{
					if (_cachedCraftXml[i].Id == craftFile.Id)
					{
						return _cachedCraftXml[i].Xml;
					}
				}
			}
			XElement xElement = null;
			try
			{
				xElement = XDocument.Load(craftFile.FullFilePath).Root;
			}
			catch (Exception exception)
			{
				UnityEngine.Debug.LogException(exception);
			}
			if (xElement == null)
			{
				try
				{
					string text = craftFile.FullFilePath + ".bak";
					if (File.Exists(text))
					{
						UnityEngine.Debug.LogWarning("[CraftDatabase] Failed to load craft XML for craft file '" + craftFile.FullFilePath + "'. Attempting to load from backup file.");
						xElement = XDocument.Load(text).Root;
					}
				}
				catch (Exception exception2)
				{
					UnityEngine.Debug.LogException(exception2);
				}
				if (showErrorDialogs)
				{
					if (xElement == null)
					{
						Game.Instance.UserInterface.CreateMessageDialog("The craft file could not be loaded. See the log for more details.", "Load Craft Failed");
					}
					else
					{
						Game.Instance.UserInterface.CreateMessageDialog("The craft file could not be loaded. A backup file was found and loaded, but may be out of date. See the log for more details.", "Backup File Loaded");
					}
				}
			}
			UpdateCraftXmlCache(craftFile.Id, xElement);
			return xElement;
		}

		public XElement LoadCraftXml(string id, bool showErrorDialogs)
		{
			CraftFileInfo value = null;
			lock (_syncLock)
			{
				if (!_craftFiles.TryGetValue(id, out value))
				{
					if (showErrorDialogs)
					{
						Game.Instance.UserInterface.CreateMessageDialog("The craft to load could not be found.", "Load Craft Failed");
					}
					return null;
				}
			}
			return LoadCraftXml(value, showErrorDialogs);
		}

		public CraftFileInfo RenameCraft(CraftFileInfo craftFile, string relativePath)
		{
			if (!File.Exists(craftFile.FullFilePath))
			{
				UnityEngine.Debug.LogError("[CraftDatabase] Unable to rename craft file at path '" + craftFile.FullFilePath + "' because the file could not be found.");
				return null;
			}
			if (!ValidateCraftPath(relativePath))
			{
				throw new CraftDatabaseException("The target file name contains one or more invalid characters.");
			}
			CraftFileInfo renamedCraftFile = new CraftFileInfo(relativePath);
			if (File.Exists(renamedCraftFile.FullFilePath))
			{
				throw new CraftDatabaseException("A craft file with that name already exists: " + Path.Combine(renamedCraftFile.SubdirectoryPath, renamedCraftFile.FileName));
			}
			string[] readOnlyDirectories = ReadOnlyDirectories;
			foreach (string text in readOnlyDirectories)
			{
				string fullPath = Path.GetFullPath(Path.Combine(CraftFilesRootPath, text));
				char directorySeparatorChar = Path.DirectorySeparatorChar;
				string value = fullPath + directorySeparatorChar;
				if (craftFile.FullFilePath.StartsWith(value) || renamedCraftFile.FullFilePath.StartsWith(value))
				{
					throw new CraftDatabaseException("The '" + text + "' directory is read only.");
				}
			}
			if (craftFile.FullFilePath.Equals(renamedCraftFile.FullFilePath, Device.IsWindowsBuild ? StringComparison.OrdinalIgnoreCase : StringComparison.Ordinal))
			{
				throw new CraftDatabaseException("The original and renamed file have the same file path and name.");
			}
			try
			{
				UpdateCraftXmlCache(craftFile.Id, null);
				UpdateCraftXmlCache(renamedCraftFile.Id, null);
				RemoveCraftFileInfo(craftFile.Id);
				CloudStorageManager.PerformFileBatchAction(delegate
				{
					FileIOUtility.TryMoveFile(craftFile.FullFilePath + ".bak", renamedCraftFile.FullFilePath + ".bak", FileIOUtility.ExceptionHandling.Throw);
					FileIOUtility.TryMoveFile(craftFile.FullFilePath, renamedCraftFile.FullFilePath, FileIOUtility.ExceptionHandling.Throw);
				});
				renamedCraftFile.Refresh();
				AddCraftFileInfo(renamedCraftFile);
				UnityEngine.Debug.Log("[CraftDatabase] Renamed craft file from '" + craftFile.FullFilePath + "' to '" + renamedCraftFile.FullFilePath + "'");
			}
			catch (Exception exception)
			{
				UnityEngine.Debug.LogException(exception);
				UnityEngine.Debug.LogError("[CraftDatabase] An error occurred while trying to rename the craft file from path: " + craftFile.FullFilePath + " to path: " + relativePath);
				return null;
			}
			return renamedCraftFile;
		}

		public async UniTaskVoid RescanCraftFilesForChangesAsync()
		{
			if (IsRescanInProgress)
			{
				UnityEngine.Debug.LogWarning("[CraftDatabase] A rescan of the craft database is already in progress. Unable to start a new rescan at this time.");
				return;
			}
			IsRescanInProgress = true;
			try
			{
				await UniTask.RunOnThreadPool(delegate
				{
					ScanAllCraftFiles(changesOnly: true);
				});
			}
			catch (Exception exception)
			{
				UnityEngine.Debug.LogException(exception);
				UnityEngine.Debug.LogError("[CraftDatabase] A critical error occurred while rescanning craft database for changes at path: " + CraftFilesRootPath);
			}
			IsRescanInProgress = false;
		}

		public void RestoreStockCraft()
		{
			UnityEngine.Debug.Log("[CraftDatabase] Restoring Stock Craft...");
			CloudStorageManager.PerformFileBatchAction(delegate
			{
				try
				{
					try
					{
						string path = Path.Combine(CraftFilesRootPath, "Stock Craft");
						if (Directory.Exists(path))
						{
							FileIOUtility.DeleteDirectory(path);
						}
					}
					catch (Exception exception)
					{
						UnityEngine.Debug.LogException(exception);
						UnityEngine.Debug.LogError("[CraftDatabase] An error occurred while trying to delete the existing stock craft directory. Attempting to continue with restoring stock craft, but errors may occur.");
					}
					TextAsset[] array = Resources.LoadAll<TextAsset>("Data/AircraftDesigns/");
					foreach (TextAsset textAsset in array)
					{
						try
						{
							RestoreStockCraftFromXml(textAsset.name, textAsset.text);
						}
						catch (Exception exception2)
						{
							UnityEngine.Debug.LogException(exception2);
							UnityEngine.Debug.LogError("[CraftDatabase] An error occurred while trying to restore the stock craft '" + textAsset.name + "'");
						}
						Resources.UnloadAsset(textAsset);
					}
				}
				catch (Exception exception3)
				{
					UnityEngine.Debug.LogException(exception3);
					UnityEngine.Debug.LogError("[CraftDatabase] An error occurred while trying to restore the stock craft");
				}
			});
		}

		public void RestoreStockCraft(string stockCraftId)
		{
			UnityEngine.Debug.Log("[CraftDatabase] Restoring Stock Craft '" + stockCraftId + "'...");
			try
			{
				TextAsset textAsset = Resources.Load<TextAsset>(Path.Combine("Data/AircraftDesigns/", stockCraftId));
				if (textAsset != null)
				{
					RestoreStockCraftFromXml(textAsset.name, textAsset.text);
					Resources.UnloadAsset(textAsset);
					return;
				}
				throw new FileNotFoundException("The stock craft '" + stockCraftId + "' could not be found.");
			}
			catch (Exception exception)
			{
				UnityEngine.Debug.LogException(exception);
				UnityEngine.Debug.LogError("[CraftDatabase] An error occurred while trying to restore the stock craft with Id '" + stockCraftId + "'");
			}
		}

		public CraftFileInfo SaveCraft(string relativePath, string craftXml, bool backupPreviousFile, bool updateXmlVersion)
		{
			return SaveCraft(relativePath, (CraftXmlDoc: null, CraftXmlString: craftXml), backupPreviousFile, updateXmlVersion);
		}

		public CraftFileInfo SaveCraft(string relativePath, XElement craftXml, bool backupPreviousFile, bool updateXmlVersion)
		{
			return SaveCraft(relativePath, (CraftXmlDoc: craftXml, CraftXmlString: null), backupPreviousFile, updateXmlVersion);
		}

		public bool TryGetCraft(string craftId, out CraftFileInfo craftFileInfo)
		{
			lock (_syncLock)
			{
				return _craftFiles.TryGetValue(craftId, out craftFileInfo);
			}
		}

		public bool ValidateCraftPath(string relativePath)
		{
			try
			{
				if (!FileIOUtility.IsValidPath(relativePath, out var _))
				{
					return false;
				}
				if (!new CraftFileInfo(relativePath).FullFilePath.StartsWith(CraftFilesRootPath, Device.IsWindowsBuild ? StringComparison.OrdinalIgnoreCase : StringComparison.Ordinal))
				{
					return false;
				}
				return true;
			}
			catch (Exception exception)
			{
				UnityEngine.Debug.LogException(exception);
			}
			return false;
		}

		private static bool ContainsTag(XElement xml, string tag)
		{
			return xml.GetStringListAttribute("tags").Contains(tag, StringComparer.OrdinalIgnoreCase);
		}

		private static bool ContainsTag(string xml, string tag)
		{
			using (StringReader input = new StringReader(xml))
			{
				using XmlReader xmlReader = XmlReader.Create(input, _xmlReaderSettings);
				if (!xmlReader.ReadToFollowing("Aircraft"))
				{
					UnityEngine.Debug.LogError("Unable to read the root element of craft xml.");
					return false;
				}
				if (xmlReader.MoveToAttribute("tags"))
				{
					StringUtility.StringSplitEnumerator enumerator = StringUtility.SpanSplit(xmlReader.Value, ',').GetEnumerator();
					while (enumerator.MoveNext())
					{
						if (string.Equals(enumerator.Current, tag, StringComparison.OrdinalIgnoreCase))
						{
							return true;
						}
					}
				}
			}
			return false;
		}

		private void AddCraftFileInfo(CraftFileInfo craftFileInfo)
		{
			lock (_syncLock)
			{
				if (_craftFiles.ContainsKey(craftFileInfo.Id))
				{
					RemoveCraftFileInfo(craftFileInfo.Id);
				}
				_craftFiles.Add(craftFileInfo.Id, craftFileInfo);
				if (craftFileInfo.Tags.Count == 0)
				{
					AddCraft(craftFileInfo, "None", null, _craftFilesByTag);
				}
				else
				{
					HashSet<int> value;
					using (CollectionPool<HashSet<int>, int>.Get(out value))
					{
						foreach (string tag in craftFileInfo.Tags)
						{
							if (value.Add(tag.GetHashCode(StringComparison.OrdinalIgnoreCase)))
							{
								AddCraft(craftFileInfo, tag, null, _craftFilesByTag);
							}
							else
							{
								UnityEngine.Debug.LogWarning("[CraftDatabase] Duplicate tags found for craft file '" + craftFileInfo.Id + "': " + tag);
							}
						}
					}
				}
				AddCraft(craftFileInfo, null, string.IsNullOrEmpty(craftFileInfo.SubdirectoryPath) ? "None" : craftFileInfo.SubdirectoryPath, _craftFilesBySubdirectory);
			}
			static void AddCraft(CraftFileInfo item, string tag, string subdirectory, Dictionary<string, List<CraftFileInfo>> dictionary)
			{
				string key = subdirectory ?? tag;
				if (!dictionary.TryGetValue(key, out var value2))
				{
					dictionary.Add(key, value2 = new List<CraftFileInfo>());
				}
				value2.Add(item);
			}
		}

		private void FilterCraftsBySubdirectories(List<CraftFileInfo> craftsFiles, IList<string> subdirectories)
		{
			if (subdirectories == null || subdirectories.Count == 0)
			{
				return;
			}
			List<CraftFileInfo> value;
			using (CollectionPool<List<CraftFileInfo>, CraftFileInfo>.Get(out value))
			{
				value.AddRange(craftsFiles);
				craftsFiles.Clear();
				StringComparer comparer = (Device.IsWindowsBuild ? StringComparer.OrdinalIgnoreCase : StringComparer.Ordinal);
				bool flag = subdirectories.Contains("None", comparer);
				foreach (CraftFileInfo item in value)
				{
					if (subdirectories.Contains(item.SubdirectoryPath, comparer) || (flag && string.IsNullOrEmpty(item.SubdirectoryPath)))
					{
						craftsFiles.Add(item);
					}
				}
			}
		}

		private async UniTaskVoid InitializeAsync()
		{
			try
			{
				await UniTask.RunOnThreadPool(delegate
				{
					ScanAllCraftFiles(changesOnly: false);
				});
			}
			catch (Exception exception)
			{
				UnityEngine.Debug.LogException(exception);
				UnityEngine.Debug.LogError("[CraftDatabase] A critical error occurred while initializing craft database at path: " + CraftFilesRootPath);
			}
			IsInitialized = true;
			UnityEngine.Debug.Log(string.Format("{0}Craft Database Initialized. Found {1} Crafts.", "[CraftDatabase] ", _craftFiles.Count));
			this.Initialized?.Invoke(this, EventArgs.Empty);
		}

		private void InitializeCraftTagList(bool clearCache)
		{
			try
			{
				XDocument xml = null;
				string path = GameData.GetPath("Cache/CraftTags.xml");
				if (!File.Exists(path) || clearCache)
				{
					FileInfo fileInfo = new FileInfo(path);
					if (!fileInfo.Directory.Exists)
					{
						fileInfo.Directory.Create();
					}
					xml = new XDocument(new XElement("Tags", CraftTags.WebsiteTags.Select((string x) => new XElement("Tag", new XAttribute("name", x)))));
					GameData.SaveXml(xml, path);
				}
				else
				{
					xml = GameData.LoadXml(path);
				}
				_fullTagList.Clear();
				_fullTagList.AddRange((from x in xml.Root?.Elements("Tag")
					select x.Attribute("name")?.Value into x
					where !string.IsNullOrEmpty(x)
					select x));
				_tagListWebRequest = WebRequest.Get(Game.SimplePlanesWebsiteUrl + "/Client/GetTagList");
				_tagListWebRequest.Complete += delegate(WebRequest r)
				{
					try
					{
						if (r.IsCanceled)
						{
							UnityEngine.Debug.LogWarning("[CraftDatabase] Tag list web request was canceled. Using locally cached tag list.");
							return;
						}
						if (r.HasError)
						{
							UnityEngine.Debug.LogError("[CraftDatabase] An error occurred while trying to retrieve the tag list from the website: " + r.Error + ". Using locally cached tag list.");
							return;
						}
						ClientResponse clientResponse = WebUtility.CreateClientResponse(r.Text);
						if (!clientResponse.Succeeded)
						{
							UnityEngine.Debug.LogError("[CraftDatabase] Failed to retrieve tag list from website. Response indicated failure: " + clientResponse.Error + ". Using locally cached tag list.");
							return;
						}
						lock (_syncLock)
						{
							_fullTagList.Clear();
							_fullTagList.AddRange((from x in clientResponse?.XmlResult?.Element("Tags")?.Elements("Tag")
								select x.Attribute("name")?.Value into x
								where !string.IsNullOrEmpty(x)
								select x));
							_fullTagList.RemoveAll((string x) => x.StartsWith("Youtube", StringComparison.OrdinalIgnoreCase));
							_fullTagList.RemoveAll((string x) => CraftTags.ExcludedWebsiteTags.Contains(x, StringComparer.OrdinalIgnoreCase));
							xml = new XDocument(new XElement("Tags", _fullTagList.Select((string x) => new XElement("Tag", new XAttribute("name", x)))));
							GameData.SaveXml(xml, path);
						}
					}
					catch (Exception exception2)
					{
						UnityEngine.Debug.LogException(exception2);
						UnityEngine.Debug.LogError("[CraftDatabase] An error occurred while trying to process the tag list retrieved from the website. Using locally cached tag list.");
					}
					_tagListWebRequest = null;
				};
			}
			catch (Exception exception)
			{
				UnityEngine.Debug.LogException(exception);
				UnityEngine.Debug.LogError("[CraftDatabase] An error occurred while trying to initialize the craft tag list.");
			}
		}

		private bool RemoveCraftFileInfo(string craftFileId)
		{
			lock (_syncLock)
			{
				if (!_craftFiles.TryGetValue(craftFileId, out var value))
				{
					return false;
				}
				if (IsInitialized)
				{
					string[] readOnlyDirectories = ReadOnlyDirectories;
					foreach (string text in readOnlyDirectories)
					{
						string fullPath = Path.GetFullPath(Path.Combine(CraftFilesRootPath, text));
						char directorySeparatorChar = Path.DirectorySeparatorChar;
						string value2 = fullPath + directorySeparatorChar;
						if (value.FullFilePath.StartsWith(value2))
						{
							throw new CraftDatabaseException("The '" + text + "' directory is read only.");
						}
					}
				}
				_craftFiles.Remove(value.Id);
				if (value.Tags.Count == 0)
				{
					RemoveCraft(value, "None", null, _craftFilesByTag);
				}
				else
				{
					HashSet<int> value3;
					using (CollectionPool<HashSet<int>, int>.Get(out value3))
					{
						foreach (string tag in value.Tags)
						{
							if (value3.Add(tag.GetHashCode(StringComparison.OrdinalIgnoreCase)))
							{
								RemoveCraft(value, tag, null, _craftFilesByTag);
							}
							else
							{
								UnityEngine.Debug.LogWarning("[CraftDatabase] Duplicate tags found for craft file '" + value.Id + "': " + tag);
							}
						}
					}
				}
				RemoveCraft(value, null, string.IsNullOrEmpty(value.SubdirectoryPath) ? "None" : value.SubdirectoryPath, _craftFilesBySubdirectory);
			}
			return true;
			static void RemoveCraft(CraftFileInfo craftFileInfo, string tag, string subdirectory, Dictionary<string, List<CraftFileInfo>> dictionary)
			{
				string text2 = subdirectory ?? tag;
				if (!dictionary.TryGetValue(text2, out var value4))
				{
					string text3 = ((tag == null) ? "subdirectory" : "tag");
					UnityEngine.Debug.LogError("[CraftDatabase] Unable to remove craft file '" + craftFileInfo.Id + "' with " + text3 + " of '" + text2 + "' because that " + text3 + " could not be found.");
				}
				else
				{
					if (!value4.Remove(craftFileInfo))
					{
						string text4 = ((tag == null) ? "subdirectory" : "tag");
						UnityEngine.Debug.LogError("[CraftDatabase] Unable to remove craft file '" + craftFileInfo.Id + "' with " + text4 + " of '" + text2 + "' because no matching craft file could be found.");
					}
					if (value4.Count == 0)
					{
						dictionary.Remove(text2);
					}
				}
			}
		}

		private void RestoreStockCraftFromXml(string resourceName, string xml)
		{
			UnityEngine.Debug.Log("[CraftDatabase] Restoring Stock Craft '" + resourceName + "'...");
			bool num = resourceName == "__editor__";
			string text = Path.Combine(num ? string.Empty : "Stock Craft", resourceName + ".xml");
			if (num && File.Exists(Path.Combine(CraftFilesRootPath, text)))
			{
				UnityEngine.Debug.Log("Designer craft already exists. Skipping restoration of the designer craft.");
			}
			else
			{
				SaveCraft(text, xml, backupPreviousFile: false, updateXmlVersion: false);
			}
		}

		private CraftFileInfo SaveCraft(string relativePath, (XElement CraftXmlDoc, string CraftXmlString) craftXml, bool backupPreviousFile, bool updateXmlVersion)
		{
			if (craftXml.CraftXmlDoc == null && string.IsNullOrEmpty(craftXml.CraftXmlString))
			{
				throw new ArgumentException("No XML provided when saving craft at path: " + relativePath, "craftXml");
			}
			if (!ValidateCraftPath(relativePath))
			{
				throw new CraftDatabaseException("The craft file name contains one or more invalid characters.");
			}
			CraftFileInfo craftFile = new CraftFileInfo(relativePath);
			if (IsInitialized)
			{
				string[] readOnlyDirectories = ReadOnlyDirectories;
				foreach (string text in readOnlyDirectories)
				{
					string fullPath = Path.GetFullPath(Path.Combine(CraftFilesRootPath, text));
					char directorySeparatorChar = Path.DirectorySeparatorChar;
					string value = fullPath + directorySeparatorChar;
					if (craftFile.FullFilePath.StartsWith(value))
					{
						throw new CraftDatabaseException("The '" + text + "' directory is read only.");
					}
				}
			}
			if (IsInitialized && ((craftXml.CraftXmlDoc == null) ? ContainsTag(craftXml.CraftXmlString, "Stock Craft") : ContainsTag(craftXml.CraftXmlDoc, "Stock Craft")))
			{
				ref XElement item = ref craftXml.CraftXmlDoc;
				if (item == null)
				{
					item = XDocument.Parse(craftXml.CraftXmlString).Root;
				}
				List<string> stringListAttribute = craftXml.CraftXmlDoc.GetStringListAttribute("tags");
				for (int num = stringListAttribute.Count - 1; num >= 0; num--)
				{
					if (string.Equals(stringListAttribute[num], "Stock Craft", StringComparison.OrdinalIgnoreCase))
					{
						stringListAttribute.RemoveAt(num);
						break;
					}
				}
				craftXml.CraftXmlDoc.SetAttributeValue("tags", string.Join(",", stringListAttribute));
			}
			if (updateXmlVersion)
			{
				ref XElement item = ref craftXml.CraftXmlDoc;
				if (item == null)
				{
					item = XDocument.Parse(craftXml.CraftXmlString).Root;
				}
				craftXml.CraftXmlDoc.SetAttributeValue("xmlVersion", 23);
			}
			if (backupPreviousFile && File.Exists(craftFile.FullFilePath))
			{
				string backupFilename = craftFile.FullFilePath + ".bak";
				CloudStorageManager.PerformFileBatchAction(delegate
				{
					File.Copy(craftFile.FullFilePath, backupFilename, overwrite: true);
				});
			}
			string path = Path.Combine(CraftFilesRootPath, craftFile.SubdirectoryPath);
			if (!Directory.Exists(path))
			{
				Directory.CreateDirectory(path);
			}
			if (craftXml.CraftXmlDoc != null)
			{
				CloudStorageManager.Save(craftFile.FullFilePath, craftXml.CraftXmlDoc);
			}
			else
			{
				CloudStorageManager.Save(craftFile.FullFilePath, craftXml.CraftXmlString);
			}
			if (IsInitialized)
			{
				craftFile.Refresh();
				AddCraftFileInfo(craftFile);
				UpdateCraftXmlCache(craftFile.Id, craftXml.CraftXmlDoc);
			}
			return craftFile;
		}

		private void ScanAllCraftFiles(bool changesOnly)
		{
			Stopwatch stopwatch = Stopwatch.StartNew();
			if (IsInitialized && !changesOnly)
			{
				lock (_syncLock)
				{
					_craftFiles.Clear();
					_craftFilesByTag.Clear();
					_craftFilesBySubdirectory.Clear();
					_craftFilesByTag.Add("None", new List<CraftFileInfo>());
					_craftFilesBySubdirectory.Add("None", new List<CraftFileInfo>());
				}
			}
			HashSet<CraftFileInfo> existingCrafts = null;
			if (changesOnly)
			{
				lock (_syncLock)
				{
					existingCrafts = new HashSet<CraftFileInfo>(_craftFiles.Values, new CraftFileInfo.IdHashEqualityComparer());
				}
			}
			string[] craftFilePaths = Directory.GetFiles(CraftFilesRootPath, "*.xml", SearchOption.AllDirectories);
			int relativePathStartIndex = CraftFilesRootPath.Length + 1;
			Parallel.For(0, craftFilePaths.Length, delegate(int i)
			{
				string text = craftFilePaths[i];
				try
				{
					CraftFileInfo craftFileInfo = new CraftFileInfo(text.Substring(relativePathStartIndex));
					bool flag = true;
					if (changesOnly)
					{
						lock (_syncLock)
						{
							if (existingCrafts.Remove(craftFileInfo))
							{
								if (_craftFiles.TryGetValue(craftFileInfo.Id, out var value))
								{
									craftFileInfo.RefreshLastModified();
									if (value.LastModified == craftFileInfo.LastModified)
									{
										flag = false;
									}
									else
									{
										UnityEngine.Debug.Log("[CraftDatabase] Craft file modified: " + craftFileInfo.FullFilePath);
									}
								}
								else
								{
									UnityEngine.Debug.LogError("[CraftDatabase] While scanning for craft file changes, found an existing craft file with id '" + craftFileInfo.Id + "' but was unable to find it in the collection of tracked craft files.");
									flag = false;
								}
							}
							else
							{
								UnityEngine.Debug.Log("[CraftDatabase] Craft file added: " + craftFileInfo.FullFilePath);
							}
							if (flag)
							{
								UpdateCraftXmlCache(craftFileInfo.Id, null);
							}
						}
					}
					if (flag)
					{
						craftFileInfo.Refresh();
						if (craftFileInfo.IsValid)
						{
							lock (_syncLock)
							{
								AddCraftFileInfo(craftFileInfo);
								return;
							}
						}
					}
				}
				catch (Exception exception)
				{
					UnityEngine.Debug.LogException(exception);
					UnityEngine.Debug.LogError("[CraftDatabase] Error processing craft file at path: " + text);
				}
			});
			if (changesOnly && existingCrafts.Count > 0)
			{
				foreach (CraftFileInfo item in existingCrafts)
				{
					if (RemoveCraftFileInfo(item.Id))
					{
						UpdateCraftXmlCache(item.Id, null);
						UnityEngine.Debug.Log("[CraftDatabase] Craft file removed: " + item.FullFilePath);
					}
					else
					{
						UnityEngine.Debug.LogError("[CraftDatabase] While scanning for craft file changes, found an existing craft file with id '" + item.Id + "' that appears to have been removed but was unable to remove it from the collection of tracked craft files.");
					}
				}
			}
			stopwatch.Stop();
			if (changesOnly)
			{
				if (!Device.IsUnityEditor)
				{
					UnityEngine.Debug.Log(string.Format("{0}Rescan of craft database completed in {1} ms", "[CraftDatabase] ", stopwatch.ElapsedMilliseconds));
				}
			}
			else
			{
				UnityEngine.Debug.Log(string.Format("{0}Scanned all crafts at path '{1}'. Found '{2}' crafts in {3} ms", "[CraftDatabase] ", CraftFilesRootPath, _craftFiles.Count, stopwatch.ElapsedMilliseconds));
			}
		}

		private void UpdateCraftXmlCache(string id, XElement xml)
		{
			lock (_syncLock)
			{
				int num = _cachedCraftXml.Length;
				int num2 = -1;
				for (int i = 0; i < num; i++)
				{
					if (_cachedCraftXml[i].Id == id)
					{
						num2 = i;
						break;
					}
				}
				if (xml == null)
				{
					if (num2 >= 0)
					{
						for (int j = num2 + 1; j < num; j++)
						{
							_cachedCraftXml[j - 1] = _cachedCraftXml[j];
						}
						_cachedCraftXml[num - 1] = default((string, XElement));
					}
				}
				else
				{
					for (int num3 = ((num2 < 0) ? (num - 1) : num2); num3 > 0; num3--)
					{
						_cachedCraftXml[num3] = _cachedCraftXml[num3 - 1];
					}
					_cachedCraftXml[0] = (Id: id, Xml: xml);
				}
			}
		}
	}
}
