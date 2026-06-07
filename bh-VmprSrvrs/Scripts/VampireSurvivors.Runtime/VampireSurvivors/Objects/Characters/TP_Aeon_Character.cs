namespace VampireSurvivors.Objects.Characters
{
	public class TP_Aeon_Character : TP_Character
	{
		private float cooldownBonus;

		private float moveBonus;

		private bool _previousTimeStopState;

		public override float LootMult_Orologion => 0f;

		public override float PCooldown()
		{
			return 0f;
		}

		public override float PMoveSpeed()
		{
			return 0f;
		}

		protected override void OnUpdate()
		{
		}

		private void OnTimeStopStart()
		{
		}

		private void OnTimeStopEnd()
		{
		}

		public override void AfterFullInitialization()
		{
		}
	}
}
