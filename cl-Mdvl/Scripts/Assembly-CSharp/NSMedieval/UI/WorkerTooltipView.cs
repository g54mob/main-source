using System.Collections.Generic;
using System.Linq;
using NSMedieval.State;
using NSMedieval.UI.Utils;
using NSMedieval.View;

namespace NSMedieval.UI
{
	public class WorkerTooltipView : TooltipViewNew
	{
		protected override List<string> GetLinesToShow()
		{
			ClearLines();
			HumanoidInstance humanoidInstance = base.gameObject.GetComponent<WorkerView>().HumanoidInstance;
			AppendLine(humanoidInstance.Info.GetFullName());
			if (humanoidInstance.Storage.ResourceCount != 1)
			{
				return base.Lines;
			}
			ResourceInstance resourceInstance = humanoidInstance.Storage.Resources.FirstOrDefault((ResourceInstance item) => item.Amount > 0);
			if (resourceInstance != null && resourceInstance.Amount > 0)
			{
				AppendLine($"{ResourceUtils.GetTextIcon(resourceInstance.Blueprint)} {ResourceUtils.GetLocalizedResourceName(resourceInstance.Blueprint)} x {resourceInstance.Amount}");
			}
			return base.Lines;
		}
	}
}
