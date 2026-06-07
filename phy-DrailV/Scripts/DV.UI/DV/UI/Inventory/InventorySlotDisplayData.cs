using DV.Common;
using DV.InventorySystem;

namespace DV.UI.Inventory
{
	public class InventorySlotDisplayData
	{
		public bool IsLockable { get; set; }

		public bool IsLocked { get; set; }

		public bool ItemGetterAllowed { get; set; }

		public bool IsItemGetter { get; set; }

		public bool ContainerAccessAllowed { get; set; }

		public bool IsBelt { get; set; }

		public bool BeltAllowed { get; set; }

		public bool BeltVisible { get; set; }

		public bool IsGhost { get; set; }

		public IInventoryItemSpec Spec { get; set; }

		public AItemContainer ItemContainer { get; set; }

		public bool IsHandData { get; set; }

		public bool IsContainerData { get; set; }

		public InventorySlotDisplayData(IInventoryItemSpec spec, bool itemGetterAllowed, bool isBelt, bool beltAllowed, bool beltVisible, bool isLockable, bool isLocked, bool isGhost, bool containerAccessAllowed, bool isHandData, bool isContainerData)
		{
			Spec = spec;
			ItemGetterAllowed = itemGetterAllowed;
			IsContainerData = isContainerData;
			if (spec != null)
			{
				ItemContainer = ((spec.GetGameObject() != null) ? spec.GetGameObject().GetComponent<AItemContainer>() : null);
				IsLockable = isLockable;
				IsLocked = isLockable && isLocked;
				IsItemGetter = spec.IsEssential;
				ContainerAccessAllowed = containerAccessAllowed;
				IsGhost = isGhost;
				IsBelt = isBelt;
				BeltAllowed = beltAllowed;
				BeltVisible = beltVisible;
				IsHandData = isHandData;
			}
		}

		public InventorySlotDisplayData(IInventoryItemSpec spec, bool isLockable, bool itemGetterAllowed, bool isBelt, bool beltAllowed, bool beltVisible, bool containerAccessAllowed, bool isHandData, bool isContainerData)
			: this(spec, itemGetterAllowed, isBelt, beltAllowed, beltVisible, isLockable, isLocked: false, isGhost: false, containerAccessAllowed, isHandData, isContainerData)
		{
		}

		public InventorySlotDisplayData(bool itemGetterAllowed, bool isBelt, bool beltAllowed, bool beltVisible, bool containerAccessAllowed, bool isHandData, bool isContainerData)
			: this(null, itemGetterAllowed, isBelt, beltAllowed, beltVisible, isLockable: false, isLocked: false, isGhost: false, containerAccessAllowed, isHandData, isContainerData)
		{
		}

		public InventorySlotDisplayData(IInventoryItemSpec spec, bool containerAccessAllowed, bool isHandData, bool isContainerData)
			: this(spec, itemGetterAllowed: false, isBelt: false, beltAllowed: false, beltVisible: false, isLockable: false, isLocked: false, isGhost: false, containerAccessAllowed, isHandData, isContainerData)
		{
		}
	}
}
