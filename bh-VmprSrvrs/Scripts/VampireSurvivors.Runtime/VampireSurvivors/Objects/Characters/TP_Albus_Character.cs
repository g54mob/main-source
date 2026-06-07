using Coherence.Toolkit;

namespace VampireSurvivors.Objects.Characters
{
	public class TP_Albus_Character : TP_Character
	{
		private float MaxBonus;

		private float MaxEnemies;

		[Sync]
		public float currentBonus;

		public override float PPower()
		{
			return 0f;
		}

		public override float PCooldown()
		{
			return 0f;
		}

		private void LateUpdate()
		{
		}
	}
}
