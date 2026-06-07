using UnityEngine;
using VampireSurvivors.Data;
using VampireSurvivors.Objects.Characters;

namespace VampireSurvivors.Objects.Weapons
{
	public class TP_Heads_Weapon : TP_Clockwork_Weapon
	{
		private Transform _cachedCameraTransform;

		private Vector2 _leftOffset;

		private Vector2 _rightOffset;

		public override void InitWeapon(VampireSurvivors.Objects.Characters.CharacterController characterController, WeaponType weaponType)
		{
		}

		public override void FireProjectiles(Vector2 pos)
		{
		}
	}
}
