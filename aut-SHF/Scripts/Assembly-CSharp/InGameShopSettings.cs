using System;
using System.Collections.Generic;
using UI;
using UnityEngine;
using UnityEngine.Localization;

public class InGameShopSettings : ScriptableObject
{
	[Serializable]
	public struct HeroRankPriceInfo
	{
		public eUnitRank rank;

		public int price;
	}

	[Serializable]
	public struct RelicRarityPriceInfo
	{
		public eRelicRarity rarity;

		public int price;

		public int rate;
	}

	[Serializable]
	public struct MotifOutputPriceInfo
	{
		public string name;

		public int price;

		public int priceCountUp;

		public bool isFirstFree;

		public eUpgradeKind shopEffectKind1;

		public List<string> param1;

		public eUpgradeKind shopEffectKind2;

		public List<string> param2;

		public string iconPath;

		public Sprite detailMainImageSprite;

		public LocalizedString localizedString;
	}

	[Serializable]
	public class InGameShopOtherItemData
	{
		public InGameShopDialog.eInGameShopCategory category;

		public string name;

		public string desc;

		public string iconPath;

		public int price;

		public int priceCountUp;

		public bool isFirstFree;

		public string archiveId;

		public List<string> param1;

		public List<string> param2;
	}

	[Header("ヒーロー選出数")]
	public int heroChoiceCount;

	[Header("レリック選出数")]
	public int relicChoiceCount;

	[Space(30f)]
	[Header("ヒーローのランクごとの値段設定")]
	public List<HeroRankPriceInfo> heroRankPrices;

	[Header("レリックのレアリティごとの値段設定")]
	public List<RelicRarityPriceInfo> relicRarityPrices;

	[Header("各モチーフ出力ごとの値段設定")]
	public List<MotifOutputPriceInfo> motifOutputPrices;

	[Header("その他の個別追加アイテム")]
	public List<InGameShopOtherItemData> otherItems;

	public Dictionary<eUnitRank, HeroRankPriceInfo> heroRankPricesDic => null;

	public Dictionary<eRelicRarity, RelicRarityPriceInfo> relicRarityPricesDic => null;

	public Dictionary<string, MotifOutputPriceInfo> motifOutputPricesDic => null;
}
