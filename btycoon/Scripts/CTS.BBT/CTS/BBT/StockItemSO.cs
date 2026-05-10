using System;
using CTS.Core;
using CTS.StockInventory;
using NaughtyAttributes;
using UnityEngine;

namespace CTS.BBT
{
	[CreateAssetMenu(menuName = "BBT/Storable Item", fileName = "New Storable Item")]
	public class StockItemSO : AbsBuyableItemSO
	{
		[SerializeField]
		[BoxGroup("Common")]
		public float SellPriceMultiplier = 0.5f;

		[SerializeField]
		[BoxGroup("Common")]
		public bool ForceLockInStore;

		[field: SerializeField]
		public StringKey<StockType> StockType { get; private set; } = "VampireStock";

		[field: SerializeField]
		[field: BoxGroup("Common")]
		public int[] PriceByQuality { get; private set; }

		[field: SerializeField]
		public float TimeForCommand { get; private set; }

		public int GetUnitPrice(float quality)
		{
			quality = Math.Clamp(quality, 1f, 10f);
			int num = Mathf.FloorToInt(quality) - 1;
			if (num >= PriceByQuality.Length)
			{
				return PriceByQuality[PriceByQuality.Length - 1];
			}
			return PriceByQuality[num];
		}

		public void ImportData(StockItemSOImportData data)
		{
			SellPriceMultiplier = data.SellPriceMultiplier;
			base.PurchasePrice = data.PurchasePrice;
			PriceByQuality = new int[10] { data.QualityPrice_1, data.QualityPrice_2, data.QualityPrice_3, data.QualityPrice_4, data.QualityPrice_5, data.QualityPrice_6, data.QualityPrice_7, data.QualityPrice_8, data.QualityPrice_9, data.QualityPrice_10 };
		}
	}
}
