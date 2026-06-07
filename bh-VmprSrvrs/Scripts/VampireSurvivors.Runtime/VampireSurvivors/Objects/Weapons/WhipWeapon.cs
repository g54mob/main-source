namespace VampireSurvivors.Objects.Weapons
{
	public class WhipWeapon : Weapon
	{
		public override void CheckArcanas()
		{
		}

		protected override FiringAnimation GetFiringAnimation()
		{
			return default(FiringAnimation);
		}
	}
}
