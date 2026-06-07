using System;
using System.Collections.Generic;
using PajamaLlama.Flotsam.World;
using PajamaLlama.Math;
using UnityEngine;
using UnityEngine.Events;

public class FlotsamSpawner : ISpawner
{
	public delegate GameObject InstantiateInToolMode(FlotsamSpawner spawner, Vector3 position, PointOfInterestSpawner pointOfInterestSpawner);

	public class FlotsamSpawnerEvent : UnityEvent<FlotsamSpawner>
	{
	}

	[Serializable]
	public class PersistentData : PersistentReference<Flotsam>
	{
		private readonly int _propertiesIndex;

		private readonly int _visualPrefabIndex;

		private readonly Vector3 _worldPosition;

		private readonly Quaternion _worldRotation;

		private readonly ItemPersistentData[] _items;

		public PersistentData(FlotsamSpawner spawner)
			: base(spawner.Instance as Flotsam)
		{
			_propertiesIndex = GameManager.PersistenceManager.ReturnPropertiesIndex(spawner.Properties);
			_visualPrefabIndex = spawner._visualPrefabIndex;
			_worldPosition = spawner.TilePosition.Vector3TopDown();
			_worldRotation = spawner._worldRotation;
			_items = ReturnItemPersistentData(spawner._compositionInventory);
		}

		public bool TryRestore(PointOfInterestSpawner parent, out FlotsamSpawner spawner)
		{
			if (GameManager.PersistenceManager.TryReturnPropertiesReference<FlotsamProperties>(_propertiesIndex, out var reference))
			{
				spawner = new FlotsamSpawner(reference)
				{
					_visualPrefabIndex = _visualPrefabIndex,
					TilePosition = _worldPosition.Vector2TopDown(),
					_worldPosition = _worldPosition,
					_worldRotation = _worldRotation,
					_compositionInventory = ReturnCompositionInventory()
				};
				if (!spawner._worldPosition.Vector2TopDown().IsInRange(parent.WorldPosition2D, parent.Properties.Radius))
				{
					spawner.IsOutOfRange = true;
				}
				if (-1 < PersistentIndex)
				{
					spawner._onSpawn.AddListener(OnFirstSpawn);
				}
				return true;
			}
			spawner = null;
			return false;
		}

		private void OnFirstSpawn(FlotsamSpawner spawner)
		{
			spawner._onSpawn.RemoveListener(OnFirstSpawn);
			base.Instance = spawner._instance as Flotsam;
			if ((bool)base.Instance)
			{
				Restore();
			}
		}

		private ItemPersistentData[] ReturnItemPersistentData(CompositionInventory composition)
		{
			List<Item> list = ListPool<Item>.Get();
			composition.ReturnAllItems(list);
			int count = list.Count;
			ItemPersistentData[] array = new ItemPersistentData[count];
			for (int i = 0; i < count; i++)
			{
				array[i] = new ItemPersistentData(list[i]);
			}
			ListPool<Item>.Add(list);
			return array;
		}

		private CompositionInventory ReturnCompositionInventory()
		{
			List<Item> list = ListPool<Item>.Get();
			ItemPersistentData[] items = _items;
			for (int i = 0; i < items.Length; i++)
			{
				if (items[i].TryRestore(filterSuperItems: false, out var item))
				{
					list.Add(item);
				}
			}
			CompositionInventory result = new CompositionInventory(list);
			ListPool<Item>.Add(list);
			return result;
		}
	}

	public static bool IsInToolMode;

	public static InstantiateInToolMode InstantiateInToolModeCallback;

	private CompositionInventory _compositionInventory;

	private Vector3 _worldTileOffset;

	private Vector3 _worldPosition;

	private Vector3 _spawnPosition;

	private Quaternion _worldRotation;

	private Quaternion _spawnRotation;

	private int _visualPrefabIndex = -1;

	private PointOfInterestSpawner _pointOfInterestSpawner;

	private FlotsamBehaviour _instance;

	private readonly FlotsamSpawnerEvent _onSpawn = new FlotsamSpawnerEvent();

	public ISpawnerType Type => ISpawnerType.Flotsam;

	public ISpawnerState State { get; private set; } = ISpawnerState.DoNotSpawn;

	public FlotsamBehaviour Instance => _instance;

	public Sprite Icon => null;

	public WorldTile WorldTile => null;

	public Vector3 WorldPosition => _worldPosition;

	public Vector2 WorldPosition2D => _worldPosition.Vector2TopDown();

	public Vector2 TilePosition { get; private set; }

	public Vector3 SpawnPosition => _spawnPosition;

	public bool IsOutOfRange { get; private set; }

	public FlotsamSpawnerEvent OnSalvaged { get; } = new FlotsamSpawnerEvent();

	public FlotsamSpawnerEvent OnOutOfRange { get; } = new FlotsamSpawnerEvent();

	public WorldRegionType RegionType => WorldRegionType.None;

	public ScoutingState ScoutingState => ScoutingState.None;

	public string Name => Properties.name;

	public FlotsamProperties Properties { get; }

	public ISpawnerEvent UpdatedEvent { get; } = new ISpawnerEvent();

	private FlotsamSpawner(FlotsamProperties properties)
	{
		Properties = properties;
	}

	public static FlotsamSpawner CreateFromItemProperties(ItemProperties itemProperties, PointOfInterestSpawner pointOfInterest)
	{
		FlotsamSpawner flotsamSpawner = CreateFromItemProperties(itemProperties);
		flotsamSpawner.InitializePosition(pointOfInterest);
		return flotsamSpawner;
	}

	public static FlotsamSpawner CreateFromItemProperties(ItemProperties itemProperties)
	{
		using ListPool<Item>.List list = ListPool<Item>.Get();
		list.Add(new Item(itemProperties));
		return new FlotsamSpawner(itemProperties.FlotsamProperties)
		{
			_compositionInventory = new CompositionInventory(list),
			IsOutOfRange = true
		};
	}

	public static FlotsamSpawner CreateFromCompositeFlotsamProperties(CompositedFlotsamProperties compositedFlotsamProperties, IEnumerable<CountedItemProperty> composition, PointOfInterestSpawner pointOfInterest)
	{
		FlotsamSpawner flotsamSpawner = CreateFromCompositeFlotsamProperties(compositedFlotsamProperties, composition);
		flotsamSpawner.InitializePosition(pointOfInterest);
		return flotsamSpawner;
	}

	public static FlotsamSpawner CreateFromCompositeFlotsamProperties(CompositedFlotsamProperties compositedFlotsamProperties, IEnumerable<CountedItemProperty> composition = null)
	{
		FlotsamSpawner flotsamSpawner = new FlotsamSpawner(compositedFlotsamProperties)
		{
			_compositionInventory = new CompositionInventory(compositedFlotsamProperties.Composition),
			IsOutOfRange = true
		};
		if (composition == null)
		{
			flotsamSpawner._compositionInventory.Fill(null, compositedFlotsamProperties.Composition);
		}
		else
		{
			flotsamSpawner._compositionInventory.Fill(null, composition);
		}
		return flotsamSpawner;
	}

	public static FlotsamSpawner CreateFromFlotsam(Flotsam flotsam)
	{
		if (flotsam == null)
		{
			return null;
		}
		Vector3 position = flotsam.Position;
		Quaternion rotation = flotsam.transform.rotation;
		return new FlotsamSpawner(flotsam.ReturnProperties())
		{
			_instance = flotsam,
			_compositionInventory = new CompositionInventory(flotsam.Inventory.ReturnAllItems()),
			_worldPosition = position,
			_worldRotation = rotation,
			_spawnPosition = position,
			_spawnRotation = rotation,
			IsOutOfRange = false,
			State = ISpawnerState.Interactable
		};
	}

	public void Initialize()
	{
	}

	private void InitializePosition(PointOfInterestSpawner pointOfInterest)
	{
		if (pointOfInterest == null)
		{
			Debug.LogWarning("Unable to FlotsamSpawner.Initialize because pointOfInterest is 'null'!");
		}
		Vector3 vector = pointOfInterest.ReturnLocalSpawnPosition();
		TilePosition = pointOfInterest.TilePosition + vector.Vector2TopDown();
		_worldPosition = TilePosition.Vector3TopDown() + _worldTileOffset;
		_worldRotation = Quaternion.identity;
		_spawnPosition = pointOfInterest.SpawnPosition + vector;
		_spawnRotation = _worldRotation;
		IsOutOfRange = false;
	}

	public void Reset()
	{
		IsOutOfRange = true;
		_visualPrefabIndex = -1;
	}

	public void Destroy()
	{
		OnSalvaged.RemoveAllListeners();
	}

	public void SetWorldTileOffset(Vector3 offset)
	{
		_worldTileOffset = offset;
		if (!IsOutOfRange)
		{
			_worldPosition += offset;
			_spawnPosition += offset;
		}
	}

	public void Spawn(PointOfInterestSpawner pointOfInterestSpawner)
	{
		_pointOfInterestSpawner = pointOfInterestSpawner;
		if (IsOutOfRange)
		{
			InitializePosition(pointOfInterestSpawner);
		}
		Spawn(pointOfInterestSpawner.State, pointOfInterestSpawner.RootTransform);
	}

	private void Spawn(ISpawnerState state, Transform parent = null)
	{
		if (_compositionInventory.IsEmpty)
		{
			return;
		}
		State = state;
		if (state == ISpawnerState.DoNotSpawn)
		{
			return;
		}
		if (IsInToolMode)
		{
			InstantiateInToolModeCallback(this, _spawnPosition, _pointOfInterestSpawner);
		}
		else if (_instance == null)
		{
			int num = FlotsamPool.Instance.Aquire(out _instance, Properties, _spawnPosition, state == ISpawnerState.Interactable, _visualPrefabIndex);
			if (num != _visualPrefabIndex)
			{
				_visualPrefabIndex = num;
				_spawnRotation = (_worldRotation = Properties.ReturnVisualPrefabRotation(_visualPrefabIndex));
			}
			_instance.InitializeComposition(_compositionInventory);
			_instance.transform.SetParent(parent, worldPositionStays: true);
			_instance.transform.rotation = _spawnRotation;
			_instance.OnSalvage.AddListener(OnSalvage);
			if (_onSpawn != null)
			{
				_onSpawn.Invoke(this);
			}
		}
	}

	public bool Despawn(bool destroyInstance)
	{
		if (_instance == null)
		{
			return false;
		}
		_instance.OnSalvage.RemoveListener(OnSalvage);
		if (_compositionInventory.IsEmpty)
		{
			if (_instance.Pooled)
			{
				_instance = null;
				return true;
			}
			Debug.LogWarning("FlotsamSpawner has a reference to a flotsam instance, but the composition is empty!");
		}
		if (destroyInstance)
		{
			UnityEngine.Object.Destroy(_instance);
		}
		else
		{
			FlotsamPool.Instance.Release(_instance);
			_instance = null;
		}
		return true;
	}

	public void Move(Vector3 movement)
	{
		if (IsOutOfRange)
		{
			Debug.LogError("FlotsamSpawner position cannot be moved when the position has not been initialized!");
			return;
		}
		_spawnPosition += movement;
		ApplyPositionAndRotation();
	}

	public void RepositionRelativeToTownheart(Vector3 townheartPosition, Quaternion townheartRotation)
	{
		_spawnPosition = _worldPosition - townheartPosition;
		_spawnPosition = Quaternion.Inverse(townheartRotation) * _spawnPosition;
		_spawnRotation = _worldRotation * Quaternion.Inverse(townheartRotation);
		ApplyPositionAndRotation();
	}

	private void ApplyPositionAndRotation()
	{
		if (_pointOfInterestSpawner == null || State == _pointOfInterestSpawner.State)
		{
			if ((bool)_instance)
			{
				_instance.UpdatePositionAndRotation(_spawnPosition, _spawnRotation);
			}
		}
		else
		{
			Despawn(destroyInstance: false);
		}
	}

	public void CountItems(InventoryAuditor auditor)
	{
		auditor.CountInventory(_compositionInventory);
	}

	public void CountItemsInRange(InventoryAuditor auditor, float range)
	{
		if (_spawnPosition.IsInRange(Vector3.zero, range))
		{
			auditor.CountInventory(_compositionInventory);
		}
	}

	private void OnSalvage()
	{
		OnSalvaged.Invoke(this);
	}
}
