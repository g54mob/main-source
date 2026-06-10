using FoxyVoxel.Logging;
using FoxyVoxel.Logging.Core.LogMessageInterpolationHandlers;
using GOAP.Action;
using NSEipix;
using NSEipix.Base;
using NSMedieval.BuildingComponents;
using NSMedieval.Controllers;
using NSMedieval.Goap.Actions;
using NSMedieval.Manager;
using NSMedieval.State;
using NSMedieval.View;
using NSMedieval.Village;
using UnityEngine;

namespace NSMedieval.Goap.Goals
{
	public abstract class EventBaseGoalRole : EventBaseGoal
	{
		protected AnimatedAgentView AnimatedAgentView
		{
			get
			{
				if (Participant is HumanoidInstance { WorkerBehaviour: not null } humanoidInstance)
				{
					AnimatedAgentView view = MonoSingleton<WorkerManager>.Instance.GetView(humanoidInstance);
					if ((object)view != null)
					{
						return view;
					}
				}
				if (Participant is HumanoidInstance instance)
				{
					AnimatedAgentView view2 = MonoSingleton<NPCManager>.Instance.GetView(instance);
					if ((object)view2 != null)
					{
						return view2;
					}
				}
				return null;
			}
		}

		protected EventBaseGoalRole(string id, Agent selfAgent, GoalInterruptMode interruptMode = GoalInterruptMode.None)
			: base(id, selfAgent, interruptMode)
		{
			AddInitStep(new ThreadSequenceStep(null, FindTargets));
		}

		protected abstract void EquipProp(bool equipped);

		public override void EndGoalWith(GoalCondition condition)
		{
			base.EndGoalWith(condition);
			if (AnimatedAgentView is WorkerView workerView)
			{
				workerView.TrySetRoleActive();
			}
			IPathfindingAgent pathfindingAgent = base.AgentOwner as IPathfindingAgent;
			if (pathfindingAgent?.PathDriver != null)
			{
				pathfindingAgent.PathDriver.IsFloatingAllowed = false;
			}
		}

		protected override bool FindTargets()
		{
			SetGatheringPositionTarget();
			SetTarget(TargetIndex.B, new TargetObject(GetEventInstance().GetEventPosition(Participant)));
			bool isEnabled;
			FVLogDebugInterpolationHandler messageBuilder = new FVLogDebugInterpolationHandler(22, 2, out isEnabled, "C:\\GIT\\dev\\Assets\\Scripts\\GOAP\\Goal\\EventBaseGoalRole.cs");
			if (isEnabled)
			{
				messageBuilder.AppendLiteral("Finding Target for ");
				messageBuilder.AppendFormatted(Participant);
				messageBuilder.AppendLiteral(":  ");
				messageBuilder.AppendFormatted(GetEventInstance().GetEventPosition(Participant));
			}
			Log.Debug(messageBuilder);
			return true;
		}

		protected GoapAction EventRoleAction(string idleAnimationTrigger)
		{
			GoapAction action = new GoapAction("EventRoleAction");
			action.CompleteAtCondition(base.EventEnded).FailAtCondition(base.EventFailed);
			action.OnInit = delegate
			{
				AnimatedAgentView.TrySetParameter("RoleActive", value: true);
				EquipProp(equipped: true);
				action.TriggerAnimation(idleAnimationTrigger, ActionAnimationMode.Interrupt, GetTarget(TargetIndex.B).IsInitialized);
			};
			action.OnComplete = delegate
			{
				AnimatedAgentView.TrySetParameter("RoleActive", value: false);
				MonoSingleton<AnimationController>.Instance.ForceQuitAgentAnimation(base.AgentOwner);
				EquipProp(equipped: false);
				if (base.AgentOwner.GetGoapAgent() is WorkerGoapAgent workerGoapAgent)
				{
					workerGoapAgent.LeavePlayerTriggeredEvent();
				}
			};
			return action;
		}

		protected GoapAction SnapToWorkPosition()
		{
			GoapAction action = new GoapAction("SnapToWorkPosition");
			action.CompleteAfterTimeExpires(0.3f).FailAtCondition(base.EventFailed).FailAtCondition(base.EventEnded)
				.AllowPathDriverFloating();
			action.OnInit = delegate
			{
				DecorationComponentInstance componentInstance = GetEventInstance().HostBuilding.GetComponentInstance<DecorationComponentInstance>();
				if (componentInstance == null)
				{
					Log.Error("DecorationComponentInstance is null!", "C:\\GIT\\dev\\Assets\\Scripts\\GOAP\\Goal\\EventBaseGoalRole.cs");
				}
				else
				{
					DecorationComponent component = VillageManager.ActiveVillage.Map.DecorationComponentManager.GetComponent(componentInstance);
					if (component == null)
					{
						Log.Error("DecorationComponent is null!", "C:\\GIT\\dev\\Assets\\Scripts\\GOAP\\Goal\\EventBaseGoalRole.cs");
					}
					else
					{
						Transform targetTransform = component.UsePositionsComponent.GetUsePositionTransform(base.HumanoidInstance.GetPosition());
						if (!targetTransform)
						{
							Log.Error("targetTransform is null!", "C:\\GIT\\dev\\Assets\\Scripts\\GOAP\\Goal\\EventBaseGoalRole.cs");
						}
						else
						{
							IPathfindingAgent pathfindingAgent = (IPathfindingAgent)action.AgentOwner;
							MonoSingleton<TaskController>.Instance.WaitForNextFrameUnscaled().Then(delegate
							{
								if ((bool)targetTransform)
								{
									HumanoidInstance humanoidInstance = base.HumanoidInstance;
									if (humanoidInstance != null && !humanoidInstance.HasDisposed)
									{
										base.HumanoidInstance?.FaceObject(targetTransform);
										pathfindingAgent?.PathDriver?.Teleport(targetTransform.position);
									}
								}
							}).ThenWaitFor(0.01f)
								.Then(delegate
								{
									if ((bool)targetTransform)
									{
										HumanoidInstance humanoidInstance = base.HumanoidInstance;
										if (humanoidInstance != null && !humanoidInstance.HasDisposed)
										{
											base.HumanoidInstance?.UpdateRotation(targetTransform.rotation);
										}
									}
								});
						}
					}
				}
			};
			action.OnComplete = delegate(ActionCompletionStatus status)
			{
				bool isEnabled;
				FVLogTraceInterpolationHandler messageBuilder = new FVLogTraceInterpolationHandler(30, 1, out isEnabled, "C:\\GIT\\dev\\Assets\\Scripts\\GOAP\\Goal\\EventBaseGoalRole.cs");
				if (isEnabled)
				{
					messageBuilder.AppendLiteral("SnapToWorkPosition completed! ");
					messageBuilder.AppendFormatted(status);
				}
				Log.Trace(messageBuilder);
			};
			return action;
		}
	}
}
