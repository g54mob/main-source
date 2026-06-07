using UnityEngine;
using VampireSurvivors.Data;
using VampireSurvivors.Framework.TimerSystem;
using VampireSurvivors.Objects.Characters;
using VampireSurvivors.Objects.Projectiles;

namespace VampireSurvivors.Objects.Weapons
{
	public class FlashArrowWeapon : Weapon, IMillionaire
	{
		private Timer _rangedAnimEvent;

		public override float PPower()
		{
			return 0f;
		}

		public override void InitWeapon(VampireSurvivors.Objects.Characters.CharacterController characterController, WeaponType weaponType)
		{
		}

		protected override void OnStart()
		{
		}

		public void PlayNextRangedAnim()
		{
		}

		public override void Fire(bool skipTriggers = false)
		{
		}

		public void Millionaire(float x, float y, float angle, int times = 4)
		{
		}

		public override void CheckArcanas()
		{
		}

		protected override bool OnBulletOverlapsEnemy(CallbackContext context, ArcadeColliderType second, ArcadeColliderType first)
		{
			return false;
		}

		public override void Cleanup()
		{
		}

		public void FireVolley(Vector2 pos, int _amount, Transform target = null)
		{
		}
	}
}
