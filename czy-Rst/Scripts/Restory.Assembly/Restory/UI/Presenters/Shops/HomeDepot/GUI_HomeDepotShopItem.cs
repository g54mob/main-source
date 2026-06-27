using System;
using Restory.Data.GameConfigs;
using Restory.Data.Localization;
using Restory.Data.Restrictions;
using Restory.Data.Shops.HomeDepot;
using Restory.ObjectPools;
using UnityEngine;
using Zenject;

namespace Restory.UI.Presenters.Shops.HomeDepot
{
	public abstract class GUI_HomeDepotShopItem : MonoBehaviour, ICleanableComponent
	{
		private HomeDepotShopItemData shopItemData;

		private GameConfig gameConfig;

		protected LocalizationSystem localizationSystem;

		public HomeDepotShopItemData ShopItemData => shopItemData;

		public ContentRestrictionBase ContentRestriction => shopItemData.ContentRestriction;

		[Inject]
		private void Construct(GameConfig gameConfig, LocalizationSystem localizationSystem)
		{
			this.gameConfig = gameConfig;
			this.localizationSystem = localizationSystem;
		}

		private void OnDisable()
		{
			Unsubscribe();
			CleanUpOnDisable();
		}

		public void Init(HomeDepotShopItemData shopItemData, int countInCart, bool insufficientFunds)
		{
			this.shopItemData = shopItemData;
			this.shopItemData.ContentRestriction = GetItemRestriction(shopItemData);
			SetUpView(shopItemData, countInCart, insufficientFunds);
			Subscribe();
		}

		public void Clean()
		{
			Unsubscribe();
			CleanUpOnClean();
		}

		protected abstract void SetUpView(HomeDepotShopItemData shopItemData, int countInCart, bool insufficientFunds);

		protected virtual void Subscribe()
		{
		}

		protected virtual void Unsubscribe()
		{
		}

		protected virtual void CleanUpOnClean()
		{
		}

		protected virtual void CleanUpOnDisable()
		{
		}

		private ContentRestrictionBase GetItemRestriction(HomeDepotShopItemData shopItemData)
		{
			if (gameConfig.VersionType == VersionType.Release)
			{
				return null;
			}
			if (!(shopItemData is HomeDepotShopDecorItemData homeDepotShopDecorItemData))
			{
				if (!(shopItemData is HomeDepotShopCleaningToolItemData homeDepotShopCleaningToolItemData))
				{
					if (!(shopItemData is HomeDepotShopPaintingPaletteItemData homeDepotShopPaintingPaletteItemData))
					{
						if (shopItemData is HomeDepotShopPcAppItemData homeDepotShopPcAppItemData)
						{
							return homeDepotShopPcAppItemData.Info.ContentRestriction;
						}
						throw new ArgumentOutOfRangeException();
					}
					return homeDepotShopPaintingPaletteItemData.Palette.ContentRestriction;
				}
				return homeDepotShopCleaningToolItemData.ToolInfo.ContentRestriction;
			}
			return homeDepotShopDecorItemData.DecorInfo.ContentRestriction;
		}
	}
}
