using DV.CabControls;
using DV.Interaction;
using DV.InventorySystem;
using DV.Items;
using DV.Utils;

namespace DV.Customization.Gadgets
{
	public class GadgetSolderingResource : MagazineAmmo, IItemUse
	{
		public override ItemBase Item { get; protected set; }

		public override ItemUseTarget AmmoUseTarget { get; protected set; }

		private void Start()
		{
			AmmoUseTarget = GetComponent<ItemUseTarget>();
			Item = GetComponent<ItemBase>();
			if (!VRManager.IsVREnabled())
			{
				base.enabled = false;
				return;
			}
			Item.Grabbed += delegate
			{
				base.enabled = true;
			};
			Item.Ungrabbed += delegate
			{
				base.enabled = false;
			};
			base.enabled = Item.IsGrabbed();
		}

		public bool HandleHover(ItemUseTarget target)
		{
			if (!target.TryGetComponent<GadgetSolderingTool>(out var component))
			{
				return false;
			}
			return component.HandleHover(AmmoUseTarget);
		}

		public bool HandleUse(ItemUseTarget target)
		{
			if (!target.TryGetComponent<GadgetSolderingTool>(out var component))
			{
				return false;
			}
			SingletonBehaviour<Inventory>.Instance.DropItemFromHandsOrInventory(base.gameObject);
			return component.HandleUse(AmmoUseTarget);
		}

		public bool IsHoverCompatible(ItemUseTarget target)
		{
			return IsUseCompatible(target);
		}

		public bool IsUseCompatible(ItemUseTarget target)
		{
			if (!target.TryGetComponent<GadgetSolderingTool>(out var component))
			{
				return false;
			}
			return component.IsUseCompatible(AmmoUseTarget);
		}
	}
}
