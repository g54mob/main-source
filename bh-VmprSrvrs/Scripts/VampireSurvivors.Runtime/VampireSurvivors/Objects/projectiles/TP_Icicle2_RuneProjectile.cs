using DG.Tweening;
using UnityEngine;
using VampireSurvivors.Framework.Phaser;
using VampireSurvivors.Framework.TimerSystem;
using VampireSurvivors.Interfaces;
using VampireSurvivors.Objects.Pools;
using VampireSurvivors.Objects.Weapons;

namespace VampireSurvivors.Objects.Projectiles
{
	public class TP_Icicle2_RuneProjectile : Projectile
	{
		private const float BodyRadius = 14f;

		private const float Radius = 0.15f;

		private const float PfxFrequency = 100f;

		private readonly uint[] _pfxTints;

		private TP_Icicle2_Weapon _trueWeapon;

		private PhaserSprite _runeSprite;

		private ParticleSystem _pfx;

		private Timer _hitboxTimer;

		private Timer _pfxTintTimer;

		private Tween _scaleTween;

		private Tween _posTween;

		private bool _updatePosition;

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

		private void RandomisePfxTint()
		{
		}

		public override void InternalUpdate()
		{
		}

		private void LateUpdate()
		{
		}

		private void UpdatePfxScale()
		{
		}

		private void UpdateRotation()
		{
		}

		private void UpdatePosition()
		{
		}

		public void MoveToNewPosition()
		{
		}

		private Vector3 GetLocalPosition()
		{
			return default(Vector3);
		}

		public override void Despawn()
		{
		}

		private void GenerateParticleSystem()
		{
		}

		protected override void OnHasHitAnObject(IDamageable other)
		{
		}
	}
}
