using Unity.Mathematics;
using VampireSurvivors.Data;
using VampireSurvivors.Objects.Pools;
using VampireSurvivors.Objects.Projectiles;

namespace VampireSurvivors.Objects.Weapons
{
	public class TP_WhipCore1_Weapon : Weapon
	{
		protected WeaponType _weaponNodeType;

		protected BulletPool _nodePool;

		protected int _fireCounter;

		protected int _specialCounter;

		protected int _subWeaponCounter;

		public override void Fire(bool skipTriggers = false)
		{
		}

		public virtual void OnSpecialCounter(bool skipTriggers = false)
		{
		}

		public virtual void OnSubWeaponCounter(bool skipTriggers = false)
		{
		}

		public Projectile CreateNodeProjectile(float2 pos, int enemiesHit = 0, int damage = 1, float area = 1f)
		{
			return null;
		}

		protected override void OnDestroy()
		{
		}

		public override void Cleanup()
		{
		}
	}
}
