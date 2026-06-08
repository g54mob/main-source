using Unity.Entities;

namespace KitchenData
{
	public interface IPlayerSpecificUI
	{
		Entity PlayerEntity { get; }

		bool IsComplete { get; }
	}
}
