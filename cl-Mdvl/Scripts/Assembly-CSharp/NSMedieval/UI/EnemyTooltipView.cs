using System.Collections.Generic;
using NSEipix.Base;
using NSMedieval.Controllers;
using NSMedieval.State;
using NSMedieval.View;

namespace NSMedieval.UI
{
	public class EnemyTooltipView : TooltipViewNew
	{
		protected override List<string> GetLinesToShow()
		{
			ClearLines();
			HumanoidInstance humanoidInstance = base.gameObject.GetComponent<NPCView>().HumanoidInstance;
			if (humanoidInstance == null)
			{
				return lines;
			}
			string singleSelectName = humanoidInstance.ActiveBehaviour.GetSingleSelectName();
			if (!string.IsNullOrEmpty(singleSelectName))
			{
				AppendLine(singleSelectName);
			}
			else
			{
				AppendLine(MonoSingleton<LocalizationController>.Instance.GetText(humanoidInstance.Id));
			}
			return lines;
		}
	}
}
