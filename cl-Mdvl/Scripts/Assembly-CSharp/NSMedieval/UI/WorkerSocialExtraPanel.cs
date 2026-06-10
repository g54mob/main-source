using System.Collections.Generic;
using System.Linq;
using NSEipix;
using NSEipix.Repository;
using NSMedieval.State;
using NSMedieval.StatsSystem;
using NSMedieval.UI.Utils;
using Social;
using UnityEngine;
using UnityEngine.UI;

namespace NSMedieval.UI
{
	public class WorkerSocialExtraPanel : SelectionExtraPanelBase
	{
		[SerializeField]
		private LayoutGroupView affectionsParent;

		[SerializeField]
		private FillBarLayoutItemView socialBar;

		private readonly List<FillBarLayoutItemView> affections = new List<FillBarLayoutItemView>();

		protected override void SetupTabPanel()
		{
			StatInstance stat = base.Humanoid.Stats.GetStat(StatType.Social);
			socialBar.SetBasicData(StatUtils.GetLocalizedName(stat.Blueprint, base.Humanoid.Info.BodyType), StatType.Social.ToString(), string.Empty, string.Empty, StatUtils.GetTooltipLines(stat, base.Humanoid.Info.BodyType), stat.StatTrend, StatUtils.GetSliderValues(stat), StatUtils.GetThresholds(stat), stat.Target, invertArrows: false, string.Empty);
			int num = 0;
			foreach (HumanoidInstance worker in GlobalSaveController.CurrentVillageData.Workers)
			{
				if (worker != base.Humanoid && !worker.HasDied && !worker.HasDisposed)
				{
					FillBarLayoutItemView at = affections.GetAt(affectionsParent, num);
					num++;
					at.SetText(GetAffectionEntryText(worker));
					at.TooltipNew.ClearLines();
					List<string> affectionTooltipLines = GetAffectionTooltipLines(worker);
					if (affectionTooltipLines.Count > 0)
					{
						at.TooltipNew.AppendLine(base.Localize.GetText("most_recent_interactions"), TooltipStyles.TooltipSubtitleLineStyle);
						at.TooltipNew.AppendLines(affectionTooltipLines);
					}
				}
			}
			LayoutRebuilder.ForceRebuildLayoutImmediate(base.transform as RectTransform);
		}

		private List<string> GetAffectionTooltipLines(HumanoidInstance targetInstance)
		{
			int num = Mathf.Max(base.Humanoid.WorkerBehaviour.WorkerSocial.AffectionEffectorsLog.Count - 10, 0);
			List<string> list = new List<string>();
			for (int num2 = base.Humanoid.WorkerBehaviour.WorkerSocial.AffectionEffectorsLog.Count - 1; num2 >= num; num2--)
			{
				EffectorLogStruct effectorLogStruct = base.Humanoid.WorkerBehaviour.WorkerSocial.AffectionEffectorsLog.ElementAt(num2);
				if (effectorLogStruct.UniqueId == targetInstance.UniqueId)
				{
					StatEffector byID = Repository<EffectorRepository, StatEffector>.Instance.GetByID(effectorLogStruct.EffectorId);
					if (!(byID == null) && byID.UIGroup.HasFlag(EffectorUiGroup.Social))
					{
						float effectorValue = effectorLogStruct.EffectorValue;
						list.Add(base.Localize.GetText(LocKeyUtils.GetName(byID.LocKeys), targetInstance.Info.BodyType) + ": " + UiUtils.FormatPositiveNegative($"{effectorValue:F1}", effectorValue));
					}
				}
			}
			return list;
		}

		private string GetAffectionEntryText(HumanoidInstance targetInstance)
		{
			SocialCompatibilitySettings socialCompatibilitySettings = Repository<SocialCompatibilitySettingsRepository, SocialCompatibilitySettings>.Instance.Settings();
			float affectionTowards = base.Humanoid.WorkerBehaviour.WorkerSocial.GetAffectionTowards(targetInstance);
			float affectionTowards2 = targetInstance.WorkerBehaviour.WorkerSocial.GetAffectionTowards(base.Humanoid);
			string text = UiUtils.FormatPositiveNeutralNegative($"{affectionTowards:F0}", affectionTowards, socialCompatibilitySettings.AffectionRivalThreshold, socialCompatibilitySettings.AffectionFriendThreshold);
			string text2 = UiUtils.FormatPositiveNeutralNegative($"{affectionTowards2:F0}", affectionTowards2, socialCompatibilitySettings.AffectionRivalThreshold, socialCompatibilitySettings.AffectionFriendThreshold);
			return UiUtils.GetWorkerLink(targetInstance, targetInstance.Info.FirstName + "(" + text2 + ")") + ": " + text;
		}

		protected override void UpdateTabPanel()
		{
			SetupTabPanel();
		}
	}
}
