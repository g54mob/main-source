using System;
using System.Collections.Generic;
using NSEipix.View.UI;
using NSMedieval.Village.Map;

namespace NSMedieval.UI
{
	public class SecondMapTypeLayoutItemView : LayoutGroupItemView
	{
		private readonly int toggleIndex = 1;

		[NonSerialized]
		private SecondMapType mapType;

		[NonSerialized]
		private CustomToggle toggle;

		public CustomToggle Toggle
		{
			get
			{
				if (toggle == null)
				{
					toggle = base.GroupItems[toggleIndex].GetComponent<CustomToggle>();
				}
				return toggle;
			}
		}

		public SecondMapType MapType => mapType;

		public void SetType(SecondMapType type)
		{
			mapType = type;
		}

		public void SetData(string itemId, bool selected, List<string> tooltipData = null)
		{
			SetText(itemId);
			SetToggleWithoutNotify(selected);
			if (tooltipData != null && tooltipData.Count > 0)
			{
				base.TooltipNew.SetEnabled(isEnabled: true);
				base.TooltipNew.ClearLines();
				base.TooltipNew.AppendLines(tooltipData);
			}
			else
			{
				base.TooltipNew.SetEnabled(isEnabled: false);
			}
		}

		public void SetToggleWithoutNotify(bool value)
		{
			Toggle.SetIsOnWithoutNotify(value);
		}
	}
}
