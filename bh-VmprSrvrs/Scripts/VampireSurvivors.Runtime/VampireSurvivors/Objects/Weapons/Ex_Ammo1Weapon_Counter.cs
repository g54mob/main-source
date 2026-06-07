namespace VampireSurvivors.Objects.Weapons
{
	public class Ex_Ammo1Weapon_Counter : Ex_Ammo1Weapon
	{
		public override bool FireInTheFacedDirection => false;

		public override void CheckArcanas()
		{
		}

		public override bool LevelUp()
		{
			return false;
		}

		protected override FiringAnimation GetFiringAnimation()
		{
			return default(FiringAnimation);
		}
	}
}
