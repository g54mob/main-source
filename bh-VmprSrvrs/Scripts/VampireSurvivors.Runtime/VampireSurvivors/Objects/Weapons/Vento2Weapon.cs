using UnityEngine;
using VampireSurvivors.Data;
using VampireSurvivors.Framework.TimerSystem;
using VampireSurvivors.Objects.Characters;
using VampireSurvivors.Objects.Pools;
using VampireSurvivors.Objects.Projectiles;

namespace VampireSurvivors.Objects.Weapons
{
	public class Vento2Weapon : Weapon
	{
		private BulletPool _extraPool;

		private bool _generatedPools;

		private Timer _healTimer;

		private bool _canHeal;

		private Timer _explodeTimer;

		private bool _canExplode;

		private float _walked;

		private Timer _walkedTimer;

		private float _pBonus;

		private const float Mul = 166.66667f;

		private const float HealDelay = 500f;

		private const float ExplodeDelay = 500f;

		public override void InitWeapon(VampireSurvivors.Objects.Characters.CharacterController characterController, WeaponType weaponType)
		{
		}

		public override float PPower()
		{
			return 0f;
		}

		public override void InternalUpdate()
		{
		}

		public override void Cleanup()
		{
		}

		public override Projectile FireOneProjectile(Vector2 pos, int index, Transform target = null, BulletPool pool = null)
		{
			return null;
		}

		protected override void OnStart()
		{
		}

		public override void ResetFiringTimer()
		{
		}

		protected override bool OnBulletOverlapsEnemy(CallbackContext context, ArcadeColliderType second, ArcadeColliderType first)
		{
			return false;
		}

		protected bool OnExplosionOverlapsEnemy(CallbackContext context, ArcadeColliderType second, ArcadeColliderType first)
		{
			return false;
		}

		public override void SetVisible(bool visible)
		{
		}

		public override void CheckArcanas()
		{
		}
	}
}
