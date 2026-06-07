namespace VampireSurvivors.Objects.Weapons
{
	public class FB_MetalClawWeapon : Weapon
	{
		private float maxCooldownOffset;

		private float cooldownOffset;

		protected override FiringAnimation GetFiringAnimation()
		{
			return default(FiringAnimation);
		}

		protected override void OnUpdate()
		{
		}

		public override float PInterval()
		{
			return 0f;
		}
	}
}
