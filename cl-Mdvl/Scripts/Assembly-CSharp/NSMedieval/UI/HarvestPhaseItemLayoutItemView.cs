using System.Collections.Generic;
using NSEipix.View.UI;

namespace NSMedieval.UI
{
	public class HarvestPhaseItemLayoutItemView : LayoutGroupItemView
	{
		private readonly int toggleIndex = 1;

		private string id;

		public CustomToggle Toggle => base.GroupItems[toggleIndex].GetComponent<CustomToggle>();

		public string ID => id;

		public void SetId(string id)
		{
			this.id = id;
		}

		public void SetData(string itemId, bool selected, List<string> tooltipData)
		{
			SetText(itemId);
			SetToggleWithoutNotify(selected);
			if (tooltipData.Count > 0)
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
