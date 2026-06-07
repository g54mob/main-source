using DV.CabControls;
using UnityEngine;

namespace DV.InventorySystem
{
	public class InventoryDV : Inventory
	{
		public override bool IsVREnabled()
		{
			return VRManager.IsVREnabled();
		}

		protected override Transform GetPlayerTransform()
		{
			return PlayerManager.PlayerTransform;
		}

		protected override bool IsEssential(GameObject item)
		{
			ItemBase component = item.GetComponent<ItemBase>();
			if ((bool)component)
			{
				return component.IsEssential();
			}
			return false;
		}

		protected override bool IsGrabbed(GameObject item)
		{
			ItemBase component = item.GetComponent<ItemBase>();
			if ((bool)component)
			{
				return component.IsGrabbed();
			}
			return false;
		}

		protected override bool IsPlaceableInBelt(GameObject item)
		{
			ItemBase component = item.GetComponent<ItemBase>();
			if ((bool)component)
			{
				return component.IsBeltSnappable;
			}
			return false;
		}

		protected override void ForceEndInteraction(GameObject item)
		{
			item.GetComponent<ItemBase>().ForceEndInteraction();
		}

		protected override void AssignInventoryLayer(GameObject item)
		{
			SetLayer("Inventory", item);
		}

		protected override void AssignWorldItemLayer(GameObject item)
		{
			SetLayer("World_Item", item);
		}

		protected override bool IsValidItem(GameObject item)
		{
			if (item != null)
			{
				return item.GetComponent<ItemBase>() != null;
			}
			return false;
		}

		protected override bool IsTwoHanded(GameObject item)
		{
			ItemBase component = item.GetComponent<ItemBase>();
			if ((bool)component)
			{
				return component.IsTwoHanded;
			}
			return false;
		}

		private void SetLayer(string layerName, GameObject item)
		{
			int layerToInteractionColliders = LayerMask.NameToLayer(layerName);
			item.GetComponent<ItemBase>().SetLayerToInteractionColliders(layerToInteractionColliders);
		}
	}
}
