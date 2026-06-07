using UnityEngine;

namespace Assets.Scripts._Data.Progression.Achievements.Challenges.ChallengeModifiers
{
	[CreateAssetMenu(menuName = "Me/Progression/Challenge/ChallengeModifiers/1 HP", order = 1)]
	public class ChallengeModifierNoDamage : ChallengeModifier
	{
		private bool hasBeenCalled;

		private bool hasBeenKilled;

		public override void Init(ChallengeData challengeData)
		{
		}

		public override void Cleanup()
		{
		}

		private void OnDamagePlayer()
		{
		}

		public override void Tick()
		{
		}
	}
}
