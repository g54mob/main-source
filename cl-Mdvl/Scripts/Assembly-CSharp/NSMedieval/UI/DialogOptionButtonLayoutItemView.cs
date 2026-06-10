using System.Collections.Generic;
using NSEipix;
using NSMedieval.Dialogs.Data;
using UnityEngine;

namespace NSMedieval.UI
{
	public class DialogOptionButtonLayoutItemView : ButtonLayoutItemView
	{
		[SerializeField]
		private LayoutGroupView optionsGroup;

		private readonly List<BasicLayoutItemView> optionEffects = new List<BasicLayoutItemView>();

		public void SetTooltipData(List<TooltipData> tooltips)
		{
			if (tooltips == null)
			{
				return;
			}
			foreach (TooltipData tooltip in tooltips)
			{
				if (optionEffects.GetNext(optionsGroup).TooltipNew is DialogOptionEffectTooltipView dialogOptionEffectTooltipView)
				{
					dialogOptionEffectTooltipView.SetTooltipArgs(tooltip.Args);
					dialogOptionEffectTooltipView.SetTooltipData(tooltip.Key, tooltip.Humanoid);
				}
			}
		}

		private void OnEnable()
		{
			optionEffects.SetAllActive(active: false);
		}
	}
}
