using UnityEngine;
using VampireSurvivors.Data;
using VampireSurvivors.Framework.TimerSystem;
using VampireSurvivors.Graphics;
using VampireSurvivors.Objects.Characters;

namespace VampireSurvivors.Objects.Weapons
{
	public class Tongue2Weapon : TongueWeapon
	{
		[SerializeField]
		private SpriteRenderer _assassinationSprite;

		[SerializeField]
		private SpriteAnimation _assassinationAnim;

		private Timer _specialAttackTimer;

		private float _lastSpecialDelay;

		private float _specialDelay;

		protected SfxType[] s_sounds;

		protected override void Awake()
		{
		}

		public override void InitWeapon(VampireSurvivors.Objects.Characters.CharacterController characterController, WeaponType weaponType)
		{
		}

		private void OnSlashAnimComplete()
		{
		}

		private float GetSpecialDelay()
		{
			return 0f;
		}

		private void ResetSpecialAttackTimer()
		{
		}

		private EnemyController GetMostDistantStrongestEnemy()
		{
			return null;
		}

		private void DoSpecialAttack()
		{
		}

		protected void Assassinate(EnemyController target, float previousTargetScale)
		{
		}

		protected override bool CanLickBackwards()
		{
			return false;
		}

		protected override bool SupportCounterWeapon()
		{
			return false;
		}

		protected override bool OnBulletOverlapsEnemy(CallbackContext context, ArcadeColliderType second, ArcadeColliderType first)
		{
			return false;
		}

		public override void CheckArcanas()
		{
		}
	}
}
