using System.Collections.Generic;
using System.Linq;
using NSEipix.Base;
using NSMedieval.BuildingComponents;
using NSMedieval.CombatAi;
using NSMedieval.CommanderAI.Orders;
using NSMedieval.Construction;
using NSMedieval.Controllers;
using NSMedieval.Goap.Actions;
using NSMedieval.Manager;
using NSMedieval.Pathfinding;
using NSMedieval.State;
using NSMedieval.StatsSystem;
using NSMedieval.View;
using NSMedieval.Village;
using NSMedieval.Village.Map;
using NSMedieval.Village.Map.Pathfinding;

namespace NSMedieval.Goap.Goals
{
	public class FollowOperateSiegeWeaponOrderGoal : FollowOrderBaseGoal<OperateSiegeWeaponOrder>
	{
		private VillageMap map;

		private ReservablePosition reservablePosition;

		private bool reloadingInProgress;

		public FollowOperateSiegeWeaponOrderGoal(Agent selfAgent)
			: base(selfAgent, "FollowOperateSiegeWeaponOrderGoal")
		{
			map = VillageManager.ActiveVillage.Map;
			AddInitStep(new ThreadSequenceStep(null, PrepareData));
		}

		public override void Dispose()
		{
			base.Dispose();
			map = null;
			reservablePosition = null;
		}

		protected override bool CanStartFollowingOrder()
		{
			SiegeWeaponComponentInstance siegeWeaponComponentInstance = base.CurrentOrder.SiegeWeaponComponentInstance;
			if (siegeWeaponComponentInstance != null && !siegeWeaponComponentInstance.HasDisposed && siegeWeaponComponentInstance.OwnerBuilding != null && !siegeWeaponComponentInstance.OwnerBuilding.HasDisposed && siegeWeaponComponentInstance.ReservablePositionsComponentInstance.ReservablePositions.Any((ReservablePosition x) => !x.Reserved))
			{
				return !siegeWeaponComponentInstance.Storage.IsEmpty();
			}
			return false;
		}

		public override void EndGoalWith(GoalCondition condition)
		{
			base.EndGoalWith(condition);
			NPCView view = MonoSingleton<NPCManager>.Instance.GetView(base.AgentOwner as HumanoidInstance);
			if (view != null)
			{
				view.TrySetParameter("IsCombatAlert", value: true);
			}
			if (condition != GoalCondition.Succeeded && reloadingInProgress)
			{
				base.CurrentOrder.SiegeWeaponComponentInstance.ReloadFailed();
			}
			reloadingInProgress = false;
			base.CurrentOrder.SiegeWeaponComponentInstance.IsOperatorReady = false;
			base.CombatAi.SetState(CombatAiState.OperatingTrebuchet, null);
			reservablePosition?.Release(base.AgentOwner);
			reservablePosition = null;
		}

		protected override IEnumerable<GoapAction> GetNextAction()
		{
			yield return GoToActions.GoToTargetNoRotation(TargetIndex.A, PathCompleteMode.ExactPosition).FailIfTargetDisposedForbidenOrNull(TargetIndex.A);
			GoapAction skipReloading = GeneralActions.Instant("SkipReloading");
			yield return JumpActions.ConditionalJump(skipReloading, () => base.CurrentOrder.SiegeWeaponComponentInstance.WeaponInAttackPosition);
			GoapAction reloadSiegeMachine = new GoapAction("ReloadSiegeMachine")
			{
				CompleteMode = ActionCompleteMode.Never
			};
			string animTrigger;
			switch (base.CurrentOrder.SiegeWeaponComponentInstance.Blueprint.SiegeWeaponType)
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
			float totalTime = 0f;
			reloadSiegeMachine.OnInit = delegate
			{
				NPCView view = MonoSingleton<NPCManager>.Instance.GetView(base.AgentOwner as HumanoidInstance);
				if (view != null)
				{
					view.TrySetParameter("IsCombatAlert", value: false);
				}
				if (reservablePosition != null && base.AgentOwner is HumanoidInstance humanoidInstance)
				{
					SiegeWeaponComponent component = map.SiegeWeaponComponentManager.GetComponent(base.CurrentOrder.SiegeWeaponComponentInstance);
					humanoidInstance.GetAgentView<NPCView>()?.FaceObject(component.BuildingUsePositionsComponent.GetUsePositionTransform(reservablePosition.Position));
				}
				totalTime = base.CurrentOrder.SiegeWeaponComponentInstance.Blueprint.ReloadAnimationSpeed;
				float attributeValue = ((IProductionAgent)base.AgentOwner).GetAttributeValue(AttributeType.MotorFunction);
				if (attributeValue != 0f)
				{
					totalTime /= attributeValue;
				}
				base.CurrentOrder.SiegeWeaponComponentInstance.ReloadSuccessEvent += OnReloadSuccess;
				base.CurrentOrder.SiegeWeaponComponentInstance.ReloadFailedEvent += OnReloadFailed;
				if (!base.CurrentOrder.SiegeWeaponComponentInstance.AttackInProgress)
				{
					base.CurrentOrder.SiegeWeaponComponentInstance.StartReloading(totalTime);
					reloadingInProgress = true;
					MonoSingleton<AnimationController>.Instance.SetAnimatorParameter(base.AgentOwner, animTrigger, value: true);
				}
			};
			reloadSiegeMachine.OnTick = delegate
			{
				if (base.CurrentOrder.SiegeWeaponComponentInstance != null && !reloadingInProgress && !base.CurrentOrder.SiegeWeaponComponentInstance.AttackInProgress)
				{
					reloadingInProgress = true;
					base.CurrentOrder.SiegeWeaponComponentInstance.StartReloading(totalTime);
					MonoSingleton<AnimationController>.Instance.SetAnimatorParameter(base.AgentOwner, animTrigger, value: true);
				}
			};
			yield return reloadSiegeMachine;
			yield return skipReloading;
			GoapAction goapAction = GeneralActions.WaitForever();
			goapAction.OnInit = delegate
			{
				if (reservablePosition != null && base.AgentOwner is HumanoidInstance humanoidInstance)
				{
					SiegeWeaponComponent component = map.SiegeWeaponComponentManager.GetComponent(base.CurrentOrder.SiegeWeaponComponentInstance);
					humanoidInstance.GetAgentView<NPCView>()?.FaceObject(component.BuildingUsePositionsComponent.GetUsePositionTransform(reservablePosition.Position));
				}
				base.CurrentOrder.SiegeWeaponComponentInstance.IsOperatorReady = true;
			};
			goapAction.TickOnInterval(1f, delegate
			{
				if (base.CurrentOrder.SiegeWeaponComponentInstance.IsOnFire || base.AgentOwner is CreatureBase { IsOnFire: not false })
				{
					EndGoalWith(GoalCondition.Succeeded);
				}
				else if (!base.CurrentOrder.SiegeWeaponComponentInstance.HasAmmunition())
				{
					EndGoalWith(GoalCondition.Succeeded);
				}
			});
			yield return goapAction;
			void OnReloadFailed()
			{
				MonoSingleton<AnimationController>.Instance.SetAnimatorParameter(base.AgentOwner, animTrigger, value: false);
				reloadSiegeMachine.Complete(ActionCompletionStatus.Fail);
				if (base.CurrentOrder.SiegeWeaponComponentInstance != null)
				{
					base.CurrentOrder.SiegeWeaponComponentInstance.ReloadFailedEvent -= OnReloadFailed;
					base.CurrentOrder.SiegeWeaponComponentInstance.ReloadSuccessEvent -= OnReloadSuccess;
				}
			}
			void OnReloadSuccess()
			{
				MonoSingleton<AnimationController>.Instance.SetAnimatorParameter(base.AgentOwner, animTrigger, value: false);
				reloadingInProgress = false;
				reloadSiegeMachine.Complete(ActionCompletionStatus.Success);
				if (base.CurrentOrder.SiegeWeaponComponentInstance != null)
				{
					base.CurrentOrder.SiegeWeaponComponentInstance.ReloadSuccessEvent -= OnReloadSuccess;
					base.CurrentOrder.SiegeWeaponComponentInstance.ReloadFailedEvent -= OnReloadFailed;
				}
			}
		}

		private bool PrepareData()
		{
			base.CombatAi.SetState(CombatAiState.OperatingTrebuchet, base.CurrentOrder.SiegeWeaponComponentInstance);
			if (!MonoSingleton<ReservationManager>.Instance.TryReserveObject(base.CurrentOrder.SiegeWeaponComponentInstance, base.AgentOwner))
			{
				return false;
			}
			IPathfindingAgent pathfindingAgent = (IPathfindingAgent)base.AgentOwner;
			foreach (ReservablePosition reservablePosition in base.CurrentOrder.SiegeWeaponComponentInstance.ReservablePositionsComponentInstance.ReservablePositions)
			{
				if (!reservablePosition.Reserved && PathfinderUtil.IsPathPossible(pathfindingAgent, reservablePosition.Position))
				{
					this.reservablePosition = reservablePosition;
					reservablePosition.Reserve(base.AgentOwner);
					SetTarget(TargetIndex.A, new TargetObject(base.CurrentOrder.SiegeWeaponComponentInstance, reservablePosition.Position));
					return true;
				}
			}
			return false;
		}
	}
}
