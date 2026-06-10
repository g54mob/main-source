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
	public class CreatureStatsTooltipView : CreatureBaseTooltipView
	{
		private static WorkerDetailsView workerDetails;

		private static readonly List<SkillLayoutItemView> WorkerSkills = new List<SkillLayoutItemView>();

		private static readonly List<LayoutGroupItemView> WorkerPerks = new List<LayoutGroupItemView>();

		[SerializeField]
		private bool hideStats;

		[SerializeField]
		private GameObject tooltipPrefab;

		private int randomIndex;

		[RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.BeforeSceneLoad)]
		private static void OnDomainReload()
		{
			Object.DestroyImmediate(workerDetails);
			workerDetails = null;
			foreach (SkillLayoutItemView workerSkill in WorkerSkills)
			{
				Object.DestroyImmediate(workerSkill);
			}
			WorkerSkills.Clear();
			foreach (LayoutGroupItemView workerPerk in WorkerPerks)
			{
				Object.DestroyImmediate(workerPerk);
			}
			WorkerPerks.Clear();
		}

		private void OnEnable()
		{
			randomIndex = 0;
		}

		protected override List<string> GetLinesToShow()
		{
			if (base.Humanoid == null || WorkerSkills == null || WorkerPerks == null)
			{
				return lines;
			}
			if (workerDetails == null)
			{
				workerDetails = Object.Instantiate(tooltipPrefab).GetComponent<WorkerDetailsView>();
			}
			CleanupWorkerSkillsPerks();
			float religiousAlignment = base.Humanoid.Info.ReligiousAlignment;
			LocalizationController instance = MonoSingleton<LocalizationController>.Instance;
			workerDetails.gameObject.SetActive(value: true);
			workerDetails.gameObject.name = "WorkerStatsTooltipView: " + base.Humanoid.Info.GetFullName();
			workerDetails.WorkerNameLabel.SetText(base.Humanoid.Info.GetFullName());
			workerDetails.BackstoryTitle.SetText(HumanoidUtils.GetBackgroundNameMerged(base.Humanoid));
			workerDetails.SetPseudonymTitle(base.Humanoid);
			workerDetails.ReligiousAlignment.SetAlignmentData(StatType.ReligiousAlignment, religiousAlignment, base.Humanoid);
			workerDetails.AgeLabel.SetText(base.Humanoid.Info.Age.ToString());
			workerDetails.WeightLabel.SetText(string.Format("{0} {1}", (int)base.Humanoid.Info.GetWeight(), instance.GetText("general_kg")));
			workerDetails.HeightLabel.SetText(string.Format("{0} {1}", (int)base.Humanoid.Info.Height, instance.GetText("general_cm")));
			IEnumerable<WorkerSkill> skillsOrdered = base.Humanoid.SkillsOrdered;
			int num = 0;
			int num2 = 0;
			int num3 = 0;
			foreach (WorkerSkill item in skillsOrdered)
			{
				if (item.Id != SkillType.None)
				{
					if (item.Level > num2)
					{
						num2 = item.Level;
						num = num3;
					}
					num3++;
				}
			}
			int count = base.Humanoid.Skills.Skills.Count;
			if (randomIndex == 0)
			{
				randomIndex = Random.Range(1, count);
				if (randomIndex == num)
				{
					randomIndex = ((num == count) ? (count - 1) : (num + 1));
				}
			}
			num3 = 0;
			foreach (WorkerSkill item2 in skillsOrdered)
			{
				if (item2.Id != SkillType.None)
				{
					SkillLayoutItemView at = WorkerSkills.GetAt(workerDetails.SkillsGroup, num3);
					at.gameObject.SetActive(value: true);
					if (num3 == num || num3 == randomIndex)
					{
						at.SetSkillData(base.Humanoid, item2, num3);
					}
					else
					{
						at.SetSkillData(base.Humanoid, item2, num3, hideStats);
					}
					num3++;
				}
			}
			WorkerSkills.SetActiveFromIndex(num3, active: false);
			workerDetails.PreferencesPanelView.UpdateData(base.Humanoid);
			num3 = 0;
			foreach (Perk perk in base.Humanoid.Perks)
			{
				LayoutGroupItemView at2 = WorkerPerks.GetAt(workerDetails.PerksGroup, num3);
				if (hideStats)
				{
					at2.SetImageHumanoid("perk_icon_hidden", "hidden", base.Humanoid);
				}
				else
				{
					at2.SetImageHumanoid(perk.IconPath, perk.Name, base.Humanoid);
				}
				num3++;
			}
			WorkerPerks.SetActiveFromIndex(num3, active: false);
			SetTooltipPrefab(workerDetails.gameObject);
			return lines;
		}

		private static bool CheckViewValid(UIView item)
		{
			if (item == null)
			{
				return true;
			}
			if (!(item == null))
			{
				return item.gameObject == null;
			}
			return true;
		}

		private static void CleanupWorkerSkillsPerks()
		{
			WorkerSkills.RemoveAll(CheckViewValid);
			WorkerPerks.RemoveAll(CheckViewValid);
		}
	}
}
