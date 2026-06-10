using System.Collections.Generic;
using NSEipix;
using NSEipix.Base;
using NSMedieval.Controllers;
using NSMedieval.Model;
using NSMedieval.StatsSystem;
using NSMedieval.UI.Utils;
using UnityEngine;

namespace NSMedieval.UI
{
	public class WorkerSkillsTooltipViewNew : WorkerBaseTooltipViewNew
	{
		private static WorkerSkillsDetailsView workerDetails;

		private static readonly List<SkillLayoutItemView> WorkerSkills = new List<SkillLayoutItemView>();

		[SerializeField]
		private GameObject tooltipPrefab;

		[SerializeField]
		private bool showAdditionalProperties;

		public override bool ShowPrefabsFirst => true;

		[RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.BeforeSceneLoad)]
		private static void OnDomainReload()
		{
			workerDetails = null;
			foreach (SkillLayoutItemView workerSkill in WorkerSkills)
			{
				Object.Destroy(workerSkill);
			}
			WorkerSkills.Clear();
		}

		protected override void OnDestroy()
		{
			base.OnDestroy();
			if (WorkerSkills == null || WorkerSkills.Count == 0)
			{
				return;
			}
			foreach (SkillLayoutItemView workerSkill in WorkerSkills)
			{
				if (workerSkill != null && workerSkill.gameObject != null)
				{
					Object.Destroy(workerSkill.gameObject);
				}
			}
			WorkerSkills.Clear();
			SetOwner(null);
		}

		protected override List<string> GetLinesToShow()
		{
			if (base.Humanoid == null || base.Humanoid.ActiveBehaviour == null || base.Humanoid.HasDisposed)
			{
				return base.Lines;
			}
			if (workerDetails == null)
			{
				workerDetails = Object.Instantiate(tooltipPrefab).GetComponent<WorkerSkillsDetailsView>();
			}
			workerDetails.gameObject.SetActive(value: true);
			workerDetails.gameObject.name = "WorkerSkillsTooltipView: " + base.Humanoid.Info.GetFullName();
			workerDetails.WorkerNameLabel.SetText(base.Humanoid.ActiveBehaviour.HumanoidRoleOwner.GetDefaultDisplayNameRole());
			List<WorkerSkill> skillsOrdered = base.Humanoid.SkillsOrdered;
			int num = 0;
			foreach (WorkerSkill item in skillsOrdered)
			{
				if (item.Id != SkillType.None)
				{
					SkillLayoutItemView at = WorkerSkills.GetAt(workerDetails.SkillsGroup, num);
					at.gameObject.SetActive(value: true);
					at.SetSkillData(base.Humanoid, item, num);
					num++;
				}
			}
			WorkerSkills.SetActiveFromIndex(num, active: false);
			SetTooltipPrefab(workerDetails.gameObject);
			if (showAdditionalProperties)
			{
				base.Lines.Clear();
				base.Lines.Add(string.Format("{0}: {1}", MonoSingleton<LocalizationController>.Instance.GetText("villager_constraint_Age"), base.Humanoid.Info.Age));
				base.Lines.Add(string.Format("{0}: {1:F1} {2}", MonoSingleton<LocalizationController>.Instance.GetText("villager_constraint_Weight"), base.Humanoid.Info.GetWeight(), MonoSingleton<LocalizationController>.Instance.GetText("general_kg")));
				base.Lines.Add(string.Format("{0}: {1:N0} {2}", MonoSingleton<LocalizationController>.Instance.GetText("villager_constraint_Height"), base.Humanoid.Info.Height, MonoSingleton<LocalizationController>.Instance.GetText("general_cm")));
				base.Lines.Add(string.Format("{0}: {1:F1}%", MonoSingleton<LocalizationController>.Instance.GetText("worker_health"), base.Humanoid.Stats.GetStat(StatType.Health).GetNormalizedPercentage() * 100f));
				base.Lines.Add(MonoSingleton<LocalizationController>.Instance.GetText("menu_background") + ": " + HumanoidUtils.GetBackgroundNameMerged(base.Humanoid));
				base.Lines.Add(MonoSingleton<LocalizationController>.Instance.GetText("general_faction") + ": " + base.Humanoid.Faction?.NameLocalized);
				if (base.Humanoid.Perks != null && base.Humanoid.Perks.Count > 0)
				{
					base.Lines.Add(MonoSingleton<LocalizationController>.Instance.GetText("menu_perks") + ":");
					foreach (Perk perk in base.Humanoid.Perks)
					{
						base.Lines.Add("  " + MonoSingleton<LocalizationController>.Instance.GetText("perk_name_" + perk.Name));
					}
				}
			}
			return base.Lines;
		}
	}
}
