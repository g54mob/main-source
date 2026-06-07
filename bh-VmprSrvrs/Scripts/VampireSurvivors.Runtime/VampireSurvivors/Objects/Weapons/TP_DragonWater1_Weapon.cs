using Unity.Mathematics;
using UnityEngine;
using VampireSurvivors.Objects.Pools;
using VampireSurvivors.Objects.Projectiles;

namespace VampireSurvivors.Objects.Weapons
{
	public class TP_DragonWater1_Weapon : Weapon
	{
		[SerializeField]
		private Projectile _waterDragonHeadPrefab;

		[SerializeField]
		private Projectile _waterDragonTailPrefab;

		protected int _fireCounter;

		protected int _specialCounter;

		protected int _subWeaponCounter;

		private BulletPool _memoryWhipPool;

		private BulletPool _tailPool;

		protected override FiringAnimation GetFiringAnimation()
		{
			return default(FiringAnimation);
		}

		protected override void OnStart()
		{
		}

		public override void Fire(bool skipTriggers = false)
		{
		}

		public virtual void OnSpecialCounter(bool skipTriggers = false)
		{
		}

		public virtual void OnSubWeaponCounter(bool skipTriggers = false)
		{
		}

		public Projectile SpawnTailProjectile(float2 pos, int index)
		{
			return null;
		}

		public override void Cleanup()
		{
		}

		public override void CheckArcanas()
		{
		}
	}
}
