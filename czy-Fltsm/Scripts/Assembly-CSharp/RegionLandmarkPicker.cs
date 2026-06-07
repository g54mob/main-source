using System;
using System.Collections.Generic;
using PajamaLlama.Flotsam.Narrative;
using PajamaLlama.Flotsam.World;
using PajamaLlama.Math;
using UnityEngine;
using UnityEngine.Serialization;

public class RegionLandmarkPicker : ILandmarkPicker
{
	public enum RegionMode
	{
		CurrentRegion = 0,
		CurrentRegionNeighbor = 1,
		CurrentRegionOrNeighbor = 2,
		RegionTriggers = 3,
		LandmarkVariableRegion = 4,
		TileRegion = 5
	}

	public enum PickingMode
	{
		FirstInList = 0,
		ClosestToTown = 1,
		FurthestFromTown = 2,
		FurthestEast = 3,
		Random = 16
	}

	[Serializable]
	public class Region : ILandmarkPickerSettings
	{
		[SerializeField]
		[HideInInspector]
		private string _name = "Region";

		[SerializeField]
		private WorldRegionType[] _acceptedRegions = new WorldRegionType[1] { WorldRegionType.Any };

		[Tooltip("If a region has any of these flags set it will be excluded, if no flags are set no region will be excluded base on their flags.")]
		[SerializeField]
		private WorldRegionFlags _regionExcludeFlags;

		[SerializeField]
		[FormerlySerializedAs("_mode")]
		private RegionMode _regionMode;

		[SerializeField]
		[ConditionalEnumHide("_regionMode", 4, true)]
		[QuestVariable(QuestVariableType.Landmark)]
		private int _landmarkVariable;

		[SerializeField]
		private PickingMode _pickingMode;

		[Header("Landmarks")]
		[SerializeField]
		[Tooltip("The maximum scouting state a picked landmark is allowed to have.")]
		private ScoutingState _maximumScoutingState = ScoutingState.Scouted;

		[Header("Validation")]
		[SerializeField]
		[Min(1f)]
		[Tooltip("When multiple landmarks are spawned by a single quest this value should reflect that amount of landmarks")]
		private int _spawnCount = 1;

		[NonSerialized]
		private Quest _owningQuest;

		public RegionMode RegionMode => _regionMode;

		public int LandmarkVariable => _landmarkVariable;

		public WorldRegionFlags RegionExcludeFlags => _regionExcludeFlags;

		public PickingMode PickingMode => _pickingMode;

		public ScoutingState MaximumScoutingState => _maximumScoutingState;

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
			if (TryReturnWorld(out var world) && TryGet(out var instance, this) && instance.PickLandmark(out landmarkSpawner, this, world))
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
			if (TryReturnWorld(out var world) && TryGet(out var instance, this) && instance.PickLandmark(out landmarkSpawner, this, world))
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

		private void PopulateAcceptedRegions(List<IWorldRegion> acceptedRegions, World world)
		{
			IWorldRegion region = null;
			IWorldRegion region2;
			switch (RegionMode)
			{
			case RegionMode.CurrentRegion:
				if (WorldManager.TryReturnCurrentRegion(out region) && AcceptsRegion(region))
				{
					acceptedRegions.Add(region);
				}
				break;
			case RegionMode.CurrentRegionNeighbor:
				if (WorldManager.TryReturnCurrentRegion(out region2))
				{
					PopulateAcceptedRegions(acceptedRegions, region2.Neighbors);
				}
				break;
			case RegionMode.CurrentRegionOrNeighbor:
				if (WorldManager.TryReturnCurrentRegion(out region2))
				{
					using (ListPool<IWorldRegion>.List list = ListPool<IWorldRegion>.Get())
					{
						list.Add(region2);
						list.AddRange(region2.Neighbors);
						PopulateAcceptedRegions(acceptedRegions, list);
						break;
					}
				}
				break;
			case RegionMode.RegionTriggers:
				PopulateAcceptedRegions(acceptedRegions, RegionTriggers.Regions);
				break;
			case RegionMode.TileRegion:
				if (WorldManager.TryReturnCurrentRegion(out region2))
				{
					PopulateAcceptedRegions(acceptedRegions, region2.WorldTile.Regions);
				}
				break;
			case RegionMode.LandmarkVariableRegion:
				if (TryReturnLandmarkVariableRegion(out region))
				{
					acceptedRegions.Add(region);
				}
				break;
			default:
				Debug.LogException(new NotImplementedException());
				break;
			}
		}

		private void PopulateAcceptedRegions(List<IWorldRegion> acceptedRegions, IEnumerable<IWorldRegion> regions)
		{
			foreach (IWorldRegion region in regions)
			{
				if (AcceptsRegion(region))
				{
					acceptedRegions.Add(region);
				}
			}
		}

		public bool AcceptsRegion(IWorldRegion region)
		{
			if ((_acceptedRegions.Contains(WorldRegionType.Any) || _acceptedRegions.Contains(region.Type)) && (region.Flags & _regionExcludeFlags) == 0)
			{
				return region.HasUnscoutedDisabledLandmarks();
			}
			return false;
		}

		public bool TryReturnLandmarkVariableRegion(out IWorldRegion region)
		{
			region = null;
			if (_owningQuest == null)
			{
				Debug.LogException(new Exception("Unable to use QuestVariables for landmark picking before SetOwningQuest"));
				return false;
			}
			if (_owningQuest.TryGetVariableValue<LandmarkSpawner>(_landmarkVariable, out var value))
			{
				region = value.Region;
				return true;
			}
			return false;
		}

		public ListPool<LandmarkSpawner>.List ReturnLandmarkSpawners(World world)
		{
			using ListPool<IWorldRegion>.List list = ListPool<IWorldRegion>.Get();
			PopulateAcceptedRegions(list, world);
			ListPool<LandmarkSpawner>.List list2 = ListPool<LandmarkSpawner>.Get();
			foreach (IWorldRegion item in list)
			{
				item.PopulateDisabledLandmarkSpawners(list2, MaximumScoutingState);
			}
			return list2;
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
			if (!TryReturnWorld(out var world))
			{
				return false;
			}
			using ListPool<LandmarkSpawner>.List list = ReturnLandmarkSpawners(world);
			return _spawnCount <= list.Count;
		}
	}

	private static RegionLandmarkPicker _instance;

	private Region _settings;

	private Vector2 _townheart;

	private LandmarkSpawner _bestPickPendingConfirmation;

	public LandmarkSpawner BestPick { get; private set; }

	private RegionLandmarkPicker()
	{
	}

	private static bool TryGet(out RegionLandmarkPicker instance, Region settings)
	{
		if ((bool)GameManager.WorldManager && GameManager.WorldManager.World != null && _instance == null)
		{
			_instance = new RegionLandmarkPicker();
		}
		instance = _instance;
		return instance != null;
	}

	private bool PickLandmark(out LandmarkSpawner landmarkSpawner, Region settings, World world)
	{
		_settings = settings;
		_townheart = world.TownheartMapPosition;
		landmarkSpawner = null;
		using ListPool<LandmarkSpawner>.List list = _settings.ReturnLandmarkSpawners(world);
		if (list.Count == 0)
		{
			Debug.LogException(new Exception("No disabled landmark spawners were present in accepted regions"));
			return false;
		}
		switch (_settings.PickingMode)
		{
		case PickingMode.ClosestToTown:
			Sorting.SlowSort(list, SortClosestToTown);
			goto case PickingMode.FirstInList;
		case PickingMode.FurthestFromTown:
			Sorting.SlowSort(list, SortFurthestFromTown);
			goto case PickingMode.FirstInList;
		case PickingMode.FurthestEast:
			Sorting.SlowSort(list, SortFurthestEast);
			goto case PickingMode.FirstInList;
		case PickingMode.FirstInList:
			landmarkSpawner = list[0];
			break;
		default:
			landmarkSpawner = list.GetRandom();
			break;
		}
		return true;
	}

	public bool CanPickFrom(TileGeneratorBase tileGeneratorBase)
	{
		return false;
	}

	public bool SkipRegion(IWorldRegion region)
	{
		return false;
	}

	public bool SetBestPick(LandmarkSpawner spawner)
	{
		if (IsBestPick(spawner))
		{
			BestPick = spawner;
			return true;
		}
		return false;
	}

	public bool IsBetterPick(LandmarkSpawner spawner)
	{
		if (IsBestPick(spawner))
		{
			_bestPickPendingConfirmation = spawner;
			return true;
		}
		return false;
	}

	public bool ConfirmBestPick(LandmarkSpawner spawner)
	{
		if (_bestPickPendingConfirmation == spawner)
		{
			BestPick = spawner;
			return true;
		}
		return false;
	}

	public bool TryGetNextWorldTile(out WorldTile worldTile, World world)
	{
		worldTile = null;
		return false;
	}

	private bool IsBestPick(LandmarkSpawner spawner)
	{
		return false;
	}

	public int SortClosestToTown(LandmarkSpawner lhs, LandmarkSpawner rhs)
	{
		return (int)(_townheart.DistanceToSquared(lhs.WorldPosition2D) - _townheart.DistanceToSquared(rhs.WorldPosition2D));
	}

	public int SortFurthestFromTown(LandmarkSpawner lhs, LandmarkSpawner rhs)
	{
		return (int)(_townheart.DistanceToSquared(rhs.WorldPosition2D) - _townheart.DistanceToSquared(lhs.WorldPosition2D));
	}

	public int SortFurthestEast(LandmarkSpawner lhs, LandmarkSpawner rhs)
	{
		return (int)(rhs.WorldPosition2D.x - lhs.WorldPosition2D.x);
	}
}
