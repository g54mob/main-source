using UnityEngine;

namespace VampireSurvivors.Objects.Weapons
{
	public class TP_SonicWhip1_Weapon : TP_WhipCore1_Weapon
	{
		protected override void Awake()
		{
		}

		public override float PDuration()
		{
			return 0f;
		}

		public override void Fire(bool skipTriggers = false)
		{
		}

		public override void CheckArcanas()
		{
		}

		protected override bool OnBulletOverlapsEnemy(CallbackContext context, ArcadeColliderType second, ArcadeColliderType first)
		{
			return false;
		}

		protected bool IsInstaKill()
		{
			return false;
		}

		protected void ShowBigDamage(float value, Vector3 position)
		{
		}

		protected override FiringAnimation GetFiringAnimation()
		{
			return default(FiringAnimation);
		}
	}
}
