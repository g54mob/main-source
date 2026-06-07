using UnityEngine;
using VampireSurvivors.Framework.Particles;
using VampireSurvivors.Framework.Phaser;
using VampireSurvivors.Framework.PhaserTweens;
using VampireSurvivors.Framework.TimerSystem;
using VampireSurvivors.Interfaces;
using VampireSurvivors.Objects.Pools;
using VampireSurvivors.Objects.Weapons;

namespace VampireSurvivors.Objects.Projectiles
{
	public class EME_RapierProjectile : Projectile
	{
		private MultiTargetTween _tween;

		private MultiTargetTween _tween2;

		private EME_RapierWeapon _trueWeapon;

		private ParticleEmitterManager _pfxEmitterManager;

		private ParticleSystem _pfxEmitter;

		private bool _initialisedParticles;

		[SerializeField]
		private MeshRenderer _Quad1;

		[SerializeField]
		private MeshRenderer _Quad2;

		private static readonly int _ScrollSpeedX;

		private static readonly int _ScrollSpeedY;

		private static readonly int _AlphaMul;

		private bool _isFinisher;

		private Timer _DespawnTimer;

		private PhaserSprite _displayImage;

		protected override void Awake()
		{
		}

		public override void InitProjectile(BulletPool pool, Weapon weapon, int index)
		{
		}

		public override void Despawn()
		{
		}

		public override void SetNullTarget()
		{
		}

		public override void SetTarget(Transform target)
		{
		}

		protected override void OnHasHitAnObject(IDamageable other)
		{
		}
	}
}
