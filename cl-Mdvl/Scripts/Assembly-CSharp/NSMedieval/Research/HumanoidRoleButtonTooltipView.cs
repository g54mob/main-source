using System.Collections.Generic;
using NSMedieval.UI;
using NSMedieval.UI.Utils;

namespace NSMedieval.Research
{
	public class HumanoidRoleButtonTooltipView : CreatureBaseTooltipView
	{
		protected override List<string> GetLinesToShow()
		{
			ClearLines();
			AppendLines(HumanoidRoleUtils.GetPossibleRoleLevelUpTooltipLines(base.Humanoid));
			return base.GetLinesToShow();
		}
	}
}
