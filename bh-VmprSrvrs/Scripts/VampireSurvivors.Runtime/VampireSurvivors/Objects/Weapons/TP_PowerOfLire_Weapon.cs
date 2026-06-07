namespace VampireSurvivors.Objects.Weapons
{
	public class TP_PowerOfLire_Weapon : Weapon
	{
		private bool _isManualFire;

		protected override FiringAnimation GetFiringAnimation()
		{
			return default(FiringAnimation);
		}

		public override float PPower()
		{
			return 0f;
		}

		public void SetManualFire()
		{
		}

		public override void ResetFiringTimer()
		{
		}

		public override void Fire(bool skipTriggers = false)
		{
		}

		public void TransformAll()
		{
		}
	}
}
