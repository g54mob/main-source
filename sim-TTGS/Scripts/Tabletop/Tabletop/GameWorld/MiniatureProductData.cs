using UnityEngine;

namespace Tabletop.GameWorld
{
	public class MiniatureProductData : TabletopProductData
	{
		public int NumberInDisplay { get; set; }

		public int NumberInSale { get; set; }

		public static MiniatureProductData Create(int miniatureUID, string locaKey)
		{
			MiniatureData miniatureData = MiniatureDatabase.Get(miniatureUID);
			MiniatureProductData miniatureProductData = ScriptableObject.CreateInstance<MiniatureProductData>();
			miniatureProductData.name = miniatureData.name;
			miniatureProductData.m_name = locaKey;
			miniatureProductData.m_license = miniatureData.License;
			miniatureProductData.m_uid = -miniatureData.UID;
			miniatureProductData.m_productType = EProductType.MINIATURE;
			miniatureProductData.m_buyCoeff = miniatureData.BuyCoeff;
			miniatureProductData.m_marketPrice = miniatureData.MarketPrice;
			return miniatureProductData;
		}

		public static MiniatureProductData Create(int miniatureUID, string locaKey, int inSale, int inDisplay)
		{
			MiniatureData miniatureData = MiniatureDatabase.Get(miniatureUID);
			if (miniatureData == null)
			{
				Debug.LogError("Can't find miniature with UID " + miniatureUID);
				return null;
			}
			MiniatureProductData miniatureProductData = ScriptableObject.CreateInstance<MiniatureProductData>();
			miniatureProductData.name = miniatureData.name;
			miniatureProductData.m_name = locaKey;
			miniatureProductData.m_license = miniatureData.License;
			miniatureProductData.m_uid = -miniatureData.UID;
			miniatureProductData.NumberInSale = inSale;
			miniatureProductData.NumberInDisplay = inDisplay;
			miniatureProductData.m_productType = EProductType.MINIATURE;
			miniatureProductData.m_buyCoeff = miniatureData.BuyCoeff;
			miniatureProductData.m_marketPrice = miniatureData.MarketPrice;
			return miniatureProductData;
		}
	}
}
