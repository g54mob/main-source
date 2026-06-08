using KitchenData;
using Unity.Entities;

namespace Kitchen
{
	public struct CDishSelectionInfo : IComponentData, IPlayerSpecificUI
	{
		public InputIdentifier Player;

		public Entity PlayerEntity;

		public int Dish;

		public bool IsComplete;

		Entity IPlayerSpecificUI.PlayerEntity => PlayerEntity;

		bool IPlayerSpecificUI.IsComplete => IsComplete;
	}
}
