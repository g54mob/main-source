using System.Collections.Generic;
using NSEipix.Base;
using NSEipix.Repository;
using NSMedieval.Controllers;
using NSMedieval.Model;
using NSMedieval.Repository;
using NSMedieval.State;
using NSMedieval.StatsSystem;
using NSMedieval.Tools;
using NSMedieval.UI.Utils;
using NSMedieval.Views.Resources;
using UnityEngine;

namespace NSMedieval.UI
{
	public class EquipmentPileTooltipView : TooltipViewNew
	{
		protected override List<string> GetLinesToShow()
		{
			ClearLines();
			ResourcePileInstance resourcePileInstance = base.gameObject.GetComponent<EquipmentPileView>().ResourcePileInstance;
			if (resourcePileInstance == null || resourcePileInstance.GetStoredResource() == null)
			{
				return lines;
			}
			Equipment byID = Repository<EquipmentRepository, Equipment>.Instance.GetByID(resourcePileInstance.BlueprintId);
			if (byID == null)
			{
				return lines;
			}
			AppendLine(EquipmentUtils.GetTooltipTitle(byID), TooltipStyles.TooltipTitle);
			if (resourcePileInstance.IsForbidden)
			{
				AppendLine(MonoSingleton<LocalizationController>.Instance.GetText("forbidden_resource"), TooltipStyles.DefaultRed);
			}
			StatInstance stat = resourcePileInstance.GetStat(StatType.Health);
			float num = resourcePileInstance.GetStoredResource()?.GetHealthInPercentage() ?? (-1f);
			int num2 = Mathf.RoundToInt(stat.Current);
			int num3 = Mathf.RoundToInt(stat.Max);
			if (num2 == num3 && num < 100f)
			{
				num2--;
			}
			string line = string.Format("<#{0}>{1}/{2} </color>  {3}", ColorTools.GetHexColor(num2, num3), num2, num3, MonoSingleton<LocalizationController>.Instance.GetText("menu_hit_points"));
			AppendLine(line);
			AppendLines(EquipmentUtils.GetTooltipLines(byID, stat));
			return lines;
		}
	}
}
