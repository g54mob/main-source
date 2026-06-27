using UnityEngine.EventSystems;
using Zenject;

namespace Restory.UI.Views.Tooltips
{
	public class TooltipContainer : UIBehaviour
	{
		public class Factory : PlaceholderFactory<TooltipContainer>
		{
		}

		public void AddTooltip(TooltipView tooltip)
		{
			tooltip.transform.SetParent(base.transform, worldPositionStays: false);
		}

		public void RemoveTooltip(TooltipView tooltip)
		{
			tooltip.transform.SetParent(null);
		}
	}
}
