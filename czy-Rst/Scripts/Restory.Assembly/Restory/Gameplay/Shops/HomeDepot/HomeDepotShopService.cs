using System;
using System.Collections.Generic;
using Restory.Data.Decors;
using Restory.Data.Equipment;
using Restory.Data.PC;
using Restory.Data.SaveLoad;
using Restory.Data.SaveLoad.Containers;
using Restory.Data.SaveLoad.DataMigration;
using Restory.Data.Shops.HomeDepot;
using Restory.Gameplay.Delivery;
using Restory.Gameplay.Equipment;
using Restory.Gameplay.PC;
using Restory.Gameplay.SaveLoad.Exceptions;
using Restory.Gameplay.WorkOrders.EmailOrders;
using UnityEngine;
using UnityEngine.Pool;
using Zenject;

namespace Restory.Gameplay.Shops.HomeDepot
{
	public class HomeDepotShopService : MonoBehaviour, IInitializable, ISaveableComponent, ISaveableComponentReader, ISaveableComponentWriter
	{
		private readonly Dictionary<DecorInfo, HomeDepotShopDecorItemData> decorItems = new Dictionary<DecorInfo, HomeDepotShopDecorItemData>();

		private readonly Dictionary<ToolInfo, HomeDepotShopCleaningToolItemData> cleaningToolItems = new Dictionary<ToolInfo, HomeDepotShopCleaningToolItemData>();

		private readonly Dictionary<PaintingPaletteInfo, HomeDepotShopPaintingPaletteItemData> paletteItems = new Dictionary<PaintingPaletteInfo, HomeDepotShopPaintingPaletteItemData>();

		private readonly Dictionary<PcAppInfo, HomeDepotShopPcAppItemData> pcAppItems = new Dictionary<PcAppInfo, HomeDepotShopPcAppItemData>();

		private HomeDepotShopInfo homeDepotShop;

		private AvailableToolsTrackingService availableToolsTrackingService;

		private AvailablePaintingPalettesTrackingService availablePaintingPalettesTrackingService;

		private PcAppManager pcAppManager;

		private DeliveryService deliveryService;

		[Inject]
		private void Construct(HomeDepotShopInfo homeDepotShop, AvailableToolsTrackingService availableToolsTrackingService, AvailablePaintingPalettesTrackingService availablePaintingPalettesTrackingService, PcAppManager pcAppManager, DeliveryService deliveryService)
		{
			this.homeDepotShop = homeDepotShop;
			this.availableToolsTrackingService = availableToolsTrackingService;
			this.availablePaintingPalettesTrackingService = availablePaintingPalettesTrackingService;
			this.pcAppManager = pcAppManager;
			this.deliveryService = deliveryService;
		}

		public void Initialize()
		{
			HomeDepotShopDecorItemData[] decorItemsList = homeDepotShop.DecorItemsList;
			foreach (HomeDepotShopDecorItemData homeDepotShopDecorItemData in decorItemsList)
			{
				if (homeDepotShopDecorItemData != null && (bool)homeDepotShopDecorItemData.DecorInfo)
				{
					decorItems[homeDepotShopDecorItemData.DecorInfo] = homeDepotShopDecorItemData.Clone();
				}
			}
			HomeDepotShopCleaningToolItemData[] cleaningToolsItemsList = homeDepotShop.CleaningToolsItemsList;
			foreach (HomeDepotShopCleaningToolItemData homeDepotShopCleaningToolItemData in cleaningToolsItemsList)
			{
				if (homeDepotShopCleaningToolItemData != null && (bool)homeDepotShopCleaningToolItemData.ToolInfo)
				{
					cleaningToolItems[homeDepotShopCleaningToolItemData.ToolInfo] = homeDepotShopCleaningToolItemData.Clone();
				}
			}
			HomeDepotShopPaintingPaletteItemData[] paletteItemsList = homeDepotShop.PaletteItemsList;
			foreach (HomeDepotShopPaintingPaletteItemData homeDepotShopPaintingPaletteItemData in paletteItemsList)
			{
				if (homeDepotShopPaintingPaletteItemData != null && (bool)homeDepotShopPaintingPaletteItemData.Palette)
				{
					paletteItems[homeDepotShopPaintingPaletteItemData.Palette] = homeDepotShopPaintingPaletteItemData.Clone();
				}
			}
			HomeDepotShopPcAppItemData[] pcAppItemsList = homeDepotShop.PcAppItemsList;
			foreach (HomeDepotShopPcAppItemData homeDepotShopPcAppItemData in pcAppItemsList)
			{
				if (homeDepotShopPcAppItemData != null && (bool)homeDepotShopPcAppItemData.Info)
				{
					pcAppItems[homeDepotShopPcAppItemData.Info] = homeDepotShopPcAppItemData.Clone();
				}
			}
		}

		public IEnumerable<HomeDepotShopCleaningToolItemData> GetAllowedCleaningTools()
		{
			Dictionary<ToolsCategory, int> availableMaxLevelsByCategory;
			using (CollectionPool<Dictionary<ToolsCategory, int>, KeyValuePair<ToolsCategory, int>>.Get(out availableMaxLevelsByCategory))
			{
				foreach (ToolInfo availableTool in availableToolsTrackingService.AvailableTools)
				{
					ToolsCategory toolsCategory = availableTool.ToolsCategory;
					int toolLevel = availableTool.ToolLevel;
					if (availableMaxLevelsByCategory.TryGetValue(toolsCategory, out var value))
					{
						if (toolLevel > value)
						{
							availableMaxLevelsByCategory[toolsCategory] = toolLevel;
						}
					}
					else
					{
						availableMaxLevelsByCategory[toolsCategory] = toolLevel;
					}
				}
				foreach (HomeDepotShopCleaningToolItemData value4 in cleaningToolItems.Values)
				{
					if (value4 == null || !value4.ToolInfo || !deliveryService.ContainsInPurchasedObjectsOrDeliveryBox(value4.ToolInfo))
					{
						continue;
					}
					ToolsCategory toolsCategory2 = value4.ToolInfo.ToolsCategory;
					int toolLevel2 = value4.ToolInfo.ToolLevel;
					if (availableMaxLevelsByCategory.TryGetValue(toolsCategory2, out var value2))
					{
						if (toolLevel2 > value2)
						{
							availableMaxLevelsByCategory[toolsCategory2] = toolLevel2;
						}
					}
					else
					{
						availableMaxLevelsByCategory[toolsCategory2] = toolLevel2;
					}
				}
				foreach (HomeDepotShopCleaningToolItemData value5 in cleaningToolItems.Values)
				{
					if (value5.IsHiddenInShop || !value5.ToolInfo)
					{
						continue;
					}
					int value3;
					int num = (availableMaxLevelsByCategory.TryGetValue(value5.ToolInfo.ToolsCategory, out value3) ? value3 : (-1));
					if (value5.ToolInfo.CanStoreMultipleCopies)
					{
						if (value5.ToolInfo.ToolLevel >= num)
						{
							yield return value5;
						}
					}
					else if (!availableToolsTrackingService.IsToolAvailable(value5.ToolInfo) && !deliveryService.ContainsInPurchasedObjectsOrDeliveryBox(value5.ToolInfo) && value5.ToolInfo.ToolLevel > num)
					{
						yield return value5;
					}
				}
			}
		}

		public IEnumerable<HomeDepotShopDecorItemData> GetAllowedDecorItems()
		{
			foreach (HomeDepotShopDecorItemData value in decorItems.Values)
			{
				if (!value.IsHiddenInShop && (bool)value.DecorInfo)
				{
					yield return value;
				}
			}
		}

		public IEnumerable<HomeDepotShopPaintingPaletteItemData> GetAllowedPaintingPalettes()
		{
			foreach (HomeDepotShopPaintingPaletteItemData value in paletteItems.Values)
			{
				if (!value.IsHiddenInShop && (bool)value.Palette && !DoesPlayerAlreadyHavePalette(value.Palette) && !deliveryService.ContainsInPurchasedObjectsOrDeliveryBox(value.Palette))
				{
					yield return value;
				}
			}
		}

		private bool DoesPlayerAlreadyHavePalette(PaintingPaletteInfo palette)
		{
			foreach (PaintingPaletteInfo availablePalette in availablePaintingPalettesTrackingService.AvailablePalettes)
			{
				if ((bool)availablePalette && availablePalette.ID == palette.ID)
				{
					return true;
				}
			}
			return false;
		}

		public IEnumerable<HomeDepotShopPcAppItemData> GetAllowedPcApps()
		{
			Dictionary<PcAppCategoryInfo, int> availableMaxVersionsByCategory;
			using (CollectionPool<Dictionary<PcAppCategoryInfo, int>, KeyValuePair<PcAppCategoryInfo, int>>.Get(out availableMaxVersionsByCategory))
			{
				foreach (PcAppInfo installedApp in pcAppManager.InstalledApps)
				{
					if ((bool)installedApp && !(installedApp.Category == null) && (!availableMaxVersionsByCategory.TryGetValue(installedApp.Category, out var value) || installedApp.Version > value))
					{
						availableMaxVersionsByCategory[installedApp.Category] = installedApp.Version;
					}
				}
				foreach (PcAppInfo availableApp in pcAppManager.AvailableApps)
				{
					if ((bool)availableApp && !(availableApp.Category == null) && (!availableMaxVersionsByCategory.TryGetValue(availableApp.Category, out var value2) || availableApp.Version > value2))
					{
						availableMaxVersionsByCategory[availableApp.Category] = availableApp.Version;
					}
				}
				foreach (HomeDepotShopPcAppItemData value5 in pcAppItems.Values)
				{
					if (value5 != null && (bool)value5.Info && !(value5.Info.Category == null) && deliveryService.ContainsInPurchasedObjectsOrDeliveryBox(value5.Info))
					{
						PcAppCategoryInfo category = value5.Info.Category;
						int version = value5.Info.Version;
						if (!availableMaxVersionsByCategory.TryGetValue(category, out var value3) || version > value3)
						{
							availableMaxVersionsByCategory[category] = version;
						}
					}
				}
				foreach (HomeDepotShopPcAppItemData value6 in pcAppItems.Values)
				{
					if (value6.IsHiddenInShop || !value6.Info || pcAppManager.ContainsApp(value6.Info) || deliveryService.ContainsInPurchasedObjectsOrDeliveryBox(value6.Info))
					{
						continue;
					}
					if (value6.Info.Category == null)
					{
						yield return value6;
						continue;
					}
					PcAppCategoryInfo category2 = value6.Info.Category;
					int value4;
					int num = (availableMaxVersionsByCategory.TryGetValue(category2, out value4) ? value4 : (-1));
					if (value6.Info.Version > num)
					{
						yield return value6;
					}
				}
			}
		}

		public void SetDecorItemIsHiddenInShop(DecorInfo decorInfo, bool isHiddenInShop)
		{
			if ((bool)decorInfo && decorItems.TryGetValue(decorInfo, out var value))
			{
				value.IsHiddenInShop = isHiddenInShop;
			}
		}

		public void SetCleaningToolItemIsHiddenInShop(ToolInfo toolInfo, bool isHiddenInShop)
		{
			if ((bool)toolInfo && cleaningToolItems.TryGetValue(toolInfo, out var value))
			{
				value.IsHiddenInShop = isHiddenInShop;
			}
		}

		public void SetPaletteItemIsHiddenInShop(PaintingPaletteInfo paletteInfo, bool isHiddenInShop)
		{
			if ((bool)paletteInfo && paletteItems.TryGetValue(paletteInfo, out var value))
			{
				value.IsHiddenInShop = isHiddenInShop;
			}
		}

		public void SetPcAppItemIsHiddenInShop(PcAppInfo pcAppInfo, bool isHiddenInShop)
		{
			if ((bool)pcAppInfo && pcAppItems.TryGetValue(pcAppInfo, out var value))
			{
				value.IsHiddenInShop = isHiddenInShop;
			}
		}

		public void RestoreState(object state)
		{
			try
			{
				HomeDepotShopServiceSaveData homeDepotShopServiceSaveData = DataMigrationWizard.Migrate<HomeDepotShopServiceSaveData>(state, base.gameObject);
				if (homeDepotShopServiceSaveData.DecorItems != null)
				{
					foreach (HomeDepotShopDecorItemData decorItem in homeDepotShopServiceSaveData.DecorItems)
					{
						if (decorItem?.DecorInfo != null)
						{
							decorItems[decorItem.DecorInfo] = decorItem;
						}
					}
				}
				if (homeDepotShopServiceSaveData.CleaningToolItems != null)
				{
					foreach (HomeDepotShopCleaningToolItemData cleaningToolItem in homeDepotShopServiceSaveData.CleaningToolItems)
					{
						if (cleaningToolItem?.ToolInfo != null)
						{
							cleaningToolItems[cleaningToolItem.ToolInfo] = cleaningToolItem;
						}
					}
				}
				if (homeDepotShopServiceSaveData.PaletteItems != null)
				{
					foreach (HomeDepotShopPaintingPaletteItemData paletteItem in homeDepotShopServiceSaveData.PaletteItems)
					{
						if (paletteItem?.Palette != null)
						{
							paletteItems[paletteItem.Palette] = paletteItem;
						}
					}
				}
				if (homeDepotShopServiceSaveData.PcAppItems == null)
				{
					return;
				}
				foreach (HomeDepotShopPcAppItemData pcAppItem in homeDepotShopServiceSaveData.PcAppItems)
				{
					if (pcAppItem?.Info != null)
					{
						pcAppItems[pcAppItem.Info] = pcAppItem;
					}
				}
			}
			catch (Exception innerException)
			{
				Debug.LogException(new RestoreProgressException(base.gameObject, state, innerException));
			}
		}

		public object CaptureState()
		{
			try
			{
				return new HomeDepotShopServiceSaveData
				{
					DecorItems = new List<HomeDepotShopDecorItemData>(decorItems.Values),
					CleaningToolItems = new List<HomeDepotShopCleaningToolItemData>(cleaningToolItems.Values),
					PaletteItems = new List<HomeDepotShopPaintingPaletteItemData>(paletteItems.Values),
					PcAppItems = new List<HomeDepotShopPcAppItemData>(pcAppItems.Values)
				};
			}
			catch (Exception innerException)
			{
				Debug.LogException(new CaptureProgressException(base.gameObject, innerException));
				return null;
			}
		}
	}
}
