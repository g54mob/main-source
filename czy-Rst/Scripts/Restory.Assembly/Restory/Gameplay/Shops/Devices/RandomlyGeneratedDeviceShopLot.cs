using System;
using Restory.Data.Devices.Condition;
using Restory.Data.Devices.Quality;
using Restory.Gameplay.WorkOrders.EmailOrders;
using UnityEngine;

namespace Restory.Gameplay.Shops.Devices
{
	[Serializable]
	public class RandomlyGeneratedDeviceShopLot : IDeviceShopLot, ILot
	{
		[SerializeField]
		private RandomlyGeneratedDeviceCondition device;

		[SerializeField]
		private DeviceQualityBase quality;

		[SerializeField]
		private int price;

		[SerializeField]
		private RandomlyGeneratedDeviceShopLotDescriptionLocalizationKeys descriptionKeys;

		[SerializeField]
		private string sellerNameKey;

		[SerializeField]
		private SellerRating sellerRating;

		[SerializeField]
		private DateTime postedDateTime;

		[SerializeField]
		private int dayPosted;

		[SerializeField]
		private int daysBeforeRemoving;

		[SerializeField]
		private int backgroundIconID;

		private Sprite backgroundIcon;

		public bool HasRestriction => device.DeviceInfo.ContentRestriction;

		public string ID => device.ID;

		public IDeviceCondition Device => device;

		public Sprite Icon => device.DeviceInfo.Icon;

		public string NameKey => device.DeviceInfo.NameLocalizationKey;

		public DeviceQualityBase Quality => quality;

		public int Price => price;

		public int MarketPrice => device.DeviceInfo.DefaultPrice;

		public string DescriptionKey => descriptionKeys.UniqueDescriptionKey;

		public RandomlyGeneratedDeviceShopLotDescriptionLocalizationKeys DescriptionKeys => descriptionKeys;

		public string SellerNameKey => sellerNameKey;

		public SellerRating SellerRating => sellerRating;

		public Sprite BackgroundIcon => backgroundIcon;

		public int Day => dayPosted;

		public DateTime PostedDateTime => postedDateTime;

		public int DaysBeforeRemoving => daysBeforeRemoving;

		public int BackgroundIconID => backgroundIconID;

		public RandomlyGeneratedDeviceShopLot(RandomlyGeneratedDeviceCondition device, DeviceQualityBase quality, int price, RandomlyGeneratedDeviceShopLotDescriptionLocalizationKeys descriptionKeys, string sellerNameKey, SellerRating sellerRating, int dayPosted, DateTime postedDateTime, int daysBeforeRemoving, int backgroundIconID)
		{
			this.device = device;
			this.quality = quality;
			this.price = price;
			this.descriptionKeys = descriptionKeys;
			this.sellerNameKey = sellerNameKey;
			this.sellerRating = sellerRating;
			this.postedDateTime = postedDateTime;
			this.daysBeforeRemoving = daysBeforeRemoving;
			this.dayPosted = dayPosted;
			this.backgroundIconID = backgroundIconID;
		}

		public RandomlyGeneratedDeviceShopLot(RandomlyGeneratedDeviceCondition device, DeviceQualityBase quality, int price, RandomlyGeneratedDeviceShopLotDescriptionLocalizationKeys descriptionKeys, string sellerNameKey, SellerRating sellerRating, int dayPosted, DateTime postedDateTime, int daysBeforeRemoving, int backgroundIconID, Sprite backgroundIcon)
		{
			this.device = device;
			this.quality = quality;
			this.price = price;
			this.descriptionKeys = descriptionKeys;
			this.sellerNameKey = sellerNameKey;
			this.sellerRating = sellerRating;
			this.postedDateTime = postedDateTime;
			this.daysBeforeRemoving = daysBeforeRemoving;
			this.dayPosted = dayPosted;
			this.backgroundIconID = backgroundIconID;
			this.backgroundIcon = backgroundIcon;
		}

		public void SetBackgroundIcon(int iconID, Sprite icon)
		{
			backgroundIconID = iconID;
			backgroundIcon = icon;
		}
	}
}
