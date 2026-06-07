namespace VampireSurvivors.Objects.Weapons
{
	public class TP_PlatinumWhip2_Weapon : TP_PlatinumWhip1_Weapon
	{
		private TP_GrandCross_Weapon _subWeapon;

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

		public override void SetVisible(bool visible)
		{
		}

		public override void Cleanup()
		{
		}

		public override void InternalUpdate()
		{
		}

		public override float CalculateTotalDamage()
		{
			return 0f;
		}
	}
}
