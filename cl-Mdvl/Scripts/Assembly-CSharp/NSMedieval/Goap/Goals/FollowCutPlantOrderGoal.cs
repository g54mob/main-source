using System.Collections.Generic;
using NSEipix.Base;
using NSMedieval.CommanderAI.Orders;
using NSMedieval.Controllers;
using NSMedieval.Goap.Actions;
using NSMedieval.Manager;
using NSMedieval.Pathfinding;
using NSMedieval.State;
using NSMedieval.Types;
using NSMedieval.View;
using NSMedieval.Water;
using UnityEngine;

namespace NSMedieval.Goap.Goals
{
	public class FollowCutPlantOrderGoal : FollowOrderBaseGoal<CutPlantOrder>
	{
		public FollowCutPlantOrderGoal(Agent selfAgent)
			: base(selfAgent, "FollowCutPlantOrderGoal")
		{
			AddInitStep(new ThreadSequenceStep(null, PrepareData));
		}

		public override void EndGoalWith(GoalCondition condition)
		{
			base.EndGoalWith(condition);
			NPCView view = MonoSingleton<NPCManager>.Instance.GetView(base.AgentOwner as HumanoidInstance);
			if (view != null)
			{
				view.TrySetParameter("IsCombatAlert", value: true);
			}
		}

		protected override IEnumerable<GoapAction> GetNextAction()
		{
			PlantMapResourceInstance plantMapResourceInstance = GetTarget(TargetIndex.A).GetObjectAs<PlantMapResourceInstance>();
			yield return GoToActions.GoToTarget(TargetIndex.A, PathCompleteMode.ExactPosition).FailIfTargetDisposedForbidenOrNull(TargetIndex.A).FailIfTargetReservationReleases(TargetIndex.A)
				.FailAtCondition(() => FailIfUnderWater(plantMapResourceInstance));
			GoapAction goapAction = MapResourceActions.EnemyCutPlant(TargetIndex.A);
			goapAction.OnInit = delegate
			{
				NPCView view = MonoSingleton<NPCManager>.Instance.GetView(base.AgentOwner as HumanoidInstance);
				if (view != null)
				{
					view.TrySetParameter("IsCombatAlert", value: false);
				}
			};
			goapAction.FailIfTargetDisposedForbidenOrNull(TargetIndex.A);
			goapAction.FailAtCondition(() => FailIfUnderWater(plantMapResourceInstance));
			goapAction.FailIfTargetReservationReleases(TargetIndex.A);
			goapAction.TriggerAnimation("Mining", ActionAnimationMode.Interrupt);
			goapAction.OnComplete = delegate
			{
				if (base.State == GoalState.Ended)
				{
					DamagePopup.Create(((IHarvestAgent)base.AgentOwner).GetPosition(), MonoSingleton<LocalizationController>.Instance.GetText("plant_cut_failed"), Color.red);
					if (base.AgentOwner is HumanoidInstance { WorkerBehaviour: not null } humanoidInstance)
					{
						humanoidInstance.WorkerBehaviour.WorkerProximity.OnChopFailed();
					}
				}
			};
			yield return goapAction;
			yield return MapResourceActions.SpawnHarvestedResources(TargetIndex.A, OrderType.CutAllVegetation | OrderType.Chopping);
		}

		protected override bool CanStartFollowingOrder()
		{
			PlantMapResourceInstance plantToChop = base.CurrentOrder.PlantToChop;
			if (plantToChop != null)
			{
				return !plantToChop.HasDisposed;
			}
			return false;
		}

		private bool PrepareData()
		{
			if (!MonoSingleton<ReservationManager>.Instance.TryReserveObject(base.CurrentOrder.PlantToChop, base.AgentOwner))
			{
				return false;
			}
			SetTarget(TargetIndex.A, new TargetObject(base.CurrentOrder.PlantToChop));
			return true;
		}

		private bool FailIfUnderWater(PlantMapResourceInstance plantMapResourceInstance)
		{
			if (plantMapResourceInstance == null || plantMapResourceInstance.HasDisposed)
			{
				return false;
			}
			WaterDepthLevel waterDepthLevel = plantMapResourceInstance.WaterDepthLevel;
			if (waterDepthLevel != WaterDepthLevel.Medium)
			{
				return waterDepthLevel == WaterDepthLevel.High;
			}
			return true;
		}
	}
}
