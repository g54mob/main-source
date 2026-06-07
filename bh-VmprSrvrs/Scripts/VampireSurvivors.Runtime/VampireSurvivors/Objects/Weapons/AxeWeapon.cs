namespace VampireSurvivors.Objects.Weapons
{
	public class AxeWeapon : Weapon
	{
		public override float PArea()
		{
			return 0f;
		}

		public override void CheckArcanas()
		{
		}

		protected override FiringAnimation GetFiringAnimation()
		{
			return default(FiringAnimation);
		}
	}
}
