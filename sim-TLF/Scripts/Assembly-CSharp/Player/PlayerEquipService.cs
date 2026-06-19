using System.Collections.Generic;
using Items;
using Player.FSM;
using UnityEngine;

namespace Player
{
	public class PlayerEquipService : IPlayerEquipService
	{
		private readonly Dictionary<EquipSide, IEquipable> _equippedItems = new Dictionary<EquipSide, IEquipable>();

		public Dictionary<EquipSide, IEquipable> EquippedItems => _equippedItems;

		public void TryEquip(IEquipable clickedItem)
		{
			Debug.Log($" clicked Item is {clickedItem}");
			if (clickedItem == null)
			{
				return;
			}
			EquipSide itemSide = GetItemSide(clickedItem);
			Debug.Log($" side is {itemSide}");
			if (itemSide == EquipSide.NONE)
			{
				return;
			}
			if (_equippedItems.TryGetValue(itemSide, out var value))
			{
				Debug.Log($"Currently equiped on {itemSide}");
				if (value == clickedItem)
				{
					value.Unequip();
					_equippedItems.Remove(itemSide);
					return;
				}
				value.Unequip();
				_equippedItems.Remove(itemSide);
			}
			if (!(clickedItem is IConsumeDecremental { CurrentQuantity: <=0 }))
			{
				clickedItem.Equip();
				_equippedItems[itemSide] = clickedItem;
			}
		}

		public void TryUnequip(EquipSide side)
		{
			if (side != EquipSide.NONE && _equippedItems.TryGetValue(side, out var value))
			{
				value.Unequip();
				_equippedItems.Remove(side);
			}
		}

		private EquipSide GetItemSide(IEquipable item)
		{
			if (item is EquipableToolItem)
			{
				return EquipSide.RIGHT_HAND;
			}
			if (item is UsableConsumableItem usableConsumableItem)
			{
				return usableConsumableItem.ConsumableObject.SideConsuming;
			}
			return EquipSide.NONE;
		}

		IEquipable IPlayerEquipService.GetEquipableAt(EquipSide side)
		{
			if (_equippedItems.TryGetValue(side, out var value))
			{
				return value;
			}
			return null;
		}

		bool IPlayerEquipService.IsConsumableInRightHand()
		{
			bool result = false;
			IEquipable equipableAt = ((IPlayerEquipService)this).GetEquipableAt(EquipSide.RIGHT_HAND);
			if (equipableAt != null && equipableAt is UsableConsumableItem)
			{
				result = true;
			}
			return result;
		}
	}
}
