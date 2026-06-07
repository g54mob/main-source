namespace VampireSurvivors.Objects.Weapons
{
	public class TP_IronBall_Weapon : Weapon
	{
		public override float PPower()
		{
			return 0f;
		}

		public override float PArea()
		{
			return 0f;
		}

		public override void CheckArcanas()
		{
		}

		protected override FiringAnimation GetFiringAnimation()
		{
			return default(FiringAnimation);
		}
	}
}
