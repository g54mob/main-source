using DV.CabControls;
using DV.InventorySystem;
using UnityEngine;

namespace DV.Items
{
	public class ItemAudioSpatialBlendController : MonoBehaviour
	{
		public GameObject itemRoot;

		public AudioSource[] sources;

		private ItemBase item;

		private bool isVR;

		private bool isInventory;

		private bool isHand;

		private void Start()
		{
			isVR = VRManager.IsVREnabled();
			if (itemRoot == null)
			{
				Debug.LogError("ItemAudioSpatialBlendController requires a valid itemRoot GameObject reference. Destroying self.", base.gameObject);
				Object.Destroy(this);
				return;
			}
			item = itemRoot.GetComponentInParent<ItemBase>();
			if (item == null)
			{
				Debug.LogError("ItemAudioSpatialBlendController requires a valid item ItemBase reference. Destroying self.", base.gameObject);
				Object.Destroy(this);
				return;
			}
			item.ItemInventoryStateChanged += OnItemInventoryStateChanged;
			item.ItemInContainerStateChanged += OnItemInContainerStateChanged;
			if (item.InContainer != null)
			{
				item.InContainer.ItemContainerNestedInChanged += OnContainerNestedInChanged;
				item.InContainer.ItemBase.ItemInventoryStateChanged += OnContainerInventoryStateChanged;
				ItemContainer itemContainer = item.InContainer.NestedIn.lastNest as ItemContainer;
				if (itemContainer != null)
				{
					itemContainer.ItemBase.ItemInventoryStateChanged += OnContainerInventoryStateChanged;
				}
			}
			isInventory = item.IsInInventory(includeInStashedContainer: true);
			isHand = !isInventory && item.IsGrabbedOrInGrabbedContainer();
			Set3DValue();
		}

		private void OnItemInContainerStateChanged(ItemBase _, AItemContainer newContainer, AItemContainer oldContainer, bool added)
		{
			if (oldContainer != null)
			{
				oldContainer.ItemContainerNestedInChanged -= OnContainerNestedInChanged;
				ItemContainer itemContainer = oldContainer.NestedIn.lastNest as ItemContainer;
				if (itemContainer != null)
				{
					itemContainer.ItemBase.ItemInventoryStateChanged -= OnContainerInventoryStateChanged;
				}
			}
			ItemContainer itemContainer2 = oldContainer as ItemContainer;
			if (itemContainer2 != null)
			{
				itemContainer2.ItemBase.ItemInventoryStateChanged -= OnContainerInventoryStateChanged;
			}
			if (newContainer != null)
			{
				newContainer.ItemContainerNestedInChanged += OnContainerNestedInChanged;
				ItemContainer itemContainer3 = newContainer.NestedIn.lastNest as ItemContainer;
				if (itemContainer3 != null)
				{
					itemContainer3.ItemBase.ItemInventoryStateChanged += OnContainerInventoryStateChanged;
				}
			}
			ItemContainer itemContainer4 = newContainer as ItemContainer;
			if (itemContainer4 != null)
			{
				itemContainer4.ItemBase.ItemInventoryStateChanged += OnContainerInventoryStateChanged;
			}
			isInventory = item.IsInInventory(includeInStashedContainer: true);
			isHand = !isInventory && item.IsGrabbedOrInGrabbedContainer();
			Set3DValue();
		}

		private void OnDestroy()
		{
			if (UnloadWatcher.isUnloading || item == null)
			{
				return;
			}
			item.ItemInventoryStateChanged -= OnItemInventoryStateChanged;
			item.ItemInContainerStateChanged -= OnItemInContainerStateChanged;
			ItemContainer inContainer = item.InContainer;
			if (inContainer != null)
			{
				inContainer.ItemContainerNestedInChanged -= OnContainerNestedInChanged;
				inContainer.ItemBase.ItemInventoryStateChanged -= OnContainerInventoryStateChanged;
				ItemContainer itemContainer = inContainer.NestedIn.lastNest as ItemContainer;
				if (itemContainer != null)
				{
					itemContainer.ItemBase.ItemInventoryStateChanged -= OnContainerInventoryStateChanged;
				}
			}
		}

		private void OnContainerInventoryStateChanged(ItemBase itemBase, InventoryActionType actionType, InventoryItemState itemState)
		{
			isInventory = itemState.IsInInventory() || itemBase.IsInInventory(includeInStashedContainer: true);
			isHand = !isInventory && actionType.HasIntFlag(InventoryActionType.Equip);
			Set3DValue();
		}

		private void OnContainerNestedInChanged(AItemContainer container, (AItemContainer __, AItemContainer lastNest) oldNestedIn)
		{
			if (oldNestedIn.lastNest != null)
			{
				ItemContainer itemContainer = oldNestedIn.lastNest as ItemContainer;
				if (itemContainer != null)
				{
					itemContainer.ItemBase.ItemInventoryStateChanged -= OnContainerInventoryStateChanged;
				}
			}
			ItemContainer itemContainer2 = container.NestedIn.lastNest as ItemContainer;
			if (itemContainer2 != null)
			{
				itemContainer2.ItemBase.ItemInventoryStateChanged += OnContainerInventoryStateChanged;
			}
			isInventory = item.IsInInventory(includeInStashedContainer: true);
			isHand = !isInventory && item.IsGrabbedOrInGrabbedContainer();
			Set3DValue();
		}

		private void Set3DValue()
		{
			int num = ((!isInventory && (isVR || !isHand)) ? 1 : 0);
			AudioSource[] array = sources;
			for (int i = 0; i < array.Length; i++)
			{
				array[i].spatialBlend = num;
			}
		}

		private void OnItemInventoryStateChanged(ItemBase _, InventoryActionType actionType, InventoryItemState itemState)
		{
			isInventory = itemState.IsInInventory() || item.IsInInventory(includeInStashedContainer: true);
			isHand = !isInventory && item.IsGrabbedOrInGrabbedContainer();
			Set3DValue();
		}
	}
}
