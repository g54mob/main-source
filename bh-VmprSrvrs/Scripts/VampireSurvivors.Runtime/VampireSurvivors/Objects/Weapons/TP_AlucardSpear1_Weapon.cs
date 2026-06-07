using VampireSurvivors.Data;
using VampireSurvivors.Objects.Characters;
using VampireSurvivors.Objects.Pools;
using VampireSurvivors.Objects.Projectiles;

namespace VampireSurvivors.Objects.Weapons
{
	public class TP_AlucardSpear1_Weapon : Weapon
	{
		private BulletPool _pommelPool;

		public override void InitWeapon(CharacterController characterController, WeaponType weaponType)
		{
		}

		protected override void OnStart()
		{
		}

		public Projectile CreatePommelProjectile(int index)
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
