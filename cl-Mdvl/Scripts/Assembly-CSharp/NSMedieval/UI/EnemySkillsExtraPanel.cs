using System.Collections.Generic;
using NSEipix;
using NSMedieval.Model;
using NSMedieval.StatsSystem;
using UnityEngine;

namespace NSMedieval.UI
{
	public class EnemySkillsExtraPanel : SelectionExtraPanelBase
	{
		[SerializeField]
		private LayoutGroupView workerSkillGroup;

		private readonly List<SkillLayoutItemView> workerSkills = new List<SkillLayoutItemView>();

		protected override void SetupTabPanel()
		{
			int num = 0;
			foreach (WorkerSkill item in base.Humanoid.SkillsOrdered)
			{
				if (item.Id != SkillType.None)
				{
					workerSkills.GetAt(workerSkillGroup, num).SetSkillData(base.Humanoid, item, num);
					num++;
				}
			}
			workerSkills.SetActiveFromIndex(num, active: false);
			foreach (SkillLayoutItemView workerSkill in workerSkills)
			{
				workerSkill.TooltipNew.RefreshTooltip();
			}
		}

		protected override void UpdateTabPanel()
		{
			SetupTabPanel();
		}
	}
}
