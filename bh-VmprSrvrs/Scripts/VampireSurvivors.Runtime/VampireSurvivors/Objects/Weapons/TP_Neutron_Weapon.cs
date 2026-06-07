namespace VampireSurvivors.Objects.Weapons
{
	public class TP_Neutron_Weapon : Weapon
	{
		private bool _isManualFire;

		protected override FiringAnimation GetFiringAnimation()
		{
			return default(FiringAnimation);
		}

		public void SetManualFire()
		{
		}

		public override void ResetFiringTimer()
		{
		}
	}
}
