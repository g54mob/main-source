using System;
using System.Collections.Generic;
using NSEipix;
using NSEipix.Base;
using NSEipix.Repository;
using NSMedieval.BuildingComponents;
using NSMedieval.Controllers;
using NSMedieval.Model;
using NSMedieval.Repository;
using NSMedieval.State;
using NSMedieval.UI.Utils;
using UnityEngine;

namespace NSMedieval.UI
{
	public class SelectionMiddleGenericView : SelectionMiddleView
	{
		[SerializeField]
		private LayoutGroupView resourcesGroup;

		[SerializeField]
		private LayoutGroupView storageContent;

		[SerializeField]
		private LayoutGroupView storageInfo;

		[SerializeField]
		private LayoutGroupView equipmentStatsGroup;

		[SerializeField]
		private LayoutGroupView buildingPileImageInfo;

		[SerializeField]
		private FillBarLayoutItemView materialType;

		[NonSerialized]
		private List<FillBarLayoutItemView> buildingPileImageInfos = new List<FillBarLayoutItemView>();

		[NonSerialized]
		private List<FillBarLayoutItemView> equipment = new List<FillBarLayoutItemView>();

		[NonSerialized]
		private List<FillBarLayoutItemView> resources = new List<FillBarLayoutItemView>();

		[NonSerialized]
		private List<FillBarLayoutItemView> storage = new List<FillBarLayoutItemView>();

		[NonSerialized]
		private List<FillBarLayoutItemView> storageInfos = new List<FillBarLayoutItemView>();

		private void OnEnable()
		{
			base.TabSelectedAction += UpdateSelectedTab;
		}

		private void OnDisable()
		{
			base.TabSelectedAction -= UpdateSelectedTab;
		}

		public void InitializeBody(InfoPanelBody body)
		{
			UpdateBody(body);
			MonoSingleton<TaskController>.Instance.WaitForNextFrame().Then(delegate
			{
				UpdateSelectedTab(base.CurrentIndex, active: true);
			});
		}

		public void UpdateBody(InfoPanelBody body)
		{
			base.CurrentBody = body;
			base.Tabs[1].gameObject.SetActive(base.CurrentBody.Descriptions.Count > 0);
			base.Tabs[2].gameObject.SetActive(base.CurrentBody.Infos.Count > 0);
			if (base.CurrentBody.Modifiers.Count > 0 || base.CurrentBody.Stats.Count > 0 || base.CurrentBody.Resources.Count > 0 || base.CurrentBody.EquipmentStats.Count > 0)
			{
				UpdateSelectedTab(base.CurrentIndex, active: true);
			}
		}

		private void UpdateMaterial()
		{
			if (base.CurrentBody == null || string.IsNullOrEmpty(base.CurrentBody.ObjectMaterial))
			{
				materialType.SetText(string.Empty);
				materialType.gameObject.SetActive(value: false);
			}
			else
			{
				materialType.gameObject.SetActive(value: true);
				materialType.SetText(base.CurrentBody.ObjectMaterial);
			}
		}

		private void UpdateEquipment()
		{
			if (base.CurrentBody == null)
			{
				equipment.SetAllActive(active: false);
				return;
			}
			int fromIndex = 0;
			foreach (InfoEquipmentStat equipmentStat in base.CurrentBody.EquipmentStats)
			{
				FillBarLayoutItemView at = equipment.GetAt(equipmentStatsGroup, fromIndex++);
				at.SetBasicData(equipmentStat.StatValue, equipmentStat.StatName, equipmentStat.ImageName, equipmentStat.ImageName);
				at.TooltipNew.SetSingleLineTooltip(equipmentStat.Tooltip);
			}
			equipment.SetActiveFromIndex(fromIndex, active: false);
		}

		private void UpdateResources()
		{
			if (base.CurrentBody == null)
			{
				return;
			}
			int num = 0;
			foreach (InfoPanelResource resource in base.CurrentBody.Resources)
			{
				FillBarLayoutItemView at = resources.GetAt(resourcesGroup, num);
				num++;
				string text = resource.ResourceValue;
				if (resource.ResourceValues != null)
				{
					text = $"{resource.ResourceValues.Min}/{resource.ResourceValues.Max}";
				}
				at.SetBasicData(text, resource.Id, ResourceUtils.GetIconPath(resource.Id), resource.Id.ToLower());
				at.TooltipNew.SetLines(ResourceUtils.GetTooltipData(resource.Id));
			}
			resources.SetActiveFromIndex(num, active: false);
		}

		private void UpdateStoredResources()
		{
			if (base.CurrentBody?.StorageResources == null)
			{
				storage.SetAllActive(active: false);
				return;
			}
			int num = 0;
			for (int i = 0; i < base.CurrentBody.StorageResources.Count; i++)
			{
				ResourcePileInstance resourcePileInstance = base.CurrentBody.StorageResources[i];
				ResourceInstance resourceInstance = resourcePileInstance?.GetStoredResource();
				if (resourceInstance == null || resourcePileInstance.HasDisposed)
				{
					num++;
					continue;
				}
				FillBarLayoutItemView at = storage.GetAt(storageContent, i - num);
				StorageContentTooltipView component = at.GetComponent<StorageContentTooltipView>();
				string localizedInheritedName = resourceInstance.LocalizedInheritedName;
				string text = MonoSingleton<LocalizationController>.Instance.GetText(LocKeyUtils.GetName(resourceInstance.Blueprint.LocKeys));
				string text2 = (string.IsNullOrEmpty(localizedInheritedName) ? $"{resourceInstance.Amount}" : $"{resourceInstance.Amount} {text} ({localizedInheritedName})");
				at.SetBasicData(text2, resourcePileInstance.BlueprintId, resourcePileInstance.Blueprint.IconPath, resourcePileInstance.Blueprint.HasQuality ? resourcePileInstance.Blueprint.ProtoId.ToLower() : resourcePileInstance.BlueprintId.ToLower());
				component.Setup(resourcePileInstance);
				component.RefreshTooltip();
			}
			storage.SetActiveFromIndex(base.CurrentBody.StorageResources.Count - num, active: false);
		}

		private void UpdateStorageInfoInStatsMenu()
		{
			storageInfos.SetAllActive(active: false);
			if (base.CurrentBody != null && Repository<BaseBuildingRepository, BaseBuildingBlueprint>.Instance.TryGetValue(base.CurrentBody.ObjectId, out var model) && model != null && !string.IsNullOrEmpty(model.ShelfComponentID))
			{
				ShelfComponentBlueprint byID = Repository<ShelfComponentRepository, ShelfComponentBlueprint>.Instance.GetByID(model.ShelfComponentID);
				if (byID != null)
				{
					storageInfos.GetNext(storageInfo).SetText(BuildingUtils.GetLocalizedStorableCategories(byID));
				}
			}
		}

		private void UpdateBuildingPileImage()
		{
			buildingPileImageInfos.SetAllActive(active: false);
			if (base.CurrentBody == null)
			{
				return;
			}
			string text = "_pile";
			if (base.CurrentBody.ObjectId.EndsWith(text))
			{
				string id = base.CurrentBody.ObjectId.Substring(0, base.CurrentBody.ObjectId.Length - text.Length);
				Resource byID = Repository<ResourceRepository, Resource>.Instance.GetByID(id);
				if (!(byID == null) && !string.IsNullOrEmpty(byID.BuildingBlueprintID))
				{
					FillBarLayoutItemView next = buildingPileImageInfos.GetNext(buildingPileImageInfo);
					next.SetDataText(string.Empty);
					next.SetImageData(ResourceUtils.GetIconPath(id));
					next.TooltipNew.SetLines(ResourceUtils.GetTooltipData(id));
				}
			}
		}

		private void UpdateSelectedTab(int index, bool active)
		{
			if (!LoadingController.IsSceneTransition && !LoadingController.IsLeavingMainScene)
			{
				if (index >= base.Tabs.Length)
				{
					index = 0;
				}
				switch (index)
				{
				case 1:
					UpdateInfos();
					break;
				case 2:
					UpdateLifeLogs();
					break;
				default:
					UpdateCommonStats();
					UpdateMaterial();
					UpdateResources();
					UpdateEquipment();
					UpdateStoredResources();
					UpdateStorageInfoInStatsMenu();
					UpdateBuildingPileImage();
					break;
				}
				Refresh();
			}
		}
	}
}
