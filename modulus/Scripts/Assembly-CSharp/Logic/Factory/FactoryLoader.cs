#define ENABLE_DEBUG_EXCEPTIONS
#define ENABLE_DEBUG_LOGS
#define ENABLE_DEBUG_ERRORS
using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using Data.FactoryFloor;
using Data.FactoryFloor.Islands;
using Data.FactoryFloor.Maps;
using Data.Operator;
using Data.SaveData;
using Data.SaveData.PersistentSOs;
using Data.Shapes;
using Data.Variables;
using Events;
using Events.Analytics;
using Events.FactoryFloor;
using Events.FactoryFloor.Islands;
using Events.Generic;
using GameAnalyticsSDK;
using Newtonsoft.Json;
using Presentation.FactoryFloor.Islands;
using Presentation.Locators;
using Presentation.UI.LoadingScreen;
using SaveData.FactoryFloor;
using SaveData.FactoryFloor.Map;
using UnityEngine;
using Utils;
using Utils.JsonConverterUtils;

namespace Logic.Factory
{
	[CreateAssetMenu(menuName = "Factory/Tools/FactoryLoader", fileName = "FactoryLoader", order = 0)]
	public class FactoryLoader : ScriptableObject
	{
		private const int MAX_MILISECONDS_BETWEEN_FRAMES = 500;

		[SerializeField]
		private PersistentSOLibrary _persistentSOLibrary;

		[SerializeField]
		private ReferenceObjectDatabase _referenceObjectDatabase;

		[SerializeField]
		private CurrentSavePathSO _currentSavePath;

		[SerializeField]
		private SaveInfoPersistentSO _saveInfoPersistentSO;

		[SerializeField]
		private UnlockedIslandsPersistentSO _unlockedIslandsPersistent;

		[SerializeField]
		private ZenModeVariableSO _zenModeSO;

		[SerializeField]
		private MaxZoomLevelModifierSO _maxZoomLevelModifier;

		[SerializeField]
		private LoadingScreenProgressVariableSO _loadingScreenProgressVariable;

		[Header("Level")]
		[SerializeField]
		private FactoryClearer _factoryClearer;

		[SerializeField]
		private FactoryLayer _terrainLayer;

		[SerializeField]
		private FactoryLayer _factoryLayer;

		[SerializeField]
		private FactoryObjectDatabase _factoryObjectDatabase;

		[SerializeField]
		private GridLocator _gridLocator;

		[SerializeField]
		private IntListEvent _factoryObjectsRemoveViewsEvent;

		[Header("Shapes")]
		[SerializeField]
		private ShapesDatabase _shapesDatabase;

		[Header("Map")]
		[SerializeField]
		private IslandDatabase _islandsDatabase;

		[SerializeField]
		private IslandLayer _islandLayer;

		[SerializeField]
		private GridLocator _gridMapLocator;

		[SerializeField]
		private CameraViewLocator _cameraViewLocator;

		[Header("Load Events")]
		[SerializeField]
		private BaseEvent _preLoadingSaveEvent;

		[SerializeField]
		private BaseEvent _startLoadingSaveEvent;

		[SerializeField]
		private BaseEvent _finishedLoadingSaveEvent;

		[SerializeField]
		private BoolEvent _levelFinishedLoadingZenModeEvent;

		[SerializeField]
		private BoolVariableSO _isLoadingSave;

		[Header("Factory Events")]
		[SerializeField]
		protected CreateFactoryObjectEvent _createFactoryObjectEvent;

		[SerializeField]
		private IslandObjectEvent _createIslandObjectEvent;

		[Header("Other Events")]
		[SerializeField]
		private AnalyticsProgressionEvent _analyticsProgressionEvent;

		[SerializeField]
		private BaseEvent _hideNarrationDialogEvent;

		[SerializeField]
		private BaseEvent _generateGrass;

		[Header("Global Update Multiplier")]
		[SerializeField]
		private IntVariableSO _globalUpdateMultiplier;

		private int _previousGlobalUpdateMultiplier;

		private bool _hasFinishedLoadingSave;

		public bool HasFinishedLoadingSave => _hasFinishedLoadingSave;

		public IEnumerator TryLoadLevel(string directoryPath, Action<bool> callback = null, bool? setZenMode = null)
		{
			yield return StartLoadLevel(directoryPath);
			SaveInfoPersistentSO saveInfo = LoadAndApplyPersistentSOs(directoryPath, setZenMode);
			yield return SetLoadingScreenProgress(LoadingProgressEnum.LoadAllPersistentSOs);
			if (!SaveDirectoryVersionsHandler.TryHandle(directoryPath, saveInfo, out var factoryShapesSaveData, out var factoryFloorSaveData, out var factoryMapSaveData))
			{
				this.LogError($"Trying to load a unsupported save directory version {saveInfo.SaveDirectoryVersion}", "TryLoadLevel", 99);
				_finishedLoadingSaveEvent.Fire();
				_isLoadingSave.SetValue(value: false);
				callback?.Invoke(obj: false);
				yield break;
			}
			yield return SetLoadingScreenProgress(LoadingProgressEnum.SaveDirectoryVersionsHandler);
			string backupPath = SaveSystem.ConvertToGameSaveBackupDirectory(directoryPath);
			IEnumerator<FactoryMapSaveData> mapSaveDataCoroutine = TryLoadSaveData(directoryPath + "/map.json", factoryMapSaveData);
			yield return mapSaveDataCoroutine;
			factoryMapSaveData = mapSaveDataCoroutine.Current;
			if (factoryMapSaveData == null)
			{
				mapSaveDataCoroutine = TryLoadSaveData(backupPath + "/map.json", factoryMapSaveData);
				yield return mapSaveDataCoroutine;
				factoryMapSaveData = mapSaveDataCoroutine.Current;
			}
			if (factoryMapSaveData == null)
			{
				string text = SaveSystem.CreateFullLevelsStreamingAssetPath(saveInfo.MapName);
				mapSaveDataCoroutine = TryLoadSaveData(text + "/map.json", factoryMapSaveData);
				yield return mapSaveDataCoroutine;
				factoryMapSaveData = mapSaveDataCoroutine.Current;
			}
			if (factoryMapSaveData == null)
			{
				_finishedLoadingSaveEvent.Fire();
				_isLoadingSave.SetValue(value: false);
				callback?.Invoke(obj: false);
				yield break;
			}
			yield return SetLoadingScreenProgress(LoadingProgressEnum.LoadedMap);
			yield return ApplyMapSaveData(factoryMapSaveData);
			IEnumerator<FactoryShapesSaveData> shapesSaveDataCoroutine = TryLoadSaveData(directoryPath + "/shapes.json", factoryShapesSaveData);
			yield return shapesSaveDataCoroutine;
			factoryShapesSaveData = shapesSaveDataCoroutine.Current;
			if (factoryShapesSaveData == null)
			{
				shapesSaveDataCoroutine = TryLoadSaveData(backupPath + "/shapes.json", factoryShapesSaveData);
				yield return shapesSaveDataCoroutine;
				factoryShapesSaveData = shapesSaveDataCoroutine.Current;
			}
			if (factoryShapesSaveData == null)
			{
				_finishedLoadingSaveEvent.Fire();
				_isLoadingSave.SetValue(value: false);
				callback?.Invoke(obj: false);
				yield break;
			}
			yield return SetLoadingScreenProgress(LoadingProgressEnum.LoadedShapes);
			yield return ApplyShapesSaveData(factoryShapesSaveData);
			ShapeDtoToIndexConverter shapeConverter = new ShapeDtoToIndexConverter(factoryShapesSaveData);
			IEnumerator<FactoryFloorSaveData> factorySaveDataCoroutine = TryLoadSaveData(directoryPath + "/level.json", factoryFloorSaveData, shapeConverter);
			yield return factorySaveDataCoroutine;
			factoryFloorSaveData = factorySaveDataCoroutine.Current;
			if (factoryFloorSaveData == null)
			{
				factorySaveDataCoroutine = TryLoadSaveData(backupPath + "/level.json", factoryFloorSaveData, shapeConverter);
				yield return factorySaveDataCoroutine;
				factoryFloorSaveData = factorySaveDataCoroutine.Current;
			}
			if (factoryFloorSaveData == null)
			{
				_finishedLoadingSaveEvent.Fire();
				_isLoadingSave.SetValue(value: false);
				callback?.Invoke(obj: false);
			}
			else
			{
				yield return SetLoadingScreenProgress(LoadingProgressEnum.LoadedLevel);
				yield return ApplyLevelSaveData(factoryFloorSaveData);
				yield return FinishLoadLevel(directoryPath, factoryMapSaveData, setZenMode);
				callback?.Invoke(obj: true);
				_loadingScreenProgressVariable.SetValue(LoadingProgressEnum.End);
			}
		}

		private IEnumerator SetLoadingScreenProgress(LoadingProgressEnum value)
		{
			_loadingScreenProgressVariable.SetValue(value);
			yield return null;
		}

		private IEnumerator<T> TryLoadSaveData<T>(string levelFilePath, T saveData, params JsonConverter[] converters) where T : class
		{
			if (saveData == null)
			{
				Task<T> task = SaveSystem.LoadDataAsync<T>(levelFilePath, converters);
				while (!task.IsCompleted)
				{
					yield return null;
				}
				if (task.IsFaulted || task.IsCanceled || task.Result == null)
				{
					this.LogError("Could not find any " + typeof(T).Name + " at " + levelFilePath, "TryLoadSaveData", 212);
					yield break;
				}
				saveData = task.Result;
			}
			if (saveData == null)
			{
				this.LogError("Trying to load a null " + typeof(T).Name, "TryLoadSaveData", 221);
			}
			else
			{
				yield return saveData;
			}
		}

		private void PauseGame(bool paused)
		{
			if (paused)
			{
				_previousGlobalUpdateMultiplier = _globalUpdateMultiplier.Value;
				_globalUpdateMultiplier.SetValue(0);
			}
			else
			{
				_globalUpdateMultiplier.SetValue(_previousGlobalUpdateMultiplier);
			}
		}

		private IEnumerator FinishLoadLevel(string directoryPath, FactoryMapSaveData factoryMapSaveData, bool? zenMode)
		{
			this.Log("Level Loaded: \"" + directoryPath + "\"", "FinishLoadLevel", 243);
			_finishedLoadingSaveEvent.Fire();
			_levelFinishedLoadingZenModeEvent.Fire(zenMode.HasValue && zenMode.Value);
			_isLoadingSave.SetValue(value: false);
			_hasFinishedLoadingSave = true;
			_analyticsProgressionEvent.Fire((GAProgressionStatus.Start, "level_load", "", ""));
			_generateGrass.Fire();
			_cameraViewLocator.CameraView.SetMovementBounds(factoryMapSaveData.Bounds);
			_cameraViewLocator.CameraView.ToggleCameraEnabled(enabled: true);
			yield return SetLoadingScreenProgress(LoadingProgressEnum.FinishedLoadingFactory);
			PauseGame(paused: false);
			yield return SetLoadingScreenProgress(LoadingProgressEnum.UnPause);
		}

		private IEnumerator StartLoadLevel(string directoryPath)
		{
			PauseGame(paused: true);
			yield return null;
			_currentSavePath.SetValue(directoryPath);
			_hasFinishedLoadingSave = false;
			_preLoadingSaveEvent.Fire();
			_factoryClearer.ClearLevel();
			_referenceObjectDatabase.Reset();
			_startLoadingSaveEvent.Fire();
			_isLoadingSave.SetValue(value: true);
			_cameraViewLocator.CameraView.ToggleCameraEnabled(enabled: false);
			yield return SetLoadingScreenProgress(LoadingProgressEnum.StartLoadingFactory);
		}

		private SaveInfoPersistentSO LoadAndApplyPersistentSOs(string directoryPath, bool? setZenMode)
		{
			string text = directoryPath + "/PersistentSOs";
			string backupPath = SaveSystem.ConvertToGameSaveBackupDirectory(directoryPath) + "/PersistentSOs";
			_persistentSOLibrary.ResetPersistentSOs();
			_persistentSOLibrary.LoadAllPersistentSOs(text, backupPath);
			if (setZenMode.HasValue)
			{
				_saveInfoPersistentSO.SetZenMode(setZenMode.Value);
			}
			_saveInfoPersistentSO.ApplyZenMode();
			if (SaveInfoToLoadSO.IsSaveablePath(directoryPath))
			{
				AbstractSaveData saveData = _saveInfoPersistentSO.GetSaveData();
				string fullSavePath = SaveSystem.CreateFullPath(text, _saveInfoPersistentSO.name + ".json");
				SaveSystem.TrySaveData(saveData, fullSavePath);
			}
			_referenceObjectDatabase.Reset();
			return _saveInfoPersistentSO;
		}

		private IEnumerator ApplyMapSaveData(FactoryMapSaveData factoryMapSaveData)
		{
			foreach (FactoryIslandSaveData factoryIslandSaveData in factoryMapSaveData.FactoryIslandSaveDatas)
			{
				_islandsDatabase.TryLoadIsland(factoryIslandSaveData);
			}
			yield return SetLoadingScreenProgress(LoadingProgressEnum.LoadedIslandsIntoDatabase);
			DateTime lastFrameTime = DateTime.Now;
			for (int i = 0; i < factoryMapSaveData.Islands.Count; i++)
			{
				if ((DateTime.Now - lastFrameTime).Milliseconds > 500)
				{
					float lerp = (float)i / (float)factoryMapSaveData.Islands.Count;
					_loadingScreenProgressVariable.SetValueLerp(LoadingProgressEnum.LoadedIslandsIntoDatabase, LoadingProgressEnum.AppliedMap, lerp);
					lastFrameTime = DateTime.Now;
					yield return null;
				}
				IslandInMapSaveData island = factoryMapSaveData.Islands[i];
				LoadIsland(island);
			}
			IslandObject islandAtGridPosition = _islandLayer.GetIslandAtGridPosition(Vector3Int.zero);
			_unlockedIslandsPersistent.UnlockIsland(islandAtGridPosition);
			this.Log($"ISLAND {islandAtGridPosition.CreatedId} start unlocked", "ApplyMapSaveData", 338);
			yield return SetLoadingScreenProgress(LoadingProgressEnum.AppliedMap);
		}

		private void LoadIsland(IslandInMapSaveData island)
		{
			IslandData islandDataById = _islandsDatabase.GetIslandDataById(island.Id);
			if (islandDataById == null)
			{
				this.DevException(string.Format("Failed to find island {0} in {1}", island.Id, "_islandsDatabase"), "LoadIsland", 347);
				return;
			}
			Vector2Int sizeUnit = islandDataById.Size + new Vector2Int(16, 16);
			Vector2Int vector2Int = new Vector2Int((int)_gridMapLocator.GetCellSize().x, (int)_gridMapLocator.GetCellSize().z);
			Vector2Int vector2Int2 = new Vector2Int(sizeUnit.x / vector2Int.x, sizeUnit.y / vector2Int.y);
			List<Vector3Int> occupiedGridPositions = GridUtils.GetOccupiedGridPositions(island.Position, vector2Int2);
			if (!_islandLayer.CanPlaceIsland(occupiedGridPositions))
			{
				this.DevException($"Failed to place island {island.Id} at {island.Position}", "LoadIsland", 359);
				return;
			}
			IslandConfig islandConfig = new IslandConfig(islandDataById, IntIdGenerator.GetNewId, GetWorldPosition(occupiedGridPositions[0], vector2Int2), islandDataById.Size, sizeUnit, island.Rotation, new IslandConfig.IslandBottomPrefabConfig(island.IslandBottomIndex, island.IslandBottomRotation), island.IsGNNGateIsland);
			IslandObject islandObject = new IslandObject(islandConfig, occupiedGridPositions, _maxZoomLevelModifier);
			_islandLayer.AddIsland(islandObject);
			_createIslandObjectEvent.Fire(islandObject);
			this.Log($"ISLAND {island.Id} in position: {island.Position} position 0: {occupiedGridPositions[0]} world position: {islandConfig.Position}", "LoadIsland", 370);
		}

		private Vector3 GetWorldPosition(Vector3Int position, Vector2Int sizeScaled)
		{
			if (sizeScaled.x % 2 != 0)
			{
				return _gridMapLocator.GetWorldPosition(position);
			}
			return _gridMapLocator.GetWorldPosition(position) - _gridMapLocator.GetCellSize() / 2f;
		}

		private IEnumerator ApplyShapesSaveData(FactoryShapesSaveData factoryShapesSaveData)
		{
			int startCount = _shapesDatabase.ShapeCount;
			Task handle = Task.Run((Func<Task>)ExecuteLoadShapesAsync);
			do
			{
				yield return null;
				float lerp = (float)(_shapesDatabase.ShapeCount - startCount) / (float)factoryShapesSaveData.Shapes.Length;
				_loadingScreenProgressVariable.SetValueLerp(LoadingProgressEnum.LoadedShapes, LoadingProgressEnum.AppliedShapes, lerp);
			}
			while (!handle.IsCompleted);
			_loadingScreenProgressVariable.SetValue(LoadingProgressEnum.AppliedShapes);
			Task ExecuteLoadShapesAsync()
			{
				return _shapesDatabase.LoadShapesAsync(factoryShapesSaveData.Shapes);
			}
		}

		private IEnumerator ApplyLevelSaveData(FactoryFloorSaveData factoryFloorSaveData)
		{
			List<SavedObjectDto> softLinkedObjects = new List<SavedObjectDto>();
			List<SavedObjectDto> hardLinkedObjects = new List<SavedObjectDto>();
			yield return LoadLayer(factoryFloorSaveData.TerrainLayer, _terrainLayer, softLinkedObjects, hardLinkedObjects, LoadingProgressEnum.LoadedLevel, LoadingProgressEnum.AppliedLevelTerrain);
			_loadingScreenProgressVariable.SetValue(LoadingProgressEnum.AppliedLevelTerrain);
			yield return null;
			yield return LoadLayer(factoryFloorSaveData.EditableFloor, _factoryLayer, softLinkedObjects, hardLinkedObjects, LoadingProgressEnum.AppliedLevelTerrain, LoadingProgressEnum.AppliedLevelFactory);
			_loadingScreenProgressVariable.SetValue(LoadingProgressEnum.AppliedLevelFactory);
			yield return null;
		}

		private IEnumerator LoadLayer(FactoryLayerSaveData factoryLayerSaveData, FactoryLayer factoryLayer, List<SavedObjectDto> softLinkedObjects, List<SavedObjectDto> hardLinkedObjects, LoadingProgressEnum fromLoadingProgress, LoadingProgressEnum toLoadingProgress)
		{
			if (factoryLayerSaveData == null)
			{
				yield break;
			}
			DateTime lastFrameTime = DateTime.Now;
			for (int i = 0; i < factoryLayerSaveData.SavedObjectDtos.Count; i++)
			{
				if ((DateTime.Now - lastFrameTime).Milliseconds > 500)
				{
					_loadingScreenProgressVariable.SetValueLerp(fromLoadingProgress, toLoadingProgress, (float)i / (float)factoryLayerSaveData.SavedObjectDtos.Count);
					lastFrameTime = DateTime.Now;
					yield return null;
				}
				SavedObjectDto savedObjectDto = factoryLayerSaveData.SavedObjectDtos[i];
				if (!TryCreateFactoryObject(savedObjectDto, factoryLayer))
				{
					if (!savedObjectDto.IsHardLinked())
					{
						continue;
					}
					foreach (Vector3Int position in savedObjectDto.HardLinkedPositions)
					{
						int num = factoryLayerSaveData.SavedObjectDtos.FindIndex((SavedObjectDto e) => e.GetPosition() == position);
						if (i >= num)
						{
							this.LogError($"Removing hard linked at {position}", "LoadLayer", 449);
							FactoryObject objectAt = factoryLayer.GetObjectAt(position);
							factoryLayer.RemoveObjectAt(position);
							_factoryObjectsRemoveViewsEvent.Fire(new List<int> { objectAt.CreatedId });
						}
						else
						{
							factoryLayerSaveData.SavedObjectDtos.RemoveAt(num);
						}
					}
				}
				else if (savedObjectDto.IsSoftLinked())
				{
					softLinkedObjects.Add(savedObjectDto);
				}
				else if (savedObjectDto.IsHardLinked())
				{
					hardLinkedObjects.Add(savedObjectDto);
				}
			}
			HardLinkObjects(hardLinkedObjects, factoryLayer);
			SoftLinkObjects(softLinkedObjects, factoryLayer);
			softLinkedObjects.Clear();
			hardLinkedObjects.Clear();
		}

		private void HardLinkObjects(List<SavedObjectDto> hardLinkedObjects, FactoryLayer factoryLayer)
		{
			foreach (SavedObjectDto hardLinkedObject in hardLinkedObjects)
			{
				Vector3Int position = hardLinkedObject.GetPosition();
				FactoryObject objectAt = factoryLayer.GetObjectAt(position);
				if (objectAt == null)
				{
					continue;
				}
				foreach (Vector3Int hardLinkedPosition in hardLinkedObject.HardLinkedPositions)
				{
					FactoryObject objectAt2 = factoryLayer.GetObjectAt(hardLinkedPosition);
					if (objectAt2 == null)
					{
						this.LogError($"Factory object missing hard link factory object. Destroying this object:\n{objectAt}", "HardLinkObjects", 499);
						factoryLayer.RemoveObjectAt(position);
						break;
					}
					objectAt.HardLink(objectAt2);
				}
			}
		}

		private void SoftLinkObjects(List<SavedObjectDto> softLinkedObjects, FactoryLayer factoryLayer)
		{
			foreach (SavedObjectDto softLinkedObject in softLinkedObjects)
			{
				Vector3Int position = softLinkedObject.GetPosition();
				FactoryObject objectAt = factoryLayer.GetObjectAt(position);
				if (objectAt == null)
				{
					continue;
				}
				foreach (Vector3Int softLinkedPosition in softLinkedObject.SoftLinkedPositions)
				{
					FactoryObject objectAt2 = factoryLayer.GetObjectAt(softLinkedPosition);
					objectAt.SoftLink(objectAt2);
				}
			}
		}

		private bool TryCreateFactoryObject(SavedObjectDto savedObjectDto, FactoryLayer layer)
		{
			if (!_factoryObjectDatabase.TryGetObjectDataWithId(savedObjectDto.FactoryObjectDataId, out var factoryObjectData))
			{
				return false;
			}
			FactoryObject factoryObject = savedObjectDto.ToFactoryObject(layer, factoryObjectData, IntIdGenerator.GetNewId);
			if (!layer.TryAddFactoryObject(factoryObject))
			{
				return false;
			}
			_createFactoryObjectEvent.Fire(new CreateFactoryObjectDto(_gridLocator.GetWorldPosition(factoryObject.Position), factoryObject.Rotation, factoryObject.Mirrored, factoryObject, -1, isGameLoading: true));
			return true;
		}
	}
}
