using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;
using VampireSurvivors.Framework.Phaser;
using VampireSurvivors.Framework.PhaserTweens;
using VampireSurvivors.Framework.TimerSystem;
using VampireSurvivors.Interfaces;
using VampireSurvivors.Objects.Pools;
using VampireSurvivors.Objects.Weapons;

namespace VampireSurvivors.Objects.Projectiles
{
	public class TP_Fire2_Projectile : Projectile
	{
		private const float Radius = 24f;

		private TP_Fire2_Weapon _parentWeapon;

		private bool _isDespawning;

		private PhaserSprite _headSprite;

		private float _scaledAlpha;

		private float _cachedProjSpeed;

		private float _cachedWeaponArea;

		private float _cachedWeaponHitBoxDelayOverSpeed;

		private float _cachedWeaponSpeed;

		private float _cachedWeaponSpeedRepeatInterval;

		private MultiTargetTween _scaleTween;

		private MultiTargetTween _alphaTween;

		private bool _cachedFlipX;

		private float _turnAngle;

		private float _turnSpeed;

		private bool _isRotating;

		private List<Vector3> _positions;

		private List<Quaternion> _rotations;

		private List<float> _rotationPath;

		private List<float> _forwardPath;

		private int _rotationCounter;

		private int _forwardCounter;

		private bool _rotationTimerStarted;

		private float _scale;

		private Timer _expireTimer;

		private Timer _hitboxTimer;

		private Timer _moveTimer;

		private List<TP_Fire2Tail_Projectile> _tails;

		private float2 _tailSpawnPos;

		private float _tailSpawnTimer;

		public List<Vector3> Positions => null;

		public List<Quaternion> Rotations => null;

		public float Scale => 0f;

		public float CachedWeaponArea => 0f;

		public float CachedWeaponHitBoxDelayOverSpeed => 0f;

		public float ScaledAlpha => 0f;

		protected override void Awake()
		{
		}

		public override void InitProjectile(BulletPool pool, Weapon weapon, int index)
		{
		}

		public override void InternalUpdate()
		{
		}

		public void SetMovementPath(List<float> rotations, List<float> forwards, bool isMirrored = false)
		{
		}

		private void StartRotationTimer()
		{
		}

		private void StartForwardTimer()
		{
		}

		private void StartDespawn()
		{
		}

		public override void Despawn()
		{
		}

		protected override void OnHasHitAnObject(IDamageable other)
		{
		}
	}
}
