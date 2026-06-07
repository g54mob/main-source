using Assets.Nimbatus.GUI.Common.Scripts;
using Assets.Nimbatus.Scripts.GalaxyMap.Shops;
using I2.Loc;

namespace Assets.Nimbatus.GUI.ShopLocation.Scripts
{
	public class BuyShopItemButton : BuyItemButton
	{
		public UILabel Label;

		private ShopItem _item;

		private bool _isInStock;

		private bool _hasResources;

		private bool _hasCapacity;

		public void Init(ShopItem item)
		{
			if (item != null)
			{
				_item = item;
				_isInStock = _item.IsInStock();
				_hasResources = _item.HasResourcesToBuy();
				_hasCapacity = _item.HasCapacityToBuy();
				Label.text = ((_item is ScrapyardItem) ? LocalizationManager.GetTermTranslation("GalaxyMap/SellFor") : LocalizationManager.GetTermTranslation("GalaxyMap/BuyFor"));
				Init();
			}
		}

		protected override bool CanBeBought()
		{
			if (_item == null)
			{
				return false;
			}
			_isInStock = _item.IsInStock();
			_hasResources = _item.HasResourcesToBuy();
			_hasCapacity = _item.HasCapacityToBuy();
			if (_isInStock && _hasResources)
			{
				return _hasCapacity;
			}
			return false;
		}

		protected override void Buy()
		{
			if (_item != null)
			{
				_item.Buy();
			}
		}

		public override void OnTooltip(bool show)
		{
			if (_item != null && show)
			{
				if (!_isInStock)
				{
					NimbatusToolTip.Show(LocalizationManager.GetTermTranslation("GalaxyMap/OutOfStock"));
				}
				if (!_hasResources)
				{
					NimbatusToolTip.Show(LocalizationManager.GetTermTranslation("GalaxyMap/NotEnoughResources"));
				}
				if (!_hasCapacity)
				{
					NimbatusToolTip.Show(LocalizationManager.GetTermTranslation("GalaxyMap/MaximumAmount"));
				}
			}
			else
			{
				NimbatusToolTip.Show(null);
			}
		}
	}
}
