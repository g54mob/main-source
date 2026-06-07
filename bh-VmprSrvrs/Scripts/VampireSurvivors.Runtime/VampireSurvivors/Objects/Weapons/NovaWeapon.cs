using UnityEngine;
using VampireSurvivors.Data;
using VampireSurvivors.Objects.Pools;
using VampireSurvivors.Objects.Projectiles;

namespace VampireSurvivors.Objects.Weapons
{
	public class NovaWeapon : Weapon
	{
		[SerializeField]
		private Color _projectileColor;

		[SerializeField]
		private WeaponType _novaExplosionType;

		private uint _convertedColor;

		protected override void OnStart()
		{
		}

		public override void ResetFiringTimer()
		{
		}

		public override Projectile FireOneProjectile(Vector2 pos, int index, Transform target = null, BulletPool pool = null)
		{
			return null;
		}

		public uint ConvertColorToUint(Color color)
		{
			return 0u;
		}

		protected override bool OnBulletOverlapsEnemy(CallbackContext context, ArcadeColliderType second, ArcadeColliderType first)
		{
			return false;
		}
	}
}
