using System;
using System.Collections.Generic;

namespace NSMedieval.UI.ScenarioEditor
{
	public struct ListPopupItemData
	{
		public List<string> TooltipLines;

		public string ID { get; private set; }

		public string LocalizedName { get; private set; }

		public Action Callback { get; private set; }

		public string ImagePath { get; private set; }

		public static ListPopupItemData CreateInstance(string id, string localizedName, Action callback, List<string> tooltipLines = null, string imagePath = "")
		{
			return new ListPopupItemData
			{
				ID = id,
				LocalizedName = localizedName,
				Callback = callback,
				TooltipLines = tooltipLines,
				ImagePath = imagePath
			};
		}
	}
}
