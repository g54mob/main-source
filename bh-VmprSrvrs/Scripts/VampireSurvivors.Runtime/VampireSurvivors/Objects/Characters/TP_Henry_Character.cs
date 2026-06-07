using Coherence.Toolkit;

namespace VampireSurvivors.Objects.Characters
{
	public class TP_Henry_Character : TP_Character
	{
		private float MaxBonus;

		private float MaxEnemies;

		[Sync]
		public float currentBonus;

		public override float PLuck()
		{
			return 0f;
		}

		public override float PArea()
		{
			return 0f;
		}

		private void LateUpdate()
		{
		}
	}
}
