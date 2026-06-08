using System;
using MessagePack;

namespace KitchenData
{
	[Serializable]
	public struct PatienceValues
	{
		[IgnoreMember]
		private static string _Editor_PatienceMultiplierInfo = "These are applied as Base * (1 + Value), so 0 is neutral, 1 is double and -0.5 is half";

		[IgnoreMember]
		private static string _Editor_PatienceDeliveryBonuses = "Grant this many extra seconds when this type of item is delivered";

		public float Eating;

		public float Thinking;

		public float Seating;

		public float Service;

		public float WaitForFood;

		public float GetFoodDelivered;

		public float DrinkDeliverBonus;

		public float ItemDeliverBonus;

		public float FoodDeliverBonus;

		public bool SkipWaitPhase;

		public bool InfinitePatienceIfQueue;

		public bool DestroyTableIfLeave;

		public bool BonusPatienceWhenNearby;

		public bool ResetPatienceOption;

		public bool ProvidesQueuePatienceBoost;

		public float this[PatienceReason reason]
		{
			get
			{
				return reason switch
				{
					PatienceReason.Eating => Eating, 
					PatienceReason.Thinking => Thinking, 
					PatienceReason.Seating => Seating, 
					PatienceReason.Service => Service, 
					PatienceReason.WaitForFood => WaitForFood, 
					PatienceReason.GetFoodDelivered => GetFoodDelivered, 
					PatienceReason.Queue => 0f, 
					_ => 0f, 
				};
			}
			set
			{
				switch (reason)
				{
				case PatienceReason.Eating:
					Eating = value;
					break;
				case PatienceReason.Thinking:
					Thinking = value;
					break;
				case PatienceReason.Seating:
					Seating = value;
					break;
				case PatienceReason.Service:
					Service = value;
					break;
				case PatienceReason.WaitForFood:
					WaitForFood = value;
					break;
				case PatienceReason.GetFoodDelivered:
					GetFoodDelivered = value;
					break;
				}
			}
		}

		public static PatienceValues Ones => new PatienceValues
		{
			Eating = 1f,
			Thinking = 1f,
			Seating = 1f,
			Service = 1f,
			WaitForFood = 1f,
			GetFoodDelivered = 1f,
			FoodDeliverBonus = 0f,
			ItemDeliverBonus = 0f,
			DrinkDeliverBonus = 0f
		};

		public static PatienceValues Default => new PatienceValues
		{
			Eating = 3f,
			Thinking = 3f,
			Seating = 150f,
			Service = 150f,
			WaitForFood = 90f,
			GetFoodDelivered = 15f,
			FoodDeliverBonus = 2f
		};

		public PatienceValues ApplyModifiers(PatienceValues m, float offset = 1f)
		{
			return new PatienceValues
			{
				Eating = Eating * (offset + m.Eating),
				Thinking = Thinking * (offset + m.Thinking),
				Seating = Seating * (offset + m.Seating),
				Service = Service * (offset + m.Service),
				WaitForFood = WaitForFood * (offset + m.WaitForFood),
				GetFoodDelivered = GetFoodDelivered * (offset + m.GetFoodDelivered),
				FoodDeliverBonus = FoodDeliverBonus + m.FoodDeliverBonus,
				ItemDeliverBonus = ItemDeliverBonus + m.ItemDeliverBonus,
				DrinkDeliverBonus = DrinkDeliverBonus + m.DrinkDeliverBonus,
				SkipWaitPhase = (SkipWaitPhase || m.SkipWaitPhase),
				InfinitePatienceIfQueue = (InfinitePatienceIfQueue || m.InfinitePatienceIfQueue),
				DestroyTableIfLeave = (DestroyTableIfLeave || m.DestroyTableIfLeave),
				BonusPatienceWhenNearby = (BonusPatienceWhenNearby || m.BonusPatienceWhenNearby),
				ResetPatienceOption = (ResetPatienceOption || m.ResetPatienceOption),
				ProvidesQueuePatienceBoost = (ProvidesQueuePatienceBoost || m.ProvidesQueuePatienceBoost)
			};
		}
	}
}
