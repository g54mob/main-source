using System.Collections.Generic;
using System.Linq;
using Helpers.Ranges;
using UnityEngine;

namespace Restory.Data.Devices
{
	[CreateAssetMenu(menuName = "Restory/Shops/DevicesShop/RandomLotsGeneration/DeviceShopLotsRandomElementsBoxesGenerationSettings", fileName = "DeviceShopLotsRandomElementsBoxesGenerationSettings")]
	public class DeviceShopRandomElementsBoxesGenerationSettings : ScriptableObject
	{
		[SerializeField]
		private IntRange dailyBoxesCount;

		[SerializeField]
		private IntRange lotLifetime;

		[SerializeField]
		[Min(1f)]
		private int baseElementPrice = 100;

		[SerializeField]
		private int minusOneYenPricePercentProbability;

		[SerializeField]
		private DeviceShopSellerRating[] sellerRatings = new DeviceShopSellerRating[0];

		[SerializeField]
		private DeviceShopRandomElementsBoxPreset[] boxPresets = new DeviceShopRandomElementsBoxPreset[0];

		public IntRange DailyBoxesCount => dailyBoxesCount;

		public IntRange LotLifetime => lotLifetime;

		public int BaseElementPrice => baseElementPrice;

		public int MinusOneYenPricePercentProbability => minusOneYenPricePercentProbability;

		public IReadOnlyList<DeviceShopSellerRating> SellerRatings => sellerRatings;

		public IReadOnlyList<DeviceShopRandomElementsBoxPreset> BoxPresets => boxPresets;

		private bool ValidateSellerRatings()
		{
			return sellerRatings.Select((DeviceShopSellerRating x) => x.Rating.Rating).Distinct().Count() == sellerRatings.Length;
		}

		private bool ValidateBoxPresets()
		{
			return boxPresets.Any((DeviceShopRandomElementsBoxPreset x) => x.Weight > 0);
		}
	}
}
