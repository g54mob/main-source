using DG.Tweening;
using UnityEngine;
using VampireSurvivors.Data;
using VampireSurvivors.Objects.Characters;

namespace VampireSurvivors.Objects.Weapons
{
	public class ColdExplosionWeapon : Weapon
	{
		public bool _DoesRetaliate;

		private bool _canExplode;

		private Tween _explodeTimer;

		public override float PPower()
		{
			return 0f;
		}

		public override void InitWeapon(VampireSurvivors.Objects.Characters.CharacterController characterController, WeaponType weaponType)
		{
		}

		public override void ResetFiringTimer()
		{
		}

		public void ExplodeAt(Vector2 position, bool ignoreCooldown = false)
		{
		}
	}
}
