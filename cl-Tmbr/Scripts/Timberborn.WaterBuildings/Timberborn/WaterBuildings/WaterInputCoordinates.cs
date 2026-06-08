using System;
using System.Collections.Generic;
using Timberborn.BaseComponentSystem;
using Timberborn.BlockSystem;
using Timberborn.Common;
using Timberborn.DuplicationSystem;
using Timberborn.EntitySystem;
using Timberborn.Persistence;
using Timberborn.SingletonSystem;
using Timberborn.TerrainSystem;
using Timberborn.WorldPersistence;
using UnityEngine;

namespace Timberborn.WaterBuildings
{
	public class WaterInputCoordinates : BaseComponent, IAwakableComponent, IInitializableEntity, IDeletableEntity, IPostPlacementChangeListener, IPostInitializableEntity, IPersistentEntity, IDuplicable<WaterInputCoordinates>, IDuplicable
	{
		public static readonly BlockOccupations InvalidOccupations = ~(BlockOccupations.Floor | BlockOccupations.Corners);

		private static readonly ComponentKey WaterInputCoordinatesKey = new ComponentKey("WaterInputCoordinates");

		private static readonly PropertyKey<int> DepthLimitKey = new PropertyKey<int>("DepthLimit");

		private static readonly PropertyKey<bool> UseDepthLimitKey = new PropertyKey<bool>("UseDepthLimit");

		private readonly ITerrainService _terrainService;

		private readonly IBlockService _blockService;

		private readonly EventBus _eventBus;

		private BlockObject _blockObject;

		private WaterInputSpec _waterInputSpec;

		private readonly List<BlockObject> _blockObjectCache = new List<BlockObject>();

		public Vector3Int Coordinates { get; private set; }

		public int Depth { get; private set; }

		public int DepthLimit { get; private set; }

		public bool UseDepthLimit { get; private set; }

		public event EventHandler<Vector3Int> CoordinatesChanged;

		public WaterInputCoordinates(ITerrainService terrainService, IBlockService blockService, EventBus eventBus)
		{
			_terrainService = terrainService;
			_blockService = blockService;
			_eventBus = eventBus;
		}

		public void Awake()
		{
			_blockObject = GetComponent<BlockObject>();
			_waterInputSpec = GetComponent<WaterInputSpec>();
			DepthLimit = _waterInputSpec.MaxDepth;
			Asserts.ValueIsInRange(DepthLimit, 1, int.MaxValue, "DepthLimit");
		}

		public void InitializeEntity()
		{
			_terrainService.TerrainHeightChanged += OnTerrainHeightChanged;
			_eventBus.Register(this);
		}

		public void PostInitializeEntity()
		{
			UpdateCoordinatesAndDepth();
		}

		public void DeleteEntity()
		{
			_terrainService.TerrainHeightChanged -= OnTerrainHeightChanged;
			_eventBus.Unregister(this);
		}

		public void Save(IEntitySaver entitySaver)
		{
			IObjectSaver component = entitySaver.GetComponent(WaterInputCoordinatesKey);
			component.Set(DepthLimitKey, DepthLimit);
			component.Set(UseDepthLimitKey, UseDepthLimit);
		}

		public void Load(IEntityLoader entityLoader)
		{
			IObjectLoader component = entityLoader.GetComponent(WaterInputCoordinatesKey);
			DepthLimit = Math.Min(component.Get(DepthLimitKey), _waterInputSpec.MaxDepth);
			UseDepthLimit = component.Get(UseDepthLimitKey);
		}

		public void DuplicateFrom(WaterInputCoordinates source)
		{
			UseDepthLimit = source.UseDepthLimit;
			DepthLimit = Math.Min(source.DepthLimit, _waterInputSpec.MaxDepth);
			UpdateCoordinatesAndDepth();
		}

		public void OnPostPlacementChanged()
		{
			UpdateCoordinatesAndDepth();
		}

		public void SetDepthLimit(int depth)
		{
			UseDepthLimit = true;
			DepthLimit = depth;
			UpdateCoordinatesAndDepth();
		}

		public void DisableDepthLimit()
		{
			UseDepthLimit = false;
			DepthLimit = _waterInputSpec.MaxDepth;
			UpdateCoordinatesAndDepth();
		}

		[OnEvent]
		public void OnBlockObjectSetEvent(BlockObjectSetEvent blockObjectSetEvent)
		{
			if (ShouldUpdate(blockObjectSetEvent.BlockObject.PositionedBlocks))
			{
				UpdateCoordinatesAndDepth();
			}
		}

		[OnEvent]
		public void OnBlockObjectUnsetEvent(BlockObjectUnsetEvent blockObjectUnsetEvent)
		{
			if (ShouldUpdate(blockObjectUnsetEvent.BlockObject.PositionedBlocks))
			{
				UpdateCoordinatesAndDepth();
			}
		}

		private void OnTerrainHeightChanged(object sender, TerrainHeightChangeEventArgs terrainHeightChangeEventArgs)
		{
			if (terrainHeightChangeEventArgs.Change.Coordinates == Coordinates.XY())
			{
				UpdateCoordinatesAndDepth();
			}
		}

		private bool ShouldUpdate(PositionedBlocks changedBlocks)
		{
			foreach (Vector3Int allCoordinate in changedBlocks.GetAllCoordinates())
			{
				if (allCoordinate.XY() == Coordinates.XY() && allCoordinate.z <= _blockObject.CoordinatesAtBaseZ.z)
				{
					return true;
				}
			}
			return false;
		}

		private void UpdateCoordinatesAndDepth()
		{
			Vector3Int waterInputCoordinates = _waterInputSpec.WaterInputCoordinates;
			Vector3Int startCoordinates = _blockObject.TransformCoordinates(waterInputCoordinates) + new Vector3Int(0, 0, _blockObject.BaseZ + 1);
			Coordinates = new Vector3Int(startCoordinates.x, startCoordinates.y, GetZCoordinateLimitedByDepth(startCoordinates));
			Depth = startCoordinates.z - Coordinates.z;
			this.CoordinatesChanged?.Invoke(this, Coordinates);
		}

		private int GetZCoordinateLimitedByDepth(Vector3Int startCoordinates)
		{
			int z = startCoordinates.z;
			int num = (UseDepthLimit ? DepthLimit : _waterInputSpec.MaxDepth);
			for (int num2 = z - 1; num2 >= z - num; num2--)
			{
				Vector3Int coordinates = new Vector3Int(startCoordinates.x, startCoordinates.y, num2);
				if (IsTileOccupied(coordinates))
				{
					return num2 + 1;
				}
			}
			return z - num;
		}

		private bool IsTileOccupied(Vector3Int coordinates)
		{
			if (_terrainService.Underground(coordinates))
			{
				return true;
			}
			_blockService.GetIntersectingObjectsAt(coordinates, InvalidOccupations, _blockObjectCache);
			bool result = HasOccupyingObject();
			_blockObjectCache.Clear();
			return result;
		}

		private bool HasOccupyingObject()
		{
			foreach (BlockObject item in _blockObjectCache)
			{
				if (!item.Overridable && item != _blockObject && !item.HasComponent<PipeIntersectionAllowerSpec>())
				{
					return true;
				}
			}
			return false;
		}
	}
}
