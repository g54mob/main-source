using System;
using PajamaLlama.Flotsam.Narrative;
using PajamaLlama.Flotsam.World;
using PajamaLlama.Math;
using UnityEngine;

public class LandmarkPicker : ILandmarkPicker
{
	[Serializable]
	public class Settings : ILandmarkPickerSettings
	{
		public enum ReferencePoint
		{
			TownheartX = 0,
			TownheartMaxX = 1,
			LandmarkVariableX = 2
		}

		[SerializeField]
		private ReferencePoint _referencePoint;

		[SerializeField]
		[ConditionalEnumHide("_referencePoint", 2, true)]
		[QuestVariable(QuestVariableType.Landmark)]
		private int _landmarkVariable;

		[SerializeField]
		private float _desiredDistanceX = 2000f;

		[SerializeField]
		private float _minimumDistanceX = 1000f;

		[SerializeField]
		private WorldRegionType[] _acceptedRegions;

		[SerializeField]
		private bool _onlyRegionsWithScoutingLandmark;

		[SerializeField]
		private WorldTileProviderBase _worldTileProvider;

		private static Settings _instance;

		[NonSerialized]
		private Quest _owningQuest;

		public float DesiredDistanceX => _desiredDistanceX;

		public float MinimumDistanceX => _minimumDistanceX;

		public WorldRegionType[] AcceptedRegions => _acceptedRegions;

		public bool OnlyRegionsWithScoutingLandmark => _onlyRegionsWithScoutingLandmark;

		public static Settings Get(float desiredDistanceX, float minimumDistanceX, params WorldRegionType[] acceptedRegions)
		{
			if (_instance == null)
			{
				_instance = new Settings();
			}
			_instance._desiredDistanceX = desiredDistanceX;
			_instance._minimumDistanceX = minimumDistanceX;
			_instance._acceptedRegions = acceptedRegions;
			return _instance;
		}

		public void SetOwningQuest(Quest owningQuest)
		{
			_owningQuest = owningQuest;
		}

		public bool Spawn(ILandmarkBehaviourProvider landmarkBehaviourProvider)
		{
			LandmarkSpawner landmarkSpawner;
			return Spawn(out landmarkSpawner, landmarkBehaviourProvider);
		}

		public bool Spawn(out LandmarkSpawner landmarkSpawner, ILandmarkBehaviourProvider landmarkBehaviourProvider)
		{
			if (TryReturnWorld(out var world) && TryGet(out var instance, this) && world.SpawnLandmark(instance, landmarkBehaviourProvider))
			{
				landmarkSpawner = instance.BestPick;
				return true;
			}
			landmarkSpawner = null;
			return false;
		}

		public bool SpawnDrifter(ActorDescriptor actorDescriptor, QuestProperties questToAssign = null, ILandmarkBehaviourProvider landmarkBehaviourProvider = null)
		{
			LandmarkSpawner landmarkSpawner;
			return SpawnDrifter(out landmarkSpawner, actorDescriptor, questToAssign, landmarkBehaviourProvider);
		}

		public bool SpawnDrifter(out LandmarkSpawner landmarkSpawner, ActorDescriptor actorDescriptor, QuestProperties questToAssign = null, ILandmarkBehaviourProvider landmarkBehaviourProvider = null)
		{
			if (TryReturnWorld(out var world) && TryGet(out var instance, this) && world.SpawnDrifter(instance, actorDescriptor, questToAssign, landmarkBehaviourProvider))
			{
				landmarkSpawner = instance.BestPick;
				return true;
			}
			landmarkSpawner = null;
			return false;
		}

		public WorldTile GetNextWorldTile(World world)
		{
			if ((bool)_worldTileProvider)
			{
				WorldTile nextWorldTile = _worldTileProvider.GetNextWorldTile(world);
				if (nextWorldTile == null)
				{
					Debug.LogException(new Exception($"LandmarkPicker could ne GetNextWorldTile from WorldTileProvider '{_worldTileProvider}'"));
				}
				return nextWorldTile;
			}
			return null;
		}

		public Vector3 ReturnReferencePosition(World world)
		{
			switch (_referencePoint)
			{
			case ReferencePoint.TownheartX:
				return world.TownheartWorldPosition;
			case ReferencePoint.TownheartMaxX:
				return new Vector3(world.TownheartMaxX, world.TownheartWorldPosition.y, 0f);
			case ReferencePoint.LandmarkVariableX:
			{
				if (_owningQuest.TryGetVariableValue<LandmarkSpawner>(_landmarkVariable, out var value))
				{
					return value.WorldPosition;
				}
				Debug.LogException(new Exception("Unable to return landmark variable world position X, falling back on townheart max X"));
				goto case ReferencePoint.TownheartMaxX;
			}
			default:
				Debug.LogException(new NotImplementedException("Fallingback on townheart max X"));
				goto case ReferencePoint.TownheartMaxX;
			}
		}

		private bool TryReturnWorld(out World world)
		{
			if ((bool)GameManager.WorldManager && GameManager.WorldManager.World != null)
			{
				world = GameManager.WorldManager.World;
				return true;
			}
			world = null;
			return false;
		}

		public bool SkipRegion(IWorldRegion region)
		{
			if (_worldTileProvider != null)
			{
				return !_worldTileProvider.Contains(region.WorldTile.SubTileGeneratorPrefab);
			}
			return false;
		}

		public bool CanSpawn()
		{
			Debug.LogException(new NotImplementedException());
			return true;
		}
	}

	public delegate bool Condition(LandmarkSpawner spawner);

	private static LandmarkPicker _instance;

	private Settings _settings;

	private WorldRegionType[] _acceptedRegions;

	private bool _acceptsAllRegions;

	private bool _onlyRegionsWithScoutingLandmark;

	private Vector2 _townheart;

	private float _desiredX;

	private float _minimumX;

	private float _bestPickDistanceX;

	private float _bestPickPendingConfirmationDistanceX;

	private ISpawner _bestPickPendingConfirmation;

	public LandmarkSpawner BestPick { get; private set; }

	public ScoutingState MaximumScoutingState => ScoutingState.Selected;

	public float MinimumX => _minimumX;

	private LandmarkPicker()
	{
	}

	private static bool TryGet(out ILandmarkPicker instance, Settings settings = null)
	{
		if ((bool)GameManager.WorldManager && GameManager.WorldManager.World != null)
		{
			if (_instance == null)
			{
				_instance = new LandmarkPicker();
			}
			_instance.Initialize(GameManager.WorldManager.World, settings);
		}
		instance = _instance;
		return instance != null;
	}

	public void Initialize(World world, Settings settings)
	{
		_settings = settings;
		_townheart = world.TownheartWorldPosition.Vector2TopDown();
		_bestPickDistanceX = float.MaxValue;
		if (_settings == null)
		{
			_acceptedRegions = null;
			_onlyRegionsWithScoutingLandmark = false;
			_desiredX = world.TownheartMaxX + 2000f;
			_minimumX = world.TownheartMaxX + 1000f;
		}
		else
		{
			_acceptedRegions = ((world.TileProperties.GameMode == GameMode.Classic) ? null : _settings.AcceptedRegions);
			_onlyRegionsWithScoutingLandmark = _settings.OnlyRegionsWithScoutingLandmark;
			Vector3 vector = _settings.ReturnReferencePosition(world);
			_minimumX = vector.x + _settings.MinimumDistanceX;
			_desiredX = vector.x + _settings.DesiredDistanceX;
		}
		_acceptsAllRegions = _acceptedRegions.IsNullOrEmpty();
		BestPick = null;
	}

	public void Reset()
	{
		_settings = null;
	}

	public bool CanPickFrom(TileGeneratorBase subTileGenerator)
	{
		return subTileGenerator.HasRegionOfType(_settings.AcceptedRegions);
	}

	public bool SkipRegion(IWorldRegion region)
	{
		if ((_acceptsAllRegions || _acceptedRegions.Contains(region.Type)) && (!_onlyRegionsWithScoutingLandmark || region.TryReturnScoutingLandmark(out var _)))
		{
			return _settings.SkipRegion(region);
		}
		return true;
	}

	public bool SkipLandmark(ISpawner spawner)
	{
		return spawner.WorldPosition2D.x < _minimumX;
	}

	public bool SetBestPick(LandmarkSpawner spawner)
	{
		if (IsBestPick(spawner, _bestPickDistanceX, out var distanceToDesiredX))
		{
			BestPick = spawner;
			_bestPickDistanceX = distanceToDesiredX;
			return true;
		}
		return false;
	}

	public bool IsBetterPick(LandmarkSpawner spawner)
	{
		if (IsBestPick(spawner, _bestPickDistanceX, out var distanceToDesiredX))
		{
			_bestPickPendingConfirmation = spawner;
			_bestPickPendingConfirmationDistanceX = distanceToDesiredX;
			return true;
		}
		return false;
	}

	public bool ConfirmBestPick(LandmarkSpawner spawner)
	{
		if (_bestPickPendingConfirmation == spawner)
		{
			BestPick = spawner;
			_bestPickDistanceX = _bestPickPendingConfirmationDistanceX;
			return true;
		}
		return false;
	}

	public bool TryGetNextWorldTile(out WorldTile worldTile, World world)
	{
		worldTile = _settings.GetNextWorldTile(world);
		return worldTile != null;
	}

	private bool IsBestPick(ISpawner spawner, float mostDesireableDistanceX, out float distanceToDesiredX)
	{
		distanceToDesiredX = Mathf.Abs(spawner.WorldPosition2D.x - _desiredX);
		if ((_acceptsAllRegions || _acceptedRegions.Contains(spawner.RegionType)) && distanceToDesiredX < _bestPickDistanceX)
		{
			return _minimumX < spawner.WorldPosition2D.x;
		}
		return false;
	}
}
