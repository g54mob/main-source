using Unity.Profiling;
using UnityEngine;
using VampireSurvivors.Framework.Particles;
using VampireSurvivors.Interfaces;
using VampireSurvivors.Objects.Pools;
using VampireSurvivors.Objects.Weapons;

namespace VampireSurvivors.Objects.Projectiles
{
	public class MagicMissileProjectile : Projectile
	{
		[SerializeField]
		private float _IndexOffsetScaleFactor;

		private ParticleEmitterManager _pfxManager;

		private ParticleSystem _pfx;

		private MagicMissileWeapon _trueWeapon;

		private static readonly ProfilerMarker _markerInitProjectile;

		public override void InitProjectile(BulletPool pool, Weapon weapon, int index)
		{
		}

		private void GenerateParticleSystem()
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

		public override void InternalUpdate()
		{
		}
	}
}
