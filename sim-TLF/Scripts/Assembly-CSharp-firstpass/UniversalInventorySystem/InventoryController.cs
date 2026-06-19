using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Zenject;

namespace UniversalInventorySystem
{
	[Serializable]
	public static class InventoryController
	{
		[Serializable]
		protected enum MethodType
		{
			Add = 0,
			Remove = 1,
			Use = 2,
			Swap = 3,
			LocalSwap = 4,
			Initialize = 5,
			Craft = 6,
			Utility = 7,
			Drop = 8
		}

		private static InventoryHandler inventoryHandlerTemp;

		public static List<InventoryUI> inventoriesUI = new List<InventoryUI>();

		public static List<Inventory> inventories = new List<Inventory>();

		public static readonly Slot nullSlot = new Slot(null, 0, _hasItem: false, 0);

		public const InventoryProtection AllInventoryFlags = InventoryProtection.InventoryToInventory | InventoryProtection.SlotToSlot | InventoryProtection.Add | InventoryProtection.Remove | InventoryProtection.Use | InventoryProtection.Drop;

		public const InventoryProtection AddInvFlags = InventoryProtection.Add;

		public const InventoryProtection RemoveInvFlags = InventoryProtection.Remove;

		public const InventoryProtection UseInvFlags = InventoryProtection.Use;

		public const InventoryProtection LocalSwapInvFlags = InventoryProtection.SlotToSlot;

		public const InventoryProtection SwapInvFlags = InventoryProtection.InventoryToInventory;

		public const InventoryProtection DropInvFlags = InventoryProtection.Remove | InventoryProtection.Drop;

		public const SlotProtection AllSlotFlags = SlotProtection.Add | SlotProtection.Remove | SlotProtection.Swap | SlotProtection.Use;

		public const SlotProtection AddFlags = SlotProtection.Add;

		public const SlotProtection RemoveFlags = SlotProtection.Remove;

		public const SlotProtection SwapFlags = SlotProtection.Swap;

		public const SlotProtection UseFlags = SlotProtection.Use;

		public static InventoryData inventoryData = default(InventoryData);

		public static InventoryHandler inventoryHandler
		{
			get
			{
				if (inventoryHandlerTemp == null)
				{
					inventoryHandlerTemp = ProjectContext.Instance.Container.Resolve<InventoryHandler>();
				}
				return inventoryHandlerTemp;
			}
		}

		public static List<Inventory> GetInventories()
		{
			return inventories;
		}

		public static Inventory GetInventoryById(int id)
		{
			foreach (Inventory inventory in inventories)
			{
				if (inventory.id == id)
				{
					return inventory;
				}
			}
			return null;
		}

		public static Inventory GetInventory(int index)
		{
			return inventories[index];
		}

		public static Slot GetSlotInInventory(int invIndex, int slotIndex)
		{
			return inventories[invIndex][slotIndex];
		}

		public static InventoryData SaveInventoryData()
		{
			inventoryData.inventories = inventories.ToArray();
			return inventoryData;
		}

		public static InventoryData LoadInventoryData(InventoryData loadData)
		{
			inventories = loadData.inventories.ToList();
			return SaveInventoryData();
		}

		public static int AddItemToNewSlot(this Inventory inv, Item item, int amount, BroadcastEventType e = BroadcastEventType.AddItem, bool overrideSlotProtection = false, int? durability = null, Action callback = null)
		{
			if (inv == null)
			{
				Debug.LogError("Null inventory provided for AddItemToNewSlot");
				throw new ArgumentNullException("inv", "Null inventory provided");
			}
			if (item == null)
			{
				Debug.LogError("Null item provided for AddItemToNewSlot");
				throw new ArgumentNullException("inv", "Null item provided");
			}
			if (!AcceptsInventoryProtection(inv, MethodType.Add))
			{
				return amount;
			}
			if (!durability.HasValue)
			{
				durability = item.maxDurability;
			}
			if (!item.stackable)
			{
				for (int i = 0; i < inv.slots.Count; i++)
				{
					if (!AcceptsSlotProtection(inv.slots[i], MethodType.Add) && !overrideSlotProtection)
					{
						continue;
					}
					ItemGroup whitelist = inv.slots[i].whitelist;
					if (((object)whitelist != null && !whitelist.itemsList.Contains(item)) || (inv.slots[i].hasItem && i < inv.slots.Count - 1))
					{
						continue;
					}
					if (i < inv.slots.Count - 1)
					{
						inv.slots[i] = Slot.SetItemProperties(inv.slots[i], item, 1, _hasItem: true, durability.GetValueOrDefault());
						amount--;
						if (amount <= 0)
						{
							break;
						}
						continue;
					}
					if (!inv.slots[i].hasItem)
					{
						inv.slots[i] = Slot.SetItemProperties(inv.slots[i], item, 1, _hasItem: true, durability.GetValueOrDefault());
						if (amount <= 0)
						{
							break;
						}
						if (amount > 0)
						{
							Debug.Log($"Not enougth room for {amount} items");
							InventoryHandler.AddItemEventArgs aea = new InventoryHandler.AddItemEventArgs(inv, _addedToNewSlot: true, _addedToSlot: false, item, amount, null);
							inventoryHandler.Broadcast(e, aea);
							return amount;
						}
						continue;
					}
					Debug.Log("Not Enought Room");
					return amount;
				}
				callback?.Invoke();
				InventoryHandler.AddItemEventArgs aea2 = new InventoryHandler.AddItemEventArgs(inv, _addedToNewSlot: true, _addedToSlot: false, item, amount, null);
				inventoryHandler.Broadcast(e, aea2);
				return 0;
			}
			for (int j = 0; j < inv.slots.Count; j++)
			{
				if (inv.slots[j].hasItem || (!AcceptsSlotProtection(inv.slots[j], MethodType.Add) && !overrideSlotProtection))
				{
					continue;
				}
				ItemGroup whitelist2 = inv.slots[j].whitelist;
				if ((object)whitelist2 != null && !whitelist2.itemsList.Contains(item))
				{
					continue;
				}
				if (j < inv.slots.Count - 1)
				{
					int maxAmount = item.maxAmount;
					if (amount <= maxAmount)
					{
						inv.slots[j] = Slot.SetItemProperties(inv.slots[j], item, amount, _hasItem: true, durability.GetValueOrDefault());
						break;
					}
					inv.slots[j] = Slot.SetItemProperties(inv.slots[j], item, maxAmount, _hasItem: true, durability.GetValueOrDefault());
					amount -= maxAmount;
					if (amount <= 0)
					{
						break;
					}
					continue;
				}
				if (!inv.slots[j].hasItem)
				{
					InventoryHandler.AddItemEventArgs aea3 = new InventoryHandler.AddItemEventArgs(inv, _addedToNewSlot: true, _addedToSlot: false, item, amount, null);
					int amount2 = inv.slots[j].amount;
					amount -= item.maxAmount - amount2;
					amount2 = item.maxAmount;
					inv.slots[j] = Slot.SetItemProperties(inv.slots[j], item, amount2, _hasItem: true, durability.GetValueOrDefault());
					if (amount > 0)
					{
						inventoryHandler.Broadcast(e, aea3);
						Debug.Log("Not Enought Room");
						return amount;
					}
					continue;
				}
				Debug.Log("Not Enought Room");
				return amount;
			}
			callback?.Invoke();
			InventoryHandler.AddItemEventArgs aea4 = new InventoryHandler.AddItemEventArgs(inv, _addedToNewSlot: true, _addedToSlot: false, item, amount, null);
			inventoryHandler.Broadcast(e, aea4);
			return 0;
		}

		public static int AddItem(this Inventory inv, Item item, int amount, BroadcastEventType e = BroadcastEventType.AddItem, bool overrideSlotProtection = false, int? durability = null, Action callback = null)
		{
			if (!AcceptsInventoryProtection(inv, MethodType.Add))
			{
				return amount;
			}
			if (inv == null)
			{
				Debug.LogError("Null inventory provided for AddItem");
				throw new ArgumentNullException("inv", "Null Inventory was provided");
			}
			if (item == null)
			{
				Debug.LogError("Null item provided for AddItem");
				throw new ArgumentNullException("item", "Null Item was provided");
			}
			if (!durability.HasValue)
			{
				durability = item.maxDurability;
			}
			if (!item.stackable)
			{
				return inv.AddItemToNewSlot(item, amount, e);
			}
			for (int i = 0; i < inv.slots.Count; i++)
			{
				if (inv.slots[i].item != item || inv.slots[i].amount == inv.slots[i].item.maxAmount || (!AcceptsSlotProtection(inv.slots[i], MethodType.Add) && !overrideSlotProtection))
				{
					continue;
				}
				ItemGroup whitelist = inv.slots[i].whitelist;
				if ((object)whitelist == null || whitelist.itemsList.Contains(item))
				{
					Slot value = inv.slots[i];
					if (value.amount + amount <= item.maxAmount)
					{
						value.amount += amount;
						amount = 0;
						inv.slots[i] = value;
						break;
					}
					if (value.amount + amount > item.maxAmount)
					{
						amount -= item.maxAmount - value.amount;
						value.amount = item.maxAmount;
						inv.slots[i] = value;
						_ = 0;
					}
				}
			}
			if (amount > 0)
			{
				return inv.AddItemToNewSlot(item, amount, e);
			}
			callback?.Invoke();
			InventoryHandler.AddItemEventArgs aea = new InventoryHandler.AddItemEventArgs(inv, _addedToNewSlot: false, _addedToSlot: false, item, amount, null);
			inventoryHandler.Broadcast(e, aea);
			return 0;
		}

		public static int AddItemToSlot(this Inventory inv, Item item, int amount, int slotNumber, BroadcastEventType e = BroadcastEventType.AddItem, bool overrideSlotProtection = false, int? durability = null, Action callback = null)
		{
			if (inv == null)
			{
				Debug.LogError("Null inventory provided for AddItemToSlot");
				throw new ArgumentNullException("inv", "Null inventory provided");
			}
			if (item == null)
			{
				Debug.LogError("Null item provided for AddItemToSlot");
				throw new ArgumentNullException("item", "Null item provided");
			}
			if (!AcceptsInventoryProtection(inv, MethodType.Add))
			{
				return amount;
			}
			if (!AcceptsSlotProtection(inv.slots[slotNumber], MethodType.Add) && !overrideSlotProtection)
			{
				return amount;
			}
			ItemGroup whitelist = inv.slots[slotNumber].whitelist;
			if ((object)whitelist != null && !whitelist.itemsList.Contains(item))
			{
				return amount;
			}
			if (!durability.HasValue)
			{
				durability = item.maxDurability;
			}
			if (!item.stackable)
			{
				if (inv.slots[slotNumber].hasItem)
				{
					return amount;
				}
				inv.slots[slotNumber] = Slot.SetItemProperties(inv.slots[slotNumber], item, 1, _hasItem: true, durability.GetValueOrDefault() / amount);
				callback?.Invoke();
				InventoryHandler.AddItemEventArgs aea = new InventoryHandler.AddItemEventArgs(inv, _addedToNewSlot: false, _addedToSlot: true, item, amount, slotNumber);
				inventoryHandler.Broadcast(e, aea);
				if (amount - 1 <= 0)
				{
					return 0;
				}
				return amount - 1;
			}
			if (!inv.slots[slotNumber].hasItem)
			{
				if (amount < item.maxAmount)
				{
					inv.slots[slotNumber] = Slot.SetItemProperties(inv.slots[slotNumber], item, amount, _hasItem: true, durability.GetValueOrDefault());
					callback?.Invoke();
					InventoryHandler.AddItemEventArgs aea2 = new InventoryHandler.AddItemEventArgs(inv, _addedToNewSlot: false, _addedToSlot: true, item, amount, slotNumber);
					inventoryHandler.Broadcast(e, aea2);
					return 0;
				}
				inv.slots[slotNumber] = Slot.SetItemProperties(inv.slots[slotNumber], item, item.maxAmount, _hasItem: true, durability.GetValueOrDefault());
				return amount - item.maxAmount;
			}
			if (inv.slots[slotNumber].item == item)
			{
				if (inv.slots[slotNumber].amount + amount < item.maxAmount)
				{
					inv.slots[slotNumber] = Slot.SetItemProperties(inv.slots[slotNumber], item, amount + inv.slots[slotNumber].amount, _hasItem: true, inv.slots[slotNumber].durability);
					callback?.Invoke();
					InventoryHandler.AddItemEventArgs aea3 = new InventoryHandler.AddItemEventArgs(inv, _addedToNewSlot: false, _addedToSlot: true, item, amount, slotNumber);
					inventoryHandler.Broadcast(e, aea3);
					return 0;
				}
				int result = amount + inv.slots[slotNumber].amount - item.maxAmount;
				inv.slots[slotNumber] = Slot.SetItemProperties(inv.slots[slotNumber], item, item.maxAmount, _hasItem: true, inv.slots[slotNumber].durability);
				return result;
			}
			Debug.Log($"Slot {slotNumber} is already occupied with a different item");
			InventoryHandler.AddItemEventArgs aea4 = new InventoryHandler.AddItemEventArgs(inv, _addedToNewSlot: false, _addedToSlot: false, null, 0, slotNumber);
			inventoryHandler.Broadcast(e, aea4);
			return -1;
		}

		public static bool DropItem(this Inventory inv, int amount, Vector3 dropPosition, Item item, BroadcastEventType e = BroadcastEventType.DropItem, bool overrideSlotProtecion = true)
		{
			if (inv == null)
			{
				Debug.LogError("Null inventory provided for DropItem");
				throw new ArgumentNullException("inv", "Null inventory provided");
			}
			if (!AcceptsInventoryProtection(inv, MethodType.Drop))
			{
				return false;
			}
			if (item != null)
			{
				return inv.RemoveItem(item, amount, e, dropPosition, overrideSlotProtecion);
			}
			Debug.LogError("Null item provided for DropItem");
			return false;
		}

		public static bool DropItem(this Inventory inv, int amount, Vector3 dropPosition, int slot, BroadcastEventType e = BroadcastEventType.DropItem, bool overrideSlotProtecion = true)
		{
			if (inv == null)
			{
				Debug.LogError("Null inventory provided for DropItem");
				throw new ArgumentNullException("inv", "Null inventory provided");
			}
			if (!AcceptsInventoryProtection(inv, MethodType.Drop))
			{
				return false;
			}
			if (slot >= 0 && slot < inv.slots.Count)
			{
				return inv.RemoveItemInSlot(slot, amount, e, dropPosition, overrideSlotProtecion);
			}
			Debug.LogError($"Invalid slot number provided for DropItem; slot number: {slot}");
			throw new ArgumentOutOfRangeException("slot", "The slot number provided was out of the inventory slots bounds");
		}

		public static bool RemoveItem(this Inventory inv, Item item, int amount, BroadcastEventType e = BroadcastEventType.RemoveItem, Vector3? dropPosition = null, bool overrideSlotProtection = false)
		{
			if (inv == null)
			{
				Debug.LogError("Null inventory provided for RemoveItem");
				throw new ArgumentNullException("inv", "Null inventory provided");
			}
			if (item == null)
			{
				Debug.LogError("Null item provided for RemoveItem");
				throw new ArgumentNullException("item", "Null item provided");
			}
			if (!AcceptsInventoryProtection(inv, MethodType.Remove))
			{
				return false;
			}
			int num = 0;
			for (int i = 0; i < inv.slots.Count; i++)
			{
				if (inv.slots[i].item == item && (AcceptsSlotProtection(inv.slots[i], MethodType.Remove) || overrideSlotProtection))
				{
					num += inv.slots[i].amount;
				}
			}
			int slot = 0;
			if (num >= amount)
			{
				for (int j = 0; j < inv.slots.Count; j++)
				{
					if (inv.slots[j].item == item && (AcceptsSlotProtection(inv.slots[j], MethodType.Remove) || overrideSlotProtection))
					{
						int amount2 = inv.slots[j].amount;
						Slot value = inv.slots[j];
						value.amount -= amount;
						inv.slots[j] = value;
						if (value.amount > 0)
						{
							break;
						}
						inv.slots[j] = Slot.SetItemProperties(inv.slots[j], nullSlot);
						amount -= amount2;
						slot = j;
					}
				}
				dropPosition = dropPosition ?? new Vector3(0f, 0f, 0f);
				InventoryHandler.RemoveItemEventArgs rea = new InventoryHandler.RemoveItemEventArgs(inv, _removedByUI: false, amount, item, null);
				if (e == BroadcastEventType.DropItem)
				{
					item.OnDrop(inv, tss: false, slot, amount, dbui: false, dropPosition);
				}
				else
				{
					inventoryHandler.Broadcast(e, null, rea);
				}
				return true;
			}
			Debug.Log("There arent enought items to take out!");
			return false;
		}

		public static bool RemoveItemInSlot(this Inventory inv, int slot, int amount, BroadcastEventType e = BroadcastEventType.RemoveItem, Vector3? dropPosition = null, bool overrideSlotProtecion = false)
		{
			if (inv == null)
			{
				Debug.LogError("Null inventory provided for RemoveItemInSlot");
				throw new ArgumentNullException("inv", "Null inventory provided");
			}
			if (!AcceptsInventoryProtection(inv, MethodType.Remove))
			{
				return false;
			}
			if (!AcceptsSlotProtection(inv.slots[slot], MethodType.Remove) && !overrideSlotProtecion)
			{
				return false;
			}
			dropPosition = dropPosition ?? new Vector3(0f, 0f, 0f);
			InventoryHandler.RemoveItemEventArgs rea = new InventoryHandler.RemoveItemEventArgs(inv, _removedByUI: false, amount, inv.slots[slot].item, slot);
			if (inv.slots[slot].amount == amount)
			{
				Item item = inv.slots[slot].item;
				inv.slots[slot] = Slot.SetItemProperties(inv.slots[slot], nullSlot);
				if (e == BroadcastEventType.DropItem)
				{
					item?.OnDrop(inv, tss: true, slot, amount, dbui: false, dropPosition);
				}
				else
				{
					inventoryHandler.Broadcast(e, null, rea);
				}
				return true;
			}
			if (inv.slots[slot].amount > amount)
			{
				Item item2 = inv.slots[slot].item;
				inv.slots[slot] = Slot.SetItemProperties(inv.slots[slot], inv.slots[slot].item, inv.slots[slot].amount - amount, _hasItem: true, 0);
				if (e == BroadcastEventType.DropItem)
				{
					item2?.OnDrop(inv, tss: true, slot, amount, dbui: false, dropPosition);
				}
				else
				{
					inventoryHandler.Broadcast(e, null, rea);
				}
				return true;
			}
			Debug.Log("There arent enought items to take out!");
			return false;
		}

		public static void UseItemInSlot(this Inventory inv, int slot, BroadcastEventType e = BroadcastEventType.UseItem, bool overrideSlotProtection = false)
		{
			if (inv == null)
			{
				Debug.LogError("Null inventory provided for UseItemInSlot");
				throw new ArgumentNullException("inv", "Null inventory provided");
			}
			if (!AcceptsInventoryProtection(inv, MethodType.Use) || (!AcceptsSlotProtection(inv.slots[slot], MethodType.Use) && !overrideSlotProtection) || !inv.slots[slot].hasItem || !inv.areItemsUsable)
			{
				return;
			}
			if (inv.slots[slot].item.destroyOnUse)
			{
				Item item = inv.slots[slot].item;
				if (item.hasDurability)
				{
					if (inv.slots[slot].durability <= 0)
					{
						return;
					}
					Slot slot2 = inv.slots[slot];
					Slot.SetDurability(ref slot2, inv.slots[slot].durability - 1);
					inv.slots[slot] = slot2;
					InventoryHandler.UseItemEventArgs uea = new InventoryHandler.UseItemEventArgs(inv, item, slot);
					if (inv.slots[slot].durability == 0)
					{
						if (inv.RemoveItemInSlot(slot, inv.slots[slot].item.useHowManyWhenUsed))
						{
							item.OnUse(inv, slot);
							inventoryHandler.Broadcast(e, null, null, null, null, uea);
						}
					}
					else
					{
						item.OnUse(inv, slot);
						inventoryHandler.Broadcast(e, null, null, null, null, uea);
					}
				}
				else if (inv.RemoveItemInSlot(slot, inv.slots[slot].item.useHowManyWhenUsed))
				{
					item.OnUse(inv, slot);
					InventoryHandler.UseItemEventArgs uea2 = new InventoryHandler.UseItemEventArgs(inv, item, slot);
					inventoryHandler.Broadcast(e, null, null, null, null, uea2);
				}
			}
			else
			{
				if (inv.slots[slot].item.destroyOnUse)
				{
					return;
				}
				if (inv.slots[slot].item.hasDurability)
				{
					if (inv.slots[slot].durability > 0)
					{
						Slot slot3 = inv.slots[slot];
						Slot.SetDurability(ref slot3, inv.slots[slot].durability - 1);
						inv.slots[slot] = slot3;
						InventoryHandler.UseItemEventArgs uea3 = new InventoryHandler.UseItemEventArgs(inv, inv.slots[slot].item, slot);
						inv.slots[slot].item.OnUse(inv, slot);
						inventoryHandler.Broadcast(e, null, null, null, null, uea3);
					}
				}
				else
				{
					inv.slots[slot].item.OnUse(inv, slot);
					InventoryHandler.UseItemEventArgs uea4 = new InventoryHandler.UseItemEventArgs(inv, inv.slots[slot].item, slot);
					inventoryHandler.Broadcast(e, null, null, null, null, uea4);
				}
			}
		}

		public static void UseItem(this Inventory inv, Item item, BroadcastEventType e = BroadcastEventType.UseItem, bool overrideSlotProtection = false)
		{
			if (inv == null)
			{
				Debug.LogError("Null inventory provided for UseItemInSlot");
				throw new ArgumentNullException("inv", "Null inventory provided");
			}
			if (!AcceptsInventoryProtection(inv, MethodType.Use) || !inv.areItemsUsable)
			{
				return;
			}
			for (int i = 0; i < inv.slots.Count; i++)
			{
				if (!inv.slots[i].hasItem || inv.slots[i].item != item || (!AcceptsSlotProtection(inv.slots[i], MethodType.Use) && !overrideSlotProtection))
				{
					continue;
				}
				if (inv.slots[i].item.destroyOnUse)
				{
					Item item2 = inv.slots[i].item;
					if (item2.hasDurability)
					{
						if (inv.slots[i].durability <= 0)
						{
							break;
						}
						Slot slot = inv.slots[i];
						Slot.SetDurability(ref slot, inv.slots[i].durability - 1);
						inv.slots[i] = slot;
						InventoryHandler.UseItemEventArgs uea = new InventoryHandler.UseItemEventArgs(inv, item2, i);
						if (inv.slots[i].durability == 0)
						{
							if (inv.RemoveItemInSlot(i, inv.slots[i].item.useHowManyWhenUsed))
							{
								item2.OnUse(inv, i);
								inventoryHandler.Broadcast(e, null, null, null, null, uea);
							}
						}
						else
						{
							item2.OnUse(inv, i);
							inventoryHandler.Broadcast(e, null, null, null, null, uea);
						}
					}
					else if (inv.RemoveItemInSlot(i, inv.slots[i].item.useHowManyWhenUsed))
					{
						item2.OnUse(inv, i);
						InventoryHandler.UseItemEventArgs uea2 = new InventoryHandler.UseItemEventArgs(inv, item2, i);
						inventoryHandler.Broadcast(e, null, null, null, null, uea2);
					}
					break;
				}
				if (inv.slots[i].item.destroyOnUse)
				{
					continue;
				}
				if (inv.slots[i].item.hasDurability)
				{
					if (inv.slots[i].durability > 0)
					{
						Slot slot2 = inv.slots[i];
						Slot.SetDurability(ref slot2, inv.slots[i].durability - 1);
						inv.slots[i] = slot2;
						InventoryHandler.UseItemEventArgs uea3 = new InventoryHandler.UseItemEventArgs(inv, inv.slots[i].item, i);
						inv.slots[i].item.OnUse(inv, i);
						inventoryHandler.Broadcast(e, null, null, null, null, uea3);
					}
				}
				else
				{
					inv.slots[i].item.OnUse(inv, i);
					InventoryHandler.UseItemEventArgs uea4 = new InventoryHandler.UseItemEventArgs(inv, inv.slots[i].item, i);
					inventoryHandler.Broadcast(e, null, null, null, null, uea4);
				}
			}
		}

		public static void SwapItemsInSlots(this Inventory inv, int nativeSlot, int targetSlot, BroadcastEventType e = BroadcastEventType.SwapItem, bool overrideSlotProtection = false)
		{
			if (inv == null)
			{
				Debug.LogError("Null inventory provided for SwapItemsInSlots");
				throw new ArgumentNullException("inv", "Null inventory provided");
			}
			if (inv[nativeSlot].item == null)
			{
				Debug.LogError("Null item provided for SwapItemsInCertainAmountInSlots");
				return;
			}
			if (!AcceptsInventoryProtection(inv, MethodType.LocalSwap) || inv.slots[targetSlot].isProductSlot || (!AcceptsSlotProtection(inv.slots[targetSlot], MethodType.Swap) && !overrideSlotProtection) || (!AcceptsSlotProtection(inv.slots[nativeSlot], MethodType.Swap) && !overrideSlotProtection))
			{
				return;
			}
			ItemGroup whitelist = inv.slots[nativeSlot].whitelist;
			bool num;
			if ((object)whitelist == null)
			{
				if (inv.slots[targetSlot].whitelist == null)
				{
					goto IL_0108;
				}
				num = inv.slots[targetSlot].whitelist.itemsList.ContainsWNull(inv.slots[nativeSlot].item);
			}
			else
			{
				num = whitelist.itemsList.ContainsWNull(inv.slots[targetSlot].item);
			}
			if (!num)
			{
				return;
			}
			goto IL_0108;
			IL_0108:
			ItemGroup whitelist2 = inv.slots[targetSlot].whitelist;
			bool num2;
			if ((object)whitelist2 == null)
			{
				if (inv.slots[nativeSlot].whitelist == null)
				{
					goto IL_0188;
				}
				num2 = inv.slots[nativeSlot].whitelist.itemsList.ContainsWNull(inv.slots[targetSlot].item);
			}
			else
			{
				num2 = whitelist2.itemsList.ContainsWNull(inv.slots[nativeSlot].item);
			}
			if (!num2)
			{
				return;
			}
			goto IL_0188;
			IL_0188:
			Slot slot = inv.slots[targetSlot];
			if (inv.slots[nativeSlot].isProductSlot || inv.slots[targetSlot].isProductSlot)
			{
				if (slot.item == null)
				{
					inv.slots[targetSlot] = Slot.SetItemProperties(inv.slots[targetSlot], inv.slots[nativeSlot]);
					inv.slots[nativeSlot] = Slot.SetItemProperties(inv.slots[nativeSlot], slot);
					InventoryHandler.SwapItemsEventArgs sea = new InventoryHandler.SwapItemsEventArgs(inv, nativeSlot, targetSlot, inv.slots[targetSlot].item, slot.item, null);
					inventoryHandler.Broadcast(e, null, null, sea);
				}
			}
			else
			{
				inv.slots[targetSlot] = Slot.SetItemProperties(inv.slots[targetSlot], inv.slots[nativeSlot]);
				inv.slots[nativeSlot] = Slot.SetItemProperties(inv.slots[nativeSlot], slot);
				InventoryHandler.SwapItemsEventArgs sea2 = new InventoryHandler.SwapItemsEventArgs(inv, nativeSlot, targetSlot, inv.slots[targetSlot].item, slot.item, null);
				inventoryHandler.Broadcast(e, null, null, sea2);
			}
		}

		public static int SwapItemsInCertainAmountInSlots(this Inventory inv, int nativeSlot, int targetSlot, int? _amount, BroadcastEventType e = BroadcastEventType.SwapItem, bool overrideSlotProtection = false)
		{
			if (inv == null)
			{
				Debug.LogError("Null inventory provided for SwapItemsInCertainAmountInSlots");
				throw new ArgumentNullException("inv", "Null inventory provided");
			}
			if (inv[nativeSlot].item == null)
			{
				Debug.LogWarning("Null item provided for SwapItemsInCertainAmountInSlots");
			}
			Item item = inv[nativeSlot].item;
			if ((object)item != null && !item.stackable)
			{
				inv.SwapItemsInSlots(nativeSlot, targetSlot);
				return 0;
			}
			if (!AcceptsInventoryProtection(inv, MethodType.LocalSwap))
			{
				return _amount ?? inv.slots[nativeSlot].amount;
			}
			if (inv.slots[targetSlot].isProductSlot)
			{
				return _amount ?? inv.slots[nativeSlot].amount;
			}
			if (!AcceptsSlotProtection(inv.slots[targetSlot], MethodType.Swap) && !overrideSlotProtection)
			{
				return _amount ?? inv.slots[nativeSlot].amount;
			}
			if (!AcceptsSlotProtection(inv.slots[nativeSlot], MethodType.Swap) && !overrideSlotProtection)
			{
				return _amount ?? inv.slots[nativeSlot].amount;
			}
			ItemGroup whitelist = inv.slots[nativeSlot].whitelist;
			bool num;
			if ((object)whitelist == null)
			{
				if (inv.slots[targetSlot].whitelist == null)
				{
					goto IL_01c0;
				}
				num = inv.slots[targetSlot].whitelist.itemsList.ContainsWNull(inv.slots[nativeSlot].item);
			}
			else
			{
				num = whitelist.itemsList.ContainsWNull(inv.slots[targetSlot].item);
			}
			if (num)
			{
				goto IL_01c0;
			}
			goto IL_023f;
			IL_0264:
			int num2 = _amount ?? inv.slots[nativeSlot].amount;
			if (num2 <= 0)
			{
				return num2;
			}
			if (num2 > inv.slots[nativeSlot].amount)
			{
				return num2;
			}
			InventoryHandler.SwapItemsEventArgs sea;
			if (inv.slots[targetSlot].item == null)
			{
				inv.slots[targetSlot] = Slot.SetItemProperties(inv.slots[targetSlot], inv.slots[nativeSlot].item, num2, _hasItem: true, inv.slots[nativeSlot].durability);
				inv.slots[nativeSlot] = Slot.SetItemProperties(inv.slots[nativeSlot], inv.slots[nativeSlot].item, inv.slots[nativeSlot].amount - num2, _hasItem: true, inv.slots[nativeSlot].durability);
				if (inv.slots[nativeSlot].amount <= 0)
				{
					inv.slots[nativeSlot] = Slot.SetItemProperties(inv.slots[nativeSlot], nullSlot);
				}
			}
			else
			{
				if (inv.slots[nativeSlot].item == inv.slots[targetSlot].item)
				{
					int num3 = inv.AddItemToSlot(inv.slots[nativeSlot].item, num2, targetSlot);
					inv.slots[nativeSlot] = Slot.SetItemProperties(inv.slots[nativeSlot], inv.slots[nativeSlot].item, inv.slots[nativeSlot].amount - num2 + num3, _hasItem: true, inv.slots[nativeSlot].durability);
					if (inv.slots[nativeSlot].amount <= 0)
					{
						inv.slots[nativeSlot] = Slot.SetItemProperties(inv.slots[nativeSlot], nullSlot);
					}
					sea = new InventoryHandler.SwapItemsEventArgs(inv, nativeSlot, targetSlot, inv.slots[targetSlot].item, inv.slots[nativeSlot].item, num2 - num3);
					inventoryHandler.Broadcast(e, null, null, sea);
					return num3;
				}
				inv.SwapItemsInSlots(nativeSlot, targetSlot);
			}
			sea = new InventoryHandler.SwapItemsEventArgs(inv, nativeSlot, targetSlot, inv.slots[targetSlot].item, inv.slots[nativeSlot].item, num2);
			inventoryHandler.Broadcast(e, null, null, sea);
			return 0;
			IL_023f:
			return _amount ?? inv.slots[nativeSlot].amount;
			IL_01c0:
			ItemGroup whitelist2 = inv.slots[targetSlot].whitelist;
			bool num4;
			if ((object)whitelist2 == null)
			{
				if (inv.slots[nativeSlot].whitelist == null)
				{
					goto IL_0264;
				}
				num4 = inv.slots[nativeSlot].whitelist.itemsList.ContainsWNull(inv.slots[targetSlot].item);
			}
			else
			{
				num4 = whitelist2.itemsList.ContainsWNull(inv.slots[nativeSlot].item);
			}
			if (!num4)
			{
				goto IL_023f;
			}
			goto IL_0264;
		}

		public static int SwapItemThruInventoriesSlotToSlot(this Inventory nativeInv, Inventory targetInv, int nativeSlotNumber, int targetSlotNumber, int amount, BroadcastEventType e = BroadcastEventType.SwapTrhuInventory, bool overrideSlotProtection = false)
		{
			if (nativeInv == null)
			{
				Debug.LogError("Null native inventory provided for SwapItemThruInventoriesSlotToSlot");
				throw new ArgumentNullException("nativeInv", "Null inventory provided");
			}
			if (targetInv == null)
			{
				Debug.LogError("Null target inventory provided for SwapItemThruInventoriesSlotToSlot");
				throw new ArgumentNullException("targetInv", "Null inventory provided");
			}
			if (nativeInv[nativeSlotNumber].item == null)
			{
				Debug.LogWarning("Null item provided for SwapItemsInCertainAmountInSlots");
			}
			Item item = nativeInv[nativeSlotNumber].item;
			if ((object)item != null && !item.stackable)
			{
				nativeInv.SwapItemsThruInventoriesInSlots(targetInv, nativeSlotNumber, targetSlotNumber);
				return 0;
			}
			if (!AcceptsInventoryProtection(nativeInv, MethodType.Swap))
			{
				return amount;
			}
			if (!AcceptsInventoryProtection(targetInv, MethodType.Swap))
			{
				return amount;
			}
			if (targetInv.slots[targetSlotNumber].isProductSlot)
			{
				return amount;
			}
			if (!AcceptsSlotProtection(nativeInv.slots[nativeSlotNumber], MethodType.Swap) && !overrideSlotProtection)
			{
				return amount;
			}
			if (!AcceptsSlotProtection(targetInv.slots[targetSlotNumber], MethodType.Swap) && !overrideSlotProtection)
			{
				return amount;
			}
			ItemGroup whitelist = nativeInv.slots[nativeSlotNumber].whitelist;
			bool num;
			if ((object)whitelist == null)
			{
				if (targetInv.slots[targetSlotNumber].whitelist == null)
				{
					goto IL_0162;
				}
				num = targetInv.slots[targetSlotNumber].whitelist.itemsList.ContainsWNull(nativeInv.slots[nativeSlotNumber].item);
			}
			else
			{
				num = whitelist.itemsList.ContainsWNull(targetInv.slots[targetSlotNumber].item);
			}
			if (num)
			{
				goto IL_0162;
			}
			goto IL_01e1;
			IL_01e4:
			if (amount > nativeInv.slots[nativeSlotNumber].amount)
			{
				return amount;
			}
			InventoryHandler.SwapItemsTrhuInvEventArgs siea;
			if (targetInv.slots[targetSlotNumber].item == null)
			{
				targetInv.slots[targetSlotNumber] = Slot.SetItemProperties(targetInv.slots[targetSlotNumber], nativeInv.slots[nativeSlotNumber].item, amount, _hasItem: true, nativeInv.slots[nativeSlotNumber].durability);
				nativeInv.slots[nativeSlotNumber] = Slot.SetItemProperties(nativeInv.slots[nativeSlotNumber], nativeInv.slots[nativeSlotNumber].item, nativeInv.slots[nativeSlotNumber].amount - amount, _hasItem: true, nativeInv.slots[nativeSlotNumber].durability);
				if (nativeInv.slots[nativeSlotNumber].amount <= 0)
				{
					nativeInv.slots[nativeSlotNumber] = Slot.SetItemProperties(nativeInv.slots[nativeSlotNumber], nullSlot);
				}
			}
			else
			{
				if (nativeInv.slots[nativeSlotNumber].item == targetInv.slots[targetSlotNumber].item)
				{
					int num2 = targetInv.AddItemToSlot(nativeInv.slots[nativeSlotNumber].item, amount, targetSlotNumber);
					nativeInv.slots[nativeSlotNumber] = Slot.SetItemProperties(nativeInv.slots[nativeSlotNumber], nativeInv.slots[nativeSlotNumber].item, nativeInv.slots[nativeSlotNumber].amount - amount + num2, _hasItem: true, nativeInv.slots[nativeSlotNumber].durability);
					if (nativeInv.slots[nativeSlotNumber].amount <= 0)
					{
						nativeInv.slots[nativeSlotNumber] = Slot.SetItemProperties(nativeInv.slots[nativeSlotNumber], nullSlot);
					}
					siea = new InventoryHandler.SwapItemsTrhuInvEventArgs(nativeInv, targetInv, nativeSlotNumber, targetSlotNumber, targetInv.slots[targetSlotNumber].item, nativeInv.slots[nativeSlotNumber].item, amount - num2);
					inventoryHandler.Broadcast(e, null, null, null, siea);
					return num2;
				}
				Slot slot = targetInv.slots[targetSlotNumber];
				targetInv.slots[targetSlotNumber] = Slot.SetItemProperties(targetInv.slots[targetSlotNumber], nativeInv.slots[nativeSlotNumber]);
				nativeInv.slots[nativeSlotNumber] = Slot.SetItemProperties(nativeInv.slots[nativeSlotNumber], slot);
			}
			siea = new InventoryHandler.SwapItemsTrhuInvEventArgs(nativeInv, targetInv, nativeSlotNumber, targetSlotNumber, targetInv.slots[targetSlotNumber].item, nativeInv.slots[nativeSlotNumber].item, amount);
			inventoryHandler.Broadcast(e, null, null, null, siea);
			return 0;
			IL_01e1:
			return amount;
			IL_0162:
			ItemGroup whitelist2 = targetInv.slots[targetSlotNumber].whitelist;
			bool num3;
			if ((object)whitelist2 == null)
			{
				if (nativeInv.slots[nativeSlotNumber].whitelist == null)
				{
					goto IL_01e4;
				}
				num3 = nativeInv.slots[nativeSlotNumber].whitelist.itemsList.ContainsWNull(targetInv.slots[targetSlotNumber].item);
			}
			else
			{
				num3 = whitelist2.itemsList.ContainsWNull(nativeInv.slots[nativeSlotNumber].item);
			}
			if (!num3)
			{
				goto IL_01e1;
			}
			goto IL_01e4;
		}

		public static bool SwapItemThruInventories(this Inventory nativeInv, Inventory targetInv, Item item, int amount, BroadcastEventType e = BroadcastEventType.SwapTrhuInventory)
		{
			if (nativeInv == null)
			{
				Debug.LogError("Null native inventory provided for SwapItemThruInventories");
				throw new ArgumentNullException("nativeInv", "Null inventory provided");
			}
			if (targetInv == null)
			{
				Debug.LogError("Null target inventory provided for SwapItemThruInventories");
				throw new ArgumentNullException("targetInv", "Null inventory provided");
			}
			if (!AcceptsInventoryProtection(nativeInv, MethodType.Swap))
			{
				return false;
			}
			if (!AcceptsInventoryProtection(targetInv, MethodType.Swap))
			{
				return false;
			}
			if (nativeInv.RemoveItem(item, amount))
			{
				int num = targetInv.AddItem(item, amount);
				if (num > 0)
				{
					nativeInv.AddItem(item, num);
				}
				InventoryHandler.SwapItemsTrhuInvEventArgs siea = new InventoryHandler.SwapItemsTrhuInvEventArgs(nativeInv, targetInv, null, null, item, null, amount);
				inventoryHandler.Broadcast(e, null, null, null, siea);
				return true;
			}
			return false;
		}

		public static void SwapItemsThruInventoriesInSlots(this Inventory nativeInv, Inventory targetInv, int nativeSlot, int targetSlot, BroadcastEventType e = BroadcastEventType.SwapTrhuInventory, bool overrideSlotProtection = false)
		{
			if (nativeInv == null || targetInv == null)
			{
				Debug.LogError("Null inventory provided for SwapItemsInSlots");
				throw new ArgumentNullException((nativeInv == null) ? "nativeInv" : "targetInv", "Null inventory provided");
			}
			if (!AcceptsInventoryProtection(nativeInv, MethodType.Swap) || !AcceptsInventoryProtection(targetInv, MethodType.Swap) || targetInv.slots[targetSlot].isProductSlot || (!AcceptsSlotProtection(nativeInv.slots[nativeSlot], MethodType.Swap) && !overrideSlotProtection) || (!AcceptsSlotProtection(targetInv.slots[targetSlot], MethodType.Swap) && !overrideSlotProtection))
			{
				return;
			}
			ItemGroup whitelist = nativeInv.slots[nativeSlot].whitelist;
			bool num;
			if ((object)whitelist == null)
			{
				if (targetInv.slots[targetSlot].whitelist == null)
				{
					goto IL_0100;
				}
				num = targetInv.slots[targetSlot].whitelist.itemsList.ContainsWNull(nativeInv.slots[nativeSlot].item);
			}
			else
			{
				num = whitelist.itemsList.ContainsWNull(targetInv.slots[targetSlot].item);
			}
			if (!num)
			{
				return;
			}
			goto IL_0100;
			IL_0100:
			ItemGroup whitelist2 = targetInv.slots[targetSlot].whitelist;
			bool num2;
			if ((object)whitelist2 == null)
			{
				if (nativeInv.slots[nativeSlot].whitelist == null)
				{
					goto IL_0180;
				}
				num2 = nativeInv.slots[nativeSlot].whitelist.itemsList.ContainsWNull(targetInv.slots[targetSlot].item);
			}
			else
			{
				num2 = whitelist2.itemsList.ContainsWNull(nativeInv.slots[nativeSlot].item);
			}
			if (!num2)
			{
				return;
			}
			goto IL_0180;
			IL_0180:
			Slot slot = targetInv.slots[targetSlot];
			if (nativeInv.slots[nativeSlot].isProductSlot || targetInv.slots[targetSlot].isProductSlot)
			{
				if (slot.item == null)
				{
					targetInv.slots[targetSlot] = Slot.SetItemProperties(targetInv.slots[targetSlot], nativeInv.slots[nativeSlot]);
					nativeInv.slots[nativeSlot] = Slot.SetItemProperties(nativeInv.slots[nativeSlot], slot);
					InventoryHandler.SwapItemsTrhuInvEventArgs siea = new InventoryHandler.SwapItemsTrhuInvEventArgs(nativeInv, targetInv, nativeSlot, targetSlot, nativeInv.slots[targetSlot].item, slot.item, null);
					inventoryHandler.Broadcast(e, null, null, null, siea);
				}
			}
			else
			{
				targetInv.slots[targetSlot] = Slot.SetItemProperties(targetInv.slots[targetSlot], nativeInv.slots[nativeSlot]);
				nativeInv.slots[nativeSlot] = Slot.SetItemProperties(nativeInv.slots[nativeSlot], slot);
				InventoryHandler.SwapItemsTrhuInvEventArgs siea2 = new InventoryHandler.SwapItemsTrhuInvEventArgs(nativeInv, targetInv, nativeSlot, targetSlot, nativeInv.slots[nativeSlot].item, slot.item, null);
				inventoryHandler.Broadcast(e, null, null, null, siea2);
			}
		}

		public static Inventory Initialize(this Inventory inv, BroadcastEventType e = BroadcastEventType.InitializeInventory)
		{
			if (inv == null)
			{
				Debug.LogError("Null inventory provided for Initialize");
				throw new ArgumentNullException("inv", "Null inventory provided");
			}
			if (inv.hasInitializated)
			{
				return inv;
			}
			if (inv.slots.Count != inv.slotAmounts)
			{
				if (inv.slots == null)
				{
					inv.slots = new List<Slot>();
				}
				for (int i = 0; i < inv.slotAmounts; i++)
				{
					if (i >= inv.slots.Count)
					{
						inv.slots.Add(Slot.nullSlot);
					}
				}
			}
			inv.id = inventories.Count;
			inv.hasInitializated = true;
			inventories.Add(inv);
			Debug.Log(inventoryHandler);
			InventoryHandler.InitializeInventoryEventArgs iea = new InventoryHandler.InitializeInventoryEventArgs(inv);
			inventoryHandler.Broadcast(e, null, null, null, null, null, null, iea);
			return inv;
		}

		public static Inventory InitializeInventoryFromAnotherInventory(this Inventory inv, Inventory modelInv, BroadcastEventType e = BroadcastEventType.InitializeInventory)
		{
			if (inv == null)
			{
				Debug.LogError("Null inventory provided for Initialize");
				throw new ArgumentNullException("inv", "Null inventory provided");
			}
			if (modelInv == null)
			{
				Debug.LogError("Null model inventory provided for Initialize");
				throw new ArgumentNullException("modelinv", "Null inventory provided");
			}
			if (inv.hasInitializated)
			{
				return inv;
			}
			inv = modelInv;
			inv.id = inventories.Count;
			inv.hasInitializated = true;
			inventories.Add(inv);
			InventoryHandler.InitializeInventoryEventArgs iea = new InventoryHandler.InitializeInventoryEventArgs(inv);
			inventoryHandler.Broadcast(e, null, null, null, null, null, null, iea);
			return inv;
		}

		public static CraftItemData CraftItem(this Inventory inv, CraftItemData grid, Vector2Int gridSize, bool craftItem, bool allowPatternRecipe, int productSlots)
		{
			if (inventoryHandler == null)
			{
				return CraftItemData.nullData;
			}
			foreach (RecipeGroup recipeAsset in inventoryHandler.recipeAssets)
			{
				if (allowPatternRecipe)
				{
					foreach (PatternRecipe receipePatterns in recipeAsset.receipePatternsList)
					{
						CraftItemData craftItemData = inv.CraftItem(grid, gridSize, craftItem, receipePatterns, productSlots);
						if (craftItemData != CraftItemData.nullData)
						{
							return craftItemData;
						}
					}
				}
				foreach (Recipe recipes in recipeAsset.recipesList)
				{
					CraftItemData craftItemData2 = inv.CraftItem(grid, craftItem, recipes, productSlots);
					if (craftItemData2 != CraftItemData.nullData)
					{
						return craftItemData2;
					}
				}
			}
			return CraftItemData.nullData;
		}

		public static CraftItemData CraftItem(this Inventory inv, CraftItemData grid, Vector2Int gridSize, bool craftItem, RecipeGroup asset, bool allowPatternRecipe, int productSlots)
		{
			if (allowPatternRecipe)
			{
				foreach (PatternRecipe receipePatterns in asset.receipePatternsList)
				{
					CraftItemData craftItemData = inv.CraftItem(grid, gridSize, craftItem, receipePatterns, productSlots);
					if (craftItemData != CraftItemData.nullData)
					{
						return craftItemData;
					}
				}
			}
			foreach (Recipe recipes in asset.recipesList)
			{
				CraftItemData craftItemData2 = inv.CraftItem(grid, craftItem, recipes, productSlots);
				if (craftItemData2 != CraftItemData.nullData)
				{
					return craftItemData2;
				}
			}
			return CraftItemData.nullData;
		}

		public static CraftItemData CraftItem(this Inventory inv, CraftItemData grid, Vector2Int gridSize, bool craftItem, PatternRecipe pattern, int productSlots)
		{
			if (pattern.pattern.Length > grid.items.Length)
			{
				return CraftItemData.nullData;
			}
			if (pattern.products.Length > productSlots)
			{
				return CraftItemData.nullData;
			}
			if (pattern.pattern.Length == grid.items.Length && pattern.amountPattern.Length == grid.amounts.Length)
			{
				if (pattern.pattern.SequenceEqual(grid.items) && SequenceEqualOrGreter(pattern.amountPattern, grid.amounts))
				{
					if (craftItem)
					{
						bool flag = true;
						int num = 0;
						for (int i = grid.items.Length; i - grid.items.Length < productSlots; i++)
						{
							if (!inv.slots[i].hasItem)
							{
								num++;
								continue;
							}
							for (int j = 0; j < pattern.products.Count(); j++)
							{
								if (inv.slots[i].item == pattern.products[j] && inv.slots[i].amount + pattern.amountProducts[j] <= inv.slots[i].item.maxAmount)
								{
									num++;
								}
							}
						}
						if (num < pattern.products.Length)
						{
							flag = false;
						}
						if (flag)
						{
							int num2 = 0;
							int num3 = 0;
							for (int k = grid.items.Length; k < inv.slots.Count; k++)
							{
								if (k <= grid.items.Length - 1)
								{
									continue;
								}
								if (k - grid.items.Length >= pattern.products.Length)
								{
									break;
								}
								while (true)
								{
									if (k + num3 >= inv.slots.Count)
									{
										return CraftItemData.nullData;
									}
									if (!inv[k + num3].hasItem || (!(inv[k + num3].item != pattern.products[k - grid.items.Length]) && (!(inv[k + num3].item == pattern.products[k - grid.items.Length]) || inv[k + num3].amount + pattern.amountProducts[k - grid.items.Length] <= inv[k + num3].item.maxAmount)))
									{
										break;
									}
									num3++;
								}
								num2 = inv.AddItemToSlot(pattern.products[k - grid.items.Length], pattern.amountProducts[k - grid.items.Length], k + num3, BroadcastEventType.AddItem, overrideSlotProtection: true);
								if (num2 > 0)
								{
									return CraftItemData.nullData;
								}
							}
							if (num2 > 0)
							{
								return CraftItemData.nullData;
							}
							for (int l = 0; l < grid.items.Length; l++)
							{
								if (inv.slots[l].hasItem && l <= grid.items.Length - 1)
								{
									inv.RemoveItemInSlot(l, pattern.amountPattern[l]);
								}
							}
						}
					}
					return new CraftItemData(pattern.products, pattern.amountProducts);
				}
			}
			else if (pattern.pattern.Length < grid.items.Length)
			{
				int num4 = (gridSize.y - pattern.gridSize.y + 1) * (gridSize.x - pattern.gridSize.x + 1);
				for (int m = 0; m < num4; m++)
				{
					List<int> usedIndexes;
					CraftItemData craftItemData = inv.CraftItem(GetSectionFromGrid(grid, gridSize, pattern.gridSize, m, out usedIndexes), pattern.gridSize, craftItem: false, pattern, productSlots);
					if (craftItemData.items == null)
					{
						continue;
					}
					bool flag2 = true;
					for (int n = 0; n < grid.items.Length; n++)
					{
						if (!usedIndexes.Contains(n) && grid.items[n] != null)
						{
							flag2 = false;
						}
					}
					if (!flag2)
					{
						continue;
					}
					if (craftItem)
					{
						bool flag3 = true;
						int num5 = 0;
						for (int num6 = grid.items.Length; num6 - grid.items.Length < productSlots; num6++)
						{
							if (!inv.slots[num6].hasItem)
							{
								num5++;
								continue;
							}
							for (int num7 = 0; num7 < pattern.products.Count(); num7++)
							{
								if (inv.slots[num6].item == pattern.products[num7] && inv.slots[num6].amount + pattern.amountProducts[num7] <= inv.slots[num6].item.maxAmount)
								{
									num5++;
								}
							}
						}
						if (num5 < pattern.products.Length)
						{
							flag3 = false;
						}
						if (flag3)
						{
							int num8 = 0;
							int num9 = 0;
							for (int num10 = grid.items.Length; num10 < inv.slots.Count; num10++)
							{
								if (num10 <= grid.items.Length - 1)
								{
									continue;
								}
								if (num10 - grid.items.Length >= pattern.products.Length)
								{
									break;
								}
								while (true)
								{
									if (num10 + num9 >= inv.slots.Count)
									{
										return CraftItemData.nullData;
									}
									if (!inv[num10 + num9].hasItem || (!(inv[num10 + num9].item != pattern.products[num10 - grid.items.Length]) && (!(inv[num10 + num9].item == pattern.products[num10 - grid.items.Length]) || inv[num10 + num9].amount + pattern.amountProducts[num10 - grid.items.Length] <= inv[num10 + num9].item.maxAmount)))
									{
										break;
									}
									num9++;
								}
								num8 = inv.AddItemToSlot(pattern.products[num10 - grid.items.Length], pattern.amountProducts[num10 - grid.items.Length], num10 + num9, BroadcastEventType.AddItem, overrideSlotProtection: true);
								if (num8 > 0)
								{
									return CraftItemData.nullData;
								}
							}
							if (num8 > 0)
							{
								return CraftItemData.nullData;
							}
							for (int num11 = 0; num11 < pattern.gridSize.y; num11++)
							{
								for (int num12 = 0; num12 < pattern.gridSize.x; num12++)
								{
									int num13 = num11 * gridSize.x + num12;
									if (inv.slots[num13].hasItem && num13 <= grid.items.Length - 1)
									{
										Debug.Log(num13 + "  " + pattern.amountPattern.Length);
										inv.RemoveItemInSlot(num13, pattern.amountPattern[num11 * pattern.gridSize.x + num12]);
									}
								}
							}
						}
					}
					return craftItemData;
				}
			}
			return CraftItemData.nullData;
		}

		public static CraftItemData CraftItem(this Inventory inv, CraftItemData grid, bool craftItem, Recipe recipe, int productSlots)
		{
			List<int> list = new List<int>();
			List<int> list2 = new List<int>();
			List<int> list3 = new List<int>();
			if (recipe.products.Length > productSlots)
			{
				return CraftItemData.nullData;
			}
			for (int i = 0; i < grid.items.Length; i++)
			{
				for (int j = 0; j < recipe.numberOfFactors; j++)
				{
					if (grid.items[i] == recipe.factors[j] && !list2.Contains(j))
					{
						list2.Add(j);
						list.Add(i);
						list3.Add(recipe.amountFactors[j]);
						break;
					}
				}
			}
			bool flag = true;
			if (list.Count != recipe.numberOfFactors)
			{
				return CraftItemData.nullData;
			}
			for (int k = 0; k < grid.items.Length; k++)
			{
				if (grid.items[k] != null && !list.Contains(k))
				{
					flag = false;
				}
			}
			for (int l = 0; l < list.Count; l++)
			{
				if (grid.amounts[list[l]] < recipe.amountFactors[l])
				{
					flag = false;
				}
			}
			if (flag)
			{
				if (craftItem)
				{
					bool flag2 = true;
					int num = 0;
					for (int m = grid.items.Length; m - grid.items.Length < productSlots; m++)
					{
						if (!inv.slots[m].hasItem)
						{
							num++;
							continue;
						}
						for (int n = 0; n < recipe.products.Count(); n++)
						{
							if (inv.slots[m].item == recipe.products[n] && inv.slots[m].amount + recipe.amountProducts[n] <= inv.slots[m].item.maxAmount)
							{
								num++;
							}
						}
					}
					if (num < recipe.products.Length)
					{
						flag2 = false;
					}
					if (flag2)
					{
						int num2 = 0;
						int num3 = 0;
						for (int num4 = grid.items.Length; num4 < inv.slots.Count; num4++)
						{
							if (num4 <= grid.items.Length - 1)
							{
								continue;
							}
							if (num4 - grid.items.Length >= recipe.products.Length)
							{
								break;
							}
							while (true)
							{
								if (num4 + num3 >= inv.slots.Count)
								{
									return CraftItemData.nullData;
								}
								if (!inv[num4 + num3].hasItem || (!(inv[num4 + num3].item != recipe.products[num4 - grid.items.Length]) && (!(inv[num4 + num3].item == recipe.products[num4 - grid.items.Length]) || inv[num4 + num3].amount + recipe.amountProducts[num4 - grid.items.Length] <= inv[num4 + num3].item.maxAmount)))
								{
									break;
								}
								num3++;
							}
							num2 = inv.AddItemToSlot(recipe.products[num4 - grid.items.Length], recipe.amountProducts[num4 - grid.items.Length], num4 + num3, BroadcastEventType.AddItem, overrideSlotProtection: true);
							if (num2 > 0)
							{
								return CraftItemData.nullData;
							}
						}
						if (num2 > 0)
						{
							return CraftItemData.nullData;
						}
						int num5 = 0;
						for (int num6 = 0; num6 < grid.items.Length; num6++)
						{
							if (inv.slots[num6].hasItem && num6 <= grid.items.Length - 1)
							{
								inv.RemoveItemInSlot(num6, list3[num5]);
								num5++;
							}
						}
					}
				}
				return new CraftItemData(recipe.products, recipe.amountProducts);
			}
			return CraftItemData.nullData;
		}

		public static CraftItemData GetSectionFromGrid(CraftItemData originalGrid, Vector2Int originalGridSize, Vector2Int sectionSize, int offsetIndex, out List<int> usedIndexes)
		{
			Item[] array = new Item[sectionSize.x * sectionSize.y];
			int[] array2 = new int[sectionSize.x * sectionSize.y];
			usedIndexes = new List<int>();
			int num = originalGridSize.x - sectionSize.x + 1;
			int num2 = Mathf.FloorToInt(offsetIndex / num);
			int num3 = offsetIndex - num2 * num;
			for (int i = 0; i < sectionSize.y; i++)
			{
				for (int j = 0; j < sectionSize.x; j++)
				{
					array[i * sectionSize.x + j] = originalGrid.items[(i + num2) * originalGridSize.x + j + num3];
					array2[i * sectionSize.x + j] = originalGrid.amounts[(i + num2) * originalGridSize.x + j + num3];
					usedIndexes.Add((i + num2) * originalGridSize.x + j + num3);
				}
			}
			return new CraftItemData(array, array2);
		}

		private static bool SequenceEqualOrGreter(int[] firstInt, int[] greterInt)
		{
			bool result = true;
			for (int i = 0; i < firstInt.Length; i++)
			{
				if (greterInt[i] < firstInt[i])
				{
					result = false;
				}
			}
			return result;
		}

		public static CheckItemData CheckItemInInventory(this Inventory inv, Item itemToCheck, int minAmount, InventoryProtection[] acceptableInvProtections = null, SlotProtection acceptableSlotProtections = SlotProtection.Add | SlotProtection.Remove | SlotProtection.Swap | SlotProtection.Use, bool mustBeOnSameSlot = false)
		{
			if (inv == null)
			{
				Debug.LogError("Null inventory provided for CheckItemInInventory");
				return null;
			}
			if (itemToCheck == null)
			{
				Debug.LogError("Null item to check provided for CheckItemInInventory");
				return null;
			}
			List<int> list = new List<int>();
			for (int i = 0; i < inv.slots.Count; i++)
			{
				list.Add(i);
			}
			return inv.CheckItemInInventory(itemToCheck, minAmount, acceptableInvProtections, acceptableSlotProtections, mustBeOnSameSlot, list.ToArray());
		}

		public static CheckItemData CheckItemInInventory(this Inventory inv, Item itemToCheck, int minAmount, InventoryProtection[] acceptableInvProtections = null, SlotProtection acceptableSlotProtections = SlotProtection.Add | SlotProtection.Remove | SlotProtection.Swap | SlotProtection.Use, bool mustBeOnSameSlot = false, params int[] slotsToCheck)
		{
			if (inv == null)
			{
				Debug.LogError("Null inventory provided for CheckItemInInventory");
				return null;
			}
			if (itemToCheck == null)
			{
				Debug.LogError("Null item to check provided for CheckItemInInventory");
				return null;
			}
			if (!acceptableInvProtections.Contains(inv.interactiable))
			{
				return null;
			}
			int num = 0;
			List<int> list = new List<int>();
			foreach (int num2 in slotsToCheck)
			{
				if (num2 >= inv.slots.Count)
				{
					Debug.LogError($"Provided slot index to check is out of array bounds (index: {num2} Array lenght: {inv.slots.Count})\n The code continued to next index");
				}
				else
				{
					if (!acceptableSlotProtections.HasFlag(inv.slots[num2].interative))
					{
						continue;
					}
					if (mustBeOnSameSlot)
					{
						if (inv.slots[num2].item == itemToCheck && inv.slots[num2].amount >= minAmount)
						{
							return new CheckItemData(inv, slotsToCheck, new int[1] { num2 }, inv.slots[num2].amount, _hasItem: true, _mustBeOnSameSlot: true, itemToCheck);
						}
					}
					else if (inv.slots[num2].item == itemToCheck)
					{
						num += inv.slots[num2].amount;
						list.Add(num2);
					}
				}
			}
			if (num >= minAmount && !mustBeOnSameSlot)
			{
				return new CheckItemData(inv, slotsToCheck, list.ToArray(), num, _hasItem: true, _mustBeOnSameSlot: false, itemToCheck);
			}
			return new CheckItemData(inv, slotsToCheck, new int[0], 0, _hasItem: false, mustBeOnSameSlot, itemToCheck);
		}

		public static ToolTipInfo GetTooltipInfoFromSlot(this Inventory inv, int slot)
		{
			if (inv == null)
			{
				Debug.LogError("Null inventory provided for GetTooltipInfoFromSlot");
				return null;
			}
			if (slot < 0 || slot >= inv.slots.Count)
			{
				Debug.LogError("Slot number provided for GetTooltipInfoFromSlot is outside the inventory slots array bounds");
				return null;
			}
			return inv.slots[slot].item.tooltip;
		}

		public static int AddItemToNewSlot(this Inventory inv, Item item, int amount, int durability)
		{
			return inv.AddItemToNewSlot(item, amount, BroadcastEventType.AddItem, overrideSlotProtection: false, durability);
		}

		public static int AddItemToNewSlot(this Inventory inv, Item item, int amount, int durability, Action callback)
		{
			return inv.AddItemToNewSlot(item, amount, BroadcastEventType.AddItem, overrideSlotProtection: false, durability, callback);
		}

		public static int AddItemToNewSlot(this Inventory inv, Item item, int amount, Action callback)
		{
			return inv.AddItemToNewSlot(item, amount, BroadcastEventType.AddItem, overrideSlotProtection: false, null, callback);
		}

		public static int AddItem(this Inventory inv, Item item, int amount, int durability)
		{
			return inv.AddItem(item, amount, BroadcastEventType.AddItem, overrideSlotProtection: false, durability);
		}

		public static int AddItem(this Inventory inv, Item item, int amount, int durability, Action callback)
		{
			return inv.AddItem(item, amount, BroadcastEventType.AddItem, overrideSlotProtection: false, durability, callback);
		}

		public static int AddItem(this Inventory inv, Item item, int amount, Action callback)
		{
			return inv.AddItem(item, amount, BroadcastEventType.AddItem, overrideSlotProtection: false, null, callback);
		}

		public static int AddItemToSlot(this Inventory inv, Item item, int amount, int slotNumber)
		{
			return inv.AddItemToSlot(item, amount, slotNumber, BroadcastEventType.AddItem, false, null, null);
		}

		public static int AddItem(this Inventory inv, Item item, int amount, int slotNumber, int durability)
		{
			return inv.AddItemToSlot(item, amount, slotNumber, durability);
		}

		public static int AddItem(this Inventory inv, Item item, int amount, int slotNumber, int durability, Action callback)
		{
			return inv.AddItemToSlot(item, amount, slotNumber, durability, callback);
		}

		public static int AddItemToSlot(this Inventory inv, Item item, int amount, int slotNumber, int durability)
		{
			return inv.AddItemToSlot(item, amount, slotNumber, BroadcastEventType.AddItem, overrideSlotProtection: false, durability);
		}

		public static int AddItemToSlot(this Inventory inv, Item item, int amount, int slotNumber, int durability, Action callback)
		{
			return inv.AddItemToSlot(item, amount, slotNumber, BroadcastEventType.AddItem, overrideSlotProtection: false, durability, callback);
		}

		public static int AddItemToSlot(this Inventory inv, Item item, int amount, int slotNumber, Action callback)
		{
			return inv.AddItemToSlot(item, amount, slotNumber, BroadcastEventType.AddItem, overrideSlotProtection: false, null, callback);
		}

		private static bool AcceptsSlotProtection(Slot slot, MethodType methodType)
		{
			if (slot.interative.Equals(SlotProtection.Locked))
			{
				return false;
			}
			switch (methodType)
			{
			case MethodType.Add:
				return slot.interative.HasFlag(SlotProtection.Add);
			case MethodType.Remove:
				return slot.interative.HasFlag(SlotProtection.Remove);
			case MethodType.Swap:
			case MethodType.LocalSwap:
				return slot.interative.HasFlag(SlotProtection.Swap);
			case MethodType.Use:
				return slot.interative.HasFlag(SlotProtection.Use);
			default:
				return slot.interative.HasFlag(SlotProtection.Add | SlotProtection.Remove | SlotProtection.Swap | SlotProtection.Use);
			}
		}

		private static bool AcceptsInventoryProtection(Inventory inv, MethodType methodType)
		{
			if (inv.interactiable.Equals(InventoryProtection.Locked))
			{
				return false;
			}
			return methodType switch
			{
				MethodType.Add => inv.interactiable.HasFlag(InventoryProtection.Add), 
				MethodType.Remove => inv.interactiable.HasFlag(InventoryProtection.Remove), 
				MethodType.Swap => inv.interactiable.HasFlag(InventoryProtection.InventoryToInventory), 
				MethodType.LocalSwap => inv.interactiable.HasFlag(InventoryProtection.SlotToSlot), 
				MethodType.Use => inv.interactiable.HasFlag(InventoryProtection.Use), 
				MethodType.Drop => (inv.interactiable & (InventoryProtection.Remove | InventoryProtection.Drop)) != (InventoryProtection.Remove | InventoryProtection.Drop), 
				_ => inv.interactiable.HasFlag(InventoryProtection.InventoryToInventory | InventoryProtection.SlotToSlot | InventoryProtection.Add | InventoryProtection.Remove | InventoryProtection.Use | InventoryProtection.Drop), 
			};
		}
	}
}
