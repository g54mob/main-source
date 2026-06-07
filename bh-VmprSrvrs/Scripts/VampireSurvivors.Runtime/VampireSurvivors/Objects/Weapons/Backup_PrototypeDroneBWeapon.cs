using VampireSurvivors.Data;
using VampireSurvivors.Objects.Characters;
using VampireSurvivors.Objects.Pools;

namespace VampireSurvivors.Objects.Weapons
{
	public class Backup_PrototypeDroneBWeapon : FB_RapidFireWeapon
	{
		private BulletPool _planeBulletPool;

		public override void InitWeapon(CharacterController characterController, WeaponType weaponType)
		{
		}

		public override void Cleanup()
		{
		}
	}
}
