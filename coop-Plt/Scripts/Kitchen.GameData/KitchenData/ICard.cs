using UnityEngine;

namespace KitchenData
{
	public interface ICard
	{
		string Name { get; }

		string FlavourText { get; }

		string Description { get; }

		Unlock.RewardLevel ExpReward { get; }

		int CardID { get; }

		CardType CardType { get; }

		Color Colour { get; }

		string Icon { get; }
	}
}
