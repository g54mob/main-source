using UnityEngine;
using VampireSurvivors.Objects.Pools;

namespace VampireSurvivors.Objects.Weapons
{
	public class TP_HolyWhip1_Weapon : TP_WhipCore1_Weapon
	{
		protected BulletPool _smokePool;

		protected override void Awake()
		{
		}

		public void FireSmokeProjectiles(Vector2 pos)
		{
		}

		protected override void OnDestroy()
		{
		}

		public override void Cleanup()
		{
		}

		public override void CheckArcanas()
		{
		}

		protected override FiringAnimation GetFiringAnimation()
		{
			return default(FiringAnimation);
		}
	}
}
