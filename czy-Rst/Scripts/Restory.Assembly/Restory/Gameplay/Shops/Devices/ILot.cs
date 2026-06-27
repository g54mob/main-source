using UnityEngine;

namespace Restory.Gameplay.Shops.Devices
{
	public interface ILot
	{
		bool HasRestriction { get; }

		string ID { get; }

		Sprite Icon { get; }

		string NameKey { get; }

		int Price { get; }

		int MarketPrice { get; }

		string DescriptionKey { get; }

		string SellerNameKey { get; }

		SellerRating SellerRating { get; }

		Sprite BackgroundIcon { get; }

		int Day { get; }

		int DaysBeforeRemoving { get; }
	}
}
