using DV.CabControls;
using UnityEngine;

namespace DV.Items
{
	public class ItemMagazine : ItemContainer
	{
		[SerializeField]
		private MagazineAmmoType ammoType;

		public Transform forceDropAnchor;

		public override bool DirectInteractionAllowed => false;

		protected override bool AddSoundAllowed => false;

		protected override void Awake()
		{
			base.Awake();
			QuickDropAllowed = true;
		}

		public override bool ValidItem(GameObject item)
		{
			MagazineAmmo ammo = ((item != null) ? item.GetComponent<MagazineAmmo>() : null);
			return ValidItem(ammo, allowSpent: true);
		}

		public bool ValidItem(MagazineAmmo ammo, bool allowSpent)
		{
			if (ammo != null && (allowSpent || !ammo.isSpent))
			{
				return ammo.AmmoType == ammoType;
			}
			return false;
		}

		public void SetQuickDropAllowed(bool allowed)
		{
			QuickDropAllowed = allowed;
		}

		public override bool AddItem(GameObject item, int index)
		{
			if (!base.AddItem(item, index))
			{
				return false;
			}
			ItemBase component = item.GetComponent<ItemBase>();
			if (component != null)
			{
				component.AssignForceDropAnchor(forceDropAnchor);
			}
			return true;
		}

		public override bool RemoveItem(int index, bool activateItem, bool dropItem)
		{
			GameObject gameObject = (index.IsInRange(0, base.Capacity) ? items[index] : null);
			if (!base.RemoveItem(index, activateItem, dropItem))
			{
				return false;
			}
			ItemBase itemBase = ((gameObject != null) ? gameObject.GetComponent<ItemBase>() : null);
			if (itemBase != null)
			{
				itemBase.AssignForceDropAnchor(null);
			}
			return true;
		}
	}
}
