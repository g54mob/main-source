using UnityEngine;
using VampireSurvivors.Data;
using VampireSurvivors.Framework.Phaser;
using VampireSurvivors.Interfaces;
using VampireSurvivors.Objects.Characters;
using VampireSurvivors.Objects.Pools;
using VampireSurvivors.Objects.Projectiles;

namespace VampireSurvivors.Objects.Weapons
{
	public class TP_Acid2_Weapon : FB_QuantisedAngleWeapon
	{
		private IDamageable _targetDamagable;

		private bool _hasGemini;

		private TP_Acid1_Weapon _acid1Weapon;

		private PhaserSprite _cursor;

		private float _cursorAngle;

		private float _angleUnit;

		private float _targetAngle;

		private float _mul;

		private bool _cooldownAffectedByMovement;

		private bool _isStandalone;

		public virtual bool IsPrimaryWeapon => false;

		public virtual float PlayerFacing => 0f;

		private PhaserSprite CursorToUse1 => null;

		private PhaserSprite CursorToUse2 => null;

		public override void InitWeapon(VampireSurvivors.Objects.Characters.CharacterController characterController, WeaponType weaponType)
		{
		}

		public override void InternalUpdate()
		{
		}

		public override Projectile FireOneProjectile(Vector2 pos, int index, Transform target = null, BulletPool pool = null)
		{
			return null;
		}

		private void UpdateTargeting()
		{
		}

		public override void Fire(bool skipTriggers = false)
		{
		}

		public void FireProjectiles(Vector2 pos)
		{
		}

		public override void CheckArcanas()
		{
		}

		private float Approach(float start, float end, float shift)
		{
			return 0f;
		}

		private void DisplayCursorVFX(int _times, float _duration)
		{
		}

		public override void SetVisible(bool visible)
		{
		}
	}
}
