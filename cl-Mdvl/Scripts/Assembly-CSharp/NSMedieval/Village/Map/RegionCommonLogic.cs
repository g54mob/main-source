using System;
using System.Collections.Generic;
using NSEipix;
using NSMedieval.Manager;
using NSMedieval.Utils.Pool;
using UnityEngine;

namespace NSMedieval.Village.Map
{
	public static class RegionCommonLogic
	{
		private static int uniqueIdCount;

		[RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.BeforeSceneLoad)]
		private static void OnDomainReload()
		{
			uniqueIdCount = 0;
		}

		internal static int GetNewUniqueId()
		{
			uniqueIdCount++;
			return uniqueIdCount;
		}

		internal static Region FillRegionFromNode(MapNode startNode, Func<MapNode, Region, bool, bool> canAddToRegion)
		{
			Region region = startNode.Region;
			int targetY = startNode.Position.y;
			FloodFillUtil.FloodFillConnections(startNode.Map, startNode.Position, -1f, delegate(MapNode item)
			{
				if (item.Region != null || !canAddToRegion(item, region, arg3: false))
				{
					return FloodFillUtil.ScanStatus.InvalidNode;
				}
				if (item.Position.y != targetY)
				{
					return FloodFillUtil.ScanStatus.InvalidNode;
				}
				if (region == null)
				{
					if (!RegionBridgeLogic.IsBridgeNode(item))
					{
						region = new Region(GetNewUniqueId(), startNode.Map);
					}
					else
					{
						region = new RegionBridge(GetNewUniqueId(), startNode.Map);
					}
				}
				region.AddNode(item);
				return (region.Nodes.Count >= 420) ? FloodFillUtil.ScanStatus.Abort : FloodFillUtil.ScanStatus.Continue;
			});
			return region;
		}

		internal static void TrimExpandRegion(Region region, ref List<MapNode> removedNodes, Func<MapNode, Region, bool, bool> canAddToRegion)
		{
			HashSet<MapNode> newNodes = HashSetPool<MapNode>.Get();
			MapNode mapNode = region.Nodes[0];
			int targetY = mapNode.Position.y;
			FloodFillUtil.FloodFillConnections(mapNode.Map, mapNode.Position, -1f, delegate(MapNode item)
			{
				if (item.Region != region && item.Region != null)
				{
					return FloodFillUtil.ScanStatus.InvalidNode;
				}
				if (item.Position.y != targetY)
				{
					return FloodFillUtil.ScanStatus.InvalidNode;
				}
				if (!canAddToRegion(item, region, arg3: true))
				{
					return FloodFillUtil.ScanStatus.InvalidNode;
				}
				newNodes.Add(item);
				return FloodFillUtil.ScanStatus.Continue;
			});
			foreach (MapNode item in region.Nodes.IterateInReverseDynamic())
			{
				if (!newNodes.Contains(item))
				{
					region.RemoveNode(item);
					removedNodes.Add(item);
				}
				else
				{
					newNodes.Remove(item);
				}
			}
			foreach (MapNode item2 in newNodes)
			{
				if (canAddToRegion(item2, region, arg3: false))
				{
					region.AddNode(item2);
				}
			}
			HashSetPool<MapNode>.Return(newNodes);
		}
	}
}
