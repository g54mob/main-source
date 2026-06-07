using System;
using QFSW.MOP2;
using Unity.Mathematics;
using UnityEngine;
using VampireSurvivors.Data;
using VampireSurvivors.Framework.Particles;
using VampireSurvivors.Framework.Phaser;
using VampireSurvivors.Framework.PhaserTweens;
using VampireSurvivors.Objects.Characters;
using VampireSurvivors.Objects.Pools;
using VampireSurvivors.Objects.Projectiles;

namespace VampireSurvivors.Objects.Weapons
{
	public class TP_SpiritTornado2_Weapon : Weapon
	{
		[SerializeField]
		private SpriteRenderer _WhiteDot;

		[SerializeField]
		private SpriteRenderer _GroundSeal;

		[SerializeField]
		private GameObject _ExplosionVFXPrefab;

		[SerializeField]
		private Projectile _spiritGemProjectilePrefab;

		[SerializeField]
		private Projectile _gemExplosionProjectilePrefab;

		[NonSerialized]
		public float _R;

		[NonSerialized]
		public float _G;

		[NonSerialized]
		public float _B;

		[NonSerialized]
		public float _A;

		private BulletPool _spiritGemProjectilePool;

		private BulletPool _gemExplosionProjectilePool;

		private ObjectPool _explosionPool;

		private MultiTargetTween _rgbTween;

		private MultiTargetTween _alphaTween;

		private bool _canFlash;

		private Projectile _activeProjectile;

		private PhaserSprite _bigGemSprite1;

		private PhaserSprite _bigGemSprite2;

		private float _bigGemAngle;

		private float2 _bigGemOrbitModifier;

		private ParticleEmitterManager _pfxManager;

		private ParticleSystem _pfxEmitter;

		private float _cachedXPMultiplier;

		public float StoredXP { get; set; }

		public BulletPool SpiritGemProjectilePool => null;

		public BulletPool GemExplosionProjectilePool => null;

		public ObjectPool ExplosionPool => null;

		public SpriteRenderer WhiteDot => null;

		protected override bool UseOnlineTimer => false;

		public float TweenInDurationMillis => 0f;

		protected override void OnStart()
		{
		}

		public override void InitWeapon(VampireSurvivors.Objects.Characters.CharacterController characterController, WeaponType weaponType)
		{
		}

		private void InitVariables()
		{
		}

		public override float PInterval()
		{
			return 0f;
		}

		public override void InternalUpdate()
		{
		}

		public override void Fire(bool skipTriggers = false)
		{
		}

		public void FireVenusCrescent(bool skipTriggers)
		{
		}

		public void FlashScreen(Projectile projectile)
		{
		}

		public void SpinSeal(float durationMillis, float scale, float alpha, Projectile projectile)
		{
		}

		public void HideSeal(Projectile projectile)
		{
		}

		protected override void MakeLevelOne()
		{
		}

		private void InitGroundSeal()
		{
		}

		private void ShowSeal()
		{
		}

		private void MakeWhiteDot()
		{
		}

		private void GeneratePool()
		{
		}

		public void MakeBigGem()
		{
		}

		private void DoBigGemTween1()
		{
		}

		private void DoBigGemTween2()
		{
		}

		private void UpdateBigGem()
		{
		}

		public void GrantStoredXP()
		{
		}

		private void SpawnGameKillerGems(float amount)
		{
		}

		public void SpawnGemExplosion()
		{
		}

		private void GenerateParticleSystem()
		{
		}

		public override void SetVisible(bool visible)
		{
		}
	}
}
