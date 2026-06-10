using System;
using NSEipix.Model;
using NSMedieval.Serialization;
using UnityEngine;

namespace NSMedieval.UI
{
	[Serializable]
	[FVSerializableKey("TraderStockItem", "")]
	public class TraderStockItem : TraderStockItemBase
	{
		[SerializeField]
		private IntRange amountRange;

		[SerializeField]
		private IntRange entriesCount;

		[SerializeField]
		private float chance = 1f;

		public IntRange AmountRange => amountRange;

		public IntRange EntriesCount => entriesCount;

		public float Chance => chance;

		public TraderStockItem()
		{
		}

		public override void Serialize(FVSerializer serializer)
		{
			base.Serialize(serializer);
			serializer.Write("amountRange", amountRange);
			serializer.Write("entriesCount", entriesCount);
			serializer.Write("chance", chance);
		}

		public TraderStockItem(FVDeserializer deserializer)
			: base(deserializer)
		{
			amountRange = deserializer.ReadObject<IntRange>("amountRange");
			entriesCount = deserializer.ReadObject<IntRange>("entriesCount");
			chance = deserializer.ReadFloat("chance");
		}
	}
}
