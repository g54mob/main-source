#define ENABLE_DEBUG_ERRORS
#define ENABLE_DEBUG_EXCEPTIONS
using System;
using System.Collections.Generic;
using Data.FactoryFloor.Islands;
using Data.FactoryFloor.Maps;
using Data.SaveData.PersistentSOs;
using Data.Shapes;
using Data.Variables;
using Presentation.Locators;
using SFB;
using SaveData.FactoryFloor;
using SaveData.FactoryFloor.Island;
using SaveData.FactoryFloor.Map;
using UnityEngine;
using UnityEngine.InputSystem;
using Utils;

namespace Logic.Factory.Map
{
	[CreateAssetMenu(menuName = "Factory/Tools/Map/MapExporter", fileName = "MapExporter", order = 0)]
	public class MapExporter : ScriptableObject
	{
		[SerializeField]
		private IslandDatabase _islandsDatabase;

		[SerializeField]
		private IslandLayer _islandLayer;

		[SerializeField]
		private GridLocator _gridLocator;

		[SerializeField]
		private GridLocator _gridMapLocator;

		[SerializeField]
		private InputActionAsset _input;

		[SerializeField]
		private StreamingAssetsPathVariableSO _currentMapWorkingStreamingAssetsPath;

		[SerializeField]
		private SaveInfoPersistentSO _saveInfoPersistentSO;

		public void ExportCurrentMap(bool isZenMode)
		{
			List<IslandInMapSaveData> allIslandsInMap = _islandLayer.GetAllIslandsInMap();
			GetFactoryObjects(allIslandsInMap, out var terrainSavedObjectDtos, out var factorySavedObjectDtos);
			FactoryLayerSaveData terrainLayer = new FactoryLayerSaveData(terrainSavedObjectDtos);
			FactoryLayerSaveData editableFloor = new FactoryLayerSaveData(factorySavedObjectDtos);
			List<FactoryIslandSaveData> factoryIslandsSaveData = GetFactoryIslandsSaveData();
			FactoryFloorSaveData data = new FactoryFloorSaveData(terrainLayer, editableFloor);
			FactoryMapSaveData data2 = new FactoryMapSaveData(factoryIslandsSaveData, allIslandsInMap, _islandLayer.CalculateBounds());
			_input.Disable();
			string text;
			try
			{
				string[] array = StandaloneFileBrowser.OpenFolderPanel("Export map", _currentMapWorkingStreamingAssetsPath.Value, multiselect: false);
				text = ((array.Length != 0) ? array[0] : string.Empty);
			}
			catch (Exception ex)
			{
				this.LogAssertion(ex.ToString(), "ExportCurrentMap", 49);
				_input.Enable();
				return;
			}
			_input.Enable();
			if (!string.IsNullOrEmpty(text))
			{
				if (!SaveSystem.TrySaveData(data2, text + "/map.json"))
				{
					this.LogError("Failed to save map data", "ExportCurrentMap", 62);
				}
				if (!SaveSystem.TrySaveData(data, text + "/level.json"))
				{
					this.LogError("Failed to save level data", "ExportCurrentMap", 66);
				}
				if (!SaveSystem.TrySaveData(new FactoryShapesSaveData(new ShapeDto[0]), text + "/shapes.json"))
				{
					this.LogError("Failed to save shapes data", "ExportCurrentMap", 70);
				}
				string fullSavePath = SaveSystem.CreateFullPath(text + "/PersistentSOs", _saveInfoPersistentSO.name + ".json");
				string mapName = text.Split('\\', '/')[^1];
				_saveInfoPersistentSO.ResetToDefaults();
				_saveInfoPersistentSO.SetZenMode(isZenMode);
				_saveInfoPersistentSO.ApplyZenMode();
				_saveInfoPersistentSO.SetMapValues(mapName, Guid.NewGuid());
				if (!SaveSystem.TrySaveData(_saveInfoPersistentSO.GetSaveData(), fullSavePath))
				{
					this.LogError("Failed to save " + _saveInfoPersistentSO.name + " data", "ExportCurrentMap", 82);
				}
				_currentMapWorkingStreamingAssetsPath.SetValue(text);
			}
		}

		private List<FactoryIslandSaveData> GetFactoryIslandsSaveData()
		{
			List<FactoryIslandSaveData> list = new List<FactoryIslandSaveData>();
			foreach (IslandData allIslandData in _islandsDatabase.GetAllIslandDatas())
			{
				list.Add(new FactoryIslandSaveData(allIslandData));
			}
			return list;
		}

		private void GetFactoryObjects(List<IslandInMapSaveData> islandInMaps, out List<SavedObjectDto> terrainSavedObjectDtos, out List<SavedObjectDto> factorySavedObjectDtos)
		{
			Vector2Int vector2Int = new Vector2Int((int)_gridMapLocator.GetCellSize().x, (int)_gridMapLocator.GetCellSize().z);
			terrainSavedObjectDtos = new List<SavedObjectDto>();
			factorySavedObjectDtos = new List<SavedObjectDto>();
			foreach (IslandInMapSaveData islandInMap in islandInMaps)
			{
				IslandSaveData islandSaveDataById = _islandsDatabase.GetIslandSaveDataById(islandInMap.Id);
				Vector2Int vector2Int2 = _islandsDatabase.GetIslandDataById(islandInMap.Id).Size + new Vector2Int(16, 16);
				Vector3Int islandPosition = GetPositionInPlayGrid(sizeScaled: new Vector2Int(vector2Int2.x / vector2Int.x, vector2Int2.y / vector2Int.y), islandPosition: islandInMap.Position, rotation: islandInMap.Rotation);
				foreach (SavedObjectDto terrainSavedObjectDto in islandSaveDataById.TerrainSavedObjectDtos)
				{
					terrainSavedObjectDtos.Add(ConvertObject(terrainSavedObjectDto, islandPosition, islandInMap.Rotation));
				}
				foreach (SavedObjectDto factorySavedObjectDto in islandSaveDataById.FactorySavedObjectDtos)
				{
					factorySavedObjectDtos.Add(ConvertObject(factorySavedObjectDto, islandPosition, islandInMap.Rotation));
				}
			}
		}

		private Vector3Int GetPositionInPlayGrid(Vector3Int islandPosition, Vector2Int sizeScaled, int rotation)
		{
			return _gridLocator.GetCellPosition(GetWorldPosition(islandPosition, sizeScaled)) + AdjustWithRotation(rotation);
		}

		private Vector3Int AdjustWithRotation(int rotation)
		{
			return rotation switch
			{
				0 => Vector3Int.zero, 
				90 => Vector3Int.back, 
				270 => Vector3Int.left, 
				180 => Vector3Int.left + Vector3Int.back, 
				_ => Vector3Int.zero, 
			};
		}

		private Vector3 GetWorldPosition(Vector3Int position, Vector2Int sizeScaled)
		{
			if (sizeScaled.x % 2 == 0)
			{
				return _gridMapLocator.GetWorldPosition(position) - _gridMapLocator.GetCellSize() / 2f;
			}
			return _gridMapLocator.GetWorldPosition(position);
		}

		private SavedObjectDto ConvertObject(SavedObjectDto savedObject, Vector3Int islandPosition, int rotation)
		{
			int rotation2 = (savedObject.Rotation + rotation) % 360;
			return new SavedObjectDto(GridUtils.RotatePoint(savedObject.GetPosition(), rotation) + islandPosition, rotation2, savedObject.MirroredInt == 1, savedObject.NonChangableInt == 1, savedObject.FactoryObjectDataId, savedObject.SoftLinkedPositions, savedObject.HardLinkedPositions, savedObject.BehaviourConfigurationDtos, savedObject.BehaviourSaveStateDtos, isApartOfMap: true);
		}
	}
}
