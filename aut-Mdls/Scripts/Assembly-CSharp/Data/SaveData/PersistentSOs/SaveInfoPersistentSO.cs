#define ENABLE_DEBUG_LOGS
using System;
using System.Collections.Generic;
using Data.Variables;
using UnityEngine;
using UnityEngine.Pool;
using Utils;

namespace Data.SaveData.PersistentSOs
{
	[CreateAssetMenu(menuName = "PersistentSOs/SaveInfo", fileName = "SaveInfoPersistentSO", order = 0)]
	public class SaveInfoPersistentSO : AbstractPersistentSO, IComparable<SaveInfoPersistentSO>
	{
		private SaveInfoSaveData _saveData;

		private DateTime _loadSaveDateTime;

		[SerializeField]
		private double _totalPlayTimeMins;

		[SerializeField]
		private bool _zenMode;

		[SerializeField]
		private ZenModeVariableSO _zenModeSO;

		[SerializeField]
		private string _mapName;

		[SerializeField]
		private Guid _mapGuid;

		[SerializeField]
		private bool _isSupported;

		[SerializeField]
		private bool _isMapOld;

		private double _pausedDuration;

		private string _autoSaveSourceSaveName = string.Empty;

		public string AutoSaveSourceSaveName => _autoSaveSourceSaveName;

		public double TotalPlayTimeMins => _totalPlayTimeMins;

		public double TotalPlayTimeMinsRealtime => _totalPlayTimeMins + (DateTime.Now - _loadSaveDateTime).TotalMinutes - _pausedDuration;

		public bool IsZenMode => _zenMode;

		public bool IsSupported => _isSupported;

		public bool IsMapOld => _isMapOld;

		public DateTime LastModifiedTime => _saveData.LastSaveTimeStamp;

		public int SaveDirectoryVersion => _saveData.SaveDirectoryVersion;

		public bool IsSaveDirectoryOldVersion => _saveData.SaveDirectoryVersion != 2;

		public string MapName => _mapName;

		public Guid MapGuid => _mapGuid;

		public bool IsDemoSave { get; private set; }

		public string GetDisplaySaveName(SaveFile saveFile)
		{
			return saveFile.Name.UnsanitizeSpaces();
		}

		public override void ResetToDefaults()
		{
			_loadSaveDateTime = DateTime.Now;
			_totalPlayTimeMins = 0.0;
			_pausedDuration = 0.0;
			_zenMode = _zenModeSO.Value;
			_mapName = (_zenMode ? "DefaultLevel" : "DefaultLevelCreative");
			_mapGuid = Guid.Empty;
			_isSupported = true;
		}

		public override AbstractSaveData GetSaveData()
		{
			GetUpdatedTotalPlaytime();
			_zenMode = _zenModeSO.Value;
			IsDemoSave = false;
			IsDemoSave = true;
			return new SaveInfoSaveData(_totalPlayTimeMins, _zenMode, _mapName, _mapGuid, IsDemoSave, _autoSaveSourceSaveName);
		}

		public double GetUpdatedTotalPlaytime()
		{
			_totalPlayTimeMins += (float)(DateTime.Now - _loadSaveDateTime).TotalMinutes - (float)_pausedDuration;
			_loadSaveDateTime = DateTime.Now;
			_pausedDuration = 0.0;
			return _totalPlayTimeMins;
		}

		public void RemovePausedDurationFromTotalPlayTime(double duration)
		{
			_pausedDuration += (float)duration;
		}

		protected override void ApplyLoadedSaveData(AbstractSaveData saveData)
		{
			_saveData = saveData as SaveInfoSaveData;
			_totalPlayTimeMins = _saveData.TotalPlayTimeMins;
			_pausedDuration = 0.0;
			_loadSaveDateTime = DateTime.Now;
			_zenMode = _saveData.ZenMode;
			_mapName = _saveData.MapName;
			_mapGuid = _saveData.MapGuid;
			_autoSaveSourceSaveName = _saveData.AutoSaveSourceSaveName;
			IsDemoSave = _saveData.IsDemoSave;
		}

		public void SetZenMode(bool zenMode)
		{
			_zenMode = zenMode;
		}

		public void ApplyZenMode()
		{
			_zenModeSO.SetValue(_zenMode);
		}

		public void SetSupported(bool value)
		{
			_isSupported = value;
		}

		public void SetMapValues(string mapName, Guid mapGuid)
		{
			_mapName = mapName;
			_mapGuid = mapGuid;
		}

		public void SetIsMapOld(Guid mapGuid)
		{
			_isMapOld = mapGuid != _mapGuid;
		}

		public void SetAutoSaveSourceSaveName(string sourceSavePath)
		{
			if (string.IsNullOrEmpty(sourceSavePath))
			{
				_autoSaveSourceSaveName = null;
				return;
			}
			List<string> list = CollectionPool<List<string>, string>.Get();
			List<string> list2 = CollectionPool<List<string>, string>.Get();
			list.AddRange(sourceSavePath.Split('/'));
			foreach (string item in list)
			{
				list2.AddRange(item.Split('\\'));
			}
			string text = list2[list2.Count - 1];
			CollectionPool<List<string>, string>.Release(list);
			CollectionPool<List<string>, string>.Release(list2);
			if (!text.Equals("AutoSave"))
			{
				this.Log("Set auto save source path " + sourceSavePath, "SetAutoSaveSourceSaveName", 128);
				_autoSaveSourceSaveName = text;
			}
		}

		public override bool TryLoadSaveData(string fullPath)
		{
			return TryLoadSaveDataInternal<SaveInfoSaveData>(fullPath);
		}

		public int CompareTo(SaveInfoPersistentSO other)
		{
			if (other == null)
			{
				return 1;
			}
			return LastModifiedTime.CompareTo(other.LastModifiedTime);
		}
	}
}
