using DG.Tweening;
using VampireSurvivors.Framework.TimerSystem;
using VampireSurvivors.Interfaces;
using VampireSurvivors.Objects.Pools;
using VampireSurvivors.Objects.Weapons;

namespace VampireSurvivors.Objects.Projectiles
{
	public class EME_WaveProjectile : Projectile
	{
		private Tween _scaleTween;

		private float _saveVelX;

		private float _saveVelY;

		private Timer _bounceTimer;

		private bool _canBounce;

		protected override void Awake()
		{
		}

		protected override void OnDestroy()
		{
		}

		public override void InitProjectile(BulletPool pool, Weapon weapon, int index)
		{
		}

		public override void InternalUpdate()
		{
		}

		protected override void OnHasHitAnObject(IDamageable other)
		{
		}

		public override void OnHasHitWallPhaser(PhaserTile tile)
		{
		}

		private void Bounce(Body bdy, bool up, bool down, bool left, bool right)
		{
		}

		public override void Despawn()
		{
		}
	}
}
