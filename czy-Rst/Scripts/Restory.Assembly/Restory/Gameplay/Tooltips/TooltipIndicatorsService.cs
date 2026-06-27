using System.Collections.Generic;
using Restory.Gameplay.Common;

namespace Restory.Gameplay.Tooltips
{
	public class TooltipIndicatorsService
	{
		private readonly List<TooltipIndicator> allActiveIndicators = new List<TooltipIndicator>();

		private readonly HashSet<IActiveStateSwitchRequester> blockers = new HashSet<IActiveStateSwitchRequester>();

		public void RegisterTooltipIndicator(TooltipIndicator tooltipIndicator)
		{
			if (!allActiveIndicators.Contains(tooltipIndicator))
			{
				allActiveIndicators.Add(tooltipIndicator);
			}
		}

		public void UnregisterTooltipIndicator(TooltipIndicator tooltipIndicator)
		{
			allActiveIndicators.Remove(tooltipIndicator);
		}

		public void BlockAllIndicators(IActiveStateSwitchRequester blocker)
		{
			blockers.Add(blocker);
			foreach (TooltipIndicator allActiveIndicator in allActiveIndicators)
			{
				allActiveIndicator.BlockIndicatorVisibility();
			}
		}

		public void UnBlockAllIndicators(IActiveStateSwitchRequester blocker)
		{
			blockers.Remove(blocker);
			if (blockers.Count != 0)
			{
				return;
			}
			foreach (TooltipIndicator allActiveIndicator in allActiveIndicators)
			{
				allActiveIndicator.UnblockIndicatorVisibility();
			}
		}
	}
}
