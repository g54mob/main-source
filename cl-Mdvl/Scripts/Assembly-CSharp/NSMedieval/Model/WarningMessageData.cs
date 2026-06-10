using System;
using System.Collections.Generic;
using NSMedieval.State;
using NSMedieval.UI;

namespace NSMedieval.Model
{
	public class WarningMessageData
	{
		public delegate void ProcessTooltipDataDelegate(List<string> textLines, WarningMessageData warningMessageData);

		public readonly bool ShowInPlayerVillageOnly;

		public ProcessTooltipDataDelegate ProcessTooltipDataAction { get; private set; }

		public Action<WarningMessageData> ClickAction { get; set; }

		public Action<WarningMessageData> CloseClickAction { get; private set; }

		public string ID { get; private set; }

		public WarningMessageCategory Category { get; }

		public string Text { get; private set; }

		public string Tooltip { get; set; }

		public string Icon { get; private set; }

		public int Timer { get; private set; }

		public FactionInstance FactionInstance { get; set; }

		public bool ShouldShow
		{
			get
			{
				if (GlobalSaveController.CurrentVillageData.IsSecondMap)
				{
					return !ShowInPlayerVillageOnly;
				}
				return true;
			}
		}

		public WarningMessageData(WarningMessageCategory category, string text, string tooltip, string icon, Action<WarningMessageData> clickAction = null, ProcessTooltipDataDelegate processTooltipDataAction = null, Action<WarningMessageData> closeClickAction = null, bool showInPlayerVillageOnly = true, string id = "")
		{
			Category = category;
			Text = text;
			Tooltip = tooltip;
			Icon = icon;
			ClickAction = clickAction;
			CloseClickAction = closeClickAction;
			ProcessTooltipDataAction = processTooltipDataAction;
			ShowInPlayerVillageOnly = showInPlayerVillageOnly;
			ID = id;
		}

		public void SetTimer(int timeMinutes)
		{
			Timer = timeMinutes;
		}

		public void UpdateData(string textUpdated, string tooltipUpdated = null, string iconUpdated = "")
		{
			if (Text != null)
			{
				Text = textUpdated;
			}
			if (Tooltip != null)
			{
				Tooltip = tooltipUpdated;
			}
			if (Icon != null && iconUpdated != string.Empty)
			{
				Icon = iconUpdated;
			}
		}

		public override string ToString()
		{
			return $"(type: {Category}, text: {Text}, tooltip: {Tooltip})";
		}

		public void Dispose()
		{
			ClickAction = null;
			CloseClickAction = null;
			ProcessTooltipDataAction = null;
		}
	}
}
