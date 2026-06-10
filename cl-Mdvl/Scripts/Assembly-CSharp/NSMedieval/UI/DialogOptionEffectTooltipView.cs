using System.Collections.Generic;
using NSEipix.Base;
using NSMedieval.Controllers;

namespace NSMedieval.UI
{
	public class DialogOptionEffectTooltipView : CreatureStatsTooltipView
	{
		private List<string> tooltipArgs;

		public void SetTooltipArgs(List<string> tooltipArgs)
		{
			this.tooltipArgs = tooltipArgs;
		}

		protected override List<string> GetLinesToShow()
		{
			ClearLines();
			if (!string.IsNullOrEmpty(base.KeyId))
			{
				AppendLine(MonoSingleton<LocalizationController>.Instance.GetText("dialogOptionEffect_" + base.KeyId));
			}
			foreach (string tooltipArg in tooltipArgs)
			{
				AppendLine(tooltipArg, TooltipStyles.TooltipDescriptionLine);
			}
			if (base.Humanoid != null)
			{
				AppendLine(string.Empty);
			}
			return base.GetLinesToShow();
		}
	}
}
