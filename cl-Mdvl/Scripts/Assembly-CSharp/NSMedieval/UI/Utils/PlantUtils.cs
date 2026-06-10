using System.Collections.Generic;
using System.Globalization;
using System.Text;
using NSEipix;
using NSEipix.Repository;
using NSMedieval.Model;
using NSMedieval.Repository;
using NSMedieval.Types;

namespace NSMedieval.UI.Utils
{
	public static class PlantUtils
	{
		public static string GetLocalizedName(string id)
		{
			PlantMapResource byID = Repository<PlantMapResourceRepository, PlantMapResource>.Instance.GetByID(id);
			if (!(byID == null))
			{
				return UiUtils.Localize.GetText(LocKeyUtils.GetName(byID.LocKeys));
			}
			return id;
		}

		public static string GetLocalizedLink(string id)
		{
			PlantMapResource byID = Repository<PlantMapResourceRepository, PlantMapResource>.Instance.GetByID(id);
			if ((object)byID != null)
			{
				PlantMapResource plantMapResource = byID;
				return UiUtils.GetLocalizedAlmanacLink(LocKeyUtils.GetName(plantMapResource.LocKeys));
			}
			return GetLocalizedName(id);
		}

		public static List<string> GetInfoLines(PlantMapResource plant)
		{
			List<string> obj = new List<string>
			{
				GetLocalizedCultivable(plant),
				GetLocalizedGrowsOn(plant),
				GetLocalizedGrowTime(plant),
				GetLocalizedSowTime(plant)
			};
			obj.AddIfNotNullOrEmpty(GetLocalizedCoverLink(plant));
			obj.AddIfNotNullOrEmpty(GetLocalizedResources(plant));
			return obj;
		}

		private static string GetLocalizedResources(PlantMapResource plant)
		{
			if (plant.StorableResources == null || plant.StorableResources.Count == 0)
			{
				return string.Empty;
			}
			StringBuilder stringBuilder = new StringBuilder();
			stringBuilder.AppendLine(UiUtils.Localize.GetText("base_yield_peak") + ":");
			foreach (KeyValuePair<string, string> yieldResource in GetYieldResources(plant))
			{
				string spriteAsset = AssetUtils.GetSpriteAsset(yieldResource.Key);
				string localizedAlmanacLink = UiUtils.GetLocalizedAlmanacLink("resource_name_" + yieldResource.Key);
				stringBuilder.AppendLine("<indent=10%><style=AltColor>~" + yieldResource.Value + "</style></indent><indent=20%> " + spriteAsset + " " + localizedAlmanacLink + "</indent>");
			}
			return stringBuilder.ToString();
		}

		public static string GetLocalizedCoverLink(PlantMapResource plant)
		{
			if (plant.AttackTraversePenalty != 0f)
			{
				return string.Format("{0}: <style=AltColor>{1}%</style>", UiUtils.GetLocalizedAlmanacLink("cover_percentage"), (int)(plant.AttackTraversePenalty * 100f));
			}
			return string.Empty;
		}

		private static string GetLocalizedSowTime(PlantMapResource plant)
		{
			return string.Format("{0}: <style=AltColor>{1}</style>", UiUtils.Localize.GetText("plant_sow_time"), plant.SowTime);
		}

		private static string GetLocalizedGrowTime(PlantMapResource plant)
		{
			float num = 0f;
			foreach (PlantLifePhases lifePhase in plant.LifePhases)
			{
				num += lifePhase.DurationDays;
			}
			return string.Format("{0}: <style=AltColor>{1} {2}</style>", UiUtils.Localize.GetText("crop_grow_time"), num, UiUtils.Localize.GetText("general_days"));
		}

		private static string GetLocalizedGrowsOn(PlantMapResource plant)
		{
			List<string> list = new List<string>();
			foreach (string item in plant.GrowsOn)
			{
				list.Add("voxel_" + item);
			}
			return UiUtils.Localize.GetText("plant_grows_on") + ": <style=AltColor>" + UiUtils.Localize.JoinLocalized(list) + "</style>";
		}

		private static string GetLocalizedCultivable(PlantMapResource plant)
		{
			return UiUtils.Localize.GetText("plant_cultivable") + ": <style=AltColor>" + UiUtils.GetLocalizedYesNo(plant.Cultivable) + "</style>";
		}

		public static IEnumerable<KeyValuePair<string, string>> GetYieldResources(PlantMapResource plant)
		{
			List<KeyValuePair<string, string>> list = new List<KeyValuePair<string, string>>();
			int num = ((plant.HarvestPhase == -1) ? plant.CutPhase : plant.HarvestPhase);
			if (num == -1)
			{
				num = plant.LifePhases.Count - 1;
			}
			for (int i = 0; i < plant.StorableResources.Count; i++)
			{
				if (plant.LifeCyclesCount <= 0 || plant.StorableResources[i].Orders.HasFlag(OrderType.Harvesting))
				{
					string resourceId = plant.StorableResources[i].ResourceId;
					int min = plant.LifePhases[num].ResourcesRange[i].Min;
					if (min > 0)
					{
						list.Add(new KeyValuePair<string, string>(resourceId, min.ToString(CultureInfo.CurrentCulture)));
					}
				}
			}
			return list;
		}
	}
}
