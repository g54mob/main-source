using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;
using VampireSurvivors.Framework.Geom;
using VampireSurvivors.Framework.Particles;
using VampireSurvivors.Framework.Phaser;
using VampireSurvivors.Framework.PhaserTweens;
using VampireSurvivors.Framework.TimerSystem;

namespace VampireSurvivors.Objects
{
	public class DamageZoneFlexible : PoolablePhaserSprite
	{
		public enum ZoneAlignment
		{
			Center = 0,
			Left = 1,
			Right = 2,
			Top = 3,
			Bottom = 4
		}

		private Transform _cachedTransform;

		private Timer _hitboxTimer;

		private Timer _despawnTimer;

		private Timer _particleDespawnTimer;

		private MultiTargetTween _activateDamageZoneTween;

		private MultiTargetTween _enableDamageTween;

		private MultiTargetTween _warningTween;

		private float _damage;

		private float _activatonDelay;

		private float _durationMillis;

		private float _hitDelayMillis;

		private bool _haveWarningMark;

		private float _warningTimeMillis;

		private PhaserSprite _exclamationMark;

		protected bool _isCircle;

		protected Circle _circleCollider;

		protected bool _activateDamage;

		protected bool _hasHit;

		private bool _follow;

		private float _followSpeed;

		private bool _lockX;

		private bool _lockY;

		private Transform _targetTransform;

		private bool _visibleWarningZone;

		protected PhaserSprite _groundFx;

		private float2 _offsetPosition;

		private PhaserSprite _damageSprite;

		private bool _usingParticles;

		private ParticleEmitterManager _particlesManager;

		private ZoneAlignment _zoneAlignment;

		private ParticleSystem _currentEmitter;

		private ParticleSystem _pfxEmitter;

		private GravityWell _well;

		protected override void Awake()
		{
		}

		public static DamageZoneFlexible CreateZone(Camera targetCamera)
		{
			return null;
		}

		public static ParticleSystemConfig BaseConfig(Vector3 pos, List<string> frames, string textureName = "items")
		{
			return null;
		}

		public void InitDamageZone(float damage, float durationMillis, float activationDelay, float hitDelayMillis, float2 spawnLocation)
		{
		}

		public void InitDamageZoneCircle(float radius, bool enableGroundVisuals = true)
		{
		}

		private void SetCircleDamageZone(float radius)
		{
		}

		public void InitDamageZoneRectangle(float width, float height, bool enableGroundVisuals = true)
		{
		}

		private void SetRectangleDamageZone(float2 size)
		{
		}

		public void InitWarningBehaviour(bool haveWarningMark, float warningTimeMillis = 600f)
		{
		}

		public void InitDamageZoneBehaviour(bool lockX, bool lockY, bool following, Transform targetTransform = null, float followSpeed = 1f)
		{
		}

		public void InitParticleVisuals(ParticleSystemConfig newConfig, ZoneAlignment newAlignment)
		{
		}

		public void InitSpriteVisuals(List<Sprite> newAnimFrames, int fps, float offsetX, float offsetY, float frameScale)
		{
		}

		public void EnableZone()
		{
		}

		private void ActivateDamage()
		{
		}

		protected override void OnUpdate()
		{
		}

		protected virtual Vector3 UpdatePosition(Vector3 currentPosition)
		{
			return default(Vector3);
		}

		protected virtual void UpdatePlayerEffects()
		{
		}

		private void TriggerDespawnDelayed()
		{
		}

		protected virtual void Despawn()
		{
		}

		private Vector3 GetZoneAlignmentPosition(Vector3 pos)
		{
			return default(Vector3);
		}

		private void SetEmitterLocation(Vector3 newPos)
		{
		}

		private void SetEmitterBounds()
		{
		}

		private void MakeEmitterManager()
		{
		}

		private void MakeEmitters(ParticleSystemConfig config1, ParticleSystemConfig config2)
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
