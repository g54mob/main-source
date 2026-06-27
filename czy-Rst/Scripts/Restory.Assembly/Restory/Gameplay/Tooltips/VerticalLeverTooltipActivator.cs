using Restory.Gameplay.Equipment.Levers;
using UnityEngine;

namespace Restory.Gameplay.Tooltips
{
	public class VerticalLeverTooltipActivator : LocalizedTooltipActivator, ITooltipActivatorWithCondition
	{
		[SerializeField]
		private VerticalLever verticalLever;

		[SerializeField]
		private string openStoreLocalizationKey;

		[SerializeField]
		private string closeStoreLocalizationKey;

		public bool ShouldTooltipBeShown()
		{
			if (!verticalLever.IsActive)
			{
				return false;
			}
			tooltipLocalizationKey = ((verticalLever.CurrentPosition == LeverPositions.Top) ? openStoreLocalizationKey : closeStoreLocalizationKey);
			return true;
		}
	}
}
