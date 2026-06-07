using System;
using System.Collections.Generic;
using Data.Operator;
using Data.Variables;
using Presentation.FactoryFloor.Islands;
using UnityEngine;

namespace Data.FactoryFloor.Maps
{
	public class IslandObject
	{
		public struct FactoryObjectCollection
		{
			public Dictionary<Vector3Int, FactoryObject> ObjectsInLayer;

			public Dictionary<FactoryObjectData, List<FactoryObject>> ObjectDataToFactoryObjects;

			public List<FactoryObject> DistinctObjects;
		}

		public const float ISLAND_ACTIVE_RADIUS = 250f;

		public const float ISLAND_NEARBY_RADIUS = 500f;

		public const float MAX_ZOOM_MODIFIER_MULTIPLIER = 1.5f;

		private readonly IslandConfig _islandConfig;

		private IslandView _islandView;

		private readonly Dictionary<FactoryLayer, FactoryObjectCollection> _factoryObjectCollections = new Dictionary<FactoryLayer, FactoryObjectCollection>();

		private Vector2Int _islandSize;

		private float _lastUpdateTime;

		private float _processWaitTime;

		private IslandCullState _islandCullState;

		private IslandOverclockData _overclockData;

		private MaxZoomLevelModifierSO _maxZoomLevelModifier;

		public int CreatedId => _islandConfig.CreatedID;

		public Guid Guid => _islandConfig.ID;

		public int Rotation => _islandConfig.Rotation;

		public Vector3Int Position => _islandConfig.Position;

		public Vector2Int Size => _islandSize;

		public IslandConfig IslandConfig => _islandConfig;

		public IslandView IslandView => _islandView;

		public IslandOverclockData OverclockData => _overclockData;

		public List<Vector3Int> Positions { get; }

		public event Action<IslandObject, FactoryLayer> OnObjectsOnIslandChanged = delegate
		{
		};

		public event Action<FactoryLayer, FactoryObject, IslandObject> OnFactoryObjectAdded = delegate
		{
		};

		public event Action<FactoryLayer, FactoryObject, IslandObject> OnFactoryObjectRemoved = delegate
		{
		};

		public event Action<IslandObject> OnIslandChangedCullingState = delegate
		{
		};

		public IslandObject(IslandConfig islandConfig, List<Vector3Int> positions, MaxZoomLevelModifierSO maxZoomLevelModifier)
		{
			_maxZoomLevelModifier = maxZoomLevelModifier;
			_islandConfig = islandConfig;
			Positions = positions;
			_islandSize = new Vector2Int((int)_islandConfig.Size.x, (int)_islandConfig.Size.y);
			_overclockData = new IslandOverclockData(this);
		}

		public void SetLastUpdateTime(float time, float processWaitTime)
		{
			_lastUpdateTime = time;
			_processWaitTime = processWaitTime;
		}

		public float GetDeltaTimePerc(float currentTime)
		{
			return Mathf.Clamp01((currentTime - _lastUpdateTime) / _processWaitTime);
		}

		public void SetIslandView(IslandView islandView)
		{
			_islandView = islandView;
			IslandView.SetIslandObject(this);
		}

		public void AddFactoryObject(FactoryLayer factoryLayer, FactoryObject factoryObject)
		{
			FactoryObjectCollection collection = GetCollection(factoryLayer);
			collection.DistinctObjects.Add(factoryObject);
			foreach (Vector3Int occupiedPosition in factoryObject.OccupiedPositions)
			{
				collection.ObjectsInLayer.Add(occupiedPosition, factoryObject);
			}
			AddToObjectDataInstanceList(collection, factoryObject);
			factoryObject.AssignIsland(this);
			factoryObject.Initialize();
			this.OnObjectsOnIslandChanged(this, factoryLayer);
			this.OnFactoryObjectAdded(factoryLayer, factoryObject, this);
		}

		public void RemoveFactoryObjectAt(FactoryLayer factoryLayer, Vector3Int position)
		{
			FactoryObjectCollection collection = GetCollection(factoryLayer);
			FactoryObject factoryObject = collection.ObjectsInLayer[position];
			collection.DistinctObjects.Remove(factoryObject);
			factoryObject.UpdateSaveState();
			factoryObject.UpdateConfigurations();
			factoryObject.UnInitialize();
			foreach (Vector3Int occupiedPosition in factoryObject.OccupiedPositions)
			{
				collection.ObjectsInLayer.Remove(occupiedPosition);
			}
			collection.ObjectDataToFactoryObjects[factoryObject.FactoryObjectData].Remove(factoryObject);
			if (collection.ObjectDataToFactoryObjects[factoryObject.FactoryObjectData].Count <= 0)
			{
				collection.ObjectDataToFactoryObjects.Remove(factoryObject.FactoryObjectData);
			}
			this.OnObjectsOnIslandChanged(this, factoryLayer);
			this.OnFactoryObjectRemoved(factoryLayer, factoryObject, this);
		}

		public void RemoveFactoryObject(FactoryLayer factoryLayer, FactoryObject factoryObject)
		{
			FactoryObjectCollection collection = GetCollection(factoryLayer);
			collection.DistinctObjects.Remove(factoryObject);
			factoryObject.UpdateSaveState();
			factoryObject.UpdateConfigurations();
			factoryObject.UnInitialize();
			foreach (Vector3Int occupiedPosition in factoryObject.OccupiedPositions)
			{
				collection.ObjectsInLayer.Remove(occupiedPosition);
			}
			collection.ObjectDataToFactoryObjects[factoryObject.FactoryObjectData].Remove(factoryObject);
			if (collection.ObjectDataToFactoryObjects[factoryObject.FactoryObjectData].Count <= 0)
			{
				collection.ObjectDataToFactoryObjects.Remove(factoryObject.FactoryObjectData);
			}
			this.OnObjectsOnIslandChanged(this, factoryLayer);
			this.OnFactoryObjectRemoved(factoryLayer, factoryObject, this);
		}

		public bool CanPlaceObjectAt(FactoryLayer factoryLayer, List<Vector3Int> occupiedPositions)
		{
			FactoryObjectCollection collection = GetCollection(factoryLayer);
			foreach (Vector3Int occupiedPosition in occupiedPositions)
			{
				if (collection.ObjectsInLayer.ContainsKey(occupiedPosition) || !IsPositionOnIsland(occupiedPosition))
				{
					return false;
				}
			}
			return true;
		}

		public bool CanPlaceObjectAt(FactoryLayer factoryLayer, Vector3Int position)
		{
			if (GetCollection(factoryLayer).ObjectsInLayer.ContainsKey(position) || !IsPositionOnIsland(position))
			{
				return false;
			}
			return true;
		}

		public FactoryObject GetObjectAt(FactoryLayer factoryLayer, Vector3Int position)
		{
			if (!GetCollection(factoryLayer).ObjectsInLayer.TryGetValue(position, out var value))
			{
				return null;
			}
			return value;
		}

		public bool TryGetObjectAt(FactoryLayer factoryLayer, Vector3Int position, out FactoryObject factoryObject)
		{
			return GetCollection(factoryLayer).ObjectsInLayer.TryGetValue(position, out factoryObject);
		}

		private FactoryObjectCollection GetCollection(FactoryLayer factoryLayer)
		{
			if (!_factoryObjectCollections.ContainsKey(factoryLayer))
			{
				_factoryObjectCollections.Add(factoryLayer, new FactoryObjectCollection
				{
					ObjectsInLayer = new Dictionary<Vector3Int, FactoryObject>(),
					DistinctObjects = new List<FactoryObject>(),
					ObjectDataToFactoryObjects = new Dictionary<FactoryObjectData, List<FactoryObject>>()
				});
			}
			return _factoryObjectCollections[factoryLayer];
		}

		private void AddToObjectDataInstanceList(FactoryObjectCollection collection, FactoryObject factoryObject)
		{
			if (!collection.ObjectDataToFactoryObjects.ContainsKey(factoryObject.FactoryObjectData))
			{
				collection.ObjectDataToFactoryObjects.Add(factoryObject.FactoryObjectData, new List<FactoryObject> { factoryObject });
			}
			else
			{
				collection.ObjectDataToFactoryObjects[factoryObject.FactoryObjectData].Add(factoryObject);
			}
		}

		public bool IsPositionOnIsland(Vector3Int position)
		{
			int num = -(_islandSize.x / 2);
			int num2 = Position.x + num;
			if (position.x < num2)
			{
				return false;
			}
			int num3 = _islandSize.x + Position.x + num;
			if (position.x >= num3)
			{
				return false;
			}
			num = -(_islandSize.y / 2);
			num2 = Position.z + num;
			if (position.z < num2)
			{
				return false;
			}
			num3 = _islandSize.y + Position.z + num;
			if (position.z >= num3)
			{
				return false;
			}
			return true;
		}

		public List<FactoryObject> GetAllDistinctObjects(FactoryLayer factoryLayer)
		{
			return GetCollection(factoryLayer).DistinctObjects;
		}

		public IEnumerable<FactoryObject> GetAllDistinctObjectsEnumerable(FactoryLayer factoryLayer)
		{
			foreach (FactoryObject distinctObject in GetCollection(factoryLayer).DistinctObjects)
			{
				yield return distinctObject;
			}
		}

		public void EvaluateCullingState(Vector3 cameraPos)
		{
			float sqrMagnitude = (cameraPos - Position).sqrMagnitude;
			float num = (float)(_maxZoomLevelModifier.Value * _maxZoomLevelModifier.Value) * 1.5f;
			float num2 = 62500f + num;
			float num3 = 250000f + num;
			if (_islandCullState == IslandCullState.Active)
			{
				if (sqrMagnitude > num2)
				{
					_islandCullState = IslandCullState.PlayerNearby;
					this.OnIslandChangedCullingState?.Invoke(this);
				}
			}
			else if (_islandCullState == IslandCullState.PlayerNearby)
			{
				if (sqrMagnitude > num3)
				{
					_islandCullState = IslandCullState.Virtual;
					this.OnIslandChangedCullingState?.Invoke(this);
				}
				else if (sqrMagnitude < num2)
				{
					_islandCullState = IslandCullState.Active;
					this.OnIslandChangedCullingState?.Invoke(this);
				}
			}
			else if (_islandCullState == IslandCullState.Virtual && sqrMagnitude < num3)
			{
				_islandCullState = IslandCullState.PlayerNearby;
				this.OnIslandChangedCullingState?.Invoke(this);
			}
		}

		public IslandCullState GetCullState()
		{
			return _islandCullState;
		}

		public void Clear(FactoryLayer factoryLayer)
		{
			FactoryObjectCollection collection = GetCollection(factoryLayer);
			foreach (FactoryObject distinctObject in collection.DistinctObjects)
			{
				distinctObject.DestroyBehaviours();
			}
			collection.DistinctObjects.Clear();
			collection.ObjectsInLayer.Clear();
			collection.ObjectDataToFactoryObjects.Clear();
		}

		public List<FactoryObject> GetObjectsFromData(FactoryLayer factoryLayer, FactoryObjectData factoryObjectData)
		{
			FactoryObjectCollection collection = GetCollection(factoryLayer);
			if (!collection.ObjectDataToFactoryObjects.ContainsKey(factoryObjectData))
			{
				return new List<FactoryObject>();
			}
			return collection.ObjectDataToFactoryObjects[factoryObjectData];
		}

		public bool TryGetObjectsFromData(FactoryLayer factoryLayer, FactoryObjectData factoryObjectData, out List<FactoryObject> factoryObjects)
		{
			return GetCollection(factoryLayer).ObjectDataToFactoryObjects.TryGetValue(factoryObjectData, out factoryObjects);
		}
	}
}
