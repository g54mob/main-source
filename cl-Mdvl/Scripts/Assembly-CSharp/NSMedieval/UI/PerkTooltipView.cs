using System;
using System.Collections.Generic;
using NSMedieval.State;
using NSMedieval.UI.Utils;

namespace NSMedieval.UI
{
	public class PerkTooltipView : TooltipViewNew
	{
		[NonSerialized]
		private HumanoidInstance humanoidInstance;

		private string perkId;

		public void Init(string perkId, HumanoidInstance humanoidInstance)
		{
			this.perkId = perkId;
			this.humanoidInstance = humanoidInstance;
		}

		protected override List<string> GetLinesToShow()
		{
			return HumanoidUtils.GetPerkTooltipLines(perkId, humanoidInstance);
		}
	}
}
