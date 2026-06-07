using Unity.Mathematics;
using VampireSurvivors.Data;
using VampireSurvivors.Objects.Characters;
using VampireSurvivors.Objects.Pools;
using VampireSurvivors.Objects.Projectiles;

namespace VampireSurvivors.Objects.Weapons
{
	public class TP_Chauve2_Weapon : TP_Chauve1_Weapon
	{
		private BulletPool _beamPool;

		private const float _shootTimeMillis = 250f;

		public float ShootTimeMillis => 0f;

		public override void InitWeapon(CharacterController characterController, WeaponType weaponType)
		{
		}

		public Projectile SpawnBeamAt(float2 pos, int enemiesHit = 0, int damage = 1, float area = 1f)
		{
			return null;
		}

		protected override bool OnBulletOverlapsEnemy(CallbackContext context, ArcadeColliderType second, ArcadeColliderType first)
		{
			return false;
		}

		private bool OnBeamOverlapsEnemy(CallbackContext context, ArcadeColliderType second, ArcadeColliderType first)
		{
			return false;
		}

		private void DealCritDamage(EnemyController target)
		{
		}
	}
}
