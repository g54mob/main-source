using UnityEngine;

namespace Assets.Scripts._Data.Progression.Achievements.Challenges.ChallengeWinConditions
{
	[CreateAssetMenu(menuName = "Me/Progression/Challenge/Win Conditions/Escape First Crypt", order = 1)]
	public class ChallengeWinConditionEscapeFirstCrypt : ChallengeWinCondition
	{
		private ChallengeData challengeData;

		public override void Init(ChallengeData challengeData)
		{
		}

		public override void Cleanup()
		{
		}

		private void OnCryptCompleted(float time)
		{
		}
	}
}
