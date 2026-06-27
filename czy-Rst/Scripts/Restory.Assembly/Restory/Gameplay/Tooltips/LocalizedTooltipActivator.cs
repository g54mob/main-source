using UnityEngine;

namespace Restory.Gameplay.Tooltips
{
	public class LocalizedTooltipActivator : TooltipActivatorBase
	{
		[SerializeField]
		protected string tooltipLocalizationKey;

		public string TooltipLocalizationKey => tooltipLocalizationKey;
	}
}
