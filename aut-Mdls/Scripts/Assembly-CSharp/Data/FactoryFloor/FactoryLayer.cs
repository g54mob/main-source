#define ENABLE_DEBUG_ERRORS
using System;
using System.Collections.Generic;
using Data.FactoryFloor.Maps;
using Data.Operator;
using Data.Variables;
using Events.FactoryFloor;
using UnityEngine;
using Utils;

namespace Data.FactoryFloor
{
	[CreateAssetMenu(menuName = "Factory/New factory layer", fileName = "FactoryLayer", order = 0)]
	public class FactoryLayer : ScriptableObject
	{
		[SerializeField]
		private FactoryObjectDeletedEvent _factoryObjectDeletedEvent;

		[SerializeField]
		private IslandLayer _islandLayer;

		public event Action<FactoryLayer> OnObjectsInLayerChanged;

		public event Action<FactoryObject> OnObjectAdded;

		public event Action<FactoryObject> OnObjectRemoved;

		public void ObjectsInLayerChanged()
		{
			this.OnObjectsInLayerChanged?.Invoke(this);
		}

		public bool TryAddFactoryObject(FactoryObject factoryObject, bool invokeObjectsChangedEvent = true)
		{
			if (!_islandLayer.TryAddFactoryObject(this, factoryObject))
			{
				return false;
			}
			if (invokeObjectsChangedEvent)
			{
				ObjectsInLayerChanged();
			}
			this.OnObjectAdded?.Invoke(factoryObject);
			return true;
		}

		public FactoryObject GetObjectAt(Vector3Int position)
		{
			return _islandLayer.GetObjectAt(this, position);
		}

		public bool TryGetObjectAt(Vector3Int position, out FactoryObject factoryObject)
		{
			return _islandLayer.TryGetObjectAt(this, position, out factoryObject);
		}

		public bool CanPlaceObjectAt(List<Vector3Int> gridPositions)
		{
			return _islandLayer.CanPlaceObjectAt(this, gridPositions);
		}

		public bool CanPlaceObjectAt(Vector3Int gridPosition, List<FactoryObjectData> overridableExceptions)
		{
			if (TryGetObjectAt(gridPosition, out var factoryObject) && overridableExceptions.Contains(factoryObject.FactoryObjectData))
			{
				return true;
			}
			return CanPlaceObjectAt(gridPosition);
		}

		public bool CanPlaceObjectAt(Vector3Int gridPosition)
		{
			return _islandLayer.CanPlaceObjectAt(this, gridPosition);
		}

		public void RemoveObjectAt(Vector3Int position, bool invokeObjectsChangedEvent = true)
		{
			if (!_islandLayer.TryGetObjectAt(this, position, out var factoryObject))
			{
				this.LogError($"Couldn't remove object at: {position}, does not exist in island layer", "RemoveObjectAt", 80);
				return;
			}
			_islandLayer.RemoveFactoryObject(this, factoryObject);
			_factoryObjectDeletedEvent.Fire((factoryObject, this));
			if (invokeObjectsChangedEvent)
			{
				ObjectsInLayerChanged();
			}
			this.OnObjectRemoved?.Invoke(factoryObject);
		}

		public void Clear()
		{
			_islandLayer.ClearObjects(this);
			this.OnObjectsInLayerChanged?.Invoke(this);
		}

		public void GetObjectsBetween(Vector3Int startPosition, Vector3Int endPosition, List<FactoryObject> factoryObjects)
		{
			int num = Mathf.Min(startPosition.x, endPosition.x);
			int num2 = Mathf.Max(startPosition.x, endPosition.x);
			int num3 = Mathf.Min(startPosition.y, endPosition.y);
			int num4 = Mathf.Max(startPosition.y, endPosition.y);
			int num5 = Mathf.Min(startPosition.z, endPosition.z);
			int num6 = Mathf.Max(startPosition.z, endPosition.z);
			for (int i = num; i <= num2; i++)
			{
				for (int j = num3; j <= num4; j++)
				{
					for (int k = num5; k <= num6; k++)
					{
						FactoryObject objectAt = GetObjectAt(new Vector3Int(i, j, k));
						AddHardLinkedObjects(objectAt, factoryObjects);
					}
				}
			}
		}

		public void GetCranesBetween(CranesLibrarySO cranesLibrary, Vector3Int startPosition, Vector3Int endPosition, List<Vector3Int> results)
		{
			int num = Mathf.Min(startPosition.x, endPosition.x);
			int num2 = Mathf.Max(startPosition.x, endPosition.x);
			int num3 = Mathf.Min(startPosition.y, endPosition.y);
			int num4 = Mathf.Max(startPosition.y, endPosition.y);
			int num5 = Mathf.Min(startPosition.z, endPosition.z);
			int num6 = Mathf.Max(startPosition.z, endPosition.z);
			for (int i = num; i <= num2; i++)
			{
				for (int j = num3; j <= num4; j++)
				{
					for (int k = num5; k <= num6; k++)
					{
						Vector3Int vector3Int = new Vector3Int(i, j, k);
						if (cranesLibrary.Cranes.ContainsKey(vector3Int))
						{
							results.Add(vector3Int);
						}
					}
				}
			}
		}

		private void AddHardLinkedObjects(FactoryObject factoryObject, List<FactoryObject> allFactoryObjects)
		{
			if (factoryObject == null || allFactoryObjects.Contains(factoryObject))
			{
				return;
			}
			allFactoryObjects.Add(factoryObject);
			if (!factoryObject.IsHardLinked)
			{
				return;
			}
			foreach (FactoryObject hardLinkedObject in factoryObject.HardLinkedObjects)
			{
				AddHardLinkedObjects(hardLinkedObject, allFactoryObjects);
			}
		}

		public IEnumerable<FactoryObject> GetAllDistinctObjectLists()
		{
			return _islandLayer.GetAllDistinctObjects(this);
		}

		public List<FactoryObject> GetObjectsFromData(FactoryObjectData factoryObjectData)
		{
			return _islandLayer.GetObjectsFromData(this, factoryObjectData);
		}

		public bool TryGetObjectsFromData(FactoryObjectData factoryObjectData, out List<FactoryObject> factoryObjects)
		{
			return _islandLayer.TryGetObjectsFromData(this, factoryObjectData, out factoryObjects);
		}
	}
}
