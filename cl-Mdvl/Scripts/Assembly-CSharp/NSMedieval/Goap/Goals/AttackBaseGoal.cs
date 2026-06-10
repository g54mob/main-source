using System.Collections.Generic;
using FoxyVoxel.Logging;
using FoxyVoxel.Logging.Core.LogMessageInterpolationHandlers;
using NSEipix;
using NSEipix.Base;
using NSEipix.Repository;
using NSMedieval.BuildingComponents;
using NSMedieval.CombatAi;
using NSMedieval.Controllers;
using NSMedieval.FloatingOverlaySystem;
using NSMedieval.Goap.Actions;
using NSMedieval.Manager;
using NSMedieval.Model;
using NSMedieval.Repository;
using NSMedieval.Sound;
using NSMedieval.State;
using NSMedieval.State.Timers;
using NSMedieval.Types;
using NSMedieval.UI.Utils;
using NSMedieval.View;
using NSMedieval.Village.Map;
using NSMedieval.Village.Map.Pathfinding;
using UnityEngine;

namespace NSMedieval.Goap.Goals
{
	public abstract class AttackBaseGoal : Goal
	{
		protected readonly IDamageDealAgent ownerAgent;

		protected Path initialPath;

		protected IDamageTakingAgent failedTarget;

		protected int failedCount;

		private const int MaxFailedPathfindings = 3;

		private const float RangedWeaponMinimumDistance = 2f;

		private CircularProgressBarFloatingElement chargeBar;

		protected AttackBaseGoal(string name, Agent selfAgent, GoalInterruptMode interruptMode = GoalInterruptMode.None)
			: base(name, selfAgent, interruptMode)
		{
			ownerAgent = (IDamageDealAgent)base.AgentOwner;
			AddInitSteps();
		}

		protected virtual void AddInitSteps()
		{
			AddInitStep(new ThreadSequenceStep(AssignPreferredTarget, CalculateInitialPath));
		}

		public override bool AgentTypeCheck()
		{
			return base.AgentOwner is IDamageDealAgent;
		}

		public override void Start()
		{
			base.Start();
			ownerAgent.CurrentAttackStream = 0;
		}

		public override void EndGoalWith(GoalCondition condition)
		{
			ownerAgent.ForbidWeapon = false;
			DestroyChargeProgressBar();
			OnAttackStreamEnd();
			MonoSingleton<AnimationController>.Instance.SetAnimatorParameter(base.AgentOwner, "IsAttacking", value: false);
			MonoSingleton<AnimationController>.Instance.ForceQuitAgentAnimation(base.AgentOwner);
			base.EndGoalWith(condition);
		}

		protected override IEnumerable<GoapAction> GetNextAction()
		{
			int loopPrevention = 0;
			IDamageDealAgent agent = (IDamageDealAgent)base.AgentOwner;
			IDamageTakingAgent target = agent.GetTarget();
			Vector3 positionToRestore = Vector3.zero;
			GoapAction getInRange = CombatActions.MoveToAttackPosition(agent, initialPath);
			bool targetIsNotACreature = !(target is CreatureBase);
			if (targetIsNotACreature)
			{
				getInRange.FailIfTargetBecomesFireDangerous();
			}
			getInRange.OnPreInit = delegate
			{
				WeaponModeUpdate(getInRange);
			};
			getInRange.OnInit = delegate
			{
				ownerAgent.SetWeaponVisibility(isVisible: true);
			};
			getInRange.OnComplete = delegate(ActionCompletionStatus status)
			{
				bool isEnabled;
				FVLogTraceInterpolationHandler messageBuilder = new FVLogTraceInterpolationHandler(34, 2, out isEnabled, "C:\\GIT\\dev\\Assets\\Scripts\\GOAP\\Goal\\AttackBaseGoal.cs");
				if (isEnabled)
				{
					messageBuilder.AppendLiteral("GetInRange action completed with ");
					messageBuilder.AppendFormatted(status);
					messageBuilder.AppendLiteral(" ");
					messageBuilder.AppendFormatted(base.AgentOwner);
				}
				Log.Trace(messageBuilder);
				switch (status)
				{
				case ActionCompletionStatus.Success:
					if (getInRange.TotalTickingTime >= 0.1f)
					{
						positionToRestore = Vector3.zero;
						OnAttackStreamEnd();
					}
					ownerAgent.FaceTarget();
					break;
				default:
					loopPrevention++;
					if (loopPrevention >= 8)
					{
						FVLogWarningInterpolationHandler messageBuilder2 = new FVLogWarningInterpolationHandler(60, 1, out isEnabled, "C:\\GIT\\dev\\Assets\\Scripts\\GOAP\\Goal\\AttackBaseGoal.cs");
						if (isEnabled)
						{
							messageBuilder2.AppendLiteral("Attack goal MoveToAttackPosition loop prevention triggered. ");
							messageBuilder2.AppendFormatted(base.AgentOwner);
						}
						Log.Warning(messageBuilder2);
						EndGoalWith(GoalCondition.Incompletable);
					}
					break;
				case ActionCompletionStatus.Fail:
				case ActionCompletionStatus.Error:
					EndGoalWith(GoalCondition.Incompletable);
					MonoSingleton<CombatTargetManager>.Instance.RemovePreferredTarget(ownerAgent);
					break;
				}
			};
			getInRange.OnTick = delegate
			{
				if (getInRange.TotalTickingTime > 0.15f)
				{
					OnAttackStreamEnd();
				}
			};
			yield return getInRange;
			GoapAction chargeAction = new GoapAction("ChargeWeapon")
			{
				CompleteMode = ActionCompleteMode.Delay
			};
			bool initialForbidState = false;
			AnimatedAgentView agentView = ((CreatureBase)agent).GetAgentView<AnimatedAgentView>();
			chargeAction.OnInit = delegate
			{
				agentView.CombatAnimationEventsEnabled = true;
				float num = CombatCalculator.CalculateAttackSpeed(agent);
				agentView.TrySetParameter("AttackSpeed", 1f / num);
				agentView.TrySetParameter("LadderAttackDir", (int)CombatUtils.GetLadderAttackDirection(agent));
				initialForbidState = agent.ForbidWeapon;
				chargeAction.CompleteAfterTimeExpires(num);
				ownerAgent.CurrentAttackStream++;
				if (ownerAgent.CurrentAttackStream == 1)
				{
					OnAttackStreamStart();
				}
				SpawnChargeProgressBar();
				agentView.TrySetParameter("IsAttacking", value: true);
				IDamageDealAgent damageDealAgent = (IDamageDealAgent)base.AgentOwner;
				if (CombatUtils.IsNullOrDisposed(damageDealAgent))
				{
					chargeAction.Complete(ActionCompletionStatus.Fail);
				}
				else
				{
					MapNode node = damageDealAgent.GetNode();
					if ((node.Tag & MapNodeTags.Ladder) != MapNodeTags.None)
					{
						Vector3 worldPosition = node.WorldPosition;
						positionToRestore = new Vector3(worldPosition.x, damageDealAgent.GetPosition().y, worldPosition.z);
					}
				}
			};
			chargeAction.OnTick = delegate
			{
				agentView.TrySetParameter("IsAttacking", value: true);
				float num = chargeAction.TotalTickingTime / chargeAction.Duration - 0.05f;
				if (num < 0f)
				{
					num = 0f;
				}
				agentView.TrySetParameter("AttackMotionTime", num);
				agent.FaceTarget();
				if (initialForbidState != agent.ForbidWeapon)
				{
					chargeAction.Complete(ActionCompletionStatus.Jump);
					agentView.ForceQuitAnimation();
					agentView.TrySetParameter("IsAttacking", value: false);
				}
			};
			chargeAction.OnComplete = delegate(ActionCompletionStatus status)
			{
				bool isEnabled;
				FVLogTraceInterpolationHandler messageBuilder = new FVLogTraceInterpolationHandler(30, 2, out isEnabled, "C:\\GIT\\dev\\Assets\\Scripts\\GOAP\\Goal\\AttackBaseGoal.cs");
				if (isEnabled)
				{
					messageBuilder.AppendLiteral("Charge action completed with ");
					messageBuilder.AppendFormatted(status);
					messageBuilder.AppendLiteral(" ");
					messageBuilder.AppendFormatted(base.AgentOwner);
				}
				Log.Trace(messageBuilder);
				agentView.CombatAnimationEventsEnabled = false;
				DestroyChargeProgressBar();
				agentView.TrySetParameter("AttackMotionTime", 0f);
				if (status == ActionCompletionStatus.Success && positionToRestore != Vector3.zero)
				{
					((IPathfindingAgent)base.AgentOwner).UpdatePosition(positionToRestore);
					positionToRestore = Vector3.zero;
				}
			};
			chargeAction.OnAnimationGoapEvent("shoot", delegate
			{
				if (CombatAiUtils.IsAgentDefeated(agent.GetTarget()))
				{
					MonoSingleton<CombatTargetManager>.Instance.RemovePreferredTarget(agent);
					EndGoalWith(GoalCondition.Incompletable);
				}
				else
				{
					if (!(chargeBar == null) && !(chargeAction.Duration >= 0.65f))
					{
						chargeBar.FlashEffect();
					}
					agent.CombatAi?.SetState(CombatAiState.LastAttackTime, TimerController.TimeSinceStartup);
					agent.CombatAi?.SetState(CombatAiState.LastAttackedTarget, agent.GetTarget());
					if (agent is AnimalInstance animalInstance)
					{
						PlayAnimalAttackSound(animalInstance, agent.GetPosition());
					}
					if (base.AgentOwner is HumanoidInstance humanoidInstance)
					{
						NPC npcBlueprint = humanoidInstance.ActiveBehaviour.NpcBlueprint;
						if ((object)npcBlueprint != null && agent.GetTarget() is BaseBuildingInstance baseBuildingInstance && baseBuildingInstance.GetComponentInstance<ProductionComponentInstance>() != null && Random.value < npcBlueprint.SetProductionBuildingOnFireChance)
						{
							baseBuildingInstance.SetFire(agent.GetGridPosition(), 0.3f);
							EndGoalWith(GoalCondition.Incompletable);
							MonoSingleton<CombatTargetManager>.Instance.RemovePreferredTarget(ownerAgent);
							return;
						}
					}
					if (CombatUtils.GetAttackType(agent) == AttackType.Melee)
					{
						CombatActions.AttackMelee(agent);
					}
					else
					{
						CombatActions.FireRangedWeapon(agent);
					}
				}
			});
			chargeAction.TickOnInterval(0.5f, WeaponModeUpdate);
			chargeAction.TriggerAnimation("Attack", ActionAnimationMode.Ignore, isSequenced: true);
			chargeAction.WithDynamicAnimatorParameter("AttackRnd", () => (int)Random.Range(0f, 3f));
			chargeAction.FailIfInvalidCombatTarget();
			chargeAction.FailIfCombatTargetClears();
			chargeAction.FailIfCombatTargetAnimalGetsRoped();
			chargeAction.FailIfViolatingGenevaConvention();
			if (targetIsNotACreature)
			{
				chargeAction.FailIfTargetBecomesFireDangerous();
			}
			yield return chargeAction;
			yield return new GoapAction("CheckTargetValidity")
			{
				OnInit = delegate
				{
					if (ownerAgent.GetTarget() == null || !CombatUtils.IsAttackPossible(ownerAgent, ownerAgent.GetTarget()))
					{
						MonoSingleton<CombatTargetManager>.Instance.RemovePreferredTarget(ownerAgent);
						EndGoalWith(GoalCondition.Succeeded);
					}
				}
			};
			yield return JumpActions.ConditionalJump(getInRange, delegate
			{
				if (ownerAgent.CombatAi.GetState<bool>(CombatAiState.IsSingleAttackSwingMode))
				{
					MonoSingleton<CombatTargetManager>.Instance.RemovePreferredTarget(ownerAgent);
					return false;
				}
				return CombatUtils.IsAlive(ownerAgent.GetTarget());
			});
		}

		private void PlayAnimalAttackSound(AnimalInstance animalInstance, Vector3 position)
		{
			string text = animalInstance.Blueprint.GetID().CapitalizeFirst() + "Attack";
			if (MonoRepository<SoundRepository, SoundEvent>.Instance.EventExists(text))
			{
				MonoSingleton<AudioManager>.Instance.PlaySoundAtPosition(text, position);
			}
		}

		protected virtual bool AssignPreferredTarget()
		{
			initialPath = null;
			IDamageTakingAgent preferredTarget = MonoSingleton<CombatTargetManager>.Instance.GetPreferredTarget(ownerAgent);
			if (failedTarget != preferredTarget || failedTarget == null)
			{
				failedTarget = null;
				failedCount = 0;
			}
			ownerAgent.SetTarget(preferredTarget);
			if (!CombatUtils.IsAlive(preferredTarget) || !CombatUtils.IsAttackPossible(ownerAgent, preferredTarget))
			{
				bool isEnabled;
				FVLogTraceInterpolationHandler messageBuilder = new FVLogTraceInterpolationHandler(36, 2, out isEnabled, "C:\\GIT\\dev\\Assets\\Scripts\\GOAP\\Goal\\AttackBaseGoal.cs");
				if (isEnabled)
				{
					messageBuilder.AppendLiteral("Attack not possible, target ");
					messageBuilder.AppendFormatted(preferredTarget);
					messageBuilder.AppendLiteral(", agent ");
					messageBuilder.AppendFormatted(ownerAgent);
				}
				Log.Trace(messageBuilder);
				MonoSingleton<ThreadingJobSystem>.Instance.ExecuteOnMainThread(delegate
				{
					MonoSingleton<CombatTargetManager>.Instance.SetPreferredTarget((IDamageDealAgent)base.AgentOwner, null);
				});
				return false;
			}
			return true;
		}

		protected bool CalculateInitialPath()
		{
			IDamageDealAgent damageDealAgent = (IDamageDealAgent)base.AgentOwner;
			IDamageTakingAgent damageTakingAgent = damageDealAgent?.GetTarget();
			bool isEnabled;
			FVLogTraceInterpolationHandler messageBuilder;
			if (CombatUtils.IsNullOrDisposed(damageDealAgent, damageTakingAgent))
			{
				messageBuilder = new FVLogTraceInterpolationHandler(43, 2, out isEnabled, "C:\\GIT\\dev\\Assets\\Scripts\\GOAP\\Goal\\AttackBaseGoal.cs");
				if (isEnabled)
				{
					messageBuilder.AppendLiteral("Target is null or disposed, target ");
					messageBuilder.AppendFormatted(damageTakingAgent);
					messageBuilder.AppendLiteral(", agent ");
					messageBuilder.AppendFormatted(ownerAgent);
				}
				Log.Trace(messageBuilder);
				return false;
			}
			if (CombatAttackerPositioningManager.IsInAttackPosition(damageDealAgent, damageTakingAgent))
			{
				messageBuilder = new FVLogTraceInterpolationHandler(27, 1, out isEnabled, "C:\\GIT\\dev\\Assets\\Scripts\\GOAP\\Goal\\AttackBaseGoal.cs");
				if (isEnabled)
				{
					messageBuilder.AppendLiteral("Already in attack position ");
					messageBuilder.AppendFormatted(base.AgentOwner);
				}
				Log.Trace(messageBuilder);
				return true;
			}
			IDamageTakingAgent preferredTarget = MonoSingleton<CombatTargetManager>.Instance.GetPreferredTarget(ownerAgent);
			initialPath = MonoSingleton<CombatAttackTracker>.Instance.StartAttackPath(damageDealAgent);
			if (initialPath == null)
			{
				messageBuilder = new FVLogTraceInterpolationHandler(18, 1, out isEnabled, "C:\\GIT\\dev\\Assets\\Scripts\\GOAP\\Goal\\AttackBaseGoal.cs");
				if (isEnabled)
				{
					messageBuilder.AppendLiteral("Initial path null ");
					messageBuilder.AppendFormatted(base.AgentOwner);
				}
				Log.Trace(messageBuilder);
				MapNode agentNode = damageDealAgent.GetNode();
				if ((agentNode.Tag & MapNodeTags.Ladder) != MapNodeTags.None && agentNode == preferredTarget.GetNode())
				{
					float ladderAttackOffset = CombatActions.GetLadderAttackOffset(preferredTarget);
					PathfinderAgentDriver driver = ((IPathfindingAgent)ownerAgent).PathDriver;
					MonoSingleton<ThreadingJobSystem>.Instance.ExecuteOnMainThread(delegate
					{
						driver.Teleport(agentNode.WorldPosition + new Vector3(0f, ladderAttackOffset, 0f));
					});
					return true;
				}
				messageBuilder = new FVLogTraceInterpolationHandler(19, 1, out isEnabled, "C:\\GIT\\dev\\Assets\\Scripts\\GOAP\\Goal\\AttackBaseGoal.cs");
				if (isEnabled)
				{
					messageBuilder.AppendLiteral("Target unreachable ");
					messageBuilder.AppendFormatted(base.AgentOwner);
				}
				Log.Trace(messageBuilder);
				MonoSingleton<ThreadingJobSystem>.Instance.ExecuteOnMainThread(delegate
				{
					MonoSingleton<CombatTargetManager>.Instance.SetPreferredTarget(damageDealAgent, null);
				});
				return false;
			}
			MonoSingleton<PathProcessorManager>.Instance.InstantProcessPath(initialPath);
			if (initialPath.State == PathState.Calculated)
			{
				messageBuilder = new FVLogTraceInterpolationHandler(23, 1, out isEnabled, "C:\\GIT\\dev\\Assets\\Scripts\\GOAP\\Goal\\AttackBaseGoal.cs");
				if (isEnabled)
				{
					messageBuilder.AppendLiteral("Attack path calculated ");
					messageBuilder.AppendFormatted(base.AgentOwner);
				}
				Log.Trace(messageBuilder);
				return true;
			}
			messageBuilder = new FVLogTraceInterpolationHandler(45, 2, out isEnabled, "C:\\GIT\\dev\\Assets\\Scripts\\GOAP\\Goal\\AttackBaseGoal.cs");
			if (isEnabled)
			{
				messageBuilder.AppendLiteral("Attack path calculation failed (errorType: ");
				messageBuilder.AppendFormatted(initialPath.ErrorType);
				messageBuilder.AppendLiteral(") ");
				messageBuilder.AppendFormatted(base.AgentOwner);
			}
			Log.Trace(messageBuilder);
			failedTarget = preferredTarget;
			failedCount++;
			if (failedCount >= 3)
			{
				MonoSingleton<ThreadingJobSystem>.Instance.ExecuteOnMainThread(delegate
				{
					MonoSingleton<CombatTargetManager>.Instance.SetPreferredTarget((IDamageDealAgent)base.AgentOwner, null);
				});
				failedTarget = null;
				failedCount = 0;
			}
			Path.ReleasePath(initialPath);
			return false;
		}

		private static void WeaponModeUpdate(GoapAction action)
		{
			IDamageDealAgent damageDealAgent = (IDamageDealAgent)action.AgentOwner;
			if (CombatUtils.IsNullOrDisposed(damageDealAgent))
			{
				return;
			}
			EquipmentInstance weapon = CombatUtils.GetWeapon(damageDealAgent, ignoreForbidden: true);
			if (weapon == null)
			{
				return;
			}
			if (weapon.Blueprint.SecondaryWeaponMode == null)
			{
				WeaponModeUpdatePrimaryOnly(damageDealAgent);
				return;
			}
			damageDealAgent.ForbidWeapon = false;
			IDamageTakingAgent target = damageDealAgent.GetTarget();
			bool flag = CombatUtils.IsAgentSwimming(damageDealAgent);
			if (weapon.AttackType != AttackType.Melee)
			{
				if (flag)
				{
					damageDealAgent.ToggleWeaponMode(weapon);
				}
				else
				{
					if (!CombatUtils.IsInAttackRange(damageDealAgent, target, -1f, weapon.OtherWeaponMode))
					{
						return;
					}
					PathfinderAgentDriver pathfinderAgentDriver = (target as IPathfindingAgent)?.PathDriver;
					if (pathfinderAgentDriver != null && pathfinderAgentDriver.IsMoving)
					{
						Vector3 worldPosition = pathfinderAgentDriver.NextStop.WorldPosition;
						float range = CombatUtils.GetRange(damageDealAgent, target, weapon.OtherWeaponMode);
						if (Vector3.Distance(worldPosition, damageDealAgent.GetPosition()) > range)
						{
							return;
						}
					}
					damageDealAgent.ToggleWeaponMode(weapon);
				}
			}
			else if (!flag && !CombatUtils.IsInAttackRange(damageDealAgent, target))
			{
				damageDealAgent.ToggleWeaponMode(weapon);
			}
		}

		private static void WeaponModeUpdatePrimaryOnly(IDamageDealAgent agent)
		{
			if (!agent.ForbidWeapon && CombatUtils.GetAttackType(agent) == AttackType.Melee)
			{
				return;
			}
			IDamageTakingAgent target = agent.GetTarget();
			if (target == null)
			{
				return;
			}
			bool flag = Vector3.Distance(target.GetPosition(), agent.GetPosition()) <= 2f && CombatAttackerPositioningManager.IsInHeightDiffLimitRange(agent, target);
			if (!flag && CombatUtils.IsAgentSwimming(agent))
			{
				flag = true;
			}
			if (flag == agent.ForbidWeapon)
			{
				return;
			}
			if (flag)
			{
				PathfinderAgentDriver pathfinderAgentDriver = (target as IPathfindingAgent)?.PathDriver;
				if (pathfinderAgentDriver != null && pathfinderAgentDriver.IsMoving)
				{
					Vector3 worldPosition = pathfinderAgentDriver.NextStop.WorldPosition;
					agent.ForbidWeapon = Vector3.Distance(worldPosition, agent.GetPosition()) <= 2f;
					return;
				}
			}
			agent.ForbidWeapon = flag;
		}

		private void SpawnChargeProgressBar()
		{
			if (chargeBar != null)
			{
				return;
			}
			CreatureBase creatureBase = (CreatureBase)base.AgentOwner;
			Sprite sprite;
			if (base.AgentOwner is AnimalInstance animalInstance)
			{
				sprite = AssetUtils.GetSprite(animalInstance.Blueprint.AttackIcon);
			}
			else
			{
				EquipmentInstance equipmentInstance = creatureBase?.Inventory?.GetItem(ItemType.Weapon);
				sprite = ((equipmentInstance == null || creatureBase.ForbidWeapon) ? AssetUtils.GetSprite("fist_attack") : AssetUtils.GetSprite(equipmentInstance.Blueprint.Resource.IconPath));
			}
			if (!(sprite == null))
			{
				float interval = CombatCalculator.CalculateAttackSpeed(creatureBase);
				chargeBar = (CircularProgressBarFloatingElement)((IProgressBarOwner)base.AgentOwner).GetProgressBar(OverlayProgressBarType.CombatCircle);
				if (!(chargeBar == null))
				{
					chargeBar.Setup(new Timer(interval), isInverted: true);
					chargeBar.FillImage.sprite = sprite;
				}
			}
		}

		private void DestroyChargeProgressBar()
		{
			if (!(chargeBar == null))
			{
				chargeBar?.Timer?.Dispose();
				chargeBar?.Dispose();
				chargeBar = null;
			}
		}

		private void OnAttackStreamStart()
		{
			MonoSingleton<CombatController>.Instance.OnAttackStreamStart(ownerAgent);
		}

		private void OnAttackStreamEnd()
		{
			if (ownerAgent.CurrentAttackStream != 0)
			{
				MonoSingleton<CombatController>.Instance.OnAttackStreamEnd(ownerAgent);
				ownerAgent.CurrentAttackStream = 0;
			}
		}
	}
}
