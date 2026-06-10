using System;
using System.Collections.Generic;
using System.Linq;
using NSEipix;
using NSEipix.Base;
using NSMedieval.Controllers;
using NSMedieval.State;
using NSMedieval.Utils.Pool;
using NSMedieval.Utils.Pool.Janitors;

namespace NSMedieval.Village.Map
{
	public class Area : IGameDisposable, IDisposable
	{
		public delegate bool ConnectionSearchOperation(Region region);

		private uint id;

		private readonly HashSet<Region> regions = new HashSet<Region>();

		private readonly HashSet<Region> connections = new HashSet<Region>();

		private bool isTouchingEdge;

		private bool isBridge;

		private int nodesCount;

		private VillageMap map;

		private readonly object connectionsLock = new object();

		private bool regenerateConnections;

		public bool HasDisposed { get; private set; }

		public uint Id => id;

		public bool IsBridge => isBridge;

		public VillageMap Map => map;

		public HashSet<Region> Regions => regions;

		public bool IsTouchingEdge => isTouchingEdge;

		public int NodesCount
		{
			get
			{
				CheckFillConnections();
				if (nodesCount == 0)
				{
					foreach (Region region in regions)
					{
						nodesCount += region.Nodes.Count;
					}
				}
				return nodesCount;
			}
		}

		public int ConnectionsCount { get; private set; }

		public event Action<IGameDisposable> OnDisposedEvent;

		public Area(uint id, VillageMap map, bool isBridge)
		{
			this.id = id;
			this.map = map;
			this.isBridge = isBridge;
			regenerateConnections = true;
			MonoSingleton<TaskController>.Instance.OptimizedCall(this, "refresh", CheckFillConnections);
		}

		public void Dispose()
		{
			if (HasDisposed)
			{
				return;
			}
			if (!LoadingController.IsLeavingMainScene)
			{
				this.OnDisposedEvent?.Invoke(this);
			}
			this.OnDisposedEvent = null;
			HasDisposed = true;
			map = null;
			regions.Clear();
			lock (connectionsLock)
			{
				connections.Clear();
				ConnectionsCount = 0;
			}
		}

		internal void NodeAdded()
		{
			nodesCount = 0;
		}

		internal void NodeRemoved()
		{
			nodesCount = 0;
		}

		internal int GetNonRoofedNodesCount()
		{
			int num = 0;
			foreach (Region region in regions)
			{
				if (!region.IsBridge && region.NonRoofedNodesCount > 0)
				{
					num += region.NonRoofedNodesCount;
				}
			}
			return num;
		}

		internal void AddRegion(Region region)
		{
			if (isBridge && regions.Count > 0)
			{
				throw new Exception($"Tried to add multiple regions to bridge area {id}. This should not be reached...");
			}
			if (region.Area != 0 && region.Area != id)
			{
				throw new Exception($"Tried to add region already in area {region.Area}, to different area {id}. This should not be reached...");
			}
			region.Area = id;
			regions.Add(region);
			nodesCount = 0;
			isTouchingEdge |= region.HasMapEdgeNodes;
			region.OnDisposedEvent += OnRegionDisposed;
			foreach (Region connection in region.Connections)
			{
				if (connection.IsBridge)
				{
					connection.GetArea()?.ScheduleRegenerateConnections();
				}
			}
			ScheduleRegenerateConnections();
		}

		internal void RemoveAllRegions()
		{
			foreach (Region region in regions)
			{
				region.Area = 0u;
			}
			isTouchingEdge = false;
			regions.Clear();
			nodesCount = 0;
		}

		internal void ConnectionsSafeForEach(Action<Region> operation)
		{
			CheckFillConnections();
			lock (connectionsLock)
			{
				if (connections == null || connections.Count == 0)
				{
					return;
				}
				foreach (Region connection in connections)
				{
					operation(connection);
				}
			}
		}

		internal bool ConnectionsSafeSearch(ConnectionSearchOperation operation)
		{
			CheckFillConnections();
			lock (connectionsLock)
			{
				if (connections == null || connections.Count == 0)
				{
					return false;
				}
				foreach (Region connection in connections)
				{
					if (operation(connection))
					{
						return true;
					}
				}
			}
			return false;
		}

		internal HashSet<Region> TrimArea(bool refreshBridges = true)
		{
			if (regions.Count == 0)
			{
				return null;
			}
			HashSet<Region> hashSet = AreaFloodFill.RegionsInArea(regions.First());
			if (hashSet == null)
			{
				HashSet<Region> hashSet2 = HashSetPool<Region>.Get();
				{
					foreach (Region region in regions)
					{
						hashSet2.Add(region);
					}
					return hashSet2;
				}
			}
			if (regions.Count == hashSet.Count)
			{
				HashSetPool<Region>.Return(hashSet);
				return null;
			}
			HashSet<Region> hashSet3 = HashSetPool<Region>.Get();
			foreach (Region region2 in regions)
			{
				if (!hashSet.Contains(region2))
				{
					hashSet3.Add(region2);
				}
			}
			foreach (Region item in hashSet3)
			{
				RemoveRegion(item, refreshBridges: false);
			}
			if (refreshBridges)
			{
				ScheduleRegenerateConnections();
				foreach (Region region3 in regions)
				{
					foreach (Region connection in region3.Connections)
					{
						if (connection.IsBridge)
						{
							connection.GetArea()?.ScheduleRegenerateConnections();
						}
					}
				}
			}
			HashSetPool<Region>.Return(hashSet);
			return hashSet3;
		}

		internal HashSet<Region> ReFloodArea()
		{
			if (regions.Count == 0 || IsBridge)
			{
				return null;
			}
			Region item = regions.First();
			Queue<Region> queue = QueuePool<Region>.Get();
			HashSet<Region> hashSet = HashSetPool<Region>.Get();
			HashSet<Region> hashSet2 = HashSetPool<Region>.Get();
			hashSet2.Add(item);
			queue.Enqueue(item);
			while (queue.Count > 0)
			{
				Region region = queue.Dequeue();
				if (hashSet.Contains(region))
				{
					continue;
				}
				hashSet.Add(region);
				foreach (Region connection in region.Connections)
				{
					if (!connection.IsBridge)
					{
						if (connection.Area != id && connection.Area != 0)
						{
							map.RegionAreaManager.GetAreaById(connection.Area)?.RemoveRegion(connection);
						}
						hashSet2.Add(connection);
						queue.Enqueue(connection);
					}
				}
			}
			HashSetPool<Region>.Return(hashSet);
			QueuePool<Region>.Return(queue);
			if (hashSet2.Count != 0)
			{
				HashSet<Region> hashSet3 = HashSetPool<Region>.Get();
				foreach (Region region2 in regions)
				{
					if (!hashSet2.Contains(region2))
					{
						hashSet3.Add(region2);
					}
				}
				RemoveAllRegions();
				foreach (Region item2 in hashSet2)
				{
					AddRegion(item2);
				}
				HashSetPool<Region>.Return(hashSet2);
				return hashSet3;
			}
			foreach (Region region3 in regions)
			{
				hashSet2.Add(region3);
			}
			RemoveAllRegions();
			return hashSet2;
		}

		internal bool IsValidBridge()
		{
			if (!IsBridge || regions.Count != 1)
			{
				return false;
			}
			Region region = regions.First();
			if (region.IsBridge)
			{
				return !region.HasDisposed;
			}
			return false;
		}

		internal void ScheduleRegenerateConnections()
		{
			regenerateConnections = true;
		}

		private void CollectConnections(ISet<Region> connections)
		{
			foreach (Region region in regions)
			{
				if (!isBridge && !region.HasBridgeConnections)
				{
					continue;
				}
				foreach (Region connection in region.Connections)
				{
					if (connection.Area != 0 && connection.Area != id && (isBridge || connection.IsBridge))
					{
						connections.Add(connection);
					}
				}
			}
		}

		private void CheckFillConnections()
		{
			if (!regenerateConnections)
			{
				return;
			}
			regenerateConnections = false;
			isTouchingEdge = false;
			foreach (Region region in regions)
			{
				isTouchingEdge |= region.HasMapEdgeNodes;
				if (isTouchingEdge)
				{
					break;
				}
			}
			using PooledHashSet<Region> pooledHashSet = HashSetPool<Region>.GetJanitor();
			CollectConnections(pooledHashSet);
			lock (connectionsLock)
			{
				using PooledHashSet<uint> pooledHashSet2 = HashSetPool<uint>.GetJanitor();
				foreach (Region item in pooledHashSet)
				{
					if (!connections.Contains(item))
					{
						pooledHashSet2.Add(item.Area);
					}
				}
				foreach (Region connection in connections)
				{
					if (!pooledHashSet.Contains(connection))
					{
						pooledHashSet2.Add(connection.Area);
					}
				}
				connections.Clear();
				connections.UnionWith(pooledHashSet);
				ConnectionsCount = connections.Count;
				foreach (uint item2 in pooledHashSet2)
				{
					Area areaById = map.RegionAreaManager.GetAreaById(item2);
					if (areaById != null)
					{
						areaById.regenerateConnections = true;
					}
				}
			}
		}

		private void OnRegionDisposed(IGameDisposable disposable)
		{
			RemoveRegion((Region)disposable);
		}

		private void RemoveRegion(Region region, bool refreshBridges = true)
		{
			if (!regions.Remove(region))
			{
				return;
			}
			map.RegionRemovedFromArea(region, this);
			region.Area = 0u;
			if (regions.Count == 0)
			{
				Dispose();
				return;
			}
			nodesCount = 0;
			if (refreshBridges)
			{
				ScheduleRegenerateConnections();
			}
		}
	}
}
