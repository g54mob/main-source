using UnityEngine;
using UnityEngine.UI;
using VampireSurvivors.Data;
using VampireSurvivors.Data.Items;
using VampireSurvivors.Data.Weapons;

namespace VampireSurvivors.UI
{
	public class CollectionItemUI : SelectableUI
	{
		public enum CollectionTypes
		{
			WEAPON = 0,
			ITEM = 1,
			ARCANA = 2
		}

		[SerializeField]
		private Image LockedIcon;

		[SerializeField]
		private Image UnlockedIcon;

		[SerializeField]
		private Image Frame;

		[SerializeField]
		private Image _SealIcon;

		private WeaponData _weaponData;

		private WeaponType _weaponType;

		private CollectionsPage _page;

		private ItemData _itemData;

		private ItemType _itemType;

		private ArcanaData _arcanaData;

		private ArcanaType _arcanaType;

		private Button _button;

		private bool _seen;

		public CollectionTypes CollectionType;

		public void SetData(WeaponData w, CollectionsPage page, WeaponType _wType, bool isSealed)
		{
		}

		public ItemData GetItemData()
		{
			return null;
		}

		private void SetIconSizes()
		{
		}

		public void SetItem(ItemData w, CollectionsPage page, ItemType _item, bool isSealed)
		{
		}

		public void SetArcana(ArcanaData w, CollectionsPage page, ArcanaType type)
		{
		}

		public void Seal()
		{
		}

		public void UnSeal()
		{
		}

		public bool IsWeapon()
		{
			return false;
		}

		public bool IsPassive()
		{
			return false;
		}

		public bool IsItem()
		{
			return false;
		}

		public bool IsRelic()
		{
			return false;
		}

		public bool IsArcana()
		{
			return false;
		}

		public bool IsDefaultContent()
		{
			return false;
		}

		public bool IsExtra()
		{
			return false;
		}

		private void SetLocked(bool isUnlocked)
		{
		}

		protected override void OnSelected()
		{
		}

		private void SetupClickRegister()
		{
		}

		private void RegisterClick()
		{
		}

		public WeaponType GetWeaponType()
		{
			return default(WeaponType);
		}

		public WeaponData GetWeaponData()
		{
			return null;
		}

		public ItemType GetItemType()
		{
			return default(ItemType);
		}

		public ContentGroupType GetContentGroup()
		{
			return default(ContentGroupType);
		}

		public ArcanaType GetArcanaType()
		{
			return default(ArcanaType);
		}
	}
}
