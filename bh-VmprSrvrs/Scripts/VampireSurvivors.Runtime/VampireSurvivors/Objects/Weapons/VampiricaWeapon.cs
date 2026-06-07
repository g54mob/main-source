using VampireSurvivors.Framework.TimerSystem;

namespace VampireSurvivors.Objects.Weapons
{
	public class VampiricaWeapon : Weapon
	{
		private Timer _healTimer;

		private bool _canHeal;

		private float _healDelay;

		public override void CheckArcanas()
		{
		}

		protected override bool OnBulletOverlapsEnemy(CallbackContext context, ArcadeColliderType second, ArcadeColliderType first)
		{
			return false;
		}
	}
}
