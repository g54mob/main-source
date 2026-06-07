using DG.Tweening;
using UnityEngine;
using VampireSurvivors.Framework.Geom;
using VampireSurvivors.Framework.TimerSystem;
using VampireSurvivors.Objects.Pools;
using VampireSurvivors.Objects.Weapons;

namespace VampireSurvivors.Objects.Projectiles
{
	public class HolyWaterProjectile : Projectile
	{
		[SerializeField]
		private SpriteRenderer _GroundFx;

		private Camera _camera;

		private Tween _angleTween;

		private Tween _positionTween;

		private Timer _hitboxTimer;

		private Timer _expireTimer;

		private Timer _DespawnTimer;

		private ParticleSystem _pfx1;

		private ParticleSystem _pfx2;

		private ParticleSystem _explosionPfx1;

		private ParticleSystem _explosionPfx2;

		private Circle _explosionCircle;

		private const float Radius = 16f;

		private const float ExploRadius = 8f;

		private bool _isBroken;

		private bool _isDespawning;

		private HolyWaterWeapon HolyWater => null;

		protected override void Awake()
		{
		}

		public override void InitProjectile(BulletPool pool, Weapon weapon, int index)
		{
		}

		public override void InternalUpdate()
		{
		}

		private void Break()
		{
		}

		private void StartDespawn()
		{
		}

		public override void Despawn()
		{
		}

		private void GetComponents()
		{
		}

		private void GenerateParticleSystems()
		{
		}
	}
}
