using DG.Tweening;
using UnityEngine;
using VampireSurvivors.Framework.TimerSystem;
using VampireSurvivors.Interfaces;
using VampireSurvivors.Objects.Pools;
using VampireSurvivors.Objects.Weapons;

namespace VampireSurvivors.Objects.Projectiles
{
	public class TP_Pocket1_Projectile : Projectile
	{
		[SerializeField]
		private TrailRenderer _Trail;

		private const float Radius = 8f;

		private Timer _expireTimer;

		private Tween _scaleTween;

		protected override void Awake()
		{
		}

		public override void InitProjectile(BulletPool pool, Weapon weapon, int index)
		{
		}

		private void InitAiming()
		{
		}

		private void StartTimers()
		{
		}

		private void SetupTrail()
		{
		}

		protected override void OnHasHitAnObject(IDamageable other)
		{
		}

		protected override void OnHasHitAnotherPlayerObject(IDamageable other)
		{
		}

		protected void OnHasHitAnObjectLogic(IDamageable other, bool triggerHit)
		{
		}

		private void StartDespawn()
		{
		}

		public override void Despawn()
		{
		}
	}
}
