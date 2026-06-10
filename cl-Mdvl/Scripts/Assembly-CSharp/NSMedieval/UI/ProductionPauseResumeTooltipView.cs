using System;
using System.Collections.Generic;
using NSEipix.Base;
using NSMedieval.Controllers;
using NSMedieval.State;

namespace NSMedieval.UI
{
	public class ProductionPauseResumeTooltipView : TooltipViewNew
	{
		[NonSerialized]
		private ProductionInstance productionInstance;

		public void SetTooltipData(ProductionInstance productionInstance)
		{
			this.productionInstance = productionInstance;
		}

		protected override List<string> GetLinesToShow()
		{
			ClearLines();
			if (productionInstance == null)
			{
				return lines;
			}
			bool flag = productionInstance.State == ProductionState.Paused;
			AppendLine(MonoSingleton<LocalizationController>.Instance.GetText(flag ? "ingame_menu_resume" : "menu_pause_production"));
			return lines;
		}
	}
}
