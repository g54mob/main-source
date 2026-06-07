using System.Text;
using TMPro;
using UnityEngine.UI;

public class SkillDisplayRegion : MenuButton
{
	public TextMeshProUGUI label;

	public Slider progressBar;

	private int lastDisplayedLevel = int.MinValue;

	private Skill skill;

	private bool isExportSkill;

	public void LoadSkill(StateManager s)
	{
		skill = s.skill;
		progressBar.gameObject.SetActive(!s.ignoreSkillIncrement);
		isExportSkill = s is TradingState;
	}

	public void UpdateSimulationDisplay()
	{
		if (skill != null)
		{
			skill.experience.CalcProgress();
			progressBar.value = skill.experience.progressToNextLevel;
			if (skill.level != lastDisplayedLevel)
			{
				ReloadLabelParent();
			}
		}
	}

	public void ReloadLabelParent()
	{
		TextDisplay.FormatLevelAbbreviation(label, skill.level);
		lastDisplayedLevel = skill.level;
	}

	public override string HighlightText()
	{
		StringBuilder highlightTextBuilder = TextDisplay.highlightTextBuilder;
		highlightTextBuilder.Clear();
		if (isExportSkill)
		{
			highlightTextBuilder.AppendFormat(TextDisplay.KeyValueFormatSpaced, "Trading".Localized(), TextDisplay.GetFormattedLevelAbbreviation(skill.level));
		}
		else
		{
			highlightTextBuilder.AppendFormat(TextDisplay.KeyValueFormatSpaced, "Skill".Localized(), TextDisplay.GetFormattedLevelAbbreviation(skill.level));
		}
		highlightTextBuilder.Append(TextDisplay.NewLine);
		TextDisplay.debug = true;
		string arg = string.Format(TextDisplay.FractionFormat, TextDisplay.LocalizedNumber(skill.experience.points - (double)skill.experience.currentLevelFloor), TextDisplay.LocalizedNumber(skill.experience.currentLevelCeil - skill.experience.currentLevelFloor));
		highlightTextBuilder.AppendFormat(TextDisplay.KeyValueFormatSpaced, "ExperiencePointsShort".Localized(), arg);
		TextDisplay.debug = false;
		string arg2 = TextDisplay.LabelForMultiplier(skill.ProductionMultiplier());
		highlightTextBuilder.Append(TextDisplay.NewLine);
		highlightTextBuilder.AppendFormat(TextDisplay.KeyValueFormatSpaced, "SpeedBoost".Localized(), arg2);
		return highlightTextBuilder.ToString();
	}
}
