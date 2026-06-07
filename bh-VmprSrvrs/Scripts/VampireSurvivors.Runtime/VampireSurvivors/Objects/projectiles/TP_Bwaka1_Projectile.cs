using UnityEngine;
using VampireSurvivors.Framework.TimerSystem;
using VampireSurvivors.Interfaces;
using VampireSurvivors.Objects.Pools;
using VampireSurvivors.Objects.Weapons;

namespace VampireSurvivors.Objects.Projectiles
{
	public class TP_Bwaka1_Projectile : Projectile
	{
		private float _deltaTime;

		private const float _orbitPercentage = 0.125f;

		private const float _orbitModifier = 75f;

		private const float _rotationModifier = 360f;

		private Vector3 _centralPos;

		private Vector3 _velocity;

		private float _rotationInc;

		private float _flipSwitch;

		private bool _cachedFlipX;

		private Timer _durationTimer;

		private Timer _bodyTimer;

		private const float _bodyDisableDuration = 250f;

		protected virtual string FrameName => null;

		protected virtual bool InfiniteBounces => false;

		protected virtual float Radius => 0f;

		protected virtual float OrbitRadius => 0f;

		protected override void Awake()
		{
		}

		public override void InitProjectile(BulletPool pool, Weapon weapon, int index)
		{
		}

		public override void InternalUpdate()
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

		protected void OnHasHitAnObjectLogic(IDamageable other, bool triggerHit)
		{
		}

		private void OnBounce()
		{
		}
	}
}
