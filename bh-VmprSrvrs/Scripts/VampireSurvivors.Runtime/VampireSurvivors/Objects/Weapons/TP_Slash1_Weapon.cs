namespace VampireSurvivors.Objects.Weapons
{
	public class TP_Slash1_Weapon : Weapon
	{
		protected override void OnStart()
		{
		}

		public override void CheckArcanas()
		{
		}

		protected override FiringAnimation GetFiringAnimation()
		{
			return default(FiringAnimation);
		}

		protected virtual bool OnBulletOverlapsOwner(CallbackContext context, ArcadeColliderType second, ArcadeColliderType first)
		{
			return false;
		}
	}
}
