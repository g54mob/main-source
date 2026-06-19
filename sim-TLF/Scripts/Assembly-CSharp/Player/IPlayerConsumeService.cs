using System;
using Items;
using Player.FSM;

namespace Player
{
	[Obsolete("Use Player Tool Equip Service Instead")]
	public interface IPlayerConsumeService
	{
		PlayerProgressiveConsumableObject GetConsumingObject(EquipSide side);

		UsableConsumableItem GetConsumingWorldItem(EquipSide side);

		bool IsConsumingIn(EquipSide side);

		void SetConsumingObject(EquipSide side, PlayerProgressiveConsumableObject obj);

		void SetConsumingWorldItem(EquipSide side, UsableConsumableItem item);

		void ClearObject(EquipSide side);
	}
}
