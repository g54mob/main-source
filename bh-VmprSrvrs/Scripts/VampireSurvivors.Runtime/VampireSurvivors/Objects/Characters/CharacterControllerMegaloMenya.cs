namespace VampireSurvivors.Objects.Characters
{
	public class CharacterControllerMegaloMenya : CharacterController
	{
		public override bool NeedsCart => false;

		public override void LevelUp()
		{
		}

		public override bool GetDamaged(float damageAmount)
		{
			return false;
		}

		protected override void OnStop()
		{
		}

		protected override void OnUpdate()
		{
		}

		public override void OnDeath()
		{
		}
	}
}
