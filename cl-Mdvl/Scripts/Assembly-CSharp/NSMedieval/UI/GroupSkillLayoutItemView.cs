using NSMedieval.Model;
using UnityEngine.UI;

namespace NSMedieval.UI
{
	public class GroupSkillLayoutItemView : SkillLayoutItemView
	{
		public void SetSkillData(WorkerSkill skill, string tooltipText)
		{
			SetSkillLevelText(skill.Level);
			base.TooltipNew.SetSingleLineTooltip(tooltipText);
			base.GoalPrefsGroup.SetData(skill.GetGoalPreferenceLevel());
			if (base.GroupItems[base.SkillLevelSlider] != null)
			{
				base.GroupItems[base.SkillLevelSlider].GetComponent<Slider>().value = skill.Level;
			}
		}
	}
}
