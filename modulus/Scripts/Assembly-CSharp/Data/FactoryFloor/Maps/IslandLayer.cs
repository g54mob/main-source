#define ENABLE_DEBUG_ERRORS
using System.Collections.Generic;
using Data.Operator;
using Presentation.Locators;
using SaveData.FactoryFloor.Map;
using UnityEngine;
using Utils;

namespace Data.FactoryFloor.Maps
{
	[CreateAssetMenu(menuName = "Factory/MapEditor/IslandsMap", fileName = "IslandsMap", order = 0)]
	public class IslandLayer : ScriptableObject
	{
		[SerializeField]
		private GridLocator _gridMapLocator;

		private readonly Dictionary<Vector3Int, IslandObject> _dictionary = new Dictionary<Vector3Int, IslandObject>();

		private readonly List<IslandObject> _islands = new List<IslandObject>();

		public bool IsEmpty => _dictionary.Count == 0;

		public void AddIsland(IslandObject islandObjectInMap)
		{
			foreach (Vector3Int position in islandObjectInMap.Positions)
			{
				_dictionary.Add(new Vector3Int(position.x, 0, position.z), islandObjectInMap);
			}
			_islands.Add(islandObjectInMap);
		}

		public bool CanPlaceIsland(List<Vector3Int> gridPositions)
		{
			foreach (Vector3Int gridPosition in gridPositions)
			{
				if (_dictionary.ContainsKey(new Vector3Int(gridPosition.x, 0, gridPosition.z)))
				{
					return false;
				}
			}
			return true;
		}

		public bool CanPlaceIsland(Vector3Int gridPosition)
		{
			gridPosition.y = 0;
			return !_dictionary.ContainsKey(gridPosition);
		}

		public bool TryGetIslandAtWorldPosition(Vector3Int position, out IslandObject islandObject)
		{
			Vector3Int cellPosition = _gridMapLocator.GetCellPosition(position);
			cellPosition.y = 0;
			return TryGetIslandAtGridPosition(cellPosition, out islandObject);
		}

		public bool TryGetIslandAtGridPosition(Vector3Int gridPosition, out IslandObject islandObject)
		{
			gridPosition.y = 0;
			return _dictionary.TryGetValue(gridPosition, out islandObject);
		}

		public IslandObject GetIslandAtGridPosition(Vector3Int gridPosition)
		{
			gridPosition.y = 0;
			return _dictionary.GetValueOrDefault(gridPosition);
		}

		public void RemoveIslandAtGridPosition(Vector3Int gridPosition)
		{
			gridPosition.y = 0;
			if (CanPlaceIsland(gridPosition))
			{
				return;
			}
			IslandObject islandObject = _dictionary[gridPosition];
			foreach (Vector3Int position in islandObject.Positions)
			{
				_dictionary.Remove(new Vector3Int(position.x, 0, position.z));
			}
			_islands.Remove(islandObject);
		}

		public List<IslandObject> GetAllIslands()
		{
			return _islands;
		}

		public List<IslandInMapSaveData> GetAllIslandsInMap()
		{
			List<IslandInMapSaveData> list = new List<IslandInMapSaveData>();
			foreach (IslandObject allIsland in GetAllIslands())
			{
				list.Add(new IslandInMapSaveData(_gridMapLocator.GetCellPosition(allIsland.Position), allIsland.Rotation, allIsland.IslandConfig.IslandBottom.SelectedIndex, allIsland.IslandConfig.IslandBottom.Rotation, allIsland.IslandConfig.IsGNNGateIsland, allIsland.Guid));
			}
			return list;
		}

		public void Clear()
		{
			_dictionary.Clear();
			_islands.Clear();
		}

		public bool TryAddFactoryObject(FactoryLayer factoryLayer, FactoryObject factoryObject)
		{
			if (!TryGetIslandAtWorldPosition(factoryObject.Position, out var islandObject))
			{
				this.LogError($"Trying to add FactoryObject at position: {factoryObject.Position} but no island exist at grid position: {_gridMapLocator.GetCellPosition(factoryObject.Position)} Obj: {factoryObject}", "TryAddFactoryObject", 112);
				return false;
			}
			if (!islandObject.CanPlaceObjectAt(factoryLayer, factoryObject.OccupiedPositions))
			{
				this.LogError($"Couldn't add object: {factoryObject} to island: {islandObject}", "TryAddFactoryObject", 118);
				return false;
			}
			islandObject.AddFactoryObject(factoryLayer, factoryObject);
			return true;
		}

		public void RemoveFactoryObjectAt(FactoryLayer factoryLayer, Vector3Int position)
		{
			if (!TryGetIslandAtWorldPosition(position, out var islandObject))
			{
				this.LogError($"Trying to remove FactoryObject at position: {position} but no island exist this position", "RemoveFactoryObjectAt", 130);
			}
			else
			{
				islandObject.RemoveFactoryObjectAt(factoryLayer, position);
			}
		}

		public void RemoveFactoryObject(FactoryLayer factoryLayer, FactoryObject factoryObject)
		{
			if (!TryGetIslandAtWorldPosition(factoryObject.Position, out var islandObject))
			{
				this.LogError($"Trying to remove FactoryObject at position: {factoryObject.Position} but no island exist this position", "RemoveFactoryObject", 141);
			}
			else
			{
				islandObject.RemoveFactoryObject(factoryLayer, factoryObject);
			}
		}

		public FactoryObject GetObjectAt(FactoryLayer factoryLayer, Vector3Int position)
		{
			if (TryGetIslandAtWorldPosition(position, out var islandObject))
			{
				return islandObject.GetObjectAt(factoryLayer, position);
			}
			return null;
		}

		public bool TryGetObjectAt(FactoryLayer factoryLayer, Vector3Int position, out FactoryObject factoryObject)
		{
			if (TryGetIslandAtWorldPosition(position, out var islandObject))
			{
				return islandObject.TryGetObjectAt(factoryLayer, position, out factoryObject);
			}
			factoryObject = null;
			return false;
		}

		public bool CanPlaceObjectAt(FactoryLayer factoryLayer, List<Vector3Int> positions)
		{
			IslandObject islandObject = null;
			bool flag = false;
			foreach (Vector3Int position in positions)
			{
				if (TryGetIslandAtWorldPosition(position, out islandObject))
				{
					flag = true;
					break;
				}
			}
			if (!flag)
			{
				return false;
			}
			return islandObject.CanPlaceObjectAt(factoryLayer, positions);
		}

		public bool CanPlaceObjectAt(FactoryLayer factoryLayer, Vector3Int position)
		{
			if (!TryGetIslandAtWorldPosition(position, out var islandObject))
			{
				return false;
			}
			return islandObject.CanPlaceObjectAt(factoryLayer, position);
		}

		public void ClearObjects(FactoryLayer factoryLayer)
		{
			foreach (IslandObject island in _islands)
			{
				island.Clear(factoryLayer);
			}
		}

		public IEnumerable<FactoryObject> GetAllDistinctObjects(FactoryLayer factoryLayer)
		{
			foreach (IslandObject island in _islands)
			{
				foreach (FactoryObject item in island.GetAllDistinctObjectsEnumerable(factoryLayer))
				{
					yield return item;
				}
			}
		}

		public List<FactoryObject> GetObjectsFromData(FactoryLayer factoryLayer, FactoryObjectData factoryObjectData)
		{
			List<FactoryObject> list = new List<FactoryObject>();
			foreach (IslandObject island in _islands)
			{
				list.AddRange(island.GetObjectsFromData(factoryLayer, factoryObjectData));
			}
			return list;
		}

		public bool TryGetObjectsFromData(FactoryLayer factoryLayer, FactoryObjectData factoryObjectData, out List<FactoryObject> factoryObjects)
		{
			factoryObjects = new List<FactoryObject>();
			bool result = false;
			foreach (IslandObject island in _islands)
			{
				if (island.TryGetObjectsFromData(factoryLayer, factoryObjectData, out var factoryObjects2))
				{
					factoryObjects.AddRange(factoryObjects2);
					result = true;
				}
			}
			return result;
		}

		public Bounds CalculateBounds()
		{
			Vector3 min = default(Vector3);
			Vector3 max = default(Vector3);
			foreach (IslandObject island in _islands)
			{
				int num = island.Position.x + island.Size.x;
				int num2 = island.Position.x - island.Size.x;
				int num3 = island.Position.z + island.Size.y;
				int num4 = island.Position.z - island.Size.y;
				max.x = Mathf.Max(max.x, num);
				min.x = Mathf.Min(min.x, num2);
				max.z = Mathf.Max(max.z, num3);
				min.z = Mathf.Min(min.z, num4);
			}
			Bounds result = default(Bounds);
			result.SetMinMax(min, max);
			return result;
		}
	}
}
