using System;
using UnityEngine;

namespace Restory.Gameplay.Shops.Devices
{
	[Serializable]
	public class RandomlyGeneratedElementsBoxLot : IElementsBoxLot, ILot
	{
		[SerializeField]
		private string id;

		[SerializeField]
		private int price;

		[SerializeField]
		private ElementsBoxData boxData;

		[SerializeField]
		private string descriptionKey;

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

		public bool HasRestriction => boxData.Info.ContentRestriction;

		public string ID => id;

		public ElementsBoxData BoxData => boxData;

		public Sprite Icon => boxData.Info.Icon;

		public string NameKey => boxData.Info.NameLocalizationKey;

		public int Price => price;

		public int MarketPrice => boxData.Info.DefaultPrice;

		public string DescriptionKey
		{
			get
			{
				if (!string.IsNullOrEmpty(descriptionKey))
				{
					return descriptionKey;
				}
				return boxData.Info.DescriptionLocalizationKey;
			}
		}

		public string SellerNameKey => sellerNameKey;

		public SellerRating SellerRating => sellerRating;

		public Sprite BackgroundIcon => backgroundIcon;

		public int Day => dayPosted;

		public DateTime PostedDateTime => postedDateTime;

		public int DaysBeforeRemoving => daysBeforeRemoving;

		public int BackgroundIconID => backgroundIconID;

		public RandomlyGeneratedElementsBoxLot(string id, ElementsBoxData boxData, string descriptionKey, int price, string sellerNameKey, SellerRating sellerRating, int dayPosted, DateTime postedDateTime, int daysBeforeRemoving, int backgroundIconID)
		{
			this.id = id;
			this.boxData = boxData;
			this.descriptionKey = descriptionKey;
			this.price = price;
			this.sellerNameKey = sellerNameKey;
			this.sellerRating = sellerRating;
			this.postedDateTime = postedDateTime;
			this.daysBeforeRemoving = daysBeforeRemoving;
			this.dayPosted = dayPosted;
			this.backgroundIconID = backgroundIconID;
		}

		public RandomlyGeneratedElementsBoxLot(string id, ElementsBoxData boxData, string descriptionKey, int price, string sellerNameKey, SellerRating sellerRating, int dayPosted, DateTime postedDateTime, int daysBeforeRemoving, int backgroundIconID, Sprite backgroundIcon)
		{
			this.id = id;
			this.boxData = boxData;
			this.descriptionKey = descriptionKey;
			this.price = price;
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
