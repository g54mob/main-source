using System;
using System.Collections.Generic;
using System.Linq;
using FoxyVoxel.Logging;
using FoxyVoxel.Logging.Core.LogMessageInterpolationHandlers;
using NSEipix;
using NSEipix.Base;
using NSEipix.Repository;
using NSMedieval.BuildingComponents;
using NSMedieval.CombatAi;
using NSMedieval.Controllers;
using NSMedieval.EnvironmentEffects;
using NSMedieval.Fire;
using NSMedieval.Manager;
using NSMedieval.Map;
using NSMedieval.Model;
using NSMedieval.Repository;
using NSMedieval.Scripts.Pooler;
using NSMedieval.State;
using NSMedieval.Types;
using NSMedieval.UI.Utils;
using NSMedieval.Utils;
using NSMedieval.View;
using NSMedieval.Views.Resources;
using NSMedieval.Village;
using NSMedieval.Village.Map;
using NSMedieval.Village.Map.Pathfinding;
using UnityEngine;

namespace NSMedieval.Goap.Actions
{
	public static class CombatActions
	{
		private const float DefaultProjectileSpeed = 45f;

		public static float GetLadderAttackOffset(IDamageTakingAgent target)
		{
			if (CombatUtils.IsNullOrDisposed(target))
			{
				return 0f;
			}
			return (float)World.MapBlockHeight - (target.GetPosition().y - target.GetNode().WorldPosition.y);
		}

		public static GoapAction MoveToAttackPosition(IDamageDealAgent agentOwner, Path initialPath)
		{
			GoapAction action = new GoapAction("MoveToAttackPosition");
			bool pathIsBeingConstructed = false;
			action.OnInit = delegate
			{
				PathfinderAgentDriver driver = ((IPathfindingAgent)agentOwner).PathDriver;
				IDamageTakingAgent target = agentOwner.GetTarget();
				bool standingOnLadder;
				if (CombatUtils.IsNullOrDisposed(agentOwner, target))
				{
					action.Goal.EndGoalWith(GoalCondition.Incompletable);
				}
				else if (CombatAttackerPositioningManager.IsInAttackPosition(agentOwner, target))
				{
					action.Complete(ActionCompletionStatus.Success);
				}
				else
				{
					CombatAiAgent combatAi = agentOwner.CombatAi;
					if (combatAi != null && combatAi.IsStateSet(CombatAiState.IsDraftAutoTargetSet) && CombatUtils.GetAttackType(agentOwner) != AttackType.Melee)
					{
						action.Complete(ActionCompletionStatus.Fail);
					}
					else
					{
						standingOnLadder = (agentOwner.GetNode().Tag & MapNodeTags.Ladder) != 0;
						_ = standingOnLadder;
						MonoSingleton<AnimationController>.Instance.SetAnimatorParameter(action.Goal.AgentOwner, "IsAttacking", value: false);
						if (initialPath == null || initialPath.State == PathState.None)
						{
							bool isEnabled;
							FVLogDebugInterpolationHandler messageBuilder = new FVLogDebugInterpolationHandler(87, 2, out isEnabled, "C:\\GIT\\dev\\Assets\\Scripts\\GOAP\\Action\\CombatActions.cs");
							if (isEnabled)
							{
								messageBuilder.AppendLiteral("Not in position, but action started without valid path (path: '");
								messageBuilder.AppendFormatted(initialPath);
								messageBuilder.AppendLiteral("')... Creating new path ");
								messageBuilder.AppendFormatted(agentOwner);
							}
							Log.Debug(messageBuilder);
							pathIsBeingConstructed = true;
							MonoSingleton<ThreadingJobSystem>.Instance.QueueTask(delegate
							{
								initialPath = MonoSingleton<CombatAttackTracker>.Instance.StartAttackPath(agentOwner);
								return true;
							}, delegate(bool result)
							{
								pathIsBeingConstructed = false;
								if (!result)
								{
									Log.Error("Thread exception occurred while trying to construct attack path (see previous error)", "C:\\GIT\\dev\\Assets\\Scripts\\GOAP\\Action\\CombatActions.cs");
								}
								else
								{
									CalculatePathAndInitDriver();
								}
							});
						}
						else
						{
							CalculatePathAndInitDriver();
						}
					}
				}
				void CalculatePathAndInitDriver()
				{
					IDamageTakingAgent target2 = agentOwner.GetTarget();
					if (CombatUtils.IsNullOrDisposed(agentOwner, target2))
					{
						action.Complete(ActionCompletionStatus.Fail);
					}
					else
					{
						Path tmpPath = initialPath;
						initialPath = null;
						MapNode node = target2.GetNode();
						if (node == null)
						{
							action.Complete(ActionCompletionStatus.Fail);
						}
						else
						{
							PathfinderDriverExecCfg execConfig = new PathfinderDriverExecCfg
							{
								Path = tmpPath,
								CalcDirectYOffset = (((node.Tag & MapNodeTags.Ladder) != MapNodeTags.None) ? new Func<MapNode, PathfinderAgentDriver, float>(CalcLadderYOffset) : null),
								StatusCb = delegate(bool result)
								{
									bool isEnabled2;
									if (!result || driver.HasDisposed)
									{
										FVLogTraceInterpolationHandler messageBuilder2 = new FVLogTraceInterpolationHandler(50, 2, out isEnabled2, "C:\\GIT\\dev\\Assets\\Scripts\\GOAP\\Action\\CombatActions.cs");
										if (isEnabled2)
										{
											messageBuilder2.AppendLiteral("MoveToAttackPosition failed, result is ");
											messageBuilder2.AppendFormatted(result);
											messageBuilder2.AppendLiteral(" for agent ");
											messageBuilder2.AppendFormatted(agentOwner);
										}
										Log.Trace(messageBuilder2);
										action.Complete(ActionCompletionStatus.Fail);
									}
									else if (tmpPath.NodePath == null || tmpPath.NodePath.Count == 0)
									{
										FVLogTraceInterpolationHandler messageBuilder2 = new FVLogTraceInterpolationHandler(65, 1, out isEnabled2, "C:\\GIT\\dev\\Assets\\Scripts\\GOAP\\Action\\CombatActions.cs");
										if (isEnabled2)
										{
											messageBuilder2.AppendLiteral("MoveToAttackPosition NodePath is NULL or SizeZero ");
											messageBuilder2.AppendFormatted(agentOwner);
											messageBuilder2.AppendLiteral(", action failed");
										}
										Log.Trace(messageBuilder2);
										action.Complete(ActionCompletionStatus.Fail);
									}
									else
									{
										MapNode mapNode = tmpPath.NodePath[0];
										if (mapNode.Tag.HasFlag(MapNodeTags.Ladder) || standingOnLadder)
										{
											FVLogTraceInterpolationHandler messageBuilder2 = new FVLogTraceInterpolationHandler(113, 2, out isEnabled2, "C:\\GIT\\dev\\Assets\\Scripts\\GOAP\\Action\\CombatActions.cs");
											if (isEnabled2)
											{
												messageBuilder2.AppendLiteral("Destination node is a ladder node or the agent is standing on a ladder, calculated path accepted, node: ");
												messageBuilder2.AppendFormatted(mapNode);
												messageBuilder2.AppendLiteral(", agent: ");
												messageBuilder2.AppendFormatted(agentOwner);
											}
											Log.Trace(messageBuilder2);
										}
										else if (MonoSingleton<CombatAttackTracker>.Instance.CanBeReservedBy(mapNode.Position, agentOwner))
										{
											FVLogTraceInterpolationHandler messageBuilder2 = new FVLogTraceInterpolationHandler(84, 2, out isEnabled2, "C:\\GIT\\dev\\Assets\\Scripts\\GOAP\\Action\\CombatActions.cs");
											if (isEnabled2)
											{
												messageBuilder2.AppendLiteral("Destination node can be reserved by agent, calculated path accepted, node: ");
												messageBuilder2.AppendFormatted(mapNode);
												messageBuilder2.AppendLiteral(", agent: ");
												messageBuilder2.AppendFormatted(agentOwner);
											}
											Log.Trace(messageBuilder2);
										}
										else
										{
											FVLogTraceInterpolationHandler messageBuilder2 = new FVLogTraceInterpolationHandler(60, 2, out isEnabled2, "C:\\GIT\\dev\\Assets\\Scripts\\GOAP\\Action\\CombatActions.cs");
											if (isEnabled2)
											{
												messageBuilder2.AppendLiteral("Destination node NOT accepted, can't be reserved by ");
												messageBuilder2.AppendFormatted(agentOwner);
												messageBuilder2.AppendLiteral(", node: ");
												messageBuilder2.AppendFormatted(mapNode);
											}
											Log.Trace(messageBuilder2);
											action.Complete(ActionCompletionStatus.Jump);
											action.Goal.JumpToAction(action);
											initialPath = null;
										}
									}
								}
							};
							driver.ExecutePath(execConfig);
						}
					}
				}
			};
			action.OnTick = delegate
			{
				IDamageTakingAgent target = agentOwner.GetTarget();
				if (CombatUtils.IsNullOrDisposed(agentOwner, target))
				{
					action.Complete(ActionCompletionStatus.Fail);
				}
				else
				{
					bool flag;
					if (CombatUtils.GetAttackType(agentOwner) != AttackType.Melee)
					{
						flag = target != null && CombatAttackerPositioningManager.IsInAttackPosition(agentOwner, target);
					}
					else
					{
						float num = CombatUtils.GetRange(agentOwner, target) / 2f;
						flag = agentOwner.Distance(target) < num;
					}
					if (flag)
					{
						action.Complete(ActionCompletionStatus.Success);
					}
					else
					{
						PathfinderAgentDriver pathDriver = ((IPathfindingAgent)agentOwner).PathDriver;
						if (!pathIsBeingConstructed && !pathDriver.IsProcessing && (pathDriver.CurrentPath == null || !pathDriver.IsMoving))
						{
							if (target != null && CombatAttackerPositioningManager.IsInAttackPosition(agentOwner, target))
							{
								action.Complete(ActionCompletionStatus.Success);
							}
							else if (!(pathDriver.TimeWithoutPath <= 2f))
							{
								bool isEnabled;
								FVLogTraceInterpolationHandler messageBuilder = new FVLogTraceInterpolationHandler(40, 3, out isEnabled, "C:\\GIT\\dev\\Assets\\Scripts\\GOAP\\Action\\CombatActions.cs");
								if (isEnabled)
								{
									messageBuilder.AppendLiteral("Timeout fail, path '");
									messageBuilder.AppendFormatted(pathDriver.CurrentPath);
									messageBuilder.AppendLiteral("', isMoving ");
									messageBuilder.AppendFormatted(pathDriver.IsMoving);
									messageBuilder.AppendLiteral(", agent ");
									messageBuilder.AppendFormatted(agentOwner);
								}
								Log.Trace(messageBuilder);
								action.Complete(ActionCompletionStatus.Fail);
							}
						}
					}
				}
			};
			action.OnComplete = delegate(ActionCompletionStatus status)
			{
				if (status != ActionCompletionStatus.Success)
				{
					MonoSingleton<CombatAttackTracker>.Instance.AttackPathFailed(agentOwner);
				}
				else
				{
					MonoSingleton<CombatAttackTracker>.Instance.AttackPathDestinationReached(agentOwner);
					IDamageTakingAgent target = agentOwner.GetTarget();
					if (CombatUtils.IsNullOrDisposed(target) || !CombatAttackerPositioningManager.IsInAttackPosition(agentOwner, target))
					{
						action.Goal.JumpToAction(action);
					}
					else
					{
						((IPathfindingAgent)agentOwner).PathDriver.Abort();
					}
				}
			};
			if (!(agentOwner is HumanoidInstance humanoidInstance) || !humanoidInstance.IsEnemy() || humanoidInstance.EnemyBehaviour.CurrentOrder == null)
			{
				action.FailIfInvalidCombatTarget();
				action.FailIfCombatTargetClears();
			}
			action.UpdatePathIfTargetMoved();
			action.CompleteMode = ActionCompleteMode.Never;
			return action;
		}

		public static void AttackMelee(IDamageDealAgent agent)
		{
			IDamageTakingAgent damageTakingAgent = agent?.GetTarget();
			if (CombatUtils.IsNullOrDisposed(agent, damageTakingAgent))
			{
				return;
			}
			MonoSingleton<CombatController>.Instance.CombatStarted();
			float additionalPenalty = 0f;
			EquipmentInstance weapon = CombatUtils.GetWeapon(agent);
			if (CombatUtils.IsAgentSwimming(agent) && weapon != null)
			{
				additionalPenalty = weapon.WaterPrecisionPenalty;
			}
			bool flag = CombatHitManager.HasHit(agent, damageTakingAgent, additionalPenalty) == CombatMissType.None;
			CombatHitManager.HandleXp(agent, damageTakingAgent, AttackType.Melee, flag);
			if (!flag)
			{
				if (!(damageTakingAgent is BaseBuildingInstance))
				{
					weapon?.DealWeaponDurabilityDamage(isMiss: true);
				}
				return;
			}
			if (!(damageTakingAgent is BaseBuildingInstance))
			{
				weapon?.DealWeaponDurabilityDamage(isMiss: false);
			}
			CombatHitInfo info = CombatHitManager.DealDamage(agent, damageTakingAgent, DamageType.Melee);
			DamagePopup.Create(info, damageTakingAgent.GetPosition());
			if (ShouldBleed(damageTakingAgent))
			{
				GameObject gameObject;
				if (info.HasBlocked && damageTakingAgent is HumanoidInstance humanoidInstance)
				{
					Transform equipmentTransform = humanoidInstance.GetAgentView<HumanoidView>().BodyPreview.GetEquipmentTransform(info.ItemThatBlocked.Blueprint.EquipmentSlots);
					gameObject = MonoSingleton<ParticleSystemPool>.Instance.PlayParticles("block_hit", equipmentTransform.position);
					PlayHitEffectOnEquipment(equipmentTransform);
				}
				else
				{
					Vector3 position = damageTakingAgent.GetPosition() + new Vector3(UnityEngine.Random.Range(-0.3f, 0.3f), UnityEngine.Random.Range(0.4f, 0.85f), UnityEngine.Random.Range(-0.3f, 0.3f));
					gameObject = MonoSingleton<ParticleSystemPool>.Instance.PlayParticles("weapon_hit", position);
				}
				MonoSingleton<CameraManager>.Instance.OnCameraShakeEvent(damageTakingAgent.GetPosition(), CameraShakeStrength.Weak);
				if (gameObject != null)
				{
					gameObject.GetComponent<HitEffect>()?.OnHit();
				}
			}
			if (!info.HasBlocked)
			{
				damageTakingAgent.GetTransform()?.GetComponent<HitEffect>()?.OnHit();
				if (info.Critical)
				{
					(damageTakingAgent as CreatureBase)?.LadderFallDown();
				}
			}
		}

		private static bool ShouldBleed(IDamageTakingAgent target)
		{
			if (CombatUtils.IsNullOrDisposed(target))
			{
				return false;
			}
			return (target.DamageAgentType & (DamageTakingAgentType.Animal | DamageTakingAgentType.Worker | DamageTakingAgentType.NPC)) != 0;
		}

		public static GoapAction FailIfInvalidCombatTarget(this GoapAction action)
		{
			action.OnPreTick = delegate
			{
				IDamageTakingAgent target = ((IDamageDealAgent)action.Goal.AgentOwner).GetTarget();
				if (!CombatUtils.IsAlive(target) && CombatAiUtils.IsAgentDefeated(target) && !(target is CreatureBase) && target.Map.FirePresenceGrid.HasFirePresence(target.GetNode()))
				{
					MonoSingleton<CombatTargetManager>.Instance.RemovePreferredTarget(action.AgentOwner as IDamageDealAgent);
					action.Goal.EndGoalWith(GoalCondition.Incompletable);
				}
			};
			return action;
		}

		public static GoapAction FailIfViolatingGenevaConvention(this GoapAction action)
		{
			action.OnPreTick = delegate
			{
				if ((action.AgentOwner as IDamageDealAgent)?.GetTarget() is HumanoidInstance humanoidInstance && humanoidInstance.GetGoapAgent().CurrentGoalName == "PrisonerSurrenderGoal")
				{
					MonoSingleton<CombatTargetManager>.Instance.RemovePreferredTarget(action.AgentOwner as IDamageDealAgent);
					action.Goal.EndGoalWith(GoalCondition.Incompletable);
				}
			};
			return action;
		}

		public static GoapAction JumpIfCombatTargetIsInvalid(this GoapAction action, GoapAction nextAction)
		{
			return action.JumpIf(nextAction, () => !CombatUtils.IsAlive(((IDamageDealAgent)action.Goal.AgentOwner).GetTarget()));
		}

		public static GoapAction FailIfCombatTargetClears(this GoapAction action)
		{
			action.AddGoalEndingCondition(() => ((action.AgentOwner as IDamageDealAgent)?.GetTarget() != null) ? GoalCondition.OnGoing : GoalCondition.Incompletable);
			return action;
		}

		public static GoapAction FailIfCombatTargetAnimalGetsRoped(this GoapAction action)
		{
			action.AddGoalEndingCondition(delegate
			{
				IDamageTakingAgent damageTakingAgent = (action.AgentOwner as IDamageDealAgent)?.GetTarget();
				if (damageTakingAgent == null)
				{
					return GoalCondition.Incompletable;
				}
				return (!(action.AgentOwner is AnimalInstance) || !(damageTakingAgent is AnimalInstance animalInstance) || animalInstance.RopedTo() == null) ? GoalCondition.OnGoing : GoalCondition.Incompletable;
			});
			return action;
		}

		public static GoapAction UpdatePathIfTargetMoved(this GoapAction action)
		{
			Vector3 lastCheckTargetPos = Vector3.zero;
			float lastTime = 0f;
			bool disableThisCheck = false;
			action.TickOnInterval(0.3f, delegate
			{
				IPathfindingAgent agent;
				IDamageDealAgent actionAgentOwner;
				IDamageTakingAgent targetAgent;
				Path path;
				if (!disableThisCheck)
				{
					agent = (IPathfindingAgent)action.AgentOwner;
					actionAgentOwner = (IDamageDealAgent)action.AgentOwner;
					targetAgent = actionAgentOwner.GetTarget();
					if (!CombatUtils.IsNullOrDisposed(actionAgentOwner, targetAgent))
					{
						if (lastCheckTargetPos == Vector3.zero)
						{
							lastCheckTargetPos = targetAgent.GetPosition();
							lastTime = Time.time;
						}
						else if ((!(Vector3.Distance(targetAgent.GetPosition(), agent.GetPosition()) >= 9f) || !(Time.time - lastTime < 3.5f)) && !(Vector3.Distance(targetAgent.GetPosition(), lastCheckTargetPos) <= 0.75f))
						{
							lastCheckTargetPos = targetAgent.GetPosition();
							lastTime = Time.time;
							disableThisCheck = true;
							path = null;
							MonoSingleton<ThreadingJobSystem>.Instance.QueueTask(CreatePathThread, SchedulePathfinding);
						}
					}
				}
				bool CreatePathThread()
				{
					path = MonoSingleton<CombatAttackTracker>.Instance.RecalculateAttackPath(actionAgentOwner);
					return true;
				}
				void SchedulePathfinding(bool successful)
				{
					if (path == null)
					{
						action.Complete(ActionCompletionStatus.Fail);
						disableThisCheck = false;
					}
					else
					{
						PathProcessingTask task = MonoSingleton<PathProcessorManager>.Instance.ScheduleProcessPath(path);
						PathProcessingTask pathProcessingTask = task;
						pathProcessingTask.OnComplete = (Action<PathProcessingTask>)Delegate.Combine(pathProcessingTask.OnComplete, (Action<PathProcessingTask>)delegate(PathProcessingTask processingTask)
						{
							disableThisCheck = false;
							if (task.Path == null || task.Path.State != PathState.Calculated || targetAgent.HasDisposed)
							{
								Path.ReleasePath(path);
								action.Complete(ActionCompletionStatus.Fail);
							}
							else if (!MonoSingleton<CombatAttackTracker>.Instance.CanBeReservedBy(path.NodePath.First().Position, actionAgentOwner))
							{
								Path.ReleasePath(path);
							}
							else
							{
								MapNode node = targetAgent.GetNode();
								PathfinderDriverExecCfg execConfig = new PathfinderDriverExecCfg
								{
									Path = processingTask.Path,
									CalcDirectYOffset = (((node.Tag & MapNodeTags.Ladder) != MapNodeTags.None) ? new Func<MapNode, PathfinderAgentDriver, float>(CalcLadderYOffset) : null),
									StatusCb = delegate(bool result)
									{
										if (!result)
										{
											action.Complete(ActionCompletionStatus.Fail);
										}
									}
								};
								agent?.PathDriver?.ExecutePath(execConfig);
							}
						});
					}
				}
			});
			return action;
		}

		public static void FireRangedWeapon(IDamageDealAgent agent)
		{
			IDamageTakingAgent target = agent?.GetTarget();
			if (CombatUtils.IsNullOrDisposed(agent, target))
			{
				return;
			}
			Transform weaponTransform = agent.GetWeaponTransform(0);
			weaponTransform = ((weaponTransform == null) ? agent.GetWeaponTransform(1) : weaponTransform);
			if (weaponTransform == null)
			{
				Log.Error("Tried to fire arrow FX without weapon transform!", "C:\\GIT\\dev\\Assets\\Scripts\\GOAP\\Action\\CombatActions.cs");
				return;
			}
			EquipmentInstance weaponInstance = CombatUtils.GetWeapon(agent);
			if (weaponInstance?.Blueprint == null || weaponInstance.HasDisposed)
			{
				return;
			}
			Vector3 vector = weaponTransform.position + weaponInstance.ProjectileOffset;
			Transform transform = target.GetTransform();
			if (transform == null)
			{
				return;
			}
			MonoSingleton<CombatController>.Instance.CombatStarted();
			bool flag = agent.ConsumeFlammableRound();
			MapNode randomTraverseNode;
			float num = CombatCalculator.CalculateLineOfSightObjectsTraversePenalty(agent.Map, agent.GetGridPosition(), target.GetGridPosition(), out randomTraverseNode);
			if (flag)
			{
				num += 0.2f;
			}
			CombatMissType missType = CombatHitManager.HasHit(agent, target, num);
			weaponInstance.DealWeaponDurabilityDamage(missType != CombatMissType.None, flag);
			CombatProjectile combatProjectile = UnityEngine.Object.Instantiate(weaponInstance.ProjectilePrefab, vector, Quaternion.identity);
			combatProjectile.SetFireEffect(flag);
			float num2 = agent.GetPosition().y - target.GetPosition().y;
			if (num2 >= 1f)
			{
				combatProjectile.ShowBonusTrail();
			}
			else if (num2 <= -1f)
			{
				combatProjectile.ShowPenaltyTrail();
			}
			Transform transform2 = null;
			Vector3 destination = Vector3.zero;
			Vector3 destinationOffset = Vector3.zero;
			bool dontSpawnEffect = false;
			float range = CombatUtils.GetRange(agent, target);
			float num3 = Vector3.Distance(agent.GetPosition(), target.GetPosition()) / range;
			float speed = weaponInstance.ApplyProjectileSpeedModifier(45f);
			float bezierPathApex = ((Mathf.Lerp(0f, 0.5f, num3) + num2 <= 0.1f) ? 0f : (num3 * 2f));
			bezierPathApex = weaponInstance.ApplyProjectileArchHeightModifier(bezierPathApex);
			float destroyDelay = (flag ? 5f : 0.25f);
			switch (missType)
			{
			case CombatMissType.None:
				transform2 = transform;
				destinationOffset = Vector3.up;
				break;
			case CombatMissType.Evade:
				transform2 = transform;
				destinationOffset = Vector3.up;
				dontSpawnEffect = true;
				break;
			case CombatMissType.LineOfSight:
			case CombatMissType.Other:
				destination = ((randomTraverseNode != null && missType != CombatMissType.Other) ? randomTraverseNode.WorldPosition : target.GetPosition());
				dontSpawnEffect = true;
				break;
			case CombatMissType.Miss:
			{
				IDamageTakingAgent damageTakingAgent = ((UnityEngine.Random.value > 0.7f) ? FindAccidentHitTarget(agent, target.GetPosition(), 2.5f) : null);
				if (damageTakingAgent == null || damageTakingAgent.GetTransform() == null)
				{
					Vector3 normalized = (new Vector3(UnityEngine.Random.Range(-1.5f, 1.5f), UnityEngine.Random.Range(0.3f, 2.5f), UnityEngine.Random.Range(-1.5f, 1.5f)) + target.GetPosition() - vector).normalized;
					float num4 = Vector3.Distance(vector, target.GetPosition()) + UnityEngine.Random.Range(2.5f, 10.5f);
					destination = vector + normalized * num4;
					dontSpawnEffect = true;
				}
				else
				{
					target = damageTakingAgent;
					transform2 = damageTakingAgent.GetTransform();
					destinationOffset = Vector3.up * 0.2f;
					missType = CombatMissType.None;
				}
				break;
			}
			}
			if (target is AttackablePointTarget)
			{
				dontSpawnEffect = true;
				destinationOffset = Vector3.zero;
			}
			string text = ((missType != CombatMissType.None || !ShouldBleed(target)) ? weaponInstance.ProjectileHitBuildingParticles : (weaponInstance.ProjectileHitCreatureParticles ?? "weapon_hit"));
			BasicPointToPointMove arrowMover = combatProjectile.GetComponent<BasicPointToPointMove>();
			if (target.DamageAgentType == DamageTakingAgentType.Trebuchet)
			{
				arrowMover.SetParticlesOhHit("destroy_wood_roof");
			}
			else if (text != null)
			{
				arrowMover.SetParticlesOhHit(text);
			}
			if (transform2 != null)
			{
				arrowMover.Setup(transform2, speed, dontSpawnEffect, destinationOffset, bezierPathApex, destroyDelay);
			}
			else
			{
				arrowMover.Setup(destination, speed, dontSpawnEffect, destinationOffset, bezierPathApex, destroyDelay);
			}
			MapNode nodeToSetFireTo = ((!flag) ? null : PickNodeToSetFireTo(missType, agent, target, arrowMover, vector));
			if (nodeToSetFireTo != null)
			{
				arrowMover.Setup(nodeToSetFireTo.WorldPosition, speed, dontSpawnEffect: true, Vector3.zero, bezierPathApex, destroyDelay);
			}
			arrowMover.DestinationReachedEvent += delegate
			{
				if (!CombatUtils.IsNullOrDisposed(agent, target))
				{
					combatProjectile.SetActiveVisibleMeshes(value: false);
					if (nodeToSetFireTo != null)
					{
						FireSimLogic fireSimLogic = VillageManager.ActiveVillage.Map.FireSimLogic;
						float fireData = fireSimLogic.GetFireData(nodeToSetFireTo.Index);
						fireSimLogic.SetFireData(nodeToSetFireTo.Index, Mathf.Max(fireData, 0.1f));
						if (fireSimLogic.IsGreekOilBlobAt(nodeToSetFireTo.Index) || HasGreekOilFireTrap(nodeToSetFireTo))
						{
							fireSimLogic.SetFlameType(nodeToSetFireTo.Index, 1);
						}
					}
					if (target is AttackablePointTarget)
					{
						MonoSingleton<CombatTargetManager>.Instance.RemovePreferredTarget(agent);
					}
					else if (missType == CombatMissType.None)
					{
						CombatHitInfo info = CombatHitManager.DealDamage(agent, target, DamageType.Ranged);
						CombatHitManager.HandleXp(agent, target, CombatUtils.GetAttackType(agent), !info.HasBlocked);
						DamagePopup.Create(info, target.GetPosition());
						MonoSingleton<CameraManager>.Instance.OnCameraShakeEvent(target.GetPosition(), CameraShakeStrength.Weak);
						if (info.HasBlocked)
						{
							arrowMover.SetParticlesOhHit("block_hit");
							if (target is HumanoidInstance humanoidInstance)
							{
								Transform equipmentTransform = humanoidInstance.GetAgentView<HumanoidView>().BodyPreview.GetEquipmentTransform(info.ItemThatBlocked.Blueprint.EquipmentSlots);
								arrowMover.OverrideParticleOnHitPosition(equipmentTransform.position);
								PlayHitEffectOnEquipment(equipmentTransform);
							}
						}
						else
						{
							target.GetTransform()?.GetComponent<HitEffect>()?.OnHit();
							if (info.Critical)
							{
								(target as CreatureBase)?.LadderFallDown();
							}
						}
					}
					else
					{
						CombatHitManager.HandleXp(agent, target, CombatUtils.GetAttackType(agent), hasHit: false);
						if (missType == CombatMissType.Other)
						{
							DamagePopup.Create(arrowMover.OffsetDestination, AssetUtils.GetSpriteAsset("arrow_hits_obstacle") + "   ");
							string id = weaponInstance.ProjectileBreakParticles ?? "arrowbreak";
							MonoSingleton<ParticleSystemPool>.Instance.PlayParticles(id, arrowMover.OffsetDestination);
						}
						else if (missType != CombatMissType.Evade)
						{
							DamagePopup.Create(arrowMover.OffsetDestination, DamagePopup.GenerateMissContent(missType));
							string id2 = weaponInstance.ProjectileMissParticles ?? "arrowmiss";
							MonoSingleton<ParticleSystemPool>.Instance.PlayParticles(id2, arrowMover.OffsetDestination);
						}
					}
				}
			};
		}

		private static bool HasGreekOilFireTrap(MapNode node)
		{
			foreach (WorldObject worldObject in node.GetWorldObjects(GridDataType.Trap))
			{
				if (worldObject is BaseBuildingInstance baseBuildingInstance)
				{
					TrapComponentInstance componentInstance = baseBuildingInstance.GetComponentInstance<TrapComponentInstance>();
					if (componentInstance != null && componentInstance.Blueprint.SpawnFire > 0f && componentInstance.Blueprint.FireType == 1)
					{
						return true;
					}
				}
			}
			return false;
		}

		private static MapNode PickNodeToSetFireTo(CombatMissType missType, IDamageDealAgent agent, IDamageTakingAgent target, BasicPointToPointMove arrowMover, Vector3 projectileStartPos)
		{
			if (CombatUtils.IsNullOrDisposed(agent, target))
			{
				return null;
			}
			switch (missType)
			{
			case CombatMissType.None:
			case CombatMissType.Evade:
				return target.GetNode();
			default:
			{
				Vector3 normalized = (arrowMover.OffsetDestination - projectileStartPos).normalized;
				float rayLength = CombatUtils.GetRange(agent, target) * 1.2f;
				int num = 2;
				if (Vec3Int.Distance(agent.GetGridPosition(), target.GetGridPosition()) <= (float)num)
				{
					num = -1;
				}
				CombatUtils.RaycastLosRaw(projectileStartPos, normalized, rayLength, out var firstNodeHit, out var firstNodeHitPoint, num, stopAtFirstHit: true);
				return (!(firstNodeHitPoint.y % (float)World.MapBlockHeight / (float)World.MapBlockHeight > 0.9f)) ? firstNodeHit : firstNodeHit?.GetNodeAbove();
			}
			}
		}

		private static void PlayHitEffectOnEquipment(Transform itemThatBlocked)
		{
			Renderer[] array = itemThatBlocked.GetComponent<MaterialMeshParameters>()?.Meshes;
			HitEffect orAddComponent = itemThatBlocked.gameObject.GetOrAddComponent<HitEffect>();
			if (array != null && orAddComponent != null)
			{
				orAddComponent.Initialize(0.1f, array);
				orAddComponent.OnHit();
			}
		}

		private static IDamageTakingAgent FindAccidentHitTarget(IDamageDealAgent agent, Vector3 point, float range)
		{
			if (CombatUtils.IsNullOrDisposed(agent, agent.GetTarget()))
			{
				return null;
			}
			IDamageTakingAgent agentAsTakeAgent = agent as IDamageTakingAgent;
			if (agentAsTakeAgent == null)
			{
				return null;
			}
			List<IDamageTakingAgent> targetsInRange = CombatUtils.GetTargetsInRange(point, range, (IDamageTakingAgent takeAgent) => takeAgent != agentAsTakeAgent && takeAgent != agent.GetTarget(), agent.CanAttackTypes());
			if (targetsInRange == null || targetsInRange.Count == 0)
			{
				return null;
			}
			if (targetsInRange.Count <= 2)
			{
				IDamageTakingAgent damageTakingAgent = targetsInRange.PickRandom();
				DamageTakingAgentSettings byAgentType = Repository<DamageTakingAgentSettingsRepository, DamageTakingAgentSettings>.Instance.GetByAgentType(damageTakingAgent.DamageAgentType);
				if (byAgentType != null && UnityEngine.Random.value <= byAgentType.AccidentallyHitChance)
				{
					return damageTakingAgent;
				}
				return null;
			}
			List<IDamageTakingAgent> list = new List<IDamageTakingAgent>();
			foreach (IDamageTakingAgent item in targetsInRange)
			{
				DamageTakingAgentSettings byAgentType2 = Repository<DamageTakingAgentSettingsRepository, DamageTakingAgentSettings>.Instance.GetByAgentType(item.DamageAgentType);
				if (byAgentType2 != null && UnityEngine.Random.value <= byAgentType2.AccidentallyHitChance)
				{
					list.Add(item);
				}
			}
			return list.GetRandom();
		}

		private static float CalcLadderYOffset(MapNode targetNode, PathfinderAgentDriver driver)
		{
			if (targetNode == null || driver == null || driver.HasDisposed)
			{
				return 0f;
			}
			if ((targetNode.Tag & MapNodeTags.Ladder) == 0 || targetNode != driver.CurrentPath.NodePath[0])
			{
				return 0f;
			}
			IDamageDealAgent damageDealAgent = (IDamageDealAgent)driver.Agent;
			if (damageDealAgent.GetTarget() == null)
			{
				return 0f;
			}
			return GetLadderAttackOffset(damageDealAgent.GetTarget());
		}

		private static void TryDraftPositioningFix(IDamageDealAgent agent)
		{
		}
	}
}
