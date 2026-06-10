using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using FoxyVoxel.Logging;
using FoxyVoxel.Logging.Core.LogMessageInterpolationHandlers;
using NSEipix;
using NSEipix.Base;
using NSMedieval.Goap;
using NSMedieval.Map;
using NSMedieval.Model;
using NSMedieval.State;
using NSMedieval.Tools;
using NSMedieval.Types;
using NSMedieval.Utils;
using NSMedieval.Utils.Pool;
using NSMedieval.Utils.Pool.Janitors;
using NSMedieval.Village;
using NSMedieval.Village.Map;
using NSMedieval.Village.Map.Pathfinding;
using NSMedieval.Water;
using Unity.Mathematics;
using UnityEngine;

namespace NSMedieval.Manager
{
	public class NPCStartPositionManager : MonoSingleton<NPCStartPositionManager>
	{
		public delegate int NodeSortDelegate(MapNode node1, MapNode node2);

		public struct LastInfo
		{
			public List<MapNode> LastStartingNodes;

			public MapNode LastTargetNode;

			public List<WorldObject> Beds;

			public List<WorldObject> Doors;

			public List<WorldObject> ProductionBuildings;

			public List<Vector3> PossibleTargetPositions;

			public bool PathGenerated;

			public List<Path> Paths;

			public int TargetCount;

			public int Iterations;

			public bool DisplayInfo;

			public bool Success;
		}

		private static int noise3dSeed;

		private LastInfo info;

		public LastInfo LastSearchInfo => info;

		[RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.BeforeSceneLoad)]
		public new static void OnDomainReload()
		{
			noise3dSeed = 0;
		}

		protected override void OnDestroy()
		{
			base.OnDestroy();
		}

		public static void SetStartPositionsForAgentsRandom(WalkableModel walkableModel, IReadOnlyList<IPathfindingAgent> agents, ISet<Region> mustBeReachable)
		{
			List<MapNode> nodesNearEdge = GetNodesNearEdge(8, CompareNodeDistanceToEdges, skipUnderwaterNodes: true, removeInaccessibleRegions: true);
			if (nodesNearEdge.Count < agents.Count)
			{
				nodesNearEdge = GetNodesNearEdge(16, null, skipUnderwaterNodes: false);
			}
			nodesNearEdge.ShuffleInPlace();
			using PooledList<MapNode> pooledList = nodesNearEdge.ToPooledListJanitor();
			HashSet<MapNode> hashSet = new HashSet<MapNode>();
			while (hashSet.Count < agents.Count && pooledList.Count > 0)
			{
				MapNode mapNode = pooledList.PickRandom();
				pooledList.Remove(mapNode);
				if (!mapNode.IsWalkable)
				{
					continue;
				}
				bool flag = false;
				foreach (Region item in mustBeReachable)
				{
					if (PathfinderUtil.IsRegionReachable(walkableModel, mapNode.Region, item))
					{
						flag = true;
						break;
					}
				}
				if (flag)
				{
					hashSet.Add(mapNode);
				}
			}
			if (hashSet.Count < agents.Count)
			{
				bool isEnabled;
				FVLogErrorInterpolationHandler messageBuilder = new FVLogErrorInterpolationHandler(99, 2, out isEnabled, "C:\\GIT\\dev\\Assets\\Scripts\\Managers\\NPCStartPositionManager.cs");
				if (isEnabled)
				{
					messageBuilder.AppendLiteral("Could not find enough start positions. Agents count: ");
					messageBuilder.AppendFormatted(agents.Count);
					messageBuilder.AppendLiteral(", spawnNodes count: ");
					messageBuilder.AppendFormatted(hashSet?.Count);
					messageBuilder.AppendLiteral(", picking random positions");
				}
				Log.Error(messageBuilder);
			}
			foreach (IPathfindingAgent agent in agents)
			{
				if (hashSet.Count == 0)
				{
					MapNode mapNode2 = nodesNearEdge.PickRandom();
					agent.UpdatePosition(mapNode2.WorldPosition);
				}
				else
				{
					MapNode mapNode3 = hashSet.PickRandom();
					hashSet.Remove(mapNode3);
					agent.UpdatePosition(mapNode3.WorldPosition);
				}
			}
		}

		public static void SetStartPositionsForAgents(WalkableModel walkableModel, IReadOnlyList<IPathfindingAgent> agents, Action<MapNode, IPathfindingAgent> customPlaceAction = null, System.Random random = null)
		{
			if (random == null)
			{
				random = new System.Random();
			}
			MonoSingleton<NPCStartPositionManager>.Instance.GetStartAndTarget(walkableModel, out var _, out var outStartingNodes, agents.Count, int.MaxValue, onlyTargetReachable: true, random);
			if (outStartingNodes.Count < agents.Count)
			{
				List<MapNode> nodesNearEdge = GetNodesNearEdge(8, null, skipUnderwaterNodes: true, removeInaccessibleRegions: false, random);
				if (nodesNearEdge.Count < agents.Count)
				{
					nodesNearEdge = GetNodesNearEdge(16, null, skipUnderwaterNodes: false, removeInaccessibleRegions: false, random);
				}
				MapNode mapNode = nodesNearEdge.PickRandom(random);
				nodesNearEdge.Remove(mapNode);
				MapNode mapNode2 = mapNode;
				outStartingNodes.Add(mapNode);
				while (outStartingNodes.Count < agents.Count)
				{
					MapNode mapNode3 = null;
					float num = 0f;
					foreach (MapNode item in nodesNearEdge)
					{
						float num2 = (mapNode2.Position - item.Position).sqrMagnitude;
						if (mapNode3 == null || num2 < num)
						{
							num = num2;
							mapNode3 = item;
						}
						if (num2 <= 1f)
						{
							break;
						}
					}
					nodesNearEdge.Remove(mapNode3);
					outStartingNodes.Add(mapNode3);
					mapNode2 = mapNode3;
				}
			}
			if (outStartingNodes.Count < agents.Count)
			{
				bool isEnabled;
				FVLogErrorInterpolationHandler messageBuilder = new FVLogErrorInterpolationHandler(73, 2, out isEnabled, "C:\\GIT\\dev\\Assets\\Scripts\\Managers\\NPCStartPositionManager.cs");
				if (isEnabled)
				{
					messageBuilder.AppendLiteral("Could not find enough start positions. Agents count: ");
					messageBuilder.AppendFormatted(agents.Count);
					messageBuilder.AppendLiteral(", spawnNodes count: ");
					messageBuilder.AppendFormatted(outStartingNodes?.Count);
				}
				Log.Error(messageBuilder);
			}
			foreach (IPathfindingAgent agent in agents)
			{
				MapNode mapNode4 = outStartingNodes.PickRandom(random);
				outStartingNodes.Remove(mapNode4);
				if (customPlaceAction != null)
				{
					customPlaceAction(mapNode4, agent);
				}
				else
				{
					agent.UpdatePosition(mapNode4.WorldPosition);
				}
			}
		}

		public List<MapNode> GetRandomEdgeFloodFill(WalkableModel walkableModel, int positionsToGet, float boundingBoxMinFillPercent, float boundingBoxMaxAspectRatio, bool onlyReachable = true)
		{
			int num = UnityEngine.Random.Range(1, int.MaxValue);
			System.Random random = new System.Random(num);
			bool isEnabled;
			FVLogInfoInterpolationHandler messageBuilder = new FVLogInfoInterpolationHandler(63, 2, out isEnabled, "C:\\GIT\\dev\\Assets\\Scripts\\Managers\\NPCStartPositionManager.cs");
			if (isEnabled)
			{
				messageBuilder.AppendLiteral("Doing random edge flood fill with random seed ");
				messageBuilder.AppendFormatted(num);
				messageBuilder.AppendLiteral(", onlyReachable: ");
				messageBuilder.AppendFormatted(onlyReachable);
			}
			Log.Info(messageBuilder);
			List<MapNode> resultNodes = new List<MapNode>();
			VillageMap map = VillageManager.ActiveVillage.Map;
			RegionAreaManager regionAreaManager = map.RegionAreaManager;
			List<MapNode> allPossibleTargets = GetAllPossibleTargets();
			PooledHashSet<Region> possibleTargetRegions = HashSetPool<Region>.GetJanitor();
			PooledList<MapNode> edgeNodes;
			try
			{
				using PooledHashSet<uint> pooledHashSet = HashSetPool<uint>.GetJanitor();
				using PooledHashSet<Region> pooledHashSet2 = HashSetPool<Region>.GetJanitor();
				foreach (MapNode item in allPossibleTargets)
				{
					Region region = item.Region;
					possibleTargetRegions.Add(region);
				}
				map.RegionAreaManager.GetAreasTouchingEdge(pooledHashSet);
				foreach (KeyValuePair<uint, Area> item2 in regionAreaManager.Areas.Where((KeyValuePair<uint, Area> kvp) => kvp.Value != null && kvp.Value.IsTouchingEdge))
				{
					pooledHashSet2.UnionWith(item2.Value.Regions);
				}
				using PooledHashSet<MapNode> pooledHashSet3 = HashSetPool<MapNode>.GetJanitor();
				using PooledList<MapNode> pooledList = ListPool<MapNode>.GetJanitor();
				using PooledList<MapNode> pooledList2 = ListPool<MapNode>.GetJanitor();
				GetNodesNearEdge(pooledHashSet2, 4, pooledHashSet3);
				foreach (MapNode item3 in pooledHashSet3)
				{
					if (item3.WaterDepthLevel == WaterDepthLevel.None)
					{
						pooledList.Add(item3);
					}
					else
					{
						pooledList2.Add(item3);
					}
				}
				pooledList.ShuffleInPlace(random);
				pooledList2.ShuffleInPlace(random);
				edgeNodes = pooledList;
				edgeNodes.AddRange(pooledList2);
				FindValidFloodFill();
				return resultNodes;
			}
			finally
			{
				((IDisposable)possibleTargetRegions/*cast due to .constrained prefix*/).Dispose();
			}
			int FindValidFloodFill()
			{
				int num2 = 0;
				GridBoundingBox2D gridBoundingBox2D = default(GridBoundingBox2D);
				foreach (Region item4 in possibleTargetRegions)
				{
					foreach (MapNode item5 in edgeNodes)
					{
						if (!onlyReachable || PathfinderUtil.IsRegionReachable(walkableModel, item5.Region, item4))
						{
							num2++;
							resultNodes.Clear();
							gridBoundingBox2D.Clear();
							foreach (MapNode item6 in FloodFillUtil.IterateFloodFillConnections(item5, 1000f, (MapNode node) => !node.IsWalkable))
							{
								if (item6.IsWalkable && (item6.Tag & (MapNodeTags.Enemy | MapNodeTags.Worker)) == 0 && (item6.DataType & (GridDataType.BuildingFinished | GridDataType.Slope | GridDataType.PlantMapResource)) == 0 && !item6.Tag.HasFlag(MapNodeTags.WaterDepthHigh) && !item6.Tag.HasFlag(MapNodeTags.WaterLevelHigh) && !item6.Tag.HasFlag(MapNodeTags.WaterLevelMedium))
								{
									gridBoundingBox2D.AddPoint(item6.Position.x, item6.Position.z);
									resultNodes.Add(item6);
									if (resultNodes.Count >= positionsToGet)
									{
										if (gridBoundingBox2D.AspectRatio > boundingBoxMaxAspectRatio || gridBoundingBox2D.FillPercent < boundingBoxMinFillPercent)
										{
											break;
										}
										bool isEnabled2;
										FVLogInfoInterpolationHandler messageBuilder2 = new FVLogInfoInterpolationHandler(42, 1, out isEnabled2, "C:\\GIT\\dev\\Assets\\Scripts\\Managers\\NPCStartPositionManager.cs");
										if (isEnabled2)
										{
											messageBuilder2.AppendLiteral("Found valid flood fill starting from node ");
											messageBuilder2.AppendFormatted(item5.Position);
										}
										Log.Info(messageBuilder2);
										return num2;
									}
								}
							}
						}
					}
				}
				resultNodes.Clear();
				return num2;
			}
		}

		public bool GetStartAndTarget(WalkableModel walkableModel, out MapNode outTargetNode, out List<MapNode> outStartingNodes, int positionsToGet, int maxDistFromEdge = int.MaxValue, bool onlyTargetReachable = true, System.Random random = null)
		{
			if (random == null)
			{
				random = new System.Random();
			}
			if (maxDistFromEdge == int.MaxValue)
			{
				maxDistFromEdge = 8;
			}
			VillageMap map = VillageManager.ActiveVillage.Map;
			RegionAreaManager regionAreaManager = map.RegionAreaManager;
			bool flag = false;
			int num = 0;
			List<MapNode> allPossibleTargets = GetAllPossibleTargets();
			using PooledHashSet<Region> pooledHashSet = HashSetPool<Region>.GetJanitor();
			PooledHashSet<uint> areasTouchingEdge = HashSetPool<uint>.GetJanitor();
			try
			{
				using PooledHashSet<Region> pooledHashSet2 = HashSetPool<Region>.GetJanitor();
				foreach (MapNode item in allPossibleTargets)
				{
					Region region = item.Region;
					pooledHashSet.Add(region);
				}
				map.RegionAreaManager.GetAreasTouchingEdge(areasTouchingEdge);
				foreach (KeyValuePair<uint, Area> item2 in regionAreaManager.Areas.Where((KeyValuePair<uint, Area> kvp) => kvp.Value != null && kvp.Value.IsTouchingEdge))
				{
					pooledHashSet2.UnionWith(item2.Value.Regions);
				}
				using PooledList<Region> pooledList = ListPool<Region>.GetJanitor();
				pooledList.AddRange(pooledHashSet2);
				pooledList.ShuffleInPlace(random);
				pooledList.Sort(delegate(Region a, Region b)
				{
					WaterDepthLevel waterDepthLevel = map.WaterManager.GetWaterDepthLevel(a.Nodes[0].Index);
					WaterDepthLevel waterDepthLevel2 = map.WaterManager.GetWaterDepthLevel(b.Nodes[0].Index);
					int num2 = (((waterDepthLevel & (WaterDepthLevel.None | WaterDepthLevel.Low)) != 0) ? 1 : 0);
					return (((waterDepthLevel2 & (WaterDepthLevel.None | WaterDepthLevel.Low)) != 0) ? 1 : 0) - num2;
				});
				outTargetNode = null;
				outStartingNodes = new List<MapNode>();
				using PooledHashSet<MapNode> pooledHashSet3 = HashSetPool<MapNode>.GetJanitor();
				GetNodesNearEdge(pooledHashSet2, maxDistFromEdge, pooledHashSet3);
				foreach (Region item3 in pooledHashSet)
				{
					foreach (Region item4 in pooledList)
					{
						if (!onlyTargetReachable || PathfinderUtil.IsRegionReachable(walkableModel, item4, item3))
						{
							num++;
							GetStartNeighborNodes(pooledHashSet3, outStartingNodes, item4, positionsToGet, (MapNode node) => node.IsWalkable && areasTouchingEdge.Contains(node.Area) && (node.Tag & (MapNodeTags.Enemy | MapNodeTags.Worker)) == 0 && (node.DataType & (GridDataType.BuildingFinished | GridDataType.Slope | GridDataType.PlantMapResource)) == 0, random);
							if (outStartingNodes.Count >= positionsToGet)
							{
								flag = true;
								break;
							}
						}
					}
					if (flag)
					{
						break;
					}
				}
				if (!flag)
				{
					outTargetNode = null;
				}
				return flag;
			}
			finally
			{
				((IDisposable)areasTouchingEdge/*cast due to .constrained prefix*/).Dispose();
			}
		}

		private static void GetStartNeighborNodes(ISet<MapNode> edgeNodes, IList<MapNode> outStartingNodes, Region edgeRegion, int positionsToGet, Predicate<MapNode> startPositionFilter, System.Random random = null)
		{
			if (random == null)
			{
				random = new System.Random();
			}
			outStartingNodes.Clear();
			using PooledList<MapNode> pooledList = edgeNodes.WherePooled((MapNode node) => node != null && node.Region == edgeRegion);
			pooledList.ShuffleInPlace(random);
			int num = Math.Clamp(positionsToGet, 5, 50);
			foreach (MapNode item in pooledList)
			{
				foreach (MapNode item2 in FloodFillUtil.IterateFloodFillConnections(item, num, (MapNode node) => !node.IsWalkable))
				{
					if (startPositionFilter(item2))
					{
						outStartingNodes.Add(item2);
						if (outStartingNodes.Count >= positionsToGet)
						{
							return;
						}
					}
				}
				outStartingNodes.Clear();
			}
		}

		public static bool CheckIfPositionReachableFromEdge(HumanoidInstance humanoid)
		{
			foreach (MapNode item in GetNodesNearEdge(8, null, skipUnderwaterNodes: true))
			{
				if (PathfinderUtil.IsPathPossible(humanoid, item))
				{
					return true;
				}
			}
			return false;
		}

		public static MapNode GetClosestReachableEdgeNode(IPathfindingAgent agent)
		{
			if (CombatUtils.IsNullOrDisposed(agent))
			{
				return null;
			}
			return GetClosestReachableEdgeNode(agent.WalkableModel, agent.GetNode());
		}

		public static MapNode GetClosestReachableEdgeNode(WalkableModel walkableModel, MapNode startingNode)
		{
			foreach (MapNode item in GetNodesNearEdge(1, delegate(MapNode node1, MapNode node2)
			{
				double num = startingNode.Distance(node1);
				double value = startingNode.Distance(node2);
				return num.CompareTo(value);
			}, skipUnderwaterNodes: false))
			{
				if (PathfinderUtil.IsPathPossible(walkableModel, startingNode, item))
				{
					return item;
				}
			}
			return null;
		}

		public static List<MapNode> GetNodesNearEdge(int maxDistFromEdge, NodeSortDelegate sortFunction, bool skipUnderwaterNodes, bool removeInaccessibleRegions = false, System.Random random = null)
		{
			if (random == null)
			{
				random = new System.Random();
			}
			List<MapNode> list = new List<MapNode>();
			int num = MonoSingleton<World>.Instance.SizeX - maxDistFromEdge;
			int num2 = MonoSingleton<World>.Instance.SizeZ - maxDistFromEdge;
			using PooledHashSet<Region> pooledHashSet = HashSetPool<Region>.GetJanitor();
			foreach (KeyValuePair<uint, Area> item in GlobalSaveController.CurrentVillageData.PlayerVillage.Map.RegionAreaManager.Areas.Where((KeyValuePair<uint, Area> kvp) => kvp.Value != null && kvp.Value.IsTouchingEdge))
			{
				pooledHashSet.UnionWith(item.Value.Regions);
			}
			if (removeInaccessibleRegions)
			{
				using PooledList<Region> pooledList = pooledHashSet.WherePooled(delegate(Region region)
				{
					Area areaById = region.Map.RegionAreaManager.GetAreaById(region.Area);
					return areaById.ConnectionsCount > 0 || CheckAreaSize(areaById, 2000);
				});
				if (pooledList.Count > 0)
				{
					pooledHashSet.IntersectWith(pooledList);
				}
				else
				{
					using PooledList<Region> pooledList2 = pooledHashSet.WherePooled(delegate(Region region)
					{
						Area areaById = region.Map.RegionAreaManager.GetAreaById(region.Area);
						return areaById.ConnectionsCount > 0 || CheckAreaSize(areaById, 500);
					});
					if (pooledList2.Count > 0)
					{
						pooledHashSet.IntersectWith(pooledList2);
					}
				}
			}
			foreach (Region item2 in pooledHashSet)
			{
				foreach (MapNode node in item2.Nodes)
				{
					if (node != null && node.IsWalkable && (!skipUnderwaterNodes || (node.WaterDepthLevel & (WaterDepthLevel.Medium | WaterDepthLevel.High)) == 0))
					{
						int x = node.Position.x;
						int z = node.Position.z;
						if (x < maxDistFromEdge || x >= num || z < maxDistFromEdge || z >= num2)
						{
							list.Add(node);
						}
					}
				}
			}
			if (sortFunction != null)
			{
				noise3dSeed = random.Next(10000);
				list.Sort((MapNode a, MapNode b) => sortFunction(a, b));
			}
			return list;
		}

		public static void GetNodesNearEdge(IEnumerable<Region> regions, int maxDistFromEdge, ISet<MapNode> result, bool skipUnderwaterNodes = false)
		{
			result.Clear();
			int num = MonoSingleton<World>.Instance.SizeX - maxDistFromEdge;
			int num2 = MonoSingleton<World>.Instance.SizeZ - maxDistFromEdge;
			foreach (Region region in regions)
			{
				foreach (MapNode node in region.Nodes)
				{
					if (node != null && node.IsWalkable && (!skipUnderwaterNodes || (node.WaterDepthLevel & (WaterDepthLevel.Medium | WaterDepthLevel.High)) == 0))
					{
						int x = node.Position.x;
						int z = node.Position.z;
						if (x < maxDistFromEdge || x >= num || z < maxDistFromEdge || z >= num2)
						{
							result.Add(node);
						}
					}
				}
			}
		}

		public List<IDamageTakingAgent> GetPossibleWorldObjectTargets()
		{
			return GetAllPossibleTargetsWorldObject(updateDbgInfo: false).OfType<IDamageTakingAgent>().ToList();
		}

		private static bool CheckAreaSize(Area area, int size)
		{
			int num = 0;
			foreach (Region region in area.Regions)
			{
				num += region.Nodes.Count;
				if (num >= size)
				{
					return true;
				}
			}
			return false;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		private static float GetVec2DistanceFromEdgeCenterVal(float vx, float vy)
		{
			float num = 0.5f * (16f / (float)(GridDataIndexTools.SizeX - 1));
			float num2 = 0.5f * (16f / (float)(GridDataIndexTools.SizeZ - 1));
			float x = Mathf.Abs(vx - num);
			x = math.min(x, Mathf.Abs(1f - vx - num));
			x = math.min(x, Mathf.Abs(vy - num2));
			x = math.min(x, Mathf.Abs(1f - vy - num2));
			return 1f - x;
		}

		private static float GetDistanceFromMapEdge(Vector2 v)
		{
			return math.max(Mathf.Abs(v.x - 0.5f), Mathf.Abs(v.y - 0.5f)) * 2f;
		}

		public static int GetDistanceFromMapEdge(MapNode node)
		{
			int x = math.min(node.Position.x, node.Map.Size.x - node.Position.x);
			int y = math.min(node.Position.z, node.Map.Size.z - node.Position.z);
			return math.min(x, y);
		}

		private static void AddWorkersToTargetList(List<MapNode> targetNodes)
		{
			System.Random rnd = new System.Random();
			foreach (int item in from r in Enumerable.Range(0, GlobalSaveController.CurrentVillageData.Workers.Count)
				orderby rnd.Next()
				select r)
			{
				HumanoidInstance humanoidInstance = GlobalSaveController.CurrentVillageData.Workers[item];
				if (CombatUtils.IsNullOrDisposed(humanoidInstance))
				{
					break;
				}
				MapNode node = humanoidInstance.GetNode();
				if (node != null)
				{
					targetNodes.Add(node);
				}
			}
		}

		public static int CompareNodeDistanceToCenter(MapNode node1, MapNode node2)
		{
			if (node1 == null || node2 == null)
			{
				return int.MaxValue;
			}
			int sizeX = MonoSingleton<World>.Instance.SizeX;
			int sizeZ = MonoSingleton<World>.Instance.SizeZ;
			Vector3 worldPosition = node1.WorldPosition;
			int num = Mathf.CeilToInt(GetVec2DistanceFromEdgeCenterVal((worldPosition.x + 0.5f) / (float)sizeX, (worldPosition.z + 0.5f) / (float)sizeZ) * 1000f) * 1000 + GetNoise3D(node1.Position.x, node1.Position.y + noise3dSeed, node1.Position.z, 1000);
			Vector3 worldPosition2 = node2.WorldPosition;
			return Mathf.CeilToInt(GetVec2DistanceFromEdgeCenterVal((worldPosition2.x + 0.5f) / (float)sizeX, (worldPosition2.z + 0.5f) / (float)sizeZ) * 1000f) * 1000 + GetNoise3D(node2.Position.x, node2.Position.y + noise3dSeed, node2.Position.z, 1000) - num;
		}

		public static int CompareNodeDistanceToEdges(MapNode node1, MapNode node2)
		{
			if (node1 == null || node2 == null)
			{
				return int.MaxValue;
			}
			int sizeX = MonoSingleton<World>.Instance.SizeX;
			int sizeZ = MonoSingleton<World>.Instance.SizeZ;
			float num = math.max(Mathf.Abs((float)node1.Position.x / ((float)sizeX - 1f) - 0.5f), Mathf.Abs((float)node1.Position.z / ((float)sizeZ - 1f) - 0.5f));
			float num2 = math.max(Mathf.Abs((float)node2.Position.x / ((float)sizeX - 1f) - 0.5f), Mathf.Abs((float)node2.Position.z / ((float)sizeZ - 1f) - 0.5f));
			int num3 = Mathf.FloorToInt(num * 1000f) * 1000 + GetNoise3D(node1.Position.x, node1.Position.y + noise3dSeed, node1.Position.z, 1000);
			return Mathf.FloorToInt(num2 * 1000f) * 1000 + GetNoise3D(node2.Position.x, node2.Position.y + noise3dSeed, node2.Position.z, 1000) - num3;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static int GetNoise3D(int seedX, int seedY, int seedZ, int maximum)
		{
			return Mathf.Abs((seedX * 3654103) ^ (seedY * 3512346) ^ (seedZ * 3131)) % maximum;
		}

		private List<WorldObject> CollectBeds()
		{
			List<WorldObject> list = new List<WorldObject>();
			foreach (WorldObject worldObject in VillageManager.ActiveVillage.Map.BedComponentManager.WorldObjects)
			{
				if (!list.Contains(worldObject))
				{
					list.Add(worldObject);
				}
			}
			return list;
		}

		private List<WorldObject> CollectDoors()
		{
			List<WorldObject> list = new List<WorldObject>();
			foreach (WorldObject worldObject in VillageManager.ActiveVillage.Map.DoorComponentManager.WorldObjects)
			{
				if (!list.Contains(worldObject))
				{
					list.Add(worldObject);
				}
			}
			return list;
		}

		private List<WorldObject> CollectProductionBuildings()
		{
			List<WorldObject> list = new List<WorldObject>();
			foreach (WorldObject worldObject in VillageManager.ActiveVillage.Map.ProductionComponentBuildingManager.WorldObjects)
			{
				if (!list.Contains(worldObject))
				{
					list.Add(worldObject);
				}
			}
			return list;
		}

		private List<WorldObject> CreateTargetsList(ref List<WorldObject> beds, ref List<WorldObject> doors, ref List<WorldObject> productionBuildings)
		{
			List<WorldObject> list = new List<WorldObject>();
			list.AddRange(beds);
			list.AddRange(productionBuildings);
			List<WorldObject> list2 = list.Shuffle().ToList();
			list2.AddRange(doors.Shuffle());
			return list2;
		}

		private List<MapNode> GetAllPossibleTargets(bool updateDbgInfo = true)
		{
			List<MapNode> nodesAtTargets = GetNodesAtTargets(GetAllPossibleTargetsWorldObject(updateDbgInfo));
			AddWorkersToTargetList(nodesAtTargets);
			return nodesAtTargets;
		}

		private List<WorldObject> GetAllPossibleTargetsWorldObject(bool updateDbgInfo = true)
		{
			List<WorldObject> beds = CollectBeds();
			List<WorldObject> doors = CollectDoors();
			List<WorldObject> productionBuildings = CollectProductionBuildings();
			return CreateTargetsList(ref beds, ref doors, ref productionBuildings);
		}

		private static List<MapNode> GetNodesAtTargets(List<WorldObject> targetList)
		{
			List<MapNode> list = new List<MapNode>();
			VillageMap map = GlobalSaveController.CurrentVillageData.PlayerVillage.Map;
			foreach (WorldObject target in targetList)
			{
				if (target == null)
				{
					continue;
				}
				if (target.Positions == null)
				{
					Log.Error("GetNodesAtTargets: targetObj.Positions is null", "C:\\GIT\\dev\\Assets\\Scripts\\Managers\\NPCStartPositionManager.cs");
					continue;
				}
				foreach (Vec3Int position in target.Positions)
				{
					MapNode node = map.GetNode(position);
					if (node == null)
					{
						continue;
					}
					if (node.IsWalkable)
					{
						list.Add(node);
					}
					foreach (MapNode item in node.ConnectionsSafe)
					{
						if (item != null && item.IsWalkable && !list.Contains(item))
						{
							list.Add(item);
						}
					}
				}
			}
			return list;
		}

		private static List<MapNode> GetStartPositions(WalkableModel walkableModel, MapNode targetNode, int positionsToGet, IEnumerable<MapNode> nodesNearEdge, ref int iterationCounter)
		{
			List<MapNode> list = new List<MapNode>();
			using PooledQueue<MapNode> pooledQueue = QueuePool<MapNode>.GetJanitor();
			using PooledHashSet<MapNode> pooledHashSet = HashSetPool<MapNode>.GetJanitor();
			using PooledDictionary<Region, bool> pooledDictionary = DictionaryPool<Region, bool>.GetJanitor();
			Region region = targetNode.Region;
			foreach (MapNode item in nodesNearEdge)
			{
				Region region2 = item.Region;
				if (!pooledDictionary.ContainsKey(region2))
				{
					pooledDictionary.Add(region2, PathfinderUtil.IsRegionReachable(walkableModel, region2, region));
				}
				if (!pooledDictionary[region2])
				{
					continue;
				}
				list.Clear();
				int num = 0;
				pooledQueue.Clear();
				pooledQueue.Enqueue(item);
				uint area = item.Area;
				while (pooledQueue.Count > 0)
				{
					MapNode mapNode = pooledQueue.Dequeue();
					if (mapNode.IsWalkable && mapNode.Area == area && (mapNode.DataType & (GridDataType.BuildingFinished | GridDataType.PlantMapResource)) == 0)
					{
						list.Add(mapNode);
						num++;
						if (num >= positionsToGet)
						{
							return list;
						}
						foreach (MapNode item2 in mapNode.ConnectionsSafe)
						{
							if (item2 != null && !pooledHashSet.Contains(item2))
							{
								pooledQueue.Enqueue(item2);
							}
						}
					}
					iterationCounter++;
					pooledHashSet.Add(mapNode);
				}
			}
			return null;
		}

		private void OnDrawGizmos()
		{
			Color color = Gizmos.color;
			if (info.PossibleTargetPositions != null)
			{
				Vector3 size = new Vector3(1f, 0.05f, 1f);
				Gizmos.color = new Color(1f, 1f, 1f, 0.66f);
				foreach (Vector3 possibleTargetPosition in info.PossibleTargetPositions)
				{
					Gizmos.DrawCube(possibleTargetPosition, size);
				}
			}
			if (info.Beds != null)
			{
				Gizmos.color = Color.blue;
				foreach (WorldObject bed in info.Beds)
				{
					DrawGizmosWorldObject(bed);
				}
			}
			if (info.Doors != null)
			{
				Gizmos.color = Color.blue;
				foreach (WorldObject door in info.Doors)
				{
					DrawGizmosWorldObject(door);
				}
			}
			if (info.ProductionBuildings != null)
			{
				Gizmos.color = Color.blue;
				foreach (WorldObject productionBuilding in info.ProductionBuildings)
				{
					DrawGizmosWorldObject(productionBuilding);
				}
			}
			if (info.LastTargetNode != null)
			{
				Gizmos.color = Color.cyan;
				Gizmos.DrawSphere(info.LastTargetNode.WorldPosition, 0.5f);
			}
			if (info.LastStartingNodes != null)
			{
				Gizmos.color = Color.magenta;
				foreach (MapNode lastStartingNode in info.LastStartingNodes)
				{
					Gizmos.DrawSphere(lastStartingNode.WorldPosition, 0.5f);
				}
			}
			if (info.Paths != null)
			{
				Gizmos.color = Color.magenta;
				foreach (Path path in info.Paths)
				{
					DrawGizmosPath(path);
				}
			}
			Gizmos.color = color;
		}

		private void DrawGizmosPath(Path path)
		{
		}

		private void DrawGizmosWorldObject(WorldObject obj)
		{
			Vector3 size = new Vector3(1f, 0.1f, 1f);
			foreach (Vec3Int position in obj.Positions)
			{
				Gizmos.DrawCube(GridUtils.GetWorldPosition(position), size);
			}
		}
	}
}
