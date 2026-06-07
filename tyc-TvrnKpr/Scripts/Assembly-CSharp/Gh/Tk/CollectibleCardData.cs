using System;
using LitJson;

namespace Gh.Tk
{
	[Serializable]
	public class CollectibleCardData
	{
		[Serializable]
		public enum CardType
		{
			Character = 0,
			Landscape = 1,
			Item = 2,
			Misc = 3,
			Special = 4
		}

		[Serializable]
		public enum CardRarity
		{
			Common = 0,
			Rare = 1,
			Epic = 2,
			Legendary = 3
		}

		[JsonAlias("Type", false)]
		public CardType cardType;

		[JsonAlias("Rarity_Text", false)]
		public CardRarity rarity;

		[JsonAlias("Name_Max24", false)]
		public string name;

		[JsonAlias("Description_Max100", false)]
		public string description;

		[JsonAlias("Image_Path", false)]
		public string imageId;

		[JsonAlias("Card_Count", false)]
		public int cardNumber;

		public static string GetCardRarityKey(CardRarity rarity)
		{
			return null;
		}

		public bool IsUnlocked()
		{
			return false;
		}

		public int GetAmountUnlocked()
		{
			return 0;
		}

		public bool IsUnpacked()
		{
			return false;
		}

		public int GetAmountUnpacked()
		{
			return 0;
		}

		public TooltipData GetTooltip()
		{
			return null;
		}

		public bool IsAllCardsSeen()
		{
			return false;
		}
	}
}
