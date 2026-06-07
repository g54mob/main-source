using System;
using UnityEngine;
using VampireSurvivors.Data;
using VampireSurvivors.Framework.TimerSystem;
using VampireSurvivors.Objects.Characters;
using VampireSurvivors.Objects.Pools;
using VampireSurvivors.Objects.Projectiles;

namespace VampireSurvivors.Objects.Weapons
{
	public class TP_Mace2_Weapon : Weapon
	{
		[NonSerialized]
		public bool isCrit;

		[NonSerialized]
		public int ExtraBodyAmount;

		private float maxCooldownOffset;

		private float cooldownOffset;

		private Timer _freezeTimer;

		private bool _canFreeze;

		private BulletPool _invisPool;

		private BulletPool _critPool;

		private BulletPool _standardPool;

		protected override FiringAnimation GetFiringAnimation()
		{
			return default(FiringAnimation);
		}

		public override void InitWeapon(VampireSurvivors.Objects.Characters.CharacterController characterController, WeaponType weaponType)
		{
		}

		public override void Fire(bool skipTriggers = false)
		{
		}

		protected override void OnUpdate()
		{
		}

		public override float PInterval()
		{
			return 0f;
		}

		protected bool OnCriticalBulletOverlapsEnemy(CallbackContext context, ArcadeColliderType second, ArcadeColliderType first)
		{
			return false;
		}

		public void ShowBigDamage(float value, Vector3 position)
		{
		}

		public bool FrameFreeze()
		{
			return false;
		}

		public Projectile CreateStandardProjectile(int index)
		{
			return null;
		}

		public Projectile CreateCriticalProjectile(int index)
		{
			return null;
		}

		protected override void OnDestroy()
		{
		}
	}
}
