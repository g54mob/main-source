using System.Collections.Generic;
using System.Linq;
using Helpers.Ranges;
using JetBrains.Annotations;
using UnityEngine;

namespace Restory.Data.Devices
{
	[CreateAssetMenu(menuName = "Restory/Shops/DevicesShop/RandomLotsGeneration/DeviceShopLotsRandomDevicesGenerationSettings", fileName = "DeviceShopLotsRandomDevicesGenerationSettings")]
	public class DeviceShopRandomDevicesGenerationSettings : ScriptableObject
	{
		[SerializeField]
		private IntRange dailyLotsCount;

		[SerializeField]
		private IntRange lotLifetime;

		[SerializeField]
		[Min(1f)]
		private int maxOneTypeDeviceLotsCountPerDay = 1;

		[SerializeField]
		private IntRange brokenDevicesPercent;

		[SerializeField]
		private IntRange brokenElementsPercent;

		[SerializeField]
		private IntRange dirtyElementsPercent;

		[SerializeField]
		private float brokenDevicePriceModifier;

		[SerializeField]
		private float dirtyDevicePriceModifier;

		[SerializeField]
		private int minusOneYenPricePercentProbability;

		[SerializeField]
		private DeviceShopSellerRating[] sellerRatings = new DeviceShopSellerRating[0];

		public IntRange DailyLotsCount => dailyLotsCount;

		public int MaxOneTypeDeviceLotsCountPerDay => maxOneTypeDeviceLotsCountPerDay;

		public IntRange LotLifetime => lotLifetime;

		public IntRange BrokenDevicesPercent => brokenDevicesPercent;

		public IntRange BrokenElementsPercent => brokenElementsPercent;

		public IntRange DirtyElementsPercent => dirtyElementsPercent;

		public float BrokenDevicePriceModifier => brokenDevicePriceModifier;

		public float DirtyDevicePriceModifier => dirtyDevicePriceModifier;

		public int MinusOneYenPricePercentProbability => minusOneYenPricePercentProbability;

		public IReadOnlyList<DeviceShopSellerRating> SellerRatings => sellerRatings;

		[UsedImplicitly]
		private bool ValidateSellerRatings()
		{
			return sellerRatings.Select((DeviceShopSellerRating x) => x.Rating.Rating).Distinct().Count() == sellerRatings.Length;
		}
	}
}
