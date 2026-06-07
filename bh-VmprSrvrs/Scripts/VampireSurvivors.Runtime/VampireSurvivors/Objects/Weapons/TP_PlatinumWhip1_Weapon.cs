using UnityEngine;
using VampireSurvivors.Objects.Pools;
using VampireSurvivors.Objects.Projectiles;

namespace VampireSurvivors.Objects.Weapons
{
	public class TP_PlatinumWhip1_Weapon : Weapon
	{
		[SerializeField]
		private Projectile _memoryWhipPrefab;

		protected int _fireCounter;

		protected int _specialCounter;

		protected int _subWeaponCounter;

		private BulletPool _memoryWhipPool;

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

		public override void Cleanup()
		{
		}

		public override void CheckArcanas()
		{
		}
	}
}
