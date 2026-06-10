using System;
using System.Collections.Generic;
using System.Linq;
using FoxyVoxel.Logging;
using FoxyVoxel.Logging.Core.LogMessageInterpolationHandlers;
using NSEipix;
using NSEipix.Base;
using NSMedieval.BuildingComponents;
using NSMedieval.Enums;
using NSMedieval.Goap;
using NSMedieval.Map;
using NSMedieval.Model;
using NSMedieval.State;
using NSMedieval.Types;
using NSMedieval.Utils.Pool;
using NSMedieval.Utils.Pool.Janitors;
using NSMedieval.Village;
using NSMedieval.Village.Map;
using NSMedieval.Village.Map.Pathfinding;
using UnityEngine;

namespace NSMedieval.Manager
{
	public class CombatAttackerPositioningManager : MonoSingleton<CombatAttackerPositioningManager>
	{
		public const float RangedPositionSearchRangeLimit = 45f;

		public Path CreatePath(IDamageDealAgent agent, IDamageTakingAgent target, bool forceMelee = false)
		{
			if (CombatUtils.IsNullOrDisposed(agent, target))
			{
				return null;
			}
			if (!CombatUtils.CanBeTargeted(target))
			{
				return null;
			}
			Path path = null;
			if (!forceMelee && CombatUtils.GetAttackType(agent) != AttackType.Melee)
			{
				path = FindViableRangedAttackPositionFast(agent, target);
			}
			if (path != null)
			{
				return path;
			}
			if (target.DamageAgentType == DamageTakingAgentType.Building)
			{
				return FindBuildingAttackPositionPath(agent, target);
			}
			return FindMeleeViableAttackPosition(agent, target);
		}

		public bool CanCreatePath(IDamageDealAgent agent, IDamageTakingAgent target, bool executePathfinding = false, bool forceMelee = false)
		{
			if (CombatUtils.IsNullOrDisposed(agent, target))
			{
				return false;
			}
			if (!CombatUtils.IsAttackPossible(agent, target))
			{
				return false;
			}
			if (IsInAttackPosition(agent, target))
			{
				return true;
			}
			Path path = CreatePath(agent, target, forceMelee);
			if (path == null)
			{
				return false;
			}
			if (!executePathfinding)
			{
				Path.ReleasePath(path);
				return true;
			}
			MonoSingleton<PathProcessorManager>.Instance.InstantProcessPath(path);
			if (path.State != PathState.Calculated)
			{
				bool isEnabled;
				FVLogTraceInterpolationHandler messageBuilder = new FVLogTraceInterpolationHandler(68, 1, out isEnabled, "C:\\GIT\\dev\\Assets\\Scripts\\Combat\\Manager\\CombatAttackerPositioningManager.cs");
				if (isEnabled)
				{
					messageBuilder.AppendLiteral("CreateAttackPath failed after executing path calculations for agent ");
					messageBuilder.AppendFormatted(agent);
				}
				Log.Trace(messageBuilder);
				Path.ReleasePath(path);
				return false;
			}
			Path.ReleasePath(path);
			return true;
		}

		public static bool IsInAttackPosition(IDamageDealAgent attacker, IDamageTakingAgent target)
		{
			if (CombatUtils.IsNullOrDisposed(attacker, target))
			{
				return false;
			}
			if (CombatUtils.GetAttackType(attacker) != AttackType.Melee)
			{
				return IsInAttackPositionRanged(attacker, target);
			}
			return IsInAttackPositionMelee(attacker, target);
		}

		private static bool IsInAttackPositionRanged(IDamageDealAgent attacker, IDamageTakingAgent target)
		{
			if (CombatUtils.IsNullOrDisposed(attacker, target))
			{
				return false;
			}
			MapNode node = attacker.GetNode();
			if (CombatUtils.IsInAttackRange(attacker, target) && IsValidNode(node, 0f, attacker, target))
			{
				return CombatUtils.HasCombatLosMainThreadBlocking(node.Position, target.GetGridPosition());
			}
			return false;
		}

		private static bool IsInAttackPositionMelee(IDamageDealAgent attacker, IDamageTakingAgent target)
		{
			float maxHeightDiff = CombatUtils.GetMaxHeightDiff(attacker, target);
			bool flag = CombatUtils.IsInAttackRange(attacker, target, maxHeightDiff);
			FVLogTraceInterpolationHandler messageBuilder = new FVLogTraceInterpolationHandler(63, 5, out var isEnabled, "C:\\GIT\\dev\\Assets\\Scripts\\Combat\\Manager\\CombatAttackerPositioningManager.cs");
			if (isEnabled)
			{
				messageBuilder.AppendLiteral("MaxHeightDiff ");
				messageBuilder.AppendFormatted(maxHeightDiff);
				messageBuilder.AppendLiteral(", isInRange ");
				messageBuilder.AppendFormatted(flag);
				messageBuilder.AppendLiteral(", attackerPos ");
				messageBuilder.AppendFormatted(attacker.GetPosition());
				messageBuilder.AppendLiteral(", targetPos ");
				messageBuilder.AppendFormatted(target.GetPosition());
				messageBuilder.AppendLiteral(", attacker ");
				messageBuilder.AppendFormatted(attacker);
			}
			Log.Trace(messageBuilder);
			Vec3Int b = attacker.GetGridPosition();
			bool flag2;
			if ((target.DamageAgentType & DamageTakingAgentType.Building) != DamageTakingAgentType.None)
			{
				if (flag && Vec3Int.Distance(target.GetGridPosition(), in b) >= 1.3f)
				{
					flag2 = HasCombatLosMeleeTrippleRaycastBlocking(attacker.GetGridPosition().ToVector3World(), target.GetGridPosition().ToVector3World());
					messageBuilder = new FVLogTraceInterpolationHandler(41, 2, out isEnabled, "C:\\GIT\\dev\\Assets\\Scripts\\Combat\\Manager\\CombatAttackerPositioningManager.cs");
					if (isEnabled)
					{
						messageBuilder.AppendLiteral("Atk pos melee -> building hasLos ");
						messageBuilder.AppendFormatted(flag2);
						messageBuilder.AppendLiteral(", agent ");
						messageBuilder.AppendFormatted(attacker);
					}
					Log.Trace(messageBuilder);
					return flag2;
				}
				if (!flag)
				{
					messageBuilder = new FVLogTraceInterpolationHandler(30, 1, out isEnabled, "C:\\GIT\\dev\\Assets\\Scripts\\Combat\\Manager\\CombatAttackerPositioningManager.cs");
					if (isEnabled)
					{
						messageBuilder.AppendLiteral("Atk pos melee -> not in range ");
						messageBuilder.AppendFormatted(attacker);
					}
					Log.Trace(messageBuilder);
				}
				return flag;
			}
			MapNode node = attacker.Map.GetNode(b);
			if (node == null)
			{
				return false;
			}
			if (node.CreaturesCount > 3)
			{
				messageBuilder = new FVLogTraceInterpolationHandler(46, 1, out isEnabled, "C:\\GIT\\dev\\Assets\\Scripts\\Combat\\Manager\\CombatAttackerPositioningManager.cs");
				if (isEnabled)
				{
					messageBuilder.AppendLiteral("Not in atk pos melee creatureCount > 1, agent ");
					messageBuilder.AppendFormatted(attacker);
				}
				Log.Trace(messageBuilder);
				return false;
			}
			if (attacker.CombatAi == null || !flag)
			{
				messageBuilder = new FVLogTraceInterpolationHandler(32, 2, out isEnabled, "C:\\GIT\\dev\\Assets\\Scripts\\Combat\\Manager\\CombatAttackerPositioningManager.cs");
				if (isEnabled)
				{
					messageBuilder.AppendLiteral("Atk pos melee isInRange ");
					messageBuilder.AppendFormatted(flag);
					messageBuilder.AppendLiteral(", agent ");
					messageBuilder.AppendFormatted(attacker);
				}
				Log.Trace(messageBuilder);
				return flag;
			}
			flag2 = HasCombatLosMeleeTrippleRaycastBlocking(attacker.GetGridPosition().ToVector3World(), target.GetGridPosition().ToVector3World());
			messageBuilder = new FVLogTraceInterpolationHandler(29, 2, out isEnabled, "C:\\GIT\\dev\\Assets\\Scripts\\Combat\\Manager\\CombatAttackerPositioningManager.cs");
			if (isEnabled)
			{
				messageBuilder.AppendLiteral("Atk pos melee hasLos ");
				messageBuilder.AppendFormatted(flag2);
				messageBuilder.AppendLiteral(", agent ");
				messageBuilder.AppendFormatted(attacker);
			}
			Log.Trace(messageBuilder);
			return flag2;
		}

		public static bool IsInHeightDiffLimitRange(IDamageDealAgent deal, IDamageTakingAgent take)
		{
			if (CombatUtils.IsNullOrDisposed(deal, take) || take.GetNode() == null || deal.GetNode() == null)
			{
				return false;
			}
			float maxHeightDiff = CombatUtils.GetMaxHeightDiff(deal, take);
			if (maxHeightDiff < 0f)
			{
				return true;
			}
			return Mathf.Abs(deal.GetPosition().y - take.GetPosition().y) <= maxHeightDiff;
		}

		private List<Vec3Int> GatherBuildingAttackPositions(IDamageDealAgent attacker, IDamageTakingAgent target)
		{
			if (target is BaseBuildingInstance baseBuildingInstance)
			{
				IPathfindingAgent pathAgent = attacker as IPathfindingAgent;
				if (pathAgent != null)
				{
					WorldDirection direction = WorldDirection.N | WorldDirection.NE | WorldDirection.E | WorldDirection.SE | WorldDirection.S | WorldDirection.SW | WorldDirection.W | WorldDirection.NW;
					List<Vec3Int> possibleAttackPoints = ListPool<Vec3Int>.Get(8);
					foreach (Vec3Int position in baseBuildingInstance.Positions)
					{
						if (possibleAttackPoints.Count >= 8)
						{
							break;
						}
						PathTraversalProvider provider = pathAgent.PathTraversalProvider;
						ReachabilityUtil.IterateTroughReachablePositions(position, direction, delegate(MapNode node)
						{
							if (possibleAttackPoints.Count < 8)
							{
								if (node.CreaturesCount > 3)
								{
									DebugNodeSearchStatus(node, isValidNode: false);
								}
								else if (!provider.CanStandOnNode(node))
								{
									DebugNodeSearchStatus(node, isValidNode: false);
								}
								else
								{
									if (node.GetWorldObject(GridDataType.BuildingFinished, (WorldObject item) => ((BaseBuildingInstance)item).BuildingType != BuildingType.Floor) is BaseBuildingInstance baseBuildingInstance2)
									{
										DoorComponentInstance componentInstance = baseBuildingInstance2.GetComponentInstance<DoorComponentInstance>();
										if (componentInstance == null)
										{
											DebugNodeSearchStatus(node, isValidNode: false);
											return;
										}
										if (componentInstance.LockState != LockState.AlwaysOpen && componentInstance.LockState != LockState.ForcedOpen)
										{
											DebugNodeSearchStatus(node, isValidNode: false);
											return;
										}
									}
									if (!PathfinderUtil.IsPathPossible(pathAgent, node))
									{
										DebugNodeSearchStatus(node, isValidNode: false);
									}
									else
									{
										float maxHeightDiff = CombatUtils.GetMaxHeightDiff(attacker, target, node);
										if (Mathf.Abs(node.WorldPosition.y - target.GetPosition().y) > maxHeightDiff && node.IsLayerRamp())
										{
											DebugNodeSearchStatus(node, isValidNode: false);
										}
										else if (!MonoSingleton<CombatAttackTracker>.Instance.CanBeReservedBy(node.Position, attacker))
										{
											DebugNodeSearchStatus(node, isValidNode: false);
										}
										else
										{
											DebugNodeSearchStatus(node, isValidNode: true);
											possibleAttackPoints.Add(node.Position);
										}
									}
								}
							}
						});
					}
					if (possibleAttackPoints == null || possibleAttackPoints.Count == 0)
					{
						ListPool<Vec3Int>.Return(possibleAttackPoints);
						return null;
					}
					RemoveNoCombatLosPositionsBlocking(possibleAttackPoints, target.GetGridPosition());
					if (possibleAttackPoints.Count == 0)
					{
						return null;
					}
					return possibleAttackPoints;
				}
			}
			return null;
			static void DebugNodeSearchStatus(MapNode node, bool isValidNode)
			{
			}
		}

		private Path FindBuildingAttackPositionPath(IDamageDealAgent attacker, IDamageTakingAgent target)
		{
			List<Vec3Int> list = GatherBuildingAttackPositions(attacker, target);
			if (list == null)
			{
				return null;
			}
			P2MultiPath result = P2MultiPath.Construct((IPathfindingAgent)attacker, 1, list.ToList(), shouldSort: false);
			ListPool<Vec3Int>.Return(list);
			return result;
		}

		private Path FindMeleeViableAttackPosition(IDamageDealAgent attacker, IDamageTakingAgent target)
		{
			if (CombatUtils.IsNullOrDisposed(attacker, target))
			{
				return null;
			}
			IPathfindingAgent pathfindingAgent = (IPathfindingAgent)attacker;
			float range = CombatUtils.GetRange(attacker, target);
			MapNode targetStandingOnNode = target.GetNode();
			MapNode nodeBelow = targetStandingOnNode.GetNodeBelow();
			if (targetStandingOnNode.Tag.HasFlag(MapNodeTags.Ladder) || targetStandingOnNode.IsWater || (nodeBelow != null && nodeBelow.Tag.HasFlag(MapNodeTags.Ladder)))
			{
				return FindMeleeLadderAttackPosition(attacker, target);
			}
			bool targetIsOnRamp = target.GetNode().IsLayerRamp();
			List<Vec3Int> validGridPositions = new List<Vec3Int>();
			PathfindingPenalty walkableModelPathfindingPenalty = pathfindingAgent.WalkableModel.PathfindingPenalty;
			FloodFillUtil.FloodFillConnections(attacker.Map, targetStandingOnNode.Position, range, delegate(MapNode node)
			{
				if (!node.IsWalkable)
				{
					return FloodFillUtil.ScanStatus.Continue;
				}
				if (!targetIsOnRamp && node == targetStandingOnNode)
				{
					return FloodFillUtil.ScanStatus.Continue;
				}
				if (node.GetPenalty(walkableModelPathfindingPenalty) >= ushort.MaxValue)
				{
					return FloodFillUtil.ScanStatus.Continue;
				}
				float maxHeightDiff = CombatUtils.GetMaxHeightDiff(attacker, target, node, forceMelee: true);
				if (!IsValidNode(node, maxHeightDiff, attacker, target, forceMelee: true))
				{
					return FloodFillUtil.ScanStatus.Continue;
				}
				if (MonoSingleton<CombatAttackTracker>.Instance.CanBeReservedBy(node.Position, attacker))
				{
					validGridPositions.Add(node.Position);
				}
				return FloodFillUtil.ScanStatus.Continue;
			});
			bool isEnabled;
			if (validGridPositions.Count == 0)
			{
				FVLogTraceInterpolationHandler messageBuilder = new FVLogTraceInterpolationHandler(55, 1, out isEnabled, "C:\\GIT\\dev\\Assets\\Scripts\\Combat\\Manager\\CombatAttackerPositioningManager.cs");
				if (isEnabled)
				{
					messageBuilder.AppendLiteral("CreateAttackPath failed, no valid grid positions found ");
					messageBuilder.AppendFormatted(attacker);
				}
				Log.Trace(messageBuilder);
				return null;
			}
			RemoveNoCombatLosPositionsBlocking(validGridPositions, target.GetGridPosition());
			if (validGridPositions.Count == 0)
			{
				FVLogTraceInterpolationHandler messageBuilder = new FVLogTraceInterpolationHandler(81, 1, out isEnabled, "C:\\GIT\\dev\\Assets\\Scripts\\Combat\\Manager\\CombatAttackerPositioningManager.cs");
				if (isEnabled)
				{
					messageBuilder.AppendLiteral("CreateAttackPath failed, no valid grid positions found after no LoS ones removed ");
					messageBuilder.AppendFormatted(attacker);
				}
				Log.Trace(messageBuilder);
				return null;
			}
			P2MultiPath p2MultiPath = P2MultiPath.Construct(pathfindingAgent, 1, validGridPositions);
			if (p2MultiPath == null)
			{
				FVLogTraceInterpolationHandler messageBuilder = new FVLogTraceInterpolationHandler(56, 1, out isEnabled, "C:\\GIT\\dev\\Assets\\Scripts\\Combat\\Manager\\CombatAttackerPositioningManager.cs");
				if (isEnabled)
				{
					messageBuilder.AppendLiteral("CreateAttackPath failed, final path construction failed ");
					messageBuilder.AppendFormatted(attacker);
				}
				Log.Trace(messageBuilder);
			}
			return p2MultiPath;
		}

		private static void RemoveNoCombatLosPositionsBlocking(List<Vec3Int> possibleGridPositions, Vec3Int targetPosition)
		{
			Vector3 targetWorldPosition = targetPosition.ToVector3World();
			MonoSingleton<ThreadingJobSystem>.Instance.ExecuteOnMainThreadBlocking(delegate
			{
				int num = 0;
				while (num < possibleGridPositions.Count)
				{
					if (!HasCombatLosMeleeTrippleRaycast(possibleGridPositions[num].ToVector3World(), targetWorldPosition))
					{
						possibleGridPositions.RemoveAt(num);
					}
					else
					{
						num++;
					}
				}
			});
		}

		private static bool HasCombatLosMeleeTrippleRaycast(Vector3 start, Vector3 end)
		{
			Vector3 normal = end - start;
			Vector3 tangent = default(Vector3);
			Vector3 binormal = default(Vector3);
			Vector3.OrthoNormalize(ref normal, ref tangent, ref binormal);
			Vector3 vector = (Mathf.Approximately(binormal.y, 0f) ? binormal : tangent);
			if (!CombatUtils.HasCombatLos(start, end) && !CombatUtils.HasCombatLos(start + vector * 0.4f, end + vector * 0.4f))
			{
				return CombatUtils.HasCombatLos(start - vector * 0.4f, end - vector * 0.4f);
			}
			return true;
		}

		private static bool HasCombatLosMeleeTrippleRaycastBlocking(Vector3 start, Vector3 end)
		{
			bool result = false;
			MonoSingleton<ThreadingJobSystem>.Instance.ExecuteOnMainThreadBlocking(delegate
			{
				result = HasCombatLosMeleeTrippleRaycast(start, end);
			});
			return result;
		}

		private Path FindMeleeLadderAttackPosition(IDamageDealAgent attacker, IDamageTakingAgent target)
		{
			if (CombatUtils.IsNullOrDisposed(attacker, target))
			{
				return null;
			}
			IPathfindingAgent pathfindingAgent = (IPathfindingAgent)attacker;
			MapNode targetStandingOnNode = target.GetNode();
			List<Vec3Int> validGridPositions = new List<Vec3Int>();
			MapNodeUtils.ForEachNeighbour(targetStandingOnNode, delegate(MapNode node)
			{
				bool isEnabled2;
				if (!node.IsWalkable || (node != targetStandingOnNode && !PathfinderUtil.IsPathPossible(pathfindingAgent, node)))
				{
					FVLogTraceInterpolationHandler messageBuilder2 = new FVLogTraceInterpolationHandler(34, 2, out isEnabled2, "C:\\GIT\\dev\\Assets\\Scripts\\Combat\\Manager\\CombatAttackerPositioningManager.cs");
					if (isEnabled2)
					{
						messageBuilder2.AppendLiteral("Unwalkable or path not possible ");
						messageBuilder2.AppendFormatted(node.Position);
						messageBuilder2.AppendLiteral(", ");
						messageBuilder2.AppendFormatted(attacker);
					}
					Log.Trace(messageBuilder2);
					return true;
				}
				bool flag = false;
				if (node.Position.y > targetStandingOnNode.Position.y)
				{
					if (target.GetPosition().y - targetStandingOnNode.WorldPosition.y >= (float)World.MapBlockHeight / 2f)
					{
						flag = IsValidNode(node, -1f, attacker, target);
					}
				}
				else
				{
					flag = IsValidNode(node, -1f, attacker, target);
				}
				if (!flag)
				{
					FVLogTraceInterpolationHandler messageBuilder2 = new FVLogTraceInterpolationHandler(15, 2, out isEnabled2, "C:\\GIT\\dev\\Assets\\Scripts\\Combat\\Manager\\CombatAttackerPositioningManager.cs");
					if (isEnabled2)
					{
						messageBuilder2.AppendLiteral("Invalid node ");
						messageBuilder2.AppendFormatted(node.Position);
						messageBuilder2.AppendLiteral(", ");
						messageBuilder2.AppendFormatted(attacker);
					}
					Log.Trace(messageBuilder2);
					return true;
				}
				if (node.Tag.HasFlag(MapNodeTags.Ladder))
				{
					validGridPositions.Add(node.Position);
				}
				else if (MonoSingleton<CombatAttackTracker>.Instance.CanBeReservedBy(node.Position, attacker))
				{
					validGridPositions.Add(node.Position);
				}
				else
				{
					FVLogTraceInterpolationHandler messageBuilder2 = new FVLogTraceInterpolationHandler(20, 2, out isEnabled2, "C:\\GIT\\dev\\Assets\\Scripts\\Combat\\Manager\\CombatAttackerPositioningManager.cs");
					if (isEnabled2)
					{
						messageBuilder2.AppendLiteral("Can't be reserved ");
						messageBuilder2.AppendFormatted(node.Position);
						messageBuilder2.AppendLiteral(", ");
						messageBuilder2.AppendFormatted(attacker);
					}
					Log.Trace(messageBuilder2);
				}
				return true;
			});
			bool isEnabled;
			FVLogTraceInterpolationHandler messageBuilder;
			if (validGridPositions.Count == 0)
			{
				messageBuilder = new FVLogTraceInterpolationHandler(31, 1, out isEnabled, "C:\\GIT\\dev\\Assets\\Scripts\\Combat\\Manager\\CombatAttackerPositioningManager.cs");
				if (isEnabled)
				{
					messageBuilder.AppendLiteral("validGridPositions.Count == 0, ");
					messageBuilder.AppendFormatted(attacker);
				}
				Log.Trace(messageBuilder);
				return null;
			}
			RemoveNoCombatLosPositionsBlocking(validGridPositions, target.GetGridPosition());
			if (validGridPositions.Count == 0)
			{
				messageBuilder = new FVLogTraceInterpolationHandler(58, 1, out isEnabled, "C:\\GIT\\dev\\Assets\\Scripts\\Combat\\Manager\\CombatAttackerPositioningManager.cs");
				if (isEnabled)
				{
					messageBuilder.AppendLiteral("RemoveNoCombatLosPositionsBlocking removed all positions, ");
					messageBuilder.AppendFormatted(attacker);
				}
				Log.Trace(messageBuilder);
				return null;
			}
			messageBuilder = new FVLogTraceInterpolationHandler(36, 1, out isEnabled, "C:\\GIT\\dev\\Assets\\Scripts\\Combat\\Manager\\CombatAttackerPositioningManager.cs");
			if (isEnabled)
			{
				messageBuilder.AppendLiteral("Found valid ladder attack positions ");
				messageBuilder.AppendFormatted(validGridPositions.Count);
			}
			Log.Trace(messageBuilder);
			return P2MultiPath.Construct(pathfindingAgent, 1, validGridPositions);
		}

		private static Path FindViableRangedAttackPositionFast(IDamageDealAgent attacker, IDamageTakingAgent target)
		{
			float range = CombatUtils.GetRange(attacker, target);
			Vec3Int gridPosition = target.GetGridPosition();
			if (!(attacker is IPathfindingAgent agent))
			{
				throw new Exception("Invalid attacker type passed to method: must implement IPathfindingAgent");
			}
			using PooledHashSet<float> pooledHashSet = HashSetPool<float>.GetJanitor();
			PooledList<MapNode> candidateNodes = ListPool<MapNode>.GetJanitor();
			try
			{
				foreach (MapNode item in FloodFillUtil.IterateFloodFill3D(attacker.Map, gridPosition, range, onlyWalkable: true, roundedCylinder: true))
				{
					if (PathfinderUtil.IsPathPossible(agent, item))
					{
						float num = Vector2.SignedAngle((item.WorldPosition.ToVector2XZ() - target.GetPosition().ToVector2XZ()).normalized, Vector2.left);
						if (num < 0f)
						{
							num = Mathf.Abs(num) + 180f;
						}
						num = 22.5f * (float)(int)(num / 22.5f);
						float obj = num + 1000f * (float)item.Position.y;
						if (pooledHashSet.Add(obj) && IsValidNode(item, 0f, attacker, target))
						{
							candidateNodes.Add(item);
						}
					}
				}
				int connectionsAddedCount = 0;
				foreach (MapNode item2 in target.GetNode().ConnectionsSafe)
				{
					if (PathfinderUtil.IsPathPossible(agent, item2) && IsValidNode(item2, 0f, attacker, target))
					{
						connectionsAddedCount++;
						candidateNodes.Insert(0, item2);
					}
				}
				bool isEnabled;
				if (candidateNodes.Count == 0)
				{
					FVLogTraceInterpolationHandler messageBuilder = new FVLogTraceInterpolationHandler(57, 1, out isEnabled, "C:\\GIT\\dev\\Assets\\Scripts\\Combat\\Manager\\CombatAttackerPositioningManager.cs");
					if (isEnabled)
					{
						messageBuilder.AppendLiteral("CreateAttackPath ranged failed, no candidate nodes found ");
						messageBuilder.AppendFormatted(attacker);
					}
					Log.Trace(messageBuilder);
					return null;
				}
				List<Vec3Int> positions = new List<Vec3Int>();
				int satisfiedCount = connectionsAddedCount + 3;
				MonoSingleton<ThreadingJobSystem>.Instance.ExecuteOnMainThreadBlocking(delegate
				{
					for (int i = 0; i < candidateNodes.Count; i++)
					{
						MapNode mapNode = candidateNodes[i];
						if (i >= connectionsAddedCount && !CombatUtils.HasCombatLos(mapNode.WorldPosition, target.GetPosition()))
						{
							bool isEnabled2;
							FVLogTraceInterpolationHandler messageBuilder2 = new FVLogTraceInterpolationHandler(35, 2, out isEnabled2, "C:\\GIT\\dev\\Assets\\Scripts\\Combat\\Manager\\CombatAttackerPositioningManager.cs");
							if (isEnabled2)
							{
								messageBuilder2.AppendLiteral("No combat LoS for candidate node ");
								messageBuilder2.AppendFormatted(mapNode.Position);
								messageBuilder2.AppendLiteral(", ");
								messageBuilder2.AppendFormatted(attacker);
							}
							Log.Trace(messageBuilder2);
						}
						else
						{
							positions.Add(mapNode.Position);
							if (positions.Count >= satisfiedCount)
							{
								break;
							}
						}
					}
				});
				if (positions.Count == 0)
				{
					FVLogTraceInterpolationHandler messageBuilder = new FVLogTraceInterpolationHandler(60, 1, out isEnabled, "C:\\GIT\\dev\\Assets\\Scripts\\Combat\\Manager\\CombatAttackerPositioningManager.cs");
					if (isEnabled)
					{
						messageBuilder.AppendLiteral("CreateAttackPath ranged failed, no positions with LoS found ");
						messageBuilder.AppendFormatted(attacker);
					}
					Log.Trace(messageBuilder);
					return null;
				}
				P2MultiPath p2MultiPath = P2MultiPath.Construct((IPathfindingAgent)attacker, 1, positions);
				if (p2MultiPath == null)
				{
					FVLogTraceInterpolationHandler messageBuilder = new FVLogTraceInterpolationHandler(63, 1, out isEnabled, "C:\\GIT\\dev\\Assets\\Scripts\\Combat\\Manager\\CombatAttackerPositioningManager.cs");
					if (isEnabled)
					{
						messageBuilder.AppendLiteral("CreateAttackPath ranged failed, final path construction failed ");
						messageBuilder.AppendFormatted(attacker);
					}
					Log.Trace(messageBuilder);
				}
				return p2MultiPath;
			}
			finally
			{
				((IDisposable)candidateNodes/*cast due to .constrained prefix*/).Dispose();
			}
		}

		private static bool IsValidNode(MapNode node, float maxHeightDiff, IDamageDealAgent attacker, IDamageTakingAgent target, bool forceMelee = false)
		{
			if (node == null)
			{
				return false;
			}
			AttackType attackType = CombatUtils.GetAttackType(attacker);
			bool flag = !forceMelee && (attackType == AttackType.RangeChargeAfter || attackType == AttackType.RangeChargeBefore);
			if (flag && node.IsWater && !node.Map.WaterManager.CanWalkInside(node))
			{
				Log.Trace($"IsValidNode {node.Position} false water, agent {attacker}", "CombatAttackerPositioningManager_IsValidNode");
				return false;
			}
			IPathfindingAgent pathfindingAgent = (IPathfindingAgent)attacker;
			if (!pathfindingAgent.PathTraversalProvider.CanStandOnNode(node))
			{
				Log.Trace($"IsValidNode {node.Position} false can't traverse, agent {attacker}", "CombatAttackerPositioningManager_IsValidNode");
				return false;
			}
			Vec3Int position = node.Position;
			Vector3 worldPosition = node.WorldPosition;
			Vec3Int gridPosition = pathfindingAgent.GetGridPosition();
			Vector3 position2 = target.GetPosition();
			if (maxHeightDiff > 0f && Mathf.Abs(worldPosition.y - position2.y) > maxHeightDiff)
			{
				Log.Trace($"IsValidNode {node.Position} false height diff ({Mathf.Abs(worldPosition.y - position2.y)} > {maxHeightDiff}), agent {attacker}", "CombatAttackerPositioningManager_IsValidNode");
				return false;
			}
			WeaponMode weaponModeOverride = null;
			bool forbidWeapon = attacker.ForbidWeapon;
			if (forceMelee)
			{
				EquipmentInstance weapon = CombatUtils.GetWeapon(attacker);
				if (weapon != null)
				{
					if (weapon.ActiveWeaponMode.WeaponTypeSettings.AttackType != AttackType.Melee && weapon.OtherWeaponMode != null && weapon.OtherWeaponMode.WeaponTypeSettings.AttackType == AttackType.Melee)
					{
						weaponModeOverride = weapon.OtherWeaponMode;
					}
					else
					{
						attacker.ForbidWeapon = true;
					}
				}
			}
			bool num = CombatUtils.IsInAttackRange(attacker, target, -1f, weaponModeOverride, node);
			attacker.ForbidWeapon = forbidWeapon;
			if (!num)
			{
				Log.Trace($"IsValidNode {node.Position} false out of range, agent {attacker}", "CombatAttackerPositioningManager_IsValidNode");
				return false;
			}
			if (!PathfinderUtil.IsPathPossible(pathfindingAgent, position, gridPosition))
			{
				Log.Trace($"IsValidNode {node.Position} false impossible path, agent {attacker}", "CombatAttackerPositioningManager_IsValidNode");
				return false;
			}
			MapNode node2 = target.GetNode();
			if (!flag && (node2.Tag & MapNodeTags.Ladder) != MapNodeTags.None && (node.Position.x != node2.Position.x || node.Position.z != node2.Position.z) && (position.y != node2.Position.y || Mathf.Abs(node2.WorldPosition.y - position2.y) > 1.3f))
			{
				Log.Trace($"IsValidNode {node.Position} false ladder, agent {attacker}", "CombatAttackerPositioningManager_IsValidNode");
				return false;
			}
			if (node.CreaturesCount > 0)
			{
				if ((node.Tag & MapNodeTags.Ladder) != MapNodeTags.None)
				{
					if (node.Map.CreaturesOnNodes.TryGetValue(node.Index, out var value) && value.Any((CreatureBase item) => item is HumanoidInstance humanoidInstance && humanoidInstance.IsEnemy()))
					{
						Log.Trace($"IsValidNode {node.Position} false ladder enemy already on it, agent {attacker}", "CombatAttackerPositioningManager_IsValidNode");
						return false;
					}
					return true;
				}
				if (node.CreaturesCount >= 3)
				{
					Log.Trace($"IsValidNode {node.Position} false max creatures on node, agent {attacker}", "CombatAttackerPositioningManager_IsValidNode");
					return false;
				}
			}
			Log.Trace($"IsValidNode {node.Position} true, agent {attacker}", "CombatAttackerPositioningManager_IsValidNode");
			return true;
		}
	}
}
