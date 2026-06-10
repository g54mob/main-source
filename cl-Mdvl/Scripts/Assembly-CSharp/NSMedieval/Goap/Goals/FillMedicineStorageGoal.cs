using System.Collections.Generic;
using NSEipix.Base;
using NSMedieval.Goap.Actions;
using NSMedieval.Manager;
using NSMedieval.Model;
using NSMedieval.Pathfinding;
using NSMedieval.State;
using NSMedieval.State.WorkerJobs;

namespace NSMedieval.Goap.Goals
{
	public class FillMedicineStorageGoal : Goal
	{
		private const float MinHealingAmountRequired = 1.2f;

		private readonly HumanoidInstance humanoid;

		public FillMedicineStorageGoal(Agent selfAgent)
			: base("FillMedicineStorageGoal", selfAgent)
		{
			humanoid = base.AgentOwner as HumanoidInstance;
			AddInitStep(new ThreadSequenceStep(null, FindAndTargetMedicine));
		}

		public override bool CanStart(bool isForced = false)
		{
			if (humanoid == null || humanoid.HasDisposed || humanoid.HasDied)
			{
				return false;
			}
			if (humanoid.WorkerBehaviour.IsJobActive(JobType.TendWounds))
			{
				return humanoid.MedicineStorage.IsEmpty();
			}
			return false;
		}

		public override bool AgentTypeCheck()
		{
			return base.AgentOwner is HumanoidInstance;
		}

		protected override IEnumerable<GoapAction> GetNextAction()
		{
			yield return GoToActions.GoToTarget(TargetIndex.A, PathCompleteMode.ExactPosition).FailIfTargetDisposedForbidenOrNull(TargetIndex.A).FailIfTargetReservationReleases(TargetIndex.A);
			yield return GeneralActions.Instant().TriggerAnimation("PickUpPile", ActionAnimationMode.WaitForCompletion).FailIfTargetDisposedForbidenOrNull(TargetIndex.A)
				.FailIfTargetReservationReleases(TargetIndex.A);
			yield return ResourceActions.PickupResourceFromPile(TargetIndex.A, (Resource blueprint) => 1, delegate
			{
			}, onlySameResourceType: false, humanoid.MedicineStorage).SkipIfTargetDisposedForbidenOrNull(TargetIndex.A);
		}

		private bool FindAndTargetMedicine()
		{
			ResourcePileInstance resourcePileInstance = CommonGoalMethods.FindMedicine(humanoid, humanoid.GetGridPosition(), mustBeInStorage: true, 1.2f);
			if (resourcePileInstance == null)
			{
				return false;
			}
			if (!MonoSingleton<ReservationManager>.Instance.TryReserveObject(resourcePileInstance, base.AgentOwner))
			{
				return false;
			}
			SetTarget(TargetIndex.A, new TargetObject(resourcePileInstance));
			return true;
		}
	}
}
