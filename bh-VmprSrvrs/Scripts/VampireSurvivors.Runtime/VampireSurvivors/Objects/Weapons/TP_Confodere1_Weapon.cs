using System;
using System.Collections.Generic;
using UnityEngine;
using VampireSurvivors.Data;
using VampireSurvivors.Framework.Particles;
using VampireSurvivors.Framework.TimerSystem;
using VampireSurvivors.Objects.Characters;
using VampireSurvivors.Objects.Pools;
using VampireSurvivors.Objects.Projectiles;

namespace VampireSurvivors.Objects.Weapons
{
	public class TP_Confodere1_Weapon : Weapon
	{
		private float _range;

		private int _sourceIndex;

		private float _maxSources;

		private List<Transform> _sources;

		[SerializeField]
		protected SpriteRenderer _TargetZone;

		[SerializeField]
		protected Transform _cachedTargetTransform;

		protected Color _targetZoneCol;

		protected float _targetZoneStroke;

		private static readonly int AlphaId;

		private static readonly int ColorId;

		private static readonly int ThicknessId;

		[NonSerialized]
		public int _FireCounter;

		[NonSerialized]
		public int[] _FireAngles;

		private float _defaultRange;

		private BulletPool _destructibleProjectilePool;

		[SerializeField]
		private Projectile _destructibleProjectilePrefab;

		private BulletPool _bigProjectilePool;

		[SerializeField]
		private Projectile _bigProjectilePrefab;

		private BulletPool _specialProjectilePool;

		[SerializeField]
		private Projectile _specialProjectilePrefab;

		protected int _activations;

		protected bool _hasLight;

		protected bool _hasDark;

		private ParticleEmitterManager _pfxManager;

		private ParticleSystem _emitter1;

		private ParticleSystem _emitter2;

		protected List<WeaponType> lightGlyphs;

		protected List<WeaponType> darkGlyphs;

		private Timer glyphCheckTimer;

		protected virtual bool bigProjectileEnabled => false;

		protected virtual bool specialProjectileEnabled => false;

		protected override void Awake()
		{
		}

		public override void InitWeapon(VampireSurvivors.Objects.Characters.CharacterController characterController, WeaponType weaponType)
		{
		}

		protected void CheckGlyphs()
		{
		}

		public override void InternalUpdate()
		{
		}

		public override void ResetFiringTimer()
		{
		}

		public void SetSources(List<Transform> array)
		{
		}

		public override float PPower()
		{
			return 0f;
		}

		public float GetRange()
		{
			return 0f;
		}

		public override void Fire(bool skipTriggers = false)
		{
		}

		public override void SetVisible(bool visible)
		{
		}

		private Transform GetSource()
		{
			return null;
		}

		public override void Cleanup()
		{
		}

		protected virtual bool OnBigBulletOverlapsEnemy(CallbackContext context, ArcadeColliderType second, ArcadeColliderType first)
		{
			return false;
		}

		public override void CheckArcanas()
		{
		}

		public void CheckLightGlyphs()
		{
		}

		public void CheckDarkGlyphs()
		{
		}

		private void MakeEmitters()
		{
		}
	}
}
