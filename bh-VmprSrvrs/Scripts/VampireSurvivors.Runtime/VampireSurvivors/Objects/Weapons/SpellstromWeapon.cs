using System;
using UnityEngine;
using VampireSurvivors.Data;
using VampireSurvivors.Framework.Geom;
using VampireSurvivors.Framework.Particles;
using VampireSurvivors.Framework.PhaserTweens;
using VampireSurvivors.Objects.Characters;
using VampireSurvivors.Objects.Projectiles;

namespace VampireSurvivors.Objects.Weapons
{
	public class SpellstromWeapon : Weapon
	{
		private ParticleEmitterManager _pfxManager;

		private ParticleSystem _emitter1;

		private ParticleSystem _emitter2;

		private Circle _emitZone;

		private GravityWell _well1;

		private GravityWell _well2;

		private float _angleValue;

		private ParticleEmitterManager _fixedCircleManager;

		private ParticleSystem _fixedCircleEmitter;

		private Circle _circleEmitZone;

		private SpellstringWeapon _weaponString;

		private SpellstreamWeapon _weaponStream;

		private SpellstrikeWeapon _weaponStrike;

		private MultiTargetTween _singularityTween;

		private float _singularityTime;

		private bool _doingSingularity;

		private MultiTargetTween _restoreTween;

		private float _singularityTimes;

		private bool _skipEmitUpdate;

		private bool _hasBullets;

		private MultiTargetTween _singularityExplosionTween;

		private MultiTargetTween _screenShakeTween;

		private SpellstromProjectile _bulletA;

		private SpellstromProjectile _bulletB;

		private bool _totalDamageCalculated;

		[NonSerialized]
		public float Radius;

		[NonSerialized]
		public float SingularityExplosionValue;

		protected override void Awake()
		{
		}

		public override void InitWeapon(VampireSurvivors.Objects.Characters.CharacterController characterController, WeaponType weaponType)
		{
		}

		public override void Fire(bool skipTriggers = false)
		{
		}

		public override float CalculateTotalDamage()
		{
			return 0f;
		}

		public override void InternalUpdate()
		{
		}

		public override void Cleanup()
		{
		}

		protected virtual float SingularityPower()
		{
			return 0f;
		}

		protected virtual float SingularityDelay()
		{
			return 0f;
		}

		private void InitBullets()
		{
		}

		private void DoSingularity()
		{
		}

		private void ExplodeSingularity()
		{
		}

		protected override void OnStart()
		{
		}

		private void ScreenShake()
		{
		}

		public override void SetVisible(bool visible)
		{
		}
	}
}
