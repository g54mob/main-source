using System.Collections.Generic;
using NSEipix.Base;
using NSMedieval.Controllers;
using NSMedieval.State;
using NSMedieval.StatsSystem;
using NSMedieval.Tools;
using NSMedieval.UI.Utils;
using NSMedieval.Views.Resources;
using UnityEngine;

namespace NSMedieval.UI
{
	[RequireComponent(typeof(HumanCarcassPileView))]
	public class HumanCarcassPileTooltipView : TooltipViewNew
	{
		protected override List<string> GetLinesToShow()
		{
			ClearLines();
			HumanCarcassPileInstance humanCarcassPileInstance = GetComponentInChildren<HumanCarcassPileView>()?.ResourcePileInstance as HumanCarcassPileInstance;
			if (humanCarcassPileInstance?.GetStoredResource() == null)
			{
				return base.Lines;
			}
			CreatureBase bodyOwner = humanCarcassPileInstance.BodyOwner;
			if (bodyOwner == null)
			{
				return base.Lines;
			}
			AppendLine(ResourceUtils.GetTextIcon(humanCarcassPileInstance.Blueprint) + " " + bodyOwner.GetFullName() + " (" + MonoSingleton<LocalizationController>.Instance.GetText("dead", bodyOwner.GetInfo().BodyType) + ")", TooltipStyles.TooltipTitle);
			StatInstance stat = humanCarcassPileInstance.GetStat(StatType.Health);
			float num = humanCarcassPileInstance.GetStoredResource()?.GetHealthInPercentage() ?? (-1f);
			int num2 = Mathf.RoundToInt(stat.Current);
			int num3 = Mathf.RoundToInt(stat.Max);
			if (num2 == num3 && num < 100f)
			{
				num2--;
			}
			AppendLine($"<#{ColorTools.GetHexColor(num2, num3)}>{num2}/{num3} </color>" + "  " + MonoSingleton<LocalizationController>.Instance.GetText("menu_hit_points"), TooltipStyles.TooltipDescriptionLine);
			foreach (ResourcePileInstance item in humanCarcassPileInstance.Inventory)
			{
				if (item != null && !item.HasDisposed && !(item.Blueprint == null) && item.GetStoredResource() != null)
				{
					StatInstance stat2 = item.GetStat(StatType.Health);
					ResourceInstance storedResource = item.GetStoredResource();
					string text = ResourceUtils.GetLocalizedResourceName(storedResource.Blueprint);
					string localizedInheritedName = storedResource.LocalizedInheritedName;
					if (!string.IsNullOrEmpty(localizedInheritedName))
					{
						text = text + " (" + localizedInheritedName + ")";
					}
					string text2 = $"{ResourceUtils.GetTextIcon(item.Blueprint)} {item.GetStoredResource().Amount} {text}";
					string text3 = string.Format("<#{0}>{1}/{2}</color> {3}", ColorTools.GetHexColor(Mathf.RoundToInt(stat2.Current), Mathf.RoundToInt(stat2.Max)), Mathf.RoundToInt(stat2.Current), Mathf.RoundToInt(stat2.Max), MonoSingleton<LocalizationController>.Instance.GetText("menu_hit_points"));
					AppendLine(text2 + "  " + text3, TooltipStyles.TooltipDescriptionLine);
				}
			}
			return base.Lines;
		}
	}
}
