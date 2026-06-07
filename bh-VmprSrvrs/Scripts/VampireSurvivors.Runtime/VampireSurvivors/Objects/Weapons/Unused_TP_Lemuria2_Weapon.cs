namespace VampireSurvivors.Objects.Weapons
{
	public class Unused_TP_Lemuria2_Weapon : Unused_TP_Lemuria1_Weapon
	{
		private TP_DarkRift_Weapon _subWeapon;

		private bool _totalDamageCalculated;

		protected override void Awake()
		{
		}

		protected override void OnStart()
		{
		}

		public override void OnSubWeaponCounter(bool skipTriggers = false)
		{
		}

		public override void Cleanup()
		{
		}

		public override float CalculateTotalDamage()
		{
			return 0f;
		}
	}
}
