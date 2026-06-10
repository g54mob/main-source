using System.Collections.Generic;
using NSEipix.Base;
using NSMedieval.Controllers;

namespace NSMedieval.UI
{
	public class DateTimeDetailsTooltip : TooltipViewNew
	{
		protected override List<string> GetLinesToShow()
		{
			ClearLines();
			AppendLine(MonoSingleton<LocalizationController>.Instance.GetText("date_time_details_title"), TooltipStyles.TooltipTitle);
			AppendLine(string.Format("{0}: {1}", MonoSingleton<LocalizationController>.Instance.GetText("days_from_start"), GlobalSaveController.CurrentVillageData.DateAndTime.DaysTotal));
			AppendLine(MonoSingleton<LocalizationController>.Instance.GetText("date_time_details_info") ?? "");
			return base.Lines;
		}
	}
}
