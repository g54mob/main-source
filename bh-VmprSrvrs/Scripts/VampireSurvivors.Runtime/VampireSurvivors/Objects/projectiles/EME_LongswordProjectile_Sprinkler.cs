using UnityEngine;
using VampireSurvivors.Framework.Particles;
using VampireSurvivors.Framework.Phaser;
using VampireSurvivors.Framework.PhaserTweens;
using VampireSurvivors.Framework.TimerSystem;
using VampireSurvivors.Objects.Pools;
using VampireSurvivors.Objects.Weapons;

namespace VampireSurvivors.Objects.Projectiles
{
	public class EME_LongswordProjectile_Sprinkler : Projectile
	{
		[SerializeField]
		private ParticleSystem _particlesVFX;

		protected float Radius;

		private PhaserSprite _animatedSprite;

		private Timer _hitboxTimer;

		private MultiTargetTween _fadeOutTween;

		private Projectile _parentProjectile;

		private int[] _tints;

		private BlendMode[] _blends;

		protected override void Awake()
		{
		}

		public void setParentProjectile(Projectile parent)
		{
		}

		public override void InitProjectile(BulletPool pool, Weapon weapon, int index)
		{
		}

		public override void InternalUpdate()
		{
		}

		private void UpdatePositionAndScale()
		{
		}

		public override void Despawn()
		{
		}
	}
}
