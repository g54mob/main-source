using System.Collections.Generic;
using NSMedieval.Manager;
using NSMedieval.State;
using NSMedieval.Views.Resources;

namespace NSMedieval.UI
{
	public class ResourcePileTooltipView : TooltipViewNew
	{
		protected override List<string> GetLinesToShow()
		{
			ClearLines();
			ResourcePileView component = base.gameObject.GetComponent<ResourcePileView>();
			if (component == null || component.HasDisposed)
			{
				return lines;
			}
			ResourcePileInstance resourcePileInstance = component.ResourcePileInstance;
			if (resourcePileInstance == null || resourcePileInstance.HasDisposed || resourcePileInstance.Blueprint == null || resourcePileInstance.GetStoredResource() == null)
			{
				return lines;
			}
			lines.AddRange(ResourcePileUtils.GetTooltipLines(resourcePileInstance));
			return lines;
		}
	}
}
