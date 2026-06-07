using VampireSurvivors.Framework.PhaserTweens;
using VampireSurvivors.Framework.TimerSystem;
using VampireSurvivors.Interfaces;
using VampireSurvivors.Objects.Pools;
using VampireSurvivors.Objects.Weapons;

namespace VampireSurvivors.Objects.Projectiles
{
	public class TP_Energy1_Projectile : Projectile
	{
		private Timer _expireTimer;

		private float _saveVelX;

		private float _saveVelY;

		private float _spriteSize;

		private float _bodyRadius;

		protected float[] _firingAngles;

		private MultiTargetTween _scaleTween;

		protected override void Awake()
		{
		}

		public override void InitProjectile(BulletPool pool, Weapon weapon, int index)
		{
		}

		public override void InternalUpdate()
		{
		}

		private void Bounce(Body b, bool up, bool down, bool left, bool right)
		{
		}

		private void PlayBounceSFX()
		{
		}

		private void FadeOutAndDispose()
		{
		}

		public override void OnHasHitWallPhaser(PhaserTile tile)
		{
		}

		public override void Despawn()
		{
		}

		protected override void OnHasHitAnObject(IDamageable other)
		{
		}
	}
}
