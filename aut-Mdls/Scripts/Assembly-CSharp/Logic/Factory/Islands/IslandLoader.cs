using System.Collections.Generic;
using System.IO;
using Data.FactoryFloor;
using Data.FactoryFloor.Islands;
using Data.FactoryFloor.Maps;
using Data.Operator;
using Data.Variables;
using Events;
using Events.FactoryFloor;
using Presentation.Locators;
using SFB;
using SaveData.FactoryFloor;
using SaveData.FactoryFloor.Island;
using UnityEngine;
using UnityEngine.InputSystem;
using Utils;
using Utils.JsonConverterUtils;

namespace Logic.Factory.Islands
{
	[CreateAssetMenu(menuName = "Factory/Tools/Islands/IslandLoader", fileName = "IslandLoader", order = 0)]
	public class IslandLoader : ScriptableObject
	{
		[SerializeField]
		private InputActionAsset _input;

		[SerializeField]
		private BrushPositions _brushPositions;

		[SerializeField]
		private CurrentEditingIsland _currentEditingIsland;

		[SerializeField]
		private StreamingAssetsPathVariableSO _currentIslandWorkingPath;

		[SerializeField]
		private IslandCreator _islandCreator;

		[SerializeField]
		private GridLocator _gridLocator;

		[SerializeField]
		private FactoryObjectDatabase _factoryObjectDatabase;

		[SerializeField]
		private FactoryLayer _terrainLayer;

		[SerializeField]
		private FactoryLayer _factoryLayer;

		[SerializeField]
		private IslandLayer _islandLayer;

		[SerializeField]
		protected CreateFactoryObjectEvent _createFactoryObjectEvent;

		[SerializeField]
		private BaseEvent _generateGrass;

		[SerializeField]
		private DecorationsObjectDatabase _decorationsObjectDatabase;

		public void LoadIsland()
		{
			_input.Disable();
			string directoryName = Path.GetDirectoryName(_currentIslandWorkingPath.Value);
			string[] array = StandaloneFileBrowser.OpenFilePanel("Load Island", directoryName, "json", multiselect: false);
			_input.Enable();
			if (!array.IsNullOrEmpty())
			{
				string text = array[0];
				_currentIslandWorkingPath.SetValue(text);
				if (SaveSystem.TryLoadData<IslandSaveData>(text, out var data))
				{
					_islandCreator.CreateIslandWithId(Path.GetFileNameWithoutExtension(text), data.Guid, data.Size);
					_currentEditingIsland.SetTexturePixels(data.FloorTextureColors);
					_brushPositions.SetBrushesAtPosition(GetBrushPositions(data.BrushPositions));
					List<IslandObject> allIslands = _islandLayer.GetAllIslands();
					IslandObject islandObject = allIslands[allIslands.Count - 1];
					SafetyMoveDectorationsToFactoryLayer(data);
					LoadLayer(data.TerrainSavedObjectDtos, _terrainLayer, islandObject.Position);
					LoadLayer(data.FactorySavedObjectDtos, _factoryLayer, islandObject.Position);
					_generateGrass.Fire();
				}
			}
		}

		private void SafetyMoveDectorationsToFactoryLayer(IslandSaveData islandSaveData)
		{
			for (int num = islandSaveData.TerrainSavedObjectDtos.Count - 1; num >= 0; num--)
			{
				SavedObjectDto savedObjectDto = islandSaveData.TerrainSavedObjectDtos[num];
				if (_decorationsObjectDatabase.DecorationDatas.FindIndex((FactoryObjectData i) => i.ID == savedObjectDto.FactoryObjectDataId) != -1)
				{
					islandSaveData.TerrainSavedObjectDtos.RemoveAt(num);
					islandSaveData.FactorySavedObjectDtos.Add(savedObjectDto);
				}
			}
		}

		private void CreateFactoryObject(SavedObjectDto savedObjectDto, FactoryLayer layer)
		{
			FactoryObjectData objectDataWithId = _factoryObjectDatabase.GetObjectDataWithId(savedObjectDto.FactoryObjectDataId);
			FactoryObject factoryObject = savedObjectDto.ToFactoryObject(layer, objectDataWithId, IntIdGenerator.GetNewId);
			if (layer.TryAddFactoryObject(factoryObject))
			{
				_createFactoryObjectEvent.Fire(new CreateFactoryObjectDto(_gridLocator.GetWorldPosition(factoryObject.Position), factoryObject.Rotation, factoryObject.Mirrored, factoryObject));
			}
		}

		private void LoadLayer(List<SavedObjectDto> dataSavedEnvironmentObjectDtos, FactoryLayer layer, Vector3Int islandPosition)
		{
			foreach (SavedObjectDto dataSavedEnvironmentObjectDto in dataSavedEnvironmentObjectDtos)
			{
				dataSavedEnvironmentObjectDto.PositionX += islandPosition.x;
				dataSavedEnvironmentObjectDto.PositionZ += islandPosition.z;
				CreateFactoryObject(dataSavedEnvironmentObjectDto, layer);
			}
		}

		private Dictionary<Vector3Int, int> GetBrushPositions(Vector3IntSerlializableDictionary dataBrushPositions)
		{
			Dictionary<Vector3Int, int> dictionary = new Dictionary<Vector3Int, int>();
			foreach (KeyValuePair<string, int> item in dataBrushPositions.dictionary)
			{
				string[] array = item.Key.Trim('(', ')').Split(',');
				Vector3Int key = new Vector3Int(int.Parse(array[0]), int.Parse(array[1]), int.Parse(array[2]));
				dictionary[key] = item.Value;
			}
			return dictionary;
		}
	}
}
