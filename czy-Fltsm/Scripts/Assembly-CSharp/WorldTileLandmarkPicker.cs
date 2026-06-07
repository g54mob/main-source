using System;
using System.Collections.Generic;
using PajamaLlama.Flotsam.World;
using UnityEngine;

public class WorldTileLandmarkPicker : ILandmarkPicker
{
	[Serializable]
	public class WorldTilePickerSettings : ILandmarkPickerSettings
	{
		[SerializeField]
		private WorldTileProviderBase _tileProvider;

		[SerializeField]
		[Tooltip("True: Look for existing tile, spawn otherwise. False: Always spawn a new tile.")]
		private bool _tryExistingTile;

		[SerializeField]
		private WorldRegionType[] _acceptedRegions;

		[SerializeField]
		private ScoutingState _maximumScoutingState;

		public WorldTileProviderBase TileProvider => _tileProvider;

		public bool TryExistingTile => _tryExistingTile;

		public WorldRegionType[] AcceptedRegions => _acceptedRegions;

		public ScoutingState MaximumScoutingState => _maximumScoutingState;

		public void SetOwningQuest(Quest owningQuest)
		{
		}

		public bool Spawn(ILandmarkBehaviourProvider landmarkBehaviourProvider)
		{
			LandmarkSpawner landmarkSpawner;
			return Spawn(out landmarkSpawner, landmarkBehaviourProvider);
		}

		public bool Spawn(out LandmarkSpawner landmarkSpawner, ILandmarkBehaviourProvider landmarkBehaviourProvider)
		{
			if (TryReturnWorld(out var world) && TryGet(out var instance, this) && instance.TryPickLandmark(out landmarkSpawner, world))
			{
				landmarkSpawner.SetLandmarkBehaviour(landmarkBehaviourProvider.ReturnLandmarkBehaviour(landmarkSpawner.Region.Type), null);
				LandmarkNotificationEvent.Spawned(landmarkSpawner);
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
			if (TryReturnWorld(out var world) && TryGet(out var instance, this) && instance.TryPickLandmark(out landmarkSpawner, world))
			{
				LandmarkSpawner obj = landmarkSpawner;
				ILandmarkBehaviourProvider landmarkBehaviourProvider3;
				if (landmarkBehaviourProvider == null)
				{
					ILandmarkBehaviourProvider landmarkBehaviourProvider2 = world.TileProperties.ReturnLandmarkBehaviour(landmarkSpawner.Region);
					landmarkBehaviourProvider3 = landmarkBehaviourProvider2;
				}
				else
				{
					landmarkBehaviourProvider3 = landmarkBehaviourProvider;
				}
				obj.SetActorDescriptor(actorDescriptor, questToAssign, landmarkBehaviourProvider3);
				LandmarkNotificationEvent.Spawned(landmarkSpawner);
				return true;
			}
			landmarkSpawner = null;
			return false;
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

		public bool CanSpawn()
		{
			return true;
		}
	}

	private static WorldTileLandmarkPicker _instance;

	private WorldTilePickerSettings _settings;

	private bool _acceptsAllRegions;

	public LandmarkSpawner BestPick { get; private set; }

	private static bool TryGet(out WorldTileLandmarkPicker instance, WorldTilePickerSettings settings = null)
	{
		if ((bool)GameManager.WorldManager && GameManager.WorldManager.World != null)
		{
			if (_instance == null)
			{
				_instance = new WorldTileLandmarkPicker();
			}
			_instance._settings = settings;
		}
		instance = _instance;
		return instance != null;
	}

	public bool CanPickFrom(TileGeneratorBase tileGeneratorBase)
	{
		return _settings.TileProvider.Contains(tileGeneratorBase);
	}

	public bool SkipRegion(IWorldRegion region)
	{
		if (_acceptsAllRegions || _settings.AcceptedRegions.Contains(region.Type))
		{
			return !_settings.TileProvider.Contains(region.WorldTile);
		}
		return true;
	}

	public bool SetBestPick(LandmarkSpawner spawner)
	{
		throw new NotImplementedException();
	}

	public bool IsBetterPick(LandmarkSpawner spawner)
	{
		throw new NotImplementedException();
	}

	public bool ConfirmBestPick(LandmarkSpawner spawner)
	{
		throw new NotImplementedException();
	}

	public bool TryGetNextWorldTile(out WorldTile worldTile, World world)
	{
		worldTile = null;
		if (_settings.TileProvider != null)
		{
			worldTile = _settings.TileProvider.GetNextWorldTile(world);
			if (worldTile == null)
			{
				Debug.LogException(new Exception($"WorldTileLandmarkPicker could not GetNextWorldTile from TileProvider {_settings.TileProvider}"));
			}
		}
		return worldTile != null;
	}

	private bool TryPickLandmark(out LandmarkSpawner landmarkSpawner, World world)
	{
		landmarkSpawner = null;
		if (TryPickFromExistingWorldTile(out landmarkSpawner, world))
		{
			return true;
		}
		WorldTile nextWorldTile = _settings.TileProvider.GetNextWorldTile(world);
		world.AddNextTile(nextWorldTile, synchronous: true);
		using ListPool<LandmarkSpawner>.List list = ListPool<LandmarkSpawner>.Get();
		PopulateDisabledLandmarks(nextWorldTile, list, _settings.MaximumScoutingState);
		if (0 < list.Count)
		{
			landmarkSpawner = list.GetRandom();
			return true;
		}
		Debug.LogException(new Exception("WorldTileLandmarkPicker was unable to spawn landmark!"));
		return false;
	}

	private bool TryPickFromExistingWorldTile(out LandmarkSpawner landmarkSpawner, World world)
	{
		landmarkSpawner = null;
		if (!_settings.TryExistingTile)
		{
			return false;
		}
		using ListPool<LandmarkSpawner>.List list = ListPool<LandmarkSpawner>.Get();
		foreach (WorldTile tile in world.Tiles)
		{
			PopulateDisabledLandmarks(tile, list, _settings.MaximumScoutingState);
		}
		if (list.Count == 0)
		{
			return false;
		}
		landmarkSpawner = list.GetRandom();
		return true;
	}

	private void PopulateDisabledLandmarks(WorldTile tile, List<LandmarkSpawner> landmarks, ScoutingState maximumScoutingState)
	{
		if (!_settings.TileProvider.Contains(tile))
		{
			return;
		}
		foreach (IWorldRegion region in tile.Regions)
		{
			if (!SkipRegion(region))
			{
				region.PopulateDisabledLandmarkSpawners(landmarks, ScoutingState.None);
			}
		}
	}
}
