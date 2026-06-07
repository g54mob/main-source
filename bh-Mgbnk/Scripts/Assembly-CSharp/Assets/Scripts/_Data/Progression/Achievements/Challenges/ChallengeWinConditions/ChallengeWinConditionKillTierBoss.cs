using UnityEngine;

namespace Assets.Scripts._Data.Progression.Achievements.Challenges.ChallengeWinConditions
{
	[CreateAssetMenu(menuName = "Me/Progression/Challenge/Win Conditions/Kill Tier Boss", order = 1)]
	public class ChallengeWinConditionKillTierBoss : ChallengeWinCondition
	{
		public override void Init(ChallengeData challengeData)
		{
		}

		public override void Cleanup()
		{
		}

		private void OnStageBossDied(bool didPortalOpen)
		{
		}

		private void OnGhostBossDied()
		{
		}
	}
}
