using Unity.Mathematics;
using VampireSurvivors.Data;
using VampireSurvivors.Objects.Characters;
using VampireSurvivors.Objects.Pools;
using VampireSurvivors.Objects.Projectiles;

namespace VampireSurvivors.Objects.Weapons
{
	public class TP_StarFlail2_Weapon : Weapon
	{
		private BulletPool _bladePool;

		private BulletPool _swipeBodyPool;

		public override float PPower()
		{
			return 0f;
		}

		public override void InitWeapon(CharacterController characterController, WeaponType weaponType)
		{
		}

		protected override FiringAnimation GetFiringAnimation()
		{
			return default(FiringAnimation);
		}

		public override void Fire(bool skipTriggers = false)
		{
		}

		public TP_StarFlail2_Blade_Projectile SpawnBladeAt(float2 pos, int enemiesHit = 0, int damage = 1, float area = 1f)
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
