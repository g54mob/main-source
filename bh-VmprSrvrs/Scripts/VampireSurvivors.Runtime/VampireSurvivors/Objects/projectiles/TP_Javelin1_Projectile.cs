using UnityEngine;
using VampireSurvivors.Framework.PhaserTweens;
using VampireSurvivors.Framework.TimerSystem;
using VampireSurvivors.Interfaces;
using VampireSurvivors.Objects.Pools;
using VampireSurvivors.Objects.Weapons;

namespace VampireSurvivors.Objects.Projectiles
{
	public class TP_Javelin1_Projectile : Projectile
	{
		private const float Gravity = 4f;

		private const float InitialAngle = 30f;

		private const float Radius = 12f;

		private MultiTargetTween _scaleTween;

		private MultiTargetTween _alphaTween;

		private Vector2 _velocity;

		private Vector2 _initialVelocity;

		private bool _cachedFlipX;

		private float _flipNum;

		private Timer _expireTimer;

		protected virtual string FrameName => null;

		protected virtual bool IsEvolution => false;

		protected virtual bool WrapX => false;

		protected virtual bool WrapY => false;

		protected override void Awake()
		{
		}

		public override void InitProjectile(BulletPool pool, Weapon weapon, int index)
		{
		}

		protected override void OnUpdate()
		{
		}

		private void CheckForDespawn()
		{
		}

		private void CheckForScreenWrapping()
		{
		}

		private void UpdateBody()
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

		protected override void OnHasHitAnotherPlayerObject(IDamageable other)
		{
		}

		private void OnHasHitAnObjectLogic(IDamageable other, bool triggerHit)
		{
		}
	}
}
