using System;
using NSMedieval.State;
using NSMedieval.StatsSystem;
using NSMedieval.UI.Utils;
using UnityEngine;
using UnityEngine.UI;

namespace NSMedieval.UI
{
	public class AlignmentLayoutItemView : LayoutGroupItemView
	{
		private readonly int skillLevelSliderLeft = 1;

		private readonly int skillLevelSliderRight = 2;

		private readonly int trendArrowLeft = 3;

		private readonly int trendArrowRight = 4;

		[SerializeField]
		private Image leftBar;

		[SerializeField]
		private Image rightBar;

		private readonly string defaultFill = "fill_bar_inner_part";

		private readonly string lockedFill = "fill_bar_inner_part_orange";

		public void SetAlignmentData(StatType alignmentType, float value, HumanoidInstance humanoid)
		{
			string text = alignmentType.ToString();
			text = text.Substring(0, text.LastIndexOf("Alignment", StringComparison.Ordinal));
			bool flag = false;
			if (humanoid.IsStatsInitialized)
			{
				flag = humanoid.Stats.GetStat(alignmentType).IsLocked;
			}
			string text2 = (flag ? (" (" + base.Localize.GetText("lock_state_locked") + ")") : string.Empty);
			SetText(base.Localize.GetText("menu_character_" + text, humanoid) + text2);
			base.GroupItems[trendArrowLeft].SetActive(value: false);
			base.GroupItems[trendArrowRight].SetActive(value: false);
			base.GroupItems[skillLevelSliderLeft].GetComponent<Slider>().value = 0f;
			base.GroupItems[skillLevelSliderRight].GetComponent<Slider>().value = 0.5f;
			HandleLockedStateChange(flag);
			if (value <= 0.5f)
			{
				float value2 = Mathf.Clamp(0.5f - value, 0f, 0.5f);
				base.GroupItems[skillLevelSliderLeft].GetComponent<Slider>().value = value2;
				base.GroupItems[skillLevelSliderRight].GetComponent<Slider>().value = 0f;
			}
			else
			{
				float value3 = Mathf.Clamp(value, 0.5f, 1f);
				base.GroupItems[skillLevelSliderLeft].GetComponent<Slider>().value = 0f;
				base.GroupItems[skillLevelSliderRight].GetComponent<Slider>().value = value3;
			}
			(base.TooltipNew as AlignmentTooltipView)?.SetTooltipData(humanoid, value, alignmentType, flag);
		}

		private void HandleLockedStateChange(bool isLocked)
		{
			if (isLocked)
			{
				leftBar.sprite = AssetUtils.GetSprite(lockedFill);
				rightBar.sprite = AssetUtils.GetSprite(lockedFill);
			}
			else
			{
				leftBar.sprite = AssetUtils.GetSprite(defaultFill);
				rightBar.sprite = AssetUtils.GetSprite(defaultFill);
			}
		}
	}
}
