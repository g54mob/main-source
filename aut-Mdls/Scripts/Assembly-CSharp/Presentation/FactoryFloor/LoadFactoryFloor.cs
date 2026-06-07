#define ENABLE_DEBUG_EXCEPTIONS
#define ENABLE_DEBUG_LOGS
using System.Collections.Generic;
using System.IO;
using Data.Variables;
using Events.Generic;
using Logic.Factory;
using NaughtyAttributes;
using SaveData.FactoryFloor;
using UnityEngine;
using Utils;

namespace Presentation.FactoryFloor
{
	public class LoadFactoryFloor : MonoBehaviour
	{
		[SerializeField]
		private StringEvent _levelFinishedLoadingEvent;

		[SerializeField]
		private FactoryLoader _factoryLoader;

		[SerializeField]
		private FactorySaver _factorySaver;

		[SerializeField]
		private StringVariableSO _currentEditorWorkingPath;

		[SerializeField]
		private StringVariableSO _currentEditorLevelName;

		[SerializeField]
		private SaveFileUtils _saveFileUtilsSO;

		[SerializeField]
		private SaveInfoToLoadSO _saveInfoToLoad;

		[SerializeField]
		private ZenModeVariableSO _zenModeSO;

		[SerializeField]
		private CurrentSavePathSO _currentSavePath;

		private void Awake()
		{
			_levelFinishedLoadingEvent.Register(LevelFinishedLoading);
			_currentEditorWorkingPath.SetValue(Path.Combine(SaveSystem.StreamingAssetsPath, "Levels"));
			_currentEditorLevelName.SetValue("Level");
		}

		private void OnDestroy()
		{
			_levelFinishedLoadingEvent.UnRegister(LevelFinishedLoading);
		}

		[Button("Save Level", EButtonEnableMode.Always)]
		public void SaveLevel()
		{
			SaveSystem.GetFullSavePathForFileName("Levels");
			_factorySaver.SaveFactory(SaveSystem.CreateFullLevelsSavePath("Level"));
		}

		[Button(null, EButtonEnableMode.Always)]
		public void LoadLevel()
		{
			LevelFinishedLoading(string.Empty);
		}

		private void LevelFinishedLoading(string sceneName)
		{
			if (_saveInfoToLoad.Value != null)
			{
				LoadFromLoadInfo();
			}
			else
			{
				TryFindSaveToLoad();
			}
		}

		private void LoadFromLoadInfo()
		{
			string path = _saveInfoToLoad.Value.SavePath;
			if (SaveSystem.DoesDirectoryExist(path))
			{
				StartCoroutine(_factoryLoader.TryLoadLevel(path));
				return;
			}
			StartCoroutine(_factoryLoader.TryLoadLevel(_saveInfoToLoad.Value.NewSaveMapPath, delegate
			{
				OnFactoryLoadedFromLoadInfo(path);
			}, _saveInfoToLoad.Value.NewSaveIsZen));
		}

		private void OnFactoryLoadedFromLoadInfo(string path)
		{
			_currentSavePath.SetValue(path);
			_factorySaver.SaveFactory(path);
		}

		private void TryFindSaveToLoad()
		{
			List<SaveFile> saveFiles = _saveFileUtilsSO.GetSaveFiles();
			string savePath;
			string text = (savePath = ((saveFiles.Count > 0) ? saveFiles[0].Path : SaveSystem.CreateFullLevelsSavePath("DefaultLevel")));
			if (Directory.Exists(SaveSystem.AutoSavePath) && _saveFileUtilsSO.TryGetSaveFile("AutoSave", SaveSystem.AutoSavePath, out var outSaveFile))
			{
				if (saveFiles.Count == 0 || outSaveFile.Info.LastModifiedTime.Ticks > saveFiles[0].Info.LastModifiedTime.Ticks)
				{
					this.Log("Found autosave, loading that!!", "TryFindSaveToLoad", 94);
					StartCoroutine(_factoryLoader.TryLoadLevel(SaveSystem.AutoSavePath));
					return;
				}
				this.Log($"Found autosave, but it's older than save. Auto: {outSaveFile.Info.LastModifiedTime} save: {_saveFileUtilsSO.GetSaveFiles()[0].Info.LastModifiedTime}", "TryFindSaveToLoad", 99);
			}
			if (!SaveSystem.TryLoadData<FactoryFloorSaveData>(text + "/level.json", out var data))
			{
				this.Log("Could not find any factory save data for the specified level at " + text, "TryFindSaveToLoad", 105);
				text = GetFullLevelStreamingAssetPath();
				if (!SaveSystem.TryLoadData<FactoryFloorSaveData>(text + "/level.json", out data))
				{
					this.DevException("Could not find any level terrain data at " + text, "TryFindSaveToLoad", 111);
				}
				else if (SaveInfoToLoadSO.IsSaveablePath(savePath))
				{
					StartCoroutine(_factoryLoader.TryLoadLevel(text, delegate
					{
						_factorySaver.SaveFactory(savePath);
					}));
				}
			}
			else
			{
				StartCoroutine(_factoryLoader.TryLoadLevel(text));
			}
		}

		private string GetFullLevelStreamingAssetPath()
		{
			if (_zenModeSO.Value)
			{
				return SaveSystem.CreateFullLevelsStreamingAssetPath("DefaultLevelCreative");
			}
			return SaveSystem.CreateFullLevelsStreamingAssetPath("DefaultLevel");
		}
	}
}
