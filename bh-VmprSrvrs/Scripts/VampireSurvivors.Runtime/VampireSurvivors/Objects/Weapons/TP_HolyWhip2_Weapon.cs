namespace VampireSurvivors.Objects.Weapons
{
	public class TP_HolyWhip2_Weapon : TP_HolyWhip1_Weapon
	{
		private TP_GothMissile_Weapon _subWeapon;

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

		public override void SetVisible(bool visible)
		{
		}
	}
}
