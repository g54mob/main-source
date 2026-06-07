using UnityEngine;

namespace VampireSurvivors.Objects.Weapons
{
	public class CartWeapon : Weapon
	{
		public Vector2? Location { get; set; }

		public override float PAmount()
		{
			return 0f;
		}

		public override float PPower()
		{
			return 0f;
		}

		public override float PInterval()
		{
			return 0f;
		}
	}
}
