using System;
using NSMedieval.Serialization;
using UnityEngine;

namespace NSMedieval.UI
{
	[Serializable]
	[FVSerializableKey("TraderStockModifierItem", "")]
	public class TraderStockModifierItem : TraderStockItemBase
	{
		[SerializeField]
		private float modifyAmount = 1f;

		[SerializeField]
		private float priceModifier = 1f;

		[SerializeField]
		private bool cannotTrade;

		public float ModifyAmount => modifyAmount;

		public float PriceModifier => priceModifier;

		public bool CannotTrade => cannotTrade;

		public TraderStockModifierItem()
		{
		}

		public override void Serialize(FVSerializer serializer)
		{
			base.Serialize(serializer);
			serializer.Write("modifyAmount", modifyAmount);
			serializer.Write("priceModifier", priceModifier);
			serializer.Write("cannotTrade", cannotTrade);
		}

		public TraderStockModifierItem(FVDeserializer deserializer)
			: base(deserializer)
		{
			modifyAmount = deserializer.ReadFloat("modifyAmount");
			priceModifier = deserializer.ReadFloat("priceModifier");
			cannotTrade = deserializer.ReadBool("cannotTrade");
		}
	}
}
