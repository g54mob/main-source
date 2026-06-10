using System.Collections.Generic;
using System.Linq;
using FoxyVoxel.Logging;
using FoxyVoxel.Logging.Core.LogMessageInterpolationHandlers;
using NSEipix;
using NSEipix.Base;
using NSMedieval.BuildingComponents;
using NSMedieval.Controllers;
using NSMedieval.Goap.Actions;
using NSMedieval.Manager;
using NSMedieval.MovableBuildings;
using NSMedieval.Pathfinding;
using NSMedieval.State;
using NSMedieval.Types;
using NSMedieval.UI.Utils;
using NSMedieval.Utils.Pool.Janitors;
using NSMedieval.Village;
using NSMedieval.Village.Map.Pathfinding;
using NSMedieval.Water;
using UnityEngine;

namespace NSMedieval.Goap.Goals
{
	public abstract class HaulingBaseGoal : Goal
	{
		private const float MultiPickupDistanceLimit = 9f;

		protected int PickedCount;

		protected int TotalTargetedCount;

		protected int MaxCaryAmount;

		private readonly HashSet<IStorage> reservedStorages = new HashSet<IStorage>();

		protected readonly FVLogger logger;

		private string HaulEndEffectorName
		{
			get
			{
				if (base.AgentOwner is IHaulAgent haulAgent)
				{
					return haulAgent.HaulEndEffectorName;
				}
				return string.Empty;
			}
		}

		private float HaulEndEffectorDuration
		{
			get
			{
				if (base.AgentOwner is IHaulAgent haulAgent)
				{
					return haulAgent.HaulEndEffectorDuration;
				}
				return 1f;
			}
		}

		private bool ShouldFireHaulEndEffector
		{
			get
			{
				if (base.AgentOwner is IHaulAgent haulAgent)
				{
					return haulAgent.ShouldFireHaulEndEffector;
				}
				return true;
			}
		}

		protected HaulingBaseGoal(string id, Agent selfAgent)
			: base(id, selfAgent)
		{
			logger = FVLogger.New(id);
		}

		public override void Dispose()
		{
			base.Dispose();
			reservedStorages.Clear();
		}

		protected abstract bool ValidatePile(ResourcePileInstance pile);

		protected abstract bool FindAndProcessTargets();

		protected abstract bool HasAnywhereToStore();

		public override bool AgentTypeCheck()
		{
			if (base.AgentOwner is IStorageAgent)
			{
				return base.AgentOwner is IHaulAgent;
			}
			return false;
		}

		public override bool CanStart(bool isForced = false)
		{
			if (CanAgentHaul())
			{
				return VillageManager.ActiveVillage.Map.GetObjectCount(GridDataType.ResourcePile) > 0;
			}
			return false;
		}

		public override void EndGoalWith(GoalCondition condition)
		{
			if (base.PreferredReservableHandler != null && base.PreferredReservableHandler.HasTarget())
			{
				base.PreferredReservableHandler.ClearTarget();
			}
			ReleaseStorageReservations();
			MonoSingleton<ResourcePileHaulingManager>.Instance.TriggerLazyReProcessAll();
			base.EndGoalWith(condition);
		}

		public override void HandleConsecutiveFail()
		{
			if (!GetTarget(TargetIndex.A).IsInitialized)
			{
				return;
			}
			ResourcePileInstance objectAs = GetTarget(TargetIndex.A).GetObjectAs<ResourcePileInstance>();
			if (objectAs != null)
			{
				if (objectAs.InstanceStorage == null)
				{
					objectAs.IsForbidden = true;
					string localizedResourcePileName = ResourceUtils.GetLocalizedResourcePileName(objectAs.Blueprint.GetID());
					string messageText = MonoSingleton<LocalizationController>.Instance.GetText("error_autoforbid_message").Replace("<object>", localizedResourcePileName);
					MonoSingleton<BlackBarMessageController>.Instance.ShowClickableBlackBarMessage(messageText, objectAs.WorldPosition);
				}
				else if (objectAs.InstanceStorage.GetOwner is ShelfComponentInstance shelfComponentInstance)
				{
					shelfComponentInstance.SetForbidden(isForbidden: true);
				}
			}
		}

		internal override void ClearTargets(bool extraSafety = false)
		{
			ReleaseStorageReservations();
			base.ClearTargets(extraSafety);
		}

		protected virtual int GetMaxPickupAmount()
		{
			return 0;
		}

		protected virtual bool ShouldConsiderPile(ResourcePileInstance pileInstance)
		{
			return pileInstance.OwnedByPlayer();
		}

		protected override IEnumerable<GoapAction> GetNextAction()
		{
			GoapAction selectNextResourceTarget = GoalUtilActions.SelectNextTargetFromQueue(TargetIndex.A);
			GoapAction jumpToSelectResourceIfHaveTargetsLeft = JumpActions.JumpIfHaveTargetsInQueue(selectNextResourceTarget, TargetIndex.A).SkipIfCondition(() => PickedCount >= MaxCaryAmount);
			yield return selectNextResourceTarget;
			yield return GoToActions.GoToTargetNoFailCheck(TargetIndex.A, PathCompleteMode.ExactPosition).JumpIfTargetDisposedForbiddenOrNull(jumpToSelectResourceIfHaveTargetsLeft, TargetIndex.A).JumpIf(jumpToSelectResourceIfHaveTargetsLeft, () => PickedCount > 0 && !HasAnywhereToStore())
				.FailAtCondition(() => PickedCount <= 0 && !HasAnywhereToStore())
				.FailAtCondition(FailHaulIfPilePlacementActive)
				.FailAtCondition(FailHaulIfCarcassIsMarkedForStripping)
				.OnGridSpaceChangedEvent(delegate
				{
					InjectPilesInProximityRange(selectNextResourceTarget);
				});
			GoapAction goapAction = ResourceActions.PickupResourceFromPile(TargetIndex.A, GetMaxPickupAmount()).JumpIfTargetDisposedForbiddenOrNull(jumpToSelectResourceIfHaveTargetsLeft, TargetIndex.A).FailAtCondition(() => !HasAnywhereToStore())
				.FailAtCondition(FailHaulIfPilePlacementActive)
				.FailAtCondition(FailHaulIfCarcassIsMarkedForStripping)
				.SkipIfCondition(() => PickedCount >= MaxCaryAmount);
			goapAction.OnComplete = delegate(ActionCompletionStatus status)
			{
				if (status == ActionCompletionStatus.Success && base.AgentOwner != null)
				{
					IStorageAgent storageAgent = (IStorageAgent)base.AgentOwner;
					PickedCount = (storageAgent.Storage?.GetSingleResource()?.Amount).GetValueOrDefault();
					TargetObject target = GetTarget(TargetIndex.A);
					if (target.ObjectInstance != null && !target.ObjectInstance.HasDisposed)
					{
						MonoSingleton<ReservationManager>.Instance.ReleaseObject(target.GetAsReservable(), base.AgentOwner);
					}
				}
			};
			yield return goapAction;
			yield return jumpToSelectResourceIfHaveTargetsLeft;
			GoapAction doneJumpPoint = GeneralActions.Instant("ExitJumpPoint");
			GoapAction selectNextTarget = GoalUtilActions.SelectNextTargetFromQueue(TargetIndex.B);
			GoapAction reserveAndQueueStorageSpaces = StorageActions.ReserveAndQueueStoragePlaces(TargetIndex.B, TargetIndex.B, delegate(IStorage storage, Vec3Int i)
			{
				reservedStorages.Add(storage);
			});
			reserveAndQueueStorageSpaces.OnPreInit = ReleaseStorageReservations;
			GoapAction findBestStorage = StorageActions.FindBestStorage(TargetIndex.B);
			GoapAction selectGoToTarget = GoalUtilActions.SelectNextTargetFromQueue(TargetIndex.B);
			GoapAction goToStorage = GoToActions.GoToTarget(TargetIndex.B, PathCompleteMode.ExactPosition).SkipIfTargetDisposedForbidenOrNull(TargetIndex.B).FailAtCondition(() => CheckAnimalHauling() || ResourceFilterAbort(useWorkerStorage: true) || FailIfPileUnderWaterOrOnFire())
				.JumpOnCompletionIfHaveTargetsInQueue(selectGoToTarget, TargetIndex.B, ActionCompletionStatus.Jump)
				.JumpOnCompletionIfHaveNoTargetsInQueue(findBestStorage, TargetIndex.B, ActionCompletionStatus.Jump)
				.FailAtCondition(() => ((CreatureBase)base.AgentOwner).Storage.IsEmpty() || FailIfStorageUnderWaterOrOnFire());
			goToStorage.OnComplete = delegate(ActionCompletionStatus status)
			{
				if (status != ActionCompletionStatus.Success && base.AgentOwner != null)
				{
					CreatureBase creatureBase = (CreatureBase)base.AgentOwner;
					if (!creatureBase.HasDisposed && creatureBase.Storage != null && !creatureBase.Storage.IsEmpty())
					{
						ClearTargetsQueue(TargetIndex.B);
					}
				}
			};
			GoapAction storeResource = ResourceActions.StoreResourceOnStockpile(TargetIndex.B).SkipIfTargetDisposedForbidenOrNull(TargetIndex.B);
			if (ShouldFireHaulEndEffector)
			{
				storeResource.FireEffectorOnCompletion(HaulEndEffectorName, ActionCompletionStatus.Success, HaulEndEffectorDuration);
			}
			yield return StorageActions.CompleteIfOwnerStorageIsEmpty();
			yield return JumpActions.JumpIfNoTargetsInQueue(findBestStorage, TargetIndex.B);
			yield return selectNextTarget;
			yield return reserveAndQueueStorageSpaces.JumpOnCompletionIfNotStatus(findBestStorage, ActionCompletionStatus.Success).JumpOnCompletion(selectGoToTarget, ActionCompletionStatus.Success);
			yield return findBestStorage.JumpOnCompletionIfHaveTargetsInQueue(selectNextTarget, TargetIndex.B, ActionCompletionStatus.Success);
			yield return selectGoToTarget;
			yield return goToStorage.JumpOnCompletionIfNotStatus(findBestStorage, ActionCompletionStatus.Success);
			yield return storeResource.SkipOnFailure();
			yield return JumpActions.JumpIfHaveNoResourceInStorage(doneJumpPoint);
			yield return JumpActions.JumpIfHaveTargetsInQueue(selectGoToTarget, TargetIndex.B);
			yield return JumpActions.Jump(findBestStorage);
			yield return doneJumpPoint;
		}

		protected virtual void PickClosestPileToHaul(out ZonePriority minimumStoragePriority, out ResourcePileInstance targetPile)
		{
			ResourcePileHaulingManager instance = MonoSingleton<ResourcePileHaulingManager>.Instance;
			IHaulAgent haulAgent = (IHaulAgent)base.AgentOwner;
			IPathfindingAgent t = (IPathfindingAgent)base.AgentOwner;
			targetPile = null;
			minimumStoragePriority = ZonePriority.None;
			using PooledList<ResourcePileInstance> pooledList = instance.CanBeStored.ToPooledListJanitor();
			using PooledList<ResourcePileInstance> pooledList2 = instance.PilesToReStore.ToPooledListJanitor();
			FVLogTraceInterpolationHandler messageBuilder = new FVLogTraceInterpolationHandler(47, 1, out var isEnabled, "C:\\GIT\\dev\\Assets\\Scripts\\GOAP\\Goal\\Hauling\\HaulingBaseGoal.cs");
			if (isEnabled)
			{
				messageBuilder.AppendLiteral("PickClosestPileToHaul Start (HaulTargetMode = ");
				messageBuilder.AppendFormatted(haulAgent.HaulTargetMode);
				messageBuilder.AppendLiteral(")");
			}
			Log.Trace(messageBuilder);
			switch (haulAgent.HaulTargetMode)
			{
			case HaulTargetingMode.PrioritiseReLocation:
				targetPile = (ResourcePileInstance)PathfinderUtil.GetClosestReachable(t, pooledList2, (IGoapTargetable o) => ValidatePile((ResourcePileInstance)o), (IGoapTargetable item) => ((ResourcePileInstance)item).Blueprint.HaulPriority);
				if (targetPile != null)
				{
					minimumStoragePriority = targetPile.PlacedOnStorage.Priority;
					messageBuilder = new FVLogTraceInterpolationHandler(48, 1, out isEnabled, "C:\\GIT\\dev\\Assets\\Scripts\\GOAP\\Goal\\Hauling\\HaulingBaseGoal.cs");
					if (isEnabled)
					{
						messageBuilder.AppendLiteral("Picked pile that can be Re-stored, targetPile = ");
						messageBuilder.AppendFormatted(targetPile);
					}
					Log.Trace(messageBuilder);
				}
				if (targetPile == null)
				{
					targetPile = (ResourcePileInstance)PathfinderUtil.GetClosestReachable(t, pooledList, (IGoapTargetable o) => ValidatePile((ResourcePileInstance)o), (IGoapTargetable item) => ((ResourcePileInstance)item).Blueprint.HaulPriority);
				}
				if (targetPile != null)
				{
					messageBuilder = new FVLogTraceInterpolationHandler(45, 1, out isEnabled, "C:\\GIT\\dev\\Assets\\Scripts\\GOAP\\Goal\\Hauling\\HaulingBaseGoal.cs");
					if (isEnabled)
					{
						messageBuilder.AppendLiteral("Picked pile that can be stored, targetPile = ");
						messageBuilder.AppendFormatted(targetPile);
					}
					Log.Trace(messageBuilder);
				}
				break;
			case HaulTargetingMode.PrioritiseStoring:
				targetPile = (ResourcePileInstance)PathfinderUtil.GetClosestReachable(t, pooledList, (IGoapTargetable o) => ValidatePile((ResourcePileInstance)o), (IGoapTargetable item) => ((ResourcePileInstance)item).Blueprint.HaulPriority);
				if (targetPile == null)
				{
					if (targetPile == null)
					{
						targetPile = (ResourcePileInstance)PathfinderUtil.GetClosestReachable(t, pooledList2, (IGoapTargetable o) => ValidatePile((ResourcePileInstance)o), (IGoapTargetable item) => ((ResourcePileInstance)item).Blueprint.HaulPriority);
					}
					if (targetPile != null)
					{
						minimumStoragePriority = targetPile.PlacedOnStorage.Priority;
						messageBuilder = new FVLogTraceInterpolationHandler(48, 1, out isEnabled, "C:\\GIT\\dev\\Assets\\Scripts\\GOAP\\Goal\\Hauling\\HaulingBaseGoal.cs");
						if (isEnabled)
						{
							messageBuilder.AppendLiteral("Picked pile that can be Re-stored, targetPile = ");
							messageBuilder.AppendFormatted(targetPile);
						}
						Log.Trace(messageBuilder);
					}
				}
				else
				{
					messageBuilder = new FVLogTraceInterpolationHandler(45, 1, out isEnabled, "C:\\GIT\\dev\\Assets\\Scripts\\GOAP\\Goal\\Hauling\\HaulingBaseGoal.cs");
					if (isEnabled)
					{
						messageBuilder.AppendLiteral("Picked pile that can be stored, targetPile = ");
						messageBuilder.AppendFormatted(targetPile);
					}
					Log.Trace(messageBuilder);
				}
				break;
			case HaulTargetingMode.TreatAllEqually:
			{
				IEnumerable<IGoapTargetable> searchSet = pooledList.Concat(pooledList2);
				targetPile = (ResourcePileInstance)PathfinderUtil.GetClosestReachable(t, searchSet, (IGoapTargetable o) => ValidatePile((ResourcePileInstance)o), (IGoapTargetable item) => ((ResourcePileInstance)item).Blueprint.HaulPriority);
				if (targetPile != null && instance.IsMarkedForReStoring(targetPile))
				{
					minimumStoragePriority = targetPile.PlacedOnStorage.Priority;
					messageBuilder = new FVLogTraceInterpolationHandler(35, 1, out isEnabled, "C:\\GIT\\dev\\Assets\\Scripts\\GOAP\\Goal\\Hauling\\HaulingBaseGoal.cs");
					if (isEnabled)
					{
						messageBuilder.AppendLiteral("Picked pile marked for re-storing, ");
						messageBuilder.AppendFormatted(targetPile);
					}
					Log.Trace(messageBuilder);
				}
				break;
			}
			default:
			{
				FVLogger fVLogger = logger;
				FVLogWarningInterpolationHandler messageBuilder2 = new FVLogWarningInterpolationHandler(68, 2, out isEnabled, "C:\\GIT\\dev\\Assets\\Scripts\\GOAP\\Goal\\Hauling\\HaulingBaseGoal.cs");
				if (isEnabled)
				{
					messageBuilder2.AppendLiteral("Invalid haul target mode ");
					messageBuilder2.AppendFormatted(haulAgent.HaulTargetMode);
					messageBuilder2.AppendLiteral(" for agent ");
					messageBuilder2.AppendFormatted(t);
					messageBuilder2.AppendLiteral(". Some default picked instead...");
				}
				fVLogger.Warning(in messageBuilder2);
				goto case HaulTargetingMode.TreatAllEqually;
			}
			}
			if (targetPile == null)
			{
				Log.Trace("Pile not found", "C:\\GIT\\dev\\Assets\\Scripts\\GOAP\\Goal\\Hauling\\HaulingBaseGoal.cs");
			}
		}

		private void InjectPilesInProximityRange(GoapAction selectNextResourceTarget)
		{
			if (base.PreferredReservableHandler.HasTarget())
			{
				return;
			}
			IGoapAgentOwner agentOwner = base.AgentOwner;
			CreatureBase creature = agentOwner as CreatureBase;
			if (creature == null)
			{
				return;
			}
			TargetObject target = GetTarget(TargetIndex.A);
			int maximumStorableCount = creature.Storage.GetMaximumStorableCount(target.GetObjectAs<ResourcePileInstance>().Blueprint);
			if (maximumStorableCount <= 0)
			{
				return;
			}
			int num = 0;
			List<TargetObject> targetQueue = GetTargetQueue(TargetIndex.A);
			int count = targetQueue.Count;
			FVLogWarningInterpolationHandler messageBuilder;
			bool isEnabled;
			foreach (WorldObject obj in creature.ProximityObjects)
			{
				if (obj.HasDisposed || !(obj is ResourcePileInstance resourcePileInstance) || target.ObjectInstance == obj || resourcePileInstance.IsOnFire || !ShouldConsiderPile(resourcePileInstance) || !resourcePileInstance.CanBeHauled || resourcePileInstance.IsReserveAll || resourcePileInstance.IsStoredOnStockpile() || resourcePileInstance.Blueprint != target.GetObjectAs<ResourcePileInstance>().Blueprint)
				{
					continue;
				}
				bool flag = false;
				if (targetQueue.Count > 0 && TotalTargetedCount + PickedCount >= MaxCaryAmount && Vec3Int.Distance(targetQueue[targetQueue.Count - 1].ReachablePosition, creature.GetGridPosition()) < Vec3Int.Distance(obj.GridDataPosition, creature.GetGridPosition()))
				{
					flag = true;
				}
				if (targetQueue.Any((TargetObject item) => item.ObjectInstance == obj) || MonoSingleton<ReservationManager>.Instance.GetReserversCount(resourcePileInstance) > 0)
				{
					continue;
				}
				ResourceInstance storedResource = resourcePileInstance.GetStoredResource();
				if (storedResource == null)
				{
					continue;
				}
				resourcePileInstance.ReserveAll();
				if (!MonoSingleton<ReservationManager>.Instance.TryReserveObject(resourcePileInstance, base.AgentOwner))
				{
					FVLogger fVLogger = logger;
					messageBuilder = new FVLogWarningInterpolationHandler(66, 3, out isEnabled, "C:\\GIT\\dev\\Assets\\Scripts\\GOAP\\Goal\\Hauling\\HaulingBaseGoal.cs");
					if (isEnabled)
					{
						messageBuilder.AppendLiteral("Agent ");
						messageBuilder.AppendFormatted(base.AgentOwner);
						messageBuilder.AppendLiteral(" failed to reserve pile ");
						messageBuilder.AppendFormatted(resourcePileInstance.GridDataPosition);
						messageBuilder.AppendLiteral(" during multi-pickup. IsReserveAll: ");
						messageBuilder.AppendFormatted(resourcePileInstance.IsReserveAll);
					}
					fVLogger.Warning(in messageBuilder);
					continue;
				}
				if (flag)
				{
					TargetObject targetObject = targetQueue[targetQueue.Count - 1];
					MonoSingleton<ReservationManager>.Instance.ReleaseAll(targetObject.GetAsReservable());
					targetQueue.RemoveAt(targetQueue.Count - 1);
					ResourceInstance storedResource2 = targetObject.GetObjectAs<ResourcePileInstance>().GetStoredResource();
					if (storedResource2 == null)
					{
						logger.Warning("Should never happen. This is a failsafe. MultiHauling skipped...");
						return;
					}
					TotalTargetedCount -= storedResource2.Count.Amount;
				}
				if (targetQueue.Count > 0)
				{
					targetQueue.Insert(0, new TargetObject(obj));
				}
				else
				{
					targetQueue.Add(new TargetObject(obj));
				}
				num++;
				TotalTargetedCount += Mathf.Min(storedResource.Count.Amount, maximumStorableCount);
				if (TotalTargetedCount + PickedCount > MaxCaryAmount)
				{
					TotalTargetedCount = MaxCaryAmount - PickedCount;
				}
			}
			if (num <= 0)
			{
				return;
			}
			if (num < targetQueue.Count)
			{
				targetQueue.Insert(num, target);
			}
			else
			{
				FVLogger fVLogger2 = logger;
				messageBuilder = new FVLogWarningInterpolationHandler(65, 5, out isEnabled, "C:\\GIT\\dev\\Assets\\Scripts\\GOAP\\Goal\\Hauling\\HaulingBaseGoal.cs");
				if (isEnabled)
				{
					messageBuilder.AppendLiteral("HaulingGoal addedCount (");
					messageBuilder.AppendFormatted(num);
					messageBuilder.AppendLiteral(") < queue.Count(");
					messageBuilder.AppendFormatted(targetQueue.Count);
					messageBuilder.AppendLiteral("). Agent:");
					messageBuilder.AppendFormatted(base.AgentOwner);
					messageBuilder.AppendLiteral(". Target: ");
					messageBuilder.AppendFormatted(target.ObjectInstance);
					messageBuilder.AppendLiteral(", ORS:");
					messageBuilder.AppendFormatted(count);
				}
				fVLogger2.Warning(in messageBuilder);
				targetQueue.Add(target);
			}
			targetQueue.Sort((TargetObject item1, TargetObject item2) => Vector3.Distance(creature.GetPosition(), item1.ObjectInstance.GetPosition()).CompareTo(Vector3.Distance(creature.GetPosition(), item2.ObjectInstance.GetPosition())));
			if (targetQueue[0].ObjectInstance != target.ObjectInstance)
			{
				JumpToAction(selectNextResourceTarget);
			}
			else
			{
				targetQueue.RemoveAt(0);
			}
		}

		private bool CanAgentHaul()
		{
			if (!(base.AgentOwner is AnimalInstance animalInstance))
			{
				return true;
			}
			if (animalInstance.Blueprint == null || animalInstance.AnimalType != AnimalType.Pet)
			{
				return false;
			}
			if (animalInstance.PetHaulEnabled)
			{
				return animalInstance.Blueprint.CanHaulAsPet;
			}
			return false;
		}

		private bool ResourceFilterAbort(bool useWorkerStorage = false)
		{
			IStorage storage = GetTarget(TargetIndex.B).ObjectInstance as IStorage;
			if (storage == null)
			{
				storage = GetTargetQueue(TargetIndex.B).FirstOrDefault().ObjectInstance as IStorage;
			}
			if (storage == null)
			{
				return true;
			}
			if (!useWorkerStorage)
			{
				ResourcePileInstance objectAs = GetTarget(TargetIndex.A).GetObjectAs<ResourcePileInstance>();
				if (objectAs == null)
				{
					return true;
				}
				return !storage.CanStore(objectAs.GetStoredResource(), base.AgentOwner as CreatureBase);
			}
			ResourceInstance resource = (base.AgentOwner as IStorageAgent)?.Storage.GetSingleResource();
			return !storage.CanStore(resource, base.AgentOwner as CreatureBase);
		}

		private bool CheckAnimalHauling()
		{
			if (!(base.AgentOwner is AnimalInstance animalInstance))
			{
				return false;
			}
			return !animalInstance.PetHaulEnabled;
		}

		private void ReleaseStorageReservations()
		{
			if (reservedStorages.Count <= 0)
			{
				return;
			}
			foreach (IStorage reservedStorage in reservedStorages)
			{
				reservedStorage.ReleaseReservations((CreatureBase)base.AgentOwner);
			}
			reservedStorages.Clear();
		}

		private bool FailIfPileUnderWaterOrOnFire()
		{
			TargetObject target = GetTarget(TargetIndex.A);
			if (target.ObjectInstance is WorldObject { IsOnFire: not false })
			{
				return true;
			}
			if (!(base.AgentOwner is AnimalInstance animalInstance))
			{
				return false;
			}
			return animalInstance.Map.WaterManager.GetWaterLevelAsDepth(target.ReachablePosition) == WaterDepthLevel.High;
		}

		private bool FailIfStorageUnderWaterOrOnFire()
		{
			IStorage objectAs = GetTarget(TargetIndex.B).GetObjectAs<IStorage>();
			if (objectAs != null)
			{
				if (!objectAs.Underwater)
				{
					return objectAs.IsOnFire;
				}
				return true;
			}
			return false;
		}

		private bool FailHaulIfPilePlacementActive()
		{
			if (GetTarget(TargetIndex.A).GetObjectAs<ResourcePileInstance>() is MovableBuildingPileInstance movableBuildingPileInstance)
			{
				return movableBuildingPileInstance.PlacementModeActive;
			}
			return false;
		}

		private bool FailHaulIfCarcassIsMarkedForStripping()
		{
			if (GetTarget(TargetIndex.A).GetObjectAs<ResourcePileInstance>() is HumanCarcassPileInstance humanCarcassPileInstance)
			{
				return humanCarcassPileInstance.MarkedForStripping;
			}
			return false;
		}
	}
}
