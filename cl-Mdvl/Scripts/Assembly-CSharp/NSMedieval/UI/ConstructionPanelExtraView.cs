using System.Collections.Generic;
using FoxyVoxel.Logging;
using FoxyVoxel.Logging.Core.LogMessageInterpolationHandlers;
using NSEipix;
using NSEipix.Base;
using NSEipix.Repository;
using NSMedieval.BuildingComponents;
using NSMedieval.Crops;
using NSMedieval.UI.Utils;
using UnityEngine;

namespace NSMedieval.UI
{
	public class ConstructionPanelExtraView : UIView
	{
		[SerializeField]
		private LayoutGroupView materialsPanel;

		[SerializeField]
		private LayoutGroupView infosPanel;

		[SerializeField]
		private LayoutGroupView cropfieldYieldPanel;

		[SerializeField]
		private RectTransform topContentGroup;

		[SerializeField]
		private RectTransform selectVariantGroup;

		[SerializeField]
		private LayoutGroupView subcategoryPanel;

		[SerializeField]
		private FillBarLayoutItemView headerTitle;

		private List<FillBarLayoutItemView> infoLines = new List<FillBarLayoutItemView>();

		private List<FillBarLayoutItemView> materialEntries = new List<FillBarLayoutItemView>();

		private List<FillBarLayoutItemView> yieldEntries = new List<FillBarLayoutItemView>();

		private string constructableId;

		public LayoutGroupView SubcategoryPanel => subcategoryPanel;

		protected override void OnDestroy()
		{
			base.OnDestroy();
			infoLines = null;
			materialEntries = null;
			yieldEntries = null;
		}

		public void SetupPanel(string buildingId, bool hasVariants)
		{
			Show();
			bool isEnabled;
			FVLogTraceInterpolationHandler messageBuilder = new FVLogTraceInterpolationHandler(15, 2, out isEnabled, "C:\\GIT\\dev\\Assets\\ConstructionPanelExtraView.cs");
			if (isEnabled)
			{
				messageBuilder.AppendFormatted(buildingId);
				messageBuilder.AppendLiteral(" has variants: ");
				messageBuilder.AppendFormatted(hasVariants);
			}
			Log.Trace(messageBuilder);
			constructableId = buildingId;
			headerTitle.SetText(BuildingUtils.GetLocalizedName(buildingId));
			foreach (FillBarLayoutItemView infoLine in infoLines)
			{
				infoLine.SetText(string.Empty);
			}
			foreach (FillBarLayoutItemView materialEntry in materialEntries)
			{
				materialEntry.SetText(string.Empty);
			}
			foreach (FillBarLayoutItemView yieldEntry in yieldEntries)
			{
				yieldEntry.SetText(string.Empty);
			}
			MonoSingleton<TaskController>.Instance.WaitForNextFrameUnscaled().Then(SetInfos);
			selectVariantGroup.gameObject.SetActive(hasVariants);
		}

		private void SetInfos()
		{
			Log.Debug("Set Infos", "C:\\GIT\\dev\\Assets\\ConstructionPanelExtraView.cs");
			infoLines.SetAllActive(active: false);
			materialEntries.SetAllActive(active: false);
			yieldEntries.SetAllActive(active: false);
			if (Repository<BaseBuildingRepository, BaseBuildingBlueprint>.Instance.GetByID(constructableId) != null)
			{
				foreach (KeyValuePair<string, string> material in BuildingUtils.GetMaterials(constructableId))
				{
					FillBarLayoutItemView next = materialEntries.GetNext(materialsPanel);
					next.SetBasicData(material.Value, material.Key, ResourceUtils.GetIconPath(material.Key), material.Key);
					next.TooltipNew.SetLines(ResourceUtils.GetTooltipData(material.Key));
				}
				{
					foreach (string infoLine in BuildingUtils.GetInfoLines(constructableId, Vec3Int.zero))
					{
						infoLines.GetNext(infosPanel).SetDataText(infoLine);
					}
					return;
				}
			}
			if (!(ZoneUtils.Item(constructableId) as Cropfield != null))
			{
				return;
			}
			foreach (KeyValuePair<string, string> item in ZoneUtils.GetFormattedRequiredSeed(constructableId))
			{
				FillBarLayoutItemView next2 = materialEntries.GetNext(materialsPanel);
				next2.SetBasicData(item.Value, item.Key, ResourceUtils.GetIconPath(item.Key), item.Key);
				next2.TooltipNew.SetLines(ResourceUtils.GetTooltipData(item.Key));
			}
			foreach (string infoLine2 in ZoneUtils.GetInfoLines(constructableId, showTemperature: false))
			{
				infoLines.GetNext(infosPanel).SetText(infoLine2);
			}
			List<KeyValuePair<string, string>> yieldResources = ZoneUtils.GetYieldResources(constructableId);
			if (yieldResources.Count <= 0)
			{
				return;
			}
			infoLines.GetNext(infosPanel).SetText(base.Localize.GetText("base_yield_peak") ?? "");
			foreach (KeyValuePair<string, string> item2 in yieldResources)
			{
				FillBarLayoutItemView next3 = yieldEntries.GetNext(cropfieldYieldPanel);
				next3.SetBasicData("~" + item2.Value, item2.Key, ResourceUtils.GetIconPath(item2.Key), item2.Key);
				next3.TooltipNew.SetLines(ResourceUtils.GetTooltipData(item2.Key));
			}
		}
	}
}
