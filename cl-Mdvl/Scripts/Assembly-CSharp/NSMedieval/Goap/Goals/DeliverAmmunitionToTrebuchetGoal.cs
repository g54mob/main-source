using System.Collections.Generic;
using System.Linq;
using FoxyVoxel.Logging;
using FoxyVoxel.Logging.Core.LogMessageInterpolationHandlers;
using NSMedieval.BuildingComponents;
using NSMedieval.Construction;
using NSMedieval.Goap.Actions;
using NSMedieval.Pathfinding;
using NSMedieval.State;

namespace NSMedieval.Goap.Goals
{
	public class DeliverAmmunitionToTrebuchetGoal : Goal
	{
		private readonly SiegeWeaponComponentInstance siegeWeaponComponentInstance;

		private readonly bool forceOperationGoal;

		public SiegeWeaponComponentInstance SiegeWeaponComponentInstance => siegeWeaponComponentInstance;

		public DeliverAmmunitionToTrebuchetGoal(Agent selfAgent, SiegeWeaponComponentInstance siegeWeaponComponentInstance, bool forceOperationGoal)
			: base("DeliverAmmunitionToTrebuchetGoal", selfAgent)
		{
			this.siegeWeaponComponentInstance = siegeWeaponComponentInstance;
			this.forceOperationGoal = forceOperationGoal;
			AddInitStep(new ThreadSequenceStep(null, PrepareData, ReserveTargets));
		}

		public override bool AgentTypeCheck()
		{
			return base.AgentOwner is HumanoidInstance;
		}

		public override bool CanStart(bool isForced = false)
		{
			if (siegeWeaponComponentInstance != null && !siegeWeaponComponentInstance.HasDisposed && siegeWeaponComponentInstance.OwnerBuilding != null && !siegeWeaponComponentInstance.OwnerBuilding.HasDisposed)
			{
				return siegeWeaponComponentInstance.Storage.IsEmpty();
			}
			return false;
		}

		public override void EndGoalWith(GoalCondition condition)
		{
			base.EndGoalWith(condition);
			if (condition == GoalCondition.Succeeded && forceOperationGoal)
			{
				base.Agent.ForceNextGoal(new OperateTrebuchetGoal(base.Agent));
			}
		}

		protected override IEnumerable<GoapAction> GetNextAction()
		{
			yield return GoToActions.GoToTarget(TargetIndex.A, PathCompleteMode.ExactPosition).FailIfTargetDisposedForbidenOrNull(TargetIndex.A).FailIfTargetDisposedForbidenOrNull(TargetIndex.B);
			yield return ResourceActions.PickupResourceFromPile(TargetIndex.A, 1);
			yield return GoToActions.GoToTarget(TargetIndex.B, PathCompleteMode.ExactPosition).FailIfTargetDisposedForbidenOrNull(TargetIndex.B);
			yield return ResourceActions.DeliverToSiegeWeapon(TargetIndex.B).FailIfTargetDisposedForbidenOrNull(TargetIndex.B).TriggerAnimation("DropPile", ActionAnimationMode.WaitForCompletion);
		}

		private bool PrepareData()
		{
			List<TargetObject> list = PathfinderResourcePile.FindPiles((IPathfindingAgent)base.AgentOwner, (ResourcePileInstance x) => siegeWeaponComponentInstance.ResourcesFilter.IsValid(x.Blueprint));
			if (list == null || list.Count == 0)
			{
				return false;
			}
			QueueTargets(TargetIndex.A, list);
			return true;
		}

		private bool ReserveTargets()
		{
			if (siegeWeaponComponentInstance == null || siegeWeaponComponentInstance.HasDisposed)
			{
				return false;
			}
			ReservablePosition reservablePosition = siegeWeaponComponentInstance.ReservablePositionsComponentInstance.ReservablePositions.FirstOrDefault();
			if (reservablePosition == null)
			{
				return false;
			}
			bool isEnabled;
			FVLogTraceInterpolationHandler messageBuilder = new FVLogTraceInterpolationHandler(23, 1, out isEnabled, "C:\\GIT\\dev\\Assets\\Scripts\\GOAP\\Goal\\DeliverAmmunitionToTrebuchetGoal.cs");
			if (isEnabled)
			{
				messageBuilder.AppendLiteral("Deliver ammo position: ");
				messageBuilder.AppendFormatted(reservablePosition.Position);
			}
			Log.Trace(messageBuilder);
			SetTarget(TargetIndex.B, new TargetObject(siegeWeaponComponentInstance, reservablePosition.Position));
			return ReserveAndSelectFirstTargetFromQueue(TargetIndex.A);
		}
	}
}
