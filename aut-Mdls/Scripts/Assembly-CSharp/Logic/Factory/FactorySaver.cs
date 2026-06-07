#define ENABLE_DEBUG_LOGS
#define ENABLE_DEBUG_EXCEPTIONS
using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using Data.FactoryFloor;
using Data.FactoryFloor.Islands;
using Data.FactoryFloor.Maps;
using Data.Lighting;
using Data.SaveData;
using Data.SaveData.PersistentSOs;
using Data.Shapes;
using Data.Variables;
using Events;
using Events.Lighting;
using Presentation.Locators;
using SaveData.FactoryFloor;
using SaveData.FactoryFloor.Map;
using UnityEngine;
using UnityEngine.Experimental.Rendering;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;
using Utils;
using Utils.JsonConverterUtils;

namespace Logic.Factory
{
	[CreateAssetMenu(menuName = "Factory/Tools/FactorySaver", fileName = "FactorySaver", order = 0)]
	public class FactorySaver : ScriptableObject
	{
		[SerializeField]
		private ShapesDatabase _shapesDatabase;

		[SerializeField]
		private PersistentSOLibrary _persistentSOLibrary;

		[SerializeField]
		private SaveInfoPersistentSO _saveInfoPersistentSO;

		[SerializeField]
		private BaseEvent _finishedSavingEvent;

		[Header("Map")]
		[SerializeField]
		private IslandDatabase _islandsDatabase;

		[SerializeField]
		private IslandLayer _islandLayer;

		[Header("Level")]
		[SerializeField]
		private FactoryLayer _terrainLayer;

		[SerializeField]
		private FactoryLayer _factoryLayer;

		[Header("Thumbnail References")]
		[SerializeField]
		private CameraLocator _cameraLocator;

		[SerializeField]
		private RenderTexture _saveThumbnailRenderTex;

		[SerializeField]
		private GraphicsFormat _textureFormat;

		[SerializeField]
		private SetDirectionalLightEventSO _setDirectionalLightEventSO;

		[SerializeField]
		private SetLightingConfigEventSO _setLightingConfigEvent;

		[SerializeField]
		private BaseEvent _resetToDefaultLightingConfigEvent;

		[SerializeField]
		private LightingManagerLocator _lightingManagerLocator;

		[SerializeField]
		private DirectionalLightManagerLocator _directionalLightManagerLocator;

		private readonly byte[] _gammaLookUpTable = new byte[256];

		private readonly List<Task> _ongoingSavingTasks = new List<Task>();

		private void OnEnable()
		{
			BuildGammaLookUpTable();
		}

		private void OnDisable()
		{
			EnsureTasksAreCompleted();
		}

		private void OnDestroy()
		{
			EnsureTasksAreCompleted();
		}

		public void SaveFactory(string savePath, string autoSaveSourceSaveName = null, int iteration = 0)
		{
			string directoryPath = savePath.Split(".json")[0];
			if (!SaveInfoToLoadSO.IsSaveablePath(directoryPath))
			{
				this.DevException("Saving to this path is not allowed: \"" + directoryPath + "\"", "SaveFactory", 66);
				_finishedSavingEvent.Fire();
				return;
			}
			EnsureTasksAreCompleted();
			FactoryMapSaveData mapData;
			FactoryShapesSaveData shapesData;
			FactoryFloorSaveData saveData;
			try
			{
				SaveSystem.CreateFullPath(directoryPath);
				mapData = GetCurrentMapSaveData();
				shapesData = GetCurrentShapesSaveData();
				saveData = GetCurrentSaveData();
				Task<bool> item = Task.Run((Func<Task<bool>>)ExecuteTrySaveMapDataAsync);
				_ongoingSavingTasks.Add(item);
				item = Task.Run((Func<Task<bool>>)ExecuteTrySaveShapesDataAsync);
				_ongoingSavingTasks.Add(item);
				item = Task.Run((Func<Task<bool>>)ExecuteTrySaveFactoryDataAsync);
				_ongoingSavingTasks.Add(item);
				_saveInfoPersistentSO.SetAutoSaveSourceSaveName(autoSaveSourceSaveName);
				Task item2 = _persistentSOLibrary.SaveAllPersistentSOsAsync(directoryPath + "/PersistentSOs");
				_ongoingSavingTasks.Add(item2);
				CreateThumbnail(directoryPath);
				if (!EnsureTasksAreCompleted())
				{
					this.Log("Failed! Saved to directory " + directoryPath + "!", "SaveFactory", 101);
					if (iteration >= 1)
					{
						_finishedSavingEvent.Fire();
					}
					else
					{
						SaveFactory(savePath, autoSaveSourceSaveName, iteration + 1);
					}
				}
				else
				{
					this.Log("Success! Saved to directory " + directoryPath + "!", "SaveFactory", 113);
					CreateBackup(directoryPath);
					_finishedSavingEvent.Fire();
				}
			}
			catch (Exception ex)
			{
				this.LogAssertion(ex.ToString(), "SaveFactory", 121);
				_finishedSavingEvent.Fire();
			}
			Task<bool> ExecuteTrySaveFactoryDataAsync()
			{
				return SaveSystem.TrySaveDataAsync(saveData, directoryPath, "level.json", new ShapeDtoToIndexConverter(shapesData));
			}
			Task<bool> ExecuteTrySaveMapDataAsync()
			{
				return SaveSystem.TrySaveDataAsync(mapData, directoryPath, "map.json");
			}
			Task<bool> ExecuteTrySaveShapesDataAsync()
			{
				return SaveSystem.TrySaveDataAsync(shapesData, directoryPath, "shapes.json");
			}
		}

		private void CreateBackup(string directoryPath)
		{
			EnsureTasksAreCompleted();
			string text = SaveSystem.ConvertToGameSaveBackupDirectory(directoryPath);
			this.Log("Backups: Copying " + directoryPath + " to " + text + "!", "CreateBackup", 132);
			if (Directory.Exists(text))
			{
				Directory.Delete(text, recursive: true);
			}
			FileUtils.CopyDirectoryTo(directoryPath, text, recursive: true);
		}

		private void CreateThumbnail(string directoryPath)
		{
			LightingConfig customLightConfig = _lightingManagerLocator.Value.CustomLightConfig;
			bool isEnabled = _directionalLightManagerLocator.Value.IsEnabled;
			_resetToDefaultLightingConfigEvent.Fire();
			_setDirectionalLightEventSO.Fire(data: true);
			float renderScale = (GraphicsSettings.currentRenderPipeline as UniversalRenderPipelineAsset).renderScale;
			int num = _saveThumbnailRenderTex.width;
			int num2 = _saveThumbnailRenderTex.height;
			if (renderScale > 1f)
			{
				num = (int)((float)num / renderScale);
				num2 = (int)((float)num2 / renderScale);
			}
			RenderTexture targetTexture = _cameraLocator.Camera.targetTexture;
			_cameraLocator.Camera.targetTexture = _saveThumbnailRenderTex;
			_cameraLocator.Camera.Render();
			_cameraLocator.Camera.targetTexture = targetTexture;
			Texture2D texture2D = new Texture2D(num, num2, _textureFormat, TextureCreationFlags.None)
			{
				name = "Thumbnail"
			};
			RenderTexture.active = _saveThumbnailRenderTex;
			texture2D.ReadPixels(new Rect(0f, 0f, num, num2), 0, 0);
			GammaCorrectTexture(texture2D);
			texture2D.Apply();
			byte[] thumbnailPNG = texture2D.EncodeToPNG();
			Task item = Task.Run((Func<Task>)ExecuteCreateThumbnail);
			_ongoingSavingTasks.Add(item);
			if (customLightConfig != null)
			{
				_setLightingConfigEvent.Fire(customLightConfig);
			}
			_setDirectionalLightEventSO.Fire(isEnabled);
			Task ExecuteCreateThumbnail()
			{
				return CreateThumbnailAsync(directoryPath, thumbnailPNG);
			}
		}

		private async Task CreateThumbnailAsync(string directoryPath, byte[] thumbnailPNG)
		{
			try
			{
				await File.WriteAllBytesAsync(Path.Combine(directoryPath, "Thumbnail.png"), thumbnailPNG);
			}
			catch (Exception ex)
			{
				this.LogAssertion(ex.ToString(), "CreateThumbnailAsync", 198);
			}
		}

		private void BuildGammaLookUpTable()
		{
			for (int i = 0; i < 256; i++)
			{
				int value = Mathf.RoundToInt(Mathf.Pow((float)i / 255f, 0.45454544f) * 255f);
				_gammaLookUpTable[i] = (byte)Mathf.Clamp(value, 0, 255);
			}
		}

		private void GammaCorrectTexture(Texture2D texture2D)
		{
			Color32[] pixels = texture2D.GetPixels32();
			for (int i = 0; i < pixels.Length; i++)
			{
				Color32 color = pixels[i];
				color.r = _gammaLookUpTable[color.r];
				color.g = _gammaLookUpTable[color.g];
				color.b = _gammaLookUpTable[color.b];
				color.a = byte.MaxValue;
				pixels[i] = color;
			}
			texture2D.SetPixels32(pixels);
		}

		private bool EnsureTasksAreCompleted()
		{
			if (_ongoingSavingTasks.IsNullOrEmpty())
			{
				return true;
			}
			Task.WaitAll(_ongoingSavingTasks.ToArray());
			for (int i = 0; i < _ongoingSavingTasks.Count; i++)
			{
				if (_ongoingSavingTasks[i] is Task<bool> { Result: false })
				{
					_ongoingSavingTasks.Clear();
					return false;
				}
			}
			_ongoingSavingTasks.Clear();
			return true;
		}

		private FactoryMapSaveData GetCurrentMapSaveData()
		{
			List<FactoryIslandSaveData> list = new List<FactoryIslandSaveData>();
			foreach (IslandData allIslandData in _islandsDatabase.GetAllIslandDatas())
			{
				list.Add(new FactoryIslandSaveData(allIslandData));
			}
			List<IslandInMapSaveData> allIslandsInMap = _islandLayer.GetAllIslandsInMap();
			return new FactoryMapSaveData(list, allIslandsInMap, _islandLayer.CalculateBounds());
		}

		private FactoryFloorSaveData GetCurrentSaveData()
		{
			List<SavedObjectDto> allSavedObjectDtos = GetAllSavedObjectDtos(_factoryLayer);
			return new FactoryFloorSaveData(new FactoryLayerSaveData(GetAllSavedObjectDtos(_terrainLayer)), new FactoryLayerSaveData(allSavedObjectDtos));
		}

		private FactoryShapesSaveData GetCurrentShapesSaveData()
		{
			return new FactoryShapesSaveData(_shapesDatabase.GetShapeDtos());
		}

		private List<SavedObjectDto> GetAllSavedObjectDtos(FactoryLayer layer)
		{
			List<SavedObjectDto> list = new List<SavedObjectDto>();
			foreach (FactoryObject allDistinctObjectList in layer.GetAllDistinctObjectLists())
			{
				list.Add(new SavedObjectDto(allDistinctObjectList.Position, allDistinctObjectList.Rotation, allDistinctObjectList.Mirrored, allDistinctObjectList.NonChangable, allDistinctObjectList.ObjectId, allDistinctObjectList.GetSoftLinkedObjectsPos(), allDistinctObjectList.GetHardLinkedObjectsPos(), allDistinctObjectList.GetConfigurations(), allDistinctObjectList.GetSaveStates(), allDistinctObjectList.ApartOfMap));
			}
			return list;
		}
	}
}
