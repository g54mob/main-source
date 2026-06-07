using DV.CabControls;
using DV.InventorySystem;
using DV.Utils;
using UnityEngine;

namespace DV.Items
{
	public class ItemPositionHandler : MonoBehaviour
	{
		private ItemBase itemBase;

		private Transform positionTransform;

		private const InventoryActionType VALID_INVENTORY_ACTIONS = InventoryActionType.Add | InventoryActionType.Drop | InventoryActionType.Purge | InventoryActionType.Equip | InventoryActionType.Unequip;

		public Vector3 ItemPosition => positionTransform.position;

		public bool Initialized { get; private set; }

		public void Initialize(GameObject item)
		{
			ItemBase item2 = ((item != null) ? item.GetComponent<ItemBase>() : null);
			Initialize(item2);
		}

		public void Initialize(ItemBase item)
		{
			if (Initialized)
			{
				Debug.LogError("ItemPositionHandler is already initialized.", this);
				return;
			}
			if (item == null)
			{
				Debug.LogError("ItemPositionHandler requires a valid item ItemBase reference. Initialization failed.", base.gameObject);
				return;
			}
			itemBase = item;
			SetPositionTransform(SingletonBehaviour<Inventory>.Instance != null && SingletonBehaviour<Inventory>.Instance.Contains(itemBase.gameObject, includeDropped: false));
			SetupListeners(on: true);
			Initialized = true;
		}

		private void OnDestroy()
		{
			SetupListeners(on: false);
			Initialized = false;
		}

		private void SetupListeners(bool on)
		{
			if (itemBase != null)
			{
				itemBase.AboutToBeDestroyed -= OnItemAboutToBeDestroyed;
				itemBase.ItemInContainerStateChanged -= OnItemInContainerStateChanged;
				ItemContainer inContainer = itemBase.InContainer;
				if (inContainer != null)
				{
					inContainer.ItemContainerNestedInChanged -= OnItemContainerNestedInChanged;
					inContainer.ItemBase.ItemInventoryStateChanged -= OnItemInContainerInventoryStateChanged;
					ItemContainer itemContainer = inContainer.NestedIn.lastNest as ItemContainer;
					if (itemContainer != null)
					{
						itemContainer.ItemBase.ItemInventoryStateChanged -= OnItemInContainerInventoryStateChanged;
					}
				}
			}
			bool flag = SingletonBehaviour<Inventory>.Instance != null;
			if (flag)
			{
				SingletonBehaviour<Inventory>.Instance.InventoryStatusChanged -= OnInventoryStatusChanged;
			}
			PlayerManager.CameraChanged -= OnCameraChanged;
			if (!on)
			{
				return;
			}
			if (itemBase != null)
			{
				itemBase.AboutToBeDestroyed += OnItemAboutToBeDestroyed;
				itemBase.ItemInContainerStateChanged += OnItemInContainerStateChanged;
				ItemContainer inContainer2 = itemBase.InContainer;
				if (inContainer2 != null)
				{
					inContainer2.ItemContainerNestedInChanged += OnItemContainerNestedInChanged;
					inContainer2.ItemBase.ItemInventoryStateChanged += OnItemInContainerInventoryStateChanged;
					ItemContainer itemContainer2 = inContainer2.NestedIn.lastNest as ItemContainer;
					if (itemContainer2 != null)
					{
						itemContainer2.ItemBase.ItemInventoryStateChanged += OnItemInContainerInventoryStateChanged;
					}
				}
			}
			if (flag)
			{
				SingletonBehaviour<Inventory>.Instance.InventoryStatusChanged += OnInventoryStatusChanged;
				PlayerManager.CameraChanged += OnCameraChanged;
			}
		}

		private void OnItemInContainerStateChanged(ItemBase _, AItemContainer newContainer, AItemContainer oldContainer, bool added)
		{
			if (oldContainer != null)
			{
				oldContainer.ItemContainerNestedInChanged -= OnItemContainerNestedInChanged;
				ItemContainer itemContainer = oldContainer as ItemContainer;
				if (itemContainer != null)
				{
					itemContainer.ItemBase.ItemInventoryStateChanged -= OnItemInContainerInventoryStateChanged;
				}
			}
			if (newContainer != null)
			{
				newContainer.ItemContainerNestedInChanged += OnItemContainerNestedInChanged;
				ItemContainer itemContainer2 = newContainer as ItemContainer;
				if (itemContainer2 != null)
				{
					itemContainer2.ItemBase.ItemInventoryStateChanged += OnItemInContainerInventoryStateChanged;
				}
			}
			SetPositionTransform(itemBase.IsInInventory(includeInStashedContainer: true));
		}

		private void OnItemInContainerInventoryStateChanged(ItemBase item, InventoryActionType actiontype, InventoryItemState itemstate)
		{
			bool flag = item.IsInInventory(includeInStashedContainer: true);
			SetPositionTransform(flag);
		}

		private void OnItemContainerNestedInChanged(AItemContainer container, (AItemContainer firstNest, AItemContainer lastNest) oldNestedIn)
		{
			if (oldNestedIn.lastNest != null)
			{
				ItemContainer itemContainer = oldNestedIn.lastNest as ItemContainer;
				if (itemContainer != null)
				{
					itemContainer.ItemBase.ItemInventoryStateChanged -= OnItemInContainerInventoryStateChanged;
				}
			}
			ItemContainer itemContainer2 = container.NestedIn.lastNest as ItemContainer;
			if (itemContainer2 != null)
			{
				itemContainer2.ItemBase.ItemInventoryStateChanged += OnItemInContainerInventoryStateChanged;
			}
			SetPositionTransform(itemBase.IsInInventory(includeInStashedContainer: true));
		}

		private void OnCameraChanged()
		{
			bool flag = SingletonBehaviour<Inventory>.Instance != null && SingletonBehaviour<Inventory>.Instance.Contains(itemBase.gameObject, includeDropped: false);
			SetPositionTransform(flag);
		}

		private void OnInventoryStatusChanged(InventorySlotState originState, InventoryActionType originActionType, InventorySlotState _, InventoryActionType __)
		{
			if (originActionType.HasAnyIntFlag(InventoryActionType.Add | InventoryActionType.Drop | InventoryActionType.Purge | InventoryActionType.Equip | InventoryActionType.Unequip) && !(originState.item != itemBase.gameObject))
			{
				bool flag = originState.itemState.IsInInventory();
				SetPositionTransform(flag);
			}
		}

		private void SetPositionTransform(bool stashed)
		{
			if (stashed)
			{
				Camera activeCamera = PlayerManager.ActiveCamera;
				if (activeCamera != null)
				{
					positionTransform = activeCamera.transform;
					return;
				}
			}
			positionTransform = ((itemBase.InContainer == null) ? itemBase.transform : itemBase.InContainer.transform);
		}

		private void OnItemAboutToBeDestroyed(ItemBase _)
		{
			Initialized = false;
		}
	}
}
