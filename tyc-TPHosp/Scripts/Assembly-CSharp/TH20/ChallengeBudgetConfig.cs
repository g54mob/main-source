using System.Collections.Generic;
using FullInspector;
using JetBrains.Annotations;

namespace TH20
{
	[UsedImplicitly(ImplicitUseKindFlags.Assign | ImplicitUseKindFlags.InstantiatedNoFixedConstructorSignature, ImplicitUseTargetFlags.Members)]
	public class ChallengeBudgetConfig : ChallengeConfig
	{
		[InspectorDivider]
		[InspectorMargin(8)]
		[InspectorHeader("Budget Config")]
		public int DurationInMonths;

		public float MinBudgetPercent = 20f;

		public float MaxBudgetPercent = 80f;

		public string TooltipLocString = "Challenges/SubGoals/ChallengeBudget_ToolTip_CS";

		public LocalisedString AdvisorMessageOverride;

		public bool DontShowAdvisorMessage;

		public List<ChallengeBudgetEntry> Stats;

		public ColourPercentMapping[] ColourPercentMappings;

		public bool HideRunningCostsDisplay;

		public bool UseVibeIcon;

		public float VibeAchievementTarget;

		public override Challenge CreateChallenge(Level level)
		{
			return new ChallengeBudget(this, level);
		}
	}
}
