namespace VampireSurvivors.Objects.Weapons
{
	public class TP_SoulStealPickup_Weapon : TP_SoulSteal_Weapon
	{
		public override float Chance => 0f;

		protected override void MakeLevelOne()
		{
		}

		public override float PPower()
		{
			return 0f;
		}

		public override float PAmount()
		{
			return 0f;
		}

		public override void ResetFiringTimer()
		{
		}
	}
}
