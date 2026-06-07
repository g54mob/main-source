using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;
using VampireSurvivors.Data;
using VampireSurvivors.Framework.Particles;
using VampireSurvivors.Framework.Phaser;
using VampireSurvivors.Framework.PhaserTweens;
using VampireSurvivors.Framework.TimerSystem;
using VampireSurvivors.Objects.Characters;
using VampireSurvivors.Objects.Pools;
using VampireSurvivors.Objects.Projectiles;

namespace VampireSurvivors.Objects.Weapons
{
	public class Sample2Weapon : Weapon
	{
		protected int _samplesAmount;

		private ParticleSystem _pfxSnowEmitter;

		protected List<float2> screenGrid;

		private ParticleEmitterManager _particlesManager;

		private ParticleSystem _pfxEmitter;

		private ParticleSystem _pfxEmitter2;

		protected uint[] tints;

		protected bool _triggerReactor;

		protected PhaserSprite _reactorSprite;

		protected PhaserSprite _reactorHideCrimesSprite;

		public float reactorSpriteOffsetY;

		protected BulletPool _reactorPool;

		public Projectile reactorPrefab;

		protected float2 centrePos;

		protected MultiTargetTween _moveReactorTween;

		protected Timer _completeTimer;

		private int lastIndex;

		private int sequenceCounter;

		private float[] _randomOffsets;

		private int _randomOffsetsIndex;

		public override float PPower()
		{
			return 0f;
		}

		public override float SecondaryPPower()
		{
			return 0f;
		}

		protected override void MakeLevelOne()
		{
		}

		protected override void OnStart()
		{
		}

		public virtual void MakeReactor()
		{
		}

		public override void InitWeapon(VampireSurvivors.Objects.Characters.CharacterController characterController, WeaponType weaponType)
		{
		}

		public override void Fire(bool skipTriggers = false)
		{
		}

		protected virtual void fireSample(int sampleInt, float2 position, float flashDelay, float activationDelay)
		{
		}

		public void InputSequence(int index)
		{
		}

		protected void startReactor()
		{
		}

		public void hideReactor()
		{
		}

		public void completeReactor()
		{
		}

		protected virtual void LateUpdate()
		{
		}

		public void SpawnExplosionClustersAt(float2 pos)
		{
		}

		public override Projectile SpawnExplosionAt(float2 pos, int enemiesHit = 0, int damage = 1, float area = 1f)
		{
			return null;
		}

		protected override bool OnBulletOverlapsPlayer(CallbackContext context, ArcadeColliderType second, ArcadeColliderType first)
		{
			return false;
		}

		protected override bool OnSecondaryBulletOverlapsEnemy(CallbackContext context, ArcadeColliderType second, ArcadeColliderType first)
		{
			return false;
		}

		public override void Cleanup()
		{
		}

		private void GenerateParticleSystems()
		{
		}
	}
}
