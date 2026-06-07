namespace VampireSurvivors.Objects.Weapons
{
	public class TP_Slash2_Weapon : Weapon
	{
		protected override void OnStart()
		{
		}

		protected override FiringAnimation GetFiringAnimation()
		{
			return default(FiringAnimation);
		}

		protected override float CalcCritMul()
		{
			return 0f;
		}

		public override void CheckArcanas()
		{
		}
	}
}
