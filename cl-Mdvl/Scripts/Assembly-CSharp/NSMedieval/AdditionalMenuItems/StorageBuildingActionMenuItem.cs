using System.Collections.Generic;
using System.Linq;
using FoxyVoxel.Logging;
using FoxyVoxel.Logging.Core.LogMessageInterpolationHandlers;
using NSEipix.Base;
using NSEipix.Repository;
using NSMedieval.BuildingComponents;
using NSMedieval.Controllers;
using NSMedieval.Draft;
using NSMedieval.Enums;
using NSMedieval.Manager;
using NSMedieval.Model;
using NSMedieval.Repository;
using NSMedieval.State;
using NSMedieval.State.WorkerJobs;
using NSMedieval.StatsSystem;
using NSMedieval.StorageUniversal;
using NSMedieval.Types;
using NSMedieval.UI.Utils;

namespace NSMedieval.AdditionalMenuItems
{
	public class StorageBuildingActionMenuItem : AdditionalMenuItemBase
	{
		private readonly bool isEquipAction;

		private ResourcePileInstance resourcePile;

		public StorageBuildingActionMenuItem(IAdditionalMenuOwner owner)
			: base(owner, JobType.None, canDoWhileDrafted: true)
		{
			if (!(base.Owner.GetAsTarget() is BaseBuildingInstance baseBuildingInstance))
			{
				base.IsEnabled = false;
				return;
			}
			ShelfComponentInstance componentInstance = baseBuildingInstance.Map.ShelfComponentManager.GetComponentInstance(baseBuildingInstance);
			if (componentInstance.HasDisposed || componentInstance.AllStorage == null)
			{
				bool flag;
				FVLogWarningInterpolationHandler messageBuilder = new FVLogWarningInterpolationHandler(69, 3, out flag, "C:\\GIT\\dev\\Assets\\Scripts\\Component\\AdditionalMenu\\Items\\StorageBuildingActionMenuItem.cs");
				if (flag)
				{
					messageBuilder.AppendLiteral("Additional menu storage holder problem. Disposed: ");
					messageBuilder.AppendFormatted(componentInstance.HasDisposed);
					messageBuilder.AppendLiteral("; All Storage");
					messageBuilder.AppendFormatted(componentInstance.AllStorage);
					messageBuilder.AppendLiteral("; Type");
					messageBuilder.AppendFormatted(componentInstance.OwnerBuildingID);
				}
				Log.Warning(messageBuilder);
				base.IsEnabled = false;
				return;
			}
			int valueOrDefault = (MonoSingleton<AdditionalMenuManager>.Instance.CurrentMenu?.Items?.Where((AdditionalMenuItemBase item) => item is StorageBuildingActionMenuItem).Count()).GetValueOrDefault();
			int num = 0;
			foreach (UniversalStorage item in componentInstance.AllStorage)
			{
				if (item == null || item.HasDisposed)
				{
					continue;
				}
				StorageSlot[] storageSlots = item.StorageSlots;
				foreach (StorageSlot storageSlot in storageSlots)
				{
					if (storageSlot?.Pile?.GetStoredResource() != null && !storageSlot.Pile.HasDisposed && (!(storageSlot.Pile.GetStoredResource().Blueprint.EquipmentBlueprint == null) || storageSlot.Pile.Blueprint.Category.HasFlag(ResourceCategory.CtgEdible)))
					{
						if (num == valueOrDefault)
						{
							resourcePile = storageSlot.Pile;
						}
						num++;
					}
				}
				if (resourcePile != null)
				{
					break;
				}
			}
			if (resourcePile?.GetStoredResource() != null)
			{
				if (resourcePile.GetStoredResource().Blueprint.EquipmentBlueprint != null)
				{
					GenerateEquipData(resourcePile);
					isEquipAction = true;
				}
				else if (resourcePile.GetStoredResource().Blueprint.Category.HasFlag(ResourceCategory.CtgEdible))
				{
					GenerateConsumeData(resourcePile);
					isEquipAction = false;
				}
				else
				{
					isEquipAction = false;
					base.IsEnabled = false;
				}
			}
		}

		public override void Dispose()
		{
			base.Dispose();
			resourcePile = null;
		}

		private void GenerateEquipData(ResourcePileInstance pile)
		{
			List<SkillLevelPair> requiredSkills = Repository<EquipmentRepository, Equipment>.Instance.GetByID(pile.BlueprintId).RequiredSkills;
			string text = MonoSingleton<LocalizationController>.Instance.GetText("general_equip") + " " + ResourceUtils.GetLocalizedResourceName(pile.BlueprintId);
			if (MonoSingleton<LocalizationController>.Instance.GetCurrentLanguageEnum() == Language.Korean)
			{
				text = ResourceUtils.GetLocalizedResourceName(pile.BlueprintId) + " " + MonoSingleton<LocalizationController>.Instance.GetText("general_equip");
			}
			bool flag = false;
			if (requiredSkills != null && requiredSkills.Count > 0)
			{
				base.Text = text + "\n" + MonoSingleton<LocalizationController>.Instance.GetText("needed_skills") + ": " + AdditionalMenuItemUtil.GenerateSkillInfo(requiredSkills[0].Key.ToString().ToLower(), requiredSkills[0].Value);
				flag = true;
			}
			else
			{
				base.Text = text;
			}
			HumanoidInstance selectedWorker = GetSelectedWorker();
			if (selectedWorker == null)
			{
				EnableIfWorkerIsSelected();
				return;
			}
			if (flag)
			{
				base.MenuTitle = selectedWorker.Info.FirstName + " (" + AdditionalMenuItemUtil.GenerateSkillInfo(requiredSkills[0].Key.ToString().ToLower(), selectedWorker.GetSkillLevel(requiredSkills[0].Key)) + ")";
			}
			SkillLevelPair blockedSkill = PileEquipMenuItem.GetBlockedSkill(selectedWorker, pile);
			if (blockedSkill != null && blockedSkill.Key != SkillType.None)
			{
				base.IsEnabled = false;
				base.Tooltip = MonoSingleton<LocalizationController>.Instance.GetText("not_enough_skill_level");
			}
			else
			{
				EnableIfWorkerIsSelected();
			}
		}

		private void GenerateConsumeData(ResourcePileInstance pile)
		{
			string text = MonoSingleton<LocalizationController>.Instance.GetText("general_consume");
			string localizedResourceName = ResourceUtils.GetLocalizedResourceName(pile.Blueprint);
			if (MonoSingleton<LocalizationController>.Instance.GetCurrentLanguageEnum() == Language.Japanese || MonoSingleton<LocalizationController>.Instance.GetCurrentLanguageEnum() == Language.Korean)
			{
				base.Text = localizedResourceName + text;
			}
			else if (MonoSingleton<LocalizationController>.Instance.GetCurrentLanguageEnum() == Language.Chinese)
			{
				base.Text = text + localizedResourceName;
			}
			else
			{
				base.Text = text + " " + localizedResourceName;
			}
			EnableIfWorkerIsSelected();
		}

		protected override void OnClickCallback()
		{
			if (resourcePile == null || resourcePile.HasDisposed)
			{
				base.OnClickCallback();
				return;
			}
			HumanoidInstance selectedWorker = GetSelectedWorker();
			if (selectedWorker == null)
			{
				base.OnClickCallback();
			}
			else if (isEquipAction)
			{
				if (!resourcePile.Blueprint.Category.HasFlag(ResourceCategory.CtgItem))
				{
					base.OnClickCallback();
					return;
				}
				MonoSingleton<DraftController>.Instance.ExecuteDraftOrder(selectedWorker, new DraftOrderEquip(resourcePile));
				base.OnClickCallback();
			}
			else if (!resourcePile.Blueprint.Category.HasFlag(ResourceCategory.CtgEdible))
			{
				base.OnClickCallback();
			}
			else
			{
				MonoSingleton<DraftController>.Instance.ExecuteDraftOrder(selectedWorker, new DraftOrderConsume(resourcePile));
				base.OnClickCallback();
			}
		}
	}
}
