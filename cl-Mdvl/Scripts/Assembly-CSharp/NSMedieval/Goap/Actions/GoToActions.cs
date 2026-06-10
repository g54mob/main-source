using System;
using System.Collections.Generic;
using System.Linq;
using FoxyVoxel.Logging;
using FoxyVoxel.Logging.Core.LogMessageInterpolationHandlers;
using NSEipix;
using NSEipix.Base;
using NSMedieval.CombatAi;
using NSMedieval.DebugEvents;
using NSMedieval.Manager;
using NSMedieval.Pathfinding;
using NSMedieval.State;
using NSMedieval.View.Animals;
using NSMedieval.Village;
using NSMedieval.Village.Map;
using NSMedieval.Village.Map.Pathfinding;
using UnityEngine;

namespace NSMedieval.Goap.Actions
{
	public static class GoToActions
	{
		public static GoapAction GoToTarget(TargetIndex targetIndex, PathCompleteMode pathCompleteMode, Vector3 lookAtPointOverride = default(Vector3))
		{
			GoapAction goapAction = GoToTargetNoFailCheck(targetIndex, pathCompleteMode, lookAtPointOverride);
			goapAction.FailIfTargetBecomesUnreachable();
			return goapAction;
		}

		public static GoapAction GoToTargetNoFailCheck(TargetIndex targetIndex, PathCompleteMode pathCompleteMode, Vector3 lookAtPointOverride = default(Vector3))
		{
			GoapAction action = new GoapAction("GoToTarget");
			action.OnInit = delegate
			{
				TargetObject target = action.Goal.GetTarget(targetIndex);
				IPathfindingAgent agent = (IPathfindingAgent)action.AgentOwner;
				Vec3Int targetGridPos = target.ReachablePosition;
				PathfinderAgentDriver driver;
				if (targetGridPos == agent.GetGridPosition())
				{
					action.Complete(ActionCompletionStatus.Success);
				}
				else if (pathCompleteMode != PathCompleteMode.NeverFail && CompleteModeConditions.IsCompleteModeFulfilled(agent.GetGridPosition(), targetGridPos, pathCompleteMode))
				{
					action.CompleteMode = ActionCompleteMode.Instant;
				}
				else
				{
					if (!PathfinderUtil.IsPathPossible(agent, targetGridPos))
					{
						if (!(target.ObjectInstance is WorldObject worldObject))
						{
							action.Complete(ActionCompletionStatus.Fail);
							return;
						}
						targetGridPos = worldObject.GetFirstReachablePosition(agent);
					}
					else if (target.ObjectInstance is WorldObject worldObject2 && target.ObjectInstance.GetGridPosition().Equals(targetGridPos))
					{
						targetGridPos = worldObject2.GetFirstReachablePosition(agent);
					}
					if (targetGridPos.Equals(Vec3Int.zero))
					{
						action.Complete(ActionCompletionStatus.Fail);
					}
					else
					{
						action.CompleteMode = ActionCompleteMode.Never;
						driver = agent.PathDriver;
						P2PPath path = P2PPath.Construct(agent, targetGridPos);
						driver.ExecutePath(new PathfinderDriverExecCfg
						{
							Path = path,
							StatusCb = delegate(bool success)
							{
								if (!success)
								{
									action.Complete(ActionCompletionStatus.Fail);
								}
								else
								{
									driver.OnClearPathEvent += Callback;
								}
							}
						});
					}
				}
				void Callback(PathfinderAgentDriver dr, PathDriverCompletionState st)
				{
					driver.OnClearPathEvent -= Callback;
					if (!CompleteModeConditions.IsCompleteModeFulfilled(agent.GetGridPosition(), targetGridPos, pathCompleteMode))
					{
						action.Complete(ActionCompletionStatus.Fail);
					}
					else
					{
						action.Complete(ActionCompletionStatus.Success);
					}
				}
			};
			action.OnComplete = delegate(ActionCompletionStatus status)
			{
				IPathfindingAgent agent = (IPathfindingAgent)action.AgentOwner;
				if (status != ActionCompletionStatus.Success)
				{
					agent?.PathDriver?.Abort();
				}
				else
				{
					TargetObject target = action.Goal.GetTarget(targetIndex);
					Vector3 lookAtPosition;
					if (lookAtPointOverride != default(Vector3))
					{
						lookAtPosition = lookAtPointOverride;
					}
					else
					{
						lookAtPosition = target.ObjectInstance?.GetPosition() ?? GridUtils.GetWorldPosition(target.ReachablePosition);
					}
					MonoSingleton<TaskController>.Instance.WaitForNextFrame().Then(delegate
					{
						agent?.FaceObject(lookAtPosition);
					});
				}
			};
			action.OnTick = delegate
			{
				if (!(action.TotalTickingTime < 5f))
				{
					IPathfindingAgent pathfindingAgent = (IPathfindingAgent)action.AgentOwner;
					if (pathfindingAgent.HasDisposed || pathfindingAgent.PathDriver == null || pathfindingAgent.PathDriver.TimeWithoutPath > 5f)
					{
						bool isEnabled;
						FVLogWarningInterpolationHandler messageBuilder = new FVLogWarningInterpolationHandler(104, 5, out isEnabled, "C:\\GIT\\dev\\Assets\\Scripts\\GOAP\\Action\\GoToActions.cs");
						if (isEnabled)
						{
							messageBuilder.AppendLiteral("GoTo action runtime failure detected. Aborting action. Agent:");
							messageBuilder.AppendFormatted(pathfindingAgent);
							messageBuilder.AppendLiteral(" Goal:");
							messageBuilder.AppendFormatted(action.Goal.Id);
							messageBuilder.AppendLiteral(" Target:(");
							messageBuilder.AppendFormatted(action.Goal.GetTarget(targetIndex).ReachablePosition);
							messageBuilder.AppendLiteral(") TimeWithoutPath:");
							messageBuilder.AppendFormatted(pathfindingAgent.PathDriver?.TimeWithoutPath);
							messageBuilder.AppendLiteral(". ActTime:");
							messageBuilder.AppendFormatted(action.TotalTickingTime);
						}
						Log.Warning(messageBuilder);
						action.Complete(ActionCompletionStatus.Error);
					}
				}
			};
			action.CompleteMode = ActionCompleteMode.Never;
			return action;
		}

		public static GoapAction GoToTargetNoRotation(TargetIndex targetIndex, PathCompleteMode pathCompleteMode)
		{
			GoapAction goapAction = GoToTargetNoFailCheckNoRotation(targetIndex, pathCompleteMode);
			goapAction.FailIfTargetBecomesUnreachable();
			return goapAction;
		}

		public static GoapAction GoToTargetNoFailCheckNoRotation(TargetIndex targetIndex, PathCompleteMode pathCompleteMode)
		{
			GoapAction action = new GoapAction("GoToTarget");
			action.OnInit = delegate
			{
				TargetObject target = action.Goal.GetTarget(targetIndex);
				IPathfindingAgent agent = (IPathfindingAgent)action.AgentOwner;
				Vec3Int targetGridPos = target.ReachablePosition;
				PathfinderAgentDriver driver;
				if (targetGridPos == agent.GetGridPosition())
				{
					action.Complete(ActionCompletionStatus.Success);
				}
				else if (pathCompleteMode != PathCompleteMode.NeverFail && CompleteModeConditions.IsCompleteModeFulfilled(agent.GetGridPosition(), targetGridPos, pathCompleteMode))
				{
					action.CompleteMode = ActionCompleteMode.Instant;
				}
				else
				{
					if (!PathfinderUtil.IsPathPossible(agent, targetGridPos))
					{
						if (!(target.ObjectInstance is WorldObject worldObject))
						{
							action.Complete(ActionCompletionStatus.Fail);
							return;
						}
						targetGridPos = worldObject.GetFirstReachablePosition(agent);
					}
					else if (target.ObjectInstance is WorldObject worldObject2 && target.ObjectInstance.GetGridPosition().Equals(targetGridPos))
					{
						targetGridPos = worldObject2.GetFirstReachablePosition(agent);
					}
					if (targetGridPos.Equals(Vec3Int.zero))
					{
						action.Complete(ActionCompletionStatus.Fail);
					}
					else
					{
						action.CompleteMode = ActionCompleteMode.Never;
						driver = agent.PathDriver;
						P2PPath path = P2PPath.Construct(agent, targetGridPos);
						driver.ExecutePath(new PathfinderDriverExecCfg
						{
							Path = path,
							StatusCb = delegate(bool success)
							{
								if (!success)
								{
									action.Complete(ActionCompletionStatus.Fail);
								}
								else
								{
									driver.OnClearPathEvent += Callback;
								}
							}
						});
					}
				}
				void Callback(PathfinderAgentDriver dr, PathDriverCompletionState st)
				{
					driver.OnClearPathEvent -= Callback;
					if (!CompleteModeConditions.IsCompleteModeFulfilled(agent.GetGridPosition(), targetGridPos, pathCompleteMode))
					{
						action.Complete(ActionCompletionStatus.Fail);
					}
					else
					{
						action.Complete(ActionCompletionStatus.Success);
					}
				}
			};
			action.OnComplete = delegate(ActionCompletionStatus status)
			{
				IPathfindingAgent pathfindingAgent = (IPathfindingAgent)action.AgentOwner;
				if (status != ActionCompletionStatus.Success)
				{
					pathfindingAgent?.PathDriver?.Abort();
				}
			};
			action.OnTick = delegate
			{
				if (!(action.TotalTickingTime < 5f))
				{
					IPathfindingAgent pathfindingAgent = (IPathfindingAgent)action.AgentOwner;
					if (pathfindingAgent.HasDisposed || pathfindingAgent.PathDriver == null || pathfindingAgent.PathDriver.TimeWithoutPath > 5f)
					{
						bool isEnabled;
						FVLogErrorInterpolationHandler messageBuilder = new FVLogErrorInterpolationHandler(104, 5, out isEnabled, "C:\\GIT\\dev\\Assets\\Scripts\\GOAP\\Action\\GoToActions.cs");
						if (isEnabled)
						{
							messageBuilder.AppendLiteral("GoTo action runtime failure detected. Aborting action. Agent:");
							messageBuilder.AppendFormatted(pathfindingAgent);
							messageBuilder.AppendLiteral(" Goal:");
							messageBuilder.AppendFormatted(action.Goal.Id);
							messageBuilder.AppendLiteral(" Target:(");
							messageBuilder.AppendFormatted(action.Goal.GetTarget(targetIndex).ReachablePosition);
							messageBuilder.AppendLiteral(") TimeWithoutPath:");
							messageBuilder.AppendFormatted(pathfindingAgent.PathDriver?.TimeWithoutPath);
							messageBuilder.AppendLiteral(". ActTime:");
							messageBuilder.AppendFormatted(action.TotalTickingTime);
						}
						Log.Error(messageBuilder);
						action.Complete(ActionCompletionStatus.Error);
					}
				}
			};
			action.CompleteMode = ActionCompleteMode.Never;
			return action;
		}

		public static GoapAction FleeFromEnemy(float maxDistance)
		{
			GoapAction action = new GoapAction("FleeFromTarget");
			action.OnInit = delegate
			{
				IPathfindingAgent pathfindingAgent = (IPathfindingAgent)action.AgentOwner;
				PathfinderAgentDriver driver = pathfindingAgent.PathDriver;
				if (driver == null)
				{
					action.Complete(ActionCompletionStatus.Error);
				}
				else
				{
					IDamageDealAgent attacker = MonoSingleton<CombatTargetManager>.Instance.GetFirstPreferedAttacker((IDamageTakingAgent)action.AgentOwner);
					if (attacker == null && action.AgentOwner is IDamageDealAgent damageDealAgent)
					{
						attacker = damageDealAgent.CombatAi?.GetState<IDamageDealAgent>(CombatAiState.LastDamageTakenFrom);
						if (attacker == null)
						{
							attacker = damageDealAgent.CombatAi?.GetState<IDamageDealAgent>(CombatAiState.LastMissFrom);
						}
					}
					List<Vec3Int> list;
					if (attacker != null)
					{
						list = (from item in MonoSingleton<CreatureManager>.Instance.Creatures
							where item.GetType() == attacker.GetType()
							select item.GetGridPosition()).ToList();
					}
					else if (pathfindingAgent is AnimalInstance)
					{
						list = MonoSingleton<WorkerManager>.Instance.AllWorkers.Keys.Select((HumanoidInstance item) => item.GetGridPosition()).ToList();
					}
					else
					{
						CombatAiAgent combatAi = ((CreatureBase)action.AgentOwner).CombatAi;
						if (combatAi != null)
						{
							HashSet<IDamageDealAgent> perceptionHostiles = combatAi.GetState<HashSet<IDamageDealAgent>>(CombatAiState.PerceptionHostiles);
							list = (from item in MonoSingleton<CreatureManager>.Instance.Creatures
								where perceptionHostiles.Any((IDamageDealAgent damageDealAgent2) => damageDealAgent2.GetType() == item.GetType())
								select item.GetGridPosition()).ToList();
						}
						else
						{
							list = (from item in MonoSingleton<NPCManager>.Instance.IterateNPCs()
								select item.GetGridPosition()).ToList();
						}
					}
					if (list.Count == 0)
					{
						bool isEnabled;
						FVLogWarningInterpolationHandler messageBuilder = new FVLogWarningInterpolationHandler(55, 2, out isEnabled, "C:\\GIT\\dev\\Assets\\Scripts\\GOAP\\Action\\GoToActions.cs");
						if (isEnabled)
						{
							messageBuilder.AppendLiteral("FleeGoal: Agent: ");
							messageBuilder.AppendFormatted(action.AgentOwner);
							messageBuilder.AppendLiteral(" Nothing to run away from... Attacker ");
							messageBuilder.AppendFormatted(attacker);
						}
						Log.Warning(messageBuilder);
						action.Complete(ActionCompletionStatus.Error);
					}
					else
					{
						FleePath path = FleePath.Construct(pathfindingAgent, list, maxDistance);
						driver.ExecutePath(new PathfinderDriverExecCfg
						{
							Path = path,
							StatusCb = delegate(bool success)
							{
								if (!success)
								{
									action.Complete(ActionCompletionStatus.Fail);
								}
								else
								{
									driver.OnClearPathEvent += Callback;
								}
							}
						});
					}
				}
				void Callback(PathfinderAgentDriver dr, PathDriverCompletionState st)
				{
					driver.OnClearPathEvent -= Callback;
					if (action.AgentOwner is CreatureBase creatureBase && creatureBase.CombatAi.TryGetState<IDamageTakingAgent>(CombatAiState.LastAttackedTarget, out var value) && value != null)
					{
						creatureBase.FaceObject(value.GetPosition());
					}
					action.Complete(ActionCompletionStatus.Success);
				}
			};
			action.CompleteMode = ActionCompleteMode.Never;
			return action;
		}

		public static GoapAction WithMovementSpeedMultiplier(this GoapAction action, float speedMultiplier)
		{
			action.OnInit = delegate
			{
				((IPathfindingAgent)action.AgentOwner).PathDriver.GoapTempSpeedMultiplier = speedMultiplier;
			};
			action.OnComplete = delegate
			{
				IPathfindingAgent pathfindingAgent = (IPathfindingAgent)action.AgentOwner;
				if (pathfindingAgent?.PathDriver != null)
				{
					pathfindingAgent.PathDriver.GoapTempSpeedMultiplier = 1f;
				}
			};
			return action;
		}

		public static GoapAction GoToCreatureTarget(TargetIndex targetIndex, float endWhenInRange = 1.5f)
		{
			GoapAction action = new GoapAction("GoToCreatureTarget")
			{
				CompleteMode = ActionCompleteMode.Never
			};
			action.OnInit = delegate
			{
				CreatureBase objectAs = action.Goal.GetTarget(targetIndex).GetObjectAs<CreatureBase>();
				bool isEnabled;
				if (objectAs == null)
				{
					action.Complete(ActionCompletionStatus.Error);
					FVLogInfoInterpolationHandler messageBuilder = new FVLogInfoInterpolationHandler(20, 1, out isEnabled, "C:\\GIT\\dev\\Assets\\Scripts\\GOAP\\Action\\GoToActions.cs");
					if (isEnabled)
					{
						messageBuilder.AppendLiteral("Target not creature ");
						messageBuilder.AppendFormatted(action.AgentOwner);
					}
					Log.Info(messageBuilder);
					DebugEventLog.WriteGoapEvent(action, GoapDebugEventCode.GoTo_Fail_TargetNotCreature);
				}
				else
				{
					if (objectAs == action.AgentOwner)
					{
						FVLogWarningInterpolationHandler messageBuilder2 = new FVLogWarningInterpolationHandler(59, 1, out isEnabled, "C:\\GIT\\dev\\Assets\\Scripts\\GOAP\\Action\\GoToActions.cs");
						if (isEnabled)
						{
							messageBuilder2.AppendLiteral("Follow goal problem. Agent ");
							messageBuilder2.AppendFormatted(objectAs);
							messageBuilder2.AppendLiteral(" is trying to follow him self...");
						}
						Log.Warning(messageBuilder2);
					}
					IPathfindingAgent pathfindingAgent = (IPathfindingAgent)action.AgentOwner;
					if (Vector3.Distance(objectAs.GetPosition(), pathfindingAgent.GetPosition()) <= endWhenInRange)
					{
						action.CompleteMode = ActionCompleteMode.Instant;
						DebugEventLog.WriteGoapEvent(action, GoapDebugEventCode.GoTo_Success_TargetCloseEnough);
					}
					else
					{
						DebugEventLog.WriteGoapEvent(action, GoapDebugEventCode.GoTo_Init);
						action.CompleteMode = ActionCompleteMode.Never;
					}
				}
			};
			action.TickOnInterval(0.2f, delegate
			{
				IPathfindingAgent pathfindingAgent = (IPathfindingAgent)action.AgentOwner;
				CreatureBase objectAs = action.Goal.GetTarget(targetIndex).GetObjectAs<CreatureBase>();
				if (CombatUtils.IsNullOrDisposed(action.AgentOwner, objectAs))
				{
					DebugEventLog.WriteGoapEvent(action, GoapDebugEventCode.GoTo_Fail_TargetNullOrDisposed);
					action.Complete(ActionCompletionStatus.Fail);
				}
				else if (Vector3.Distance(objectAs.GetPosition(), pathfindingAgent.GetPosition()) <= endWhenInRange)
				{
					DebugEventLog.WriteGoapEvent(action, GoapDebugEventCode.GoTo_Success_TargetCloseEnough);
					action.Complete(ActionCompletionStatus.Success);
				}
				else
				{
					PathfinderAgentDriver pathDriver = pathfindingAgent.PathDriver;
					if (!pathDriver.IsProcessing && (!pathDriver.IsMoving || !(Vec3Int.Distance(pathDriver.FinalDestination, objectAs.GetGridPosition()) <= endWhenInRange)))
					{
						MapNode mapNode = (objectAs.PathDriver.IsMoving ? objectAs.PathDriver.NextStop : objectAs.GetNode());
						if (mapNode == null)
						{
							mapNode = objectAs.GetNode();
						}
						if (!pathfindingAgent.PathTraversalProvider.CanStandOnNode(mapNode))
						{
							MapNode closestConnectedNode = mapNode.GetClosestConnectedNode(pathfindingAgent.GetGridPosition(), pathfindingAgent.PathTraversalProvider.CanStandOnNode);
							endWhenInRange = Vec3Int.Distance(closestConnectedNode.Position, mapNode.Position) + 0.1f;
							mapNode = closestConnectedNode;
						}
						Vec3Int gridDestination = mapNode?.Position ?? objectAs.GetGridPosition();
						P2PPath path = P2PPath.Construct(pathfindingAgent, gridDestination);
						pathDriver.ExecutePath(new PathfinderDriverExecCfg
						{
							Path = path,
							StatusCb = delegate(bool result)
							{
								if (!result)
								{
									DebugEventLog.WriteGoapEvent(action, GoapDebugEventCode.GoTo_Fail_PathfindingError);
									action.Complete(ActionCompletionStatus.Fail);
								}
							}
						});
					}
				}
			});
			return action;
		}

		public static GoapAction GoToHarvestAnimalTarget(TargetIndex targetIndex, bool useFrontPosOnly = false)
		{
			GoapAction action = new GoapAction("GoToHarvestAnimalTarget")
			{
				CompleteMode = ActionCompleteMode.Never
			};
			action.OnInit = delegate
			{
				AnimalInstance objectAs = action.Goal.GetTarget(targetIndex).GetObjectAs<AnimalInstance>();
				if (objectAs == null)
				{
					action.Complete(ActionCompletionStatus.Error);
					bool isEnabled;
					FVLogInfoInterpolationHandler messageBuilder = new FVLogInfoInterpolationHandler(20, 1, out isEnabled, "C:\\GIT\\dev\\Assets\\Scripts\\GOAP\\Action\\GoToActions.cs");
					if (isEnabled)
					{
						messageBuilder.AppendLiteral("Target not creature ");
						messageBuilder.AppendFormatted(action.AgentOwner);
					}
					Log.Info(messageBuilder);
				}
				else
				{
					IPathfindingAgent pathfindingAgent = (IPathfindingAgent)action.AgentOwner;
					objectAs.GetHarvestPosition(out var gridPos, out var eulerAngles, useFrontPosOnly ? null : pathfindingAgent);
					if (Vector3.Distance(gridPos, pathfindingAgent.GetPosition()) <= 0.6f)
					{
						action.CompleteMode = ActionCompleteMode.Instant;
						RotateAgent(pathfindingAgent, eulerAngles, objectAs);
					}
				}
			};
			action.TickOnInterval(0.6f, delegate(GoapAction act)
			{
				IPathfindingAgent pathfindingAgent = (IPathfindingAgent)action.AgentOwner;
				AnimalInstance objectAs = action.Goal.GetTarget(targetIndex).GetObjectAs<AnimalInstance>();
				if (CombatUtils.IsNullOrDisposed(action.AgentOwner, objectAs))
				{
					act.Complete(ActionCompletionStatus.Fail);
				}
				else
				{
					objectAs.GetHarvestPosition(out var gridPos, out var eulerAngles, useFrontPosOnly ? null : pathfindingAgent);
					if ((objectAs.GetNode().Tag & MapNodeTags.Ladder) == 0)
					{
						MapNode nodeByWorldPos = objectAs.Map.GetNodeByWorldPos(gridPos);
						if ((nodeByWorldPos.Tag & MapNodeTags.Ladder) == 0)
						{
							Vec3Int rhs = nodeByWorldPos.Position;
							if (pathfindingAgent.GetGridPosition() == rhs)
							{
								action.Complete(ActionCompletionStatus.Success);
								pathfindingAgent.PathDriver.Abort();
								pathfindingAgent.PathDriver.IsFloatingAllowed = true;
								pathfindingAgent.PathDriver.Teleport(gridPos);
								RotateAgent(pathfindingAgent, eulerAngles, objectAs);
							}
							else
							{
								PathfinderAgentDriver pathDriver = pathfindingAgent.PathDriver;
								if (!pathDriver.IsMoving || !(pathDriver.FinalDestination == rhs))
								{
									P2PPath path = P2PPath.Construct(pathfindingAgent, rhs);
									pathDriver.ExecutePath(new PathfinderDriverExecCfg
									{
										Path = path,
										StatusCb = delegate(bool result)
										{
											if (!result)
											{
												action.Complete(ActionCompletionStatus.Fail);
											}
										}
									});
								}
							}
						}
					}
				}
			});
			action.OnComplete = delegate
			{
				IPathfindingAgent pathfindingAgent = (IPathfindingAgent)action.AgentOwner;
				if (pathfindingAgent?.PathDriver != null)
				{
					pathfindingAgent.PathDriver.IsFloatingAllowed = false;
				}
			};
			return action;
			static void RotateAgent(IPathfindingAgent agent, Vector3 euler, AnimalInstance target)
			{
				IProductionAgent productionAgent = agent as IProductionAgent;
				if (productionAgent != null && euler != Vector3.zero)
				{
					MonoSingleton<TaskController>.Instance.WaitForNextFrameUnscaled().Then(delegate
					{
						if (target != null && !(target.GetAgentView<AnimalView>() == null))
						{
							Vector3 eulerAngle = new Vector3(0f, target.GetAgentView<AnimalView>().transform.eulerAngles.y + euler.y, 0f);
							if (productionAgent != null)
							{
								productionAgent.SetEulerAngle(eulerAngle);
							}
						}
					});
				}
				else
				{
					agent.FaceObject(target.GetPosition());
				}
			}
		}

		public static GoapAction OnGridSpaceChangedEvent(this GoapAction action, Action<GoapAction, MapNode, MapNode> callback)
		{
			if (!action.Id.Equals("GoToTarget") && !action.Id.Equals("GoToCreatureTarget"))
			{
				throw new Exception("This extension can not be used with action " + action.Id);
			}
			action.OnInit = delegate
			{
				CreatureBase creature = (CreatureBase)action.AgentOwner;
				Action<CreatureBase, MapNode, MapNode> gridChangeCallback = null;
				gridChangeCallback = delegate(CreatureBase cr, MapNode oldNode, MapNode newNode)
				{
					if (action.Goal.State != GoalState.Running || action.HasCompleted)
					{
						creature.OnGridSpaceChangedEvent -= gridChangeCallback;
					}
					else
					{
						callback?.Invoke(action, oldNode, newNode);
					}
				};
				creature.OnGridSpaceChangedEvent += gridChangeCallback;
				action.OnComplete = delegate
				{
					creature.OnGridSpaceChangedEvent -= gridChangeCallback;
				};
			};
			return action;
		}
	}
}
