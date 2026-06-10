using System.Collections.Generic;
using FoxyVoxel.Logging;
using FoxyVoxel.Logging.Core.LogMessageInterpolationHandlers;
using NSEipix.Base;
using NSMedieval.Controllers;
using NSMedieval.Goap.Actions;
using NSMedieval.Manager;
using NSMedieval.Pathfinding;
using NSMedieval.RoomDetection;
using NSMedieval.State;
using NSMedieval.Utils.Pool.Janitors;
using UnityEngine;

namespace NSMedieval.Goap.Goals
{
	public class WardenRoleGoal : RoleGoal
	{
		private const uint VisitHoursCooldown = 3u;

		private CaptiveLabourerBehaviour captiveLabourerTarget;

		public WardenRoleGoal(Agent selfAgent)
			: base("WardenRoleGoal", selfAgent, GoalInterruptMode.HigherPriority)
		{
			base.AllowedRoleId = "warden";
		}

		protected override IEnumerable<GoapAction> GetNextAction()
		{
			yield return GotoAction();
			yield return ForceLabourAction();
			yield return IdleAction();
		}

		private GoapAction IdleAction()
		{
			return new GoapAction("IdleAction");
		}

		private GoapAction GotoAction()
		{
			GoapAction goapAction = GoToActions.GoToTarget(TargetIndex.A, PathCompleteMode.ExactPosition).FailIfTargetDisposedOrNull(TargetIndex.A).FailAtCondition(base.RoleNotAssigned);
			goapAction.OnInit = delegate
			{
				EquipProp(equipped: true);
			};
			goapAction.OnComplete = delegate(ActionCompletionStatus state)
			{
				MonoSingleton<AnimationController>.Instance.ForceQuitAgentAnimation(base.AgentOwner);
				EquipProp(equipped: false);
				if (state == ActionCompletionStatus.Success)
				{
					base.HumanoidInstance.FaceObject(GetTarget(TargetIndex.A).ObjectInstance.GetPosition());
				}
			};
			return goapAction;
		}

		public override bool CanStart(bool isForced = false)
		{
			if (base.CanStart(false))
			{
				return ValidateNextTarget();
			}
			return false;
		}

		private GoapAction ForceLabourAction()
		{
			GoapAction goapAction = new GoapAction("ForceLabourAction");
			ActionEndingConditions.CompleteAfterTimeExpires(time: Random.value * 10f + 5f, action: goapAction.TriggerAnimation("WardenIdle", ActionAnimationMode.Interrupt)).FailAtCondition(base.RoleNotAssigned);
			goapAction.OnInit = delegate
			{
				captiveLabourerTarget.OnWardenForceLabour(base.HumanoidInstance.WorkerBehaviour);
			};
			goapAction.OnComplete = delegate
			{
				MonoSingleton<AnimationController>.Instance.ForceQuitAgentAnimation(base.AgentOwner);
				MonoSingleton<AnimationController>.Instance.SetAnimatorParameter(base.AgentOwner, "WardenIdle", value: false);
				EquipProp(equipped: false);
			};
			return goapAction;
		}

		protected override void AssignGoToTarget(Room room)
		{
			ValidateNextTarget();
		}

		private bool ValidateNextTarget()
		{
			if (GetTarget(TargetIndex.A).ObjectInstance != null)
			{
				return true;
			}
			captiveLabourerTarget = null;
			uint num = GlobalSaveController.CurrentVillageData.DateAndTime.HoursTotal - 3;
			using PooledList<CaptiveLabourerBehaviour> pooledList = MonoSingleton<NPCManager>.Instance.GetNPCsPooled<CaptiveLabourerBehaviour>();
			pooledList.Sort((CaptiveLabourerBehaviour a, CaptiveLabourerBehaviour b) => a.LastTimeVisitedByWarden.CompareTo(b.LastTimeVisitedByWarden));
			bool isEnabled;
			FVLogDebugInterpolationHandler messageBuilder;
			foreach (CaptiveLabourerBehaviour item in pooledList)
			{
				messageBuilder = new FVLogDebugInterpolationHandler(43, 1, out isEnabled, "C:\\GIT\\dev\\Assets\\Scripts\\GOAP\\Goal\\WardenRoleGoal.cs");
				if (isEnabled)
				{
					messageBuilder.AppendLiteral("WardenRoleGoal - Checking captive labourer ");
					messageBuilder.AppendFormatted(item.Humanoid.GetFullName());
				}
				Log.Debug(messageBuilder);
				if (item.Humanoid.HasDisposed || item.Humanoid.HasDied || item.Humanoid.HasFainted)
				{
					messageBuilder = new FVLogDebugInterpolationHandler(67, 1, out isEnabled, "C:\\GIT\\dev\\Assets\\Scripts\\GOAP\\Goal\\WardenRoleGoal.cs");
					if (isEnabled)
					{
						messageBuilder.AppendLiteral("WardenRoleGoal - Skipping ");
						messageBuilder.AppendFormatted(item.Humanoid.GetFullName());
						messageBuilder.AppendLiteral(" due to disposed, died, or fainted state.");
					}
					Log.Debug(messageBuilder);
					continue;
				}
				if (item.LastTimeVisitedByWarden >= num)
				{
					messageBuilder = new FVLogDebugInterpolationHandler(53, 3, out isEnabled, "C:\\GIT\\dev\\Assets\\Scripts\\GOAP\\Goal\\WardenRoleGoal.cs");
					if (isEnabled)
					{
						messageBuilder.AppendLiteral("WardenRoleGoal - Skipping ");
						messageBuilder.AppendFormatted(item.Humanoid.GetFullName());
						messageBuilder.AppendLiteral(" due to recent visit: ");
						messageBuilder.AppendFormatted(item.LastTimeVisitedByWarden);
						messageBuilder.AppendLiteral(" => ");
						messageBuilder.AppendFormatted(num);
						messageBuilder.AppendLiteral(".");
					}
					Log.Debug(messageBuilder);
					continue;
				}
				if (item.PrisonerAgent.CurrentHourType != HourType.Any && item.PrisonerAgent.CurrentHourType != HourType.Working)
				{
					messageBuilder = new FVLogDebugInterpolationHandler(63, 3, out isEnabled, "C:\\GIT\\dev\\Assets\\Scripts\\GOAP\\Goal\\WardenRoleGoal.cs");
					if (isEnabled)
					{
						messageBuilder.AppendLiteral("WardenRoleGoal - Skipping ");
						messageBuilder.AppendFormatted(item.Humanoid.GetFullName());
						messageBuilder.AppendLiteral(" due to incompatible hour type : ");
						messageBuilder.AppendFormatted(item.PrisonerAgent.CurrentHourType);
						messageBuilder.AppendLiteral(" != ");
						messageBuilder.AppendFormatted(HourType.Any);
					}
					Log.Debug(messageBuilder);
					continue;
				}
				messageBuilder = new FVLogDebugInterpolationHandler(55, 3, out isEnabled, "C:\\GIT\\dev\\Assets\\Scripts\\GOAP\\Goal\\WardenRoleGoal.cs");
				if (isEnabled)
				{
					messageBuilder.AppendLiteral("WardenRoleGoal - Found target ");
					messageBuilder.AppendFormatted(item.Humanoid.GetFullName());
					messageBuilder.AppendLiteral(" last time visited at ");
					messageBuilder.AppendFormatted(item.LastTimeVisitedByWarden);
					messageBuilder.AppendLiteral(" : ");
					messageBuilder.AppendFormatted(num);
				}
				Log.Debug(messageBuilder);
				captiveLabourerTarget = item;
				break;
			}
			if (captiveLabourerTarget == null)
			{
				Log.Debug("WardenRoleGoal - No suitable target found.", "C:\\GIT\\dev\\Assets\\Scripts\\GOAP\\Goal\\WardenRoleGoal.cs");
				ClearTargets();
				isEnabled = false;
				return isEnabled;
			}
			messageBuilder = new FVLogDebugInterpolationHandler(34, 1, out var isEnabled2, "C:\\GIT\\dev\\Assets\\Scripts\\GOAP\\Goal\\WardenRoleGoal.cs");
			if (isEnabled2)
			{
				messageBuilder.AppendLiteral("WardenRoleGoal - Target assigned: ");
				messageBuilder.AppendFormatted(captiveLabourerTarget.Humanoid.GetFullName());
			}
			Log.Debug(messageBuilder);
			SetTarget(TargetIndex.A, new TargetObject(captiveLabourerTarget.Humanoid));
			isEnabled = true;
			return isEnabled;
		}

		protected override void OnPropEquipCall(WorkerBodyPreview workerBodyPreview, bool equipped)
		{
			base.OnPropEquipCall(workerBodyPreview, equipped);
			workerBodyPreview.SetWardenPropsEnabled(equipped);
		}
	}
}
