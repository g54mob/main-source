using System.Collections.Generic;

namespace NSMedieval.UI
{
	public class WoundEntryLayoutItemView : LayoutGroupItemView
	{
		private int untendedIconIndex;

		private int tendedIconIndex = 1;

		private int bleedIconIndex = 2;

		private int titleIndex = 3;

		private int severityIndex = 4;

		private int backgroundIndex = 5;

		public void SetBasicData(string title, string severity, bool tended, bool bleeding, List<string> tooltipData)
		{
			SetText(titleIndex, title);
			SetText(severityIndex, severity);
			base.GroupItems[untendedIconIndex].SetActive(!tended);
			base.GroupItems[tendedIconIndex].SetActive(tended);
			base.GroupItems[bleedIconIndex].SetActive(bleeding);
			base.GroupItems[backgroundIndex].SetActive(bleeding);
			TooltipViewNew tooltipViewNew = base.TooltipNew;
			if ((object)tooltipViewNew == null)
			{
				return;
			}
			tooltipViewNew.ClearLines();
			for (int i = 0; i < tooltipData.Count; i++)
			{
				string lineStyle = TooltipStyles.TooltipDescriptionLine;
				if (i == 0)
				{
					lineStyle = TooltipStyles.TooltipTitle;
				}
				tooltipViewNew.AppendLine(tooltipData[i], lineStyle);
			}
		}
	}
}
