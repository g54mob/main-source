using System;
using System.Globalization;
using System.IO;
using FoxyVoxel.Logging;
using FoxyVoxel.Logging.Core.LogMessageInterpolationHandlers;
using NSEipix;
using NSMedieval.State;
using NSMedieval.UI.Utils;
using UnityEngine;

namespace NSMedieval
{
	[Serializable]
	public class VillageSaveInfo
	{
		[SerializeField]
		private string folderName;

		[SerializeField]
		private string villageName;

		[SerializeField]
		private string fileName;

		[SerializeField]
		private long lastPlayed;

		[SerializeField]
		private bool autoSave;

		[SerializeField]
		private int index;

		[SerializeField]
		private string modifiedVersion;

		[NonSerialized]
		private VillageSaveMeta meta;

		[NonSerialized]
		private bool isMetaInitialized;

		[NonSerialized]
		private string filePath;

		[NonSerialized]
		private bool isObsolete;

		public int Index => index;

		public string VillageName => villageName;

		public string FileName => fileName;

		public string FolderName => folderName;

		public DateTime LastPlayed
		{
			get
			{
				try
				{
					return lastPlayed.FromUnixTimeSeconds();
				}
				catch (Exception)
				{
					bool isEnabled;
					FVLogInfoInterpolationHandler messageBuilder = new FVLogInfoInterpolationHandler(81, 2, out isEnabled, "C:\\GIT\\dev\\Assets\\Scripts\\State\\Profile\\VillageSaveInfo.cs");
					if (isEnabled)
					{
						messageBuilder.AppendLiteral("LastPlayed: error converting ");
						messageBuilder.AppendFormatted(lastPlayed);
						messageBuilder.AppendLiteral(" into DateTime. Using DateTime.now (");
						messageBuilder.AppendFormatted(DateTime.Now);
						messageBuilder.AppendLiteral(") as LastPlayed.");
					}
					Log.Info(messageBuilder);
					lastPlayed = DateTime.Now.ToUnixTimeSeconds();
					return DateTime.Now;
				}
			}
		}

		public long LastPlayedUnixSeconds => lastPlayed;

		public string LastPlayedLocalizedString
		{
			get
			{
				if (lastPlayed == 0L)
				{
					return string.Empty;
				}
				return LastPlayed.ToLocalTime().ToString(CultureInfo.CurrentCulture);
			}
		}

		public string FilePath
		{
			get
			{
				if (string.IsNullOrEmpty(filePath))
				{
					string path = Path.Combine(Application.persistentDataPath, "VillageSaves");
					path = Path.Combine(path, Path.Combine(folderName, fileName)).Replace("\\", "/");
					filePath = path;
				}
				return filePath;
			}
		}

		public bool AutoSave => autoSave;

		public bool IsObsolete => isObsolete;

		public string ModifiedVersion
		{
			get
			{
				if (!string.IsNullOrEmpty(modifiedVersion))
				{
					return modifiedVersion;
				}
				return "?.?.?";
			}
		}

		public VillageSaveMeta Meta
		{
			get
			{
				if (!isMetaInitialized)
				{
					isMetaInitialized = true;
					LoadMeta();
				}
				return meta;
			}
		}

		public VillageSaveInfo(string villageName, string fileName, string folderName, DateTime lastPlayed, bool autosave = false, int index = 0)
		{
			this.villageName = villageName;
			this.fileName = fileName;
			this.folderName = folderName;
			this.lastPlayed = lastPlayed.ToUnixTimeSeconds();
			autoSave = autosave;
			this.index = index;
		}

		private void LoadMeta()
		{
			string text = FilePath + ".meta";
			if (!File.Exists(text))
			{
				meta = null;
				return;
			}
			try
			{
				string json = File.ReadAllText(text);
				meta = JsonUtility.FromJson<VillageSaveMeta>(json);
			}
			catch (Exception ex)
			{
				Log.Error("Exception happened during reading " + text, "C:\\GIT\\dev\\Assets\\Scripts\\State\\Profile\\VillageSaveInfo.cs");
				Log.Error(ex.ToString(), "C:\\GIT\\dev\\Assets\\Scripts\\State\\Profile\\VillageSaveInfo.cs");
				meta = null;
			}
		}

		public void SetModifiedVersion(string modifiedVersion, bool isObsolete)
		{
			this.modifiedVersion = modifiedVersion;
			this.isObsolete = isObsolete;
		}

		public void SetIndex(int index)
		{
			this.index = index;
		}

		public void SetVillageName(string name)
		{
			villageName = name;
		}

		public void SetLastPlayed(DateTime date)
		{
			lastPlayed = date.ToUnixTimeSeconds();
		}

		public void SetFolderName(string folderName)
		{
			this.folderName = folderName;
		}

		public void SetFileName(string fileName)
		{
			this.fileName = fileName;
		}

		public void InitModifiedVersion()
		{
			if (string.IsNullOrEmpty(modifiedVersion))
			{
				modifiedVersion = VillageSaveData.ReadModifiedVersionFromZip(FilePath);
			}
			isObsolete = !ApplicationVersionUtils.IsNewSaveVersion(modifiedVersion);
		}
	}
}
