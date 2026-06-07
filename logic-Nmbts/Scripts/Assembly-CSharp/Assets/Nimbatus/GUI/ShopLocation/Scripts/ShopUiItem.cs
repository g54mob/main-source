using Assets.Nimbatus.GUI.Common.Scripts;
using Assets.Nimbatus.Scripts.GalaxyMap.Shops;
using Assets.Nimbatus.Scripts.WorldObjects.Items;
using Assets.Nimbatus.Scripts.WorldObjects.Items.DroneParts.Weapons;
using Assets.Nimbatus.Scripts.WorldObjects.Items.DroneParts.Weapons.Emitters;
using UnityEngine;

namespace Assets.Nimbatus.GUI.ShopLocation.Scripts
{
	public class ShopUiItem : MonoBehaviour
	{
		public UITexture Icon;

		public UITexture ColoredIcon;

		public UILabel StackSizeLabel;

		public UITexture Background;

		public Color NormalColor;

		public Color SelectedColor;

		public Color HoverColor;

		private ShopUiManager _manager;

		private ShopItem _shopItem;

		private NimbatusItem _item;

		private bool _hover;

		public void Init(ShopUiManager manager, ShopItem shopItem)
		{
			_manager = manager;
			_shopItem = shopItem;
			_item = null;
			ShopInventoryItem shopInventoryItem;
			_item = (((shopInventoryItem = _shopItem as ShopInventoryItem) != null) ? shopInventoryItem.Item.GetReward<NimbatusItem>() : ((ScrapyardItem)_shopItem).Item);
			if (Icon != null)
			{
				Texture2D mainTexture = null;
				ShopInventoryItem shopInventoryItem2;
				if (_item != null)
				{
					mainTexture = _item.GetIcon();
				}
				else if ((shopInventoryItem2 = _shopItem as ShopInventoryItem) != null)
				{
					mainTexture = shopInventoryItem2.Item.GetIcon();
				}
				Icon.mainTexture = mainTexture;
				Icon.enabled = true;
			}
			Weapon weapon;
			Emitter emitter;
			if (_item != null && (object)(weapon = _item as Weapon) != null)
			{
				if (ColoredIcon != null)
				{
					ColoredIcon.mainTexture = weapon.Emitter.AmmunitionTexture;
					ColoredIcon.color = weapon.Ammunition.IconColorModifier;
					ColoredIcon.enabled = true;
				}
			}
			else if (_item != null && (object)(emitter = _item as Emitter) != null)
			{
				if (ColoredIcon != null)
				{
					ColoredIcon.mainTexture = emitter.AmmunitionTexture;
					ColoredIcon.color = emitter.Ammunition.IconColorModifier;
					ColoredIcon.enabled = true;
				}
			}
			else if (ColoredIcon != null)
			{
				ColoredIcon.enabled = false;
			}
			UpdateStackSizeLabel();
		}

		public void Update()
		{
			if (_manager != null && _manager.SelectedItem == _shopItem)
			{
				Background.color = SelectedColor;
			}
			else
			{
				Background.color = (_hover ? HoverColor : NormalColor);
			}
			UpdateStackSizeLabel();
		}

		private void UpdateStackSizeLabel()
		{
			ShopInventoryItem shopInventoryItem;
			int num = (((shopInventoryItem = _shopItem as ShopInventoryItem) != null) ? shopInventoryItem.StackSize : ((ScrapyardItem)_shopItem).Item.CurrentStackSize);
			StackSizeLabel.text = ((num > 0) ? LabelHelper.White : LabelHelper.DarkOrange) + num;
		}

		public void OnClick()
		{
			_manager.SelectItem(_shopItem);
		}

		public void OnHover(bool isOver)
		{
			_hover = isOver;
		}
	}
}
