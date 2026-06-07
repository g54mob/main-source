#define ENABLE_DEBUG_WARNINGS
#define ENABLE_DEBUG_ERRORS
using System.Collections.Generic;
using System.Linq;
using Data.FactoryFloor;
using Data.FactoryFloor.FactoryObjectBehaviours.NatureBehaviour;
using Events.FactoryFloor;
using Events.Generic;
using Logic.Factory.Blueprint;
using Presentation.Locators;
using UnityEngine;
using Utils;

namespace Commands.ToolsCommands
{
	public class PlaceBlueprintCommand : ICommandUndo, ICommand
	{
		private readonly FactoryLayer _factoryLayer;

		private readonly FactoryLayer _terrainLayer;

		private Vector3Int _position;

		private readonly int _rotation;

		private readonly Blueprint _blueprint;

		private readonly CreateFactoryObjectEvent _createFactoryObjectEvent;

		private readonly GridLocator _gridLocator;

		private readonly IntListEvent _factoryObjectsRemoveViewsEvent;

		private readonly AudioManagerLocator _audioManagerLocator;

		private readonly List<FactoryObject> _factoryObjects = new List<FactoryObject>();

		private readonly List<FactoryObject> _deletedObjects = new List<FactoryObject>();

		private int _objectSize = -1;

		private int _natureObjectSize = -1;

		public PlaceBlueprintCommand(FactoryLayer factoryLayer, FactoryLayer terrainLayer, Vector3Int position, int rotation, Blueprint blueprint, CreateFactoryObjectEvent createFactoryObjectEvent, GridLocator gridLocator, IntListEvent factoryObjectsRemoveViewsEvent, AudioManagerLocator audioManagerLocator)
		{
			_factoryLayer = factoryLayer;
			_terrainLayer = terrainLayer;
			_position = position;
			_rotation = rotation;
			_blueprint = blueprint;
			_createFactoryObjectEvent = createFactoryObjectEvent;
			_gridLocator = gridLocator;
			_factoryObjectsRemoveViewsEvent = factoryObjectsRemoveViewsEvent;
			_audioManagerLocator = audioManagerLocator;
		}

		public bool TryDo()
		{
			if (!BlueprintPlacementValidator.CanBePlaced(_position, _blueprint, _factoryLayer, _terrainLayer))
			{
				_audioManagerLocator.AudioManager.PlayCantPlace(_position);
				return false;
			}
			_deletedObjects.Clear();
			_objectSize = 0;
			for (int i = 0; i < _blueprint.Elements.Count; i++)
			{
				BlueprintElement blueprintElement = _blueprint.Elements[i];
				FactoryObject factoryObject = new FactoryObject(FactoryObject.GetOccupiedPositions(_position, blueprintElement.RelativePositions), blueprintElement.ObjectData, IntIdGenerator.GetNewId, (_rotation + blueprintElement.Rotation) % 360, blueprintElement.Mirrored, nonChangable: false, _factoryLayer, blueprintElement.Configurations?.ToArray());
				PlaceFactoryObject(i, factoryObject);
			}
			_factoryLayer.ObjectsInLayerChanged();
			LinkBlueprintElements();
			if (_deletedObjects.Count > 0)
			{
				_factoryObjectsRemoveViewsEvent.Fire(_deletedObjects.Select((FactoryObject x) => x.CreatedId).ToList());
			}
			PlayPlaceSFX();
			return true;
		}

		public bool TryReDo()
		{
			_deletedObjects.Clear();
			int num = 0;
			foreach (FactoryObject factoryObject in _factoryObjects)
			{
				PlaceFactoryObject(num++, factoryObject);
			}
			_factoryLayer.ObjectsInLayerChanged();
			LinkBlueprintElements();
			if (_deletedObjects.Count > 0)
			{
				_factoryObjectsRemoveViewsEvent.Fire(_deletedObjects.Select((FactoryObject x) => x.CreatedId).ToList());
			}
			PlayPlaceSFX();
			return true;
		}

		public bool TryUnDo()
		{
			List<int> list = new List<int>();
			foreach (FactoryObject factoryObject in _factoryObjects)
			{
				if (_factoryLayer.CanPlaceObjectAt(factoryObject.Position))
				{
					this.LogError("Can't delete object at position " + factoryObject.Position.ToString(), "TryUnDo", 122);
					continue;
				}
				_factoryLayer.RemoveObjectAt(factoryObject.Position, invokeObjectsChangedEvent: false);
				list.Add(factoryObject.CreatedId);
				UnlinkAllElements(factoryObject);
			}
			foreach (FactoryObject deletedObject in _deletedObjects)
			{
				AddObject(deletedObject);
			}
			_deletedObjects.Clear();
			_factoryLayer.ObjectsInLayerChanged();
			_factoryObjectsRemoveViewsEvent.Fire(list);
			_audioManagerLocator.AudioManager.PlayDeleteObject(_position, _objectSize);
			return true;
		}

		private void PlaceFactoryObject(int index, FactoryObject factoryObject)
		{
			if (!_factoryLayer.CanPlaceObjectAt(factoryObject.OccupiedPositions))
			{
				foreach (Vector3Int occupiedPosition in factoryObject.OccupiedPositions)
				{
					FactoryObject objectAt = _factoryLayer.GetObjectAt(occupiedPosition);
					if (objectAt != null)
					{
						_deletedObjects.Add(objectAt);
						_factoryLayer.RemoveObjectAt(occupiedPosition);
					}
				}
			}
			if ((bool)factoryObject.FactoryObjectData.GetFactoryObjectBehaviour<IsNatureBehaviour>())
			{
				_natureObjectSize = Mathf.Max(_natureObjectSize, factoryObject.FactoryObjectData.ObjectSize);
			}
			else
			{
				_objectSize = Mathf.Max(_objectSize, factoryObject.FactoryObjectData.ObjectSize);
			}
			AddObject(factoryObject, index);
		}

		private void AddObject(FactoryObject factoryObject, int index = -1)
		{
			if (_factoryLayer.TryAddFactoryObject(factoryObject, invokeObjectsChangedEvent: false))
			{
				if (!_factoryObjects.Contains(factoryObject) && !_deletedObjects.Contains(factoryObject))
				{
					_factoryObjects.Add(factoryObject);
				}
				_createFactoryObjectEvent.Fire(new CreateFactoryObjectDto(_gridLocator.GetWorldPosition(factoryObject.OccupiedPositions[0]), factoryObject.Rotation, factoryObject.Mirrored, factoryObject, index));
			}
		}

		private void LinkBlueprintElements()
		{
			foreach (BlueprintElement element in _blueprint.Elements)
			{
				if (element.IsHardLinked)
				{
					foreach (Vector3Int linkedPos in element.HardLinkedToRelativePositions)
					{
						FactoryObject factoryObject = _factoryObjects.FirstOrDefault((FactoryObject x) => x.Position == _position + element.RelativePositions[0]);
						FactoryObject factoryObject2 = _factoryObjects.FirstOrDefault((FactoryObject x) => x.Position == _position + linkedPos);
						factoryObject.HardLink(factoryObject2);
					}
				}
				if (!element.IsSoftLinked)
				{
					continue;
				}
				foreach (Vector3Int linkedPos2 in element.SoftLinkedToRelativePositions)
				{
					FactoryObject factoryObject3 = _factoryObjects.FirstOrDefault((FactoryObject x) => x.Position == _position + element.RelativePositions[0]);
					FactoryObject factoryObject4 = _factoryObjects.FirstOrDefault((FactoryObject x) => x.Position == _position + linkedPos2);
					if (factoryObject4 == null)
					{
						this.LogWarning($"Softlinked element not found at {_position}+{linkedPos2}", "LinkBlueprintElements", 213);
					}
					else
					{
						factoryObject3.SoftLink(factoryObject4);
					}
				}
			}
		}

		private static void UnlinkAllElements(FactoryObject element)
		{
			if (element.IsHardLinked)
			{
				for (int num = element.HardLinkedObjects.Count - 1; num >= 0; num--)
				{
					FactoryObject factoryObject = element.HardLinkedObjects[num];
					element.UnlinkHard(factoryObject);
				}
			}
			if (element.IsSoftLinked)
			{
				for (int num2 = element.SoftLinkedObjects.Count - 1; num2 >= 0; num2--)
				{
					FactoryObject factoryObject2 = element.SoftLinkedObjects[num2];
					element.UnlinkSoft(factoryObject2);
				}
			}
		}

		private void PlayPlaceSFX()
		{
			if (_natureObjectSize > -1)
			{
				_audioManagerLocator.AudioManager.PlayPlaceNatureObject(_position, _natureObjectSize);
			}
			if (_objectSize > -1)
			{
				_audioManagerLocator.AudioManager.PlayPlaceObjectGeneric(_position, _blueprint, _objectSize);
			}
		}
	}
}
