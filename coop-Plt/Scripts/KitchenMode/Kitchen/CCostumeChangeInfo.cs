using KitchenData;
using Unity.Entities;

namespace Kitchen
{
	public struct CCostumeChangeInfo : IComponentData, IPlayerSpecificUI
	{
		public int CurrentCostume;

		public InputIdentifier Player;

		public Entity PlayerEntity;

		public bool IsComplete;

		Entity IPlayerSpecificUI.PlayerEntity => PlayerEntity;

		bool IPlayerSpecificUI.IsComplete => IsComplete;
	}
}
