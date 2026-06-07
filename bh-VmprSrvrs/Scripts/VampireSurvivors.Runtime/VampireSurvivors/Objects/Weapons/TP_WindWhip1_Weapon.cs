namespace VampireSurvivors.Objects.Weapons
{
	public class TP_WindWhip1_Weapon : Weapon
	{
		protected int _fireCounter;

		protected int _specialCounter;

		protected int _subWeaponCounter;

		public override float PPower()
		{
			return 0f;
		}

		protected override FiringAnimation GetFiringAnimation()
		{
			return default(FiringAnimation);
		}

		public override void Fire(bool skipTriggers = false)
		{
		}

		public virtual void OnSpecialCounter(bool skipTriggers = false)
		{
		}

		public virtual void OnSubWeaponCounter(bool skipTriggers = false)
		{
		}

		public override void CheckArcanas()
		{
		}
	}
}
