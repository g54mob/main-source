using System.Collections.Generic;

namespace NSMedieval.UI
{
	public class StatTooltipView : TooltipViewNew
	{
		private List<KeyValuePair<string, string>> tooltipLines;

		public void SetTooltipData(List<KeyValuePair<string, string>> tooltipLines)
		{
			this.tooltipLines = tooltipLines;
		}

		protected override List<string> GetLinesToShow()
		{
			ClearLines();
			if (tooltipLines == null)
			{
				return lines;
			}
			foreach (KeyValuePair<string, string> tooltipLine in tooltipLines)
			{
				AppendLine(tooltipLine.Key, tooltipLine.Value);
			}
			return lines;
		}
	}
}
