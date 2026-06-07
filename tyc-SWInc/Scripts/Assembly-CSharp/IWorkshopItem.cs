using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Steamworks;
using Tyd;
using UnityEngine;

public abstract class IWorkshopItem : IFormatColorObject
{
	public class ModMetaData
	{
		public string Name;

		public string Description;

		public string Author;

		public string Root;

		public string SteamName;

		public bool HasFile;

		private Dictionary<string, string> _customData = new Dictionary<string, string>();

		public PublishedFileId_t? SteamID { get; private set; }

		public ModMetaData()
		{
		}

		public string GetCustomData(string key)
		{
			return _customData.GetOrDefault(key);
		}

		public bool TryGetCustomData(string key, out string value)
		{
			return _customData.TryGetValue(key, out value);
		}

		public void SetCustomData(string key, string value)
		{
			_customData[key] = value;
		}

		public void RemoveCustomData(string key)
		{
			_customData.Remove(key);
		}

		public void ClearCustomData(string key)
		{
			_customData.Clear();
		}

		public ModMetaData(string root)
		{
			HasFile = false;
			Root = root;
			TydDocument tydDocument = null;
			if (root != null)
			{
				string text = Path.Combine(root, "meta.tyd");
				if (File.Exists(text))
				{
					try
					{
						tydDocument = TydFile.FromContent(Utilities.ReadOnlyReadAllText(text), text).DocumentNode;
					}
					catch (Exception ex)
					{
						Debug.LogException(new Exception("Error loading meta file for " + Path.GetFileName(root) + ":\n" + ex.ToString()));
					}
				}
			}
			Name = Path.GetFileName(root);
			if (tydDocument == null)
			{
				return;
			}
			HasFile = true;
			foreach (TydString item in tydDocument.Nodes.OfType<TydString>())
			{
				switch (item.Name)
				{
				case "Name":
					Name = item.Value;
					break;
				case "Description":
					Description = item.Value;
					break;
				case "Author":
					Author = item.Value;
					break;
				case "SteamName":
					SteamName = item.Value;
					break;
				case "SteamID":
					try
					{
						SteamID = new PublishedFileId_t(Convert.ToUInt64(item.Value.Trim()));
					}
					catch (Exception)
					{
						Debug.Log("Failed parsing Steam ID: " + item.Value + " for mod " + Name);
					}
					break;
				default:
					_customData[item.Name] = item.Value;
					break;
				}
			}
		}

		public bool UpdateSteamID(PublishedFileId_t? id)
		{
			if (id.HasValue == SteamID.HasValue)
			{
				if (!id.HasValue)
				{
					return true;
				}
				if (id.Value.m_PublishedFileId == SteamID.Value.m_PublishedFileId)
				{
					return true;
				}
			}
			SteamID = id;
			return SaveChanges();
		}

		public bool SaveChanges()
		{
			if (Root == null)
			{
				return false;
			}
			TydDocument tydDocument = new TydDocument();
			tydDocument.AddChild(new TydString("Name", Name));
			if (!string.IsNullOrEmpty(Description))
			{
				tydDocument.AddChild(new TydString("Description", Description));
			}
			if (!string.IsNullOrEmpty(Author))
			{
				tydDocument.AddChild(new TydString("Author", Author));
			}
			if (SteamName != null)
			{
				tydDocument.AddChild(new TydString("SteamName", SteamName));
			}
			if (SteamID.HasValue)
			{
				tydDocument.AddChild(new TydString("SteamID", SteamID.Value.ToString()));
			}
			foreach (KeyValuePair<string, string> customDatum in _customData)
			{
				tydDocument.AddChild(new TydString(customDatum.Key, customDatum.Value));
			}
			try
			{
				File.WriteAllText(Path.Combine(Root, "meta.tyd"), TydToText.Write(tydDocument, true));
				HasFile = true;
			}
			catch (Exception exception)
			{
				Debug.LogException(exception);
				return false;
			}
			return true;
		}
	}

	public bool SetTitle = true;

	private bool _canUpload = true;

	private bool _initialized;

	public float LoadTime;

	public string ItemTitle
	{
		get
		{
			string text;
			if (MetaData != null)
			{
				text = MetaData.SteamName;
				if (text == null)
				{
					return MetaData.Name;
				}
			}
			else
			{
				text = Path.GetFileName(Root);
			}
			return text;
		}
	}

	public bool CanUpload
	{
		get
		{
			if (_initialized && _canUpload)
			{
				return CheckCanUpload();
			}
			return false;
		}
	}

	public string Root { get; private set; }

	public string RootInvariant { get; private set; }

	public ModMetaData MetaData { get; private set; }

	public abstract string GetWorkshopType();

	public abstract string[] GetValidExts();

	public abstract string[] ExtraTags();

	public string GetThumbnail()
	{
		if (!_initialized)
		{
			return null;
		}
		string text = Path.Combine(FolderPath(), "Thumbnail.png");
		if (!File.Exists(text))
		{
			return null;
		}
		return text;
	}

	public PublishedFileId_t? GetSteamID()
	{
		if (MetaData != null)
		{
			return MetaData.SteamID;
		}
		return null;
	}

	public string FolderPath()
	{
		return Root;
	}

	public virtual bool CheckCanUpload()
	{
		return true;
	}

	public void SetName(string name, bool steam)
	{
		if (MetaData == null)
		{
			MetaData = new ModMetaData(FolderPath());
		}
		if (steam)
		{
			bool num = !name.Equals(MetaData.SteamName);
			MetaData.SteamName = name;
			if (num)
			{
				MetaData.SaveChanges();
			}
		}
		else
		{
			MetaData.Name = name;
		}
	}

	public virtual void SteamNameUpdated()
	{
	}

	public bool SameRoot(string path, bool preNormalized = false)
	{
		if (!_initialized)
		{
			return false;
		}
		if (!preNormalized)
		{
			path = path.TrimEnd(Path.DirectorySeparatorChar, Path.AltDirectorySeparatorChar).ToUpperInvariant();
		}
		if (path.StartsWith(RootInvariant))
		{
			if (path.Length != RootInvariant.Length && path[RootInvariant.Length] != Path.DirectorySeparatorChar)
			{
				return path[RootInvariant.Length] == Path.AltDirectorySeparatorChar;
			}
			return true;
		}
		return false;
	}

	public void InitMod(string path, float loadTime)
	{
		_initialized = true;
		LoadTime = loadTime;
		Root = Path.GetFullPath(path);
		RootInvariant = SteamWorkshop.NormalizePath(Root);
		MetaData = new ModMetaData(Root);
		CheckWorkshopUpdate();
		string path2 = Path.Combine(path, "Localization");
		if (LoadLocalization() && Directory.Exists(path2))
		{
			string[] directories = Directory.GetDirectories(path2);
			foreach (string text in directories)
			{
				Localization.Translation language = Localization.GetLanguage(Path.GetFileNameWithoutExtension(text));
				if (language != null)
				{
					language.LoadSecondary(text);
				}
			}
		}
		ModWindow.AddMod(this);
	}

	public virtual bool LoadLocalization()
	{
		return true;
	}

	public bool UpdateSteam(PublishedFileId_t? id, bool canUpload)
	{
		if (MetaData == null)
		{
			MetaData = new ModMetaData(FolderPath());
		}
		_canUpload = canUpload;
		CheckWorkshopUpdate();
		return MetaData.UpdateSteamID(id);
	}

	public bool UpdateSteam(PublishedFileId_t? id)
	{
		if (MetaData == null)
		{
			MetaData = new ModMetaData(FolderPath());
		}
		CheckWorkshopUpdate();
		return MetaData.UpdateSteamID(id);
	}

	public string SteamStatus()
	{
		if (GetSteamID().HasValue)
		{
			if (!CanUpload)
			{
				return "ModDownloadSteam".Loc();
			}
			return "ModUploadSteam".Loc();
		}
		return "ModLocalSteam".Loc();
	}

	public void UpdateSteam(bool canUpload)
	{
		_canUpload = canUpload;
	}

	private void CheckWorkshopUpdate()
	{
		PublishedFileId_t? steamID = GetSteamID();
		KeyValuePair<string, ulong> value;
		if (steamID.HasValue && SteamManager.Initialized && SteamWorkshop.Instance != null && SteamWorkshop.Instance.UnhandledUpdate.TryGetValue(steamID.Value, out value))
		{
			SteamWorkshop.Instance.UnhandledUpdate.Remove(steamID.Value);
			SetName(value.Key, true);
			SteamNameUpdated();
			UpdateSteam(SteamWorkshop.UserID == value.Value);
		}
	}

	public virtual bool GenerateLocalization()
	{
		return false;
	}

	public virtual bool PrepareForUpload(out bool hasShownError)
	{
		hasShownError = false;
		if (!_initialized)
		{
			return false;
		}
		if (!MetaData.HasFile || string.IsNullOrEmpty(MetaData.Author))
		{
			MetaData.Author = SteamFriends.GetPersonaName();
		}
		MetaData.SaveChanges();
		return true;
	}

	public virtual string GetExtraInfo()
	{
		return "";
	}

	public virtual void Enable(bool toggle)
	{
	}

	public virtual bool IsEnabled()
	{
		return true;
	}

	public virtual int GetCount()
	{
		return 0;
	}

	public abstract string GetActualString();
}
