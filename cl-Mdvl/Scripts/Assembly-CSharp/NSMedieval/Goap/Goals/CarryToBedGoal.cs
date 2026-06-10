using System.Collections.Generic;
using System.Linq;
using FoxyVoxel.Logging;
using FoxyVoxel.Logging.Core.LogMessageInterpolationHandlers;
using NSEipix;
using NSEipix.Base;
using NSMedieval.BuildingComponents;
using NSMedieval.Construction;
using NSMedieval.Controllers;
using NSMedieval.Goap.Actions;
using NSMedieval.Manager;
using NSMedieval.Pathfinding;
using NSMedieval.RoomDetection;
using NSMedieval.State;
using NSMedieval.Types;
using NSMedieval.View;
using NSMedieval.Village;
using NSMedieval.Village.Map;
using NSMedieval.Village.Map.Pathfinding;
using UnityEngine;

namespace NSMedieval.Goap.Goals
{
	public class CarryToBedGoal : Goal
	{
		private volatile bool hasPrioritisedTarget;

		private CreatureBase creatureCarrying;

		private HumanoidInstance closestHumanoid;

		private VillageMap map;

		public CarryToBedGoal(Agent selfAgent)
			: base("CarryToBedGoal", selfAgent)
		{
			map = VillageManager.ActiveVillage.Map;
			AddInitStep(base.PreferredReservableHandler.GetInitSequenceStep<HumanoidInstance>());
			AddInitStep(new ThreadSequenceStep(null, PrepareData));
		}

		public override void Dispose()
		{
			base.Dispose();
			map = null;
			creatureCarrying = null;
			closestHumanoid = null;
		}

		public override bool AgentTypeCheck()
		{
			return base.AgentOwner is HumanoidInstance;
		}

		public override bool CanStart(bool isForced = false)
		{
			if (!MonoSingleton<WorkerManager>.IsInstantiated())
			{
				return false;
			}
			if (MonoSingleton<WorkerManager>.Instance.FaintedWorkers.Count > 0 && !((HumanoidInstance)base.AgentOwner).HasFainted)
			{
				return !((HumanoidInstance)base.AgentOwner).IsBeingCarried;
			}
			return false;
		}

		public override void EndGoalWith(GoalCondition condition)
		{
			if (base.State != GoalState.Running || !MonoSingleton<AnimationController>.IsInstantiated())
			{
				return;
			}
			HumanoidInstance targetHumanoid = GetTarget(TargetIndex.A).GetObjectAs<HumanoidInstance>() ?? closestHumanoid;
			TargetObject target = GetTarget(TargetIndex.B);
			MonoSingleton<AnimationController>.Instance.SetAnimatorParameter(base.AgentOwner, "IsCaringWorker", value: false);
			base.EndGoalWith(condition);
			if (targetHumanoid == null || targetHumanoid.HasDisposed)
			{
				return;
			}
			AnimatedAgentView agentView = targetHumanoid.GetAgentView<AnimatedAgentView>();
			if (agentView != null)
			{
				agentView.IsRotationLocked = false;
			}
			Transform transform = targetHumanoid.GetTransform();
			bool flag = condition == GoalCondition.Succeeded;
			HumanoidInstance humanoidInstance = (HumanoidInstance)base.AgentOwner;
			if (transform != null)
			{
				Transform transform2 = humanoidInstance?.GetAgentView<WorkerView>()?.BodyPreview?.CarryBodySocket;
				if (transform2 != null && transform.parent == transform2)
				{
					flag = true;
					transform.SetParent(null);
				}
			}
			if (!targetHumanoid.IsBeingCarried)
			{
				return;
			}
			targetHumanoid.IsBeingCarried = false;
			MonoSingleton<TaskController>.Instance.WaitForNextFrame().Then(delegate
			{
				MonoSingleton<AnimationController>.Instance.TriggerAgentAnimation(targetHumanoid, "Laydown");
			});
			if (condition == GoalCondition.Succeeded)
			{
				if (!target.IsInitialized)
				{
					Log.Warning("CarryToBedGoal Successful, but furniture not found! This should never happen", "C:\\GIT\\dev\\Assets\\Scripts\\GOAP\\Goal\\CarryToBedGoal.cs");
					return;
				}
				BedComponentInstance objectAs = target.GetObjectAs<BedComponentInstance>();
				if (MonoSingleton<ReservationManager>.Instance.IsReservedBy(objectAs, base.AgentOwner))
				{
					MonoSingleton<ReservationManager>.Instance.ReleaseAll(objectAs);
				}
				if (objectAs == null || !MonoSingleton<ReservationManager>.Instance.TryReserveObject(objectAs, targetHumanoid))
				{
					return;
				}
				Agent goapAgent = targetHumanoid.GetGoapAgent();
				if (goapAgent != null && goapAgent.CurrentGoalName.Equals("FaintGoal"))
				{
					targetHumanoid.SnapToBed(objectAs);
					if (objectAs.OwnerBuilding.BuildingOwnershipInfo != null && objectAs.OwnerBuilding.BuildingOwnershipInfo.Owner == null && objectAs.BaseBuildingBlueprint.CanHaveOwner)
					{
						objectAs.OwnerBuilding.BuildingOwnershipInfo.SetOwner(targetHumanoid, objectAs.OwnerBuilding);
					}
				}
			}
			else if (humanoidInstance != null)
			{
				Vector3 position = humanoidInstance.GetPosition();
				if (!(transform == null) && flag)
				{
					transform.position = position;
					targetHumanoid.UpdatePosition(position);
				}
			}
		}

		protected override IEnumerable<GoapAction> GetNextAction()
		{
			HumanoidInstance owner = (HumanoidInstance)base.AgentOwner;
			GoapAction goToTarget = GoToActions.GoToTarget(TargetIndex.A, PathCompleteMode.Touch).FailIfTargetDisposedForbidenOrNull(TargetIndex.A).FailIfTargetDisposedForbidenOrNull(TargetIndex.B);
			goToTarget.OnInit = delegate
			{
				HumanoidInstance objectAs = GetTarget(TargetIndex.A).GetObjectAs<HumanoidInstance>();
				if (objectAs == null || objectAs.IsBeingCarried)
				{
					goToTarget.Complete(ActionCompletionStatus.Fail);
				}
			};
			goToTarget.FailAtCondition(delegate
			{
				HumanoidInstance objectAs = GetTarget(TargetIndex.A).GetObjectAs<HumanoidInstance>();
				return objectAs == null || !objectAs.HasFainted;
			});
			goToTarget.FailIfTargetReservationReleases(TargetIndex.A);
			goToTarget.FailIfTargetReservationReleases(TargetIndex.B);
			yield return goToTarget;
			GoapAction goapAction = new GoapAction("PickupAction")
			{
				OnInit = delegate
				{
					HumanoidInstance objectAs = GetTarget(TargetIndex.A).GetObjectAs<HumanoidInstance>();
					Transform transform = objectAs.GetTransform();
					transform.SetParent(owner.GetAgentView<WorkerView>().BodyPreview.CarryBodySocket);
					transform.localPosition = Vector3.zero;
					transform.localEulerAngles = Vector3.zero;
					objectAs.UpdateRotation(Quaternion.Euler(Vector3.zero));
					objectAs.GetAgentView<AnimatedAgentView>().IsRotationLocked = true;
					objectAs.GetGoapAgent().DelayNextTick(999999f);
					objectAs.IsBeingCarried = true;
					MonoSingleton<AnimationController>.Instance.TriggerAgentAnimation(objectAs, "BeingCarried");
					MonoSingleton<AnimationController>.Instance.SetAnimatorParameter(owner, "IsCaringWorker", value: true);
				}
			};
			goapAction.FailIfTargetDisposedForbidenOrNull(TargetIndex.A);
			goapAction.FailIfTargetDisposedForbidenOrNull(TargetIndex.B);
			goapAction.FailIfTargetReservationReleases(TargetIndex.A);
			goapAction.FailIfTargetReservationReleases(TargetIndex.B);
			yield return goapAction;
			GoapAction goapAction2 = GoToActions.GoToTarget(TargetIndex.B, PathCompleteMode.Touch);
			goapAction2.FailIfTargetDisposedForbidenOrNull(TargetIndex.A);
			goapAction2.FailIfTargetDisposedForbidenOrNull(TargetIndex.B);
			goapAction2.FailIfTargetReservationReleases(TargetIndex.A);
			goapAction2.FailIfTargetReservationReleases(TargetIndex.B);
			goapAction2.FailAtCondition(() => GetTarget(TargetIndex.B).ObjectInstance is WorldObject worldObject && worldObject.IsOnFire);
			yield return goapAction2;
			GoapAction goapAction3 = new GoapAction("DropAction")
			{
				OnInit = delegate
				{
					HumanoidInstance objectAs = GetTarget(TargetIndex.A).GetObjectAs<HumanoidInstance>();
					BedComponentInstance objectAs2 = GetTarget(TargetIndex.B).GetObjectAs<BedComponentInstance>();
					objectAs.GetTransform().SetParent(null);
					objectAs.GetTransform().localPosition = Vector3.zero;
					objectAs.UpdatePosition(objectAs2.GetPosition());
					objectAs.SnapToBed(objectAs2);
					objectAs.GetGoapAgent().DelayNextTick(0.1f);
					MonoSingleton<HealthLogManager>.Instance.LogCarrying(base.AgentOwner, objectAs);
				}
			};
			goapAction3.FailIfTargetDisposedForbidenOrNull(TargetIndex.A);
			goapAction3.FailIfTargetDisposedForbidenOrNull(TargetIndex.B);
			goapAction3.FailIfTargetReservationReleases(TargetIndex.A);
			goapAction3.FailIfTargetReservationReleases(TargetIndex.B);
			yield return goapAction3;
		}

		private bool PrepareData()
		{
			if (!MonoSingleton<WorkerManager>.IsInstantiated())
			{
				return false;
			}
			BedComponentInstance optimalBed = null;
			float optimalBedScore = 0f;
			closestHumanoid = null;
			creatureCarrying = (HumanoidInstance)base.AgentOwner;
			float num = 0f;
			if (!base.PreferredReservableHandler.HasTarget())
			{
				foreach (HumanoidInstance item in MonoSingleton<WorkerManager>.Instance.FaintedWorkers.Where((HumanoidInstance item) => !item.IsBeingCarried && (item.GetGoapAgent()?.CurrentGoalName.Equals("FaintGoal") ?? false)))
				{
					if (!item.HasDisposed && MonoSingleton<ReservationManager>.Instance.GetReservedBed(item) == null && PathfinderUtil.IsPathPossible((IPathfindingAgent)base.AgentOwner, item.GetGridPosition()))
					{
						float num2 = Vector3.Distance(item.GetPosition(), creatureCarrying.GetPosition());
						if ((closestHumanoid == null || num2 < num) && MonoSingleton<ReservationManager>.Instance.CanReserve(item, base.AgentOwner) && !item.IsReceivingWoundTreatman)
						{
							num = num2;
							closestHumanoid = item;
						}
					}
				}
			}
			else if (PathfinderUtil.IsPathPossible((IPathfindingAgent)base.AgentOwner, base.PreferredReservableHandler.GetTarget().ReachablePosition))
			{
				closestHumanoid = base.PreferredReservableHandler.GetTarget().ObjectInstance as HumanoidInstance;
			}
			if (closestHumanoid == null)
			{
				return false;
			}
			SetTarget(TargetIndex.A, new TargetObject(closestHumanoid));
			if (!MonoSingleton<ReservationManager>.Instance.TryReserveObject(closestHumanoid, base.AgentOwner))
			{
				bool isEnabled;
				FVLogWarningInterpolationHandler messageBuilder = new FVLogWarningInterpolationHandler(57, 1, out isEnabled, "C:\\GIT\\dev\\Assets\\Scripts\\GOAP\\Goal\\CarryToBedGoal.cs");
				if (isEnabled)
				{
					messageBuilder.AppendLiteral("CarryToBedGoal could not reserve humanoid ");
					messageBuilder.AppendFormatted(closestHumanoid);
					messageBuilder.AppendLiteral(" to be carried.");
				}
				Log.Warning(messageBuilder);
				return false;
			}
			return PathfinderMedieval.ExploreForObjects(new ExploreRequest
			{
				Agent = (IPathfindingAgent)base.AgentOwner,
				GridData = GridDataType.Furniture,
				Condition = (WorldObject obj) => TendWoundsGoal.IsBedAvailableForMedicalTending(map.BedComponentManager.GetComponentInstance(obj), closestHumanoid),
				OnFound = delegate(WorldObject obj, Vec3Int pos)
				{
					BedComponentInstance componentInstance = map.BedComponentManager.GetComponentInstance(obj);
					if (componentInstance.IsUnavailable)
					{
						return P2RegionReservableWoExplorerPath.RegionExplorerCallbackResult.Skip;
					}
					float carryToBedScore = GetCarryToBedScore(componentInstance);
					if (optimalBed == null || carryToBedScore > optimalBedScore)
					{
						if (optimalBed != null)
						{
							MonoSingleton<ReservationManager>.Instance.ReleaseObject(optimalBed, base.AgentOwner);
						}
						optimalBedScore = carryToBedScore;
						optimalBed = componentInstance;
						if (MonoSingleton<ReservationManager>.Instance.TryReserveObject(optimalBed, base.AgentOwner))
						{
							SetTarget(TargetIndex.B, new TargetObject(optimalBed));
						}
						return P2RegionReservableWoExplorerPath.RegionExplorerCallbackResult.Continue;
					}
					return P2RegionReservableWoExplorerPath.RegionExplorerCallbackResult.Skip;
				}
			});
		}

		private float GetCarryToBedScore(BedComponentInstance bed)
		{
			float num = Vector3.Distance(creatureCarrying.GetPosition(), bed.GetPosition());
			float num2 = Vector3.Distance(closestHumanoid.GetPosition(), bed.GetPosition());
			float num3 = num + num2;
			if (bed.Blueprint.BedType == BedType.Medical)
			{
				num3 += 5000f;
			}
			Room room = bed.OwnerBuilding.GetRoom();
			if (room != null && room.RoomType.Medical)
			{
				num3 += 5000f;
			}
			BuildingOwnershipInfo buildingOwnershipInfo = bed.OwnerBuilding.BuildingOwnershipInfo;
			if (buildingOwnershipInfo != null && buildingOwnershipInfo.IsOwner(closestHumanoid))
			{
				num3 += 1000f;
			}
			return num3;
		}
	}
}
