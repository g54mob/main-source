using System;

namespace PajamaLlama.Fltsm
{
	public class Thirst : DietVital, IComparable<Thirst>
	{
		public override VitalType VitalType => VitalType.Thirst;

		public Thirst(Vitals vitals)
			: base(vitals)
		{
			base.Limit = vitals.Properties.ThirstLimit;
		}

		public override void ConsumeItem(Item item)
		{
			if ((item.Properties.Tags & Item.Tags.Drink) != Item.Tags.None)
			{
				DecreaseAmount();
				AgentItemPropertiesEvent.Dispatch(GameEventType.AgentDrankDrink, base.Agent, item.Properties);
			}
		}

		public int CompareTo(Thirst other)
		{
			return other.Amount - base.Amount;
		}
	}
}
