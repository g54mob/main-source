using UnityEngine;
using VampireSurvivors.Framework.Particles;
using VampireSurvivors.Framework.Phaser;
using VampireSurvivors.Framework.PhaserTweens;
using VampireSurvivors.Framework.TimerSystem;
using VampireSurvivors.Objects.Pools;
using VampireSurvivors.Objects.Weapons;

namespace VampireSurvivors.Objects.Projectiles
{
	public class EME_AxeProjectile_HellsFury : Projectile
	{
		private MultiTargetTween _tween;

		private MultiTargetTween _tween2;

		private EME_RapierWeapon _trueWeapon;

		private ParticleEmitterManager _pfxEmitterManager;

		private ParticleSystem _pfxEmitter;

		[SerializeField]
		private ParticleSystem punchVFX;

		[SerializeField]
		private MeshRenderer _Quad1;

		[SerializeField]
		private MeshRenderer _Quad2;

		private static readonly int _ScrollSpeedX;

		private static readonly int _ScrollSpeedY;

		private static readonly int _AlphaMul;

		private Timer _DespawnTimer;

		private PhaserSprite _displayImage;

		private float _offsetX;

		private MultiTargetTween slashTween;

		private MultiTargetTween modelTween1;

		private MultiTargetTween modelTween2;

		private Timer _hitboxTimer;

		private int _strikeTimes;

		private void LateUpdate()
		{
		}

		protected override void Awake()
		{
		}

		public override void InitProjectile(BulletPool pool, Weapon weapon, int index)
		{
		}

		private void Activate()
		{
		}

		public void StartDespawn()
		{
		}

		public override void Despawn()
		{
		}
	}
}
