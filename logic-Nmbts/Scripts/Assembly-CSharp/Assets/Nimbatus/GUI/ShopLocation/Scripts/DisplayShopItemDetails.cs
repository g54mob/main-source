using System.Globalization;
using Assets.Nimbatus.GUI.Common.Scripts;
using Assets.Nimbatus.Scripts.GalaxyMap.Shops;
using Assets.Nimbatus.Scripts.Persistence;
using Assets.Nimbatus.Scripts.Receivables;
using Assets.Nimbatus.Scripts.World.Terrain.TerrainResources;
using Assets.Nimbatus.Scripts.WorldObjects.Items;
using Assets.Nimbatus.Scripts.WorldObjects.Items.DroneParts.Weapons;
using I2.Loc;
using UnityEngine;

namespace Assets.Nimbatus.GUI.ShopLocation.Scripts
{
	public class DisplayShopItemDetails : MonoBehaviour
	{
		public UILabel NameLabel;

		public UILabel DetailLabel;

		public UILabel StatusLabel;

		public WeaponDetails WeaponDetails;

		public UITexture ResourceIcon;

		public UILabel ResourceLabel;

		public BuyShopItemButton BuyButton;

		public ShowWeaponPreview WeaponPreview;

		private ShopItem _shopItem;

		private NimbatusItem _item;

		public void Init(ShopUiManager manager, ShopItem shopItem)
		{
			if (shopItem == null)
			{
				return;
			}
			_shopItem = shopItem;
			_item = null;
			ShopInventoryItem shopInventoryItem;
			_item = (((shopInventoryItem = _shopItem as ShopInventoryItem) != null) ? shopInventoryItem.Item.GetReward<NimbatusItem>() : ((ScrapyardItem)_shopItem).Item);
			if (_item != null)
			{
				NameLabel.text = LabelHelper.Blue + _item.Name;
				string text = "";
				if (!string.IsNullOrEmpty(_item.CustomToolTip.GetTranslation()))
				{
					text = string.Concat(text, LabelHelper.LightGrey, _item.CustomToolTip, LabelHelper.NewLine);
				}
				DetailLabel.text = text + _item.GetDetailedTooltip();
				Weapon weapon;
				if ((object)(weapon = _item as Weapon) != null)
				{
					WeaponDetails.gameObject.SetActive(true);
					WeaponDetails.ShowWeapon(weapon);
					WeaponPreview.gameObject.SetActive(true);
					WeaponPreview.ShowWeapon(weapon);
				}
				else
				{
					WeaponDetails.gameObject.SetActive(false);
					WeaponPreview.gameObject.SetActive(false);
				}
			}
			else
			{
				ShopInventoryItem shopInventoryItem2;
				if ((shopInventoryItem2 = _shopItem as ShopInventoryItem) != null)
				{
					NameLabel.text = LabelHelper.Blue + shopInventoryItem2.Item.GetTitle();
					DetailLabel.text = shopInventoryItem2.Item.GetAmount();
					UpgradeReceivable upgradeReceivable;
					if ((upgradeReceivable = shopInventoryItem2.Item as UpgradeReceivable) != null)
					{
						UILabel detailLabel = DetailLabel;
						detailLabel.text = detailLabel.text + LabelHelper.NewLine + upgradeReceivable.GetDescription();
						UILabel detailLabel2 = DetailLabel;
						detailLabel2.text = detailLabel2.text + LabelHelper.NewLine + upgradeReceivable.GetValue();
					}
				}
				WeaponDetails.gameObject.SetActive(false);
			}
			ResourceSetting resourceSetting = SerializableMonobehaviour<NimbatusTerrainResourceManager, ResourceManagerData>.Instance.ResourceSettings[_shopItem.Price.Resource];
			ResourceIcon.mainTexture = resourceSetting.Icon;
			ResourceLabel.text = _shopItem.Price.Amount.ToString("###0", CultureInfo.InvariantCulture);
			BuyButton.Init(_shopItem);
			StatusLabel.text = "";
		}

		public void Update()
		{
			if (!(_item == null))
			{
				if (_item is Weapon)
				{
					StatusLabel.text = "";
				}
				else if (_item.IsStackable)
				{
					string translation = LocalizationManager.GetTermTranslation("GalaxyMap/YouOwnXItems");
					LocalizationManager.ApplyLocalizationParams(ref translation, "Amount", _item.CurrentStackSize.ToString());
					StatusLabel.text = translation;
				}
			}
		}
	}
}
