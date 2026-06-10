using System.Collections.Generic;
using FoxyVoxel.Logging;
using FoxyVoxel.Logging.Core.LogMessageInterpolationHandlers;
using NSEipix;
using NSEipix.Base;
using NSMedieval.BuildingComponents;
using NSMedieval.CombatAi;
using NSMedieval.Construction;
using NSMedieval.Controllers;
using NSMedieval.Goap.Actions;
using NSMedieval.Manager;
using NSMedieval.Model;
using NSMedieval.Pathfinding;
using NSMedieval.RoomDetection;
using NSMedieval.State;
using NSMedieval.StatsSystem;
using NSMedieval.Types;
using NSMedieval.View;
using NSMedieval.Village;
using NSMedieval.Village.Map;
using NSMedieval.Village.Map.Pathfinding;
using UnityEngine;

namespace NSMedieval.Goap.Goals
{
	public class OperateTrebuchetGoal : Goal
	{
		private VillageMap map;

		private SiegeWeaponComponentInstance siegeWeaponComponentInstance;

		private ReservablePosition reservablePosition;

		private bool reloadingInProgress;

		private bool isInPosition;

		public OperateTrebuchetGoal(Agent selfAgent)
			: base("OperateTrebuchetGoal", selfAgent)
		{
			AddInitStep(new ThreadSequenceStep(CheckReservation, AmmoDelivery));
			map = VillageManager.ActiveVillage.Map;
		}

		public override void Dispose()
		{
			base.Dispose();
			map = null;
			siegeWeaponComponentInstance = null;
			reservablePosition = null;
		}

		public override bool AgentTypeCheck()
		{
			return base.AgentOwner is CreatureBase;
		}

		public override bool CanStart(bool isForced = false)
		{
			siegeWeaponComponentInstance = (base.AgentOwner as IDamageDealAgent)?.CombatAi?.GetState<SiegeWeaponComponentInstance>(CombatAiState.OperatingTrebuchet);
			if (siegeWeaponComponentInstance != null && !siegeWeaponComponentInstance.HasDisposed)
			{
				return !siegeWeaponComponentInstance.IsOnFire;
			}
			return false;
		}

		public override void Start()
		{
			base.Start();
			IDamageDealAgent damageDealAgent = (IDamageDealAgent)base.AgentOwner;
			siegeWeaponComponentInstance = damageDealAgent.CombatAi.GetState<SiegeWeaponComponentInstance>(CombatAiState.OperatingTrebuchet);
		}

		public override void EndGoalWith(GoalCondition condition)
		{
			if (base.AgentOwner is HumanoidInstance humanoidInstance)
			{
				humanoidInstance.OperatingSiegeWeapon = false;
				WorkerBehaviour workerBehaviour = humanoidInstance.WorkerBehaviour;
				if (workerBehaviour != null && workerBehaviour.IsDrafting)
				{
					humanoidInstance.GetAgentView<WorkerView>()?.TrySetParameter("IsCombatAlert", value: true);
				}
			}
			isInPosition = false;
			base.EndGoalWith(condition);
			if (condition != GoalCondition.Succeeded && reloadingInProgress)
			{
				siegeWeaponComponentInstance.ReloadFailed();
			}
			if (siegeWeaponComponentInstance != null)
			{
				siegeWeaponComponentInstance.IsOperatorReady = false;
			}
			siegeWeaponComponentInstance = null;
			reservablePosition?.Release(base.AgentOwner);
			reservablePosition = null;
			reloadingInProgress = false;
		}

		protected override IEnumerable<GoapAction> GetNextAction()
		{
			GoapAction jumpGoToTrebuchet = GeneralActions.Instant("JumpGoToTrebuchet");
			yield return JumpActions.ConditionalJump(jumpGoToTrebuchet, () => siegeWeaponComponentInstance.HasAmmunition());
			yield return GoToActions.GoToTarget(TargetIndex.B, PathCompleteMode.Touch).FailIfTargetDisposedForbidenOrNull(TargetIndex.A).FailIfTargetDisposedForbidenOrNull(TargetIndex.B)
				.FailIfTargetReservationReleases(TargetIndex.B);
			yield return ResourceActions.PickupResourceFromPile(TargetIndex.B, (Resource resource) => 1).FailIfTargetDisposedForbidenOrNull(TargetIndex.A).FailIfTargetReservationReleases(TargetIndex.A);
			yield return GoToActions.GoToTargetNoRotation(TargetIndex.A, PathCompleteMode.ExactPosition).FailIfTargetDisposedForbidenOrNull(TargetIndex.A);
			yield return ResourceActions.DeliverToSiegeWeapon(TargetIndex.A).FailIfTargetDisposedForbidenOrNull(TargetIndex.A).TriggerAnimation("DropPile", ActionAnimationMode.WaitForCompletion);
			yield return jumpGoToTrebuchet;
			yield return GoToActions.GoToTargetNoRotation(TargetIndex.A, PathCompleteMode.ExactPosition).FailIfTargetDisposedForbidenOrNull(TargetIndex.A);
			GoapAction skipReloading = GeneralActions.Instant("SkipReloading");
			yield return JumpActions.ConditionalJump(skipReloading, () => siegeWeaponComponentInstance.WeaponInAttackPosition);
			GoapAction reloadSiegeMachine = new GoapAction("ReloadSiegeMachine")
			{
				CompleteMode = ActionCompleteMode.Never
			};
			float totalTime = 0f;
			string animTrigger;
			switch (siegeWeaponComponentInstance.Blueprint.SiegeWeaponType)
			{
			case SiegeWeaponType.Ballista:
				animTrigger = "BallistaReload";
				break;
			case SiegeWeaponType.Onager:
				animTrigger = "OnagerReload";
				break;
			case SiegeWeaponType.Trebuchet:
				animTrigger = "TrebuchetReload";
				break;
			default:
				animTrigger = "BallistaReload";
				break;
			}
			reloadSiegeMachine.OnInit = delegate
			{
				if (base.AgentOwner is HumanoidInstance humanoidInstance)
				{
					humanoidInstance.PathDriver.IsFloatingAllowed = true;
					humanoidInstance.OperatingSiegeWeapon = true;
					isInPosition = true;
					RotateTowardsTargetAndSnapToPosition();
					WorkerBehaviour workerBehaviour = humanoidInstance.WorkerBehaviour;
					if (workerBehaviour != null && workerBehaviour.IsDrafting)
					{
						humanoidInstance.GetAgentView<WorkerView>()?.TrySetParameter("IsCombatAlert", value: false);
					}
				}
				totalTime = siegeWeaponComponentInstance.Blueprint.ReloadAnimationSpeed;
				float attributeValue = ((IProductionAgent)base.AgentOwner).GetAttributeValue(AttributeType.MotorFunction);
				if (attributeValue != 0f)
				{
					totalTime /= attributeValue;
				}
				siegeWeaponComponentInstance.ReloadSuccessEvent += OnReloadSuccess;
				siegeWeaponComponentInstance.ReloadFailedEvent += OnReloadFailed;
				if (!siegeWeaponComponentInstance.AttackInProgress)
				{
					siegeWeaponComponentInstance.StartReloading(totalTime);
					reloadingInProgress = true;
					MonoSingleton<AnimationController>.Instance.SetAnimatorParameter(base.AgentOwner, animTrigger, value: true);
				}
			};
			reloadSiegeMachine.OnTick = delegate
			{
				if (siegeWeaponComponentInstance != null && !reloadingInProgress && !siegeWeaponComponentInstance.AttackInProgress)
				{
					reloadingInProgress = true;
					siegeWeaponComponentInstance.StartReloading(totalTime);
					MonoSingleton<AnimationController>.Instance.SetAnimatorParameter(base.AgentOwner, animTrigger, value: true);
				}
			};
			reloadSiegeMachine.OnComplete = delegate
			{
				IPathfindingAgent pathfindingAgent = base.AgentOwner as IPathfindingAgent;
				if (pathfindingAgent?.PathDriver != null)
				{
					pathfindingAgent.PathDriver.IsFloatingAllowed = true;
				}
			};
			reloadSiegeMachine.FailIfTargetDisposedForbidenOrNull(TargetIndex.A);
			yield return reloadSiegeMachine;
			yield return skipReloading;
			GoapAction goapAction = GeneralActions.WaitForever();
			goapAction.OnInit = delegate
			{
				if (base.AgentOwner is HumanoidInstance humanoidInstance)
				{
					humanoidInstance.PathDriver.IsFloatingAllowed = true;
					humanoidInstance.OperatingSiegeWeapon = true;
					if (!isInPosition)
					{
						RotateTowardsTargetAndSnapToPosition();
					}
				}
				siegeWeaponComponentInstance.IsOperatorReady = true;
				siegeWeaponComponentInstance.CheckIfCanStartAttack();
			};
			goapAction.TickOnInterval(1f, delegate
			{
				if (siegeWeaponComponentInstance.IsOnFire || base.AgentOwner is CreatureBase { IsOnFire: not false })
				{
					EndGoalWith(GoalCondition.Succeeded);
				}
				else if (!siegeWeaponComponentInstance.HasAmmunition())
				{
					EndGoalWith(GoalCondition.Succeeded);
					base.Agent.ForceNextGoal(new DeliverAmmunitionToTrebuchetGoal(base.Agent, GetSiegeWeaponComponentInstance(), forceOperationGoal: true));
				}
			});
			goapAction.OnComplete = delegate
			{
				IPathfindingAgent pathfindingAgent = base.AgentOwner as IPathfindingAgent;
				if (pathfindingAgent?.PathDriver != null)
				{
					pathfindingAgent.PathDriver.IsFloatingAllowed = true;
				}
			};
			yield return goapAction;
			void OnReloadFailed()
			{
				MonoSingleton<AnimationController>.Instance.SetAnimatorParameter(base.AgentOwner, animTrigger, value: false);
				reloadSiegeMachine.Complete(ActionCompletionStatus.Fail);
				if (siegeWeaponComponentInstance != null)
				{
					siegeWeaponComponentInstance.ReloadFailedEvent -= OnReloadFailed;
					siegeWeaponComponentInstance.ReloadSuccessEvent -= OnReloadSuccess;
				}
			}
			void OnReloadSuccess()
			{
				MonoSingleton<AnimationController>.Instance.SetAnimatorParameter(base.AgentOwner, animTrigger, value: false);
				reloadingInProgress = false;
				reloadSiegeMachine.Complete(ActionCompletionStatus.Success);
				if (siegeWeaponComponentInstance != null)
				{
					siegeWeaponComponentInstance.ReloadSuccessEvent -= OnReloadSuccess;
					siegeWeaponComponentInstance.ReloadFailedEvent -= OnReloadFailed;
				}
			}
		}

		private SiegeWeaponComponentInstance GetSiegeWeaponComponentInstance()
		{
			return (base.AgentOwner as IDamageDealAgent)?.CombatAi?.GetState<SiegeWeaponComponentInstance>(CombatAiState.OperatingTrebuchet);
		}

		private bool CheckReservation()
		{
			SiegeWeaponComponentInstance siegeWeaponComponentInstance = (base.AgentOwner as IDamageDealAgent)?.CombatAi?.GetState<SiegeWeaponComponentInstance>(CombatAiState.OperatingTrebuchet);
			if (siegeWeaponComponentInstance == null)
			{
				return false;
			}
			this.siegeWeaponComponentInstance = siegeWeaponComponentInstance;
			return true;
		}

		private bool TryReserveTrebuchet()
		{
			if (!MonoSingleton<ReservationManager>.Instance.TryReserveObject(siegeWeaponComponentInstance, base.AgentOwner))
			{
				return false;
			}
			IPathfindingAgent pathfindingAgent = (IPathfindingAgent)base.AgentOwner;
			foreach (ReservablePosition reservablePosition in siegeWeaponComponentInstance.ReservablePositionsComponentInstance.ReservablePositions)
			{
				if (!reservablePosition.Reserved && PathfinderUtil.IsPathPossible(pathfindingAgent, reservablePosition.Position))
				{
					bool isEnabled;
					FVLogTraceInterpolationHandler messageBuilder = new FVLogTraceInterpolationHandler(10, 1, out isEnabled, "C:\\GIT\\dev\\Assets\\Scripts\\GOAP\\Goal\\OperateTrebuchetGoal.cs");
					if (isEnabled)
					{
						messageBuilder.AppendLiteral("Reserving ");
						messageBuilder.AppendFormatted(reservablePosition.Position);
					}
					Log.Trace(messageBuilder);
					this.reservablePosition = reservablePosition;
					reservablePosition.Reserve(base.AgentOwner);
					SetTarget(TargetIndex.A, new TargetObject(siegeWeaponComponentInstance, reservablePosition.Position));
					isEnabled = true;
					return isEnabled;
				}
			}
			return false;
		}

		private bool AmmoDelivery()
		{
			if (siegeWeaponComponentInstance.HasAmmunition())
			{
				return TryReserveTrebuchet();
			}
			if (PathfinderMedieval.ExploreForObjects(new ExploreRequest
			{
				Agent = (IPathfindingAgent)base.AgentOwner,
				GridData = GridDataType.ResourcePile,
				Condition = delegate(WorldObject obj)
				{
					if (!(obj is ResourcePileInstance resourcePileInstance))
					{
						return false;
					}
					if (obj.IsOnFire)
					{
						return false;
					}
					if (resourcePileInstance.IsForbidden)
					{
						return false;
					}
					Room room = resourcePileInstance.GetRoom();
					if (room != null && room.RoomType.Prison)
					{
						return false;
					}
					return siegeWeaponComponentInstance.ResourcesFilter.IsValid(resourcePileInstance.Blueprint) ? true : false;
				},
				OnFound = delegate(WorldObject item, Vec3Int pos)
				{
					ResourcePileInstance objectInstance = item as ResourcePileInstance;
					SetTarget(TargetIndex.B, new TargetObject(objectInstance, pos));
					return P2RegionReservableWoExplorerPath.RegionExplorerCallbackResult.Finish;
				}
			}))
			{
				return TryReserveTrebuchet();
			}
			return false;
		}

		private void RotateTowardsTargetAndSnapToPosition()
		{
			if (reservablePosition == null)
			{
				return;
			}
			IGoapAgentOwner agentOwner = base.AgentOwner;
			HumanoidInstance humanoidInstance = agentOwner as HumanoidInstance;
			if (humanoidInstance == null)
			{
				return;
			}
			SiegeWeaponComponent component = map.SiegeWeaponComponentManager.GetComponent(siegeWeaponComponentInstance);
			Transform targetTransform = component.BuildingUsePositionsComponent.GetUsePositionTransform(reservablePosition.Position);
			if (targetTransform != null)
			{
				IPathfindingAgent pathfindingAgent = (IPathfindingAgent)base.AgentOwner;
				MonoSingleton<TaskController>.Instance.WaitForNextFrameUnscaled().Then(delegate
				{
					if (!(targetTransform == null))
					{
						humanoidInstance.GetAgentView<WorkerView>()?.FaceObject(targetTransform);
						pathfindingAgent?.PathDriver?.Teleport(targetTransform.position);
					}
				});
				return;
			}
			MonoSingleton<TaskController>.Instance.WaitForNextFrameUnscaled().Then(delegate
			{
				if (siegeWeaponComponentInstance != null)
				{
					humanoidInstance?.GetAgentView<WorkerView>()?.FaceObject(siegeWeaponComponentInstance.GetPosition());
				}
			});
		}
	}
}
