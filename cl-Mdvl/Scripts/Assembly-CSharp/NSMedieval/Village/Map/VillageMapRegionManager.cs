using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using FoxyVoxel.Logging;
using FoxyVoxel.Logging.Core.LogMessageInterpolationHandlers;
using NSEipix.Base;
using NSMedieval.State;
using NSMedieval.Utils.Pool;
using NSMedieval.Utils.Pool.Janitors;
using NSMedieval.Village.Map.Pathfinding;

namespace NSMedieval.Village.Map
{
	public class VillageMapRegionManager : IGameDisposable, IDisposable
	{
		private readonly List<Region> regions = new List<Region>();

		private readonly Queue<MapNode> processQueue = new Queue<MapNode>();

		private readonly ConcurrentQueue<Region> dirtyRegions = new ConcurrentQueue<Region>();

		private VillageMap map;

		public bool HasDisposed { get; private set; }

		public List<Region> Regions => regions;

		public event Action<IGameDisposable> OnDisposedEvent;

		public event Action<Region> OnRegionAddedEvent;

		public event Action<Region> OnRegionRemovingEvent;

		internal VillageMapRegionManager(VillageMap map)
		{
			this.map = map;
		}

		public void Dispose()
		{
			HasDisposed = true;
			foreach (Region region in regions)
			{
				region.Dispose();
			}
			regions.Clear();
			dirtyRegions.Clear();
			if (MonoSingleton<SceneController>.IsInstantiated())
			{
				MonoSingleton<SceneController>.Instance.LateTick -= LateTick;
			}
			map = null;
			this.OnDisposedEvent = null;
			this.OnRegionAddedEvent = null;
			this.OnRegionRemovingEvent = null;
			processQueue.Clear();
		}

		public void MarkRegionAsDirty(Region region)
		{
			if (!region.HasDisposed && !region.IsDirty)
			{
				region.IsDirty = true;
				dirtyRegions.Enqueue(region);
			}
		}

		internal void Initialize()
		{
			if (regions.Count > 0)
			{
				Log.Error("This should never happen!", "C:\\GIT\\dev\\Assets\\Scripts\\Village\\Map\\Region\\VillageMapRegionManager.cs");
			}
			GenerateRegions();
			MonoSingleton<SceneController>.Instance.LateTick += LateTick;
		}

		internal void MapNodeStateChanged(MapNode node)
		{
			if (!node.RegionProcessingPending)
			{
				node.RegionProcessingPending = true;
				processQueue.Enqueue(node);
			}
		}

		private void GenerateRegions()
		{
			for (int i = 1; i < map.Size.y; i++)
			{
				for (int j = 0; j < map.Size.x; j++)
				{
					for (int k = 0; k < map.Size.z; k++)
					{
						MapNode node = map.GetNode(j, i, k);
						if (node.Region == null)
						{
							Region region = RegionClassicLogic.FillRegionFromNode(node);
							if (region != null)
							{
								Regions.Add(region);
							}
						}
					}
				}
			}
			foreach (Region region2 in regions)
			{
				region2.Initialize(initialGeneration: true);
				this.OnRegionAddedEvent?.Invoke(region2);
			}
			bool isEnabled;
			FVLogInfoInterpolationHandler messageBuilder = new FVLogInfoInterpolationHandler(18, 1, out isEnabled, "C:\\GIT\\dev\\Assets\\Scripts\\Village\\Map\\Region\\VillageMapRegionManager.cs");
			if (isEnabled)
			{
				messageBuilder.AppendLiteral("Generated ");
				messageBuilder.AppendFormatted(regions.Count);
				messageBuilder.AppendLiteral(" regions");
			}
			Log.Info(messageBuilder);
		}

		private bool TryRemoveNodeFromRegion(MapNode node)
		{
			Region region = node.Region;
			if (region == null)
			{
				return false;
			}
			if (region.IsBridge && region.Nodes.Contains(node))
			{
				if (!RegionBridgeLogic.IsBridgeNode(node))
				{
					region.RemoveNode(node);
					RefreshAboveAndBelow();
					return true;
				}
				return false;
			}
			if (RegionClassicLogic.CanAddToRegion(node, region, ignoreRegionMaxLimit: true))
			{
				return false;
			}
			region.RemoveNode(node);
			RefreshAboveAndBelow();
			return true;
			void RefreshAboveAndBelow()
			{
				MapNode nodeAbove = node.GetNodeAbove();
				MapNode nodeBelow = node.GetNodeBelow();
				if (nodeAbove != null && (nodeAbove.Region != null || RegionClassicLogic.CanAddToRegion(nodeAbove, null)))
				{
					MapNodeStateChanged(nodeAbove);
				}
				if (nodeBelow != null && (nodeBelow.Region != null || RegionClassicLogic.CanAddToRegion(nodeBelow, null)))
				{
					MapNodeStateChanged(nodeBelow);
				}
			}
		}

		private void LateTick(float delta)
		{
			using (ProfilerSampleJanitor.Begin("VillageMapRegionManager.LateTick"))
			{
				using PooledList<Region> pooledList = ListPool<Region>.GetJanitor();
				Region result;
				while (dirtyRegions.TryDequeue(out result))
				{
					if (result.HasDisposed)
					{
						result.IsDirty = false;
						continue;
					}
					if (result.IsReachableBeingProcessed)
					{
						pooledList.Add(result);
						continue;
					}
					result.ApplyScheduledMutations();
					result.IsDirty = false;
				}
				foreach (Region item in pooledList)
				{
					dirtyRegions.Enqueue(item);
				}
				RegionAreaManager regionAreaManager = map.RegionAreaManager;
				if (processQueue.Count == 0)
				{
					regionAreaManager.RecalculateAreas();
					return;
				}
				List<MapNode> removedNodes = ListPool<MapNode>.Get((int)((float)processQueue.Count * 0.8f));
				HashSet<Region> hashSet = HashSetPool<Region>.Get();
				while (processQueue.Count > 0)
				{
					MapNode mapNode = processQueue.Dequeue();
					Region region = mapNode.Region;
					bool flag = TryRemoveNodeFromRegion(mapNode);
					if (flag || mapNode.Region == null)
					{
						if (mapNode.IsWalkable)
						{
							removedNodes.Add(mapNode);
						}
						else
						{
							MapNode nodeBelow = mapNode.GetNodeBelow();
							if (nodeBelow != null && nodeBelow.IsWalkable)
							{
								removedNodes.Add(nodeBelow);
							}
						}
						if (flag && region != null)
						{
							hashSet.Add(region);
						}
					}
					mapNode.RegionProcessingPending = false;
					bool isWater = mapNode.IsWater;
					foreach (MapNode item2 in MapNodeUtils.IterateEachNeighbor(mapNode))
					{
						if (isWater != item2.IsWater)
						{
							item2.ForceUpdateConnections();
						}
					}
					foreach (MapNode item3 in mapNode.ConnectionsSafe)
					{
						if (item3.Region != null)
						{
							hashSet.Add(item3.Region);
						}
					}
				}
				foreach (Region item4 in hashSet)
				{
					bool flag2 = item4.Nodes.Count == 0;
					if (!flag2)
					{
						flag2 = item4.IsBridge && !RegionBridgeLogic.IsBridgeNode(item4.Nodes.First());
					}
					if (flag2)
					{
						if (item4.Nodes.Count > 0)
						{
							foreach (MapNode node in item4.Nodes)
							{
								removedNodes.Add(node);
							}
						}
						if (item4.Area != 0)
						{
							regionAreaManager.QueueForRecalculation(item4.Area);
						}
						this.OnRegionRemovingEvent?.Invoke(item4);
						item4.Dispose();
						regions.Remove(item4);
					}
					else if (!item4.IsBridge)
					{
						RegionClassicLogic.TrimExpandRegion(item4, ref removedNodes);
					}
				}
				HashSet<Region> hashSet2 = HashSetPool<Region>.Get();
				for (int i = 0; i < removedNodes.Count; i++)
				{
					MapNode mapNode2 = removedNodes[i];
					if (mapNode2.Region != null)
					{
						continue;
					}
					Region region2 = RegionClassicLogic.FillRegionFromNode(mapNode2);
					if (region2 == null)
					{
						continue;
					}
					region2.Initialize(initialGeneration: false);
					regions.Add(region2);
					hashSet2.Add(region2);
					if (region2.IsBridge)
					{
						continue;
					}
					uint num = 0u;
					foreach (Region connection in region2.Connections)
					{
						if (num == 0)
						{
							num = connection.Area;
						}
						else if (!connection.IsBridge && connection.Area != num)
						{
							regionAreaManager.QueueForRecalculation(connection.Area);
							regionAreaManager.QueueForRecalculation(num);
						}
					}
				}
				foreach (Region item5 in hashSet)
				{
					if (item5.HasDisposed || !item5.RefreshNeighbourConnections())
					{
						continue;
					}
					uint area = item5.Area;
					if (area == 0)
					{
						regionAreaManager.AssignRegionToArea(item5);
						area = item5.Area;
					}
					regionAreaManager.QueueForRecalculation(area);
					foreach (Region connection2 in item5.Connections)
					{
						if (!connection2.HasDisposed && (area != connection2.Area || connection2.Area == 0))
						{
							if (connection2.Area == 0)
							{
								regionAreaManager.AssignRegionToArea(connection2);
							}
							else
							{
								regionAreaManager.QueueForRecalculation(connection2.Area);
							}
						}
					}
				}
				processQueue.Clear();
				ListPool<MapNode>.Return(removedNodes);
				regionAreaManager.RecalculateAreas();
				foreach (Region item6 in hashSet2)
				{
					if (item6.Area != 0)
					{
						continue;
					}
					regionAreaManager.AssignRegionToArea(item6);
					foreach (Region connection3 in item6.Connections)
					{
						if (connection3.Area == 0)
						{
							regionAreaManager.AssignRegionToArea(connection3);
						}
					}
					if (item6.IsBridge)
					{
						foreach (Region connection4 in item6.Connections)
						{
							regionAreaManager.GetAreaById(connection4.Area).ScheduleRegenerateConnections();
						}
					}
					this.OnRegionAddedEvent?.Invoke(item6);
				}
				PathfinderUtil.ClearIsPathPossibleCache();
				HashSetPool<Region>.Return(hashSet2);
				if ((MonoSingleton<VisualDebugManager>.Instance.EnabledType & VisualDebugType.MapRegions) != VisualDebugType.None)
				{
					MonoSingleton<RegionDebugger>.Instance.GenerateDebugElements();
				}
				HashSetPool<Region>.Return(hashSet);
			}
		}
	}
}
