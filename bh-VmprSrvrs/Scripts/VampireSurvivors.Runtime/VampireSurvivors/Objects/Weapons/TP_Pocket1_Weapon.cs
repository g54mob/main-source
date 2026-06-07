using UnityEngine;

namespace VampireSurvivors.Objects.Weapons
{
	public class TP_Pocket1_Weapon : Weapon
	{
		private const float BaseOffsetY = 0.16f;

		protected override FiringAnimation GetFiringAnimation()
		{
			return default(FiringAnimation);
		}

		public override void Fire(bool skipTriggers = false)
		{
		}

		private Vector2 GetProjectilePosition(float offsetPos)
		{
			return default(Vector2);
		}

		public override void CheckArcanas()
		{
		}
	}
}
