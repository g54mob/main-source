namespace VampireSurvivors.Objects.Weapons
{
	public class AmmoAppalate1_Weapon_Counter : AmmoAppalate1_Weapon
	{
		public override bool FireInTheFacedDirection => false;

		public override void CheckArcanas()
		{
		}

		public override bool LevelUp()
		{
			return false;
		}
	}
}
