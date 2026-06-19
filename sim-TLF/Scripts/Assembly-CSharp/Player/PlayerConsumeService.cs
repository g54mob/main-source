using System;
using Items;
using Player.FSM;

namespace Player
{
	[Obsolete("Use Player Tool Equip Service Instead")]
	public class PlayerConsumeService : IPlayerConsumeService
	{
		private PlayerProgressiveConsumableObject _leftProgressiveConsumableObject;

		private PlayerProgressiveConsumableObject _rightProgressiveConsumableObject;

		private UsableConsumableItem _leftConsumableItem;

		private UsableConsumableItem _rightConsumableItem;

		PlayerProgressiveConsumableObject IPlayerConsumeService.GetConsumingObject(EquipSide side)
		{
			return side switch
			{
				EquipSide.LEFT_HAND => _leftProgressiveConsumableObject, 
				EquipSide.RIGHT_HAND => _rightProgressiveConsumableObject, 
				_ => null, 
			};
		}

		void IPlayerConsumeService.SetConsumingObject(EquipSide side, PlayerProgressiveConsumableObject obj)
		{
			switch (side)
			{
			case EquipSide.LEFT_HAND:
				_leftProgressiveConsumableObject = obj;
				break;
			case EquipSide.RIGHT_HAND:
				_rightProgressiveConsumableObject = obj;
				break;
			}
		}

		void IPlayerConsumeService.ClearObject(EquipSide side)
		{
			switch (side)
			{
			case EquipSide.LEFT_HAND:
				_leftProgressiveConsumableObject = null;
				_leftConsumableItem = null;
				break;
			case EquipSide.RIGHT_HAND:
				_rightProgressiveConsumableObject = null;
				_rightConsumableItem = null;
				break;
			}
		}

		bool IPlayerConsumeService.IsConsumingIn(EquipSide side)
		{
			return side switch
			{
				EquipSide.LEFT_HAND => _leftProgressiveConsumableObject != null, 
				EquipSide.RIGHT_HAND => _rightProgressiveConsumableObject != null, 
				_ => false, 
			};
		}

		UsableConsumableItem IPlayerConsumeService.GetConsumingWorldItem(EquipSide side)
		{
			return side switch
			{
				EquipSide.LEFT_HAND => _leftConsumableItem, 
				EquipSide.RIGHT_HAND => _rightConsumableItem, 
				_ => null, 
			};
		}

		void IPlayerConsumeService.SetConsumingWorldItem(EquipSide side, UsableConsumableItem item)
		{
			switch (side)
			{
			case EquipSide.LEFT_HAND:
				_leftConsumableItem = item;
				break;
			case EquipSide.RIGHT_HAND:
				_rightConsumableItem = item;
				break;
			}
		}
	}
}
