using Unity.Mathematics;
using UnityEngine;
using VampireSurvivors.Framework.TimerSystem;
using VampireSurvivors.Interfaces;
using VampireSurvivors.Objects.Pools;
using VampireSurvivors.Objects.Weapons;

namespace VampireSurvivors.Objects.Projectiles
{
	public class EME_PunchProjectile_Firefist : Projectile
	{
		[SerializeField]
		private ParticleSystem firefistVFX;

		[SerializeField]
		private ParticleEventCall firefistVFXparticleEventCall;

		private const float VFXDuration = 2000f;

		private float height;

		private Vector3 _firefistPillarScale;

		private float2 _bodySize;

		private float2 _bodyOffset;

		private Timer _bodyTimer;

		private Timer _expireTimer;

		protected override void Awake()
		{
		}

		public override void InitProjectile(BulletPool pool, Weapon weapon, int index)
		{
		}

		private void SetupMechanics()
		{
		}

		private void SetupVFX()
		{
		}

		public override void InternalUpdate()
		{
		}

		private void UpdateBody()
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

		protected override void OnHasHitAnObject(IDamageable other)
		{
		}
	}
}
