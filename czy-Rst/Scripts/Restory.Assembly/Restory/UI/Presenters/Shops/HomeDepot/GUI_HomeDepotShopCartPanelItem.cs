using Restory.Data.Localization;
using Restory.Data.Shops.HomeDepot;
using Restory.ObjectPools;
using UnityEngine;
using Zenject;

namespace Restory.UI.Presenters.Shops.HomeDepot
{
	public abstract class GUI_HomeDepotShopCartPanelItem : MonoBehaviour, ICleanableComponent
	{
		private HomeDepotShopItemData shopItemData;

		protected LocalizationSystem localizationSystem;

		public HomeDepotShopItemData ShopItemData => shopItemData;

		[Inject]
		private void Construct(LocalizationSystem localizationSystem)
		{
			this.localizationSystem = localizationSystem;
		}

		public void Init(HomeDepotShopItemData shopItem)
		{
			shopItemData = shopItem;
			SetUpView(shopItem);
			Subscribe();
		}

		protected abstract void SetUpView(HomeDepotShopItemData shopItem);

		private void OnDisable()
		{
			Unsubscribe();
		}

		public void Clean()
		{
			Unsubscribe();
		}

		protected virtual void Subscribe()
		{
		}

		protected virtual void Unsubscribe()
		{
		}
	}
}
