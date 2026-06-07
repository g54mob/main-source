using VampireSurvivors.Framework.Phaser;
using VampireSurvivors.Framework.PhaserTweens;
using VampireSurvivors.Objects.Pools;
using VampireSurvivors.Objects.Weapons;

namespace VampireSurvivors.Objects.Projectiles
{
	public class TP_SwordBrothers_Firing_Projectile : Projectile
	{
		private MultiTargetTween _alphaTween;

		private bool lockOnOwner;

		private PhaserSprite _displaySprite;

		protected override void Awake()
		{
		}

		public override void InitProjectile(BulletPool pool, Weapon weapon, int index)
		{
		}

		public override void InternalUpdate()
		{
		}

		public void SetSwordAngle(float angleValue)
		{
		}

		public void ShootOff()
		{
		}

		public override void Despawn()
		{
		}
	}
}
