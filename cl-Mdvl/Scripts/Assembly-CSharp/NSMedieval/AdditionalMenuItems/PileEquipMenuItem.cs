using System.Collections.Generic;
using NSEipix.Base;
using NSEipix.Repository;
using NSMedieval.Controllers;
using NSMedieval.Draft;
using NSMedieval.Enums;
using NSMedieval.Model;
using NSMedieval.Repository;
using NSMedieval.State;
using NSMedieval.State.WorkerJobs;
using NSMedieval.StatsSystem;
using NSMedieval.Types;
using NSMedieval.UI.Utils;

namespace NSMedieval.AdditionalMenuItems
{
	public class PileEquipMenuItem : AdditionalMenuItemBase
	{
		private readonly string buttonTextSuffix;

		public PileEquipMenuItem(IAdditionalMenuOwner owner)
			: base(owner, JobType.None, canDoWhileDrafted: true)
		{
			if (!(base.Owner.GetAsTarget() is ResourcePileInstance resourcePileInstance))
			{
				base.IsEnabled = false;
				return;
			}
			List<SkillLevelPair> requiredSkills = Repository<EquipmentRepository, Equipment>.Instance.GetByID(resourcePileInstance.BlueprintId).RequiredSkills;
			base.Text = MonoSingleton<LocalizationController>.Instance.GetText("general_equip") + " " + ResourceUtils.GetLocalizedResourceName(resourcePileInstance.BlueprintId);
			if (MonoSingleton<LocalizationController>.Instance.GetCurrentLanguageEnum() == Language.Korean)
			{
				base.Text = ResourceUtils.GetLocalizedResourceName(resourcePileInstance.BlueprintId) + " " + MonoSingleton<LocalizationController>.Instance.GetText("general_equip");
			}
			bool flag = requiredSkills != null && requiredSkills.Count > 0;
			if (flag)
			{
				buttonTextSuffix = "\n<style=Desc>" + MonoSingleton<LocalizationController>.Instance.GetText("needed_skills") + ": " + AdditionalMenuItemUtil.GenerateSkillInfo(requiredSkills[0].Key.ToString().ToLower(), requiredSkills[0].Value);
			}
			else
			{
				buttonTextSuffix = string.Empty;
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
			SkillLevelPair blockedSkill = GetBlockedSkill(selectedWorker, resourcePileInstance);
			if (blockedSkill != null && blockedSkill.Key != SkillType.None)
			{
				base.IsEnabled = false;
				base.Tooltip = MonoSingleton<LocalizationController>.Instance.GetText("not_enough_skill_level");
				return;
			}
			EnableIfWorkerIsSelected();
			if (base.IsEnabled)
			{
				DisableIfReserved();
			}
		}

		protected override string GetButtonTextSuffix()
		{
			return buttonTextSuffix;
		}

		public static SkillLevelPair GetBlockedSkill(HumanoidInstance humanoid, ResourcePileInstance resourcePile)
		{
			if (!resourcePile.GetStoredResource().Blueprint.Category.HasFlag(ResourceCategory.CtgItem))
			{
				return null;
			}
			foreach (SkillLevelPair requiredSkill in Repository<EquipmentRepository, Equipment>.Instance.GetByID(resourcePile.BlueprintId).RequiredSkills)
			{
				if (humanoid.SkillIsBlocked(requiredSkill.Key) || humanoid.GetSkillLevel(requiredSkill.Key) < requiredSkill.Value)
				{
					return requiredSkill;
				}
			}
			return null;
		}

		protected override void OnClickCallback()
		{
			base.OnClickCallback();
			ResourcePileInstance resourcePileInstance = (ResourcePileInstance)base.Owner.GetAsTarget();
			if (!resourcePileInstance.HasDisposed && resourcePileInstance.Blueprint.Category.HasFlag(ResourceCategory.CtgItem))
			{
				HumanoidInstance selectedWorker = GetSelectedWorker();
				if (selectedWorker != null)
				{
					MonoSingleton<DraftController>.Instance.ExecuteDraftOrder(selectedWorker, new DraftOrderEquip(resourcePileInstance));
				}
			}
		}
	}
}
