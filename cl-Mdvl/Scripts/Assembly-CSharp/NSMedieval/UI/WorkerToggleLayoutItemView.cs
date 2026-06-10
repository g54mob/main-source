using System;
using System.Collections.Generic;
using NSEipix.View.UI;
using NSMedieval.State;

namespace NSMedieval.UI
{
	public class WorkerToggleLayoutItemView : LayoutGroupItemView
	{
		private readonly int toggleIndex = 1;

		[NonSerialized]
		private HumanoidInstance humanoidInstance;

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

		public HumanoidInstance HumanoidInstance => humanoidInstance;

		public void SetWorkerInstance(HumanoidInstance humanoidInstance)
		{
			this.humanoidInstance = humanoidInstance;
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
