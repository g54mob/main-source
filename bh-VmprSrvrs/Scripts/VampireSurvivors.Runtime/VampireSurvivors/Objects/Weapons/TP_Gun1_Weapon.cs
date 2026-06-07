using UnityEngine;
using VampireSurvivors.Data;
using VampireSurvivors.Framework.TimerSystem;
using VampireSurvivors.Objects.Characters;
using VampireSurvivors.Objects.Pools;
using VampireSurvivors.Objects.Projectiles;

namespace VampireSurvivors.Objects.Weapons
{
	public class TP_Gun1_Weapon : Weapon
	{
		[SerializeField]
		private Projectile _shrapnelPrefab;

		protected BulletPool _shrapnelPool;

		protected BulletPool _gunPool;

		protected Timer _throwTimer;

		protected int _bulletCounter;

		public override void InitWeapon(VampireSurvivors.Objects.Characters.CharacterController characterController, WeaponType weaponType)
		{
		}

		public override void Fire(bool skipTriggers = false)
		{
		}

		public override void Cleanup()
		{
		}

		public virtual void FireShrapnel(Vector2 position, Vector2 velocity, float pAngle = 0f)
		{
		}

		protected override void OnDestroy()
		{
		}
	}
}
