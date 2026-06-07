using Assets.Source.Item;
using Assets.Source.Player;

namespace Assets.Source.World
{
	public abstract class PowerPlantFrame : CraftingFrame
	{
		protected int _powerStorageAmount;

		private int _addedInventorySpace;

		public override void OnAddFrame()
		{
			_refreshStorage();
		}

		public override void OnConstructionCompleted()
		{
			_refreshStorage();
		}

		private void _refreshStorage()
		{
			if (_addedInventorySpace > 0)
			{
				_removeAddedStorage();
			}
			if (base.Construction == null)
			{
				_addedInventorySpace = _powerStorageAmount;
				GamePlayer.Current.AddItemStorage(ItemType.Power, _addedInventorySpace);
			}
		}

		private void _removeAddedStorage()
		{
			GamePlayer.Current.AddItemStorage(ItemType.Power, -_addedInventorySpace);
			_addedInventorySpace = 0;
		}
	}
}
