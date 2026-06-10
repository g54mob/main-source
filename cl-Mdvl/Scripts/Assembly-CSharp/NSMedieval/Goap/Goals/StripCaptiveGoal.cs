using System.Collections.Generic;
using FoxyVoxel.Logging;
using NSEipix.Base;
using NSMedieval.Goap.Actions;
using NSMedieval.Manager;
using NSMedieval.Pathfinding;
using NSMedieval.State;
using NSMedieval.Types;

namespace NSMedieval.Goap.Goals
{
	public class StripCaptiveGoal : Goal
	{
		private const float MaximumRopingRange = 6f;

		private readonly List<HumanoidInstance> prisoners;

		private CaptiveNpcBehaviour captiveToStrip;

		public StripCaptiveGoal(Agent selfAgent)
			: base("StripCaptiveGoal", selfAgent)
		{
			prisoners = new List<HumanoidInstance>();
			AddInitStep(base.PreferredReservableHandler.GetInitSequenceStep<HumanoidInstance>());
			AddInitStep(new ThreadSequenceStep(null, FindClosestPrisoner));
		}

		public override void EndGoalWith(GoalCondition condition)
		{
			captiveToStrip?.GoapAgent.StartTicker();
			base.EndGoalWith(condition);
		}

		private bool FindClosestPrisoner()
		{
			if (base.PreferredReservableHandler.HasTarget())
			{
				TargetObject target = base.PreferredReservableHandler.GetTarget();
				HumanoidInstance objectAs = target.GetObjectAs<HumanoidInstance>();
				if (objectAs != null && objectAs.IsCaptive() && CheckCanStripPrisoner(objectAs))
				{
					QueueTarget(TargetIndex.A, target);
					if (ReserveAndSelectFirstTargetFromQueue(TargetIndex.A))
					{
						captiveToStrip = objectAs.CaptiveNpcBehaviour;
						return true;
					}
					Log.Warning("Haven't been able to reserve and select Preferred Target for StripCaptiveGoal, clearing targets and cancelling goal", "C:\\GIT\\dev\\Assets\\Scripts\\GOAP\\Goal\\StripCaptiveGoal.cs");
					return false;
				}
			}
			List<TargetObject> targets = PathfinderTargetable.FindObjects((IPathfindingAgent)base.AgentOwner, prisoners, -1, CheckCanStripPrisoner);
			QueueTargets(TargetIndex.A, targets);
			if (!ReserveAndSelectFirstTargetFromQueue(TargetIndex.A))
			{
				return false;
			}
			CaptiveNpcBehaviour captiveNpcBehaviour = GetTarget(TargetIndex.A).GetObjectAs<HumanoidInstance>().CaptiveNpcBehaviour;
			if (captiveNpcBehaviour == null)
			{
				return false;
			}
			captiveToStrip = captiveNpcBehaviour;
			return true;
		}

		private bool CheckCanStripPrisoner(HumanoidInstance possiblePrisoner)
		{
			if (possiblePrisoner.HasDisposed || !possiblePrisoner.IsCaptive() || possiblePrisoner.HasFainted)
			{
				return false;
			}
			return possiblePrisoner.CaptiveNpcBehaviour.MarkedForStripping;
		}

		public override bool CanStart(bool isForced = false)
		{
			prisoners.Clear();
			prisoners.AddRange(MonoSingleton<NPCManager>.Instance.IterateNPCs(CheckCanStripPrisoner));
			return prisoners.Count != 0;
		}

		public override bool AgentTypeCheck()
		{
			return base.AgentOwner is CreatureBase;
		}

		protected override IEnumerable<GoapAction> GetNextAction()
		{
			yield return GoToActions.GoToCreatureTarget(TargetIndex.A).FailIfTargetDisposedForbidenOrNull(TargetIndex.A).FailIfTargetReservationReleases(TargetIndex.A)
				.FailAtCondition(() => !captiveToStrip.MarkedForStripping);
			GoapAction goapAction = new GoapAction("StopPrisonerTicker");
			goapAction.OnInit = delegate
			{
				(base.AgentOwner as HumanoidInstance)?.FaceObject(captiveToStrip.Humanoid.GetTransform());
				captiveToStrip.GoapAgent.Abort();
				captiveToStrip.GoapAgent.StopTicker();
			};
			yield return goapAction;
			yield return GeneralActions.Wait(5f).TriggerAnimation("Producing", ActionAnimationMode.Ignore);
			GoapAction goapAction2 = new GoapAction("StripPrisoner");
			goapAction2.OnInit = delegate
			{
				InventoryInstance inventory = captiveToStrip.Humanoid.Inventory;
				inventory.DropItemFromEquipmentSlot(EquipmentSlotType.RightHand, forbidDroppedItem: true);
				inventory.DropItemFromEquipmentSlot(EquipmentSlotType.Head, forbidDroppedItem: true);
				inventory.DropItemFromEquipmentSlot(EquipmentSlotType.BodyArmor, forbidDroppedItem: true);
				inventory.DropItemFromEquipmentSlot(EquipmentSlotType.Body, forbidDroppedItem: true);
				EquipmentInstance item = inventory.GetItem(EquipmentSlotType.LeftHand);
				if (item != null && item.Blueprint.Resource.GroupIdentifier != "shackles")
				{
					inventory.DropItemFromEquipmentSlot(EquipmentSlotType.LeftHand, forbidDroppedItem: true);
				}
				captiveToStrip.MarkForStripping(mark: false);
			};
			yield return goapAction2;
		}
	}
}
