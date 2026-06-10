using System.Collections.Generic;
using NSEipix.Base;
using NSEipix.Repository;
using NSMedieval.BuildingComponents;
using NSMedieval.Controllers;
using NSMedieval.Manager;
using NSMedieval.Model;
using NSMedieval.Repository;
using NSMedieval.UI;
using NSMedieval.UI.Utils;

namespace NSMedieval.Research
{
	public class ItemToUnlockTooltip : TooltipViewNew
	{
		private string itemId;

		protected override List<string> GetLinesToShow()
		{
			ClearLines();
			if (string.IsNullOrEmpty(itemId))
			{
				return lines;
			}
			NSMedieval.Model.Production byID = Repository<ProductionRepository, NSMedieval.Model.Production>.Instance.GetByID(itemId);
			if (byID != null)
			{
				AppendLine(MonoSingleton<LocalizationController>.Instance.GetText(LocKeyUtils.GetName(byID.LocKeys)), TooltipStyles.TooltipTitle);
				AppendLine(MonoSingleton<LocalizationController>.Instance.GetText(LocKeyUtils.GetInfo(byID.LocKeys)), TooltipStyles.TooltipDescriptionLine);
				return lines;
			}
			AppendLine(BuildingUtils.GetLocalizedName(itemId), TooltipStyles.TooltipTitle);
			AppendLine(BuildingUtils.GetLocalizedInfo(itemId), TooltipStyles.TooltipDescriptionLine);
			if (itemId.Contains("_cropfield"))
			{
				return lines;
			}
			BaseBuildingBlueprint byID2 = Repository<BaseBuildingRepository, BaseBuildingBlueprint>.Instance.GetByID(itemId);
			if (byID2 == null)
			{
				return lines;
			}
			foreach (KeyValuePair<string, int> item in byID2.Materials.Dictionary)
			{
				string text = ((MonoSingleton<ResourcePileTracker>.Instance.GetCountByIdOrCategory(item.Key).AllowedCount < item.Value) ? $"<style=DefaultRed>{item.Value}</style>" : item.Value.ToString());
				AppendLine(ResourceUtils.GetTextIcon(item.Key) + " " + text + " " + ResourceUtils.GetLocalizedResourceName(item.Key), TooltipStyles.TooltipAttribute);
			}
			return lines;
		}

		public void SetId(string newId)
		{
			itemId = newId;
		}

		private void AppendBuildingInfoLines(string id)
		{
		}
	}
}
