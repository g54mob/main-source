using System.Collections.Generic;
using System.Linq;
using NSEipix.Base;
using NSMedieval.Goap.Actions;
using NSMedieval.Manager;
using NSMedieval.Model;
using NSMedieval.Pathfinding;
using NSMedieval.State;
using NSMedieval.State.WorkerJobs;

namespace NSMedieval.Goap.Goals
{
	public class SelfTendWoundsGoal : Goal
	{
		private const float SelfTendXpMultiplier = 0.8f;

		private const float SelfTendHealQualityMultiplier = 0.25f;

		private HumanoidInstance humanoid;

		private bool hasMedicineInStorage;

		public SelfTendWoundsGoal(Agent selfAgent)
			: base("SelfTendWoundsGoal", selfAgent)
		{
			AddInitStep(new ThreadSequenceStep(CheckIfHasMedicine, PrepareData));
		}

		public override bool CanStart(bool isForced = false)
		{
			humanoid = (HumanoidInstance)base.AgentOwner;
			if (humanoid.WorkerBehaviour.IsAllowedSelfTending && humanoid.HasUntendendWounds())
			{
				return humanoid.WorkerBehaviour.IsJobActive(JobType.TendWounds);
			}
			return false;
		}

		public override bool AgentTypeCheck()
		{
			if (base.AgentOwner is HumanoidInstance humanoidInstance)
			{
				return humanoidInstance.WorkerBehaviour != null;
			}
			return false;
		}

		public override void EndGoalWith(GoalCondition condition)
		{
			if (humanoid != null)
			{
				humanoid.IsReceivingWoundTreatman = false;
				humanoid.CanReceiveWoundTreatment = false;
			}
			base.EndGoalWith(condition);
		}

		protected override IEnumerable<GoapAction> GetNextAction()
		{
			humanoid.IsReceivingWoundTreatman = true;
			GoapAction treatWounds = TendWoundsGoal.TreatWounds(humanoid, humanoid);
			yield return JumpActions.JumpIfNoTargetSelected(treatWounds, TargetIndex.B);
			yield return GoToActions.GoToTarget(TargetIndex.B, PathCompleteMode.Touch).FailIfTargetDisposedForbidenOrNull(TargetIndex.B);
			yield return ResourceActions.PickupResourceFromPile(TargetIndex.B, 1).FailIfTargetDisposedForbidenOrNull(TargetIndex.B);
			if (hasMedicineInStorage)
			{
				ResourceInstance resourceInstance = humanoid.MedicineStorage.Resources.FirstOrDefault();
				if (resourceInstance != null)
				{
					humanoid.Storage.Add(resourceInstance);
					humanoid.MedicineStorage.DeleteResource(resourceInstance);
				}
			}
			treatWounds.OnInit = delegate
			{
				humanoid.CanReceiveWoundTreatment = true;
			};
			yield return treatWounds;
			GoapAction goapAction = new GoapAction("ApplyWoundTreatment");
			goapAction.OnInit = delegate
			{
				Resource resource = (humanoid.Storage.IsEmpty() ? null : humanoid.Storage.FirstResource.Blueprint);
				TendWoundsGoal.ApplyWoundTreatment(humanoid, humanoid, resource, 0.25f);
				if (resource != null)
				{
					humanoid.DestroyStorage();
				}
			};
			goapAction.OnComplete = delegate(ActionCompletionStatus status)
			{
				if (status == ActionCompletionStatus.Success)
				{
					TendWoundsGoal.RewardMedicalExperience(humanoid, humanoid, 0.8f);
				}
				humanoid.IsReceivingWoundTreatman = false;
				humanoid.CanReceiveWoundTreatment = false;
			};
			yield return goapAction;
		}

		private bool PrepareData()
		{
			SetTarget(TargetIndex.A, new TargetObject(humanoid));
			FindAndTargetMedicine();
			return true;
		}

		private bool CheckIfHasMedicine()
		{
			HumanoidInstance humanoidInstance = (HumanoidInstance)base.AgentOwner;
			hasMedicineInStorage = !humanoidInstance.MedicineStorage.IsEmpty();
			return true;
		}

		private void FindAndTargetMedicine()
		{
			if (!hasMedicineInStorage)
			{
				ResourcePileInstance resourcePileInstance = CommonGoalMethods.FindMedicine(humanoid, humanoid.GetGridPosition());
				if (MonoSingleton<ReservationManager>.Instance.TryReserveObject(resourcePileInstance, base.AgentOwner))
				{
					SetTarget(TargetIndex.B, new TargetObject(resourcePileInstance));
				}
			}
		}
	}
}
