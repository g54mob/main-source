using System.Collections.Generic;
using UnityEngine;
using VampireSurvivors.Objects.Pools;
using VampireSurvivors.Objects.Projectiles;

namespace VampireSurvivors.Objects.Weapons
{
	public class TP_Shuriken_Weapon : FB_QuantisedAngleWeapon
	{
		private float _amount;

		private List<float> _shuffledIndexes;

		public override float QuantisationStep => 0f;

		public override void Fire(bool skipTriggers = false)
		{
		}

		public override Projectile FireOneProjectile(Vector2 pos, int index, Transform target = null, BulletPool pool = null)
		{
			return null;
		}

		public override void CheckArcanas()
		{
		}

		protected override FiringAnimation GetFiringAnimation()
		{
			return default(FiringAnimation);
		}

		private void GenerateShuffleIndexes(float amount)
		{
		}
	}
}
