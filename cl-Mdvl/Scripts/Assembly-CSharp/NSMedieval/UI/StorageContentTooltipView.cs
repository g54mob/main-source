using System;
using System.Collections.Generic;
using NSEipix.Base;
using NSEipix.Repository;
using NSMedieval.Controllers;
using NSMedieval.Model;
using NSMedieval.Repository;
using NSMedieval.State;
using NSMedieval.StatsSystem;
using NSMedieval.StorageUniversal;
using NSMedieval.Tools;
using NSMedieval.UI.Utils;
using UnityEngine;

namespace NSMedieval.UI
{
	public class StorageContentTooltipView : TooltipViewNew
	{
		[NonSerialized]
		private ResourcePileInstance pile;

		public void Setup(ResourcePileInstance pile)
		{
			this.pile = pile;
		}

		protected override List<string> GetLinesToShow()
		{
			ClearLines();
			ResourceInstance resourceInstance = pile?.GetStoredResource();
			if (resourceInstance == null)
			{
				return lines;
			}
			StatInstance stat = pile.GetStat(StatType.Health);
			if (resourceInstance.Blueprint.HasQuality)
			{
				Equipment byID = Repository<EquipmentRepository, Equipment>.Instance.GetByID(pile.BlueprintId);
				string line = string.Format("<#{0}>{1}/{2} </color>  {3}", ColorTools.GetHexColor(Mathf.RoundToInt(stat.Current), Mathf.RoundToInt(stat.Max)), Mathf.RoundToInt(stat.Current), Mathf.RoundToInt(stat.Max), MonoSingleton<LocalizationController>.Instance.GetText("menu_hit_points"));
				AppendLine(ResourceUtils.GetTextIcon(pile.Blueprint) + " " + ResourceUtils.GetLocalizedResourceName(pile.Blueprint) + " ", TooltipStyles.TooltipTitle);
				AppendLine(line, TooltipStyles.TooltipDescriptionLine);
				AppendLines(EquipmentUtils.GetTooltipLines(byID, stat));
				return lines;
			}
			Resource blueprint = pile.Blueprint;
			AppendLine(ResourceUtils.GetLocalizedResourceName(blueprint), TooltipStyles.TooltipTitle);
			AppendLine(string.Format("<#{0}>{1}/{2} </color>  {3}", ColorTools.GetHexColor(Mathf.RoundToInt(stat.Current), Mathf.RoundToInt(stat.Max)), Mathf.RoundToInt(stat.Current), Mathf.RoundToInt(stat.Max), MonoSingleton<LocalizationController>.Instance.GetText("menu_hit_points")), TooltipStyles.TooltipDescriptionLine);
			StatInstance stat2 = pile.GetStat(StatType.Freshness);
			if (stat2 != null && stat2.Max != 0f)
			{
				AppendLine(string.Format("<#{0}>{1}/{2} </color>  {3}", ColorTools.GetHexColor(Mathf.RoundToInt(stat2.Current), Mathf.RoundToInt(stat2.Max)), Mathf.RoundToInt(stat2.Current), Mathf.RoundToInt(stat2.Max), MonoSingleton<LocalizationController>.Instance.GetText("menu_rot")), TooltipStyles.TooltipDescriptionLine);
			}
			StatInstance stat3 = pile.GetStat(StatType.Fermentation);
			if (stat3 != null && stat3.Max != 0f)
			{
				AppendLine(string.Format("<#{0}>{1}/{2} </color>  {3}", ColorTools.GetHexColor(Mathf.RoundToInt(stat3.Current), Mathf.RoundToInt(stat3.Max)), Mathf.RoundToInt(stat3.Current), Mathf.RoundToInt(stat3.Max), MonoSingleton<LocalizationController>.Instance.GetText("menu_ferment")), TooltipStyles.TooltipDescriptionLine);
			}
			string line2 = MonoSingleton<LocalizationController>.Instance.GetText("resource_categories") + ":\n" + ResourceUtils.GetLocalizedCategories(blueprint);
			AppendLine(line2);
			foreach (string resourcePileModifier in StorageUtils.GetResourcePileModifiers(pile))
			{
				AppendLine(resourcePileModifier, TooltipStyles.TooltipDescriptionLine);
			}
			if (LocKeyUtils.GetTooltipLines(blueprint.LocKeys, out var array))
			{
				string[] array2 = array;
				foreach (string key in array2)
				{
					AppendLine(MonoSingleton<LocalizationController>.Instance.GetText(key));
				}
			}
			return lines;
		}
	}
}
