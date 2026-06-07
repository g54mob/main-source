using System;

namespace PajamaLlama.Fltsm
{
	public class Hunger : DietVital, IComparable<Hunger>
	{
		public override VitalType VitalType => VitalType.Hunger;

		public Hunger(Vitals vitals)
			: base(vitals)
		{
			base.Limit = vitals.Properties.HungerLimit;
		}

		public override void Start()
		{
			if (base.Diet.Favourite == null)
			{
				base.Diet.SetFavourite(base.Properties.FavouriteFoods.GetRandom());
			}
		}

		public override void ConsumeItem(Item item)
		{
			if (item.Properties.Tags == Item.Tags.Food)
			{
				DecreaseAmount();
				new AgentItemPropertiesEvent(GameEventType.AgentAteFood, base.Agent, item.Properties).Dispatch();
			}
		}

		public int CompareTo(Hunger other)
		{
			return other.Amount - base.Amount;
		}
	}
}
