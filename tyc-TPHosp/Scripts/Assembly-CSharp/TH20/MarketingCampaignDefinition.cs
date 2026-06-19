using JetBrains.Annotations;
using UnityEngine;

namespace TH20
{
	[UsedImplicitly(ImplicitUseTargetFlags.Members)]
	public abstract class MarketingCampaignDefinition
	{
		public Sprite Icon;

		public LocalisedString NameLocalised;

		public LocalisedString DescriptionLocalised;

		public int LaunchCost = 1000;

		public int MonthlySpend = 2000;

		public int MinDuration = 3;

		public int MaxDuration = 12;

		public abstract void Apply(float multiplier, MarketingManager marketingManager);
	}
}
