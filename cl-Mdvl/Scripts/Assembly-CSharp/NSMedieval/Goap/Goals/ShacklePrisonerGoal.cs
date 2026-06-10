using System.Collections.Generic;
using FoxyVoxel.Logging;
using NSEipix.Base;
using NSMedieval.Goap.Actions;
using NSMedieval.Manager;
using NSMedieval.Model;
using NSMedieval.Pathfinding;
using NSMedieval.State;
using NSMedieval.Types;
using NSMedieval.Village;
using NSMedieval.Village.Map;
using NSMedieval.Village.Map.Pathfinding;

namespace NSMedieval.Goap.Goals
{
	public class ShacklePrisonerGoal : Goal
	{
		private CaptiveNpcBehaviour targetPrisoner;

		private bool shackleStateToSet;

		public ShacklePrisonerGoal(Agent selfAgent)
			: base("ShacklePrisonerGoal", selfAgent)
		{
			AddInitStep(base.PreferredReservableHandler.GetInitSequenceStep<HumanoidInstance>());
			AddInitStep(new ThreadSequenceStep(null, FindPathToPrisoner, ReservePrisoners));
			AddInitStep(new ThreadSequenceStep(null, FindPathToShackles, ReserveShackles));
		}

		public override bool CanStart(bool isForced = false)
		{
			if (MonoSingleton<ReservationManager>.Instance.GetPreferedReservable(base.AgentOwner as HumanoidInstance) is HumanoidInstance)
			{
				return true;
			}
			if (MonoSingleton<CaptiveNpcManager>.IsInstantiated())
			{
				return MonoSingleton<CaptiveNpcManager>.Instance.HasCaptivesWithShackleOrder();
			}
			return false;
		}

		public override bool AgentTypeCheck()
		{
			return base.AgentOwner is HumanoidInstance;
		}

		public override void EndGoalWith(GoalCondition condition)
		{
			base.EndGoalWith(condition);
			if (base.AgentOwner is HumanoidInstance humanoidInstance)
			{
				humanoidInstance.HideTool();
			}
			targetPrisoner?.GoapAgent.StartTicker();
		}

		protected override IEnumerable<GoapAction> GetNextAction()
		{
			if (shackleStateToSet)
			{
				yield return GoToActions.GoToTarget(TargetIndex.B, PathCompleteMode.ExactPosition).FailIfTargetDisposedForbidenOrNull(TargetIndex.B).FailIfTargetReservationReleases(TargetIndex.B)
					.FailAtCondition(FailWhenConditionsChange);
				yield return GeneralActions.Instant("Trigger pickup pile anim").TriggerAnimation("PickUpPile", ActionAnimationMode.WaitForCompletion).SkipIfTargetDisposedForbiddenOrNull(TargetIndex.B, checkForbidden: false)
					.SkipIfTargetReservationReleases(TargetIndex.B);
				yield return ResourceActions.PickupResourceFromPile(TargetIndex.B, (Resource blueprint) => 1, delegate
				{
				}, onlySameResourceType: false).SkipIfTargetDisposedForbiddenOrNull(TargetIndex.B, checkForbidden: false);
			}
			yield return GoToActions.GoToCreatureTarget(TargetIndex.A).FailIfTargetDisposedForbidenOrNull(TargetIndex.A).FailIfTargetReservationReleases(TargetIndex.A)
				.FailAtCondition(FailWhenConditionsChange);
			targetPrisoner = GetTarget(TargetIndex.A).GetObjectAs<HumanoidInstance>().CaptiveNpcBehaviour;
			GoapAction shackleAction = new GoapAction("ShackleAction")
			{
				CompleteMode = ActionCompleteMode.Delay
			}.FailAtCondition(FailWhenConditionsChange);
			shackleAction.OnInit = delegate
			{
				targetPrisoner.GoapAgent.StopTicker();
				targetPrisoner.Humanoid.PathDriver.Abort();
				shackleAction.CompleteAfterTimeExpires(3f);
				shackleAction.TriggerAnimation("Producing", ActionAnimationMode.Interrupt);
			};
			shackleAction.OnTick = delegate
			{
				((HumanoidInstance)base.AgentOwner).ActiveBehaviour.FaceObject(targetPrisoner.Humanoid.GetPosition());
			};
			shackleAction.OnComplete = delegate
			{
				if (targetPrisoner.Shackled)
				{
					targetPrisoner.Humanoid.Inventory.DropItemFromEquipmentSlot(EquipmentSlotType.LeftHand);
					targetPrisoner.ShacklePrisoner(isShackled: false);
				}
				else
				{
					IStorageAgent storageAgent = (IStorageAgent)base.AgentOwner;
					ResourceInstance singleResource = storageAgent.Storage.GetSingleResource();
					if (singleResource == null || singleResource.HasDisposed)
					{
						Log.Error("Target is not a resource!", "C:\\GIT\\dev\\Assets\\Scripts\\GOAP\\Goal\\ShacklePrisonerGoal.cs");
					}
					else
					{
						EquipmentInstance equipmentInstance = new EquipmentInstance(singleResource.BlueprintId, isManuallyEquiped: true);
						equipmentInstance.CloneStatsCurrent(singleResource.Stats);
						equipmentInstance.SetProducerUniqueId(singleResource.ProducerUniqueId);
						targetPrisoner.Humanoid.Inventory.Equip(equipmentInstance);
						storageAgent.Storage.Take(singleResource);
						targetPrisoner.ShacklePrisoner(isShackled: true);
					}
				}
			};
			yield return shackleAction;
		}

		private bool FindPathToShackles()
		{
			if (!shackleStateToSet)
			{
				return true;
			}
			HumanoidInstance human = base.AgentOwner as HumanoidInstance;
			if (human == null || human.HasDisposed)
			{
				return false;
			}
			List<TargetObject> list = PathfinderResourcePile.FindPiles(human, (ResourcePileInstance pile) => pile != null && pile.Blueprint?.ProtoId != null && pile.Blueprint.ProtoId.Equals("shackles") && PathfinderUtil.IsPathPossible(human, pile));
			if (list == null || list.Count == 0)
			{
				return false;
			}
			Vec3Int referencePosition = GetTarget(TargetIndex.A).ReachablePosition;
			list.Sort((TargetObject a, TargetObject b) => Vec3Int.DistanceSquared(a.ReachablePosition, in referencePosition) - Vec3Int.DistanceSquared(b.ReachablePosition, in referencePosition));
			QueueTargets(TargetIndex.B, list);
			return true;
		}

		private bool ReserveShackles()
		{
			if (!shackleStateToSet)
			{
				return true;
			}
			while (SelectNextTarget(TargetIndex.B))
			{
				WorldObject objectAs = GetTarget(TargetIndex.B).GetObjectAs<WorldObject>();
				if (objectAs != null && !objectAs.HasDisposed && MonoSingleton<ReservationManager>.Instance.TryReserveObject(objectAs, base.AgentOwner))
				{
					ClearTargetsQueue(TargetIndex.B);
					QueueTarget(TargetIndex.B, new TargetObject(objectAs));
					return ReserveAndSelectFirstTargetFromQueue(TargetIndex.B);
				}
			}
			return false;
		}

		private bool FindPathToPrisoner()
		{
			if (base.PreferredReservableHandler.HasTarget())
			{
				TargetObject target = base.PreferredReservableHandler.GetTarget();
				if (MonoSingleton<ReservationManager>.Instance.TryReserveObject(target.GetAsReservable(), base.AgentOwner))
				{
					QueueTarget(TargetIndex.A, target);
					return true;
				}
			}
			List<TargetObject> list = PathfinderTargetable.FindObjects((IPathfindingAgent)base.AgentOwner, MonoSingleton<CaptiveNpcManager>.Instance.CaptivesHumanoids, MonoSingleton<CaptiveNpcManager>.Instance.CaptivesCount, delegate(HumanoidInstance x)
			{
				CaptiveNpcBehaviour captiveNpcBehaviour = x.CaptiveNpcBehaviour;
				return captiveNpcBehaviour.MarkedForShackling || captiveNpcBehaviour.MarkedForUnShackling;
			});
			if (list == null || list.Count == 0)
			{
				return false;
			}
			QueueTargets(TargetIndex.A, list);
			return true;
		}

		private bool ReservePrisoners()
		{
			while (SelectNextTarget(TargetIndex.A))
			{
				CaptiveNpcBehaviour captiveNpcBehaviour = GetTarget(TargetIndex.A).GetObjectAs<HumanoidInstance>().CaptiveNpcBehaviour;
				if (captiveNpcBehaviour != null && MonoSingleton<ReservationManager>.Instance.TryReserveObject(captiveNpcBehaviour.Humanoid, base.AgentOwner))
				{
					if (captiveNpcBehaviour.MarkedForShackling)
					{
						shackleStateToSet = true;
					}
					else if (captiveNpcBehaviour.MarkedForUnShackling)
					{
						shackleStateToSet = false;
					}
					else
					{
						shackleStateToSet = !captiveNpcBehaviour.Shackled;
					}
					ClearTargetsQueue(TargetIndex.A);
					QueueTarget(TargetIndex.A, new TargetObject(captiveNpcBehaviour.Humanoid));
					return ReserveAndSelectFirstTargetFromQueue(TargetIndex.A);
				}
			}
			return false;
		}

		private bool FailWhenConditionsChange()
		{
			CaptiveNpcBehaviour captiveNpcBehaviour = GetTarget(TargetIndex.A).GetObjectAs<HumanoidInstance>()?.CaptiveNpcBehaviour;
			if (captiveNpcBehaviour == null || captiveNpcBehaviour.Humanoid.HasDisposed)
			{
				return true;
			}
			if (captiveNpcBehaviour.Shackled == shackleStateToSet)
			{
				return true;
			}
			if (!captiveNpcBehaviour.MarkedForShackling && !captiveNpcBehaviour.MarkedForUnShackling)
			{
				return true;
			}
			if (captiveNpcBehaviour.MarkedForShackling && !shackleStateToSet)
			{
				return true;
			}
			if (captiveNpcBehaviour.MarkedForUnShackling && shackleStateToSet)
			{
				return true;
			}
			if (captiveNpcBehaviour.Humanoid.GetNode().Tag.HasFlag(MapNodeTags.Ladder))
			{
				return true;
			}
			return MonoSingleton<CombatTargetManager>.Instance.CountPreferedAttackers(captiveNpcBehaviour.Humanoid) > 0;
		}
	}
}
