using System.Collections.Generic;
using FullInspector;
using JetBrains.Annotations;
using UnityEngine;

namespace TH20
{
	[UsedImplicitly(ImplicitUseKindFlags.Assign | ImplicitUseKindFlags.InstantiatedNoFixedConstructorSignature, ImplicitUseTargetFlags.Members)]
	public abstract class ChallengeConfig : ObjectiveDefinition
	{
		[InspectorHeader("Challenge Config")]
		[InspectorMargin(8)]
		public bool DisplayOnHUD;

		[InspectorHeader("Prerequisites")]
		public List<IChallengePrerequisite> Prerequisites;

		[InspectorHeader("Challenge Notice")]
		public bool IssueChallengeNotice;

		public int DaysUntilChallengeStart = 5;

		public bool PlayerCanRejectChallengeNotice;

		[FullInspector.InspectorName("Wait For Response Before Challenge Starts")]
		public bool WaitForNoticeResponseBeforeStartingChallenge;

		[InspectorTooltip("Show this advisor message when the challenge is issued. If empty then no message will be displayed.")]
		public LocalisedString AdvisorMessageOnIssue;

		public Sprite AdvisorIconOnIssue;

		[FullInspector.InspectorName("Advisor Message On Arrival")]
		[InspectorTooltip("Show this advisor message on arrival. If empty then no message will be displayed.")]
		public LocalisedString AdvisorMessageOnArrivalLocalised;

		public Sprite AdvisorIconOnArrival;

		[FullInspector.InspectorName("Notice Message")]
		public ChallengeNoticeDef NoticeDef;

		[InspectorMargin(8)]
		[InspectorHeader("Challenge Debrief")]
		public bool IssueDebrief;

		public int DaysUntilIssuingDebrief = 5;

		[FullInspector.InspectorName("Wait For Response Before Issuing Rewards")]
		public bool WaitForDebriefResponseBeforeIssuingReward;

		[InspectorMargin(8)]
		[InspectorHeader("Rewards")]
		public int RewardSuccessScore;

		[FullInspector.InspectorName("Rewards To Issue")]
		public ChallengeReward Reward;

		[InspectorMargin(8)]
		[FullInspector.InspectorName("Radio")]
		public Dictionary<SharedInstance<RadioDJDefinition>, RadioDJQuote> LineInjectionsOnCompletion;

		public float ChanceOfLineInjection = 1f;

		[InspectorMargin(8)]
		[InspectorHeader("Tannoy Announcements")]
		[FullInspector.InspectorName("Start")]
		public string[] TannoyOnStart;

		[FullInspector.InspectorName("Fail")]
		public string[] TannoyOnFailed;

		[FullInspector.InspectorName("Success")]
		public string[] TannoyOnSuccess;

		public bool CheckConditions(Level level)
		{
			if (Prerequisites == null)
			{
				return true;
			}
			foreach (IChallengePrerequisite prerequisite in Prerequisites)
			{
				if (prerequisite != null && !prerequisite.CheckConditions(level))
				{
					return false;
				}
			}
			return true;
		}

		public abstract Challenge CreateChallenge(Level level);
	}
}
