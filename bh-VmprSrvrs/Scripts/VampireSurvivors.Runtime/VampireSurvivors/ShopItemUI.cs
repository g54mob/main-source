using System;
using System.Runtime.CompilerServices;
using I2.Loc;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using VampireSurvivors.Data;
using VampireSurvivors.Data.Items;
using VampireSurvivors.Data.Weapons;
using VampireSurvivors.Objects;
using VampireSurvivors.Objects.Characters;
using VampireSurvivors.Objects.Items;
using VampireSurvivors.UI;

namespace VampireSurvivors
{
	public class ShopItemUI : SelectableUI
	{
		[SerializeField]
		private Image _Icon;

		[SerializeField]
		private Localize _Name;

		[SerializeField]
		private Localize _Description;

		[SerializeField]
		private TextMeshProUGUI _Price;

		[SerializeField]
		private Image _Fader;

		[SerializeField]
		private UISpriteAnimation _SheenAnimation;

		[SerializeField]
		private Image _LockIcon;

		[SerializeField]
		private Image[] _OnlineSuggestionsIcons;

		private WeaponData _weaponData;

		private WeaponType _weaponType;

		private ItemData _itemData;

		private ItemType _itemType;

		private GameWindowedUIPage _page;

		private PlayerOptions _playerOptions;

		private float _price;

		private bool _isSoldOut;

		private int _quantity;

		private int _index;

		public WeaponType WeaponType => default(WeaponType);

		public ItemType ItemType => default(ItemType);

		public bool IsSoldOut => false;

		public bool IsCustomActionItem { get; private set; }

		public event Action OnPurchased
		{
			[CompilerGenerated]
			add
			{
			}
			[CompilerGenerated]
			remove
			{
			}
		}

		public bool CanBuy()
		{
			return false;
		}

		public void InvokeCustomPurchaseAction()
		{
		}

		public void Buy()
		{
		}

		public void SetWeaponData(WeaponData d, WeaponType t, GameWindowedUIPage page, PlayerOptions po, float price, int index, int quantity = 1, float priceMarkupMultiplier = 1f, bool useWeaponDataPrice = false)
		{
		}

		private void SetLockState()
		{
		}

		public void SetItemData(ItemData d, ItemType t, GameWindowedUIPage page, float price, int index, int quantity = 1, float priceMarkupMultiplier = 1f)
		{
		}

		private void HookOnlineCallback()
		{
		}

		private void OnBuySuggestedCallback(int newSuggestion, int seatNumber, VampireSurvivors.Objects.Characters.CharacterController character)
		{
		}

		public void SetCustomAction(CustomActionInventoryItem inventoryItem, GameWindowedUIPage page, float priceMarkupMultiplier = 1f)
		{
		}

		private void SetIconSize()
		{
		}

		protected override void OnSelected()
		{
		}

		public void ShuffleText()
		{
		}

		public void SetPrice(float i)
		{
		}

		public float GetPrice()
		{
			return 0f;
		}

		public void SoldOut()
		{
		}

		public ItemData GetItemData()
		{
			return null;
		}

		public WeaponData GetWeaponData()
		{
			return null;
		}

		protected override void OnDestroy()
		{
		}

		private void AnimateBuy()
		{
		}
	}
}
