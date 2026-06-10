using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using NSMedieval.Utils.Pool;
using NSMedieval.Village.Map.Pathfinding;
using UnityEngine;

namespace NSMedieval.Village.Map
{
	public static class AreaFloodFill
	{
		private static ThreadLocal<Queue<uint>> IsPathPossibleQueue = new ThreadLocal<Queue<uint>>(() => new Queue<uint>());

		private static ThreadLocal<HashSet<uint>> IsPathPossibleVisited = new ThreadLocal<HashSet<uint>>(() => new HashSet<uint>());

		private static ThreadLocal<PathTraversalProvider> IsPathPossibleProvider = new ThreadLocal<PathTraversalProvider>(() => (PathTraversalProvider)null);

		private static ThreadLocal<uint> IsPathPossibleEndArea = new ThreadLocal<uint>(() => 0u);

		private static ThreadLocal<bool> IsPathPossibleShouldReturn = new ThreadLocal<bool>(() => false);

		private static ThreadLocal<bool> IsPathPossibleResult = new ThreadLocal<bool>(() => false);

		[RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.BeforeSceneLoad)]
		private static void OnDomainReload()
		{
			IsPathPossibleQueue = new ThreadLocal<Queue<uint>>(() => new Queue<uint>());
			IsPathPossibleVisited = new ThreadLocal<HashSet<uint>>(() => new HashSet<uint>());
			IsPathPossibleProvider = new ThreadLocal<PathTraversalProvider>(() => (PathTraversalProvider)null);
			IsPathPossibleEndArea = new ThreadLocal<uint>(() => 0u);
			IsPathPossibleShouldReturn = new ThreadLocal<bool>(() => false);
			IsPathPossibleResult = new ThreadLocal<bool>(() => false);
		}

		public static uint FindDirectAreaId(Region region)
		{
			Queue<Region> queue = QueuePool<Region>.Get();
			HashSet<Region> hashSet = HashSetPool<Region>.Get();
			queue.Enqueue(region);
			while (queue.Count > 0)
			{
				Region region2 = queue.Dequeue();
				if (!hashSet.Add(region2))
				{
					continue;
				}
				foreach (Region connection in region2.Connections)
				{
					if (!connection.IsBridge)
					{
						if (connection.Area != 0)
						{
							HashSetPool<Region>.Return(hashSet);
							QueuePool<Region>.Return(queue);
							return connection.Area;
						}
						queue.Enqueue(connection);
					}
				}
			}
			HashSetPool<Region>.Return(hashSet);
			QueuePool<Region>.Return(queue);
			return 0u;
		}

		public static HashSet<Region> RegionsInArea(Region region, Func<Region, bool> condition = null)
		{
			Queue<Region> queue = QueuePool<Region>.Get();
			HashSet<Region> hashSet = HashSetPool<Region>.Get();
			HashSet<Region> hashSet2 = HashSetPool<Region>.Get();
			hashSet2.Add(region);
			queue.Enqueue(region);
			while (queue.Count > 0)
			{
				Region region2 = queue.Dequeue();
				if (hashSet.Contains(region2))
				{
					continue;
				}
				hashSet.Add(region2);
				foreach (Region connection in region2.Connections)
				{
					if (!connection.IsBridge)
					{
						if (connection.Area == region.Area && (condition == null || condition(connection)))
						{
							hashSet2.Add(connection);
						}
						else
						{
							queue.Enqueue(connection);
						}
					}
				}
			}
			HashSetPool<Region>.Return(hashSet);
			QueuePool<Region>.Return(queue);
			if (hashSet2.Count != 0)
			{
				return hashSet2;
			}
			HashSetPool<Region>.Return(hashSet2);
			return null;
		}

		public static bool IsPathPossible(PathTraversalProvider provider, VillageMap map, uint start, uint end)
		{
			if (start == end)
			{
				return true;
			}
			if (start == 0 || end == 0)
			{
				return false;
			}
			RegionAreaManager regionAreaManager = map.RegionAreaManager;
			if (regionAreaManager.GetAreaById(start) == null)
			{
				return false;
			}
			IsPathPossibleVisited.Value.Clear();
			IsPathPossibleEndArea.Value = end;
			IsPathPossibleProvider.Value = provider;
			IsPathPossibleQueue.Value.Clear();
			IsPathPossibleQueue.Value.Enqueue(start);
			IsPathPossibleResult.Value = false;
			IsPathPossibleShouldReturn.Value = false;
			while (IsPathPossibleQueue.Value.Count > 0)
			{
				uint num = IsPathPossibleQueue.Value.Dequeue();
				if (num == 0 || !IsPathPossibleVisited.Value.Add(num))
				{
					continue;
				}
				Area current = regionAreaManager.GetAreaById(num);
				if (current != null)
				{
					IsPathPossibleShouldReturn.Value = false;
					IsPathPossibleResult.Value = false;
					current.ConnectionsSafeSearch((Region region) => IsPathPossibleConnectionsForEach(current, region));
					if (IsPathPossibleShouldReturn.Value)
					{
						break;
					}
				}
			}
			return IsPathPossibleResult.Value;
		}

		private static bool IsPathPossibleConnectionsForEach(Area startingArea, Region item)
		{
			uint area = item.Area;
			if (area == 0 || IsPathPossibleVisited.Value.Contains(area))
			{
				return false;
			}
			if (item.IsBridge && ((item.Nodes[0].Tag & MapNodeTags.Ladder) == 0 || startingArea.IsBridge) && !IsPathPossibleProvider.Value.CanTraverse(item, startingArea.Regions.First()))
			{
				if (area != IsPathPossibleEndArea.Value)
				{
					return false;
				}
				IsPathPossibleShouldReturn.Value = true;
				IsPathPossibleResult.Value = false;
				return true;
			}
			if (area == IsPathPossibleEndArea.Value)
			{
				IsPathPossibleShouldReturn.Value = true;
				IsPathPossibleResult.Value = true;
				return true;
			}
			IsPathPossibleQueue.Value.Enqueue(item.Area);
			return false;
		}
	}
}
