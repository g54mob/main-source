using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.Serialization.Formatters.Binary;
using System.Xml.Serialization;
using FuryStudios.FurySDK;
using UnityEngine;

namespace Placemaker
{
	[Serializable]
	public class SaveSystem : MonoBehaviour
	{
		public enum BootState
		{
			MoveAllCurrentToPool = 0,
			BeginLoadSettings = 1,
			LoadSettingsBytes = 2,
			CreateNewSettings = 3,
			TryLoadLastSave = 4,
			IterateLastMetaSave = 5,
			LoadSaveList = 6,
			IterateAllSaves = 7,
			ValidLastSave = 8,
			NoValidLastSave = 9,
			NewFromDefaultSave = 10
		}

		public enum State
		{
			DoNothing = 0,
			BeginRefreshSaves = 1,
			ListFiles = 2,
			ProcessStrings = 3,
			CheckExistingMetaSaves = 4,
			CreateNewMetaFiles = 5,
			ProcessAllMetaFiles = 6,
			Done = 7
		}

		[SerializeField]
		private WorldMaster worldMaster;

		public bool anyChangeWhenRefreshing;

		public BootState bootState;

		public State state;

		public Transform metaSavePool;

		public Transform metaSaveContainer;

		public SettingsData settingsData;

		public float settingsChangeTime;

		public float settingsSaveTime;

		public float settingsStartChangeTime;

		public MetaSave currentMetaSave;

		public List<string> fileList;

		public Action<MetaSave> onNewMetaSave;

		private const string settingsFileName = "Sett.ings";

		private const string saveFilePrefix = "Town";

		private const string xmlExtension = ".scape";

		private const string binExtension = ".binscape";

		private const string saveFileDirectoryName = "Saves";

		private const string preferedSaveExension = ".scape";

		private const bool shouldBeBin = false;

		private const string containerID = "storage";

		public float startRefreshTime;

		private char[] charArray;

		private string saveChars;

		private XmlSerializer settingsXmlSerializer;

		private XmlSerializer saveXmlSerializer;

		private BinaryFormatter binaryFormatter;

		[SerializeField]
		private int index;

		[SerializeField]
		private int count;

		public int validMetaSaveCount;

		private IAsyncRequest<IList<string>> listRequest;

		private IAsyncRequest<byte[]> byteRequest;

		private IAsyncRequest<bool> boolRequest;

		private IAsyncRequest saveSettingsRequest;

		public Action<int, int> onSaveRequestCountChange;

		public int activeRequestsCounter;

		public readonly int maxSaveGameCount;

		public int totalSaveGameCount;

		private IStorageContainer storageContainer => null;

		private string GetSaveFilePath(string fileName)
		{
			return null;
		}

		public string GetUniqueSaveName()
		{
			return null;
		}

		public MetaSave GetMetaSave(int index)
		{
			return null;
		}

		public int GetMetaSaveCount()
		{
			return 0;
		}

		public MetaSave GetNewMetaSave(MetaSave.State state, string path = "no path")
		{
			return null;
		}

		public void ResetBoot()
		{
		}

		public bool IterateBoot(Func<bool> keepGoing)
		{
			return false;
		}

		private void MaybeUpdateOldSettings()
		{
		}

		public bool IterateRefresh(Func<bool> keepGoing)
		{
			return false;
		}

		public void StartRefreshSaves()
		{
		}

		public void StartMaybeSaveSaves()
		{
		}

		private void LoadMetaSaveFromDisk(MetaSave metaSave)
		{
		}

		public void SaveMetaSaveToDisk(MetaSave metaSave, bool setAsLastSave = false)
		{
		}

		public void SaveSettings()
		{
		}

		public bool MaybeSaveSettings(float margin = 0f)
		{
			return false;
		}

		public void SetSettingsDirty()
		{
		}

		public bool MaybeSaveCurrent()
		{
			return false;
		}

		public void OnSaveMenuOpen()
		{
		}

		public void PopulateSaveData(MetaSave metaSave)
		{
		}

		public void MaybeSaveAndUnloadCurrent()
		{
		}

		public void SetCurrentMetaSave(MetaSave metaSave)
		{
		}

		public MetaSave GetAndMaybeCreateCurrent()
		{
			return null;
		}

		public bool DeleteMetaSaveFromDisk(MetaSave metaSave, out bool wasCurrent)
		{
			wasCurrent = default(bool);
			return false;
		}

		public bool IsMetaSaveLoading(MetaSave metaSave)
		{
			return false;
		}

		public bool LoadSave(MetaSave metaSave)
		{
			return false;
		}

		public void DuplicateSave(MetaSave oldMetaSave)
		{
		}

		private void LogTime()
		{
		}

		public static long GetDateTimeLong(DateTime dateTime)
		{
			return 0L;
		}

		private void OnApplicationQuit()
		{
		}

		public IEnumerator SaveAndQuit(Action callback = null)
		{
			return null;
		}

		public void SortAll()
		{
		}

		public void UpdateAllTextures()
		{
		}

		public bool MaybeUpdateTexture(MetaSave metaSave)
		{
			return false;
		}

		private void SetSiblingIndex(MetaSave metaSave, int index)
		{
		}

		private void ChangeState(MetaSave metaSave, MetaSave.State state)
		{
		}
	}
}
