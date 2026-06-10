using System.Collections.Generic;
using System.Globalization;
using NSEipix.Base;
using NSMedieval.Model;
using NSMedieval.Research;
using NSMedieval.Tools;
using NSMedieval.UI.Utils;

namespace NSMedieval.UI
{
	public class WarningMessageTooltipView : TooltipViewNew
	{
		private WarningMessageData warningMessageData;

		public void SetWarningData(WarningMessageData message)
		{
			warningMessageData = message;
		}

		protected override List<string> GetLinesToShow()
		{
			ClearLines();
			if (warningMessageData == null)
			{
				return lines;
			}
			string text = warningMessageData.Text.ToLocalized(BodyType.None);
			string text2 = warningMessageData.Tooltip.ToLocalized(BodyType.None);
			if (warningMessageData.FactionInstance != null)
			{
				string nameLocalized = warningMessageData.FactionInstance.NameLocalized;
				text2 = text2.Replace("<faction_name>", nameLocalized);
				text = text.Replace("<faction_name>", nameLocalized);
			}
			if (text.Contains("<research_count>"))
			{
				text = text.Replace("<research_count>", MonoSingleton<ResearchManager>.Instance.GetUnlockableNodesCount().ToString(CultureInfo.CurrentCulture));
			}
			AppendLine(TextFormatting.FormatTextVariables(text), TooltipStyles.TooltipTitle);
			AppendLine(TextFormatting.FormatTextVariables(text2), TooltipStyles.TooltipDescriptionLine);
			warningMessageData.ProcessTooltipDataAction?.Invoke(lines, warningMessageData);
			return lines;
		}
	}
}
