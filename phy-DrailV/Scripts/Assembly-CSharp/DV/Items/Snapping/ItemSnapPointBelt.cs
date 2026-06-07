using DV.CabControls;
using DV.VRTK_Extensions;
using UnityEngine;

namespace DV.Items.Snapping
{
	public class ItemSnapPointBelt : ItemSnapPointBase
	{
		public delegate void ReservedChangedDelegate(ItemSnapPointBelt snapPointBelt, ItemBase wasReservedFor, ItemBase reservedFor);

		protected override bool DisallowInteractionOnSnap { get; } = true;

		public ItemBase ReservedItem { get; private set; }

		public event ReservedChangedDelegate ReservedChanged;

		protected override bool ShouldKeepUpright(ItemBase item)
		{
			if (base.ShouldKeepUpright(item))
			{
				return item.IsUprightInBelt;
			}
			return false;
		}

		public void ToggleReserved(ItemBase itemToReserveFor)
		{
			if (!(itemToReserveFor == ReservedItem))
			{
				ItemBase reservedItem = ReservedItem;
				ReservedItem = itemToReserveFor;
				this.ReservedChanged?.Invoke(this, reservedItem, itemToReserveFor);
			}
		}

		public override void ToggleSnapPoint(bool shouldEnable)
		{
			base.transform.parent.gameObject.SetActive(shouldEnable);
		}

		protected override void HandleDisabledState()
		{
			if (!base.gameObject.activeInHierarchy)
			{
				VRTK_InteractableObject_DV component = base.SnappedItem.GetComponent<VRTK_InteractableObject_DV>();
				if (component == null)
				{
					Debug.LogError("Missing VRTK_InteractableObject_DV on snapped object. This should not happen.", this);
				}
				else
				{
					component.SaveCurrentState();
				}
			}
		}
	}
}
