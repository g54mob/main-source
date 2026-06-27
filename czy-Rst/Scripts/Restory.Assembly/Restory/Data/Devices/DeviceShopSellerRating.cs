using System;
using Helpers.Ranges;
using Restory.Gameplay.Shops;
using Restory.Gameplay.WorkOrders.EmailOrders;
using UnityEngine;

namespace Restory.Data.Devices
{
	[Serializable]
	public class DeviceShopSellerRating : IRandomnessWeightHolder
	{
		public SellerRating Rating;

		public int LieChancePercent;

		public FloatRange PriceModifierRange;

		[SerializeField]
		private int weight;

		public int Weight => weight;

		public DeviceShopSellerRating(SellerRating rating, int lieChancePercent, FloatRange priceModifierRange, int weight = 1)
		{
			Rating = rating;
			LieChancePercent = Mathf.Clamp(lieChancePercent, 0, 100);
			PriceModifierRange = priceModifierRange;
			this.weight = Mathf.Max(0, weight);
		}
	}
}
