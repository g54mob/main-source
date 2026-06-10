using System.Collections.Generic;
using System.Text;
using FoxyVoxel.Logging;
using NSEipix.Base;
using NSMedieval.Controllers;
using NSMedieval.MovableBuildings;
using NSMedieval.StatsSystem;
using NSMedieval.Tools;
using NSMedieval.UI.Utils;
using UnityEngine;

namespace NSMedieval.UI
{
	public class BuildingPileTooltipView : TooltipViewNew
	{
		[SerializeField]
		private GameObject infoPrefab;

		private BuildingPileView pileView;

		protected override List<string> GetLinesToShow()
		{
			if (pileView == null)
			{
				pileView = base.gameObject.GetComponent<BuildingPileView>();
			}
			MovableBuildingPileInstance movableBuildingPileInstance = pileView.MovableBuildingPileInstance;
			StatInstance stat = movableBuildingPileInstance.GetStat(StatType.Health);
			ClearLines();
			string text = ResourceUtils.GetTextIcon(movableBuildingPileInstance.BlueprintId) + " " + ResourceUtils.GetLocalizedResourcePileName(movableBuildingPileInstance.BlueprintId);
			if (movableBuildingPileInstance.IsForbidden)
			{
				text = text + "\n<style=DefaultRed>" + MonoSingleton<LocalizationController>.Instance.GetText("forbidden_resource") + "</style>";
			}
			AppendLine(text);
			if (stat != null)
			{
				float num = movableBuildingPileInstance.GetStoredResource()?.GetHealthInPercentage() ?? (-1f);
				int num2 = Mathf.RoundToInt(stat.Current);
				int num3 = Mathf.RoundToInt(stat.Max);
				if (num2 == num3 && num < 100f)
				{
					num2--;
				}
				AppendLine(string.Format("<#{0}>{1}/{2} </color>  {3}", ColorTools.GetHexColor(num2, num3), num2, num3, MonoSingleton<LocalizationController>.Instance.GetText("menu_hit_points")), TooltipStyles.TooltipDescriptionLine);
			}
			else
			{
				Log.Error("Pile durability is null, cannot add that info to tooltip.", "C:\\GIT\\dev\\Assets\\Scripts\\View\\UI\\Tooltip\\BuildingPileTooltipView.cs");
			}
			if (!string.IsNullOrEmpty(movableBuildingPileInstance.TargetBuildingId))
			{
				List<string> meshVariations = movableBuildingPileInstance.MoveBuildingResourceInstance.MeshVariations;
				if (meshVariations != null && meshVariations.Count > 0)
				{
					StringBuilder stringBuilder = new StringBuilder();
					foreach (string item in meshVariations)
					{
						string variationIconName = BuildingUtils.GetVariationIconName(movableBuildingPileInstance.TargetBuildingId, item);
						stringBuilder.Append(AssetUtils.GetSpriteAsset(variationIconName) ?? "");
					}
					AppendLine(stringBuilder.ToString(), TooltipStyles.TooltipSpriteAsset);
				}
			}
			return lines;
		}
	}
}
