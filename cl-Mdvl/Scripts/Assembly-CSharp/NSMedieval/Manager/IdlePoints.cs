using System;
using System.Collections.Generic;
using System.Linq;
using NSEipix;
using NSEipix.Base;
using NSEipix.Repository;
using NSMedieval.Construction;
using NSMedieval.Goap.Goals;
using NSMedieval.Model;
using NSMedieval.Production;
using NSMedieval.RoomDetection;
using NSMedieval.State;
using NSMedieval.Stockpiles;
using NSMedieval.Tools;
using NSMedieval.Types;
using NSMedieval.Utils.Pool;
using NSMedieval.Village;
using NSMedieval.Village.Map;
using NSMedieval.Village.Map.Pathfinding;

namespace NSMedieval.Manager
{
	public class IdlePoints : IDisposable
	{
		private delegate bool RoomCustomFilterDelegate(Room room, string customArg);

		private const int WalkRadius = 8;

		private const float IdlePathMinimum = 1.1f;

		private VillageMap map;

		private readonly Random random = new Random();

		public void Initialize(VillageMap villageMap)
		{
			map = villageMap;
		}

		public void Dispose()
		{
			map = null;
		}

		public MapNode GetIlePointInRoomWithResource(CreatureBase creature, string roomTypeId, string resourceId)
		{
			if (CombatUtils.IsNullOrDisposed(creature))
			{
				return null;
			}
			RoomType roomType = ((roomTypeId != null) ? Repository<RoomTypeRepository, RoomType>.Instance.GetByID(roomTypeId) : null);
			if (roomType != null)
			{
				MapNode randomPositionInRoom = GetRandomPositionInRoom(creature, roomType, out var nodeFoundSuccessfully, RoomHasResource, resourceId);
				if (nodeFoundSuccessfully)
				{
					return randomPositionInRoom;
				}
				randomPositionInRoom = GetRandomPositionInRoom(creature, roomType, out nodeFoundSuccessfully);
				if (nodeFoundSuccessfully)
				{
					return randomPositionInRoom;
				}
			}
			return GetRandomPoint(creature, creature.SpawnPosition.IsZero() ? creature.GetGridPosition() : GridUtils.GetGridPosition(creature.SpawnPosition), 8f, skipOutOfRangeTemperatures: true);
		}

		private static bool RoomHasResource(Room room, string resourceId)
		{
			return room.GetResourceCount(resourceId) > 0;
		}

		public MapNode GetIdlePointForWorker(CreatureBase worker)
		{
			if (CombatUtils.IsNullOrDisposed(worker))
			{
				return null;
			}
			if (GlobalSaveController.CurrentVillageData.IsSecondMap)
			{
				return GetIdlePointForWorkerSecondMap(worker);
			}
			MapNode node = worker.GetNode();
			float num = 8f;
			RoomType defaultRoomType = Repository<RoomTypeRepository, RoomType>.Instance.DefaultRoomType;
			RoomType byID = Repository<RoomTypeRepository, RoomType>.Instance.GetByID("great_hall");
			bool nodeFoundSuccessfully;
			MapNode mapNode = GetRandomPositionInRoom(worker, byID, out nodeFoundSuccessfully);
			if (mapNode.Distance(node) < 1.1f)
			{
				mapNode = GetRandomPositionInRoom(worker, defaultRoomType, out nodeFoundSuccessfully);
			}
			if (mapNode.Distance(node) < 1.1f)
			{
				mapNode = GetRandomPositionInRoom(worker, null, out nodeFoundSuccessfully);
			}
			if (mapNode.Distance(node) < 1.1f)
			{
				mapNode = GetRandomPositionAroundBuildings(worker, GetCampfires(), num, skipOutOfRangeTemperatures: true);
			}
			if (mapNode.Distance(node) < 1.1f)
			{
				mapNode = GetRandomPoint(worker, GridUtils.GetGridPosition(worker.SpawnPosition), num, skipOutOfRangeTemperatures: true);
			}
			if (mapNode.Distance(node) < 1.1f)
			{
				mapNode = GetRandomPoint(worker, worker.GetGridPosition(), num, skipOutOfRangeTemperatures: true);
			}
			if (mapNode.Distance(node) < 1.1f)
			{
				mapNode = GetRandomPoint(worker, worker.GetGridPosition(), num, skipOutOfRangeTemperatures: true);
			}
			if (mapNode.Distance(node) < 1.1f)
			{
				mapNode = GetRandomPositionAroundBuildings(worker, GetHeatSources(), num, skipOutOfRangeTemperatures: false);
			}
			if (mapNode.Distance(node) < 1.1f)
			{
				mapNode = GetRandomPoint(worker, worker.GetGridPosition(), num, skipOutOfRangeTemperatures: false);
			}
			return mapNode;
		}

		private MapNode GetIdlePointForWorkerSecondMap(CreatureBase worker)
		{
			Vec3Int secondMapSpawnPosition = worker.SecondMapSpawnPosition;
			return GetRandomPoint(worker, secondMapSpawnPosition, 8f, skipOutOfRangeTemperatures: false);
		}

		public MapNode GetIdlePointForAgentOnFire(CreatureBase creature)
		{
			return GetRandomPoint(creature, creature.GetGridPosition(), 10f, skipOutOfRangeTemperatures: true, getClosestNode: false, preferWaterNodes: true);
		}

		public MapNode GetIdlePointForEnemy(CreatureBase enemy)
		{
			if (CombatUtils.IsNullOrDisposed(enemy))
			{
				return null;
			}
			MapNode node = enemy.GetNode();
			if ((node.Tag & MapNodeTags.Ladder) == 0)
			{
				return GetRandomPoint(enemy, enemy.GetGridPosition(), 8f, skipOutOfRangeTemperatures: false);
			}
			HashSet<MapNode> possibleDestinations = HashSetPool<MapNode>.Get();
			FloodFillUtil.FloodFillConnections(node, 12f, delegate(MapNode mapNode2)
			{
				if ((mapNode2.Tag & MapNodeTags.Ladder) != MapNodeTags.None)
				{
					return FloodFillUtil.ScanStatus.InvalidNode;
				}
				if (!PathfinderUtil.IsPathPossible(enemy, mapNode2))
				{
					return FloodFillUtil.ScanStatus.InvalidNode;
				}
				possibleDestinations.Add(mapNode2);
				return FloodFillUtil.ScanStatus.Continue;
			});
			MapNode mapNode = null;
			float num = float.MaxValue;
			foreach (MapNode item in possibleDestinations)
			{
				float num2 = Vec3Int.Distance(item.Position, node.Position);
				if (num2 < num)
				{
					mapNode = item;
					num = num2;
				}
			}
			HashSetPool<MapNode>.Return(possibleDestinations);
			return mapNode ?? node;
		}

		public MapNode GetIdlePointForTrader(CreatureBase trader)
		{
			if (CombatUtils.IsNullOrDisposed(trader))
			{
				return null;
			}
			float num = 8f;
			if (trader is HumanoidInstance { ActiveBehaviour: TraderBehaviour activeBehaviour } && activeBehaviour.TraderType.StandsOnTheMapEdge)
			{
				return GetRandomPoint(trader, trader.GetGridPosition(), num, skipOutOfRangeTemperatures: false, getClosestNode: false, preferWaterNodes: false, (MapNode mapNode2) => GridDataIndexTools.IsForbiddenEdge(mapNode2.Position.x, mapNode2.Position.z));
			}
			MapNode node = trader.GetNode();
			MapNode mapNode = GetRandomPositionAroundBuildings(trader, GetCampfires(), num, skipOutOfRangeTemperatures: false);
			if (mapNode.Distance(node) < 1.1f)
			{
				mapNode = GetRandomPositionAroundStockpile(trader, num);
			}
			if (mapNode.Distance(node) < 1.1f)
			{
				mapNode = GetRandomPoint(trader, GridUtils.GetGridPosition(trader.SpawnPosition), num, skipOutOfRangeTemperatures: false);
			}
			if (mapNode.Distance(node) < 1.1f)
			{
				mapNode = GetRandomPoint(trader, trader.GetGridPosition(), num, skipOutOfRangeTemperatures: false);
			}
			return mapNode;
		}

		public MapNode GetIdlePointForAnimal(CreatureBase creature, out IdlePointManager.AnimalIdlePoint idlePoint)
		{
			AnimalInstance animalInstance = creature as AnimalInstance;
			idlePoint = null;
			if (CombatUtils.IsNullOrDisposed(animalInstance))
			{
				return null;
			}
			if (animalInstance.AnimalType == AnimalType.DomesticNpc && animalInstance.PetOwner != null)
			{
				MapNode idlePointForAnimalDomesticNpc = GetIdlePointForAnimalDomesticNpc(animalInstance);
				if (idlePointForAnimalDomesticNpc != null)
				{
					return idlePointForAnimalDomesticNpc;
				}
			}
			if (animalInstance.AnimalType == AnimalType.Pet)
			{
				return GetIdlePointForAnimalPet(animalInstance);
			}
			if (animalInstance.AnimalType == AnimalType.Domestic && animalInstance.GetNode() != null)
			{
				return GetIdlePointForAnimalDomestic(animalInstance);
			}
			return GetIdlePointForAnimalWild(animalInstance, out idlePoint);
		}

		private MapNode GetIdlePointForAnimalWild(AnimalInstance animal, out IdlePointManager.AnimalIdlePoint idlePoint)
		{
			idlePoint = animal.Map.IdlePointManager.GetClosestAnimalIdlePoint(animal);
			if (idlePoint == null)
			{
				return GetRandomPoint(animal, animal.GetGridPosition(), 10f, skipOutOfRangeTemperatures: false);
			}
			MapNode node = map.GetNode(idlePoint.GridPosition);
			MapNode mapNode = GetRandomPoint(animal, node.Position, 10f, skipOutOfRangeTemperatures: false);
			if (Vec3Int.Distance(mapNode.Position, animal.GetGridPosition()) < 1.1f)
			{
				mapNode = HomeArea.GetNodeInHomeArea(searchInsideHomeArea: false, animal, 1.99f, 12f) ?? GetRandomPoint(animal, animal.GetGridPosition(), 10f, skipOutOfRangeTemperatures: false);
			}
			return mapNode;
		}

		private MapNode GetIdlePointForAnimalDomestic(CreatureBase animal)
		{
			if (CombatUtils.IsNullOrDisposed(animal))
			{
				return null;
			}
			AnimalPenInstance pen = MonoSingleton<PenDetection>.Instance.GetPen(animal.GetNode());
			if (pen != null)
			{
				return pen.GetNodeWithMinPenalty(animal.Map, animal.WalkableModel.PathfindingPenalty, 8) ?? animal.GetNode();
			}
			MapNode nodeInHomeArea = HomeArea.GetNodeInHomeArea(searchInsideHomeArea: true, animal, 1.99f, 12f);
			if (nodeInHomeArea != animal.GetNode())
			{
				return nodeInHomeArea;
			}
			List<HumanoidInstance> list = ListPool<HumanoidInstance>.Get();
			list.AddRange(GlobalSaveController.CurrentVillageData.Workers);
			list.ShuffleInPlace(random);
			HumanoidInstance humanoidInstance = null;
			foreach (HumanoidInstance item in list)
			{
				if (!CombatUtils.IsNullOrDisposed(item) && PathfinderUtil.IsPathPossible(animal.WalkableModel, item.GetNode(), animal.GetNode()))
				{
					humanoidInstance = item;
				}
			}
			ListPool<HumanoidInstance>.Return(list);
			if (humanoidInstance != null)
			{
				return GetRandomPoint(humanoidInstance, humanoidInstance.GetGridPosition(), 10f, skipOutOfRangeTemperatures: false);
			}
			return animal.Map.IdlePoints.GetIdlePointForWorker(animal) ?? animal.GetNode();
		}

		private MapNode GetIdlePointForAnimalPet(AnimalInstance animal)
		{
			if (CombatUtils.IsNullOrDisposed(animal))
			{
				return null;
			}
			if (animal.PetOwner != null && !MonoSingleton<CaravanManager>.Instance.IsWorkerInCaravan(animal.PetOwner as HumanoidInstance) && !CombatUtils.IsNullOrDisposed(animal.PetOwner) && PathfinderUtil.IsPathPossible(animal.WalkableModel, animal.PetOwner.GetNode(), animal.GetNode()))
			{
				return GetRandomPoint(animal.PetOwner, animal.PetOwner.GetGridPosition(), 10f, skipOutOfRangeTemperatures: false);
			}
			return animal.Map.IdlePoints.GetIdlePointForWorker(animal) ?? animal.GetNode();
		}

		private MapNode GetIdlePointForAnimalDomesticNpc(AnimalInstance animal)
		{
			if (CombatUtils.IsNullOrDisposed(animal, animal.PetOwner))
			{
				return null;
			}
			if (PathfinderUtil.IsPathPossible(animal.WalkableModel, animal.PetOwner.GetNode(), animal.GetNode()))
			{
				return GetRandomPoint(animal.PetOwner, animal.PetOwner.GetGridPosition(), 6f, skipOutOfRangeTemperatures: false);
			}
			return null;
		}

		private MapNode GetRandomPositionInRoom(CreatureBase agent, RoomType roomTypeToFind, out bool nodeFoundSuccessfully, RoomCustomFilterDelegate roomCustomFilter = null, string customFilterArg = null)
		{
			nodeFoundSuccessfully = false;
			if (CombatUtils.IsNullOrDisposed(agent))
			{
				return null;
			}
			Vec3Int b = agent.GetNode().Position;
			VillageMap villageMap = agent.Map;
			Room room = villageMap.RoomDetection.GetRoom(b);
			Room room2 = null;
			Region region = agent.Map.GetNode(agent.GetGridPosition()).Region;
			List<Room> list = ListPool<Room>.Get();
			list.AddRange(villageMap.RoomDetection.IterateRoomsSafe());
			TemperatureManager temperatureManager = map.TemperatureManager;
			float temperatureCelsius = GlobalSaveController.CurrentVillageData.DateAndTime.TemperatureCelsius;
			foreach (Room item in list)
			{
				if ((!(roomTypeToFind != null) || roomTypeToFind.Equals(item.RoomType)) && (!(agent is HumanoidInstance human) || CommonGoalMethods.CheckPrisonConditions(human, item)) && !ShouldSkipRoom(temperatureManager, temperatureCelsius, item) && PathfinderUtil.IsRegionReachable(agent.WalkableModel, region, item.Regions.First()) && (item == room || !item.IsFullyLocked()) && (roomCustomFilter == null || roomCustomFilter(item, customFilterArg)) && (room2 == null || Vec3Int.Distance(item.Center, in b) < Vec3Int.Distance(room2.Center, in b)))
				{
					room2 = item;
				}
			}
			ListPool<Room>.Return(list);
			MapNode result = agent.GetNode();
			if (room2 != null)
			{
				List<MapNode> list2 = ListPool<MapNode>.Get();
				list2.AddRange(room2.AllNodes);
				list2.ShuffleInPlace();
				SortNodesPenaltyTemperature(agent, list2);
				Vec3Int b2 = agent.GetGridPosition();
				foreach (MapNode item2 in list2)
				{
					if (CommonGoalMethods.CheckPrisonConditions(agent, item2.Map.RoomDetection.GetRoom(item2)) && Vec3Int.Distance(item2.Position, in b2) >= 2f)
					{
						nodeFoundSuccessfully = true;
						result = item2;
						break;
					}
				}
				ListPool<MapNode>.Return(list2);
			}
			return result;
		}

		private static bool ShouldSkipRoom(TemperatureManager temperatureManager, float outsideTemp, Room room)
		{
			if (!temperatureManager.IsTemperatureOutOfRange(outsideTemp))
			{
				if (temperatureManager.IsTemperatureOutOfRange(room.AverageTemperature))
				{
					return true;
				}
			}
			else
			{
				if (outsideTemp < temperatureManager.Settings.SkipRoomIdleUnderTemperature && room.AverageTemperature < outsideTemp)
				{
					return true;
				}
				if (outsideTemp > temperatureManager.Settings.SkipRoomIdleOverTemperature && room.AverageTemperature > outsideTemp)
				{
					return true;
				}
			}
			return false;
		}

		private MapNode GetRandomPositionAroundBuildings(CreatureBase agent, IEnumerable<WorldObject> buildings, float maximumRadius, bool skipOutOfRangeTemperatures)
		{
			if (CombatUtils.IsNullOrDisposed(agent))
			{
				return null;
			}
			Vec3Int b = agent.GetGridPosition();
			WorldObject worldObject = null;
			foreach (WorldObject building in buildings)
			{
				if (building != null && PathfinderUtil.IsPathPossible(agent, building.GridDataPosition) && (worldObject == null || Vec3Int.Distance(building.GridDataPosition, in b) < Vec3Int.Distance(worldObject.GridDataPosition, in b)))
				{
					worldObject = building;
				}
			}
			if (worldObject != null)
			{
				return GetRandomPoint(agent, worldObject.ReachablePositions.PickRandom(), maximumRadius, skipOutOfRangeTemperatures);
			}
			return agent.GetNode();
		}

		private IEnumerable<WorldObject> GetCampfires()
		{
			return from item in map.GetWorldObjects(GridDataType.ProductionBuilding)
				where (item.GridDataType & GridDataType.ProductionBuilding) != GridDataType.None && item.BlueprintId.Equals("camp_fire")
				select item;
		}

		private IEnumerable<WorldObject> GetHeatSources()
		{
			return map.GetWorldObjects(GridDataType.Furniture).Where(delegate(WorldObject item)
			{
				if ((item.GridDataType & GridDataType.Furniture) != GridDataType.None)
				{
					ThermalModel thermalModel = item.ThermalModel;
					if ((object)thermalModel == null)
					{
						return false;
					}
					return thermalModel.Emission > 0;
				}
				return false;
			});
		}

		public MapNode GetRandomPoint(CreatureBase agent, Vec3Int position, float maxRadius, bool skipOutOfRangeTemperatures, bool getClosestNode = false, bool preferWaterNodes = false, Func<MapNode, bool> additionalCondition = null)
		{
			if (CombatUtils.IsNullOrDisposed(agent))
			{
				return null;
			}
			List<MapNode> list = ListPool<MapNode>.Get();
			TemperatureManager temperatureManager = map.TemperatureManager;
			Random random = new Random();
			foreach (MapNode item in MapNodeUtils.IterateConnectedNodes(map.GetNode(position), 0f, maxRadius, null))
			{
				if ((item.Tag & (MapNodeTags.Ladder | MapNodeTags.IdleTargetForbidden)) == 0 && item.IsWalkable && !(item.Position == position) && PathfinderUtil.IsPathPossible(agent, item) && (!skipOutOfRangeTemperatures || !temperatureManager.IsNodeTemperatureOutOfRange(item)) && (additionalCondition == null || additionalCondition(item)) && CommonGoalMethods.CheckPrisonConditions(agent, item.Map.RoomDetection.GetRoom(item)))
				{
					list.Insert(random.Next(list.Count + 1), item);
				}
			}
			if (getClosestNode)
			{
				SortNodesPenaltyTemperatureDistance(agent, list);
			}
			else
			{
				SortNodesPenaltyTemperature(agent, list);
			}
			if (preferWaterNodes)
			{
				SortNodesWaterFirst(agent, list);
			}
			if (list.Count <= 0)
			{
				return agent.GetNode();
			}
			return list[0];
		}

		private MapNode GetRandomPositionAroundStockpile(CreatureBase trader, float maximumRadius)
		{
			if (CombatUtils.IsNullOrDisposed(trader))
			{
				return null;
			}
			Vec3Int b = trader.GetGridPosition();
			StockpileInstance stockpileInstance = null;
			float num = 0f;
			foreach (StockpileInstance stockpile in MonoSingleton<StockpileManager>.Instance.Stockpiles)
			{
				if (stockpile == null || stockpile.Positions == null || stockpile.Positions.Count == 0)
				{
					continue;
				}
				Vec3Int a = stockpile.GridDataPosition;
				if (PathfinderUtil.IsPathPossible(trader, a))
				{
					float num2 = Vec3Int.Distance(in a, in b);
					if (stockpileInstance == null || num2 < num)
					{
						stockpileInstance = stockpile;
						num = num2;
					}
				}
			}
			if (stockpileInstance != null)
			{
				Vec3Int position = stockpileInstance.Positions.Where((Vec3Int pos) => pos != Vec3Int.zero).PickRandom();
				return GetRandomPoint(trader, position, maximumRadius, skipOutOfRangeTemperatures: false);
			}
			return trader.GetNode();
		}

		private void SortNodesPenaltyTemperature(CreatureBase creature, List<MapNode> possibleNodes)
		{
			TemperatureManager tempManager = map.TemperatureManager;
			PathfindingPenalty pathfindingPenalty = creature.WalkableModel.PathfindingPenalty;
			possibleNodes.Sort(delegate(MapNode a, MapNode b)
			{
				int num = a.GetPenalty(pathfindingPenalty) + tempManager.GetNodeTemperaturePriority(creature, a) * 65535;
				int num2 = b.GetPenalty(pathfindingPenalty) + tempManager.GetNodeTemperaturePriority(creature, b) * 65535;
				return num - num2;
			});
		}

		private void SortNodesWaterFirst(CreatureBase creature, List<MapNode> possibleNodes)
		{
			SnowGrassWetnessManager snowGrassWetnessManager = map.SnowGrassWetnessManager;
			_ = creature.WalkableModel.PathfindingPenalty;
			possibleNodes.Sort(delegate(MapNode a, MapNode b)
			{
				int num = (int)a.WaterDepthLevel * 256 + snowGrassWetnessManager.GetWetness(a.Index);
				return (int)b.WaterDepthLevel * 256 + snowGrassWetnessManager.GetWetness(b.Index) - num;
			});
		}

		private void SortNodesPenaltyTemperatureDistance(CreatureBase creature, List<MapNode> possibleNodes)
		{
			if (CombatUtils.IsNullOrDisposed(creature))
			{
				return;
			}
			Vec3Int agentPosition = creature.GetNode().Position;
			PathfindingPenalty pathfindingPenalty = creature.WalkableModel.PathfindingPenalty;
			TemperatureManager tempManager = map.TemperatureManager;
			possibleNodes.Sort(delegate(MapNode a, MapNode b)
			{
				int num = a.GetPenalty(pathfindingPenalty) + tempManager.GetNodeTemperaturePriority(creature, a) * 65535;
				int num2 = b.GetPenalty(pathfindingPenalty) + tempManager.GetNodeTemperaturePriority(creature, b) * 65535;
				if (num == num2)
				{
					int num3 = (int)(10f * (agentPosition - a.Position).magnitude);
					int num4 = (int)(10f * (agentPosition - b.Position).magnitude);
					return num3 - num4;
				}
				return num - num2;
			});
		}
	}
}
