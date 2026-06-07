namespace VampireSurvivors.Objects.Weapons
{
	public class Ex_Magistone2_Weapon : Ex_Magistone1_Weapon
	{
		private const int PlayerLevelsPerBonusDamage = 20;

		private const int EnemiesPerBonusAmount = 80;

		public float MinDamage;

		public override float PPower()
		{
			return 0f;
		}

		public override float PAmount()
		{
			return 0f;
		}

		protected override void SetTints()
		{
		}

		public override void CheckArcanas()
		{
		}

		public override void ParadoxFire()
		{
		}
	}
}
