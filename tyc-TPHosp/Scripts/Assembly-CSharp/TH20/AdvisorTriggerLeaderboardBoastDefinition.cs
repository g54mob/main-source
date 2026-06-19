using System.Collections.Generic;
using UnityEngine;

namespace TH20
{
	public class AdvisorTriggerLeaderboardBoastDefinition : AdvisorTriggerDefinition
	{
		[Header("Leaderboard Boast")]
		[Tooltip("The priority level of the message")]
		public Advisor.PriorityLevel Priority = Advisor.PriorityLevel.Medium;

		[Tooltip("How many months should go by until we start caring about this?")]
		public int NumMonthsUntilShow = 12;

		[Tooltip("Message to display if your score is top. {0} = Leaderboard Name, {1} = Score")]
		public LocalisedString PlayerTopScoreMessage;

		[Tooltip("Message to display if steamPlayerInfo has top score. {0} = Player Name, {1} = Leaderboard Name, {2} = Score")]
		public LocalisedString FriendTopScoreMessage;

		[Tooltip("Message to display if a steamPlayerInfo has a lower score than you. {0} = Friend Name, {1} = Leaderboard Name, {2} = Friend Score, {3} = Your Score")]
		public LocalisedString FriendLowerMessageLocalised;

		[Tooltip("Message to display if a steamPlayerInfo has a higher score than you. {0} = Friend Name, {1} = Leaderboard Name, {2} = Friend Score, {3} = Your Score")]
		public LocalisedString FriendHigherMessageLocalised;

		public Dictionary<CareerStatsManager.Type, LocalisedString> StatStrings;

		public override AdvisorTrigger CreateAdvisorTrigger()
		{
			return new AdvisorTriggerLeaderboardBoast(this);
		}
	}
}
