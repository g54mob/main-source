#define ENABLE_DEBUG_ERRORS
using System.Collections.Generic;
using System.Linq;
using Data.FactoryFloor;
using Events.FactoryFloor;
using Events.Generic;
using Logic.Factory.Blueprint;
using Presentation.Locators;
using UnityEngine;
using Utils;

namespace Commands.ToolsCommands
{
	public class MoveBlueprintCommand : ICommandUndo, ICommand
	{
		private readonly FactoryLayer _factoryLayer;

		private readonly FactoryLayer _terrainLayer;

		private readonly Vector3Int _position;

		private readonly int _rotation;

		private readonly Blueprint _blueprint;

		private readonly CreateFactoryObjectEvent _createFactoryObjectEvent;

		private readonly GridLocator _gridLocator;

		private readonly IntListEvent _factoryObjectsRemoveViewsEvent;

		private readonly AudioManagerLocator _audioManagerLocator;

		private readonly List<FactoryObject> _factoryObjects = new List<FactoryObject>();

		private readonly List<FactoryObject> _deletedObjects = new List<FactoryObject>();

		private readonly List<(FactoryObject factoryObject, List<Vector3Int> occupiedPosition, int rotation, bool mirrored)> _originalState = new List<(FactoryObject, List<Vector3Int>, int, bool)>();

		private int _objectSize;

		public MoveBlueprintCommand(FactoryLayer factoryLayer, FactoryLayer terrainLayer, Vector3Int position, int rotation, List<FactoryObject> factoryObjects, Blueprint blueprint, CreateFactoryObjectEvent createFactoryObjectEvent, GridLocator gridLocator, IntListEvent factoryObjectsRemoveViewsEvent, AudioManagerLocator audioManagerLocator)
		{
			_factoryLayer = factoryLayer;
			_terrainLayer = terrainLayer;
			_position = position;
			_rotation = rotation;
			_factoryObjects = new List<FactoryObject>(factoryObjects);
			_blueprint = blueprint;
			_createFactoryObjectEvent = createFactoryObjectEvent;
			_gridLocator = gridLocator;
			_factoryObjectsRemoveViewsEvent = factoryObjectsRemoveViewsEvent;
			_audioManagerLocator = audioManagerLocator;
		}

		public bool TryDo()
		{
			RemoveFactoryObjects();
			if (!BlueprintPlacementValidator.CanBePlaced(_position, _blueprint, _factoryLayer, _terrainLayer, isBeingMoved: true))
			{
				this.LogError("Cannot place blueprint at: " + _position.ToString(), "TryDo", 59);
				UndoRemoveFactoryObjects();
				return false;
			}
			_objectSize = 0;
			_originalState.Clear();
			_deletedObjects.Clear();
			foreach (BlueprintElement element in _blueprint.Elements)
			{
				FactoryObject factoryObject = _factoryObjects.FirstOrDefault((FactoryObject x) => x.CreatedId == element.CreatedId);
				_originalState.Add((factoryObject, new List<Vector3Int>(factoryObject.OccupiedPositions), factoryObject.Rotation, factoryObject.Mirrored));
				factoryObject.Move(FactoryObject.GetOccupiedPositions(_position, element.RelativePositions), _rotation + element.Rotation, element.Mirrored);
				factoryObject.SetConfigurations(element.Configurations.ToArray());
				factoryObject.SetSaveStates(element.SaveStates.ToArray());
				if (!_factoryLayer.CanPlaceObjectAt(factoryObject.OccupiedPositions))
				{
					foreach (Vector3Int occupiedPosition in factoryObject.OccupiedPositions)
					{
						FactoryObject objectAt = _factoryLayer.GetObjectAt(occupiedPosition);
						if (objectAt != null)
						{
							_deletedObjects.Add(objectAt);
							_factoryLayer.RemoveObjectAt(occupiedPosition, invokeObjectsChangedEvent: false);
						}
					}
				}
				AddObject(factoryObject);
				_objectSize = Mathf.Max(_objectSize, factoryObject.FactoryObjectData.ObjectSize);
			}
			_factoryLayer.ObjectsInLayerChanged();
			_audioManagerLocator.AudioManager.PlayPlaceObject(_position, _objectSize);
			if (_deletedObjects.Count > 0)
			{
				_factoryObjectsRemoveViewsEvent.Fire(_deletedObjects.Select((FactoryObject x) => x.CreatedId).ToList());
			}
			return true;
		}

		public bool TryReDo()
		{
			return TryDo();
		}

		public bool TryUnDo()
		{
			RemoveFactoryObjects();
			foreach (var (factoryObject, newPositions, newRotation, isMirrored) in _originalState)
			{
				factoryObject.Move(newPositions, newRotation, isMirrored);
				if (!_factoryLayer.CanPlaceObjectAt(factoryObject.OccupiedPositions))
				{
					this.LogError("Failed to place factory object: " + factoryObject, "TryUnDo", 114);
				}
				else
				{
					AddObject(factoryObject);
				}
			}
			foreach (FactoryObject deletedObject in _deletedObjects)
			{
				AddObject(deletedObject);
			}
			_factoryLayer.ObjectsInLayerChanged();
			_audioManagerLocator.AudioManager.PlayMoveObject(_position, _objectSize);
			return true;
		}

		private void RemoveFactoryObjects()
		{
			foreach (FactoryObject factoryObject in _factoryObjects)
			{
				if (!_factoryLayer.CanPlaceObjectAt(factoryObject.Position))
				{
					_factoryLayer.RemoveObjectAt(factoryObject.Position);
				}
			}
			_factoryObjectsRemoveViewsEvent.Fire(_blueprint.Elements.Select((BlueprintElement x) => x.CreatedId).ToList());
		}

		private void UndoRemoveFactoryObjects()
		{
			foreach (FactoryObject factoryObject in _factoryObjects)
			{
				AddObject(factoryObject);
			}
		}

		private void AddObject(FactoryObject factoryObject)
		{
			if (_factoryLayer.TryAddFactoryObject(factoryObject, invokeObjectsChangedEvent: false))
			{
				_createFactoryObjectEvent.Fire(new CreateFactoryObjectDto(_gridLocator.GetWorldPosition(factoryObject.Position), factoryObject.Rotation, factoryObject.Mirrored, factoryObject));
			}
		}
	}
}
