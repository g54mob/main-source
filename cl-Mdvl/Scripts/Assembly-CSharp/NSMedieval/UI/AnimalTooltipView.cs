using System.Collections.Generic;
using System.Linq;
using NSMedieval.State;
using NSMedieval.UI.Utils;
using NSMedieval.View.Animals;

namespace NSMedieval.UI
{
	public class AnimalTooltipView : TooltipViewNew
	{
		protected override List<string> GetLinesToShow()
		{
			ClearLines();
			AnimalView component = base.gameObject.GetComponent<AnimalView>();
			AnimalInstance animalInstance = component.AnimalInstance;
			AppendLine(component.GetSimpleName());
			if (animalInstance.Storage.ResourceCount != 1)
			{
				return base.Lines;
			}
			ResourceInstance resourceInstance = animalInstance.Storage.Resources.FirstOrDefault((ResourceInstance item) => item.Amount > 0);
			if (resourceInstance != null && resourceInstance.Amount > 0)
			{
				AppendLine($"{ResourceUtils.GetTextIcon(resourceInstance.Blueprint)} {ResourceUtils.GetLocalizedResourceName(resourceInstance.Blueprint)} x {resourceInstance.Amount}");
			}
			return base.Lines;
		}
	}
}
