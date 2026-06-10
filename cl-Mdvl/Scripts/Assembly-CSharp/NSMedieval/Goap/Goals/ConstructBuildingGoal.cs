using System.Collections.Generic;
using FoxyVoxel.Logging;
using FoxyVoxel.Logging.Core.LogMessageInterpolationHandlers;
using NSEipix.Base;
using NSMedieval.BuildingComponents;
using NSMedieval.Construction;
using NSMedieval.Controllers;
using NSMedieval.Goap.Actions;
using NSMedieval.Manager;
using NSMedieval.Model;
using NSMedieval.Pathfinding;
using NSMedieval.State;
using NSMedieval.StatsSystem;
using NSMedieval.UI.Utils;
using NSMedieval.View;
using NSMedieval.Village;
using NSMedieval.Village.Map;
using NSMedieval.Water;
using UnityEngine;

namespace NSMedieval.Goap.Goals
{
	public class ConstructBuildingGoal : Goal
	{
		private const float DefaultInstallMultiplier = 0.3f;

		private const float WaterMultiplier = 2f;

		private const float LerpSpeed = 8f;

		private int totalXpGained;

		private SkillType lastRewardedSkill;

		private float samplePreviousBuildProgressPoint;

		private float sampleCurrentBuildProgressPoint;

		private bool isCurrentBuildProgressSampled;

		private bool isPreviousBuildProgressSampled;

		private float buildProgress;

		private float lerpProgress;

		private bool failedBecauseOfJobManager;

		private bool isViaPreferredReservable;

		private bool allJobsAreBlocking;

		public ConstructBuildingGoal(Agent selfAgent)
			: base("ConstructBuildingGoal", selfAgent, GoalInterruptMode.HigherPriority)
		{
			AddInitStep(base.PreferredReservableHandler.GetInitSequenceStep<BaseBuildingInstance>(preferLastTarget: false));
			AddInitStep(new ThreadSequenceStep(null, PrepareData));
		}

		public override bool AgentTypeCheck()
		{
			return base.AgentOwner is HumanoidInstance;
		}

		public override bool CanStart(bool isForced = false)
		{
			return base.ConstructionJobManager.HasCreateVoxelJobs;
		}

		public override void EndGoalWith(GoalCondition condition)
		{
			base.ConstructionJobManager.ReleaseCreateClaim(base.AgentOwner as HumanoidInstance);
			if (!MonoSingleton<WorkerManager>.IsInstantiated())
			{
				base.EndGoalWith(condition);
				return;
			}
			if (base.AgentOwner == null)
			{
				base.EndGoalWith(condition);
				return;
			}
			((IToolAgent)base.AgentOwner).HideTool();
			totalXpGained = 0;
			lastRewardedSkill = SkillType.None;
			base.EndGoalWith(condition);
			bool isEnabled;
			FVLogTraceInterpolationHandler messageBuilder = new FVLogTraceInterpolationHandler(8, 1, out isEnabled, "C:\\GIT\\dev\\Assets\\Scripts\\GOAP\\Goal\\ConstructBuildingGoal.cs");
			if (isEnabled)
			{
				messageBuilder.AppendLiteral("EndGoal ");
				messageBuilder.AppendFormatted(base.AgentOwner);
			}
			Log.Trace(messageBuilder);
		}

		public override void HandleConsecutiveFail()
		{
			if (GetTarget(TargetIndex.A).IsInitialized && !failedBecauseOfJobManager)
			{
				BaseBuildingInstance objectAs = GetTarget(TargetIndex.A).GetObjectAs<BaseBuildingInstance>();
				if (objectAs != null)
				{
					objectAs.IsForbidden = true;
					string localizedName = BuildingUtils.GetLocalizedName(objectAs.Blueprint.GetID());
					string messageText = MonoSingleton<LocalizationController>.Instance.GetText("error_autoforbid_message").Replace("<object>", localizedName);
					MonoSingleton<BlackBarMessageController>.Instance.ShowClickableBlackBarMessage(messageText, objectAs.WorldPosition);
				}
			}
		}

		public override bool CanBeInterrupted()
		{
			if (isViaPreferredReservable)
			{
				return false;
			}
			if (base.TotalTickingTime >= 1f)
			{
				return base.CanBeInterrupted();
			}
			return false;
		}

		protected override IEnumerable<GoapAction> GetNextAction()
		{
			HumanoidInstance agent = (HumanoidInstance)base.AgentOwner;
			ConstructionParameters parameters = null;
			float totalTime = 0f;
			float checkFailChanceTime = 0f;
			float agentFailChance = 0f;
			float xpPerSecond = 0f;
			float xpCheckTime = 0f;
			float xpGained = 0f;
			IProductionAgent productionAgent = (IProductionAgent)base.AgentOwner;
			bool experienceReceived = false;
			MapNode buildingNode = null;
			BaseBuildingInstance building = null;
			float timeProgress = 0f;
			GoapAction selectNextTarget = GoalUtilActions.SelectNextTargetFromQueue(TargetIndex.A);
			yield return selectNextTarget;
			yield return GoToActions.GoToTarget(TargetIndex.A, PathCompleteMode.ExactPosition).FailIfTargetDisposedForbidenOrNull(TargetIndex.A).FailIfTargetIsNotType<BaseBuildingInstance>(TargetIndex.A)
				.FailIfTargetReservationReleases(TargetIndex.A);
			GoapAction buildAction = new GoapAction("ConstructAction")
			{
				CompleteMode = ActionCompleteMode.Never
			};
			buildAction.OnInit = delegate
			{
				totalTime = 0f;
				checkFailChanceTime = 0f;
				agentFailChance = 0f;
				xpPerSecond = 0f;
				xpCheckTime = 0f;
				xpGained = 0f;
				experienceReceived = false;
				timeProgress = 0f;
				building = GetTarget(TargetIndex.A).GetObjectAs<BaseBuildingInstance>();
				bool isEnabled;
				FVLogTraceInterpolationHandler messageBuilder = new FVLogTraceInterpolationHandler(23, 2, out isEnabled, "C:\\GIT\\dev\\Assets\\Scripts\\GOAP\\Goal\\ConstructBuildingGoal.cs");
				if (isEnabled)
				{
					messageBuilder.AppendLiteral("Set building '");
					messageBuilder.AppendFormatted(building);
					messageBuilder.AppendLiteral("', agent ");
					messageBuilder.AppendFormatted(base.AgentOwner);
				}
				Log.Trace(messageBuilder);
				buildingNode = building.GetNode();
				string buildItem = building.Blueprint.BuildItem;
				if (buildItem != string.Empty)
				{
					agent.SetTool(buildItem);
				}
				parameters = building.Blueprint.ConstructionParameters;
				float attributeValue = agent.GetAttributeValue(parameters.DurationStat);
				float num = Mathf.Abs(building.GetRemainingBuildTimeRelativeToStartBuildTime());
				if (building.IsMoveBlueprint)
				{
					float num2 = ((building.Blueprint.InstallationMultiplier > 0f) ? building.Blueprint.InstallationMultiplier : 0.3f);
					totalTime = num * num2 / attributeValue;
				}
				else
				{
					totalTime = num / attributeValue;
				}
				float attributeValue2 = productionAgent.GetAttributeValue(AttributeType.GlobalWorkSpeed);
				if (attributeValue2 != 0f)
				{
					totalTime /= attributeValue2;
				}
				float attributeValue3 = productionAgent.GetAttributeValue(AttributeType.MotorFunction);
				if (attributeValue3 != 0f)
				{
					totalTime /= attributeValue3;
				}
				WaterDepthLevel waterLevelAsDepth = building.Map.WaterManager.GetWaterLevelAsDepth(building.GridDataPosition);
				if (waterLevelAsDepth == WaterDepthLevel.Medium || waterLevelAsDepth == WaterDepthLevel.High)
				{
					totalTime *= 2f;
					agentFailChance = agent.GetAttributeValue(parameters.FailStat) * 2f;
				}
				else
				{
					agentFailChance = agent.GetAttributeValue(parameters.FailStat);
				}
				checkFailChanceTime = Random.Range(0f, totalTime);
				xpPerSecond = num / totalTime;
				xpCheckTime = 0f;
				xpGained = 0f;
				building.SetTotalWorkerBuildTime(totalTime);
				string triggerName = "Build";
				if (building.Blueprint.BuildAnimationTrigger != string.Empty)
				{
					triggerName = building.Blueprint.BuildAnimationTrigger;
				}
				buildAction.TriggerAnimation(triggerName, ActionAnimationMode.Interrupt);
				building.ConstructionStarted();
				agent.GetGoapAgent().GetView().SetAudioEventParameter("HammerHit", new KeyValuePair<string, float>("Material", (float)building.Blueprint.SoundMaterialCategory));
			};
			buildAction.OnTick = delegate(float delta)
			{
				if (buildAction.TotalTickingTime > 3f * totalTime)
				{
					failedBecauseOfJobManager = true;
					buildAction.Complete(ActionCompletionStatus.Fail);
				}
				else if (!(totalTime - timeProgress < 2f * delta) || buildingNode == agent.GetNode() || buildingNode.CreaturesCount <= 0)
				{
					if (ShouldFailEncloseRegion(building))
					{
						failedBecauseOfJobManager = true;
						buildAction.Complete(ActionCompletionStatus.Fail);
					}
					else
					{
						timeProgress += delta;
						if (timeProgress >= totalTime)
						{
							if (ShouldFailEncloseRegion(building, reCalculateFloodFill: true))
							{
								failedBecauseOfJobManager = true;
								buildAction.Complete(ActionCompletionStatus.Fail);
							}
							else
							{
								buildAction.Complete(ActionCompletionStatus.Success);
							}
						}
						else
						{
							if (timeProgress >= checkFailChanceTime && !building.IsMoveBlueprint && !building.Blueprint.CantFailConstruction)
							{
								checkFailChanceTime = float.MaxValue;
								float num = Random.Range(0f, 1f);
								float attributeValue = productionAgent.GetAttributeValue(AttributeType.Clumsiness);
								if (num / attributeValue < agentFailChance)
								{
									bool isEnabled;
									FVLogTraceInterpolationHandler messageBuilder = new FVLogTraceInterpolationHandler(44, 1, out isEnabled, "C:\\GIT\\dev\\Assets\\Scripts\\GOAP\\Goal\\ConstructBuildingGoal.cs");
									if (isEnabled)
									{
										messageBuilder.AppendLiteral("Construction failed (dice roll) for agent '");
										messageBuilder.AppendFormatted(base.AgentOwner);
										messageBuilder.AppendLiteral("'");
									}
									Log.Trace(messageBuilder);
									buildAction.Complete(ActionCompletionStatus.Fail);
									return;
								}
							}
							if (!isPreviousBuildProgressSampled)
							{
								samplePreviousBuildProgressPoint = totalTime - timeProgress;
								isPreviousBuildProgressSampled = true;
							}
							if (agent.IsBulidProgressAlowed)
							{
								if (!isCurrentBuildProgressSampled)
								{
									building.PlayBuildParticles();
									sampleCurrentBuildProgressPoint = totalTime - timeProgress;
									isCurrentBuildProgressSampled = true;
								}
								lerpProgress = timeProgress * 8f;
								buildProgress = Mathf.Lerp(samplePreviousBuildProgressPoint, sampleCurrentBuildProgressPoint, lerpProgress);
								building.SetRemainingTime(buildProgress);
								if (lerpProgress >= 1f)
								{
									samplePreviousBuildProgressPoint = sampleCurrentBuildProgressPoint;
									isCurrentBuildProgressSampled = false;
									lerpProgress = 0f;
									agent.IsBulidProgressAlowed = false;
								}
							}
							if (!building.IsMoveBlueprint && !(timeProgress - xpCheckTime <= 1f))
							{
								xpCheckTime = timeProgress;
								xpGained += xpPerSecond;
								if (xpGained % 1f > 0f)
								{
									experienceReceived = true;
									AddXp(agent, xpPerSecond, parameters.RewardedSkill);
								}
							}
						}
					}
				}
			};
			buildAction.OnComplete = delegate(ActionCompletionStatus status)
			{
				bool isEnabled;
				FVLogTraceInterpolationHandler messageBuilder = new FVLogTraceInterpolationHandler(23, 1, out isEnabled, "C:\\GIT\\dev\\Assets\\Scripts\\GOAP\\Goal\\ConstructBuildingGoal.cs");
				if (isEnabled)
				{
					messageBuilder.AppendLiteral("BuildAction.OnComplete ");
					messageBuilder.AppendFormatted(base.AgentOwner);
				}
				Log.Trace(messageBuilder);
				agent.HideTool();
				if (totalXpGained > 0 && lastRewardedSkill != SkillType.None && base.AgentOwner is HumanoidInstance { WorkerBehaviour: not null } humanoidInstance)
				{
					if (building != null)
					{
						building.SetProducerUniqueId(humanoidInstance.UniqueId);
					}
					WorkerView agentView = humanoidInstance.GetAgentView<WorkerView>();
					if (agentView == null)
					{
						FVLogErrorInterpolationHandler messageBuilder2 = new FVLogErrorInterpolationHandler(67, 1, out isEnabled, "C:\\GIT\\dev\\Assets\\Scripts\\GOAP\\Goal\\ConstructBuildingGoal.cs");
						if (isEnabled)
						{
							messageBuilder2.AppendLiteral("Construct building goal ended. Humanoid view is null. Humanoid ID: ");
							messageBuilder2.AppendFormatted(humanoidInstance.Info.GetFullName());
						}
						Log.Error(messageBuilder2);
					}
					else
					{
						agentView.ShowExperienceAddedPopup(lastRewardedSkill, totalXpGained);
					}
				}
				if (status == ActionCompletionStatus.Fail && base.State != GoalState.Ended)
				{
					if (building != null && !building.HasDisposed)
					{
						if (failedBecauseOfJobManager)
						{
							building.SetRemainingTime(building.Blueprint.BuildTime);
						}
						else
						{
							DropAllResources(building, agent.GetPosition());
							building.ConstructionFailed();
							DamagePopup.Create(building.WorldPosition, MonoSingleton<LocalizationController>.Instance.GetText("construction_failed"));
							if (base.AgentOwner is HumanoidInstance { WorkerBehaviour: not null } humanoidInstance2)
							{
								humanoidInstance2.WorkerBehaviour.WorkerProximity.OnConstructionFailed();
							}
						}
					}
				}
				else if (status != ActionCompletionStatus.Success)
				{
					building.ConstructionPaused();
				}
				else if (!building.HasDisposed)
				{
					building.SetRemainingTime(0f);
					building.ConstructionCompleted();
					if (!experienceReceived && !building.IsMoveBlueprint)
					{
						AddXp(agent, xpPerSecond, parameters.RewardedSkill);
					}
					isPreviousBuildProgressSampled = false;
					isCurrentBuildProgressSampled = false;
					lerpProgress = 0f;
				}
			};
			yield return buildAction.FailIfTargetDisposedForbidenOrNull(TargetIndex.A).FailIfTargetReservationReleases(TargetIndex.A).FailAtCondition(() => building?.OverlapsWithSleepingCreature() ?? false);
			yield return JumpActions.JumpIfHaveTargetsInQueue(selectNextTarget, TargetIndex.A);
		}

		private bool ShouldFailEncloseRegion(BaseBuildingInstance building, bool reCalculateFloodFill = false)
		{
			if (isViaPreferredReservable || building == null)
			{
				return false;
			}
			if (!allJobsAreBlocking)
			{
				return base.ConstructionJobManager.WouldJobEncloseRegion(building, reCalculateFloodFill);
			}
			return false;
		}

		private bool PrepareData()
		{
			FVLogTraceInterpolationHandler messageBuilder = new FVLogTraceInterpolationHandler(19, 1, out var isEnabled, "C:\\GIT\\dev\\Assets\\Scripts\\GOAP\\Goal\\ConstructBuildingGoal.cs");
			if (isEnabled)
			{
				messageBuilder.AppendLiteral("Start prepare data ");
				messageBuilder.AppendFormatted(base.AgentOwner);
			}
			Log.Trace(messageBuilder);
			totalXpGained = 0;
			failedBecauseOfJobManager = false;
			isViaPreferredReservable = false;
			ClearTargetsQueue(TargetIndex.A);
			if (base.PreferredReservableHandler.HasTarget())
			{
				IPathfindingAgent pathfindingAgent = (IPathfindingAgent)base.AgentOwner;
				BaseBuildingInstance objectAs = base.PreferredReservableHandler.GetTarget().GetObjectAs<BaseBuildingInstance>();
				if (objectAs != null && objectAs.ConstructionPhase == ConstructionPhase.Foundation && objectAs.IsBlueprintOnClearNode() && !objectAs.IsForbidden && !objectAs.OverlapsWithSleepingCreature())
				{
					List<WorldObject> targets = new List<WorldObject> { objectAs };
					List<TargetObject> list = PathfinderMedieval.FindMedievalObjects<BaseBuildingInstance>(pathfindingAgent, targets);
					if (list != null)
					{
						foreach (TargetObject item in list)
						{
							MapNode node = VillageManager.ActiveVillage.Map.GetNode(item.ReachablePosition);
							MapNode nodeAbove = node.GetNodeAbove();
							if ((node.WaterLevel != WaterDepthLevel.High || nodeAbove == null || !nodeAbove.IsWater || nodeAbove.WaterLevel == WaterDepthLevel.Low) && MonoSingleton<ReservationManager>.Instance.TryReserveObject(item.GetAsReservable(), base.AgentOwner))
							{
								QueueTarget(TargetIndex.A, item);
								isViaPreferredReservable = true;
								isEnabled = true;
								return isEnabled;
							}
						}
					}
				}
				base.PreferredReservableHandler.ClearTarget();
			}
			HumanoidInstance humanoidInstance = base.AgentOwner as HumanoidInstance;
			bool isEnabled2;
			if (!base.ConstructionJobManager.TryReserveConstructBuildingJob(humanoidInstance, out var outJobBuildings, out allJobsAreBlocking))
			{
				messageBuilder = new FVLogTraceInterpolationHandler(8, 1, out isEnabled2, "C:\\GIT\\dev\\Assets\\Scripts\\GOAP\\Goal\\ConstructBuildingGoal.cs");
				if (isEnabled2)
				{
					messageBuilder.AppendLiteral("No jobs ");
					messageBuilder.AppendFormatted(base.AgentOwner);
				}
				Log.Trace(messageBuilder);
				outJobBuildings.Dispose();
				return false;
			}
			foreach (var (baseBuildingInstance, reachablePosition) in outJobBuildings)
			{
				QueueTarget(TargetIndex.A, new TargetObject(baseBuildingInstance, reachablePosition));
				messageBuilder = new FVLogTraceInterpolationHandler(21, 2, out isEnabled2, "C:\\GIT\\dev\\Assets\\Scripts\\GOAP\\Goal\\ConstructBuildingGoal.cs");
				if (isEnabled2)
				{
					messageBuilder.AppendLiteral("QueueTarget '");
					messageBuilder.AppendFormatted(baseBuildingInstance);
					messageBuilder.AppendLiteral("' for '");
					messageBuilder.AppendFormatted(base.AgentOwner);
					messageBuilder.AppendLiteral("'");
				}
				Log.Trace(messageBuilder);
			}
			outJobBuildings.Dispose();
			return true;
		}

		private void AddXp(HumanoidInstance agent, float xpPerSecond, SkillType skill)
		{
			int num = (int)(xpPerSecond + 8f);
			WorkerSkill workerSkill = agent.Skills?.GetSkill(skill);
			if (workerSkill != null && !agent.Skills.GetSkill(skill).IsMaxLevelReached())
			{
				float experience = workerSkill.Experience;
				agent.AddExperience(skill, num, isSilent: true);
				float num2 = workerSkill.Experience - experience;
				if (num2 <= 0f)
				{
					num2 = num;
				}
				totalXpGained += (int)num2;
				lastRewardedSkill = skill;
			}
		}

		private void DropAllResources(BaseBuildingInstance building, Vector3 position)
		{
			if (building?.Storage?.Resources == null)
			{
				return;
			}
			foreach (ResourceInstance resource in building.Storage.Resources)
			{
				if (resource.Amount > 0)
				{
					MonoSingleton<ResourcePileManager>.Instance.SpawnPile(resource.Clone(), position);
				}
			}
		}
	}
}
