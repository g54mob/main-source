#define ENABLE_DEBUG_WARNINGS
#define ENABLE_DEBUG_ERRORS
using System.Collections.Generic;
using Data.FactoryFloor;
using Data.FactoryFloor.Buildings;
using Data.FactoryFloor.Maps;
using Data.SaveData.PersistentSOs;
using Data.Variables;
using Events.FactoryFloor;
using Events.Generic;
using Logic.Factory.Blueprint;
using Presentation.Locators;
using UnityEngine;
using Utils;

namespace Commands.ToolsCommands
{
	public class DeleteBlueprintCommand : ICommandUndo, ICommand
	{
		private readonly FactoryLayer _factoryLayer;

		private readonly FactoryLayer _terrainLayer;

		private readonly Blueprint _blueprint;

		private readonly IntListEvent _factoryObjectsRemoveViewsEvent;

		private readonly CreateFactoryObjectEvent _createFactoryObjectEvent;

		private readonly GridLocator _gridLocator;

		private readonly bool _deleteCranes;

		private readonly CranesLibrarySO _cranesLibrary;

		private readonly AudioManagerLocator _audioManagerLocator;

		private readonly IslandLayer _islandLayer;

		private readonly UnlockedIslandsPersistentSO _unlockedIslandsPersistentSO;

		private readonly List<FactoryObject> _deletedObjects = new List<FactoryObject>();

		private readonly List<(BuildingCranesBehaviour behaviour, BuildingCranesBehaviour.Crane crane)> _deletedCranes = new List<(BuildingCranesBehaviour, BuildingCranesBehaviour.Crane)>();

		private readonly List<int> _deletedIds = new List<int>();

		private int _objectSize;

		public DeleteBlueprintCommand(FactoryLayer factoryLayer, FactoryLayer terrainLayer, Blueprint blueprint, IntListEvent factoryObjectsRemoveViewsEvent, CreateFactoryObjectEvent createFactoryObjectEvent, GridLocator gridLocator, bool deleteCranes, CranesLibrarySO cranesLibrary, AudioManagerLocator audioManagerLocator, IslandLayer islandLayer, UnlockedIslandsPersistentSO unlockedIslandsPersistentSO)
		{
			_factoryLayer = factoryLayer;
			_terrainLayer = terrainLayer;
			_blueprint = blueprint;
			_factoryObjectsRemoveViewsEvent = factoryObjectsRemoveViewsEvent;
			_createFactoryObjectEvent = createFactoryObjectEvent;
			_gridLocator = gridLocator;
			_deleteCranes = deleteCranes;
			_cranesLibrary = cranesLibrary;
			_audioManagerLocator = audioManagerLocator;
			_islandLayer = islandLayer;
			_unlockedIslandsPersistentSO = unlockedIslandsPersistentSO;
			foreach (BlueprintElement element in blueprint.Elements)
			{
				_objectSize = Mathf.Max(_objectSize, element.ObjectData.ObjectSize);
			}
		}

		public bool TryDo()
		{
			_deletedObjects.Clear();
			_deletedIds.Clear();
			foreach (BlueprintElement element in _blueprint.Elements)
			{
				Vector3Int vector3Int = element.RelativePositions[0] + _blueprint.Position;
				IslandObject islandObject;
				if (!_factoryLayer.TryGetObjectAt(vector3Int, out var factoryObject))
				{
					Vector3Int vector3Int2 = vector3Int;
					this.LogError("Can't delete object at position: " + vector3Int2.ToString(), "TryDo", 77);
				}
				else if (_islandLayer.TryGetIslandAtWorldPosition(vector3Int, out islandObject) && !_unlockedIslandsPersistentSO.IsIslandUnlocked(islandObject))
				{
					Vector3Int vector3Int2 = vector3Int;
					this.LogWarning("Can't delete object on locked island: " + vector3Int2.ToString() + " island: " + islandObject.IslandConfig.IslandData.Name, "TryDo", 85);
				}
				else
				{
					_deletedObjects.Add(factoryObject);
					_factoryLayer.RemoveObjectAt(factoryObject.Position, invokeObjectsChangedEvent: false);
					_deletedIds.Add(element.CreatedId);
				}
			}
			if (_deleteCranes)
			{
				foreach (Vector3Int cranePosition in _blueprint.CranePositions)
				{
					if (!_cranesLibrary.TryGetCrane(cranePosition, out (BuildingCranesBehaviour, BuildingCranesBehaviour.Crane) crane))
					{
						Vector3Int vector3Int2 = cranePosition;
						this.LogError("Couldn't find crane at position: " + vector3Int2.ToString(), "TryDo", 101);
					}
					else if (!crane.Item1.RemoveCrane(crane.Item2.Position))
					{
						this.LogError("Can't delete crane at position: " + crane.Item2.Position.ToString(), "TryDo", 106);
					}
					else
					{
						_deletedCranes.Add(crane);
					}
				}
			}
			_factoryLayer.ObjectsInLayerChanged();
			_factoryObjectsRemoveViewsEvent.Fire(_deletedIds);
			_audioManagerLocator.AudioManager.PlayDeleteObject(_blueprint.Position, _objectSize);
			return true;
		}

		public bool TryReDo()
		{
			foreach (FactoryObject deletedObject in _deletedObjects)
			{
				_factoryLayer.RemoveObjectAt(deletedObject.Position, invokeObjectsChangedEvent: false);
			}
			foreach (var (buildingCranesBehaviour, crane) in _deletedCranes)
			{
				buildingCranesBehaviour.RemoveCrane(crane.Position);
			}
			_factoryLayer.ObjectsInLayerChanged();
			_factoryObjectsRemoveViewsEvent.Fire(_deletedIds);
			_audioManagerLocator.AudioManager.PlayPlaceObjectGeneric(_blueprint.Position, _blueprint, _objectSize);
			return true;
		}

		public bool TryUnDo()
		{
			if (!BlueprintPlacementValidator.CanBePlaced(_blueprint.Position, _blueprint, _factoryLayer, _terrainLayer))
			{
				return false;
			}
			foreach (FactoryObject deletedObject in _deletedObjects)
			{
				if (!_factoryLayer.CanPlaceObjectAt(deletedObject.OccupiedPositions))
				{
					this.LogError("Place object at it's OccupiedPositions: " + deletedObject, "TryUnDo", 146);
				}
				else if (_factoryLayer.TryAddFactoryObject(deletedObject, invokeObjectsChangedEvent: false))
				{
					_createFactoryObjectEvent.Fire(new CreateFactoryObjectDto(_gridLocator.GetWorldPosition(deletedObject.Position), deletedObject.Rotation, deletedObject.Mirrored, deletedObject));
				}
			}
			foreach (var (buildingCranesBehaviour, crane) in _deletedCranes)
			{
				buildingCranesBehaviour.AddCrane(crane.Position, crane.PickupPosition);
			}
			_factoryLayer.ObjectsInLayerChanged();
			return true;
		}
	}
}
