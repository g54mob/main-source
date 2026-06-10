using System;
using System.Collections.Generic;
using FoxyVoxel.Logging;
using FoxyVoxel.Logging.Core.LogMessageInterpolationHandlers;
using NSEipix;
using NSEipix.Base;
using NSMedieval.DebugEvents;
using NSMedieval.Manager;
using NSMedieval.Map;
using NSMedieval.Utils.Pool;
using UnityEngine;

namespace NSMedieval.Village.Map.Pathfinding
{
	public static class DriverQuickUnstuck
	{
		private const float StuckCheckInterval = 1.2f;

		public static void TickWhileNotMoving(PathfinderAgentDriver driver, ref float timeSinceLastCheck)
		{
			if (driver.IsSwimming || driver.Agent?.Map == null)
			{
				return;
			}
			Vec3Int agentGridPos = driver.Agent.GetGridPosition();
			PathTraversalProvider traversalProvider = driver.Agent.PathTraversalProvider;
			MapNode node = driver.Agent.Map.GetNode(agentGridPos);
			bool flag = !driver.IsFloatingAllowed && node != null && !node.IsLayerRamp() && (float)agentGridPos.y - node.WorldPosition.y > 0.5f;
			if (!flag && node != null && node.IsWalkable && !node.Tag.HasFlag(MapNodeTags.DoorCompletelyLocked))
			{
				return;
			}
			timeSinceLastCheck += Time.deltaTime;
			if (timeSinceLastCheck < 1.2f || driver.HasDisposed || driver.Agent.HasDisposed)
			{
				return;
			}
			if (driver.IsSwimming)
			{
				DebugEventLog.Write(new GoapDebugEvent(driver.Agent, GoapDebugEventCode.DriverQuickUnstuck_Agent_IsSwimming_True));
			}
			if (flag)
			{
				MapNode mapNode = node;
				int num = mapNode.Position.y;
				while (num >= 0 && !mapNode.IsWalkable)
				{
					mapNode = mapNode.GetNodeBelow();
					num--;
				}
				if (mapNode != null)
				{
					DebugEventLog.Write(new GoapDebugEvent(driver.Agent, GoapDebugEventCode.DriverQuickUnstuck_Teleport_0));
					driver.Teleport(mapNode.Position);
					return;
				}
			}
			timeSinceLastCheck = 0f;
			if (node == null)
			{
				MapNode bestNode = null;
				MapNodeUtils.ForEachNeighbour(driver.Agent.Map, agentGridPos, delegate(MapNode mapNode3)
				{
					if (!mapNode3.IsWalkable || !traversalProvider.CanStandOnNode(mapNode3))
					{
						return true;
					}
					if (mapNode3.Position.y == agentGridPos.y)
					{
						bestNode = mapNode3;
						return false;
					}
					if (bestNode == null)
					{
						bestNode = mapNode3;
					}
					return true;
				});
				if (bestNode == null)
				{
					throw new Exception("Standing on node is NULL " + driver.Agent);
				}
				DebugEventLog.Write(new GoapDebugEvent(driver.Agent, GoapDebugEventCode.DriverQuickUnstuck_Teleport_1));
				driver.Teleport(bestNode.Position);
				return;
			}
			MapNode nodeBelow = node.GetNodeBelow();
			if (nodeBelow != null && nodeBelow.IsWater && driver.IsSwimming)
			{
				return;
			}
			if (node.IsWalkable && traversalProvider.CanStandOnNode(node))
			{
				float y = driver.Agent.GetPosition().y;
				if (!(y / (float)World.MapBlockHeight - (float)node.Position.y < 0.5f) && (node.Tag & (MapNodeTags.Ladder | MapNodeTags.WaterLevelHigh)) == 0)
				{
					Vector3 destinationWorldPos = driver.GetDestinationWorldPos(node);
					if (!(y - destinationWorldPos.y <= 0.1f))
					{
						DebugEventLog.Write(new GoapDebugEvent(driver.Agent, GoapDebugEventCode.DriverQuickUnstuck_Teleport_2));
						driver.Teleport(destinationWorldPos);
					}
				}
				return;
			}
			if (nodeBelow == null)
			{
				bool isEnabled;
				FVLogWarningInterpolationHandler messageBuilder = new FVLogWarningInterpolationHandler(80, 1, out isEnabled, "C:\\GIT\\dev\\Assets\\Scripts\\Village\\Pathfinding\\Driver\\DriverQuickUnstuck.cs");
				if (isEnabled)
				{
					messageBuilder.AppendLiteral("Node below is NULL. Agent:");
					messageBuilder.AppendFormatted(driver.Agent);
					messageBuilder.AppendLiteral(". Agent probably standing on the last node of the map.");
				}
				Log.Warning(messageBuilder);
				MapNode above = node.GetNodeAbove();
				if (above == null)
				{
					FVLogErrorInterpolationHandler messageBuilder2 = new FVLogErrorInterpolationHandler(65, 2, out isEnabled, "C:\\GIT\\dev\\Assets\\Scripts\\Village\\Pathfinding\\Driver\\DriverQuickUnstuck.cs");
					if (isEnabled)
					{
						messageBuilder2.AppendLiteral("Node above node:");
						messageBuilder2.AppendFormatted(node.Position);
						messageBuilder2.AppendLiteral(" dose not exists! This should never happen. Agent");
						messageBuilder2.AppendFormatted(driver.Agent);
					}
					Log.Error(messageBuilder2);
					return;
				}
				MonoSingleton<TaskController>.Instance.WaitForNextFrame().Then(delegate
				{
					if (!driver.HasDisposed)
					{
						DebugEventLog.Write(new GoapDebugEvent(driver.Agent, GoapDebugEventCode.DriverQuickUnstuck_Teleport_3));
						driver.Teleport(above.Position);
					}
				});
				return;
			}
			if (nodeBelow.IsWalkable && nodeBelow.Region != null && (nodeBelow.Region.Nodes.Count > 81 || nodeBelow.Region.Connections.Count > 3))
			{
				Vec3Int targetPos = nodeBelow.Position;
				MonoSingleton<TaskController>.Instance.WaitForNextFrame().Then(delegate
				{
					if (!driver.HasDisposed)
					{
						DebugEventLog.Write(new GoapDebugEvent(driver.Agent, GoapDebugEventCode.DriverQuickUnstuck_Teleport_4));
						driver.Teleport(targetPos);
					}
				});
				return;
			}
			List<MapNode> nodes = ListPool<MapNode>.Get(9);
			int standingOnY = node.Position.y;
			int diffZeroCount = 0;
			int countsOfNodesBelowOrOnSameY = 0;
			MapNodeUtils.ForEachNeighbour(node, delegate(MapNode mapNode3)
			{
				if (!mapNode3.IsWalkable)
				{
					return true;
				}
				if (!traversalProvider.CanStandOnNode(mapNode3))
				{
					return true;
				}
				int num5 = standingOnY - mapNode3.Position.y;
				if (nodes.Count > 0 && num5 == 0)
				{
					diffZeroCount++;
					countsOfNodesBelowOrOnSameY++;
					nodes.Insert(0, mapNode3);
					if (diffZeroCount > 3)
					{
						return false;
					}
					return true;
				}
				if (num5 > 0)
				{
					countsOfNodesBelowOrOnSameY++;
				}
				nodes.Add(mapNode3);
				return true;
			});
			MapNode failSafeNode = null;
			FloodFillUtil.FloodFillConnections(node, 40f, delegate(MapNode mapNode3)
			{
				if (!mapNode3.IsWalkable)
				{
					return FloodFillUtil.ScanStatus.Continue;
				}
				failSafeNode = mapNode3;
				Region region2 = mapNode3.Region;
				return (region2 != null && region2.IsBridge) ? FloodFillUtil.ScanStatus.Continue : FloodFillUtil.ScanStatus.Abort;
			});
			if (nodes.Count == 0)
			{
				ListPool<MapNode>.Return(nodes);
				Vec3Int position = node.Position;
				MapNode mapNode2 = null;
				for (int num2 = position.y - 1; num2 > 0; num2--)
				{
					MapNode node2 = driver.Agent.Map.GetNode(new Vec3Int(position.x, num2, position.z));
					if (!node2.HasWaterTag || failSafeNode == null || PathfinderUtil.IsPathPossible(driver.Agent.WalkableModel, node2, failSafeNode))
					{
						if (node2.IsWalkable)
						{
							mapNode2 = node2;
							break;
						}
						foreach (MapNode item in node2.ConnectionsSafe)
						{
							if (item.IsWalkable)
							{
								mapNode2 = item;
							}
						}
					}
				}
				if (mapNode2 == null)
				{
					mapNode2 = failSafeNode;
				}
				if (mapNode2 == null)
				{
					return;
				}
				Vec3Int nodeFoundPosition = mapNode2.Position;
				MonoSingleton<TaskController>.Instance.WaitForNextFrame().Then(delegate
				{
					if (!driver.HasDisposed)
					{
						DebugEventLog.Write(new GoapDebugEvent(driver.Agent, GoapDebugEventCode.DriverQuickUnstuck_Teleport_5));
						driver.Teleport(nodeFoundPosition);
					}
				});
				return;
			}
			if (countsOfNodesBelowOrOnSameY > 2)
			{
				nodes.RemoveAll((MapNode item) => item.Position.y > standingOnY);
			}
			int num3 = int.MinValue;
			int index = 0;
			for (int num4 = 0; num4 < nodes.Count; num4++)
			{
				Region region = nodes[num4].Region;
				if (region?.Nodes != null && region.Nodes.Count > num3)
				{
					num3 = region.Nodes.Count;
					index = num4;
				}
			}
			Vec3Int targetPos2 = nodes[index].Position;
			MonoSingleton<TaskController>.Instance.WaitForNextFrame().Then(delegate
			{
				if (!driver.HasDisposed)
				{
					DebugEventLog.Write(new GoapDebugEvent(driver.Agent, GoapDebugEventCode.DriverQuickUnstuck_Teleport_6));
					driver.Teleport(targetPos2);
				}
			});
			ListPool<MapNode>.Return(nodes);
		}
	}
}
