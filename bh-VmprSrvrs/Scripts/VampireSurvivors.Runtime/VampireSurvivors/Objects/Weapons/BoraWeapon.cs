using System.Collections.Generic;
using UnityEngine;
using VampireSurvivors.Data;
using VampireSurvivors.Objects.Characters;

namespace VampireSurvivors.Objects.Weapons
{
	public class BoraWeapon : Weapon
	{
		private Camera _camera;

		private List<Vector2> _targetPoints;

		private int _lastRadiusIndex;

		private const int MaxAngles = 12;

		private bool _cooldownAffectedByMovement;

		private const float Mul = 333.33334f;

		public override void InitWeapon(VampireSurvivors.Objects.Characters.CharacterController characterController, WeaponType weaponType)
		{
		}

		public Vector2 GetTargetPoint()
		{
			return default(Vector2);
		}

		public override void InternalUpdate()
		{
		}

		public override void ResetFiringTimer()
		{
		}

		public override void CheckArcanas()
		{
		}
	}
}
