namespace VampireSurvivors.Objects.Characters
{
	public class CharacterControllerSigma : CharacterController
	{
		public override bool NeedsCart => false;

		protected override void MakeLevelOne(bool dontGetCharacterDataForCurrentLevel = false)
		{
		}

		public override void LevelUp()
		{
		}

		protected override void OnStop()
		{
		}

		public override void OnGetDamaged(string hexColor = "#ff0000", float vulnerabilityDelay = 120f, bool playDamageFx = true, bool playWeaponDamageFx = false)
		{
		}

		public override void OnDeath()
		{
		}
	}
}
