using UnityEngine;
using VampireSurvivors.Interfaces;

namespace VampireSurvivors.Objects.Weapons
{
	public class TrainHazardWeapon : Weapon
	{
		private Vector2 location;

		private float trainPixelSize;

		public override float PPower()
		{
			return 0f;
		}

		public void FireFrom(Vector2 from, bool skipTriggers = false)
		{
		}

		public override void Fire(bool skipTriggers = false)
		{
		}

		public override void ResetFiringTimer()
		{
		}

		public override void DealDamage(IDamageable other, float damage)
		{
		}
	}
}
