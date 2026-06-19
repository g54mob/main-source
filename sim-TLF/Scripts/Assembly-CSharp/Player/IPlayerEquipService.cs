using System.Collections.Generic;
using Items;
using Player.FSM;

namespace Player
{
	public interface IPlayerEquipService
	{
		Dictionary<EquipSide, IEquipable> EquippedItems { get; }

		void TryEquip(IEquipable clickedItem);

		void TryUnequip(EquipSide side);

		IEquipable GetEquipableAt(EquipSide side);

		bool IsConsumableInRightHand();
	}
}
