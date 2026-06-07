#define ENABLE_DEBUG_LOGS
#define ENABLE_DEBUG_ERRORS
#define ENABLE_DEBUG_EXCEPTIONS
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Data.FactoryFloor;
using Data.Operator;
using Data.SaveData;
using Data.SaveData.PersistentSOs;
using Data.Variables;
using NaughtyAttributes;
using SFB;
using SaveData.FactoryFloor;
using Unity.Collections;
using UnityEngine;
using UnityEngine.InputSystem;
using Utils;
using Utils.JsonConverterUtils;

namespace Logic.Factory.Map
{
	[CreateAssetMenu(menuName = "Factory/Tools/Map/MapOverrider", fileName = "MapOverrider", order = 0)]
	public class MapOverrider : ScriptableObject
	{
		[SerializeField]
		private InputActionAsset _input;

		[SerializeField]
		private StreamingAssetsPathVariableSO _currentMapWorkingStreamingAssetsPath;

		[SerializeField]
		private PersistentSOLibrary _persistentSOLibrary;

		[SerializeField]
		private SaveInfoPersistentSO _saveInfoPersistentSO;

		[SerializeField]
		private DecorationsObjectDatabase _decorationsObjectDatabase;

		[SerializeField]
		private FactoryObjectData _gnnGateData;

		[Button(null, EButtonEnableMode.Always)]
		public void EditorOverrideMap()
		{
			_input.Disable();
			string levelDirectoryPath;
			try
			{
				string[] array = StandaloneFileBrowser.OpenFolderPanel("Select save directory", Application.streamingAssetsPath, multiselect: false);
				levelDirectoryPath = ((array.Length != 0) ? array[0] : string.Empty);
			}
			catch (Exception ex)
			{
				this.LogAssertion(ex.ToString(), "EditorOverrideMap", 43);
				_input.Enable();
				return;
			}
			string mapDirectoryPath;
			try
			{
				string[] array2 = StandaloneFileBrowser.OpenFolderPanel("Select map directory", _currentMapWorkingStreamingAssetsPath.Value, multiselect: false);
				mapDirectoryPath = ((array2.Length != 0) ? array2[0] : string.Empty);
			}
			catch (Exception ex2)
			{
				this.LogAssertion(ex2.ToString(), "EditorOverrideMap", 56);
				_input.Enable();
				return;
			}
			_input.Enable();
			TryOverrideLevelInternal(levelDirectoryPath, mapDirectoryPath);
		}

		public bool TryOverrideLevel(string levelDirectoryPath, string mapName)
		{
			string mapDirectoryPath = SaveSystem.CreateFullLevelsStreamingAssetPath(mapName);
			return TryOverrideLevelInternal(levelDirectoryPath, mapDirectoryPath);
		}

		private bool TryOverrideLevelInternal(string levelDirectoryPath, string mapDirectoryPath)
		{
			if (string.IsNullOrEmpty(levelDirectoryPath) || string.IsNullOrEmpty(mapDirectoryPath))
			{
				return false;
			}
			if (!SaveInfoToLoadSO.IsSaveablePath(levelDirectoryPath))
			{
				this.DevException("Overriding at this path is not allowed: \"" + levelDirectoryPath + "\"", "TryOverrideLevelInternal", 79);
				return false;
			}
			FactoryMapSaveData mapSaveData = null;
			if (!TryLoadMapSaveData(mapDirectoryPath, ref mapSaveData))
			{
				return false;
			}
			FactoryShapesSaveData levelShapesSaveData = null;
			if (!TryLoadShapesSaveData(levelDirectoryPath, ref levelShapesSaveData))
			{
				return false;
			}
			FactoryFloorSaveData factoryFloorSaveData = null;
			FactoryFloorSaveData mapFloorSaveData = null;
			if (!TryLoadLevelSaveData(mapDirectoryPath, levelShapesSaveData, ref mapFloorSaveData))
			{
				return false;
			}
			if (!TryLoadLevelSaveData(levelDirectoryPath, levelShapesSaveData, ref factoryFloorSaveData))
			{
				return false;
			}
			CopySaveDataFromOldToNewGGNGate(mapFloorSaveData, factoryFloorSaveData);
			RemoveMapFactoryObjects(factoryFloorSaveData.TerrainLayer);
			RemoveMapFactoryObjects(factoryFloorSaveData.EditableFloor);
			RemoveMapDecorations(mapFloorSaveData.TerrainLayer.SavedObjectDtos, out var mapDecorations);
			RemoveMapDecorations(mapFloorSaveData.EditableFloor.SavedObjectDtos, out var mapDecorations2);
			mapFloorSaveData.TerrainLayer.SavedObjectDtos.AddRange(factoryFloorSaveData.TerrainLayer.SavedObjectDtos);
			mapFloorSaveData.EditableFloor.SavedObjectDtos.AddRange(factoryFloorSaveData.EditableFloor.SavedObjectDtos);
			mapFloorSaveData.TerrainLayer.SavedObjectDtos.AddRange(mapDecorations);
			mapFloorSaveData.EditableFloor.SavedObjectDtos.AddRange(mapDecorations2);
			LoadSaveInfo(levelDirectoryPath, mapDirectoryPath, out var persistentSOPath, out var levelSaveInfo, out var newMapGuid);
			if (!TryCreateBackupOfDirectory(levelDirectoryPath, levelSaveInfo))
			{
				this.LogError("Failed TryCreateBackupOfDirectory() at " + levelDirectoryPath, "TryOverrideLevelInternal", 119);
				return false;
			}
			Task[] array = new Task[3];
			Task task = Task.Run((Func<Task>)ExecuteTrySaveMapDataAsync);
			array[0] = task;
			task = Task.Run((Func<Task>)ExecuteTrySaveShapesDataAsync);
			array[1] = task;
			task = Task.Run((Func<Task>)ExecuteTrySaveFactoryDataAsync);
			array[2] = task;
			levelSaveInfo.SetMapValues(levelSaveInfo.MapName, newMapGuid);
			levelSaveInfo.ApplyZenMode();
			bool num = _persistentSOLibrary.SavePersistentSO(persistentSOPath, levelSaveInfo);
			Task.WaitAll(array);
			if (!num)
			{
				this.LogError("Failed to save " + _saveInfoPersistentSO.name + " data", "TryOverrideLevelInternal", 145);
				return false;
			}
			this.Log("Success: Overrode save level \"" + levelDirectoryPath + "\" with map \"" + mapDirectoryPath + "\"", "TryOverrideLevelInternal", 148);
			return true;
			Task ExecuteTrySaveFactoryDataAsync()
			{
				return SaveSystem.TrySaveDataAsync(mapFloorSaveData, levelDirectoryPath, "level.json", new ShapeDtoToIndexConverter(levelShapesSaveData));
			}
			Task ExecuteTrySaveMapDataAsync()
			{
				return SaveSystem.TrySaveDataAsync(mapSaveData, levelDirectoryPath, "map.json");
			}
			Task ExecuteTrySaveShapesDataAsync()
			{
				return SaveSystem.TrySaveDataAsync(levelShapesSaveData, levelDirectoryPath, "shapes.json");
			}
		}

		private bool TryCreateBackupOfDirectory(string levelDirectoryPath, SaveInfoPersistentSO levelSaveInfo)
		{
			try
			{
				string text = levelDirectoryPath;
				if (text.Split('/', '\\')[^1] == "AutoSave")
				{
					text = SaveSystem.GameSavePath + "/Levels/" + _saveInfoPersistentSO.AutoSaveSourceSaveName;
					this.Log("Is AutoSave, using directory for creating backup path \"" + text + "\"", "TryCreateBackupOfDirectory", 161);
				}
				FileUtils.GetDirectoryAsBackupPath(text, out var destinationDirectory, out var _);
				FileUtils.CopyDirectoryTo(levelDirectoryPath, destinationDirectory, recursive: true);
				this.Log("Created backup copy of: \"" + levelDirectoryPath + "\"", "TryCreateBackupOfDirectory", 165);
			}
			catch (Exception ex)
			{
				this.LogAssertion(ex.ToString(), "TryCreateBackupOfDirectory", 169);
				return false;
			}
			return true;
		}

		private void RemoveMapDecorations(List<SavedObjectDto> savedObjectDtos, out List<SavedObjectDto> mapDecorations)
		{
			HashSet<int> hashSet = new HashSet<int>();
			foreach (FactoryObjectData decorationData in _decorationsObjectDatabase.DecorationDatas)
			{
				hashSet.Add(decorationData.ID);
			}
			mapDecorations = new List<SavedObjectDto>();
			for (int num = savedObjectDtos.Count - 1; num >= 0; num--)
			{
				SavedObjectDto savedObjectDto = savedObjectDtos[num];
				if (savedObjectDto.ApartOfMap && hashSet.Contains(savedObjectDto.FactoryObjectDataId))
				{
					mapDecorations.Add(savedObjectDto);
					savedObjectDtos.RemoveAtSwapBack(num);
				}
			}
		}

		private void LoadSaveInfo(string levelDirectoryPath, string mapDirectoryPath, out string persistentSOPath, out SaveInfoPersistentSO levelSaveInfo, out Guid newMapGuid)
		{
			persistentSOPath = mapDirectoryPath + "/PersistentSOs";
			_persistentSOLibrary.LoadCopyOfPersistentSO(persistentSOPath, _saveInfoPersistentSO, out var outCopy);
			newMapGuid = (outCopy as SaveInfoPersistentSO).MapGuid;
			persistentSOPath = levelDirectoryPath + "/PersistentSOs";
			_persistentSOLibrary.LoadCopyOfPersistentSO(persistentSOPath, _saveInfoPersistentSO, out var outCopy2);
			levelSaveInfo = outCopy2 as SaveInfoPersistentSO;
		}

		private bool TryLoadMapSaveData(string directoryPath, ref FactoryMapSaveData factoryMapSaveData)
		{
			if (factoryMapSaveData == null)
			{
				string text = directoryPath + "/map.json";
				if (!SaveSystem.TryLoadData<FactoryMapSaveData>(text, out factoryMapSaveData))
				{
					this.LogError("Could not find any level map data at " + text, "TryLoadMapSaveData", 214);
					return false;
				}
			}
			if (factoryMapSaveData == null)
			{
				this.LogError("Trying to load a null map save data", "TryLoadMapSaveData", 221);
				return false;
			}
			return true;
		}

		private bool TryLoadShapesSaveData(string directoryPath, ref FactoryShapesSaveData factoryShapesSaveData)
		{
			if (factoryShapesSaveData == null)
			{
				string text = directoryPath + "/shapes.json";
				if (!SaveSystem.TryLoadData<FactoryShapesSaveData>(text, out factoryShapesSaveData))
				{
					this.LogError("Failed to load file at path: \"" + text + "\"", "TryLoadShapesSaveData", 234);
					return false;
				}
			}
			if (factoryShapesSaveData == null)
			{
				this.LogError("Trying to load a null shapes save data", "TryLoadShapesSaveData", 241);
				return false;
			}
			return true;
		}

		private bool TryLoadLevelSaveData(string directoryPath, FactoryShapesSaveData factoryShapesSaveData, ref FactoryFloorSaveData factoryFloorSaveData)
		{
			if (factoryFloorSaveData == null)
			{
				string text = directoryPath + "/level.json";
				if (!SaveSystem.TryLoadData<FactoryFloorSaveData>(text, out factoryFloorSaveData, new ShapeDtoToIndexConverter(factoryShapesSaveData)))
				{
					this.LogError("Could not find any level terrain data at " + text, "TryLoadLevelSaveData", 254);
					return false;
				}
			}
			if (factoryFloorSaveData == null)
			{
				this.LogError("Trying to load a null level save data", "TryLoadLevelSaveData", 261);
				return false;
			}
			return true;
		}

		private void RemoveMapFactoryObjects(FactoryLayerSaveData factoryLayer)
		{
			for (int num = factoryLayer.SavedObjectDtos.Count - 1; num >= 0; num--)
			{
				if (factoryLayer.SavedObjectDtos[num].ApartOfMap)
				{
					factoryLayer.SavedObjectDtos.RemoveAt(num);
				}
			}
		}

		private void CopySaveDataFromOldToNewGGNGate(FactoryFloorSaveData mapFloorSaveData, FactoryFloorSaveData levelFloorSaveData)
		{
			if (TryFindGNNGate(mapFloorSaveData, out var gnnGate) && TryFindGNNGate(levelFloorSaveData, out var gnnGate2))
			{
				gnnGate.BehaviourConfigurationDtos = gnnGate2.BehaviourConfigurationDtos;
				gnnGate.BehaviourSaveStateDtos = gnnGate2.BehaviourSaveStateDtos;
			}
		}

		private bool TryFindGNNGate(FactoryFloorSaveData factoryFloorSaveData, out SavedObjectDto gnnGate)
		{
			foreach (SavedObjectDto savedObjectDto in factoryFloorSaveData.EditableFloor.SavedObjectDtos)
			{
				if (savedObjectDto.FactoryObjectDataId == _gnnGateData.ID)
				{
					gnnGate = savedObjectDto;
					return true;
				}
			}
			gnnGate = null;
			return false;
		}
	}
}
