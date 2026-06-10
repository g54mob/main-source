using System.Collections.Generic;
using System.Linq;
using NSEipix.Base;
using NSMedieval.BuildingComponents;
using NSMedieval.Construction;
using NSMedieval.Controllers;
using NSMedieval.Goap.Actions;
using NSMedieval.Manager;
using NSMedieval.Model;
using NSMedieval.Pathfinding;
using NSMedieval.State;
using NSMedieval.Types;
using NSMedieval.UI.Utils;
using NSMedieval.Utils.Pool;
using NSMedieval.Utils.Pool.Janitors;
using NSMedieval.Village;
using NSMedieval.Village.Map;
using NSMedieval.Village.Map.Pathfinding;

namespace NSMedieval.Goap.Goals
{
	public class DeliverFuelGoal : Goal
	{
		private const int MaxBuildings = 5;

		private List<TargetObject> buildingsToRefuel = new List<TargetObject>();

		private int currentCaloriesToCarryAmount;

		private SimpleResourceCount resourceOrder;

		private VillageMap map;

		public DeliverFuelGoal(Agent selfAgent)
			: base("DeliverFuelGoal", selfAgent)
		{
			map = VillageManager.ActiveVillage.Map;
			AddInitStep(base.PreferredReservableHandler.GetInitSequenceStep<FuelConsumerComponentInstance>());
			AddInitStep(new ThreadSequenceStep(null, SelectBuildings));
			AddInitStep(new ThreadSequenceStep(null, FindFuelPiles));
		}

		public override void Dispose()
		{
			base.Dispose();
			buildingsToRefuel?.Clear();
			map = null;
		}

		public override bool CanStart(bool isForced = false)
		{
			if (!MonoSingleton<FuelDeliveryManager>.IsInstantiated())
			{
				return false;
			}
			return MonoSingleton<FuelDeliveryManager>.Instance.ObjectsToRefuelRefactored.Count > 0;
		}

		public override bool AgentTypeCheck()
		{
			return base.AgentOwner is HumanoidInstance;
		}

		public override void EndGoalWith(GoalCondition condition)
		{
			((IToolAgent)base.AgentOwner).HideTool();
			base.EndGoalWith(condition);
			resourceOrder = default(SimpleResourceCount);
		}

		public override void HandleConsecutiveFail()
		{
			if (GetTarget(TargetIndex.A).IsInitialized)
			{
				ResourcePileInstance objectAs = GetTarget(TargetIndex.A).GetObjectAs<ResourcePileInstance>();
				if (objectAs != null)
				{
					objectAs.IsForbidden = true;
					string localizedResourcePileName = ResourceUtils.GetLocalizedResourcePileName(objectAs.Blueprint.GetID());
					string messageText = MonoSingleton<LocalizationController>.Instance.GetText("error_autoforbid_message").Replace("<object>", localizedResourcePileName);
					MonoSingleton<BlackBarMessageController>.Instance.ShowClickableBlackBarMessage(messageText, objectAs.WorldPosition);
				}
			}
		}

		protected override IEnumerable<GoapAction> GetNextAction()
		{
			GoapAction deliverStartAction = StorageActions.CompleteIfNoResourceInStorage(resourceOrder.Blueprint);
			GoapAction beginCheck = JumpActions.JumpIfNoTargetsInQueue(deliverStartAction, TargetIndex.A);
			GoapAction selectNextResourceTarget = GoalUtilActions.SelectNextTargetFromQueue(TargetIndex.A);
			yield return beginCheck;
			yield return selectNextResourceTarget;
			yield return GoToActions.GoToTarget(TargetIndex.A, PathCompleteMode.ExactPosition).JumpIfTargetDisposedForbiddenOrNull(beginCheck, TargetIndex.A);
			GoapAction goapAction = ResourceActions.PickupResourceFromPile(TargetIndex.A, (Resource blueprint) => GetPickupAmountFromCalories(), delegate(Resource blueprint, int amount)
			{
				resourceOrder = new SimpleResourceCount(resourceOrder.Blueprint, resourceOrder.Amount - (int)((float)amount * resourceOrder.Blueprint.CaloriesCount));
			}).JumpIfTargetDisposedOrNull(beginCheck, TargetIndex.A);
			goapAction.OnComplete = delegate(ActionCompletionStatus status)
			{
				if (status == ActionCompletionStatus.Success)
				{
					TargetObject target = GetTarget(TargetIndex.A);
					if (target.ObjectInstance != null && !target.ObjectInstance.HasDisposed)
					{
						MonoSingleton<ReservationManager>.Instance.ReleaseObject(target.GetAsReservable(), base.AgentOwner);
					}
				}
			};
			yield return goapAction;
			yield return JumpActions.ConditionalJump(beginCheck, () => resourceOrder.Amount > 0);
			yield return deliverStartAction;
			yield return GoalUtilActions.SelectNextTargetFromQueue(TargetIndex.B);
			yield return GoToActions.GoToTarget(TargetIndex.B, PathCompleteMode.ExactPosition).JumpIfTargetDisposedForbiddenOrNull(deliverStartAction, TargetIndex.B).JumpIfTargetReservationReleases(deliverStartAction, TargetIndex.B)
				.FailAtCondition(() => !CanStoreFuel() || TurnedOff());
			GoapAction goapAction2 = ResourceActions.DeliverFuelResource(TargetIndex.B).JumpIfTargetDisposedForbiddenOrNull(deliverStartAction, TargetIndex.B).JumpIfTargetReservationReleases(deliverStartAction, TargetIndex.B)
				.TriggerAnimation("DropPile", ActionAnimationMode.WaitForCompletion);
			goapAction2.OnComplete = delegate(ActionCompletionStatus status)
			{
				if (status == ActionCompletionStatus.Success)
				{
					TargetObject target = GetTarget(TargetIndex.B);
					if (target.ObjectInstance != null && !target.ObjectInstance.HasDisposed)
					{
						MonoSingleton<ReservationManager>.Instance.ReleaseObject(target.GetAsReservable(), base.AgentOwner);
					}
				}
			};
			yield return goapAction2;
			yield return JumpActions.JumpIfHaveResourceInStorage(deliverStartAction, resourceOrder.Blueprint);
		}

		private int GetPickupAmountFromCalories()
		{
			int amount = resourceOrder.Amount;
			float caloriesCount = resourceOrder.Blueprint.CaloriesCount;
			return (int)((float)amount / caloriesCount + 0.5f);
		}

		private bool ValidatePile(ResourcePileInstance pile, FuelConsumerComponentInstance targetFuelConsumer = null)
		{
			if (pile.IsReserveAll)
			{
				return false;
			}
			if (MonoSingleton<ReservationManager>.Instance.GetReserversCount(pile) > 0)
			{
				return false;
			}
			if (pile.IsForbidden)
			{
				return false;
			}
			ResourceInstance resource = pile.GetStoredResource();
			if (targetFuelConsumer != null && !targetFuelConsumer.CanStoreFuel(resource.Blueprint))
			{
				return false;
			}
			if (!resource.Blueprint.Category.HasFlag(ResourceCategory.CtgFuel) && !resource.Blueprint.Category.HasFlag(ResourceCategory.CtgCandleFuel))
			{
				return false;
			}
			bool checkIfGoalIsForced = base.Agent.LastForceStartedGoal == this;
			using PooledList<BaseBuildingInstance> pooledList = ListPool<BaseBuildingInstance>.GetJanitor();
			foreach (FuelConsumerComponentInstance allFuelConsumer in map.FuelConsumerComponentManager.AllFuelConsumers)
			{
				pooledList.Add(allFuelConsumer.OwnerBuilding);
			}
			IPathfindingAgent pathfindingAgent = (IPathfindingAgent)base.AgentOwner;
			return PathfinderUtil.GetClosestReachable(pathfindingAgent, pooledList, delegate(IGoapTargetable x)
			{
				if (!(x is BaseBuildingInstance baseBuildingInstance))
				{
					return false;
				}
				if (baseBuildingInstance.HasDisposed)
				{
					return false;
				}
				FuelConsumerComponentInstance componentInstance = baseBuildingInstance.GetComponentInstance<FuelConsumerComponentInstance>();
				if (componentInstance == null)
				{
					return false;
				}
				if (!componentInstance.CanStoreFuel(resource.Blueprint) || componentInstance.ResourcesFilter.AllowedResourceTypes.Count == 0 || !componentInstance.AvailableResourcesExist(pathfindingAgent) || componentInstance.TorchState == TorchState.Off || componentInstance.Underwater || componentInstance.IsOnFire)
				{
					return false;
				}
				if (checkIfGoalIsForced)
				{
					return MonoSingleton<FuelDeliveryManager>.Instance.ObjectsToRefuelRefactored.Contains(componentInstance);
				}
				return componentInstance.ShouldRefuel() && MonoSingleton<FuelDeliveryManager>.Instance.ObjectsToRefuelRefactored.Contains(componentInstance);
			}, (IGoapTargetable o) => (float)((BaseBuildingInstance)o).GetComponentInstance<FuelConsumerComponentInstance>().RefuelPriority) != null;
		}

		private ResourcePileInstance PickClosestPileToHaul(FuelConsumerComponentInstance preferredFuelConsumer = null)
		{
			IPathfindingAgent obj = (IPathfindingAgent)base.AgentOwner;
			MonoSingleton<ResourcePileManager>.Instance.CategoryInstanceDictionaryTryGetValue(ResourceCategory.CtgFuel, out var resourcePileInstances);
			MonoSingleton<ResourcePileManager>.Instance.CategoryInstanceDictionaryTryGetValue(ResourceCategory.CtgCandleFuel, out var resourcePileInstances2);
			HashSet<ResourcePileInstance> hashSet = new HashSet<ResourcePileInstance>();
			if (resourcePileInstances != null)
			{
				hashSet.UnionWith(resourcePileInstances);
			}
			if (resourcePileInstances2 != null)
			{
				hashSet.UnionWith(resourcePileInstances2);
			}
			return (ResourcePileInstance)PathfinderUtil.GetClosestReachable(obj, hashSet, (IGoapTargetable o) => ValidatePile((ResourcePileInstance)o, preferredFuelConsumer));
		}

		private bool SelectBuildings()
		{
			buildingsToRefuel.Clear();
			ResourcePileInstance resourcePileInstance = null;
			TargetObject target2;
			if (HasValidPreferredReservable())
			{
				TargetObject target = base.PreferredReservableHandler.GetTarget();
				FuelConsumerComponentInstance objectAs = target.GetObjectAs<FuelConsumerComponentInstance>();
				if (objectAs != null && !objectAs.HasDisposed)
				{
					BaseBuildingInstance ownerBuilding = objectAs.OwnerBuilding;
					if (ownerBuilding != null && !ownerBuilding.HasDisposed && objectAs.OwnerBuilding.OwnedByPlayer() && MonoSingleton<ReservationManager>.Instance.TryReserveObject(objectAs, base.AgentOwner))
					{
						resourcePileInstance = PickClosestPileToHaul(objectAs);
						if (resourcePileInstance == null)
						{
							return false;
						}
						if (!objectAs.Underwater && !objectAs.IsOnFire)
						{
							target2 = new TargetObject(resourcePileInstance);
							QueueTarget(TargetIndex.A, target2);
							resourcePileInstance.ReserveAll();
							if (!MonoSingleton<ReservationManager>.Instance.TryReserveObject(resourcePileInstance, base.AgentOwner))
							{
								return false;
							}
							QueueTarget(TargetIndex.B, target);
							resourceOrder = new SimpleResourceCount(resourcePileInstance.Blueprint, objectAs.GetMaxCaloriesToStore());
							buildingsToRefuel.Add(target);
							return true;
						}
						base.PreferredReservableHandler.ClearTarget();
					}
				}
			}
			resourcePileInstance = PickClosestPileToHaul();
			if (resourcePileInstance == null)
			{
				return false;
			}
			target2 = new TargetObject(resourcePileInstance);
			QueueTarget(TargetIndex.A, target2);
			resourcePileInstance.ReserveAll();
			if (!MonoSingleton<ReservationManager>.Instance.TryReserveObject(resourcePileInstance, base.AgentOwner))
			{
				return false;
			}
			if (!FindBuildingsToRefuel(resourcePileInstance.GetStoredResource()))
			{
				return false;
			}
			buildingsToRefuel = buildingsToRefuel.OrderByDescending((TargetObject x) => (int)x.GetObjectAs<FuelConsumerComponentInstance>().RefuelPriority).ToList();
			IPathfindingAgent obj = (IPathfindingAgent)base.AgentOwner;
			TargetObject target3 = buildingsToRefuel.First();
			FuelConsumerComponentInstance sourceFuelConsumer = target3.GetObjectAs<FuelConsumerComponentInstance>();
			float caloriesCount = resourcePileInstance.Blueprint.CaloriesCount;
			int maximumStorableCount = ((IStorageAgent)obj).Storage.GetMaximumStorableCount(resourcePileInstance.Blueprint);
			int workerMaxCarryCalories = (int)((float)maximumStorableCount * caloriesCount);
			currentCaloriesToCarryAmount = 0;
			resourceOrder = default(SimpleResourceCount);
			int selectedTargetFuelConsumersCount = 0;
			if (MonoSingleton<ReservationManager>.Instance.TryReserveObject(sourceFuelConsumer, base.AgentOwner))
			{
				int num = sourceFuelConsumer.GetMaxCaloriesToStore();
				int num2 = workerMaxCarryCalories - currentCaloriesToCarryAmount;
				if (num > num2)
				{
					num = num2;
				}
				currentCaloriesToCarryAmount += num;
				selectedTargetFuelConsumersCount++;
				QueueTarget(TargetIndex.B, target3);
			}
			List<WorldObject> list = PathfinderUtil.FindNearbyObject(obj, target3.ReachablePosition, 15f, delegate(WorldObject o)
			{
				if (selectedTargetFuelConsumersCount >= 5)
				{
					return -1;
				}
				FuelConsumerComponentInstance componentInstance = map.FuelConsumerComponentManager.GetComponentInstance(o);
				if (componentInstance == null || componentInstance.HasDisposed)
				{
					return 0;
				}
				if (componentInstance == sourceFuelConsumer)
				{
					return 0;
				}
				foreach (TargetObject item in buildingsToRefuel)
				{
					if (item.GetObjectAs<FuelConsumerComponentInstance>() == componentInstance)
					{
						if (currentCaloriesToCarryAmount >= workerMaxCarryCalories)
						{
							return 2;
						}
						if (MonoSingleton<ReservationManager>.Instance.TryReserveObject(componentInstance, base.AgentOwner))
						{
							int num3 = componentInstance.GetMaxCaloriesToStore();
							int num4 = workerMaxCarryCalories - currentCaloriesToCarryAmount;
							if (num3 > num4)
							{
								num3 = num4;
							}
							currentCaloriesToCarryAmount += num3;
							selectedTargetFuelConsumersCount++;
							QueueTarget(TargetIndex.B, item);
							return 1;
						}
						return 0;
					}
				}
				return 0;
			});
			resourceOrder = new SimpleResourceCount(resourcePileInstance.Blueprint, currentCaloriesToCarryAmount);
			ListPool<WorldObject>.Return(list);
			return selectedTargetFuelConsumersCount > 0;
		}

		private bool FindFuelPiles()
		{
			ResourcePileInstance sourcePileInstance = GetTargetQueue(TargetIndex.A).First().GetObjectAs<ResourcePileInstance>();
			ResourceInstance storedResource = sourcePileInstance.GetStoredResource();
			int num = (int)((float)storedResource.Amount * storedResource.Blueprint.CaloriesCount);
			if (num >= currentCaloriesToCarryAmount)
			{
				return true;
			}
			int remainingCaloriesToBeFound = currentCaloriesToCarryAmount - num;
			ListPool<WorldObject>.Return(PathfinderUtil.FindNearbyObject((IPathfindingAgent)base.AgentOwner, sourcePileInstance.GridDataPosition, 9f, delegate(WorldObject o)
			{
				if (!(o is ResourcePileInstance { HasDisposed: false } resourcePileInstance))
				{
					return 0;
				}
				if (resourcePileInstance.IsForbidden || resourcePileInstance.Blueprint != sourcePileInstance.Blueprint || resourcePileInstance == sourcePileInstance)
				{
					return 0;
				}
				float caloriesCount = resourcePileInstance.Blueprint.CaloriesCount;
				int num2 = (int)((float)resourcePileInstance.GetStoredResource().Amount * caloriesCount);
				QueueTarget(TargetIndex.A, new TargetObject(resourcePileInstance));
				resourcePileInstance.ReserveAll();
				if (!MonoSingleton<ReservationManager>.Instance.TryReserveObject(resourcePileInstance, base.AgentOwner))
				{
					return 0;
				}
				return (remainingCaloriesToBeFound - num2 <= 0) ? 2 : 0;
			}));
			return true;
		}

		private bool FindBuildingsToRefuel(ResourceInstance resourceInstance)
		{
			IPathfindingAgent pathfindingAgent = (IPathfindingAgent)base.AgentOwner;
			List<WorldObject> fuelConsumerBuildingsPathfinding = map.FuelConsumerComponentManager.GetFuelConsumerBuildingsPathfinding(onlyPlayerOwnedBuildings: true, SearchCondition);
			if (fuelConsumerBuildingsPathfinding == null || fuelConsumerBuildingsPathfinding.Count == 0)
			{
				return false;
			}
			List<TargetObject> list = PathfinderMedieval.FindMedievalObjects<BaseBuildingInstance>(pathfindingAgent, fuelConsumerBuildingsPathfinding);
			if (list == null || list.Count <= 0)
			{
				return false;
			}
			foreach (TargetObject item in list)
			{
				WorldObject objectAs = item.GetObjectAs<WorldObject>();
				if (objectAs != null && !objectAs.HasDisposed && objectAs.OwnedByPlayer())
				{
					FuelConsumerComponentInstance componentInstance = map.FuelConsumerComponentManager.GetComponentInstance(objectAs);
					if (componentInstance != null && !componentInstance.HasDisposed)
					{
						buildingsToRefuel.Add(new TargetObject(componentInstance, item.ReachablePosition));
					}
				}
			}
			return buildingsToRefuel.Count > 0;
			bool SearchCondition(FuelConsumerComponentInstance fuelConsumerComponentInstance)
			{
				if (fuelConsumerComponentInstance == null || fuelConsumerComponentInstance.ResourcesFilter.AllowedResourceTypes.Count == 0 || fuelConsumerComponentInstance.TorchState == TorchState.Off || !fuelConsumerComponentInstance.ShouldRefuel() || !fuelConsumerComponentInstance.AvailableResourcesExist((IPathfindingAgent)base.AgentOwner) || fuelConsumerComponentInstance.Underwater)
				{
					return false;
				}
				if (!fuelConsumerComponentInstance.CanStoreFuel(resourceInstance.Blueprint))
				{
					return false;
				}
				return MonoSingleton<FuelDeliveryManager>.Instance.ObjectsToRefuelRefactored.Contains(fuelConsumerComponentInstance);
			}
		}

		private bool HasValidPreferredReservable()
		{
			WorkerGoapAgent workerGoapAgent = base.Agent as WorkerGoapAgent;
			if (workerGoapAgent?.ExclusiveGoal == null || workerGoapAgent.ExclusiveGoal != this)
			{
				return false;
			}
			if (!base.PreferredReservableHandler.HasTarget())
			{
				return false;
			}
			FuelConsumerComponentInstance objectAs = base.PreferredReservableHandler.GetTarget().GetObjectAs<FuelConsumerComponentInstance>();
			if (objectAs == null || objectAs.HasDisposed)
			{
				base.PreferredReservableHandler.ClearTarget();
				return false;
			}
			return objectAs.GetMaxCaloriesToStore() > 0;
		}

		private bool CanStoreFuel()
		{
			FuelConsumerComponentInstance objectAs = GetTarget(TargetIndex.B).GetObjectAs<FuelConsumerComponentInstance>();
			Resource blueprint = ((IStorageAgent)base.AgentOwner).Storage?.GetSingleResource()?.Blueprint;
			return objectAs?.CanStoreFuel(blueprint) ?? false;
		}

		private bool TurnedOff()
		{
			return GetTarget(TargetIndex.B).GetObjectAs<FuelConsumerComponentInstance>().TorchState == TorchState.Off;
		}
	}
}
