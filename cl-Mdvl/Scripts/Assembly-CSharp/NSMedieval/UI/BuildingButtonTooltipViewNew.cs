using System.Collections.Generic;
using NSEipix.Base;
using NSEipix.Repository;
using NSMedieval.BuildingComponents;
using NSMedieval.Controllers;
using NSMedieval.Crops;
using NSMedieval.Manager;
using NSMedieval.Model;
using NSMedieval.Repository;
using NSMedieval.UI.Utils;

namespace NSMedieval.UI
{
	public class BuildingButtonTooltipViewNew : TooltipViewNew
	{
		private string buildingId;

		public void Init(string buildingId)
		{
			this.buildingId = buildingId;
		}

		protected override List<string> GetLinesToShow()
		{
			ClearLines();
			AppendLine(BuildingUtils.GetLocalizedName(buildingId), TooltipStyles.TooltipTitle);
			AppendLine(BuildingUtils.GetLocalizedInfo(buildingId));
			AppendLine(BuildingUtils.GetLocalizedTooltipLines(buildingId));
			string text = string.Empty;
			if (Repository<BaseBuildingRepository, BaseBuildingBlueprint>.Instance.TryGetValue(buildingId, out var model) && model != null)
			{
				if (model.Materials?.Dictionary != null)
				{
					foreach (KeyValuePair<string, int> item in model.Materials.Dictionary)
					{
						if (!(item.Key == "none"))
						{
							string text2 = item.Value.ToString();
							Resource byID = Repository<ResourceRepository, Resource>.Instance.GetByID(item.Key);
							if (MonoSingleton<ResourcePileTracker>.Instance.GetCount(byID).AllowedCount < item.Value)
							{
								text2 = $"<style=DefaultRed>{item.Value}</style>";
								text = MonoSingleton<LocalizationController>.Instance.GetText("building_error_no_resources") ?? "";
							}
							AppendLine(ResourceUtils.GetTextIcon(byID) + " " + text2 + " " + ResourceUtils.GetLocalizedResourceName(byID));
						}
					}
				}
				AppendLine(BuildingUtils.GetLocalizedRoomLinks(model));
				AppendLine(BuildingUtils.GetLocalizedPteLinks(model));
				if (!string.IsNullOrEmpty(model.DoorComponentID))
				{
					AppendLine(BuildingUtils.GetLocalizedPossibleDoorStates(model));
				}
				if (!string.IsNullOrEmpty(model.ShelfComponentID))
				{
					AppendLine(BuildingUtils.GetLocalizedStorableCategories(model));
				}
				if (string.IsNullOrEmpty(model.FuelConsumerComponentID))
				{
					AppendLine(BuildingUtils.GetLocalizedFuelLinks(model));
				}
			}
			if (!text.Equals(string.Empty))
			{
				AppendLine(ColorUtils.ColorText(text, "red") ?? "");
			}
			if (Repository<CropfieldRepository, Cropfield>.Instance.TryGetValue(buildingId, out var model2) && model2 != null && CropsManager.UseSeeds)
			{
				string text3 = string.Empty;
				Resource seedBlueprint = model2.SeedBlueprint;
				int num = 1;
				string text4 = num.ToString();
				if (MonoSingleton<ResourcePileTracker>.Instance.GetCount(seedBlueprint).AllowedCount < num)
				{
					text4 = $"<style=DefaultRed>{num}</style>";
					text3 = MonoSingleton<LocalizationController>.Instance.GetText("cropfield_error_no_seeds") ?? "";
				}
				AppendLine(ResourceUtils.GetTextIcon(seedBlueprint) + " " + text4 + " " + ResourceUtils.GetLocalizedResourceName(seedBlueprint.GetID()));
				if (!text3.Equals(string.Empty))
				{
					AppendLine(ColorUtils.ColorText(text, "red") ?? "");
				}
			}
			return lines;
		}
	}
}
