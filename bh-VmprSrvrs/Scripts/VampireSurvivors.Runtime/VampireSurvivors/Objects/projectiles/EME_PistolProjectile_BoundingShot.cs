using System.Collections.Generic;
using UnityEngine;
using VampireSurvivors.Framework.TimerSystem;
using VampireSurvivors.Interfaces;
using VampireSurvivors.Objects.Pools;
using VampireSurvivors.Objects.Weapons;

namespace VampireSurvivors.Objects.Projectiles
{
	public class EME_PistolProjectile_BoundingShot : Projectile
	{
		[SerializeField]
		private ParticleSystem boundingShotVFX;

		[SerializeField]
		private ParticleEventCall boundingShotParticleEventCall;

		private readonly List<int> _targetAngles;

		private Timer _expireTimer;

		private Timer _despawnTimer;

		private float _saveVelX;

		private float _saveVelY;

		private EME_Pistol1Weapon _trueWeapon;

		private Timer _bounceTimer;

		private bool _canBounce;

		protected override void Awake()
		{
		}

		public override void InitProjectile(BulletPool pool, Weapon weapon, int index)
		{
		}

		private void SetupMechanics()
		{
		}

		private void SetupVisuals()
		{
		}

		public override void SetTarget(Transform target)
		{
		}

		public override void InternalUpdate()
		{
		}

		private void Bounce(Body b, bool up, bool down, bool left, bool right)
		{
		}

		protected override void OnHasHitAnObject(IDamageable other)
		{
		}

		public override void OnHasHitWallPhaser(PhaserTile tile)
		{
		}

		private void StartDespawn()
		{
		}

		public override void Despawn()
		{
		}

		private void DespawnAfterParticlesStopped()
		{
		}

		private void FinishDespawn()
		{
		}
	}
}
