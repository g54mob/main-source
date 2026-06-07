using System.Collections.Generic;
using UnityEngine;

namespace Motorways
{
	[CreateAssetMenu(fileName = "New Challenge Database", menuName = "Motorways/Challenges/Challenge Database", order = 2)]
	public class ChallengeDatabase : ScriptableObject
	{
		public static Diagnostics.Log.Channel Log = Diagnostics.Log.OpenChannel("ChallengeDatabase");

		[NonReorderable]
		public List<ChallengeData> regularChallenges = new List<ChallengeData>();

		[NonReorderable]
		public List<ChallengeData> wildcardChallenges = new List<ChallengeData>();

		[NonReorderable]
		public List<ChallengeData> challengesExcludedFromDailyWeekly = new List<ChallengeData>();

		[NonReorderable]
		public List<ChallengeData> debugInjectedChallenges = new List<ChallengeData>();

		[NonReorderable]
		public List<YearOfChallenges> precalculatedChallenges;

		[Tooltip("Unlocking any of these achievements will unlock daily & weekly challenges")]
		[NonReorderable]
		public MotorwaysAchievementData[] qualifyingAchievementsToUnlockTimedChallenges;

		public ChallengeData expertModeChallenge;

		public bool IsChallengeWildcard(ChallengeData challenge)
		{
			return wildcardChallenges.Contains(challenge);
		}

		public bool TryGetChallenge(string challengeName, out ChallengeData result)
		{
			foreach (ChallengeData regularChallenge in regularChallenges)
			{
				if (regularChallenge.name == challengeName)
				{
					result = regularChallenge;
					return true;
				}
			}
			foreach (ChallengeData wildcardChallenge in wildcardChallenges)
			{
				if (wildcardChallenge.name == challengeName)
				{
					result = wildcardChallenge;
					return true;
				}
			}
			foreach (ChallengeData item in challengesExcludedFromDailyWeekly)
			{
				if (item.name == challengeName)
				{
					result = item;
					return true;
				}
			}
			if (expertModeChallenge.name == challengeName)
			{
				result = expertModeChallenge;
				return true;
			}
			Log.Error("Unable to find challenge matching the name: '" + challengeName + "'!");
			result = null;
			return false;
		}
	}
}
