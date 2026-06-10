using System.Collections.Generic;
using System.Linq;
using NSEipix;
using NSEipix.Base;
using NSMedieval.BuildingComponents;
using NSMedieval.Construction;
using NSMedieval.Controllers;
using NSMedieval.Fire;
using NSMedieval.Goap.Actions;
using NSMedieval.Manager;
using NSMedieval.Model;
using NSMedieval.Pathfinding;
using NSMedieval.State;
using NSMedieval.Types;
using NSMedieval.UI.Utils;
using NSMedieval.Village;
using NSMedieval.Village.Map;
using NSMedieval.Village.Map.Pathfinding;
using NSMedieval.Water;

namespace NSMedieval.Goap.Goals
{
	public class DeliverBuildingMaterialsGoal : Goal
	{
		private const float MaxContinuousPileDistance = 6f;

		private SimpleResourceCount resourceOrder;

		public DeliverBuildingMaterialsGoal(Agent selfAgent)
			: base("DeliverBuildingMaterialsGoal", selfAgent)
		{
			AddInitStep(base.PreferredReservableHandler.GetInitSequenceStep<BaseBuildingInstance>(preferLastTarget: false));
			AddInitStep(new ThreadSequenceStep(null, FindBlueprints));
			AddInitStep(new ThreadSequenceStep(null, FindResourcePiles));
		}

		public override bool AgentTypeCheck()
		{
			return base.AgentOwner is IStorageAgent;
		}

		public override bool CanStart(bool isForced = false)
		{
			return base.ConstructionJobManager.HasDoableDeliveryJobs();
		}

		public override void EndGoalWith(GoalCondition condition)
		{
			resourceOrder = default(SimpleResourceCount);
			HumanoidInstance humanoid = (HumanoidInstance)base.AgentOwner;
			WorkerBehaviour workerBehaviour = humanoid.WorkerBehaviour;
			if ((workerBehaviour != null && workerBehaviour.IsDrafting) || humanoid.HasFainted)
			{
				base.EndGoalWith(condition);
				return;
			}
			BaseBuildingInstance building = GetTarget(TargetIndex.A).GetObjectAs<BaseBuildingInstance>();
			if (building != null && base.PreferredReservableHandler.HasTarget())
			{
				MonoSingleton<TaskController>.Instance.WaitForNextFrame().Then(delegate
				{
					WorkerBehaviour workerBehaviour2 = humanoid.WorkerBehaviour;
					if ((workerBehaviour2 == null || !workerBehaviour2.IsDrafting) && !humanoid.HasFainted)
					{
						if (!building.HasConstructionMaterials())
						{
							MonoSingleton<ReservationManager>.Instance.SetPreferedReservable(base.AgentOwner, building);
							base.Agent.ForceNextGoal(base.Id);
						}
						else if (base.Agent.GoalScheduler.IsEnabled("ConstructBuildingGoal") && building.IsBlueprintOnClearNode())
						{
							MonoSingleton<ReservationManager>.Instance.SetPreferedReservable(base.AgentOwner, building);
							base.Agent.ForceNextGoal("ConstructBuildingGoal");
						}
					}
				});
			}
			base.EndGoalWith(condition);
		}

		public override void HandleConsecutiveFail()
		{
			if (!GetTarget(TargetIndex.B).IsInitialized)
			{
				return;
			}
			ResourcePileInstance objectAs = GetTarget(TargetIndex.B).GetObjectAs<ResourcePileInstance>();
			if (objectAs == null)
			{
				return;
			}
			if (objectAs.GridDataPosition != ((IPathfindingAgent)base.Agent.AgentOwner).GetGridPosition())
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
			else if (GetTarget(TargetIndex.A).IsInitialized)
			{
				BaseBuildingInstance objectAs2 = GetTarget(TargetIndex.A).GetObjectAs<BaseBuildingInstance>();
				if (objectAs2 != null)
				{
					objectAs2.IsForbidden = true;
					string localizedName = BuildingUtils.GetLocalizedName(objectAs2.Blueprint.GetID());
					string messageText2 = MonoSingleton<LocalizationController>.Instance.GetText("error_autoforbid_message").Replace("<object>", localizedName);
					MonoSingleton<BlackBarMessageController>.Instance.ShowClickableBlackBarMessage(messageText2, objectAs2.WorldPosition);
				}
			}
		}

		protected override IEnumerable<GoapAction> GetNextAction()
		{
			GoapAction deliverStartAction = StorageActions.CompleteIfNoResourceInStorage(resourceOrder.Blueprint);
			GoapAction beginCheck = JumpActions.JumpIfNoTargetsInQueue(deliverStartAction, TargetIndex.B);
			yield return beginCheck;
			yield return GoalUtilActions.SelectNextTargetFromQueue(TargetIndex.B);
			yield return GoToActions.GoToTarget(TargetIndex.B, PathCompleteMode.ExactPosition).JumpIfTargetDisposedForbiddenOrNull(beginCheck, TargetIndex.B);
			yield return ResourceActions.PickupResourceFromPile(TargetIndex.B, (Resource blueprint) => resourceOrder.Amount, delegate(Resource blueprint, int amount)
			{
				resourceOrder = new SimpleResourceCount(resourceOrder.Blueprint, resourceOrder.Amount - amount);
			}).JumpIfTargetDisposedOrNull(beginCheck, TargetIndex.B);
			yield return JumpActions.ConditionalJump(beginCheck, () => resourceOrder.Amount > 0);
			yield return deliverStartAction;
			yield return GoalUtilActions.CompleteIfNoTargetsInQueue(TargetIndex.A);
			yield return GoalUtilActions.SelectClosestTargetFromQueue(TargetIndex.A);
			yield return GoToActions.GoToTarget(TargetIndex.A, PathCompleteMode.ExactPosition).JumpIfTargetDisposedForbiddenOrNull(deliverStartAction, TargetIndex.A).JumpIfTargetReservationReleases(deliverStartAction, TargetIndex.A);
			yield return ResourceActions.DeliverBuildingConstructionMaterials(TargetIndex.A).JumpIfTargetDisposedForbiddenOrNull(deliverStartAction, TargetIndex.A).JumpIfTargetReservationReleases(deliverStartAction, TargetIndex.A);
			yield return JumpActions.JumpIfHaveResourceInStorage(deliverStartAction, resourceOrder.Blueprint);
			GoapAction goapAction = new GoapAction("WaitForJobManagerUpdate");
			uint currentVersion = 0u;
			goapAction.CompleteAfterTimeExpires(5f);
			goapAction.OnInit = delegate
			{
				currentVersion = base.ConstructionJobManager.CreateVoxelManager.Version;
			};
			goapAction.CompleteAtCondition(() => base.ConstructionJobManager.CreateVoxelManager.Version != currentVersion);
			yield return goapAction;
		}

		private bool FindBlueprints()
		{
			resourceOrder = default(SimpleResourceCount);
			if (HasValidPreferredReservable())
			{
				IPathfindingAgent pathfindingAgent = (IPathfindingAgent)base.AgentOwner;
				BaseBuildingInstance preferredBuilding = base.PreferredReservableHandler.GetTarget().GetAsReservable() as BaseBuildingInstance;
				List<WorldObject> targets = new List<WorldObject> { preferredBuilding };
				VillageMap map = VillageManager.ActiveVillage.Map;
				FireSimLogic fireSimLogic = map.FireSimLogic;
				List<TargetObject> list = PathfinderMedieval.FindMedievalObjects(pathfindingAgent, targets, (BaseBuildingInstance item) => !item.IsMoveBlueprint && !item.IsForbidden && !item.IsOnFire);
				if (list != null)
				{
					foreach (TargetObject item in list)
					{
						MapNode node = map.GetNode(item.ReachablePosition);
						if (fireSimLogic.GetFireData(node.Index) > 0f)
						{
							continue;
						}
						MapNode nodeAbove = node.GetNodeAbove();
						if (node.WaterLevel != WaterDepthLevel.High || nodeAbove == null || !nodeAbove.IsWater || nodeAbove.WaterLevel == WaterDepthLevel.Low)
						{
							BaseBuildingInstance objectAs = item.GetObjectAs<BaseBuildingInstance>();
							if (MonoSingleton<ReservationManager>.Instance.TryReserveObject(objectAs, base.AgentOwner))
							{
								QueueTarget(TargetIndex.A, item);
								resourceOrder = objectAs.GetResourceOrder(pathfindingAgent).FirstOrDefault();
								return true;
							}
						}
					}
				}
				if (base.Agent.LastForceStartedGoal == this)
				{
					string localizedName = BuildingUtils.GetLocalizedName(preferredBuilding.Blueprint.GetID());
					string message = MonoSingleton<LocalizationController>.Instance.GetText("error_no_possible_path").Replace("<object>", localizedName);
					MonoSingleton<TaskController>.Instance.OptimizedCall(this, "DeliverPathFailMsg", delegate
					{
						MonoSingleton<BlackBarMessageController>.Instance.ShowClickableBlackBarMessage(message, preferredBuilding.WorldPosition);
					});
				}
				base.PreferredReservableHandler.ClearTarget();
			}
			HumanoidInstance humanoidInstance = (HumanoidInstance)base.AgentOwner;
			if (!base.ConstructionJobManager.TryReserveDeliverResourceJobs(humanoidInstance, out var outJobs, out resourceOrder))
			{
				outJobs.Dispose();
				return false;
			}
			foreach (BaseBuildingInstance item2 in outJobs)
			{
				Vec3Int firstReachablePosition = item2.GetFirstReachablePosition(humanoidInstance);
				QueueTarget(TargetIndex.A, new TargetObject(item2, firstReachablePosition));
			}
			outJobs.Dispose();
			return true;
		}

		private bool FindResourcePiles()
		{
			int reservedAmount = 0;
			return PathfinderMedieval.ExploreForObjects(new ExploreRequest
			{
				Agent = (IPathfindingAgent)base.AgentOwner,
				GridData = GridDataType.ResourcePile,
				DoQuickSearch = true,
				Condition = delegate(WorldObject item)
				{
					if (!(item is ResourcePileInstance resourcePileInstance))
					{
						return false;
					}
					return !resourcePileInstance.IsForbidden && resourcePileInstance.Blueprint.Equals(resourceOrder.Blueprint) && !resourcePileInstance.PlacedOnAnimalFeeder && !resourcePileInstance.IsOnFire;
				},
				OnFound = delegate(WorldObject item, Vec3Int pos)
				{
					ResourcePileInstance resourcePileInstance = item as ResourcePileInstance;
					reservedAmount += resourcePileInstance.GetStoredResource().Amount;
					QueueTarget(TargetIndex.B, new TargetObject(item, pos));
					int maximumStorableCount = ((HumanoidInstance)base.AgentOwner).Storage.GetMaximumStorableCount(resourcePileInstance.Blueprint);
					return (reservedAmount < maximumStorableCount) ? P2RegionReservableWoExplorerPath.RegionExplorerCallbackResult.Continue : P2RegionReservableWoExplorerPath.RegionExplorerCallbackResult.Finish;
				}
			});
		}

		private bool HasValidPreferredReservable()
		{
			if (!base.PreferredReservableHandler.HasTarget())
			{
				return false;
			}
			if (base.PreferredReservableHandler.GetTarget().GetObjectAs<BaseBuildingInstance>().ConstructionPhase != ConstructionPhase.Blueprint)
			{
				base.PreferredReservableHandler.ClearTarget();
				return false;
			}
			return true;
		}
	}
}
