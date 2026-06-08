using System;

namespace KitchenData
{
	[Serializable]
	public struct OrderingValues
	{
		public float StarterModifier;

		public float DessertModifier;

		public float SidesModifier;

		public float ChangeMindModifier;

		public float RepeatCourseModifier;

		public bool GroupOrdersSame;

		public bool SidesOptional;

		public bool IsOnlyFlatFee;

		public int BonusPerDelivery;

		public float ConsumableReuseChance;

		public float MessFactor;

		public bool PreventMess;

		public int MinimumShare;

		public float PriceModifier;

		public int FlatFee;

		public bool SeatWithoutClear;

		public static OrderingValues Ones => new OrderingValues
		{
			StarterModifier = 1f,
			DessertModifier = 1f,
			SidesModifier = 1f,
			ChangeMindModifier = 0f,
			RepeatCourseModifier = 0f,
			GroupOrdersSame = false,
			SidesOptional = false,
			IsOnlyFlatFee = false,
			FlatFee = 0,
			BonusPerDelivery = 0,
			PreventMess = false,
			MessFactor = 1f,
			PriceModifier = 0f
		};

		public static OrderingValues Default => new OrderingValues
		{
			StarterModifier = 0.25f,
			DessertModifier = 0.25f,
			SidesModifier = 0.25f,
			MessFactor = 1f
		};

		public OrderingValues ApplyModifiers(OrderingValues m, float offset = 1f)
		{
			return new OrderingValues
			{
				StarterModifier = StarterModifier * (offset + m.StarterModifier),
				DessertModifier = DessertModifier * (offset + m.DessertModifier),
				SidesModifier = SidesModifier * (offset + m.SidesModifier),
				ChangeMindModifier = ChangeMindModifier + m.ChangeMindModifier,
				RepeatCourseModifier = RepeatCourseModifier + m.RepeatCourseModifier,
				GroupOrdersSame = (GroupOrdersSame || m.GroupOrdersSame),
				SidesOptional = (SidesOptional || m.SidesOptional),
				IsOnlyFlatFee = (IsOnlyFlatFee || m.IsOnlyFlatFee),
				MessFactor = MessFactor * (offset + m.MessFactor),
				PreventMess = (PreventMess || m.PreventMess),
				SeatWithoutClear = (SeatWithoutClear || m.SeatWithoutClear),
				FlatFee = FlatFee + m.FlatFee,
				MinimumShare = MinimumShare + m.MinimumShare,
				BonusPerDelivery = BonusPerDelivery + m.BonusPerDelivery,
				PriceModifier = PriceModifier + m.PriceModifier,
				ConsumableReuseChance = ConsumableReuseChance + (1f - ConsumableReuseChance) * m.ConsumableReuseChance
			};
		}
	}
}
