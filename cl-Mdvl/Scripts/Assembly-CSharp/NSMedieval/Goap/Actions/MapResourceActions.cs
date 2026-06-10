using System;
using System.Collections.Generic;
using FoxyVoxel.Logging;
using FoxyVoxel.Logging.Core.LogMessageInterpolationHandlers;
using NSEipix.Base;
using NSMedieval.FloatingOverlaySystem;
using NSMedieval.Manager;
using NSMedieval.Model;
using NSMedieval.Resources;
using NSMedieval.State;
using NSMedieval.StatsSystem;
using NSMedieval.Types;
using NSMedieval.Utils.Pool;
using NSMedieval.Views.Resources;
using UnityEngine;

namespace NSMedieval.Goap.Actions
{
	public static class MapResourceActions
	{
		public enum FailType
		{
			FailAction = 1,
			FailGoal = 2
		}

		public static GoapAction StartObtaining(TargetIndex targetIndex, OrderType order, bool hideToolAtComplete = true, FailType failType = FailType.FailGoal, bool checkWouldEncloseRegion = false, bool allJobsAreBlocking = false)
		{
			GoapAction action = new GoapAction("StartObtaining");
			CreatureBase ownerCreature = null;
			MapResourceInstance resourceInstance = null;
			DigMarkerResourceInstance digMarkerResourceInstance = null;
			ConstructionJobManager jobManager = null;
			bool shouldFail = false;
			float totalTime = 0f;
			float timeProgress = 0f;
			action.OnInit = delegate
			{
				shouldFail = false;
				totalTime = 0f;
				timeProgress = 0f;
				ownerCreature = action.AgentOwner as CreatureBase;
				jobManager = action.AgentOwner.Map.BuildingsManagerMain.ConstructionJobManager;
				resourceInstance = action.Goal.GetTarget(targetIndex).GetObjectAs<MapResourceInstance>();
				digMarkerResourceInstance = resourceInstance as DigMarkerResourceInstance;
				HarvestParametars harvestParametars = resourceInstance.GetMiningParameters();
				if (resourceInstance is PlantMapResourceInstance plantMapResourceInstance && order == OrderType.Harvesting)
				{
					harvestParametars = plantMapResourceInstance.Blueprint.GetHarvestParameters();
				}
				IHarvestAgent harvestAgent = action.AgentOwner as IHarvestAgent;
				shouldFail = resourceInstance.ShouldFailHarvest(harvestParametars, harvestAgent);
				float num = harvestAgent.GetAttributeValue(harvestParametars.DurationStat);
				if (num <= 0f)
				{
					bool isEnabled;
					FVLogWarningInterpolationHandler messageBuilder = new FVLogWarningInterpolationHandler(81, 1, out isEnabled, "C:\\GIT\\dev\\Assets\\Scripts\\GOAP\\Action\\MapResourceActions.cs");
					if (isEnabled)
					{
						messageBuilder.AppendLiteral("StartObtaining duration '");
						messageBuilder.AppendFormatted(harvestParametars.DurationStat);
						messageBuilder.AppendLiteral("' stat <= 0. Setting to 1, or harvest will last forever.");
					}
					Log.Warning(messageBuilder);
					num = 1f;
				}
				float num2 = harvestAgent.GetAttributeValue(AttributeType.GlobalWorkSpeed);
				if (num2 == 0f)
				{
					num2 = 1f;
				}
				float num3 = harvestAgent.GetAttributeValue(AttributeType.MotorFunction);
				if (num3 == 0f)
				{
					num3 = 1f;
				}
				float time = harvestParametars.HarvestDuration / (num * num2 * num3);
				totalTime = time;
				((IToolAgent)action.Goal.AgentOwner).SetTool(harvestParametars.ToolId);
				action.WithProgressBar(TargetIndex.None, OverlayProgressBarType.Circle, (IProgressBarOwner owner) => timeProgress / time);
			};
			action.OnTick = delegate(float delta)
			{
				if (action.TotalTickingTime > totalTime * 1.5f)
				{
					action.Complete(ActionCompletionStatus.Fail);
				}
				else if (!checkWouldEncloseRegion || digMarkerResourceInstance == null || !(ownerCreature.GetGridPosition() != resourceInstance.GridDataPosition) || jobManager.IsDigJobEnclosed(digMarkerResourceInstance) || resourceInstance.GetNode().CreaturesCount <= 0)
				{
					timeProgress += delta;
					if (timeProgress >= totalTime)
					{
						if (checkWouldEncloseRegion && digMarkerResourceInstance != null && !allJobsAreBlocking && jobManager.WouldDestroyJobEncloseRegion(digMarkerResourceInstance.GetNode()?.GetNodeBelow(), reCalculateFloodFill: true))
						{
							action.Complete(ActionCompletionStatus.Fail);
						}
						else
						{
							action.Complete(ActionCompletionStatus.Success);
						}
					}
				}
			};
			action.OnComplete = delegate
			{
				IHarvestAgent harvestAgent = action.AgentOwner as IHarvestAgent;
				if (hideToolAtComplete)
				{
					(harvestAgent as IToolAgent)?.HideTool();
				}
				if (action.TotalTickingTime >= totalTime && shouldFail)
				{
					MapResourceInstance objectAs = action.Goal.GetTarget(targetIndex).GetObjectAs<MapResourceInstance>();
					if (objectAs.OnOrderFail(order))
					{
						if (order == OrderType.Harvesting || order == OrderType.CutAllVegetation || order == OrderType.Chopping)
						{
							HandleMapResourceObtainActionFinished(objectAs, order);
						}
						if (order == OrderType.Digging && harvestAgent is HumanoidInstance { WorkerBehaviour: not null } humanoidInstance)
						{
							humanoidInstance.WorkerBehaviour.WorkerProximity.OnDiggingFailed();
						}
						if (failType == FailType.FailGoal)
						{
							action.Goal.EndGoalWith(GoalCondition.Incompletable);
						}
						else
						{
							action.Complete(ActionCompletionStatus.Fail);
						}
					}
				}
			};
			action.CompleteMode = ActionCompleteMode.Never;
			return action;
		}

		public static GoapAction EnemyCutPlant(TargetIndex targetIndex, bool hideToolAtComplete = true, FailType failType = FailType.FailGoal)
		{
			GoapAction action = new GoapAction("EnemyCutPlant");
			float totalTime = 0f;
			action.OnInit = delegate
			{
				HarvestParametars miningParameters = action.Goal.GetTarget(targetIndex).GetObjectAs<MapResourceInstance>().GetMiningParameters();
				IHarvestAgent obj = action.AgentOwner as IHarvestAgent;
				float num = obj.GetAttributeValue(miningParameters.DurationStat);
				if (num <= 0f)
				{
					bool isEnabled;
					FVLogWarningInterpolationHandler messageBuilder = new FVLogWarningInterpolationHandler(80, 1, out isEnabled, "C:\\GIT\\dev\\Assets\\Scripts\\GOAP\\Action\\MapResourceActions.cs");
					if (isEnabled)
					{
						messageBuilder.AppendLiteral("EnemyCutPlant duration '");
						messageBuilder.AppendFormatted(miningParameters.DurationStat);
						messageBuilder.AppendLiteral("' stat <= 0. Setting to 1, or harvest will last forever.");
					}
					Log.Warning(messageBuilder);
					num = 1f;
				}
				float num2 = obj.GetAttributeValue(AttributeType.GlobalWorkSpeed);
				if (num2 == 0f)
				{
					num2 = 1f;
				}
				float num3 = obj.GetAttributeValue(AttributeType.MotorFunction);
				if (num3 == 0f)
				{
					num3 = 1f;
				}
				float time = miningParameters.HarvestDuration / (num * num2 * num3);
				totalTime = time;
				action.CompleteAfterTimeExpires(time);
				((IToolAgent)action.Goal.AgentOwner).SetTool(miningParameters.ToolId);
				action.WithProgressBar(TargetIndex.None, OverlayProgressBarType.Circle, (IProgressBarOwner owner) => action.TotalTickingTime / time).ProgressBarDestroyOnCompletion(TargetIndex.None, OverlayProgressBarType.Circle);
			};
			action.OnComplete = delegate
			{
				IHarvestAgent harvestAgent = action.AgentOwner as IHarvestAgent;
				if (hideToolAtComplete)
				{
					(harvestAgent as IToolAgent)?.HideTool();
				}
			};
			action.CompleteMode = ActionCompleteMode.Delay;
			return action;
		}

		public static GoapAction SpawnHarvestedResources(TargetIndex index, OrderType orderType, bool forbidPile = false)
		{
			GoapAction action = new GoapAction("SpawnHarvestedResources");
			action.OnInit = delegate
			{
				MapResourceInstance objectAs = action.Goal.GetTarget(index).GetObjectAs<MapResourceInstance>();
				HarvestParametars miningParameters = objectAs.GetMiningParameters();
				IHarvestAgent harvestAgent = (IHarvestAgent)action.Goal.AgentOwner;
				int totalResources;
				List<ResourceInstance> obtainableResources = GetObtainableResources(objectAs, orderType, miningParameters, harvestAgent, out totalResources);
				harvestAgent.AddExperience(miningParameters.RewardedSkill, miningParameters.RewardAmount);
				HandleMapResourceObtainActionFinished(objectAs, orderType);
				bool flag = false;
				foreach (ResourceInstance item in obtainableResources)
				{
					if (item == null || item.Blueprint == null)
					{
						bool isEnabled;
						FVLogErrorInterpolationHandler messageBuilder = new FVLogErrorInterpolationHandler(28, 1, out isEnabled, "C:\\GIT\\dev\\Assets\\Scripts\\GOAP\\Action\\MapResourceActions.cs");
						if (isEnabled)
						{
							messageBuilder.AppendLiteral("This should never happen... ");
							messageBuilder.AppendFormatted(action.AgentOwner);
						}
						Log.Error(messageBuilder);
					}
					else
					{
						flag |= item.Blueprint.Nutrition > 0f;
						ResourcePileView resourcePileView = MonoSingleton<ResourcePileManager>.Instance.SpawnPile(item, harvestAgent.GetPosition(), forbidPile);
						if (resourcePileView != null)
						{
							MonoSingleton<ResourcePileHaulingManager>.Instance.ForceProcessPileState(resourcePileView.ResourcePileInstance);
						}
					}
				}
				if (flag)
				{
					MonoSingleton<AchievementManager>.Instance.UnlockAchievement("HARVEST_CROP");
					MonoSingleton<AchievementManager>.Instance.IncreaseStat("HAR_CNT", totalResources);
				}
				ListPool<ResourceInstance>.Return(obtainableResources);
			};
			return action;
		}

		private static void SpawnObtainedResources(MapResourceInstance target, OrderType order, HarvestParametars parametars, IHarvestAgent agent)
		{
			agent.AddExperience(parametars.RewardedSkill, parametars.RewardAmount);
			List<ResourceInstance> availableResources = target.GetAvailableResources(order);
			if (availableResources != null)
			{
				for (int i = 0; i < availableResources.Count; i++)
				{
					int num = (int)Math.Ceiling(agent.GetAttributeValue(parametars.AmountStat) * (float)availableResources[i].Amount);
					ResourceInstance resource = new ResourceInstance(availableResources[i].Blueprint, Mathf.Clamp(num, 1, num));
					MonoSingleton<ResourcePileManager>.Instance.SpawnPile(resource, target.WorldPosition);
				}
			}
		}

		public static List<ResourceInstance> GetObtainableResources(MapResourceInstance target, OrderType order, HarvestParametars parametars, IHarvestAgent agent, out int totalResources)
		{
			List<ResourceInstance> list = ListPool<ResourceInstance>.Get();
			totalResources = 0;
			if (target == null || target.HasDisposed)
			{
				return list;
			}
			List<ResourceInstance> availableResources = target.GetAvailableResources(order);
			PlantMapResourceInstance plantMapResourceInstance = target as PlantMapResourceInstance;
			float num = 1f;
			if (plantMapResourceInstance != null && plantMapResourceInstance.Blueprint != null)
			{
				if (plantMapResourceInstance.Blueprint.YieldByDifficulty)
				{
					num = GlobalSaveController.CurrentVillageData.GameParametersCurrent.PlantYieldMultiplier;
				}
				if (plantMapResourceInstance.IsStunted)
				{
					num *= plantMapResourceInstance.Blueprint.StuntedYieldMultiplier;
				}
			}
			if (target is DigMarkerResourceInstance)
			{
				num = GlobalSaveController.CurrentVillageData.GameParametersCurrent.MineYieldMultiplier;
			}
			if (availableResources == null)
			{
				return list;
			}
			for (int i = 0; i < availableResources.Count; i++)
			{
				if (!target.HasDisposed)
				{
					int num2 = (int)Math.Floor(agent.GetAttributeValue(parametars.AmountStat) * (float)availableResources[i].Amount * num * target.GetStat(StatType.Health).GetNormalizedPercentage());
					int num3 = Mathf.Clamp(num2, 1, num2);
					totalResources += num3;
					list.Add(new ResourceInstance(availableResources[i].Blueprint, num3));
				}
			}
			return list;
		}

		private static void HandleMapResourceObtainActionFinished(MapResourceInstance target, OrderType orderType)
		{
			if ((orderType & (OrderType.CutAllVegetation | OrderType.Chopping)) != OrderType.None)
			{
				MonoSingleton<FloraController>.Instance.CuttingFinished((PlantMapResourceInstance)target);
				PlantMapResourceInstance obj = (PlantMapResourceInstance)target;
				if (obj != null && obj.Blueprint.GetHarvestParameters().HarvestDuration > 0f)
				{
					orderType |= OrderType.Harvesting;
				}
			}
			if ((orderType & OrderType.Harvesting) != OrderType.None)
			{
				MonoSingleton<FloraController>.Instance.HarvestFinished((PlantMapResourceInstance)target);
			}
			if ((orderType & OrderType.Digging) != OrderType.None)
			{
				((DigMarkerResourceInstance)target)?.OnDigCycleEnd();
			}
			if ((orderType & OrderType.Fishing) != OrderType.None)
			{
				((FishMapResourceInstance)target)?.OnFishCatch();
			}
		}
	}
}
