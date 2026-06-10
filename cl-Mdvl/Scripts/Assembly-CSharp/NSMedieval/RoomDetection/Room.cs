using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using FoxyVoxel.Logging;
using FoxyVoxel.Logging.Core.LogMessageInterpolationHandlers;
using NSEipix;
using NSEipix.Base;
using NSEipix.Model;
using NSEipix.Repository;
using NSMedieval.BuildingComponents;
using NSMedieval.Construction;
using NSMedieval.Enums;
using NSMedieval.Goap;
using NSMedieval.Manager;
using NSMedieval.Map;
using NSMedieval.Production;
using NSMedieval.Repository;
using NSMedieval.State;
using NSMedieval.Types;
using NSMedieval.Utils.Pool;
using NSMedieval.Utils.Pool.Janitors;
using NSMedieval.Village;
using NSMedieval.Village.Map;
using NSMedieval.Village.Map.Pathfinding;
using UnityEngine;

namespace NSMedieval.RoomDetection
{
	public class Room
	{
		private readonly HashSet<MapNode> roofNodes = new HashSet<MapNode>();

		private readonly HashSet<MapNode> volumeNodes = new HashSet<MapNode>();

		private readonly HashSet<MapNode> wallNodes = new HashSet<MapNode>();

		private readonly HashSet<MapNode> cornerWallNodes = new HashSet<MapNode>();

		private readonly HashSet<BaseBuildingInstance> doors = new HashSet<BaseBuildingInstance>();

		private readonly Dictionary<HumanoidInstance, List<BaseBuildingInstance>> ownershipByWorker = new Dictionary<HumanoidInstance, List<BaseBuildingInstance>>();

		private readonly Dictionary<string, int> resourceCount = new Dictionary<string, int>();

		private readonly ConcurrentDictionary<string, int> buildableCountByBlueprint = new ConcurrentDictionary<string, int>();

		private readonly ConcurrentDictionary<BuildingType, int> countByBuildingType = new ConcurrentDictionary<BuildingType, int>();

		private readonly ConcurrentHashSet<WorldObject> roomContent = new ConcurrentHashSet<WorldObject>();

		private readonly ConcurrentHashSet<WorldObject> roomContentUnfinished = new ConcurrentHashSet<WorldObject>();

		private readonly ConcurrentDictionary<string, ConcurrentHashSet<PlantMapResourceInstance>> plantsInRoom = new ConcurrentDictionary<string, ConcurrentHashSet<PlantMapResourceInstance>>();

		private bool needFreeSpaceUpdate;

		private bool needAverageBeautyUpdate;

		private bool wealthUpdated;

		private float totalWealth;

		private int impressivenessScore;

		private bool impressivenessFirstCheck;

		private float prevAverageTemperature;

		private RoomImpressivenessSettings.Setting impressiveness;

		private IRoleOwner rolePresent;

		private bool isContentRenderCulled;

		private WorldDirection hasOpenPortals;

		public HashSet<Region> Regions { get; }

		public HashSet<MapNode> AllNodes { get; } = new HashSet<MapNode>();

		public List<int> YLevels { get; }

		public HashSet<MapNode> BelowFloorNodes { get; } = new HashSet<MapNode>();

		public RoomType RoomType { get; private set; }

		public HashSet<MapNode> WallNodes => wallNodes;

		public HashSet<MapNode> CornerWallNodes => cornerWallNodes;

		public IEnumerable<BaseBuildingInstance> Doors => doors;

		public ConcurrentDictionary<string, ConcurrentHashSet<PlantMapResourceInstance>> PlantsInRoom => plantsInRoom;

		public Dictionary<HumanoidInstance, List<BaseBuildingInstance>> OwnershipByWorker => ownershipByWorker;

		public VillageMap Map { get; }

		public Vec3Int Center { get; private set; }

		public int FreeSpace { get; private set; }

		public float AverageBeauty { get; private set; }

		public float AverageTemperature { get; private set; }

		public bool HasRoofs { get; private set; }

		public float TotalWealth
		{
			get
			{
				return totalWealth;
			}
			private set
			{
				wealthUpdated = true;
				totalWealth = value;
			}
		}

		public float HighestPoint
		{
			get
			{
				List<int> yLevels = YLevels;
				return yLevels[yLevels.Count - 1] * World.MapBlockHeight;
			}
		}

		public WorldDirection HasOpenPortals => hasOpenPortals;

		public bool IsContentRenderCulled
		{
			get
			{
				return isContentRenderCulled;
			}
			set
			{
				if (isContentRenderCulled == value)
				{
					return;
				}
				isContentRenderCulled = value;
				foreach (WorldObject item in roomContent)
				{
					item.GetView()?.RefreshVisibility();
				}
				foreach (WorldObject item2 in roomContentUnfinished)
				{
					item2.GetView()?.RefreshVisibility();
				}
			}
		}

		public int ImpressivenessScore => impressivenessScore;

		public RoomImpressivenessSettings.Setting Impressiveness => impressiveness;

		public IRoleOwner RolePresent => rolePresent;

		public IEnumerable<WorldObject> IterateRoomContent()
		{
			foreach (WorldObject item in roomContent)
			{
				yield return item;
			}
		}

		public override string ToString()
		{
			return string.Format("{0}: {1}, {2}: {3}", "RoomType", RoomType, "Center", Center);
		}

		public void AddRolePresent(IRoleOwner roleOwner)
		{
			if (rolePresent?.RoleInstance == null)
			{
				rolePresent = roleOwner;
			}
			else if (rolePresent.RoleInstance.Level <= roleOwner.RoleInstance.Level)
			{
				rolePresent = roleOwner;
			}
		}

		public void RemoveRolePresent(IRoleOwner roleOwner)
		{
			if (roleOwner == rolePresent)
			{
				rolePresent = null;
			}
		}

		public IEnumerable<RoleEffectorData> GetRoleRoomEnterEffectors()
		{
			return rolePresent?.RoleInstance?.GetOnRoleRoomEnterEffectorIds();
		}

		public IEnumerable<RoleEffectorData> GetRoleRoomStayEffectors()
		{
			return rolePresent?.RoleInstance?.GetOnRoleRoomStayEffectorIds();
		}

		public Room(VillageMap map, HashSet<Region> regions, HashSet<MapNode> noRegionNodes)
		{
			Map = map;
			Regions = new HashSet<Region>(regions);
			foreach (MapNode noRegionNode in noRegionNodes)
			{
				if (noRegionNode.Region != null)
				{
					Regions.Add(noRegionNode.Region);
				}
			}
			AllNodes.Clear();
			foreach (Region region in Regions)
			{
				AllNodes.UnionWith(region.Nodes);
			}
			volumeNodes.Clear();
			volumeNodes.UnionWith(AllNodes);
			volumeNodes.UnionWith(noRegionNodes);
			using PooledHashSet<int> pooledHashSet = HashSetPool<int>.GetJanitor();
			foreach (MapNode allNode in AllNodes)
			{
				pooledHashSet.Add(allNode.Position.y);
			}
			YLevels = pooledHashSet.ToList();
			YLevels.Sort();
			needFreeSpaceUpdate = true;
			needAverageBeautyUpdate = true;
			impressivenessScore = 0;
			impressivenessFirstCheck = true;
		}

		public void ClearAll()
		{
			roofNodes.Clear();
			volumeNodes.Clear();
			wallNodes.Clear();
			cornerWallNodes.Clear();
			foreach (List<BaseBuildingInstance> value in ownershipByWorker.Values)
			{
				value.Clear();
			}
			ownershipByWorker.Clear();
			resourceCount.Clear();
			buildableCountByBlueprint.Clear();
			countByBuildingType.Clear();
			roomContent.Clear();
			roomContentUnfinished.Clear();
			foreach (ConcurrentHashSet<PlantMapResourceInstance> value2 in plantsInRoom.Values)
			{
				value2.Clear();
			}
			plantsInRoom.Clear();
			Regions.Clear();
			AllNodes.Clear();
			BelowFloorNodes.Clear();
		}

		public void TickImpressiveness()
		{
			bool num = needFreeSpaceUpdate || needAverageBeautyUpdate || wealthUpdated;
			if (needFreeSpaceUpdate)
			{
				needFreeSpaceUpdate = false;
				CalculateFreeSpace();
			}
			if (needAverageBeautyUpdate)
			{
				needAverageBeautyUpdate = false;
				CalculateAverageBeauty();
			}
			if (!num)
			{
				return;
			}
			int num2 = impressivenessScore;
			impressivenessScore = (int)GetImpressivenessScore();
			wealthUpdated = false;
			if (impressivenessFirstCheck || num2 != impressivenessScore)
			{
				impressivenessFirstCheck = false;
				RoomImpressivenessSettings.Setting setting = impressiveness;
				impressiveness = Map.RoomDetection.RoomImpressivenessSettings.GetImpressivenessSetting(impressivenessScore);
				MonoSingleton<RoomDetectionController>.Instance.RoomImpressivenessScoreChanged(this, num2);
				if (setting != impressiveness)
				{
					MonoSingleton<RoomDetectionController>.Instance.RoomImpressivenessChanged(this, setting);
				}
			}
		}

		public void TickAverageTemperature()
		{
			AverageTemperature = CalculateAverageTemperature();
			if ((int)prevAverageTemperature != (int)AverageTemperature)
			{
				prevAverageTemperature = AverageTemperature;
			}
		}

		public void GatherDoors()
		{
			doors.Clear();
			foreach (WorldObject item in roomContent)
			{
				if (item is BaseBuildingInstance baseBuildingInstance && (baseBuildingInstance.BuildingType & BuildingType.AnyDoor) != 0)
				{
					doors.Add(baseBuildingInstance);
				}
			}
		}

		public BaseBuildingInstance GetFurnitureById(string furnitureId)
		{
			foreach (BaseBuildingInstance item in IterateRoomFurniture())
			{
				if (item.Blueprint.ProtoId.Equals(furnitureId) || item.Blueprint.GetID().Equals(furnitureId))
				{
					return item;
				}
			}
			return null;
		}

		public IEnumerable<BaseBuildingInstance> IterateRoomFurniture()
		{
			foreach (WorldObject item in roomContent)
			{
				if (item is BaseBuildingInstance baseBuildingInstance && baseBuildingInstance.Blueprint.Furniture())
				{
					yield return baseBuildingInstance;
				}
			}
		}

		public int GetResourceCount(string resourceId)
		{
			return resourceCount.GetValueOrDefault(resourceId);
		}

		public void CalculateHasOpenPortals()
		{
			using (ProfilerSampleJanitor.Begin("RoomDetection.CalculateHasOpenPortals"))
			{
				hasOpenPortals = WorldDirection.None;
				Vector2 vector = Center.ToVector3World().ToVector2XZ();
				foreach (MapNode wallNode in WallNodes)
				{
					if (hasOpenPortals == (WorldDirection.N | WorldDirection.E | WorldDirection.S | WorldDirection.W))
					{
						break;
					}
					if ((wallNode.BuildingType & (BuildingType.AnyDoor | BuildingType.Window)) == 0)
					{
						continue;
					}
					BaseBuildingInstance baseBuildingInstance = (BaseBuildingInstance)wallNode.GetWorldObject(WorldObjectType.Building, (WorldObject obj) => obj is BaseBuildingInstance baseBuildingInstance2 && (baseBuildingInstance2.BuildingType & (BuildingType.AnyDoor | BuildingType.Window)) != 0);
					if ((wallNode.BuildingType & BuildingType.Window) != 0)
					{
						WindowComponentInstance componentInstance = baseBuildingInstance.GetComponentInstance<WindowComponentInstance>();
						if (componentInstance != null && componentInstance.LockState == LockState.Locked)
						{
							continue;
						}
					}
					else
					{
						if ((wallNode.BuildingType & BuildingType.AnyDoor) == 0)
						{
							continue;
						}
						DoorComponentInstance componentInstance2 = baseBuildingInstance.GetComponentInstance<DoorComponentInstance>();
						if (componentInstance2 == null || (componentInstance2.LockState != LockState.AlwaysOpen && componentInstance2.LockState != LockState.ForcedOpen))
						{
							continue;
						}
					}
					Vector2 normalized = (wallNode.WorldPosition.ToVector2XZ() - vector).normalized;
					int num = (int)baseBuildingInstance.GetAngle();
					if (num == 0 || num == 180)
					{
						if (Vector2.Dot(Vector2.up, normalized) > 0f)
						{
							hasOpenPortals |= WorldDirection.N;
						}
						if (Vector2.Dot(Vector2.down, normalized) > 0f)
						{
							hasOpenPortals |= WorldDirection.S;
						}
					}
					if (num == 90 || num == 270)
					{
						if (Vector2.Dot(Vector2.right, normalized) > 0f)
						{
							hasOpenPortals |= WorldDirection.E;
						}
						if (Vector2.Dot(Vector2.left, normalized) > 0f)
						{
							hasOpenPortals |= WorldDirection.W;
						}
					}
				}
			}
		}

		public void GatherFloorAndRoofNodes(HashSet<MapNode> noRegionNodes)
		{
			BelowFloorNodes.Clear();
			foreach (MapNode allNode in AllNodes)
			{
				MapNode nodeBelow = allNode.GetNodeBelow();
				if (nodeBelow != null && !volumeNodes.Contains(nodeBelow))
				{
					BelowFloorNodes.Add(nodeBelow);
				}
			}
			roofNodes.Clear();
			HasRoofs = false;
			foreach (MapNode noRegionNode in noRegionNodes)
			{
				MapNode nodeAbove = noRegionNode.GetNodeAbove();
				if (nodeAbove != null && !volumeNodes.Contains(nodeAbove))
				{
					if (!HasRoofs && (nodeAbove.BuildingType & BuildingType.Roof) != 0)
					{
						HasRoofs = true;
					}
					roofNodes.Add(nodeAbove);
				}
			}
		}

		public void DrawGizmos()
		{
			Color color = Gizmos.color;
			Gizmos.color = Color.magenta;
			foreach (MapNode roofNode in roofNodes)
			{
				Gizmos.DrawCube(roofNode.WorldPosition, Vector3.one * 0.25f);
			}
			Gizmos.color = Color.yellow;
			foreach (MapNode belowFloorNode in BelowFloorNodes)
			{
				Gizmos.DrawCube(belowFloorNode.WorldPosition, Vector3.one * 0.25f);
			}
			Gizmos.color = Color.gray;
			foreach (MapNode volumeNode in volumeNodes)
			{
				Gizmos.DrawCube(volumeNode.WorldPosition, Vector3.one * 0.25f);
			}
			Gizmos.color = Color.blue;
			foreach (MapNode wallNode in wallNodes)
			{
				Gizmos.DrawCube(wallNode.WorldPosition, Vector3.one * 0.25f);
			}
			Gizmos.color = new Color(0f, 0f, 0f, 0.3f);
			foreach (MapNode cornerWallNode in cornerWallNodes)
			{
				Gizmos.DrawCube(cornerWallNode.WorldPosition, Vector3.one * 0.5f);
			}
			Gizmos.color = Color.red;
			Gizmos.DrawSphere(GridUtils.GetWorldPosition(Center), 1f);
			Gizmos.color = color;
		}

		public void CreateWallNodes()
		{
			wallNodes.Clear();
			BuildingType buildingType = BuildingType.Wall | BuildingType.Window | BuildingType.Door;
			foreach (MapNode volumeNode in volumeNodes)
			{
				Vec3Int[] neighborsXZ = MapNodeUtils.NeighborsXZ;
				for (int i = 0; i < neighborsXZ.Length; i++)
				{
					Vec3Int a = neighborsXZ[i];
					Vec3Int gridPosition = a + volumeNode.Position;
					MapNode node = Map.GetNode(gridPosition);
					if (node != null && !volumeNodes.Contains(node) && (!node.IsVoxelAir() || (node.BuildingType & buildingType) != 0))
					{
						wallNodes.Add(node);
					}
				}
			}
		}

		public void CalculateCornerWallNodes()
		{
			cornerWallNodes.Clear();
			foreach (MapNode wallNode in wallNodes)
			{
				bool flag = false;
				Vec3Int[] neighborsXZNonDiagonal = MapNodeUtils.NeighborsXZNonDiagonal;
				for (int i = 0; i < neighborsXZNonDiagonal.Length; i++)
				{
					Vec3Int a = neighborsXZNonDiagonal[i];
					Vec3Int gridPosition = a + wallNode.Position;
					MapNode node = Map.GetNode(gridPosition);
					if (node != null && !wallNodes.Contains(node) && volumeNodes.Contains(node))
					{
						flag = true;
						break;
					}
				}
				if (!flag)
				{
					cornerWallNodes.Add(wallNode);
				}
			}
		}

		public void FillRoomContent()
		{
			ownershipByWorker.Clear();
			using PooledHashSet<WorldObject> pooledHashSet = HashSetPool<WorldObject>.GetJanitor();
			using (HashSetPool<PlantMapResourceInstance>.GetJanitor())
			{
				foreach (MapNode volumeNode in volumeNodes)
				{
					if (volumeNode?.WorldObjects != null)
					{
						pooledHashSet.UnionWith(volumeNode.WorldObjects);
					}
				}
				foreach (MapNode wallNode in wallNodes)
				{
					if (wallNode?.WorldObjects == null)
					{
						continue;
					}
					foreach (WorldObject worldObject in wallNode.WorldObjects)
					{
						if (worldObject.HasDisposed)
						{
							continue;
						}
						if (worldObject.Type == WorldObjectType.Building)
						{
							BaseBuildingInstance baseBuildingInstance = (BaseBuildingInstance)worldObject;
							if ((baseBuildingInstance.BuildingType & BuildingType.ProductionBuilding) != 0 || baseBuildingInstance.ConstructionPhase != ConstructionPhase.Finished)
							{
								continue;
							}
							pooledHashSet.Add(baseBuildingInstance);
						}
						if (worldObject.Type == WorldObjectType.ResourcePile || worldObject.Type == WorldObjectType.MapResource)
						{
							pooledHashSet.Add(worldObject);
						}
					}
				}
				TotalWealth = 0f;
				roomContentUnfinished.Clear();
				foreach (WorldObject item in pooledHashSet)
				{
					if (item.Type == WorldObjectType.Building && item is BaseBuildingInstance { ConstructionPhase: not ConstructionPhase.Finished })
					{
						roomContentUnfinished.Add(item);
					}
				}
				pooledHashSet.ExceptWith(roomContentUnfinished);
				plantsInRoom.Clear();
				roomContent.Clear();
				roomContent.UnionWith(pooledHashSet);
				foreach (WorldObject item2 in roomContent)
				{
					if (item2.Type == WorldObjectType.MapResource)
					{
						if (!resourceCount.TryAdd(item2.BlueprintId, 1))
						{
							resourceCount[item2.BlueprintId]++;
						}
						if (item2 is PlantMapResourceInstance plant)
						{
							AddPlant(plant);
						}
					}
					if (item2.Type != WorldObjectType.ResourcePile)
					{
						continue;
					}
					ResourcePileInstance obj = (ResourcePileInstance)item2;
					int num = 0;
					foreach (ResourceInstance resource in obj.GetStorage().Resources)
					{
						num += resource.Amount;
					}
					if (!resourceCount.TryAdd(item2.BlueprintId, num))
					{
						resourceCount[item2.BlueprintId] += num;
					}
				}
				PooledDictionary<string, int> janitor = DictionaryPool<string, int>.GetJanitor();
				try
				{
					PooledDictionary<BuildingType, int> janitor2 = DictionaryPool<BuildingType, int>.GetJanitor();
					try
					{
						foreach (WorldObject item3 in pooledHashSet)
						{
							if (item3 is BaseBuildingInstance baseBuildingInstance3)
							{
								if (baseBuildingInstance3.ConstructionPhase != ConstructionPhase.Finished)
								{
									continue;
								}
								if (!janitor2.TryAdd(baseBuildingInstance3.BuildingType, 1))
								{
									janitor2[baseBuildingInstance3.BuildingType]++;
								}
								AddToOwners(baseBuildingInstance3);
								TotalWealth += baseBuildingInstance3.GetWealth();
							}
							if (item3.Type == WorldObjectType.Building && !janitor.TryAdd(item3.BlueprintId, 1))
							{
								janitor[item3.BlueprintId]++;
							}
						}
						buildableCountByBlueprint.Clear();
						foreach (KeyValuePair<string, int> item4 in janitor)
						{
							buildableCountByBlueprint.TryAdd(item4.Key, item4.Value);
						}
						countByBuildingType.Clear();
						foreach (KeyValuePair<BuildingType, int> item5 in janitor2)
						{
							countByBuildingType.TryAdd(item5.Key, item5.Value);
						}
					}
					finally
					{
						((IDisposable)janitor2/*cast due to .constrained prefix*/).Dispose();
					}
				}
				finally
				{
					((IDisposable)janitor/*cast due to .constrained prefix*/).Dispose();
				}
			}
		}

		private void AddPlant(PlantMapResourceInstance plant)
		{
			string blueprintId = plant.BlueprintId;
			if (!plantsInRoom.ContainsKey(blueprintId))
			{
				plantsInRoom.TryAdd(blueprintId, new ConcurrentHashSet<PlantMapResourceInstance>());
			}
			plantsInRoom[blueprintId].Add(plant);
		}

		private void RemovePlant(PlantMapResourceInstance plant)
		{
			string blueprintId = plant.BlueprintId;
			if (plantsInRoom.TryGetValue(blueprintId, out var value))
			{
				value.Remove(plant);
			}
		}

		public Vector3 GetAveragePosition()
		{
			Vec3Int a = Vec3Int.zero;
			int num = 0;
			foreach (Region region in Regions)
			{
				foreach (MapNode node in region.Nodes)
				{
					a += node.Position;
				}
				num += region.Nodes.Count;
			}
			return GridUtils.GetWorldPosition(a) / num;
		}

		public void CalculateCenter()
		{
			Center = Vec3Int.zero;
			foreach (MapNode wallNode in wallNodes)
			{
				Center += wallNode.Position;
			}
			Center /= wallNodes.Count;
		}

		public void JoinWith(List<Room> toJoin)
		{
			foreach (Room item in toJoin)
			{
				Regions.UnionWith(item.Regions);
				AllNodes.UnionWith(item.AllNodes);
				volumeNodes.UnionWith(item.volumeNodes);
				wallNodes.UnionWith(item.wallNodes);
			}
			wallNodes.ExceptWith(AllNodes);
			CalculateCornerWallNodes();
		}

		public void CalculateRoomType(bool fireRoomTypeChangeEvent)
		{
			RoomType roomType = RoomType;
			bool flag = false;
			RoomType defaultRoomType = Repository<RoomTypeRepository, RoomType>.Instance.DefaultRoomType;
			foreach (RoomType item in Repository<RoomTypeRepository, RoomType>.Instance.GetRoomTypesByPriority())
			{
				if (item == defaultRoomType || !item.CheckRoom(this))
				{
					continue;
				}
				RoomType = item;
				if (!GlobalSaveController.CurrentVillageData.IsSecondMapThreadSafe)
				{
					if (ThreadingJobSystem.IsMainThread)
					{
						MonoSingleton<AchievementManager>.Instance.UnlockAchievement(RoomType.UnlockAchievementOnBuilt);
					}
					else
					{
						MonoSingleton<ThreadingJobSystem>.Instance.ExecuteOnMainThread(delegate
						{
							if (MonoSingleton<AchievementManager>.IsInstantiated() && RoomType != null && !string.IsNullOrEmpty(RoomType.UnlockAchievementOnBuilt))
							{
								MonoSingleton<AchievementManager>.Instance.UnlockAchievement(RoomType.UnlockAchievementOnBuilt);
							}
						});
					}
				}
				flag = true;
				break;
			}
			if (!flag && RoomType != defaultRoomType)
			{
				RoomType = defaultRoomType;
			}
			bool flag2 = roomType != null && fireRoomTypeChangeEvent && RoomType != roomType;
			MonoSingleton<RoomDetectionController>.Instance.RoomTypeRecalculated(this, flag2);
			if (flag2)
			{
				MonoSingleton<RoomDetectionController>.Instance.RoomTypeChanged(this, roomType);
			}
			CalculateHasOpenPortals();
		}

		public bool ContainsDoor(BaseBuildingInstance door)
		{
			return Doors.Contains(door);
		}

		public int GetBuildingContentCount(string blueprintId)
		{
			return buildableCountByBlueprint.GetValueOrDefault(blueprintId, 0);
		}

		public int GetBuildingTypeCount(BuildingType buildingType)
		{
			return countByBuildingType.GetValueOrDefault(buildingType, 0);
		}

		public string GetRoomTypeLocalized()
		{
			if (RoomType.CanBeIndividual && ownershipByWorker.Count == 1)
			{
				HumanoidInstance humanoidInstance = ownershipByWorker.Keys.FirstOrDefault();
				if (humanoidInstance != null)
				{
					return RoomType.NameIndividualRoomLocalized.Replace("<name>", humanoidInstance.GetFullName());
				}
				Log.Info("Returning room name without owner name (but owner name should exist).", "C:\\GIT\\dev\\Assets\\Scripts\\RoomDetection\\Room.cs");
			}
			return RoomType.NameLocalized;
		}

		public void AddToContent(WorldObject worldObject)
		{
			if (worldObject == null || worldObject.HasDisposed)
			{
				return;
			}
			roomContentUnfinished.Remove(worldObject);
			if (!roomContent.Add(worldObject))
			{
				return;
			}
			if (worldObject.Type == WorldObjectType.MapResource)
			{
				if (!resourceCount.TryAdd(worldObject.BlueprintId, 1))
				{
					resourceCount[worldObject.BlueprintId]++;
				}
				if (worldObject is PlantMapResourceInstance plant)
				{
					AddPlant(plant);
				}
			}
			if (worldObject.Type == WorldObjectType.ResourcePile)
			{
				ResourcePileInstance obj = (ResourcePileInstance)worldObject;
				int num = 0;
				foreach (ResourceInstance resource in obj.GetStorage().Resources)
				{
					num += resource.Amount;
				}
				if (!resourceCount.TryAdd(worldObject.BlueprintId, num))
				{
					resourceCount[worldObject.BlueprintId] += num;
				}
			}
			if (worldObject.Type == WorldObjectType.Building && !buildableCountByBlueprint.TryAdd(worldObject.BlueprintId, 1))
			{
				buildableCountByBlueprint[worldObject.BlueprintId]++;
			}
			if (worldObject is BaseBuildingInstance baseBuildingInstance)
			{
				if (!countByBuildingType.TryAdd(baseBuildingInstance.BuildingType, 1))
				{
					countByBuildingType[baseBuildingInstance.BuildingType]++;
				}
				AddToOwners(baseBuildingInstance);
				TotalWealth += baseBuildingInstance.GetWealth();
			}
			if (worldObject is BaseBuildingInstance { BuildingType: BuildingType.Door } baseBuildingInstance2 && !doors.Contains(baseBuildingInstance2))
			{
				doors.Add(baseBuildingInstance2);
			}
			if (worldObject.Type == WorldObjectType.Building || worldObject.Type == WorldObjectType.Slope || worldObject.Type == WorldObjectType.MapResource)
			{
				Map.RoomDetection.ScheduleRoomTypeCheck(this);
			}
			if (worldObject.Type == WorldObjectType.ResourcePile && ResourceRepository.IsResourceInRoomTypes(worldObject.BlueprintId))
			{
				Map.RoomDetection.ScheduleRoomTypeCheck(this);
			}
			needFreeSpaceUpdate = true;
			needAverageBeautyUpdate = true;
		}

		public void RemoveFromContent(WorldObject worldObject)
		{
			if (worldObject == null)
			{
				return;
			}
			roomContentUnfinished.Remove(worldObject);
			if (roomContent.Remove(worldObject))
			{
				if (worldObject.Type == WorldObjectType.MapResource && resourceCount.ContainsKey(worldObject.BlueprintId))
				{
					resourceCount[worldObject.BlueprintId]--;
				}
				if (worldObject.Type == WorldObjectType.ResourcePile)
				{
					ResourcePileInstance obj = (ResourcePileInstance)worldObject;
					int num = 0;
					foreach (ResourceInstance resource in obj.GetStorage().Resources)
					{
						num += resource.Amount;
					}
					if (resourceCount.ContainsKey(worldObject.BlueprintId))
					{
						resourceCount[worldObject.BlueprintId] -= num;
					}
				}
				if (worldObject.Type == WorldObjectType.Building && buildableCountByBlueprint.ContainsKey(worldObject.BlueprintId))
				{
					buildableCountByBlueprint[worldObject.BlueprintId]--;
					if (buildableCountByBlueprint[worldObject.BlueprintId] < 0)
					{
						bool isEnabled;
						FVLogInfoInterpolationHandler messageBuilder = new FVLogInfoInterpolationHandler(39, 1, out isEnabled, "C:\\GIT\\dev\\Assets\\Scripts\\RoomDetection\\Room.cs");
						if (isEnabled)
						{
							messageBuilder.AppendLiteral("RoomDetection: Less than 0 of ");
							messageBuilder.AppendFormatted(worldObject.BlueprintId);
							messageBuilder.AppendLiteral(" in room.");
						}
						Log.Info(messageBuilder);
					}
				}
				if (worldObject is BaseBuildingInstance baseBuildingInstance)
				{
					if (countByBuildingType.ContainsKey(baseBuildingInstance.BuildingType))
					{
						countByBuildingType[baseBuildingInstance.BuildingType]--;
					}
					RemoveFromOwners(baseBuildingInstance);
					TotalWealth -= baseBuildingInstance.GetWealth();
					doors.Remove(baseBuildingInstance);
				}
				if (worldObject.Type == WorldObjectType.Building || worldObject.Type == WorldObjectType.Slope || worldObject.Type == WorldObjectType.MapResource)
				{
					Map.RoomDetection.ScheduleRoomTypeCheck(this);
				}
				if (worldObject.Type == WorldObjectType.ResourcePile)
				{
					if (ResourceRepository.IsResourceInRoomTypes(worldObject.BlueprintId))
					{
						Map.RoomDetection.ScheduleRoomTypeCheck(this);
					}
					if (worldObject is PlantMapResourceInstance plant)
					{
						RemovePlant(plant);
					}
				}
			}
			needFreeSpaceUpdate = true;
			needAverageBeautyUpdate = true;
		}

		public string GetDebugText()
		{
			return $"Impr.: {Impressiveness?.Name} ({impressivenessScore}), \nAvg.Beauty: {AverageBeauty}";
		}

		public bool IsFullyLocked()
		{
			foreach (BaseBuildingInstance door in doors)
			{
				if (door.LockState != LockState.Locked)
				{
					return false;
				}
			}
			return true;
		}

		public void BuildingOwnerUnregistered(BaseBuildingInstance baseBuildableObject, HumanoidInstance oldHumanoid)
		{
			if (ownershipByWorker.ContainsKey(oldHumanoid))
			{
				ownershipByWorker[oldHumanoid].Remove(baseBuildableObject);
				if (ownershipByWorker[oldHumanoid].Count == 0)
				{
					ownershipByWorker.Remove(oldHumanoid);
				}
			}
		}

		public void BuildingOwnerRegistered(BaseBuildingInstance baseBuildableObject)
		{
			AddToOwners(baseBuildableObject);
		}

		public HumanoidInstance GetSingleOwner()
		{
			if (ownershipByWorker.Count == 0)
			{
				return null;
			}
			return ownershipByWorker.Keys.First();
		}

		public List<BaseBuildingInstance> GetOwnedBuildings(HumanoidInstance humanoidInstance)
		{
			return ownershipByWorker.GetValueOrDefault(humanoidInstance);
		}

		private void AddToOwners(BaseBuildingInstance bbo)
		{
			if (bbo.BuildingOwnershipInfo != null && bbo.BuildingOwnershipInfo.Owner != null)
			{
				HumanoidInstance owner = bbo.BuildingOwnershipInfo.Owner;
				if (!ownershipByWorker.ContainsKey(owner))
				{
					ownershipByWorker.Add(owner, new List<BaseBuildingInstance>());
				}
				ownershipByWorker[owner].Add(bbo);
			}
		}

		private float CalculateAverageTemperature()
		{
			float num = 0f;
			TemperatureManager temperatureManager = Map.TemperatureManager;
			foreach (MapNode allNode in AllNodes)
			{
				num += temperatureManager.GetTemperature(allNode.Position);
			}
			return num / (float)AllNodes.Count;
		}

		private void RemoveFromOwners(BaseBuildingInstance bbo)
		{
			if (bbo.BuildingOwnershipInfo == null || !bbo.BuildingOwnershipInfo.Occupied)
			{
				return;
			}
			HumanoidInstance owner = bbo.BuildingOwnershipInfo.Owner;
			if (owner != null && ownershipByWorker.ContainsKey(owner) && ownershipByWorker[owner].Contains(bbo))
			{
				ownershipByWorker[owner].Remove(bbo);
				if (ownershipByWorker[owner].Count == 0)
				{
					ownershipByWorker.Remove(owner);
				}
			}
		}

		private void CalculateFreeSpace()
		{
			FreeSpace = 0;
			foreach (MapNode volumeNode in volumeNodes)
			{
				if ((volumeNode.BuildingType & (BuildingType.Wall | BuildingType.Stairs | BuildingType.ProductionBuilding | BuildingType.Chair | BuildingType.Table | BuildingType.Bed | BuildingType.Shrine | BuildingType.Grave)) == 0)
				{
					FreeSpace++;
				}
			}
		}

		private void CalculateAverageBeauty()
		{
			AverageBeauty = 0f;
			int num = 0;
			foreach (MapNode volumeNode in volumeNodes)
			{
				if (volumeNode.DataType == GridDataType.None)
				{
					if (volumeNode.IsWalkable)
					{
						num++;
					}
				}
				else
				{
					AverageBeauty += volumeNode.BeautyInput - volumeNode.CreaturesBeauty;
					num++;
				}
			}
			if (num > 0)
			{
				AverageBeauty /= num;
			}
		}

		private float GetImpressivenessScore()
		{
			float multiplierInterpolated = Map.RoomDetection.RoomWealthList.GetMultiplierInterpolated((int)TotalWealth);
			float multiplierInterpolated2 = Map.RoomDetection.RoomSpaceList.GetMultiplierInterpolated(FreeSpace);
			float multiplierInterpolated3 = Map.RoomDetection.RoomBeautyList.GetMultiplierInterpolated((int)AverageBeauty);
			return multiplierInterpolated * multiplierInterpolated2 * multiplierInterpolated3;
		}

		public bool TryGetRandomReachablePositionInRoom(CreatureBase agent, out Vec3Int position, FloatRange distanceRange = null, int randomSeed = 0)
		{
			if (CombatUtils.IsNullOrDisposed(agent))
			{
				position = default(Vec3Int);
				return false;
			}
			MapNode mapNode = agent.GetNode();
			position = mapNode.Position;
			VillageMap map = agent.Map;
			Vec3Int b = agent.GetGridPosition();
			map.RoomDetection.GetRoom(b);
			Region region = agent.Map.GetNode(agent.GetGridPosition()).Region;
			if (!PathfinderUtil.IsRegionReachable(agent.WalkableModel, region, Regions.First()))
			{
				return false;
			}
			System.Random random = ((randomSeed == 0) ? new System.Random() : new System.Random(randomSeed));
			int num = 0;
			using PooledList<MapNode> pooledList = ListPool<MapNode>.GetJanitor();
			foreach (MapNode allNode in AllNodes)
			{
				if (!allNode.IsWalkable)
				{
					continue;
				}
				if (allNode.GetPenalty(agent.WalkableModel.PathfindingPenalty) < 4300)
				{
					int index;
					if (allNode.AnyConnection((MapNode connection) => WallNodes.Contains(connection)))
					{
						index = pooledList.Count;
						num++;
					}
					else
					{
						index = random.Next(0, pooledList.Count - num);
					}
					pooledList.Insert(index, allNode);
				}
				else
				{
					int index2 = random.Next(Math.Min(pooledList.Count - num, pooledList.Count), pooledList.Count);
					pooledList.Insert(index2, allNode);
					num++;
				}
			}
			if (distanceRange == null)
			{
				distanceRange = new FloatRange(2f, float.MaxValue);
			}
			foreach (MapNode item in pooledList)
			{
				if (Vec3Int.Distance(item.Position, in b) >= distanceRange.Min && Vec3Int.Distance(item.Position, in b) <= distanceRange.Max)
				{
					mapNode = item;
					break;
				}
			}
			position = mapNode.Position;
			return true;
		}
	}
}
