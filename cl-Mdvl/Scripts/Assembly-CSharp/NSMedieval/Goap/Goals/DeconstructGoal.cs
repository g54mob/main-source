using System.Collections.Generic;
using FoxyVoxel.Logging;
using FoxyVoxel.Logging.Core.LogMessageInterpolationHandlers;
using NSEipix.Base;
using NSMedieval.BuildingComponents;
using NSMedieval.Construction;
using NSMedieval.Goap.Actions;
using NSMedieval.Manager;
using NSMedieval.Pathfinding;
using NSMedieval.State;
using NSMedieval.StatsSystem;
using NSMedieval.Village.Map;
using UnityEngine;

namespace NSMedieval.Goap.Goals
{
	public class DeconstructGoal : Goal
	{
		private const float DurationPercentage = 0.3f;

		private const float ResourcePercentage = 0.6f;

		private HumanoidInstance humanoidOwner;

		private bool isViaPreferredReservable;

		private bool allJobsAreBlocking;

		public BaseBuildingInstance TargetBuilding { get; private set; }

		public DeconstructGoal(Agent selfAgent)
			: base("DeconstructGoal", selfAgent)
		{
			humanoidOwner = (HumanoidInstance)base.AgentOwner;
			AddInitStep(base.PreferredReservableHandler.GetInitSequenceStep<BaseBuildingInstance>(preferLastTarget: false));
			AddInitStep(new ThreadSequenceStep(null, PrepareData));
		}

		public override bool AgentTypeCheck()
		{
			if (base.AgentOwner is IToolAgent toolAgent)
			{
				return toolAgent is IProductionAgent;
			}
			return false;
		}

		public override bool CanStart(bool isForced = false)
		{
			return base.ConstructionJobManager.HasDeconstructJobs;
		}

		public override void EndGoalWith(GoalCondition condition)
		{
			bool isEnabled;
			FVLogTraceInterpolationHandler messageBuilder = new FVLogTraceInterpolationHandler(8, 1, out isEnabled, "C:\\GIT\\dev\\Assets\\Scripts\\GOAP\\Goal\\DeconstructGoal.cs");
			if (isEnabled)
			{
				messageBuilder.AppendLiteral("EndGoal ");
				messageBuilder.AppendFormatted(base.AgentOwner);
			}
			Log.Trace(messageBuilder);
			base.ConstructionJobManager.ReleaseDestroyClaim(humanoidOwner);
			(base.AgentOwner as IToolAgent)?.HideTool();
			isViaPreferredReservable = false;
			base.EndGoalWith(condition);
		}

		protected override IEnumerable<GoapAction> GetNextAction()
		{
			IToolAgent agent = (IToolAgent)base.AgentOwner;
			BaseBuildingInstance building = null;
			MapNode buildingNode = null;
			float totalTime = 0f;
			float timeProgress = 0f;
			GoapAction selectNextTarget = GoalUtilActions.SelectNextTargetFromQueue(TargetIndex.A);
			selectNextTarget.OnComplete = delegate
			{
				TargetBuilding = GetTarget(TargetIndex.A).GetObjectAs<BaseBuildingInstance>();
			};
			yield return selectNextTarget;
			yield return GoToActions.GoToTarget(TargetIndex.A, PathCompleteMode.ExactPosition).FailIfTargetDisposedForbidenOrNull(TargetIndex.A).FailIfTargetIsNotType<BaseBuildingInstance>(TargetIndex.A)
				.FailIfTargetReservationReleases(TargetIndex.A)
				.FailAtCondition(FailWhenDeconstructCanceled);
			GoapAction deconstructAction = null;
			ConstructionParameters parameters;
			deconstructAction = new GoapAction("DeconstructAction")
			{
				CompleteMode = ActionCompleteMode.Never,
				OnInit = delegate
				{
					totalTime = 0f;
					timeProgress = 0f;
					agent.SetTool("hammer_item");
					building = GetTarget(TargetIndex.A).GetObjectAs<BaseBuildingInstance>();
					buildingNode = building.GetNode();
					parameters = building.Blueprint.ConstructionParameters;
					float attributeValue = agent.GetAttributeValue(parameters.DurationStat);
					float num = Mathf.Abs(building.GetRemainingBuildTimeRelativeToStartBuildTime());
					totalTime = num * 0.3f / attributeValue;
					IProductionAgent obj = (IProductionAgent)base.AgentOwner;
					float attributeValue2 = obj.GetAttributeValue(AttributeType.GlobalWorkSpeed);
					if (attributeValue2 != 0f)
					{
						totalTime /= attributeValue2;
					}
					float attributeValue3 = obj.GetAttributeValue(AttributeType.MotorFunction);
					if (attributeValue3 != 0f)
					{
						totalTime /= attributeValue3;
					}
					building.SetTotalWorkerBuildTime(totalTime);
					agent.GetGoapAgent().GetView().SetAudioEventParameter("HammerHit", new KeyValuePair<string, float>("Material", (float)building.Blueprint.SoundMaterialCategory));
				},
				OnTick = delegate(float deltaTime)
				{
					if (FailWhenDeconstructCanceled())
					{
						deconstructAction.Complete(ActionCompletionStatus.Fail);
					}
					else if (ShouldFailDeconstructAction())
					{
						deconstructAction.Complete(ActionCompletionStatus.Fail);
					}
					else if (deconstructAction.TotalTickingTime > 3f * totalTime)
					{
						deconstructAction.Complete(ActionCompletionStatus.Fail);
					}
					else
					{
						if (!isViaPreferredReservable && !base.ConstructionJobManager.IsDeconstructJobEnclosed(building))
						{
							MapNode mapNode = building.GetNode()?.GetNodeAbove();
							if (mapNode != null && totalTime - timeProgress < 2f * deltaTime && mapNode != agent.GetNode() && mapNode.CreaturesCount > 0)
							{
								return;
							}
						}
						timeProgress += deltaTime;
						if (timeProgress >= totalTime)
						{
							if (!isViaPreferredReservable && !allJobsAreBlocking && base.ConstructionJobManager.WouldDestroyJobEncloseRegion(building.GetNode(), reCalculateFloodFill: true))
							{
								deconstructAction.Complete(ActionCompletionStatus.Fail);
							}
							else
							{
								deconstructAction.Complete(ActionCompletionStatus.Success);
							}
						}
						else
						{
							building.SetRemainingTime(totalTime - timeProgress);
						}
					}
				},
				OnComplete = delegate(ActionCompletionStatus status)
				{
					agent.HideTool();
					if (building != null && !building.HasDisposed && status == ActionCompletionStatus.Success)
					{
						building.BuildingDeconstructed(agent.GetPosition());
					}
				}
			};
			yield return deconstructAction.FailIfTargetDisposedForbidenOrNull(TargetIndex.A).TriggerAnimation("Build", ActionAnimationMode.Interrupt);
			yield return JumpActions.JumpIfHaveTargetsInQueue(selectNextTarget, TargetIndex.A);
		}

		private bool ShouldFailDeconstructAction()
		{
			MapNode node = TargetBuilding.GetNode();
			MapNode node2 = humanoidOwner.GetNode();
			if (node != node2 && node.CreaturesCount > 0 && humanoidOwner.Map.CreaturesOnNodes.TryGetValue(node.Index, out var value))
			{
				foreach (CreatureBase item in value)
				{
					Goal goal = item?.GoapAgent?.GetCurrentGoal();
					if (goal != null)
					{
						if (goal is DeconstructGoal { TargetBuilding: not null } deconstructGoal && deconstructGoal.TargetBuilding.GetNode()?.GetNodeAbove() == node2 && humanoidOwner.UniqueId < item.UniqueId)
						{
							return true;
						}
						if (goal is DigGoal { DigMarker: not null } digGoal && digGoal.DigMarker.GetNode() == node2 && humanoidOwner.UniqueId < item.UniqueId)
						{
							return true;
						}
					}
				}
			}
			if (!isViaPreferredReservable && !allJobsAreBlocking && base.ConstructionJobManager.WouldDestroyJobEncloseRegion(TargetBuilding.GetNode()))
			{
				return true;
			}
			return false;
		}

		private bool PrepareData()
		{
			isViaPreferredReservable = false;
			IPathfindingAgent reserverAgent = (IPathfindingAgent)base.AgentOwner;
			ClearTargetsQueue(TargetIndex.A);
			if (base.PreferredReservableHandler.HasTarget())
			{
				TargetObject target = base.PreferredReservableHandler.GetTarget();
				if (MonoSingleton<ReservationManager>.Instance.TryReserveObject((IReservable)target.ObjectInstance, reserverAgent))
				{
					isViaPreferredReservable = true;
					QueueTarget(TargetIndex.A, target);
					return true;
				}
				base.PreferredReservableHandler.ClearTarget();
			}
			bool isEnabled;
			if (!base.ConstructionJobManager.TryReserveDeconstructJob(humanoidOwner, out var outJobs, out allJobsAreBlocking))
			{
				FVLogTraceInterpolationHandler messageBuilder = new FVLogTraceInterpolationHandler(8, 1, out isEnabled, "C:\\GIT\\dev\\Assets\\Scripts\\GOAP\\Goal\\DeconstructGoal.cs");
				if (isEnabled)
				{
					messageBuilder.AppendLiteral("No jobs ");
					messageBuilder.AppendFormatted(base.AgentOwner);
				}
				Log.Trace(messageBuilder);
				outJobs.Dispose();
				return false;
			}
			foreach (var (destroyVoxelJob, reachablePosition) in outJobs)
			{
				QueueTarget(TargetIndex.A, new TargetObject(destroyVoxelJob.Building, reachablePosition));
				FVLogTraceInterpolationHandler messageBuilder = new FVLogTraceInterpolationHandler(21, 2, out isEnabled, "C:\\GIT\\dev\\Assets\\Scripts\\GOAP\\Goal\\DeconstructGoal.cs");
				if (isEnabled)
				{
					messageBuilder.AppendLiteral("QueueTarget '");
					messageBuilder.AppendFormatted(destroyVoxelJob.Building);
					messageBuilder.AppendLiteral("' for '");
					messageBuilder.AppendFormatted(base.AgentOwner);
					messageBuilder.AppendLiteral("'");
				}
				Log.Trace(messageBuilder);
			}
			outJobs.Dispose();
			return true;
		}

		private bool FailWhenDeconstructCanceled()
		{
			return !TargetBuilding.MarkedForDestruction;
		}
	}
}
