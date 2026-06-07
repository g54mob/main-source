using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using PajamaLlama.Flotsam.World;
using PajamaLlama.Math;
using UnityEngine;

public class PointOfInterestSpawner : ISpawner, ISpawnPositionProvider
{
	[Serializable]
	public class PersistentData
	{
		private readonly int _propertiesIndex;

		private readonly Vector3 _worldPosition;

		private readonly FlotsamSpawner.PersistentData[] _flotsamSpawners;

		private readonly FlotsamSpawner.PersistentData[] _compositedFlotsamSpawner;

		[OptionalField(VersionAdded = 2)]
		private readonly CountedItemPersistentData[] _flotsamItems;

		[OptionalField(VersionAdded = 2)]
		private readonly CountedItemPersistentData[] _compositedItems;

		[OptionalField(VersionAdded = 3)]
		private readonly ScoutingState _scoutingState;

		public PersistentData(PointOfInterestSpawner spawner)
		{
			_propertiesIndex = GameManager.PersistenceManager.ReturnPropertiesIndex(spawner.Properties);
			_worldPosition = spawner.TilePosition.Vector3TopDown();
			_scoutingState = spawner.ScoutingState;
			if (spawner.State == ISpawnerState.Interactable)
			{
				_flotsamSpawners = ReturnFlotsamSpawnerPersistentData(spawner._flotsamSpawners);
				_compositedFlotsamSpawner = ReturnFlotsamSpawnerPersistentData(spawner._compositedFlotsamSpawners);
			}
			else
			{
				_flotsamItems = ReturnCountedItems(spawner._flotsamSpawners);
				_compositedItems = ReturnCountedItems(spawner._compositedFlotsamSpawners);
			}
		}

		public bool TryRestore(out PointOfInterestSpawner spawner)
		{
			if (GameManager.PersistenceManager.TryReturnPropertiesReference<PointOfInterestProperties>(_propertiesIndex, out var reference))
			{
				spawner = new PointOfInterestSpawner(reference, _worldPosition)
				{
					ScoutingState = _scoutingState
				};
				if (_flotsamItems == null)
				{
					spawner._flotsamSpawners = ReturnFlotsamSpawnerGroup(_flotsamSpawners, spawner);
					spawner._compositedFlotsamSpawners = ReturnFlotsamSpawnerGroup(_compositedFlotsamSpawner, spawner);
				}
				else
				{
					spawner._flotsamSpawners = ReturnFlotsamSpawnerGroup(_flotsamItems, spawner);
					spawner._compositedFlotsamSpawners = CompositeFlotsamSpawnerFactory.RestoreCompositeFlotsamSpawnerGroup(_compositedItems, spawner);
				}
				spawner._initialized = true;
				return true;
			}
			spawner = null;
			return false;
		}

		private FlotsamSpawner.PersistentData[] ReturnFlotsamSpawnerPersistentData(FlotsamSpawnerGroup flotsamSpawnerGroup)
		{
			List<FlotsamSpawner> spawners = flotsamSpawnerGroup.Spawners;
			if (spawners == null)
			{
				return null;
			}
			int count = spawners.Count;
			FlotsamSpawner.PersistentData[] array = new FlotsamSpawner.PersistentData[count];
			for (int i = 0; i < count; i++)
			{
				array[i] = new FlotsamSpawner.PersistentData(spawners[i]);
			}
			return array;
		}

		private CountedItemPersistentData[] ReturnCountedItems(FlotsamSpawnerGroup flotsamSpawnerGroup)
		{
			InventoryAuditor global = InventoryAuditor.Global;
			global.Reset();
			flotsamSpawnerGroup.CountItems(global);
			return CountedItemPersistentData.GenerateFromInventoryAuditor(global);
		}

		private FlotsamSpawnerGroup ReturnFlotsamSpawnerGroup(FlotsamSpawner.PersistentData[] persistentData, PointOfInterestSpawner spawner)
		{
			if (persistentData == null)
			{
				return null;
			}
			FlotsamSpawnerGroup flotsamSpawnerGroup = new FlotsamSpawnerGroup(persistentData.Length);
			for (int i = 0; i < persistentData.Length; i++)
			{
				if (persistentData[i].TryRestore(spawner, out var spawner2))
				{
					flotsamSpawnerGroup.AddSpawner(spawner2);
				}
			}
			flotsamSpawnerGroup.SpawnerOutOfRangeEvent.AddListener(spawner.OnSpawnerOutOfRange);
			flotsamSpawnerGroup.OnSalvaged.AddListener(spawner.OnSpawnerOutOfRange);
			return flotsamSpawnerGroup;
		}

		private FlotsamSpawnerGroup ReturnFlotsamSpawnerGroup(CountedItemPersistentData[] countedItems, PointOfInterestSpawner spawner)
		{
			if (countedItems == null)
			{
				return null;
			}
			FlotsamSpawnerGroup flotsamSpawnerGroup = new FlotsamSpawnerGroup(countedItems.Length);
			for (int i = 0; i < countedItems.Length; i++)
			{
				CountedItemPersistentData countedItemPersistentData = countedItems[i];
				if (countedItemPersistentData.TryRestoreItemProperties(out var itemProperties))
				{
					for (int j = 0; j < countedItemPersistentData.Count; j++)
					{
						flotsamSpawnerGroup.AddSpawner(FlotsamSpawner.CreateFromItemProperties(itemProperties, spawner));
					}
				}
			}
			flotsamSpawnerGroup.SpawnerOutOfRangeEvent.AddListener(spawner.OnSpawnerOutOfRange);
			flotsamSpawnerGroup.OnSalvaged.AddListener(spawner.OnSpawnerOutOfRange);
			return flotsamSpawnerGroup;
		}
	}

	private readonly List<FlotsamProperties> _allFlotsamProps = new List<FlotsamProperties>();

	private FlotsamSpawnerGroup _flotsamSpawners;

	private FlotsamSpawnerGroup _compositedFlotsamSpawners;

	private Vector3 _worldPosition;

	private Vector3 _spawnPosition;

	private bool _initialized;

	private static List<Transform> _rootTransforms;

	public WorldTile Tile { get; private set; }

	public ISpawnerType Type => ISpawnerType.PointOfInterest;

	public ISpawnerState State { get; private set; }

	public ISpawnerEvent SpawnerOutOfRangeEvent { get; } = new ISpawnerEvent();

	public ISpawnerEvent OnSalvaged { get; } = new ISpawnerEvent();

	public Transform RootTransform { get; private set; }

	public PointOfInterestProperties Properties { get; }

	public Sprite Icon => Properties.DebugIcon;

	public Sprite BearingIcon => Properties.BearingIcon;

	public WorldTile WorldTile { get; set; }

	public Vector3 WorldPosition => _worldPosition;

	public Vector2 WorldPosition2D => _worldPosition.Vector2TopDown();

	public Vector2 TilePosition { get; }

	public Vector3 SpawnPosition => _spawnPosition;

	public bool HasPosition { get; private set; }

	public WorldRegionType RegionType => WorldRegionType.None;

	public ScoutingState ScoutingState { get; private set; }

	public string Name => Properties.Title.GetOrDefault(Properties.name);

	public ISpawnerEvent UpdatedEvent { get; } = new ISpawnerEvent();

	public PointOfInterestSpawner(PointOfInterestProperties properties)
	{
		Properties = properties;
		HasPosition = false;
	}

	public PointOfInterestSpawner(PointOfInterestProperties properties, Vector3 position)
		: this(properties)
	{
		TilePosition = position.Vector2TopDown();
		_worldPosition = position;
		_spawnPosition = position;
		HasPosition = true;
	}

	public void Initialize()
	{
		if (!_initialized)
		{
			_flotsamSpawners = new FlotsamSpawnerGroup(Properties.ReturnItems());
			_compositedFlotsamSpawners = new FlotsamSpawnerGroup(Properties.ReturnCompositedFlotsam());
		}
	}

	public void AddSpawnerListeners()
	{
		_flotsamSpawners.SpawnerOutOfRangeEvent.AddListener(OnSpawnerOutOfRange);
		_flotsamSpawners.OnSalvaged.AddListener(OnSpawnerSalvage);
		_compositedFlotsamSpawners.SpawnerOutOfRangeEvent.AddListener(OnSpawnerOutOfRange);
		_compositedFlotsamSpawners.OnSalvaged.AddListener(OnSpawnerSalvage);
	}

	public void SetWorldTileOffset(Vector3 offset)
	{
		if (HasPosition)
		{
			_worldPosition = TilePosition.Vector3TopDown(_worldPosition.y) + offset;
		}
		_compositedFlotsamSpawners.SetWorldTileOffset(offset);
		_flotsamSpawners.SetWorldTileOffset(offset);
	}

	public void Spawn(Transform parent)
	{
		if (!FlotsamSpawner.IsInToolMode)
		{
			State = ReturnState();
			_compositedFlotsamSpawners.Spawn(this);
			_flotsamSpawners.Spawn(this);
		}
	}

	public bool Despawn(bool destroyInstance)
	{
		_compositedFlotsamSpawners.Despawn(destroyInstance);
		_flotsamSpawners.Despawn(destroyInstance);
		ReleaseRootTransform();
		return true;
	}

	public void Move(Vector3 movement)
	{
		_spawnPosition += movement;
		if ((bool)RootTransform)
		{
			RootTransform.transform.position = _spawnPosition;
		}
		State = ReturnState();
		_compositedFlotsamSpawners.Move(movement);
		_flotsamSpawners.Move(movement);
	}

	public void RepositionRelativeToTownheart(Vector3 townheartPosition, Quaternion townheartRotation)
	{
		_spawnPosition = _worldPosition - townheartPosition;
		_spawnPosition = Quaternion.Inverse(townheartRotation) * _spawnPosition;
		if ((bool)RootTransform)
		{
			RootTransform.transform.position = _spawnPosition;
		}
		State = ReturnState();
		_compositedFlotsamSpawners.RepositionRelativeToTownheart(townheartPosition, townheartRotation);
		_flotsamSpawners.RepositionRelativeToTownheart(townheartPosition, townheartRotation);
	}

	public void CountItems(InventoryAuditor auditor)
	{
		if (_flotsamSpawners == null)
		{
			auditor.CountItemProperties(Properties.ReturnItems());
		}
		else
		{
			_flotsamSpawners.CountItems(auditor);
		}
		if (_compositedFlotsamSpawners == null)
		{
			foreach (CompositedFlotsamProperties item in Properties.ReturnCompositedFlotsam())
			{
				auditor.CountItemProperties(item.Composition);
			}
			return;
		}
		_compositedFlotsamSpawners.CountItems(auditor);
	}

	public void CountInteractableItemsInRange(InventoryAuditor auditor, float range)
	{
		if (State == ISpawnerState.Interactable && _spawnPosition.IsInRange(Vector3.zero, range))
		{
			CountItems(auditor);
		}
	}

	public void OnSpawnerOutOfRange(ISpawner spawner)
	{
		foreach (FlotsamSpawner spawner2 in _flotsamSpawners.Spawners)
		{
			if (!spawner2.IsOutOfRange)
			{
				return;
			}
		}
		foreach (FlotsamSpawner spawner3 in _compositedFlotsamSpawners.Spawners)
		{
			if (!spawner3.IsOutOfRange)
			{
				return;
			}
		}
		HasPosition = false;
		SpawnerOutOfRangeEvent.Invoke(this);
	}

	private void OnSpawnerSalvage(ISpawner spawner)
	{
		OnSalvaged.Invoke(spawner);
	}

	public void SetScoutingState(ScoutingState scoutingState)
	{
		if (ScoutingState < scoutingState)
		{
			ScoutingState = scoutingState;
			UpdatedEvent.Invoke(this);
		}
		else
		{
			Debug.LogWarning("Trying to lower scouting state for for point of interest '" + Name + "'! This is not supported!");
		}
	}

	private ISpawnerState ReturnState()
	{
		if (GameManager.WorldManager.IsInSpawnRadius(_spawnPosition))
		{
			AquireRootTransform();
			if (!GameManager.WorldManager.IsInteractable(_spawnPosition))
			{
				return ISpawnerState.NonInteractable;
			}
			return ISpawnerState.Interactable;
		}
		ReleaseRootTransform();
		return ISpawnerState.DoNotSpawn;
	}

	public Vector3 ReturnInitialSpawnPosition(bool dummy = false)
	{
		return ReturnSpawnPosition();
	}

	public Vector3 ReturnSpawnPosition()
	{
		return TilePosition.Vector3TopDown() + ReturnLocalSpawnPosition();
	}

	public Vector3 ReturnLocalSpawnPosition()
	{
		return FlotsamGame.RandomPosition(Vector3.zero, Properties.Radius, Properties.UseGaussianDistribution, Properties.ClearRadius);
	}

	public int ReturnSpawnerCount()
	{
		return _compositedFlotsamSpawners.Spawners.Count + _flotsamSpawners.Spawners.Count;
	}

	public FlotsamSpawner ReturnClosestFlotsamSpawner(Vector3 position, ref float shortestDistanceSquared, FlotsamSpawner closestSpawner)
	{
		if (State != ISpawnerState.Interactable)
		{
			return closestSpawner;
		}
		if (_flotsamSpawners != null)
		{
			closestSpawner = _flotsamSpawners.ReturnClosestFlotsamSpawner(position, ref shortestDistanceSquared, closestSpawner);
		}
		if (_compositedFlotsamSpawners != null)
		{
			closestSpawner = _compositedFlotsamSpawners.ReturnClosestFlotsamSpawner(position, ref shortestDistanceSquared, closestSpawner);
		}
		return closestSpawner;
	}

	public IReadOnlyList<FlotsamProperties> GetAllFlotsamProperties()
	{
		_allFlotsamProps.Clear();
		_allFlotsamProps.AddRange(_flotsamSpawners.GetAllFlotsamProperties());
		_allFlotsamProps.AddRange(_compositedFlotsamSpawners.GetAllFlotsamProperties());
		return _allFlotsamProps;
	}

	private void AquireRootTransform()
	{
		if (!RootTransform)
		{
			if (TryGetTransformInstance(out var instance))
			{
				RootTransform = instance;
			}
			else
			{
				RootTransform = new GameObject(Properties.name).transform;
				RootTransform.SetParent(GameManager.WorldManager.FlotsamParent);
			}
			RootTransform.position = _spawnPosition;
			RootTransform.gameObject.SetActive(value: true);
		}
	}

	private void ReleaseRootTransform()
	{
		if ((bool)RootTransform)
		{
			if (_rootTransforms == null)
			{
				_rootTransforms = new List<Transform>(16);
			}
			_rootTransforms.Add(RootTransform);
			RootTransform.gameObject.SetActive(value: false);
			RootTransform = null;
		}
	}

	private bool TryGetTransformInstance(out Transform instance)
	{
		instance = null;
		if (_rootTransforms.IsNullOrEmpty())
		{
			return false;
		}
		int count = _rootTransforms.Count;
		while (0 < count--)
		{
			instance = _rootTransforms[count];
			_rootTransforms.RemoveAt(count);
			if ((bool)instance)
			{
				return true;
			}
		}
		return false;
	}
}
