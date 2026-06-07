using System;
using VampireSurvivors.Data;
using VampireSurvivors.Objects.Characters;
using VampireSurvivors.Objects.Pools;

namespace VampireSurvivors.Objects.Weapons
{
	public class HatWeapon : Weapon
	{
		[NonSerialized]
		public int MaxHats;

		[NonSerialized]
		public int DragogionRand;

		private BulletPool _explosionPool;

		public override void InitWeapon(CharacterController characterController, WeaponType weaponType)
		{
		}

		public override void Fire(bool skipTriggers = false)
		{
		}

		public float throwInterval()
		{
			return 0f;
		}

		public void ExplodeAt(float x, float y, int index)
		{
		}

		public override void Cleanup()
		{
		}

		public override void CheckArcanas()
		{
		}
	}
}
