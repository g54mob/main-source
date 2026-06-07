namespace VampireSurvivors.Objects.Characters
{
	public class FB_Bradfang : CharacterController_FirstBlood
	{
		private float cooldownOffset;

		private float moveSpeedPercIncrease;

		private float speedPercIncrease;

		protected override void OnUpdate()
		{
		}

		public override float PCooldown()
		{
			return 0f;
		}

		public override float PMoveSpeed()
		{
			return 0f;
		}

		public override float PSpeed()
		{
			return 0f;
		}
	}
}
