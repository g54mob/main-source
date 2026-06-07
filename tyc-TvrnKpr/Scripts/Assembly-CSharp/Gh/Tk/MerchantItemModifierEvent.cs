using System.Collections.Generic;

namespace Gh.Tk
{
	public class MerchantItemModifierEvent : GameEvent
	{
		public class Modifier : IPersistable
		{
			public string templateId;

			public string merchantId;

			public int priority;

			public int stockAdjustment;

			public float stockMultiplier;

			public int priceAdjustment;

			public float priceMultiplier;

			private Modifier()
			{
			}

			public Modifier(string templateId)
			{
			}
		}

		public Modifier ActiveModifier { get; set; }

		public static IEnumerable<Modifier> GetActiveModifiers(string merchantId)
		{
			return null;
		}

		private MerchantItemModifierEvent()
		{
		}

		public MerchantItemModifierEvent(Modifier modifier, string timelineTitleKey, string timelineIcon, float dueInDaysF, bool showOnTimeline = true)
		{
		}

		public override void Trigger()
		{
		}
	}
}
