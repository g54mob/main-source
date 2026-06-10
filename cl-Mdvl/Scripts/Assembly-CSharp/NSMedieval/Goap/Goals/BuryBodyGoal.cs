using System.Collections.Generic;
using NSEipix.Base;
using NSMedieval.BuildingComponents;
using NSMedieval.Goap.Actions;
using NSMedieval.Manager;
using NSMedieval.Pathfinding;
using NSMedieval.State;
using NSMedieval.Types;
using NSMedieval.Village;

namespace NSMedieval.Goap.Goals
{
	public class BuryBodyGoal : Goal
	{
		private GraveComponentManager graveComponentManager;

		public BuryBodyGoal(Agent selfAgent)
			: base("BuryBodyGoal", selfAgent)
		{
			graveComponentManager = VillageManager.ActiveVillage.Map.GraveComponentManager;
			AddInitStep(base.PreferredReservableHandler.GetInitSequenceStep<HumanCarcassPileInstance>());
			AddInitStep(new ThreadSequenceStep(null, PrepareData, ReserveTargets));
		}

		public override bool AgentTypeCheck()
		{
			return base.AgentOwner is IStorageAgent;
		}

		public override bool CanStart(bool isForced = false)
		{
			if (graveComponentManager == null || !MonoSingleton<ResourcePileTracker>.IsInstantiated())
			{
				return false;
			}
			bool num = graveComponentManager.AvailableGravesExist();
			int allowedCount = MonoSingleton<ResourcePileTracker>.Instance.GetCount(ResourceCategory.CtgCarcass).AllowedCount;
			if (num)
			{
				return allowedCount > 0;
			}
			return false;
		}

		protected override IEnumerable<GoapAction> GetNextAction()
		{
			yield return GoToActions.GoToTarget(TargetIndex.A, PathCompleteMode.ExactPosition).FailIfTargetDisposedForbidenOrNull(TargetIndex.A).FailIfTargetDisposed(TargetIndex.B)
				.FailIfResourcePileHasNoResources(TargetIndex.A)
				.FailAtCondition(FailAtCondition)
				.FailAtCondition(FailIfCarcassIsMarkedForStripping)
				.FailAtCondition(FailWhenGraveFilterChangesBeforeCarcassPickup);
			yield return ResourceActions.PickupResourceFromPile(TargetIndex.A, 1).FailIfTargetDisposedForbidenOrNull(TargetIndex.A).FailAtCondition(FailWhenGraveFilterChangesBeforeCarcassPickup);
			yield return GoToActions.GoToTarget(TargetIndex.B, PathCompleteMode.ExactPosition).FailIfTargetDisposedForbidenOrNull(TargetIndex.B).FailIfTargetReservationReleases(TargetIndex.B)
				.FailAtCondition(FailAtCondition)
				.FailAtCondition(FailWhenGraveFilterChangesAfterCarcassPickup);
			yield return GeneralActions.Instant().TriggerAnimation("DropPile", ActionAnimationMode.WaitForCompletion).FailIfTargetReservationReleases(TargetIndex.B)
				.FailAtCondition(FailAtCondition)
				.FailAtCondition(FailWhenGraveFilterChangesAfterCarcassPickup);
			yield return ResourceActions.PlaceBodyInsideAGrave(TargetIndex.B).FailIfTargetDisposedForbidenOrNull(TargetIndex.B).FailIfTargetReservationReleases(TargetIndex.B)
				.FailAtCondition(FailAtCondition)
				.FailAtCondition(FailWhenGraveFilterChangesAfterCarcassPickup);
		}

		private bool PrepareData()
		{
			IPathfindingAgent pathfindingAgent = (IPathfindingAgent)base.AgentOwner;
			List<TargetObject> list;
			if (base.PreferredReservableHandler.HasTarget())
			{
				list = new List<TargetObject> { base.PreferredReservableHandler.GetTarget() };
			}
			else
			{
				list = PathfinderResourcePile.FindHumanCarcasses(pathfindingAgent, (ResourcePileInstance body) => !body.IsForbidden && !body.IsOnFire);
				if (list == null || list.Count == 0)
				{
					return true;
				}
			}
			QueueTargets(TargetIndex.A, list);
			List<WorldObject> graveBuildingsPathfinding = graveComponentManager.GetGraveBuildingsPathfinding((GraveComponentInstance x) => x.HasFreeSpace() && !x.Underwater && !x.IsOnFire && x.OwnedByPlayer);
			List<TargetObject> list2 = PathfinderMedieval.FindMedievalObjects<BaseBuildingInstance>(pathfindingAgent, graveBuildingsPathfinding);
			if (list2 == null || list2.Count <= 0)
			{
				return false;
			}
			List<TargetObject> list3 = new List<TargetObject>();
			foreach (TargetObject item in list2)
			{
				WorldObject objectAs = item.GetObjectAs<WorldObject>();
				if (objectAs == null || objectAs.HasDisposed)
				{
					continue;
				}
				GraveComponentInstance componentInstance = graveComponentManager.GetComponentInstance(objectAs);
				if (componentInstance == null || componentInstance.HasDisposed)
				{
					continue;
				}
				foreach (TargetObject item2 in list)
				{
					HumanCarcassPileInstance objectAs2 = item2.GetObjectAs<HumanCarcassPileInstance>();
					if (objectAs2 != null && !objectAs2.MarkedForStripping && componentInstance.CanStore(objectAs2.GetStoredCarcass()))
					{
						list3.Add(new TargetObject(componentInstance, item.ReachablePosition));
					}
				}
			}
			QueueTargets(TargetIndex.B, list3);
			return true;
		}

		private bool ReserveTargets()
		{
			while (SelectNextTarget(TargetIndex.B))
			{
				TargetObject target = GetTarget(TargetIndex.B);
				if (!MonoSingleton<ReservationManager>.Instance.CanReserve(target.GetAsReservable(), base.AgentOwner))
				{
					continue;
				}
				while (SelectNextTarget(TargetIndex.A))
				{
					TargetObject target2 = GetTarget(TargetIndex.A);
					if (!MonoSingleton<ReservationManager>.Instance.CanReserve(target2.GetAsReservable(), base.AgentOwner))
					{
						continue;
					}
					HumanCarcassPileInstance objectAs = target2.GetObjectAs<HumanCarcassPileInstance>();
					if (target.GetObjectAs<GraveComponentInstance>().CanStore(objectAs.GetStoredCarcass()))
					{
						ClearTargetsQueue(TargetIndex.A);
						ClearTargetsQueue(TargetIndex.B);
						QueueTarget(TargetIndex.A, target2);
						QueueTarget(TargetIndex.B, target);
						if (ReserveAndSelectFirstTargetFromQueue(TargetIndex.A))
						{
							return ReserveAndSelectFirstTargetFromQueue(TargetIndex.B);
						}
						return false;
					}
				}
			}
			return false;
		}

		private bool FailAtCondition()
		{
			GraveComponentInstance objectAs = GetTarget(TargetIndex.B).GetObjectAs<GraveComponentInstance>();
			if (objectAs != null && !objectAs.HasDisposed && !objectAs.Underwater)
			{
				return objectAs.IsOnFire;
			}
			return true;
		}

		private bool FailWhenGraveFilterChangesBeforeCarcassPickup()
		{
			CarcassResourceInstance carcassResourceInstance = GetTarget(TargetIndex.A).GetObjectAs<HumanCarcassPileInstance>()?.GetStoredCarcass();
			if (carcassResourceInstance == null)
			{
				return true;
			}
			return !GetTarget(TargetIndex.B).GetObjectAs<GraveComponentInstance>().CanStore(carcassResourceInstance);
		}

		private bool FailWhenGraveFilterChangesAfterCarcassPickup()
		{
			if (!(((HumanoidInstance)base.AgentOwner).Storage.GetSingleResource() is CarcassResourceInstance carcassResourceInstance))
			{
				return true;
			}
			return !GetTarget(TargetIndex.B).GetObjectAs<GraveComponentInstance>().CanStore(carcassResourceInstance);
		}

		private bool FailIfCarcassIsMarkedForStripping()
		{
			if (GetTarget(TargetIndex.A).GetObjectAs<ResourcePileInstance>() is HumanCarcassPileInstance humanCarcassPileInstance)
			{
				return humanCarcassPileInstance.MarkedForStripping;
			}
			return false;
		}
	}
}
