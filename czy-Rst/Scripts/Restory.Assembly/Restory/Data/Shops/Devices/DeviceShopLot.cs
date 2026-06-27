using Restory.Data.Base;
using Restory.Data.Devices.Condition;
using Restory.Data.Devices.Quality;
using Restory.Gameplay.Shops;
using Restory.Gameplay.Shops.Devices;
using Restory.Gameplay.TimeSystems;
using UnityEngine;

namespace Restory.Data.Shops.Devices
{
	[CreateAssetMenu(menuName = "Restory/Shops/DevicesShop/DeviceShopLot", fileName = "Name - DeviceShopLot")]
	public class DeviceShopLot : RestoryEntityInfoBase, IDeviceShopLot, ILot
	{
		[SerializeField]
		private DeviceCondition device;

		[SerializeField]
		private DeviceQualityBase quality;

		[SerializeField]
		private int price;

		[SerializeField]
		private string descriptionKey;

		[SerializeField]
		private string sellerNameKey;

		[SerializeField]
		private SellerRating sellerRating;

		[SerializeField]
		private Sprite backgroundIcon;

		[SerializeField]
		private int dayPublication;

		[SerializeField]
		private TimeOfDay publicationTime;

		[SerializeField]
		private int daysBeforeRemoving = -1;

		public bool HasRestriction => device.DeviceInfo.ContentRestriction;

		public IDeviceCondition Device => device;

		public new Sprite Icon => device.DeviceInfo.Icon;

		public string NameKey => device.DeviceInfo.NameLocalizationKey;

		public DeviceQualityBase Quality => quality;

		public int Price => price;

		public int MarketPrice => device.DeviceInfo.DefaultPrice;

		public string DescriptionKey => descriptionKey;

		public string SellerNameKey => sellerNameKey;

		public SellerRating SellerRating => sellerRating;

		public Sprite BackgroundIcon => backgroundIcon;

		public int Day => dayPublication;

		public TimeOfDay PublicationTime => publicationTime;

		public int DaysBeforeRemoving => daysBeforeRemoving;
	}
}
