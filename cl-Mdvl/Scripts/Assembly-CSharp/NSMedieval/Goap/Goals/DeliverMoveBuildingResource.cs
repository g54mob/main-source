using System.Collections.Generic;
using FoxyVoxel.Logging;
using FoxyVoxel.Logging.Core.LogMessageInterpolationHandlers;
using NSEipix;
using NSEipix.Base;
using NSMedieval.BuildingComponents;
using NSMedieval.Construction;
using NSMedieval.Controllers;
using NSMedieval.Goap.Actions;
using NSMedieval.Manager;
using NSMedieval.MovableBuildings;
using NSMedieval.Pathfinding;
using NSMedieval.State;
using NSMedieval.State.WorkerJobs;
using NSMedieval.Types;
using NSMedieval.UI.Utils;
using NSMedieval.Village;
using NSMedieval.Village.Map.Pathfinding;

namespace NSMedieval.Goap.Goals
{
	public class DeliverMoveBuildingResource : Goal
	{
		public DeliverMoveBuildingResource(Agent selfAgent)
			: base("DeliverMoveBuildingResource", selfAgent)
		{
			AddInitStep(base.PreferredReservableHandler.GetInitSequenceStep<BaseBuildingInstance>());
			AddInitStep(new ThreadSequenceStep(null, PrepareData));
		}

		public override bool AgentTypeCheck()
		{
			return base.AgentOwner is HumanoidInstance;
		}

		public override bool CanStart(bool isForced = false)
		{
			if (!MonoSingleton<MoveBuildingsManager>.IsInstantiated())
			{
				return false;
			}
			return MonoSingleton<MoveBuildingsManager>.Instance.Count > 0;
		}

		public override void EndGoalWith(GoalCondition condition)
		{
			BaseBuildingInstance baseBuildingInstance = GetTarget(TargetIndex.B).GetObjectAs<BaseBuildingInstance>();
			base.EndGoalWith(condition);
			if (baseBuildingInstance == null || condition != GoalCondition.Succeeded)
			{
				return;
			}
			HumanoidInstance obj = base.AgentOwner as HumanoidInstance;
			if (obj == null || !obj.WorkerBehaviour.ActiveJobCombination.HasFlag(JobType.Construction) || !MonoSingleton<ReservationManager>.Instance.TryReserveObject(baseBuildingInstance, base.AgentOwner))
			{
				return;
			}
			MonoSingleton<ReservationManager>.Instance.SetPreferedReservable(base.AgentOwner, baseBuildingInstance);
			base.Agent.ForceNextGoal("ConstructBuildingGoal");
			MonoSingleton<TaskController>.Instance.WaitFor(1.5f).Then(delegate
			{
				if (!base.Agent.HasDisposed && !baseBuildingInstance.HasDisposed && !base.Agent.CurrentGoalName.Equals("ConstructBuildingGoal"))
				{
					MonoSingleton<ReservationManager>.Instance.ReleaseObject(baseBuildingInstance, base.AgentOwner);
				}
			});
		}

		public override void HandleConsecutiveFail()
		{
			if (!GetTarget(TargetIndex.A).IsInitialized)
			{
				return;
			}
			MovableBuildingPileInstance objectAs = GetTarget(TargetIndex.A).GetObjectAs<MovableBuildingPileInstance>();
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
			else if (GetTarget(TargetIndex.B).IsInitialized)
			{
				BaseBuildingInstance objectAs2 = GetTarget(TargetIndex.B).GetObjectAs<BaseBuildingInstance>();
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
			yield return GoToActions.GoToTarget(TargetIndex.A, PathCompleteMode.ExactPosition).FailIfTargetDisposedForbidenOrNull(TargetIndex.A).FailIfTargetDisposedForbidenOrNull(TargetIndex.B);
			yield return ResourceActions.PickupResourceFromPile(TargetIndex.A, 1);
			yield return GoToActions.GoToTarget(TargetIndex.B, PathCompleteMode.ExactPosition).FailIfTargetDisposedForbidenOrNull(TargetIndex.B);
			yield return ResourceActions.DeliverMoveBuildingConstructionMaterials(TargetIndex.B).FailIfTargetDisposedForbidenOrNull(TargetIndex.B).TriggerAnimation("DropPile", ActionAnimationMode.WaitForCompletion);
		}

		private bool PrepareData()
		{
			if (HasValidPreferredReservable())
			{
				TargetObject target = base.PreferredReservableHandler.GetTarget();
				BaseBuildingInstance objectAs = target.GetObjectAs<BaseBuildingInstance>();
				MovableBuildingPileInstance movableBuildingPileInstance = objectAs.MovableBuildingPileInstance;
				if (movableBuildingPileInstance != null)
				{
					if (movableBuildingPileInstance.IsForbidden)
					{
						return false;
					}
					if (!objectAs.HasStabilityToBuild || !objectAs.IsBlueprintOnClearNode())
					{
						return false;
					}
					if (!MonoSingleton<ReservationManager>.Instance.TryReserveObject(objectAs, base.AgentOwner))
					{
						return false;
					}
					SetTarget(TargetIndex.A, new TargetObject(movableBuildingPileInstance, movableBuildingPileInstance.GridDataPosition));
					SetTarget(TargetIndex.B, target);
					return true;
				}
				bool isEnabled;
				FVLogWarningInterpolationHandler messageBuilder = new FVLogWarningInterpolationHandler(65, 2, out isEnabled, "C:\\GIT\\dev\\Assets\\Scripts\\GOAP\\Goal\\DeliverMoveBuildingResource.cs");
				if (isEnabled)
				{
					messageBuilder.AppendLiteral("Tried to move building without MovableBuildingPileInstance ");
					messageBuilder.AppendFormatted(objectAs);
					messageBuilder.AppendLiteral(" pos: ");
					messageBuilder.AppendFormatted(objectAs.GridDataPosition);
				}
				Log.Warning(messageBuilder);
			}
			return PathfinderMedieval.ExploreForObjects(new ExploreRequest
			{
				Agent = (IPathfindingAgent)base.AgentOwner,
				GridData = (GridDataType.OthersBlueprint | GridDataType.SocketableBlueprint | GridDataType.RugBlueprint),
				Condition = delegate(WorldObject obj)
				{
					if (!(obj is BaseBuildingInstance baseBuildingInstance))
					{
						return false;
					}
					return baseBuildingInstance.IsMoveBlueprint && baseBuildingInstance.HasStabilityToBuild && baseBuildingInstance.IsBlueprintOnClearNode() && baseBuildingInstance.MovableBuildingPileInstance != null && !baseBuildingInstance.MovableBuildingPileInstance.HasDisposed && !baseBuildingInstance.MovableBuildingPileInstance.IsForbidden && PathfinderUtil.IsPathPossible((IPathfindingAgent)base.AgentOwner, baseBuildingInstance.MovableBuildingPileInstance.ReachablePositions);
				},
				OnFound = delegate(WorldObject item, Vec3Int pos)
				{
					MovableBuildingPileInstance movableBuildingPileInstance2 = (item as BaseBuildingInstance)?.MovableBuildingPileInstance;
					if (!MonoSingleton<ReservationManager>.Instance.TryReserveObject(movableBuildingPileInstance2, base.AgentOwner))
					{
						return P2RegionReservableWoExplorerPath.RegionExplorerCallbackResult.Continue;
					}
					SetTarget(TargetIndex.A, new TargetObject(movableBuildingPileInstance2, movableBuildingPileInstance2.GridDataPosition));
					SetTarget(TargetIndex.B, new TargetObject(item, pos));
					return P2RegionReservableWoExplorerPath.RegionExplorerCallbackResult.Finish;
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
