using DG.Tweening;
using UnityEngine;
using VampireSurvivors.Framework.Geom;
using VampireSurvivors.Framework.TimerSystem;
using VampireSurvivors.Objects.Pools;
using VampireSurvivors.Objects.Weapons;

namespace VampireSurvivors.Objects.Projectiles
{
	public class EME_CannonProjectile_SunlightShowerCluster : Projectile
	{
		[SerializeField]
		private SpriteRenderer _GroundFx;

		[SerializeField]
		private TrailRenderer _orangeTrail;

		[SerializeField]
		private TrailRenderer _blueTrail;

		[SerializeField]
		private ParticleSystem _orangeExplosionVFX;

		[SerializeField]
		private ParticleSystem _blueExplosionVFX;

		private Camera _camera;

		private Tween _angleTween;

		private Tween _positionTween;

		private Timer _hitboxTimer;

		private Timer _expireTimer;

		private Circle _explosionCircle;

		private const float Radius = 16f;

		private bool _isBroken;

		protected override void Awake()
		{
		}

		public override void InitProjectile(BulletPool pool, Weapon weapon, int index)
		{
		}

		private void SetupMechanics()
		{
		}

		private void SetupVisuals()
		{
		}

		private void Break()
		{
		}

		public override void Despawn()
		{
		}
	}
}
