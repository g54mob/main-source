#define ENABLE_DEBUG_LOGS
#define ENABLE_DEBUG_ERRORS
using System.Collections.Generic;
using System.IO;
using Data.FactoryFloor.Islands;
using Data.FactoryFloor.Maps;
using Data.Variables;
using Events;
using Events.FactoryFloor.Islands;
using Presentation.FactoryFloor.Islands;
using Presentation.Locators;
using SFB;
using SaveData.FactoryFloor.Map;
using UnityEngine;
using UnityEngine.InputSystem;
using Utils;

namespace Logic.Factory.Map
{
	[CreateAssetMenu(menuName = "Factory/Tools/Map/MapLoader", fileName = "MapLoader", order = 0)]
	public class MapLoader : ScriptableObject
	{
		[SerializeField]
		private IslandDatabase _islandsDatabase;

		[SerializeField]
		private IslandLayer _islandLayer;

		[SerializeField]
		private InputActionAsset _input;

		[SerializeField]
		private StreamingAssetsPathVariableSO _currentMapWorkingStreamingAssetsPath;

		[SerializeField]
		private GridLocator _gridMapLocator;

		[SerializeField]
		private BaseEvent _clearMapEvent;

		[SerializeField]
		private IslandObjectEvent _createIslandObjectEvent;

		[SerializeField]
		private MaxZoomLevelModifierSO _maxZoomLevelModifier;

		private Vector2Int _gridCellSize;

		public void LoadMap()
		{
			_gridCellSize = new Vector2Int((int)_gridMapLocator.GetCellSize().x, (int)_gridMapLocator.GetCellSize().z);
			_input.Disable();
			string[] array = StandaloneFileBrowser.OpenFilePanel("Load Map", _currentMapWorkingStreamingAssetsPath.Value, "json", multiselect: false);
			_input.Enable();
			if (array == null || array.Length == 0)
			{
				return;
			}
			string text = array[0];
			_currentMapWorkingStreamingAssetsPath.SetValue(Path.GetDirectoryName(text));
			if (!SaveSystem.TryLoadData<MapSaveData>(text, out var data))
			{
				return;
			}
			_clearMapEvent.Fire();
			_islandLayer.Clear();
			foreach (string path in data.Paths)
			{
				_islandsDatabase.TryLoadIsland(Path.Combine(Application.streamingAssetsPath, path));
			}
			foreach (IslandInMapSaveData island in data.Islands)
			{
				LoadIsland(island);
			}
		}

		private void LoadIsland(IslandInMapSaveData island)
		{
			IslandData islandDataById = _islandsDatabase.GetIslandDataById(island.Id);
			if (islandDataById == null)
			{
				this.LogError(string.Format("Failed to find island \"{0}\" in {1}", island.Id, "_islandsDatabase"), "LoadIsland", 66);
				return;
			}
			Vector2Int sizeUnit = islandDataById.Size + new Vector2Int(16, 16);
			Vector2Int vector2Int = new Vector2Int(sizeUnit.x / _gridCellSize.x, sizeUnit.y / _gridCellSize.y);
			List<Vector3Int> occupiedGridPositions = GetOccupiedGridPositions(island.Position, vector2Int);
			if (_islandLayer.CanPlaceIsland(occupiedGridPositions))
			{
				IslandConfig islandConfig = new IslandConfig(islandDataById, IntIdGenerator.GetNewId, GetWorldPosition(occupiedGridPositions[0], vector2Int), islandDataById.Size, sizeUnit, island.Rotation, new IslandConfig.IslandBottomPrefabConfig(island.IslandBottomIndex, island.IslandBottomRotation), island.IsGNNGateIsland);
				IslandObject islandObject = new IslandObject(islandConfig, occupiedGridPositions, _maxZoomLevelModifier);
				_islandLayer.AddIsland(islandObject);
				_createIslandObjectEvent.Fire(islandObject);
				this.Log($"Island \"{island.Id}\" in position: {island.Position} position 0: {occupiedGridPositions[0]} world position: {islandConfig.Position}", "LoadIsland", 85);
			}
		}

		private Vector3 GetWorldPosition(Vector3Int position, Vector2Int sizeScaled)
		{
			if (sizeScaled.x % 2 == 0)
			{
				return _gridMapLocator.GetWorldPosition(position) - _gridMapLocator.GetCellSize() / 2f;
			}
			return _gridMapLocator.GetWorldPosition(position);
		}

		private List<Vector3Int> GetOccupiedGridPositions(Vector3Int position, Vector2Int size)
		{
			List<Vector3Int> list = new List<Vector3Int>();
			int num = -(size.x / 2);
			int num2 = -(size.y / 2);
			list.Add(position);
			for (int i = 0; i < size.x; i++)
			{
				for (int j = 0; j < size.y; j++)
				{
					Vector3Int vector3Int = new Vector3Int(position.x + num + i, position.y, position.z + num2 + j);
					if (!(vector3Int == position))
					{
						list.Add(vector3Int);
					}
				}
			}
			return list;
		}
	}
}
