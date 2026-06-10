using System.Collections.Generic;
using System.Linq;
using FoxyVoxel.Logging;
using FoxyVoxel.Logging.Core.LogMessageInterpolationHandlers;
using Models.Production;
using NSEipix.Base;
using NSEipix.Repository;
using NSMedieval.BuildingComponents;
using NSMedieval.Controllers;
using NSMedieval.Goap;
using NSMedieval.Model;
using NSMedieval.Repository;
using NSMedieval.State;
using NSMedieval.State.WorkerJobs;
using NSMedieval.UI.Utils;

namespace NSMedieval.AdditionalMenuItems
{
	public class PrioritiseProductionMenuItem : AdditionalMenuPrioritiseItem
	{
		private enum ProductionAction
		{
			None = 0,
			DeliverMaterials = 1,
			Produce = 2,
			ShowPausedMessage = 3,
			PassiveMessage = 4,
			NoActiveProductions = 5,
			TargetReached = 6,
			NoResources = 7,
			InPrisonCell = 8
		}

		private ProductionAction action;

		public PrioritiseProductionMenuItem(IAdditionalMenuOwner owner)
			: base(owner)
		{
			action = ProductionAction.None;
			if (!(base.Owner.GetAsTarget() is BaseBuildingInstance baseBuildingInstance))
			{
				base.IsEnabled = false;
				return;
			}
			ProductionComponentInstance componentInstance = baseBuildingInstance.GetComponentInstance<ProductionComponentInstance>();
			if (componentInstance == null || componentInstance.HasDisposed)
			{
				base.IsEnabled = false;
				return;
			}
			EnableIfWorkerIsSelected();
			base.Text = MonoSingleton<LocalizationController>.Instance.GetText("general_operate_production");
			if (!base.IsEnabled)
			{
				return;
			}
			DisableIfReserved();
			if (!base.IsEnabled)
			{
				return;
			}
			HumanoidInstance worker = GetSelectedWorker();
			ProductionSystemInstance productionSystemInstance = componentInstance.ProductionSystemInstance;
			if (productionSystemInstance == null)
			{
				base.Tooltip = MonoSingleton<LocalizationController>.Instance.GetText("missing_resource_for_production");
				action = ProductionAction.NoResources;
				base.IsEnabled = false;
				return;
			}
			base.MenuTitle = string.Empty;
			ProductionInstance currentProduction = productionSystemInstance.CurrentProduction;
			if (currentProduction == null)
			{
				base.IsEnabled = false;
				if (componentInstance.GetRoom()?.RoomType?.Prison == true)
				{
					base.Tooltip = BuildingUtils.GetInPrisonCellInfo(componentInstance?.OwnerBuilding?.Blueprint);
					action = ProductionAction.InPrisonCell;
					return;
				}
				ProductionInstance productionInstance = productionSystemInstance.Productions.FirstOrDefault((ProductionInstance item) => !item.IsProductionTargetCountReached() && !item.Blueprint.HasSkillsRequired(worker));
				if (productionSystemInstance.Productions.Any((ProductionInstance item) => !item.IsProductionTargetCountReached() && item.Order == ProductionOrder.Pause))
				{
					base.Tooltip = MonoSingleton<LocalizationController>.Instance.GetText(MonoSingleton<LocalizationController>.Instance.GetText("active_productin_paused"));
					action = ProductionAction.ShowPausedMessage;
				}
				else if (productionInstance != null)
				{
					SkillLevelPair skillLevelPair = productionInstance.Blueprint.FindFirstUnmetSkillRequirement(worker);
					base.Tooltip = MonoSingleton<LocalizationController>.Instance.GetText("missing_skill_required_for_production");
					base.MenuTitle = worker.Info.FirstName + " (" + AdditionalMenuItemUtil.GenerateSkillInfo(skillLevelPair.Key.ToString().ToLower(), worker.GetSkillLevel(skillLevelPair.Key)) + ")";
				}
				else if (productionSystemInstance.Productions.Any((ProductionInstance item) => !item.IsProductionTargetCountReached() && item.CurrentStep is ProductionStepCollect productionStepCollect && !productionStepCollect.ResourcesAllowedAvailable))
				{
					base.Tooltip = MonoSingleton<LocalizationController>.Instance.GetText("missing_resource_for_production");
					action = ProductionAction.NoResources;
				}
				else if (productionSystemInstance.Productions.Any((ProductionInstance item) => item.IsProductionTargetCountReached()))
				{
					base.Tooltip = MonoSingleton<LocalizationController>.Instance.GetText("production_target_reached");
					action = ProductionAction.TargetReached;
				}
				else
				{
					base.Tooltip = MonoSingleton<LocalizationController>.Instance.GetText(MonoSingleton<LocalizationController>.Instance.GetText("no_active_productions"));
					action = ProductionAction.NoActiveProductions;
				}
				return;
			}
			SkillLevelPair skillLevelPair2 = currentProduction.Blueprint.RequiredSkills[0];
			base.MenuTitle = worker.Info.FirstName + " (" + AdditionalMenuItemUtil.GenerateSkillInfo(skillLevelPair2.Key.ToString().ToLower(), worker.GetSkillLevel(skillLevelPair2.Key)) + ")";
			base.RequiredJob = currentProduction.Blueprint.JobType;
			EnableIfWorkerIsSelected();
			DisableIfUnreachableFromSelectedWorker(baseBuildingInstance);
			if (!base.IsEnabled)
			{
				return;
			}
			if (componentInstance.GetRoom()?.RoomType?.Prison == true)
			{
				base.Tooltip = BuildingUtils.GetInPrisonCellInfo(componentInstance.OwnerBuilding.Blueprint);
				action = ProductionAction.InPrisonCell;
				base.IsEnabled = false;
				return;
			}
			if (currentProduction.IsProductionTargetCountReached())
			{
				base.Tooltip = MonoSingleton<LocalizationController>.Instance.GetText("production_target_reached");
				action = ProductionAction.TargetReached;
				base.IsEnabled = false;
				return;
			}
			ProductionStepInstance currentStep = currentProduction.CurrentStep;
			ProductionStepType productionStepType = currentStep?.Type ?? ProductionStepType.None;
			if (currentStep != null)
			{
				switch (productionStepType)
				{
				case ProductionStepType.None:
					break;
				case ProductionStepType.PassiveProduce:
					base.Tooltip = MonoSingleton<LocalizationController>.Instance.GetText("cannot_passive_production");
					action = ProductionAction.PassiveMessage;
					base.IsEnabled = true;
					return;
				default:
					if (!currentProduction.RequireInteraction())
					{
						return;
					}
					if (currentProduction.OwnerCreatureId != 0 && currentProduction.OwnerCreatureId != worker.UniqueId)
					{
						base.Tooltip = MonoSingleton<LocalizationController>.Instance.GetText("production_assigned_to_different_settler");
						base.IsEnabled = false;
						return;
					}
					if (currentProduction.SkillLevelRange != null && !currentProduction.SkillLevelRange.InRange(worker.GetSkillLevel(skillLevelPair2.Key)))
					{
						base.Tooltip = MonoSingleton<LocalizationController>.Instance.GetText("skill_level_doesnt_satisfy_filter");
						base.IsEnabled = false;
						return;
					}
					if (!currentProduction.Blueprint.HasSkillsRequired(worker))
					{
						base.Tooltip = MonoSingleton<LocalizationController>.Instance.GetText("missing_skill_required_for_production");
						base.IsEnabled = false;
						return;
					}
					switch (productionStepType)
					{
					case ProductionStepType.Collect:
						if (!((ProductionStepCollect)currentStep).ResourcesAllowedAvailable)
						{
							base.Tooltip = MonoSingleton<LocalizationController>.Instance.GetText("missing_resource_for_production");
							base.IsEnabled = false;
							action = ProductionAction.NoResources;
						}
						else
						{
							base.Tooltip = MonoSingleton<LocalizationController>.Instance.GetText("menu_deliver") + ": " + MonoSingleton<LocalizationController>.Instance.GetText(LocKeyUtils.GetName(currentProduction.Blueprint.LocKeys));
							action = ProductionAction.DeliverMaterials;
						}
						break;
					case ProductionStepType.WorkerProduce:
						base.Tooltip = MonoSingleton<LocalizationController>.Instance.GetText("menu_produce") + ": " + MonoSingleton<LocalizationController>.Instance.GetText(LocKeyUtils.GetName(currentProduction.Blueprint.LocKeys));
						action = ProductionAction.Produce;
						break;
					}
					return;
				}
			}
			bool flag;
			FVLogErrorInterpolationHandler messageBuilder = new FVLogErrorInterpolationHandler(33, 2, out flag, "C:\\GIT\\dev\\Assets\\Scripts\\Component\\AdditionalMenu\\Items\\PrioritiseProductionMenuItem.cs");
			if (flag)
			{
				messageBuilder.AppendLiteral("production step type is NONE. ");
				messageBuilder.AppendFormatted(currentProduction.BlueprintId);
				messageBuilder.AppendLiteral("@(");
				messageBuilder.AppendFormatted(baseBuildingInstance.GetGridPosition());
				messageBuilder.AppendLiteral(")");
			}
			Log.Error(messageBuilder);
		}

		protected override void OnClickCallback()
		{
			base.OnClickCallback();
			if (action == ProductionAction.None)
			{
				return;
			}
			switch (action)
			{
			case ProductionAction.DeliverMaterials:
			case ProductionAction.Produce:
				PrioritiseGoal();
				break;
			case ProductionAction.NoResources:
				MonoSingleton<BlackBarMessageController>.Instance.ShowBlackBarMessage(MonoSingleton<LocalizationController>.Instance.GetText("missing_resource_for_production"));
				break;
			case ProductionAction.ShowPausedMessage:
				MonoSingleton<BlackBarMessageController>.Instance.ShowBlackBarMessage(MonoSingleton<LocalizationController>.Instance.GetText("active_productin_paused"));
				break;
			case ProductionAction.PassiveMessage:
				MonoSingleton<BlackBarMessageController>.Instance.ShowBlackBarMessage(MonoSingleton<LocalizationController>.Instance.GetText("cannot_passive_production"));
				break;
			case ProductionAction.NoActiveProductions:
				MonoSingleton<BlackBarMessageController>.Instance.ShowBlackBarMessage(MonoSingleton<LocalizationController>.Instance.GetText("no_active_productions"));
				break;
			case ProductionAction.TargetReached:
				MonoSingleton<BlackBarMessageController>.Instance.ShowBlackBarMessage(MonoSingleton<LocalizationController>.Instance.GetText("production_target_reached"));
				break;
			case ProductionAction.InPrisonCell:
				if (base.Owner.GetAsTarget() is BaseBuildingInstance baseBuildingInstance)
				{
					ProductionComponentInstance componentInstance = baseBuildingInstance.GetComponentInstance<ProductionComponentInstance>();
					MonoSingleton<BlackBarMessageController>.Instance.ShowBlackBarMessage(BuildingUtils.GetInPrisonCellInfo(componentInstance.OwnerBuilding.Blueprint));
				}
				break;
			}
		}

		protected override string GetButtonTextSuffix()
		{
			HumanoidInstance selectedWorker = GetSelectedWorker();
			if (selectedWorker == null)
			{
				return string.Empty;
			}
			if (!(base.Owner.GetAsTarget() is BaseBuildingInstance baseBuildingInstance))
			{
				return string.Empty;
			}
			ProductionComponentInstance componentInstance = baseBuildingInstance.GetComponentInstance<ProductionComponentInstance>();
			if (componentInstance == null || componentInstance.HasDisposed)
			{
				return string.Empty;
			}
			List<ProductionInstance> list = componentInstance.ProductionSystemInstance?.Productions;
			if (list == null)
			{
				return string.Empty;
			}
			foreach (ProductionInstance item in list)
			{
				if (!item.IsProductionTargetCountReached())
				{
					SkillLevelPair skillLevelPair = item.Blueprint.FindFirstUnmetSkillRequirement(selectedWorker);
					if (!(skillLevelPair == null))
					{
						string arg = MonoSingleton<LocalizationController>.Instance.GetText("skill_name_" + skillLevelPair.GetID());
						return $"\n<style=Desc>Required skill: {arg} {skillLevelPair.Value}";
					}
				}
			}
			return base.GetButtonTextSuffix();
		}

		private void PrioritiseGoal()
		{
			BaseBuildingInstance baseBuildingInstance = base.Owner.GetAsTarget() as BaseBuildingInstance;
			HumanoidInstance selectedWorker = GetSelectedWorker();
			if (selectedWorker == null || base.RequiredJob == JobType.None || baseBuildingInstance == null)
			{
				return;
			}
			string text = Repository<JobRepository, Job>.Instance.GetByJobType(base.RequiredJob)?.Goals?.FirstOrDefault((string item) => item.ToLower().Contains("production"));
			if (!string.IsNullOrEmpty(text))
			{
				Agent goapAgent = selectedWorker.GetGoapAgent();
				if (goapAgent != null && goapAgent.GoalScheduler.IsEnabled(text))
				{
					ProductionComponentInstance componentInstance = baseBuildingInstance.GetComponentInstance<ProductionComponentInstance>();
					ForceGoal(text, componentInstance);
				}
			}
		}
	}
}
