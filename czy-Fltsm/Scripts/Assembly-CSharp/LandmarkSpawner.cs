using System;
using System.Collections.Generic;
using PajamaLlama.Flotsam.World;
using PajamaLlama.Math;
using PajamaLlama.Persistence;
using UnityEngine;

public class LandmarkSpawner : ISpawner, IWorldMapCompassBearingTarget
{
	[Serializable]
	public struct PersistentReference
	{
		private int _tileIndex;

		private int _spawnerIndex;

		private Vector2 _tilePosition;

		public PersistentReference(int tileIndex, int spawnerIndex, Vector2 tilePosition)
		{
			_tileIndex = tileIndex;
			_spawnerIndex = spawnerIndex;
			_tilePosition = tilePosition;
		}

		public bool TryGet(out LandmarkSpawner landmarkSpawner)
		{
			return WorldManager.TryReturnLandmarkSpawner(out landmarkSpawner, _tileIndex, _spawnerIndex);
		}
	}

	private Vector3 _worldTileOffset = Vector3.zero;

	private Vector3 _spawnPosition;

	private Quaternion _spawnRotation;

	private Polygon _prefabPolygon;

	private Sprite _bearingIconOverride;

	public ISpawnerType Type => ISpawnerType.Landmark;

	public bool Enabled => LandmarkBehaviour;

	public Sprite Icon => LandmarkBehaviour._uiIcon;

	public WorldTile WorldTile => Region.WorldTile;

	public Vector2 WorldPosition2D { get; private set; }

	public Vector2 TilePosition { get; private set; }

	internal HandmadeTileGenerator.Landmark LandmarkData { get; private set; }

	public LandmarkBehaviour LandmarkBehaviour { get; private set; }

	public LandmarkPersistentData PersistentData { get; private set; }

	public Vector3 WorldPosition { get; private set; }

	public Vector3 SpawnPosition => _spawnPosition;

	public Quaternion Rotation { get; private set; }

	public IWorldRegion Region { get; private set; }

	public WorldRegionType RegionType { get; private set; }

	public ScoutingState ScoutingState { get; private set; }

	public WorldMapScoutingId ScoutingId
	{
		get
		{
			if (!(LandmarkBehaviour == null))
			{
				return LandmarkBehaviour.ScoutingId;
			}
			return WorldMapScoutingId.None;
		}
	}

	public string Name => LandmarkBehaviour.Name;

	public Polygon TileSpacePolygon { get; private set; }

	public Sprite BearingIcon => GetBearingIcon();

	public BearingFeatures BearingFeatures { get; private set; }

	public BearingIconType BearingIconOverride { get; private set; }

	public ISpawnerEvent UpdatedEvent { get; private set; } = new ISpawnerEvent();

	public LandmarkSpawner(LandmarkBehaviour landmarkBehaviour, Vector3 tilePosition, bool hasBearing = false)
		: this(landmarkBehaviour, tilePosition, Quaternion.AngleAxis(UnityEngine.Random.Range(0, 360), Vector3.up))
	{
		if (hasBearing)
		{
			SetScoutingState(ScoutingState.Scouted);
		}
	}

	public LandmarkSpawner(LandmarkBehaviour landmarkBehaviour, Vector3 tilePosition, Quaternion rotation)
		: this(tilePosition, rotation)
	{
		if ((bool)landmarkBehaviour && (WorldManager.GameMode != GameMode.Narrative || !landmarkBehaviour.ReturnHasLandmarkActionReference<LandmarkActionRescue>()))
		{
			SetLandmarkBehaviour(landmarkBehaviour, null);
		}
	}

	public LandmarkSpawner(LandmarkBehaviour landmarkBehaviour, Vector3 tilePosition, Quaternion rotation, LandmarkPersistentData persistentData)
		: this(tilePosition, rotation)
	{
		if ((bool)landmarkBehaviour)
		{
			SetLandmarkBehaviour(landmarkBehaviour, persistentData);
		}
	}

	internal LandmarkSpawner(HandmadeTileGenerator.Landmark landmarkData, Vector3 tilePosition, Quaternion rotation)
		: this(tilePosition, rotation)
	{
		LandmarkData = landmarkData;
	}

	private LandmarkSpawner(Vector3 tilePosition, Quaternion rotation)
	{
		WorldPosition = (_spawnPosition = tilePosition);
		TilePosition = (WorldPosition2D = tilePosition.Vector2TopDown());
		Rotation = (_spawnRotation = rotation);
	}

	public void Initialize()
	{
		throw new NotImplementedException();
	}

	public void SetLandmarkBehaviour(LandmarkBehaviour landmarkBehaviour, LandmarkPersistentData persistentData)
	{
		LandmarkBehaviour = landmarkBehaviour.ReturnInstance();
		if ((bool)GameManager.WorldManager)
		{
			LandmarkBehaviour.Initialize();
			if (persistentData != null)
			{
				LandmarkBehaviour.Restore(persistentData);
			}
		}
		if (TryReturnPrefabPolygon(out var prefabPolygon))
		{
			TileSpacePolygon = new Polygon(prefabPolygon, TilePosition.Vector3TopDown(), Rotation);
		}
		PersistentData = persistentData;
	}

	public bool SetActorDescriptor(ActorDescriptor descriptor, QuestProperties questToAssign, ILandmarkBehaviourProvider landmarkBehaviourProvider)
	{
		if (landmarkBehaviourProvider != null)
		{
			SetLandmarkBehaviour(landmarkBehaviourProvider.ReturnLandmarkBehaviour(Region.Type), null);
		}
		if (LandmarkBehaviour is ActionsBehaviour actionsBehaviour && actionsBehaviour.TryReturnAction<LandmarkActionRescue>(out var action, false))
		{
			action.AddDescriptor(descriptor);
			if ((bool)questToAssign)
			{
				action.AssignDrifterQuest(questToAssign);
			}
			return true;
		}
		return false;
	}

	public void SetWorldTileOffset(Vector3 offset)
	{
		_worldTileOffset = offset;
		WorldPosition += offset;
		_spawnPosition = WorldPosition;
		WorldPosition2D = WorldPosition.Vector2TopDown();
	}

	public void SetRegion(IWorldRegion region)
	{
		Region = region;
		RegionType = region.Type;
	}

	public void ApplyScoutingState()
	{
		ScoutingState scoutingState = ScoutingState;
		ScoutingState = ScoutingState.None;
		SetScoutingState(scoutingState);
	}

	public void SetScoutingState(ScoutingState scoutingState)
	{
		SetScoutingState(scoutingState, setBearingActive: false);
	}

	public void SetScoutingState(ScoutingState scoutingState, bool setBearingActive)
	{
		if (ScoutingState < scoutingState)
		{
			ScoutingState = scoutingState;
			UpdatedEvent.Invoke(this);
		}
		else if (scoutingState < ScoutingState)
		{
			Debug.LogWarningFormat("Trying to lower scouting state for for landmark '{0}'! This is not supported!", LandmarkBehaviour ? LandmarkBehaviour.name : "NULL");
		}
		if (setBearingActive)
		{
			SetBearingActive(active: true);
		}
	}

	public void SetBearingActive(bool active)
	{
		if (active)
		{
			if (!(LandmarkBehaviour is ActionsBehaviour actionsBehaviour))
			{
				return;
			}
			LandmarkActionSalvage action2;
			if (ScoutingId.IsFlagSet(WorldMapScoutingId.Drifter) || ScoutingId.IsFlagSet(WorldMapScoutingId.Seagull))
			{
				if (actionsBehaviour.TryReturnAction<LandmarkActionRescue>(out var action, false) && !action.IsCompleted)
				{
					SetBearingFeatures(BearingFeatures.Compass | BearingFeatures.Marker);
				}
			}
			else if (ScoutingId.IsFlagSet(WorldMapScoutingId.Cache) && actionsBehaviour.TryReturnAction<LandmarkActionSalvage>(out action2, false) && !action2.ReturnHasCompletedCategory())
			{
				SetBearingFeatures(BearingFeatures.Compass | BearingFeatures.Marker);
			}
		}
		else
		{
			SetBearingFeatures(BearingFeatures.None);
		}
	}

	public void ClearFogOfWar()
	{
		WorldManager.ClearFogOfWar(this);
	}

	public void Dispose()
	{
		SetBearingFeatures(BearingFeatures.None);
		Despawn(destroyInstance: false);
		Region?.RemoveLandmarkSpawner(this);
		LandmarkNotificationEvent.Disposed(this);
	}

	public bool Despawn(bool destroyInstance)
	{
		if (LandmarkPersistentData.TryReturnLandmarkPersistentData(out var data, LandmarkBehaviour))
		{
			PersistentData = data;
		}
		if ((bool)LandmarkBehaviour)
		{
			LandmarkBehaviour.DestroyLandmark();
		}
		GameEventDispatcher.RemoveListener(GameEventType.LandmarkSelected, OnLandmarkSelected);
		return true;
	}

	public void Spawn(Transform parent)
	{
		if (!Enabled || (bool)LandmarkBehaviour.Landmark || !GameManager.WorldManager.IsInSpawnRadius(_spawnPosition))
		{
			return;
		}
		if (PersistentData == null)
		{
			LandmarkBehaviour.SpawnLandmark(_spawnPosition, _spawnRotation, parent);
		}
		else
		{
			PersistentData.RestoreLandmark(LandmarkBehaviour, _spawnPosition, _spawnRotation, parent);
			if (PersistenceLifeCycle.State == PersistenceState.None)
			{
				PersistentData.RestoreReferences();
			}
		}
		LandmarkBehaviour.OnLandmarkSpawnedOrRestored();
		GameEventDispatcher.AddListener(GameEventType.LandmarkSelected, OnLandmarkSelected);
	}

	public void Move(Vector3 movement)
	{
		_spawnPosition += movement;
		ApplyPositionAndRotation();
	}

	public void RepositionRelativeToTownheart(Vector3 townheartPosition, Quaternion townheartRotation)
	{
		_spawnPosition = WorldPosition - townheartPosition;
		_spawnPosition = Quaternion.Inverse(townheartRotation) * _spawnPosition;
		_spawnRotation = Rotation * Quaternion.Inverse(townheartRotation);
		ApplyPositionAndRotation();
	}

	private void ApplyPositionAndRotation()
	{
		if (!(LandmarkBehaviour == null))
		{
			if (GameManager.WorldManager.IsInSpawnRadius(_spawnPosition))
			{
				LandmarkBehaviour.SetPositionAndRotation(_spawnPosition, _spawnRotation);
			}
			else if ((bool)LandmarkBehaviour.Landmark)
			{
				Despawn(destroyInstance: false);
			}
		}
	}

	public void CountItems(InventoryAuditor auditor)
	{
		if ((bool)LandmarkBehaviour)
		{
			LandmarkBehaviour.CountItems(auditor);
		}
	}

	public void PopulateWorldSpaceOutlineVertices(List<Vector2> vertices)
	{
		if (!TryReturnPrefabPolygon(out var prefabPolygon))
		{
			Debug.LogError("Unable to populate world space outline vertices");
		}
		else
		{
			prefabPolygon.PopulateTransformedVertices(vertices, WorldPosition2D.Vector3TopDown(), Rotation);
		}
	}

	public void SetBearingFeatures(BearingFeatures bearingFeatures, BearingIconType _iconOverride = BearingIconType.None)
	{
		if (BearingFeatures == BearingFeatures.Disabled)
		{
			if (bearingFeatures != BearingFeatures.Disabled)
			{
				Debug.LogException(new NotSupportedException($"Trying to set BearingFeatures '{bearingFeatures}' on landmark '{LandmarkBehaviour}' for which bearings are Disabled."));
			}
		}
		else
		{
			BearingFeatures = bearingFeatures;
			BearingIconOverride = _iconOverride;
			_bearingIconOverride = GameManager.Settings.LandmarkSettings.ReturnBearingIcon(BearingIconOverride);
			MapEvent.DispatchCompassBearingTargetEvent(this);
		}
	}

	private void OnLandmarkSelected(GameEvent gameEvent)
	{
		if (gameEvent is LandmarkNotificationEvent landmarkNotificationEvent && landmarkNotificationEvent.LandmarkBehaviour == LandmarkBehaviour)
		{
			SetBearingFeatures(BearingFeatures.Disabled);
		}
	}

	public bool IsInSpawnRadius()
	{
		return GameManager.WorldManager.IsInSpawnRadius(_spawnPosition);
	}

	public bool IsBearingActive()
	{
		return BearingFeatures != BearingFeatures.None;
	}

	public bool IsBearingTo(WorldMapScoutingId scoutingId)
	{
		if (IsBearingActive())
		{
			return (LandmarkBehaviour.ScoutingId & scoutingId) != 0;
		}
		return false;
	}

	public bool IsBearingTo(ISpawner spawner)
	{
		return spawner == this;
	}

	private Sprite GetBearingIcon()
	{
		if ((bool)_bearingIconOverride)
		{
			return _bearingIconOverride;
		}
		if (LandmarkBehaviour != null)
		{
			return LandmarkBehaviour.ReturnBearingIcon();
		}
		return null;
	}

	public bool MatchesScoutingFilter(WorldMapScoutingId filter)
	{
		if ((bool)LandmarkBehaviour)
		{
			return LandmarkBehaviour.ReturnMatchesScoutingFilter(filter);
		}
		return false;
	}

	private bool TryReturnPrefabPolygon(out Polygon prefabPolygon)
	{
		prefabPolygon = _prefabPolygon;
		if (prefabPolygon != null)
		{
			return true;
		}
		if (LandmarkBehaviour == null)
		{
			return false;
		}
		IPolygonProvider componentInChildren = LandmarkBehaviour.LandmarkPrefabGameObject.GetComponentInChildren<IPolygonProvider>();
		if (componentInChildren == null)
		{
			if (LandmarkBehaviour.LandmarkPrefabGameObject.TryGetComponent<Obstacle>(out var component))
			{
				_prefabPolygon = component.Polygon;
			}
			else
			{
				Debug.LogException(new Exception("Unable to return Landmark prefab Polygon."));
			}
		}
		else
		{
			_prefabPolygon = componentInChildren.Polygon;
		}
		prefabPolygon = _prefabPolygon;
		return prefabPolygon != null;
	}

	public PersistentReference GetPersistentReference()
	{
		return new PersistentReference(Region.WorldTile.Index, Region.WorldTile.ReturnLandmarkIndex(LandmarkBehaviour), TilePosition);
	}
}
