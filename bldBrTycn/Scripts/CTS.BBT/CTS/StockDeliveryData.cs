using CTS.BBT;
using CTS.Core;
using UnityEngine;
using UnityEngine.Serialization;

namespace CTS
{
	[CreateAssetMenu(menuName = "BBT/Stocks/Stock Delivery Data")]
	public class StockDeliveryData : ScriptableObject
	{
		[field: FormerlySerializedAs("Deliverables")]
		[field: SerializeField]
		public StockItemList Deliverables { get; private set; }

		[field: SerializeField]
		public StockAmountData BaseAmount { get; private set; }

		[field: SerializeField]
		public BloodQualityData BaseQuality { get; private set; }

		[field: SerializeField]
		public SerializableDictionary<StockItemSO, StockAmountData> AmountOverrides { get; private set; }

		[field: SerializeField]
		[field: FormerlySerializedAs("QualityOverrides")]
		public SerializableDictionary<StockItemSO, BloodQualityData> QualityOverrides { get; private set; } = new SerializableDictionary<StockItemSO, BloodQualityData>();

		public int GetAmount(StockItemSO itemData)
		{
			if (!AmountOverrides.TryGetValue(itemData, out var value))
			{
				value = BaseAmount;
			}
			if (!value)
			{
				return 0;
			}
			return value.GetRandomAmount();
		}

		public int GetQuality(StockItemSO itemData)
		{
			if (!QualityOverrides.TryGetValue(itemData, out var value))
			{
				value = BaseQuality;
			}
			if (!value)
			{
				return 1;
			}
			return value.GetRandomQuality();
		}
	}
}
