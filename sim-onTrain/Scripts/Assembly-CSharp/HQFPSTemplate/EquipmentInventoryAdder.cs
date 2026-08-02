using HQFPSTemplate.Equipment;
using HQFPSTemplate.Items;
using UnityEngine;

namespace HQFPSTemplate
{
	public class EquipmentInventoryAdder : MonoBehaviour
	{
		[HideInInspector]
		public ItemInfo currentItem;

		[HideInInspector]
		public ItemInfo unArmedItem;

		private string itemDatabaseName;

		public string itemUnarmedDatabaseName;

		public PlayerEquipmentController playerEquipmentController;

		public Player player;

		public ItemDatabase itemDatabase;

		public EquipmentHandler equipmentHandler;

		private Item m_ItemInstance;

		private Item m_UnarmedInstance;

		[SerializeField]
		[Tooltip("In what container of the Player will the picked up item go")]
		protected ItemContainerFlags m_TargetContainers = ItemContainerFlags.Storage;

		private void Start()
		{
			if (!string.IsNullOrEmpty(itemUnarmedDatabaseName))
			{
				unArmedItem = itemDatabase.GetItemWithName(itemUnarmedDatabaseName);
			}
			if (unArmedItem != null)
			{
				m_UnarmedInstance = new Item(unArmedItem);
			}
			else
			{
				Debug.LogWarning("[EIA] itemUnarmedDatabaseName='" + itemUnarmedDatabaseName + "' not found in Item Database. m_UnarmedInstance left null.");
			}
			TryUnequipItem();
		}

		public void TryEquipItem(CollectableItemData data)
		{
			Debug.Log("[EIA-DBG] TryEquipItem ENTER | data=" + ((data != null) ? data.itemName : "null") + " key='" + ((data != null) ? data.itemFPSTemplateKey : "NULL") + "'");
			if (string.IsNullOrEmpty(data.itemFPSTemplateKey))
			{
				Debug.Log("[EIA-DBG] key empty -> TryUnequipItem path");
				TryUnequipItem();
				return;
			}
			itemDatabaseName = data.itemFPSTemplateKey;
			currentItem = itemDatabase.GetItemWithName(itemDatabaseName);
			Debug.Log("[EIA-DBG] DB lookup '" + itemDatabaseName + "' -> " + ((currentItem != null) ? ("FOUND id=" + currentItem.Id) : "NOT FOUND"));
			if (currentItem == null)
			{
				Debug.LogWarning("Item '" + itemDatabaseName + "' not found in item database! Check itemFPSTemplateKey on CollectableItemData.");
				TryUnequipItem();
				return;
			}
			m_ItemInstance = new Item(currentItem);
			TryPickUp(player, 1f);
			Debug.Log($"[EIA-DBG] About to Equip | id={m_ItemInstance.Id}");
			playerEquipmentController.Equip(m_ItemInstance);
		}

		public void TryUnequipItem()
		{
			Debug.Log("[EIA-DBG] TryUnequipItem | m_ItemInstance=" + ((m_ItemInstance != null) ? m_ItemInstance.Name : "null") + " unarmedInstance=" + ((m_UnarmedInstance != null) ? m_UnarmedInstance.Name : "null"));
			equipmentHandler.UnequipItem();
			player.Inventory.RemoveItem(m_ItemInstance);
			playerEquipmentController.Equip(m_UnarmedInstance);
		}

		protected void TryPickUp(Humanoid humanoid, float interactProgress)
		{
			if (m_ItemInstance != null)
			{
				if (humanoid.EquippedItem.Get() == null)
				{
					ItemContainer containerWithFlags = humanoid.Inventory.GetContainerWithFlags(m_TargetContainers);
					ItemSlot itemSlot = containerWithFlags.Slots[containerWithFlags.SelectedSlot.Get()];
					if (itemSlot.Item == null)
					{
						itemSlot.SetItem(m_ItemInstance);
					}
					bool flag = true;
				}
				else
				{
					bool flag = humanoid.Inventory.AddItem(m_ItemInstance, m_TargetContainers);
				}
			}
			else
			{
				Debug.LogError("Item Instance is null, can't pick up anything.");
			}
		}
	}
}
