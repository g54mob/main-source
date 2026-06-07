using UnityEngine;

namespace Assets.Scripts._Data.Progression.Achievements.Challenges.ChallengeModifiers
{
	[CreateAssetMenu(menuName = "Me/Progression/Challenge/ChallengeModifiers/Blind", order = 1)]
	public class ChallengeModifierBlind : ChallengeModifier
	{
		public override void Init(ChallengeData challengeData)
		{
		}

		public override void Cleanup()
		{
		}

		private void OnGenerationComplete()
		{
		}
	}
}
