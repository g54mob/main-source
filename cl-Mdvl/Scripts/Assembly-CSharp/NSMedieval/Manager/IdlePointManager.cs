using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using NSEipix;
using NSEipix.Base;
using NSEipix.Repository;
using NSMedieval.BuildingComponents;
using NSMedieval.CombatAi;
using NSMedieval.Construction;
using NSMedieval.Controllers;
using NSMedieval.Goap;
using NSMedieval.Map;
using NSMedieval.Model;
using NSMedieval.Model.MapNew;
using NSMedieval.Repository;
using NSMedieval.State;
using NSMedieval.Tools;
using NSMedieval.Types;
using NSMedieval.Utils.Pool;
using NSMedieval.Utils.Pool.Janitors;
using NSMedieval.Village;
using NSMedieval.Village.Map;
using NSMedieval.Village.Map.Pathfinding;
using NSMedieval.Water;
using Unity.Collections;
using UnityEngine;

namespace NSMedieval.Manager
{
	public class IdlePointManager
	{
		public class AnimalIdlePoint
		{
			public const int AnimalIdlePointNearRange = 11;

			public const int AnimalIdlePointNearRangeSqr = 121;

			private readonly string animalId;

			private readonly object humansNearbyCacheLock = new object();

			public bool HumanNearby => HumansNearbyCount > 0;

			public Vec3Int GridPosition { get; private set; }

			public Vector3 WorldPosition { get; private set; }

			public int NodeIndex { get; private set; }

			public Animal AnimalBlueprint { get; }

			public int HumansNearbyCount { get; private set; }

			public HashSet<CreatureBase> HumansNearbyCache { get; } = new HashSet<CreatureBase>();

			public AnimalIdlePoint(Vector3 worldPosition, Animal animalBlueprint)
			{
				WorldPosition = worldPosition;
				GridPosition = GridUtils.GetGridPosition(WorldPosition);
				NodeIndex = GridDataIndexTools.FastTo1DIndexNoCheck(GridPosition);
				AnimalBlueprint = animalBlueprint;
				animalId = AnimalBlueprint.GetID();
			}

			public AnimalIdlePoint(Vec3Int gridPosition, Animal animalBlueprint)
			{
				GridPosition = gridPosition;
				WorldPosition = GridUtils.GetWorldPosition(GridPosition);
				NodeIndex = GridDataIndexTools.FastTo1DIndexNoCheck(GridPosition);
				AnimalBlueprint = animalBlueprint;
				animalId = AnimalBlueprint.GetID();
			}

			public void AddToHumansNearby(int value)
			{
				HumansNearbyCount = Math.Max(0, HumansNearbyCount + value);
			}

			public void AddToHumansNearby(CreatureBase creatureBase)
			{
				HumansNearbyCache.Add(creatureBase);
			}

			public void RemoveFromHumansNearby(CreatureBase creatureBase)
			{
				HumansNearbyCache.Remove(creatureBase);
			}

			public void SetPosition(Vec3Int gridPosition)
			{
				GridPosition = gridPosition;
				WorldPosition = GridUtils.GetWorldPosition(gridPosition);
				NodeIndex = GridDataIndexTools.FastTo1DIndexNoCheck(gridPosition);
			}

			public void SetNearby(int humansNearby)
			{
				HumansNearbyCount = humansNearby;
			}

			public bool IsInNearRange(Vec3Int gridPosition)
			{
				return Vec3Int.DistanceSquared(in gridPosition, GridPosition) <= 121;
			}

			public bool IsInNearRange(Vector3 worldPosition)
			{
				return Vector3.Distance(worldPosition, WorldPosition) <= 11f;
			}

			public void HumansNearbyCacheForeach(Action<CreatureBase> action)
			{
				lock (humansNearbyCacheLock)
				{
					foreach (CreatureBase item in HumansNearbyCache)
					{
						action(item);
					}
				}
			}

			public override string ToString()
			{
				return animalId;
			}
		}

		private const int WalkRadius = 8;

		private const float IdlePathMinimum = 1.1f;

		public static bool RefreshPenalty;

		private bool isGameLoaded;

		[NonSerialized]
		private VillageMap map;

		[NonSerialized]
		private System.Random rnd;

		[NonSerialized]
		private List<AnimalIdlePoint>[] animalIdlePointsInRange;

		private object animalIdlePointsInRangeLock;

		[NonSerialized]
		private Dictionary<int, CreatureBase> reservedIdleNodes;

		private object reservedIdleNodesLock;

		private int relocateAnimalIdlePointsInHours;

		[field: NonSerialized]
		public Dictionary<Animal, List<AnimalIdlePoint>> IdlePointsByAnimal { get; private set; }

		[RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.BeforeSceneLoad)]
		private static void OnDomainReload()
		{
			RefreshPenalty = false;
		}

		public void Initialize(VillageMap map)
		{
			RefreshPenalty = false;
			this.map = map;
			rnd = new System.Random();
			DateTimeSettings data = Repository<DateTimeSettingsData, DateTimeSettings>.Instance.GetData<DateTimeSettings>();
			relocateAnimalIdlePointsInHours = Mathf.Max(1, data.AnimalIdlePointRelocateHours);
			MonoSingleton<ConstructionController>.Instance.AfterConstructionCompletedEvent += OnAfterConstructionCompleted;
			MonoSingleton<ConstructionController>.Instance.DestroyBuildingEvent += OnDestroyBuilding;
			MonoSingleton<ConstructionController>.Instance.FactionOwnershipChangedEvent += OnFactionOwnershipChanged;
			MonoSingleton<CreatureManager>.Instance.CreatureChangedNodeEvent += OnCreatureChangedNodeEvent;
			MonoSingleton<WorkerController>.Instance.SpawnWorkerEvent += OnHumanAdded;
			MonoSingleton<WorkerController>.Instance.RemoveWorkerEvent += OnHumanRemoved;
			MonoSingleton<NPCController>.Instance.OnNPCSpawnedEvent += OnHumanAdded;
			MonoSingleton<NPCController>.Instance.OnNPCRemovedEvent += OnHumanRemoved;
			MonoSingleton<CombatController>.Instance.DamageTakenEvent += OnAgentDamageTaken;
			MonoSingleton<CombatController>.Instance.HitMissedEvent += OnHitMissed;
			MonoSingleton<CombatController>.Instance.TrapDamageTakenEvent += OnTrapDamageTaken;
			MonoSingleton<CombatController>.Instance.AgentDiedEvent += OnAgentDied;
			MonoSingleton<WorldTimeManager>.Instance.HourUpdateEvent += OnHourUpdate;
			MonoSingleton<FireController>.Instance.FireAddedEvent += OnFireAdded;
			MonoSingleton<LoadingController>.Instance.LoadingCompleteEvent += OnLoadingComplete;
		}

		public void Dispose()
		{
			if (MonoSingleton<ConstructionController>.IsInstantiated())
			{
				MonoSingleton<ConstructionController>.Instance.AfterConstructionCompletedEvent -= OnAfterConstructionCompleted;
				MonoSingleton<ConstructionController>.Instance.DestroyBuildingEvent -= OnDestroyBuilding;
				MonoSingleton<ConstructionController>.Instance.FactionOwnershipChangedEvent -= OnFactionOwnershipChanged;
			}
			if (MonoSingleton<CreatureManager>.IsInstantiated())
			{
				MonoSingleton<CreatureManager>.Instance.CreatureChangedNodeEvent -= OnCreatureChangedNodeEvent;
			}
			if (MonoSingleton<WorkerController>.IsInstantiated())
			{
				MonoSingleton<WorkerController>.Instance.SpawnWorkerEvent -= OnHumanAdded;
				MonoSingleton<WorkerController>.Instance.RemoveWorkerEvent -= OnHumanRemoved;
			}
			if (MonoSingleton<NPCController>.IsInstantiated())
			{
				MonoSingleton<NPCController>.Instance.OnNPCSpawnedEvent -= OnHumanAdded;
				MonoSingleton<NPCController>.Instance.OnNPCRemovedEvent -= OnHumanRemoved;
			}
			if (MonoSingleton<WorldTimeManager>.IsInstantiated())
			{
				MonoSingleton<WorldTimeManager>.Instance.HourUpdateEvent -= OnHourUpdate;
			}
			if (MonoSingleton<CombatController>.IsInstantiated())
			{
				MonoSingleton<CombatController>.Instance.DamageTakenEvent -= OnAgentDamageTaken;
				MonoSingleton<CombatController>.Instance.HitMissedEvent -= OnHitMissed;
				MonoSingleton<CombatController>.Instance.TrapDamageTakenEvent -= OnTrapDamageTaken;
				MonoSingleton<CombatController>.Instance.AgentDiedEvent -= OnAgentDied;
			}
			if (MonoSingleton<FireController>.IsInstantiated())
			{
				MonoSingleton<FireController>.Instance.FireAddedEvent -= OnFireAdded;
			}
			if (MonoSingleton<LoadingController>.IsInstantiated())
			{
				MonoSingleton<LoadingController>.Instance.LoadingCompleteEvent -= OnLoadingComplete;
			}
			IdlePointsByAnimal?.Clear();
			if (animalIdlePointsInRange != null)
			{
				List<AnimalIdlePoint>[] array = animalIdlePointsInRange;
				for (int i = 0; i < array.Length; i++)
				{
					array[i]?.Clear();
				}
				animalIdlePointsInRange = null;
			}
			reservedIdleNodes?.Clear();
		}

		public void DrawGizmos()
		{
		}

		private void OnHourUpdate()
		{
			if (MonoSingleton<GlobalSaveController>.IsInstantiated() && MonoSingleton<World>.IsInstantiated() && MonoSingleton<Heightmap>.IsInstantiated() && GlobalSaveController.CurrentVillageData != null && GlobalSaveController.CurrentVillageData.DateAndTime.HoursTotal % relocateAnimalIdlePointsInHours == 0L)
			{
				RelocateRandomIdlePoint();
			}
		}

		private void OnLoadingComplete()
		{
			isGameLoaded = true;
		}

		private IEnumerator InitAnimalIdlePointsAfterLoad()
		{
			yield return new WaitForEndOfFrame();
			InitializeAnimalIdlePoints();
			yield return new WaitForEndOfFrame();
			HashSet<WorldObject> hashSet = HashSetPool<WorldObject>.Get();
			hashSet.UnionWith(map.GetWorldObjects(GridDataType.BuildingFinished));
			hashSet.UnionWith(map.GetWorldObjects(GridDataType.BuildingUnfinished));
			hashSet.UnionWith(map.GetWorldObjects(GridDataType.BuildingBlueprint));
			hashSet.UnionWith(map.GetWorldObjects(GridDataType.OthersBlueprint));
			hashSet.UnionWith(map.GetWorldObjects(GridDataType.OthersUnfinished));
			hashSet.UnionWith(map.GetWorldObjects(GridDataType.Grave));
			hashSet.UnionWith(map.GetWorldObjects(GridDataType.Roof));
			hashSet.UnionWith(map.GetWorldObjects(GridDataType.Furniture));
			hashSet.UnionWith(map.GetWorldObjects(GridDataType.Stairs));
			hashSet.UnionWith(map.GetWorldObjects(GridDataType.ProductionBuilding));
			HomeArea homeArea = map.HomeArea;
			foreach (WorldObject item in hashSet)
			{
				if (item is BaseBuildingInstance { ConstructionPhase: ConstructionPhase.Finished } baseBuildingInstance && baseBuildingInstance.OwnedByPlayer())
				{
					Vec3Int gridDataPosition = baseBuildingInstance.GridDataPosition;
					homeArea.AddToBuildingsInRange(gridDataPosition.x, gridDataPosition.y, gridDataPosition.z, 1, forceRefreshPenalty: false);
				}
			}
			HashSetPool<WorldObject>.Return(hashSet);
		}

		private IEnumerator InitAnimalIdlePointsOnNewGame()
		{
			yield return new WaitForEndOfFrame();
			InitializeAnimalIdlePoints();
		}

		public IEnumerator GameLoadedCoroutine(bool fromSave)
		{
			if (fromSave)
			{
				yield return InitAnimalIdlePointsAfterLoad();
			}
			else
			{
				yield return InitAnimalIdlePointsOnNewGame();
			}
			MapNode[] gridSpaceData = VillageManager.ActiveVillage.Map.GridSpaceData;
			for (int i = 0; i < gridSpaceData.Length; i++)
			{
				gridSpaceData[i].ForceRefreshPenalty();
			}
			RefreshPenalty = true;
		}

		public static Vec3Int GetRandomPoint(IPathfindingAgent agent, Vec3Int position, float maxRadius, int randomSeed = 0)
		{
			List<Vec3Int> list = new List<Vec3Int>();
			System.Random random = ((randomSeed == 0) ? new System.Random() : new System.Random(randomSeed));
			int num = 0;
			foreach (MapNode item in MapNodeUtils.IterateConnectedNodes(agent.Map.GetNode(position), 0f, Mathf.Ceil(maxRadius), null))
			{
				if (!item.IsWalkable || item.IsWater)
				{
					continue;
				}
				Vec3Int lhs = item.Position;
				if (!(lhs == position))
				{
					if (item.GetPenalty(agent.WalkableModel.PathfindingPenalty) < 4300)
					{
						int index = random.Next(0, list.Count - num);
						list.Insert(index, lhs);
					}
					else
					{
						int index = random.Next(Math.Min(list.Count - num, list.Count), list.Count);
						list.Insert(index, lhs);
						num++;
					}
				}
			}
			if (list.Count == 0)
			{
				return agent.GetGridPosition();
			}
			foreach (Vec3Int item2 in list)
			{
				if (PathfinderUtil.IsPathPossible(agent, item2))
				{
					return item2;
				}
			}
			return agent.GetGridPosition();
		}

		public static Vec3Int GetRandomPointForAnimalRaid(AnimalInstance animal, float radius)
		{
			return GetRandomPoint(animal, animal.GetGridPosition(), radius);
		}

		private static bool HasImpactOnAnimalIdlePoints(BaseBuildingInstance building)
		{
			bool num = building.Map.TrapComponentsManager.GetComponentInstance(building) != null;
			bool flag = !string.IsNullOrEmpty(building.Blueprint.VoxelComponentID);
			bool flag2 = !string.IsNullOrEmpty(building.Blueprint.SlopeComponentID);
			if (!num && !flag)
			{
				return !flag2;
			}
			return false;
		}

		public bool TryReserveIdleNode(MapNode node, CreatureBase creature)
		{
			InitReservedIdleNodes();
			lock (reservedIdleNodesLock)
			{
				if (reservedIdleNodes.TryGetValue(node.Index, out var value))
				{
					if (value == creature)
					{
						return true;
					}
					if (value.HasDisposed)
					{
						reservedIdleNodes[node.Index] = creature;
						return true;
					}
				}
				return reservedIdleNodes.TryAdd(node.Index, creature);
			}
		}

		public void ReleaseIdleNodeReservation(MapNode node)
		{
			InitReservedIdleNodes();
			lock (reservedIdleNodesLock)
			{
				reservedIdleNodes.Remove(node.Index);
			}
		}

		public bool IsUsingReservedIdlePoint(CreatureBase creature)
		{
			if (CombatUtils.IsNullOrDisposed(creature))
			{
				return false;
			}
			InitReservedIdleNodes();
			lock (reservedIdleNodesLock)
			{
				MapNode mapNode = creature.GetNode();
				if (creature.PathDriver.IsMoving)
				{
					mapNode = creature.PathDriver.FinalDestinationNode;
				}
				if (reservedIdleNodes.TryGetValue(mapNode.Index, out var value) && value == creature)
				{
					return true;
				}
				return false;
			}
		}

		private void InitReservedIdleNodes()
		{
			if (reservedIdleNodes != null)
			{
				return;
			}
			reservedIdleNodesLock = new object();
			lock (reservedIdleNodesLock)
			{
				reservedIdleNodes = new Dictionary<int, CreatureBase>();
			}
		}

		public static ProductionComponentInstance GetNearestProductionBuilding(string buildingId, IPathfindingAgent agent)
		{
			HashSet<ProductionComponentInstance> hashSet = new HashSet<ProductionComponentInstance>();
			foreach (ProductionComponentInstance componentInstance in VillageManager.ActiveVillage.Map.ProductionComponentBuildingManager.ComponentInstances)
			{
				if (!hashSet.Contains(componentInstance) && componentInstance.BaseBuildingBlueprint.GetID().Equals(buildingId) && componentInstance.OwnerBuilding.ReachablePositions.Any() && PathfinderUtil.IsPathPossible(agent, componentInstance.GridDataPosition) && !componentInstance.Underwater)
				{
					hashSet.Add(componentInstance);
				}
			}
			ProductionComponentInstance productionComponentInstance = null;
			float num = 0f;
			foreach (ProductionComponentInstance item in hashSet)
			{
				if (productionComponentInstance == null || (float)(item.GridDataPosition - agent.GetGridPosition()).sqrMagnitude < num)
				{
					num = (item.GridDataPosition - agent.GetGridPosition()).sqrMagnitude;
					productionComponentInstance = item;
				}
			}
			return productionComponentInstance;
		}

		public static TradingPostComponentInstance GetNearestTradingPost(IPathfindingAgent agent)
		{
			PooledDictionary<TradingPostComponentInstance, int> janitor = DictionaryPool<TradingPostComponentInstance, int>.GetJanitor();
			try
			{
				foreach (HumanoidInstance nPC in GlobalSaveController.CurrentVillageData.NPCs)
				{
					if (nPC.ActiveBehaviour is TraderBehaviour { TradingPostComponentInstance: { } tradingPostComponentInstance } && !janitor.TryAdd(tradingPostComponentInstance, 1))
					{
						janitor[tradingPostComponentInstance]++;
					}
				}
				using PooledList<TradingPostComponentInstance> pooledList = ListPool<TradingPostComponentInstance>.GetJanitor();
				foreach (TradingPostComponentInstance componentInstance in agent.Map.TradingPostComponentManager.ComponentInstances)
				{
					if ((!janitor.ContainsKey(componentInstance) || janitor[componentInstance] < componentInstance.Blueprint.MaxTraders) && componentInstance.OwnerBuilding.ReachablePositions.Count > 0 && PathfinderUtil.IsPathPossible(agent, componentInstance.GridDataPosition) && !componentInstance.Underwater && !componentInstance.IsOnFire)
					{
						pooledList.Add(componentInstance);
					}
				}
				TradingPostComponentInstance tradingPostComponentInstance2 = null;
				float num = 0f;
				foreach (TradingPostComponentInstance item in pooledList)
				{
					if (tradingPostComponentInstance2 == null || (float)(item.GridDataPosition - agent.GetGridPosition()).sqrMagnitude < num)
					{
						num = (item.GridDataPosition - agent.GetGridPosition()).sqrMagnitude;
						tradingPostComponentInstance2 = item;
					}
				}
				return tradingPostComponentInstance2;
			}
			finally
			{
				((IDisposable)janitor/*cast due to .constrained prefix*/).Dispose();
			}
		}

		private void OnTrapDamageTaken(TrapComponentInstance trapComponentInstance, IDamageTakingAgent take, CombatHitInfo hitInfo)
		{
			if (take is AnimalInstance { HasDisposed: false } animalInstance)
			{
				StartJobRelocateClosestAnimalIdlePoints(animalInstance, null);
			}
		}

		private void OnAgentDamageTaken(IDamageDealAgent deal, IDamageTakingAgent take, CombatHitInfo hitInfo)
		{
			if (take is AnimalInstance)
			{
				StartJobRelocateClosestAnimalIdlePoints(take, deal);
			}
		}

		private void OnHitMissed(IDamageDealAgent deal, IDamageTakingAgent take, CombatMissType misstype)
		{
			if (take is AnimalInstance { HasDisposed: false } animalInstance && !(deal is AnimalInstance))
			{
				float fleeChance = CombatCalculator.GetFleeChance(deal, take);
				if (!(rnd.NextDouble() > (double)fleeChance))
				{
					StartJobRelocateClosestAnimalIdlePoints(animalInstance, deal);
				}
			}
		}

		private void OnAgentDied(IDamageCommonAgent agent)
		{
			if (!LoadingController.IsLeavingMainScene && GlobalSaveController.CurrentVillageData != null && agent is AnimalInstance { CombatAi: not null } animalInstance && animalInstance.CombatAi.GetState<IDamageCommonAgent>(CombatAiState.LastDamageTakenFrom) != null && animalInstance.CombatAi.GetState<long>(CombatAiState.LastDamageTakenTime) - GlobalSaveController.CurrentVillageData.DateAndTime.MinutesTotal < 2)
			{
				StartJobRelocateClosestAnimalIdlePoints(agent, null);
			}
		}

		private void StartJobRelocateClosestAnimalIdlePoints(IDamageCommonAgent agentTookDamage, IDamageCommonAgent agentDealDamage, ThreadingJobSystem.DoneCallback doneCallback = null)
		{
			StartJobRelocateClosestAnimalIdlePoints(agentTookDamage, Vector3.zero, delegate
			{
				doneCallback?.Invoke(result: true);
			});
			MonoSingleton<AnimalManager>.Instance.ScareOffAnimals(agentTookDamage.GetGridPosition(), 10f, agentDealDamage);
		}

		public void StartJobRelocateClosestAnimalIdlePoints(IDamageCommonAgent agentTookDamage, Vector3 forcePosition, ThreadingJobSystem.DoneCallback doneCallback)
		{
			if (!MonoSingleton<Heightmap>.IsInstantiated() || animalIdlePointsInRange == null)
			{
				return;
			}
			Vector3 worldPosition = (forcePosition.Equals(Vector3.zero) ? agentTookDamage.GetPosition() : forcePosition);
			if (agentTookDamage is AnimalInstance { CombatAi: null })
			{
				return;
			}
			Vec3Int gridPosition = GridUtils.GetGridPosition(worldPosition);
			int nodeIndex = GridDataIndexTools.FastTo1DIndex(gridPosition);
			if (nodeIndex != -1)
			{
				List<AnimalIdlePoint> obj = animalIdlePointsInRange[nodeIndex];
				if (obj != null && obj.Count > 0)
				{
					return;
				}
			}
			MonoSingleton<ThreadingJobSystem>.Instance.QueueTask(() => RelocateClosestAnimalIdlePointsThread(nodeIndex), doneCallback);
		}

		private bool RelocateClosestAnimalIdlePointsThread(int nodeIndex)
		{
			using PooledList<AnimalIdlePoint> pooledList = ListPool<AnimalIdlePoint>.GetJanitor();
			lock (animalIdlePointsInRangeLock)
			{
				if (animalIdlePointsInRange[nodeIndex] != null)
				{
					pooledList.AddRange(animalIdlePointsInRange[nodeIndex]);
				}
			}
			foreach (AnimalIdlePoint item in pooledList)
			{
				RelocateAnimalIdlePoint(item);
			}
			return true;
		}

		private void OnHumanRemoved(CreatureBase human)
		{
			if (human is HumanoidInstance)
			{
				Vec3Int gridPosition = GridUtils.GetGridPosition(human.GetPosition());
				ForNearbyIdlePoints(gridPosition, delegate(AnimalIdlePoint nearbyIdlePoint)
				{
					nearbyIdlePoint.AddToHumansNearby(-1);
					nearbyIdlePoint.RemoveFromHumansNearby(human);
				});
			}
		}

		private void OnHumanAdded(CreatureBase human)
		{
			if (human is HumanoidInstance)
			{
				Vec3Int gridPosition = GridUtils.GetGridPosition(human.GetPosition());
				ForNearbyIdlePoints(gridPosition, delegate(AnimalIdlePoint nearbyIdlePoint)
				{
					nearbyIdlePoint.AddToHumansNearby(1);
					nearbyIdlePoint.AddToHumansNearby(human);
				});
			}
		}

		public AnimalIdlePoint GetAnimalIdlePointAt(int nodeIndex)
		{
			if (animalIdlePointsInRange[nodeIndex] == null)
			{
				return null;
			}
			lock (animalIdlePointsInRangeLock)
			{
				foreach (AnimalIdlePoint item in animalIdlePointsInRange[nodeIndex])
				{
					if (item.NodeIndex == nodeIndex)
					{
						return item;
					}
				}
			}
			return null;
		}

		public AnimalIdlePoint GetClosestAnimalIdlePoint(AnimalInstance animalInstance)
		{
			if (animalInstance.Blueprint == null)
			{
				return null;
			}
			if (IdlePointsByAnimal == null || !IdlePointsByAnimal.ContainsKey(animalInstance.Blueprint) || IdlePointsByAnimal[animalInstance.Blueprint].Count == 0)
			{
				return null;
			}
			AnimalIdlePoint closestAnimalIdlePoint = GetClosestAnimalIdlePoint(animalInstance, animalInstance.GetGridPosition(), animalInstance.Blueprint);
			if (closestAnimalIdlePoint == null)
			{
				return null;
			}
			if (!PathfinderUtil.IsPathPossible(animalInstance, closestAnimalIdlePoint.GridPosition))
			{
				return null;
			}
			return closestAnimalIdlePoint;
		}

		private AnimalIdlePoint GetClosestAnimalIdlePoint(AnimalInstance animalInstance, Vec3Int gridPosition, Animal animal)
		{
			AnimalIdlePoint animalIdlePoint = null;
			HomeArea homeArea = animalInstance.Map.HomeArea;
			int num = GridDataIndexTools.FastTo1DIndexNoCheck(gridPosition);
			lock (animalIdlePointsInRangeLock)
			{
				if (animalIdlePointsInRange[num] != null && animalIdlePointsInRange[num].Count > 0)
				{
					foreach (AnimalIdlePoint item in animalIdlePointsInRange[num])
					{
						if (item.AnimalBlueprint.Equals(animal))
						{
							if (ActiveTaming(animalInstance, item) && (animalIdlePoint == null || Vec3Int.Distance(item.GridPosition, in gridPosition) < Vec3Int.Distance(animalIdlePoint.GridPosition, in gridPosition)) && PathfinderUtil.IsPathPossible(animalInstance, gridPosition, item.GridPosition))
							{
								animalIdlePoint = item;
							}
							else if (!item.HumanNearby && homeArea.GetBuildingsNearbyCount(item.NodeIndex) <= 0 && (animalIdlePoint == null || Vec3Int.Distance(item.GridPosition, in gridPosition) < Vec3Int.Distance(animalIdlePoint.GridPosition, in gridPosition)) && PathfinderUtil.IsPathPossible(animalInstance, gridPosition, item.GridPosition))
							{
								animalIdlePoint = item;
							}
						}
					}
					if (animalIdlePoint != null)
					{
						return animalIdlePoint;
					}
				}
			}
			foreach (AnimalIdlePoint item2 in IdlePointsByAnimal[animal])
			{
				if (ActiveTaming(animalInstance, item2) && (animalIdlePoint == null || Vec3Int.Distance(item2.GridPosition, in gridPosition) < Vec3Int.Distance(animalIdlePoint.GridPosition, in gridPosition)) && PathfinderUtil.IsPathPossible(animalInstance, gridPosition, item2.GridPosition))
				{
					animalIdlePoint = item2;
				}
				else if (!item2.HumanNearby && homeArea.GetBuildingsNearbyCount(item2.NodeIndex) <= 0 && (animalIdlePoint == null || Vec3Int.Distance(item2.GridPosition, in gridPosition) < Vec3Int.Distance(animalIdlePoint.GridPosition, in gridPosition)) && PathfinderUtil.IsPathPossible(animalInstance, gridPosition, item2.GridPosition))
				{
					animalIdlePoint = item2;
				}
			}
			return animalIdlePoint;
		}

		private bool ActiveTaming(AnimalInstance animalInstance, AnimalIdlePoint idlePoint)
		{
			if (!animalInstance.OrderType.HasFlag(AnimalOrderType.Tame))
			{
				return false;
			}
			bool otherWorkersPresent = false;
			idlePoint.HumansNearbyCacheForeach(delegate(CreatureBase creatureBase)
			{
				if (!MonoSingleton<ReservationManager>.Instance.IsReservedBy(animalInstance, creatureBase))
				{
					otherWorkersPresent = true;
				}
			});
			return !otherWorkersPresent;
		}

		private int GetIdlePointsCountPerAnimal()
		{
			int num = GlobalSaveController.CurrentVillageData.MapSizeInstance.IdlePointsCountPerAnimal;
			if (num == 0)
			{
				MapSize byID = Repository<MapSizeRepository, MapSize>.Instance.GetByID(GlobalSaveController.CurrentVillageData.MapSizeID);
				if (byID != null)
				{
					num = byID.IdlePointsCountPerAnimal;
				}
				if (num == 0)
				{
					num = 15;
				}
			}
			return num;
		}

		private void InitializeAnimalIdlePoints()
		{
			VillageMap villageMap = VillageManager.ActiveVillage.Map;
			animalIdlePointsInRangeLock = new object();
			IdlePointsByAnimal = new Dictionary<Animal, List<AnimalIdlePoint>>();
			animalIdlePointsInRange = new List<AnimalIdlePoint>[villageMap.GridSpaceData.Length];
			int num = Mathf.Clamp(GetIdlePointsCountPerAnimal(), 1, 250);
			List<MapNode> list = VillageManager.ActiveVillage.Map.GridSpaceData.Where((MapNode node) => node.IsWalkable && (node.WaterDepthLevel & WaterDepthLevel.None) != 0).ToPooledList();
			System.Random random = new System.Random();
			foreach (Animal allItem in Repository<AnimalBaseRepository, Animal>.Instance.GetAllItems())
			{
				IdlePointsByAnimal.Add(allItem, new List<AnimalIdlePoint>());
				for (int num2 = 0; num2 < num; num2++)
				{
					MapNode mapNode = list[random.Next(list.Count)];
					if (mapNode != null)
					{
						AnimalIdlePoint animalIdlePoint = new AnimalIdlePoint(mapNode.Position, allItem);
						IdlePointsByAnimal[allItem].Add(animalIdlePoint);
						AddToAnimalIdlePointsInRange(animalIdlePoint);
					}
				}
			}
			ListPool<MapNode>.Return(list);
		}

		private void OnCreatureChangedNodeEvent(CreatureBase creature, MapNode oldNode)
		{
			if (creature is HumanoidInstance && oldNode != null)
			{
				Vec3Int position = oldNode.Position;
				ForNearbyIdlePoints(position, delegate(AnimalIdlePoint nearbyIdlePoint)
				{
					nearbyIdlePoint.AddToHumansNearby(-1);
					nearbyIdlePoint.RemoveFromHumansNearby(creature);
				});
				Vec3Int gridPosition = creature.GetGridPosition();
				ForNearbyIdlePoints(gridPosition, delegate(AnimalIdlePoint nearbyIdlePoint)
				{
					nearbyIdlePoint.AddToHumansNearby(1);
					nearbyIdlePoint.AddToHumansNearby(creature);
				});
			}
		}

		private void OnAfterConstructionCompleted(BaseBuildingInstance building)
		{
			if (HasImpactOnAnimalIdlePoints(building) && isGameLoaded && !LoadingController.IsLeavingMainScene && building.OwnedByPlayer())
			{
				Vec3Int gridDataPosition = building.GridDataPosition;
				building.Map.HomeArea.AddToBuildingsInRange(gridDataPosition.x, gridDataPosition.y, gridDataPosition.z, 1, RefreshPenalty);
			}
		}

		private void OnDestroyBuilding(BaseBuildingInstance building)
		{
			if (building.ConstructionPhase == ConstructionPhase.Finished && HasImpactOnAnimalIdlePoints(building) && isGameLoaded && !LoadingController.IsLeavingMainScene && building.OwnedByPlayer())
			{
				Vec3Int gridDataPosition = building.GridDataPosition;
				building.Map.HomeArea.AddToBuildingsInRange(gridDataPosition.x, gridDataPosition.y, gridDataPosition.z, -1, RefreshPenalty);
			}
		}

		private void OnFactionOwnershipChanged(FactionOwnership oldFaction, FactionOwnership newFaction, WorldObject worldObject)
		{
			if (isGameLoaded && !LoadingController.IsLeavingMainScene && oldFaction != newFaction && worldObject is BaseBuildingInstance baseBuildingInstance)
			{
				if (newFaction == FactionOwnership.Player)
				{
					Vec3Int gridDataPosition = baseBuildingInstance.GridDataPosition;
					baseBuildingInstance.Map.HomeArea.AddToBuildingsInRange(gridDataPosition.x, gridDataPosition.y, gridDataPosition.z, 1, RefreshPenalty);
				}
				else
				{
					Vec3Int gridDataPosition2 = baseBuildingInstance.GridDataPosition;
					baseBuildingInstance.Map.HomeArea.AddToBuildingsInRange(gridDataPosition2.x, gridDataPosition2.y, gridDataPosition2.z, -1, RefreshPenalty);
				}
			}
		}

		private void ForNearbyIdlePoints(Vec3Int gridPosition, Action<AnimalIdlePoint> func)
		{
			if (animalIdlePointsInRange == null)
			{
				return;
			}
			int num = GridDataIndexTools.FastTo1DIndexNoCheck(gridPosition);
			if (animalIdlePointsInRange[num] == null)
			{
				return;
			}
			lock (animalIdlePointsInRangeLock)
			{
				foreach (AnimalIdlePoint item in animalIdlePointsInRange[num])
				{
					func(item);
				}
			}
		}

		private void AddToAnimalIdlePointsInRange(AnimalIdlePoint idlePoint)
		{
			for (int i = -11; i <= 11; i++)
			{
				for (int j = -11; j <= 11; j++)
				{
					Vec3Int gridPosition = idlePoint.GridPosition;
					gridPosition.x += i;
					gridPosition.z += j;
					if (!idlePoint.IsInNearRange(gridPosition))
					{
						continue;
					}
					int num = GridDataIndexTools.FastTo1DIndex(gridPosition);
					if (num == -1)
					{
						continue;
					}
					lock (animalIdlePointsInRangeLock)
					{
						if (animalIdlePointsInRange[num] == null)
						{
							animalIdlePointsInRange[num] = new List<AnimalIdlePoint>();
						}
						animalIdlePointsInRange[num].Add(idlePoint);
					}
				}
			}
		}

		private void RemoveFromAnimalIdlePointsInRange(AnimalIdlePoint idlePoint)
		{
			for (int i = -11; i <= 11; i++)
			{
				for (int j = -11; j <= 11; j++)
				{
					Vec3Int gridPosition = idlePoint.GridPosition;
					gridPosition.x += i;
					gridPosition.z += j;
					int num = GridDataIndexTools.FastTo1DIndex(gridPosition);
					if (num == -1)
					{
						continue;
					}
					lock (animalIdlePointsInRangeLock)
					{
						if (animalIdlePointsInRange[num] != null)
						{
							animalIdlePointsInRange[num].Remove(idlePoint);
						}
					}
				}
			}
		}

		private List<AnimalIdlePoint> GetInactiveAnimalIdlePoints()
		{
			VillageMap villageMap = VillageManager.ActiveVillage.Map;
			List<AnimalIdlePoint> list = new List<AnimalIdlePoint>();
			foreach (KeyValuePair<Animal, List<AnimalIdlePoint>> item in IdlePointsByAnimal)
			{
				foreach (AnimalIdlePoint item2 in item.Value)
				{
					if (item2.HumanNearby || villageMap.HomeArea.GetBuildingsNearbyCount(item2.NodeIndex) > 0)
					{
						list.Add(item2);
					}
				}
			}
			return list;
		}

		private List<AnimalIdlePoint> GetAllAnimalIdlePoints()
		{
			List<AnimalIdlePoint> list = new List<AnimalIdlePoint>();
			foreach (KeyValuePair<Animal, List<AnimalIdlePoint>> item in IdlePointsByAnimal)
			{
				list.AddRange(item.Value);
			}
			return list;
		}

		public void RelocateRandomIdlePoint()
		{
			List<AnimalIdlePoint> list = GetInactiveAnimalIdlePoints();
			if (list == null || list.Count == 0)
			{
				list = GetAllAnimalIdlePoints();
			}
			AnimalIdlePoint idlePoint = list.PickRandom();
			RelocateAnimalIdlePoint(idlePoint);
		}

		private Vec3Int GetAvailablePoint3D(Vec3Int oldPosition)
		{
			VillageMap villageMap = VillageManager.ActiveVillage.Map;
			int num = GridDataIndexTools.FastTo1DIndexNoCheck(oldPosition);
			MapNode mapNode = villageMap.GridSpaceData[num];
			Region region = mapNode.Region;
			if (region == null || region.Connections.Count == 0)
			{
				using (PooledList<Region> pooledList = villageMap.RegionManager.Regions.WherePooled((Region region3) => region3.Nodes.Count > 0 && !region3.IsFire && region3.WaterDepthLevel <= WaterDepthLevel.Low))
				{
					return pooledList.PickRandom().Nodes.PickRandom().Position;
				}
			}
			using PooledQueue<Region> pooledQueue = QueuePool<Region>.GetJanitor();
			using PooledHashSet<Region> pooledHashSet = HashSetPool<Region>.GetJanitor();
			MapNode mapNode2 = null;
			using PooledList<MapNode> pooledList2 = ListPool<MapNode>.GetJanitor();
			using PooledList<Region> pooledList3 = ListPool<Region>.GetJanitor();
			pooledList3.Add(region);
			HashSet<Region> connections = region.Connections;
			if (connections != null && connections.Count > 0)
			{
				pooledList3.AddRange(region.Connections);
			}
			pooledList3.ShuffleInPlace();
			foreach (Region item in pooledList3)
			{
				pooledQueue.Enqueue(item);
				pooledHashSet.Add(item);
			}
			while (pooledQueue.Count > 0)
			{
				Region region2 = pooledQueue.Dequeue();
				pooledHashSet.Add(region2);
				if (!(region2 is RegionBridge) && !region2.IsFire && region2.WaterDepthLevel <= WaterDepthLevel.Low)
				{
					pooledList2.Clear();
					pooledList2.AddRange(region2.Nodes);
					pooledList2.ShuffleInPlace();
					foreach (MapNode item2 in pooledList2)
					{
						if (!item2.IsWalkable)
						{
							continue;
						}
						if (item2.Index >= 0 && animalIdlePointsInRange[item2.Index] != null)
						{
							bool flag = false;
							foreach (AnimalIdlePoint item3 in animalIdlePointsInRange[item2.Index])
							{
								if (item3.NodeIndex == item2.Index)
								{
									flag = true;
									break;
								}
							}
							if (flag)
							{
								break;
							}
						}
						if (!villageMap.HomeArea.IsHomeArea(item2.Index))
						{
							mapNode2 = item2;
							break;
						}
					}
				}
				if (mapNode2 != null)
				{
					break;
				}
				foreach (Region connection in region2.Connections)
				{
					if (!pooledHashSet.Contains(connection))
					{
						pooledQueue.Enqueue(connection);
						pooledHashSet.Add(connection);
					}
				}
			}
			return mapNode2?.Position ?? mapNode.Position;
		}

		public void RelocateAnimalIdlePoint(AnimalIdlePoint idlePoint)
		{
			if (MonoSingleton<Heightmap>.IsInstantiated())
			{
				RemoveFromAnimalIdlePointsInRange(idlePoint);
				Vec3Int availablePoint3D = GetAvailablePoint3D(idlePoint.GridPosition);
				idlePoint.SetPosition(availablePoint3D);
				AddToAnimalIdlePointsInRange(idlePoint);
				int nearby = GlobalSaveController.CurrentVillageData.Workers.Count((HumanoidInstance worker) => idlePoint.IsInNearRange(worker.GetPosition()));
				idlePoint.SetNearby(nearby);
			}
		}

		private void OnFireAdded(NativeParallelHashSet<int> addedFireIndices)
		{
			using PooledHashSet<AnimalIdlePoint> pooledHashSet = HashSetPool<AnimalIdlePoint>.GetJanitor();
			foreach (int item in addedFireIndices)
			{
				if (animalIdlePointsInRange[item] != null && animalIdlePointsInRange[item].Count > 0)
				{
					pooledHashSet.AddRange(animalIdlePointsInRange[item]);
				}
			}
			foreach (AnimalIdlePoint item2 in pooledHashSet)
			{
				RelocateAnimalIdlePoint(item2);
			}
		}
	}
}
