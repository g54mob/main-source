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
	public class TP_AuraBlast2_Projectile : Projectile
	{
		private const float BodySizeX = 32f;

		private const float BodySizeY = 80f;

		private const float ScaleX = 20f;

		private const float HellfireBaseIntervalMS = 1500f;

		private const float VolcanoScale = 2f;

		private const float VolcanoOffsetY = 0.6f;

		private TP_AuraBlast2_Weapon _trueWeapon;

		private int _hellfireIndex;

		private PhaserSprite _volcanoSprite;

		private bool _initPfx;

		private bool _emitPfx;

		private ParticleEmitterManager _pfxManager;

		private ParticleSystem _pfxEmitter;

		private MultiTargetTween _scaleTween;

		private MultiTargetTween _volcanoTween;

		private Timer _hitBoxTimer;

		private Timer _expireTimer;

		private Timer _hellfireTimer;

		protected override void Awake()
		{
		}

		public override void InitProjectile(BulletPool pool, Weapon weapon, int index)
		{
		}

		private void ScaleIn()
		{
		}

		private void StartTimers()
		{
		}

		private void PlaySfx()
		{
		}

		private void InitVolcano()
		{
		}

		private void DoVolcanoShake()
		{
		}

		private void FireHellfireProjectile()
		{
		}

		public override void InternalUpdate()
		{
		}

		private void UpdateParticles()
		{
		}

		private void FadeOut()
		{
		}

		public override void Despawn()
		{
		}

		private void GenerateParticleSystems()
		{
		}

		protected override void OnHasHitAnObject(IDamageable other)
		{
		}
	}
}
