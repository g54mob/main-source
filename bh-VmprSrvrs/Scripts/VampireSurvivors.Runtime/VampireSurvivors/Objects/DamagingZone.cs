using UnityEngine;
using VampireSurvivors.Framework.Particles;
using VampireSurvivors.Framework.Phaser;
using VampireSurvivors.Framework.TimerSystem;

namespace VampireSurvivors.Objects
{
	public class DamagingZone : PoolablePhaserSprite
	{
		private Transform _cachedTransform;

		private bool _activateDamage;

		private bool _hasHit;

		private bool _follow;

		private string _skin;

		private float _damage;

		private float _durationMillis;

		private float _hitDelayMillis;

		private Timer _hitboxTimer;

		private Timer _despawnTimer;

		private PhaserSprite _groundFx;

		private ParticleSystem _currentEmitter1;

		private ParticleSystem _currentEmitter2;

		private ParticleEmitterManager _particlesManagerWeapons;

		private ParticleSystem _pfxEmitterW1;

		private ParticleSystem _pfxEmitterW2;

		private GravityWell _wellW;

		private ParticleEmitterManager _particlesManagerTrainees;

		private ParticleSystem _pfxEmitterT1;

		private ParticleSystem _pfxEmitterT2;

		private GravityWell _wellT;

		private ParticleEmitterManager _particlesManagerExplosions;

		private ParticleSystem _pfxEmitterE1;

		private ParticleSystem _pfxEmitterE2;

		private GravityWell _wellE;

		private ParticleEmitterManager _particlesManagerCoffins;

		private ParticleSystem _pfxEmitterC1;

		private ParticleSystem _pfxEmitterC2;

		private GravityWell _wellC;

		private const string SkinWeapons = "Weapons";

		private const string SkinCoffins = "Coffins";

		private const string SkinTrainees = "Trainees";

		private const string SkinExplosions = "Explosions";

		private Transform _targetTransform;

		public bool LockX { get; set; }

		public bool LockY { get; set; }

		protected override void Awake()
		{
		}

		protected override void OnUpdate()
		{
		}

		public void Init(float w, float h, float damage, float durationMillis, float hitBoxDelayMillis, string skinType, bool follow, Transform targetTransform)
		{
		}

		public void TriggerDespawnDelayed()
		{
		}

		private void Despawn()
		{
		}

		private void SetExplosionSize(float x, float y, float width, float height)
		{
		}

		private void SetExplosionDamage(float damage, float durationMillis, float hitDelayMillis)
		{
		}

		private void Shoot()
		{
		}

		private float Approach(float start, float end, float shift)
		{
			return 0f;
		}

		private void SetEmitterInCenter()
		{
		}

		private void SetEmitterOnTheRight()
		{
		}

		private void SetEmitterOnTheLeft()
		{
		}

		private void SetEmitterOnTheTop()
		{
		}

		private void SetEmitterBounds()
		{
		}

		private void MakeParticleSystems()
		{
		}

		private void MakeEmitters_Weapons()
		{
		}

		private void MakeEmitters_Coffins()
		{
		}

		private void MakeEmitters_Trainees()
		{
		}

		private void MakeEmitters_Explosions()
		{
		}

		private GameObject CreateEmitterGameObject(string childName)
		{
			return null;
		}

		private void StopAllEmitters()
		{
		}

		private void ToggleParentAllEmitters(bool shouldParent)
		{
		}

		private static void SetParentAndScale(Transform trans, Transform parent)
		{
		}
	}
}
