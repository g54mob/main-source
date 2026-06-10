using System.Collections.Generic;
using System.Linq;
using FoxyVoxel.Logging;
using FoxyVoxel.Logging.Core.LogMessageInterpolationHandlers;
using NSEipix.Base;
using NSMedieval.BuildingComponents;
using NSMedieval.Controllers;
using NSMedieval.Goap.Actions;
using NSMedieval.PlayerTriggeredEventSystem;
using NSMedieval.State;
using NSMedieval.Village;
using UnityEngine;

namespace NSMedieval.Goap.Goals
{
	public class FeastEventGoal : EventBaseGoal
	{
		private const string ToolItem = "eating_bread_item";

		private bool feastAtTable;

		private bool feastOnChair;

		private bool isToolBound;

		protected virtual string EatAtTableEffector => (base.AgentOwner as HumanoidInstance)?.CurrentHumanType.EatAtTableEffector;

		protected virtual string EatWithoutTableEffector => (base.AgentOwner as HumanoidInstance)?.CurrentHumanType.EatWithoutTableEffector;

		public FeastEventGoal(Agent selfAgent)
			: base("FeastEventGoal", selfAgent)
		{
			AddInitStep(base.PreferredReservableHandler.GetInitSequenceStep<WorldObject>());
		}

		protected override IEnumerable<GoapAction> GetNextAction()
		{
			isToolBound = false;
			yield return GoToGatherPosition();
			yield return WaitForOthers();
			yield return FindEventPosition();
			if (TargetChairReserved)
			{
				yield return SitAction();
			}
			else
			{
				bool isEnabled;
				FVLogTraceInterpolationHandler messageBuilder = new FVLogTraceInterpolationHandler(22, 2, out isEnabled, "C:\\GIT\\dev\\Assets\\Scripts\\GOAP\\Goal\\FeastEventGoal.cs");
				if (isEnabled)
				{
					messageBuilder.AppendFormatted(base.HumanoidInstance.GetFullName());
					messageBuilder.AppendLiteral(" TargetChairReserved(");
					messageBuilder.AppendFormatted(TargetChairReserved);
					messageBuilder.AppendLiteral(")");
				}
				Log.Trace(messageBuilder);
			}
			yield return FeastAction();
		}

		private GoapAction FeastAction()
		{
			GoapAction feastAction = new GoapAction("FeastAction");
			feastAction.CompleteAtCondition(base.EventEnded).FailAtCondition(base.EventFailed);
			feastAction.OnInit = delegate
			{
				AnimationTrigger = ((feastOnChair || feastAtTable) ? "FeastSitting" : "FeastStanding");
				bool isEnabled;
				FVLogTraceInterpolationHandler messageBuilder = new FVLogTraceInterpolationHandler(72, 4, out isEnabled, "C:\\GIT\\dev\\Assets\\Scripts\\GOAP\\Goal\\FeastEventGoal.cs");
				if (isEnabled)
				{
					messageBuilder.AppendFormatted(base.HumanoidInstance.GetFullName());
					messageBuilder.AppendLiteral(" FeastAction.OnInit. AnimationTrigger(");
					messageBuilder.AppendFormatted(AnimationTrigger);
					messageBuilder.AppendLiteral("), feastAtTable(");
					messageBuilder.AppendFormatted(feastAtTable);
					messageBuilder.AppendLiteral("), feastOnChair:(");
					messageBuilder.AppendFormatted(feastOnChair);
					messageBuilder.AppendLiteral(")");
				}
				Log.Trace(messageBuilder);
				feastAction.TriggerAnimation(AnimationTrigger, ActionAnimationMode.Interrupt, GetTarget(TargetIndex.B).IsInitialized);
				if (!isToolBound && !string.IsNullOrEmpty("eating_bread_item") && base.AgentOwner is IToolAgent toolAgent)
				{
					isToolBound = true;
					toolAgent.SetTool("eating_bread_item");
				}
			};
			feastAction.OnComplete = delegate
			{
				MonoSingleton<AnimationController>.Instance.SetAnimatorParameter(base.AgentOwner, AnimationTrigger, value: false);
				if (base.AgentOwner.GetGoapAgent() is WorkerGoapAgent workerGoapAgent)
				{
					workerGoapAgent.LeavePlayerTriggeredEvent();
					((IToolAgent)base.AgentOwner).HideTool();
				}
			};
			return feastAction;
		}

		protected override GoapAction SitAction()
		{
			bool hasTable = false;
			bool hasChair = false;
			GoapAction sitAction = GeneralActions.Instant().TriggerAnimation("ChairSit", ActionAnimationMode.WaitForCompletion).SkipIfTargetDisposedForbidenOrNull(TargetIndex.B)
				.SkipIfTargetReservationReleases(TargetIndex.B);
			sitAction.OnPreInit = delegate
			{
				bool isEnabled;
				if (sitAction.HasCompleted)
				{
					FVLogTraceInterpolationHandler messageBuilder = new FVLogTraceInterpolationHandler(85, 1, out isEnabled, "C:\\GIT\\dev\\Assets\\Scripts\\GOAP\\Goal\\FeastEventGoal.cs");
					if (isEnabled)
					{
						messageBuilder.AppendFormatted(base.HumanoidInstance.GetFullName());
						messageBuilder.AppendLiteral(" SitAction.OnPreInit. Already completed by some other conditions. Aborting SitAction.");
					}
					Log.Trace(messageBuilder);
				}
				else
				{
					if (!string.IsNullOrEmpty("eating_bread_item") && base.AgentOwner is IToolAgent toolAgent)
					{
						toolAgent.SetTool("eating_bread_item");
						isToolBound = true;
					}
					ChairComponentInstance objectAs = GetTarget(TargetIndex.B).GetObjectAs<ChairComponentInstance>();
					TableComponentInstance tableComponentInstance = objectAs?.TablesNearby?.FirstOrDefault();
					hasTable = tableComponentInstance != null;
					hasChair = objectAs != null;
					FVLogTraceInterpolationHandler messageBuilder = new FVLogTraceInterpolationHandler(19, 3, out isEnabled, "C:\\GIT\\dev\\Assets\\Scripts\\GOAP\\Goal\\FeastEventGoal.cs");
					if (isEnabled)
					{
						messageBuilder.AppendFormatted(base.HumanoidInstance.GetFullName());
						messageBuilder.AppendLiteral(" hasTable:");
						messageBuilder.AppendFormatted(hasTable);
						messageBuilder.AppendLiteral(" hasChair");
						messageBuilder.AppendFormatted(hasChair);
					}
					Log.Trace(messageBuilder);
					if (objectAs != null && base.AgentOwner is IPathfindingAgent pathfindingAgent)
					{
						pathfindingAgent.PathDriver.Teleport(objectAs.GridDataPosition);
					}
					if (tableComponentInstance == null)
					{
						if (objectAs != null)
						{
							Vector3 objectPosition = base.Agent.GetView().transform.position + Quaternion.Euler(0f, objectAs.Angle, 0f) * Vector3.right;
							base.Agent.GetView().FaceObject(objectPosition);
						}
					}
					else
					{
						Vec3Int gridPos = Vec3Int.zero;
						float num = 0f;
						foreach (Vec3Int position in tableComponentInstance.Positions)
						{
							Vec3Int a = position;
							if (gridPos.Equals(Vec3Int.zero) || Vec3Int.Distance(in a, objectAs.GridDataPosition) < num)
							{
								num = Vec3Int.Distance(in a, objectAs.GridDataPosition);
								gridPos = a;
							}
						}
						base.Agent.GetView().FaceObject(GridUtils.GetWorldPosition(gridPos));
					}
				}
			};
			sitAction.OnComplete = delegate(ActionCompletionStatus status)
			{
				if (status == ActionCompletionStatus.Success)
				{
					feastAtTable = hasTable && hasChair;
					feastOnChair = !hasTable && hasChair;
					if (base.AgentOwner is HumanoidInstance { WorkerBehaviour: not null } humanoidInstance)
					{
						ChairComponentBlueprint chairComponentBlueprint = GetTarget(TargetIndex.B).GetObjectAs<ChairComponentInstance>()?.Blueprint;
						if (!(chairComponentBlueprint == null))
						{
							foreach (string workerEffector in chairComponentBlueprint.WorkerEffectors)
							{
								if (!string.IsNullOrEmpty(workerEffector))
								{
									humanoidInstance.Stats.StartEffector(workerEffector);
								}
							}
						}
					}
				}
			};
			sitAction.SetMinimumDurationTime(1f);
			return sitAction;
		}

		protected override bool FindTargets()
		{
			if (!(GetEventInstance() is FeastEventInstance))
			{
				return false;
			}
			SetGatheringPositionTarget();
			SetEventPositionTarget();
			return true;
		}

		protected override PlayerTriggeredEventInstance GetEventInstance()
		{
			if (!(MonoSingleton<PlayerTriggeredEventManager>.Instance.CurrentEvent is FeastEventInstance result))
			{
				return null;
			}
			return result;
		}

		public override void EndGoalWith(GoalCondition condition)
		{
			base.EndGoalWith(condition);
			if (!string.IsNullOrEmpty("eating_bread_item") && base.AgentOwner is IToolAgent toolAgent)
			{
				toolAgent.HideTool();
			}
			if (!(base.AgentOwner is CreatureBase { HasDisposed: false } creatureBase))
			{
				return;
			}
			if (feastAtTable && !string.IsNullOrEmpty(EatAtTableEffector))
			{
				creatureBase.Stats.StartEffector(EatAtTableEffector);
			}
			if (feastOnChair && !string.IsNullOrEmpty(EatWithoutTableEffector))
			{
				creatureBase.Stats.StartEffector(EatWithoutTableEffector);
			}
			if ((!feastAtTable && !feastOnChair) || !(base.AgentOwner is HumanoidInstance { WorkerBehaviour: not null } humanoidInstance))
			{
				return;
			}
			TargetObject target = GetTarget(TargetIndex.B);
			humanoidInstance.WorkerBehaviour.WorkerInteraction.FireInteractionEvent("ate_at_table");
			ChairComponentBlueprint chairComponentBlueprint = target.GetObjectAs<ChairComponentInstance>()?.Blueprint;
			if (!(chairComponentBlueprint != null))
			{
				return;
			}
			foreach (string workerEffector in chairComponentBlueprint.WorkerEffectors)
			{
				if (!string.IsNullOrEmpty(workerEffector))
				{
					humanoidInstance.Stats.EndEffector(workerEffector);
				}
			}
		}
	}
}
