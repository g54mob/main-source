using System;
using System.Collections.Generic;

namespace Gh.Tk.UI
{
	public abstract class ScheduleTimelineItem
	{
		public Dictionary<string, string> InvalidReasons;

		public Action<int> OnHourChanged;

		public bool NoSameTypeOverlap { get; set; }

		public int Length { get; set; }

		public bool IsHistorical { get; set; }

		public string GetInvalidReason(string checkName)
		{
			return null;
		}

		public abstract string GetDisplayNameKey();

		public abstract void OnRemoved();

		public abstract TooltipData GetTooltipData();

		public virtual bool IsValid(int itemHour, ScheduleTimelineItem checkItem, int checkItemHour, out string invalidReason)
		{
			invalidReason = null;
			return false;
		}
	}
}
