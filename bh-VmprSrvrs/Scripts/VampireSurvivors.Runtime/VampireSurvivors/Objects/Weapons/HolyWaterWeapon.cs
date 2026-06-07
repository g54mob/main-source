using System.Collections.Generic;
using VampireSurvivors.Data;
using VampireSurvivors.Objects.Characters;

namespace VampireSurvivors.Objects.Weapons
{
	public class HolyWaterWeapon : Weapon
	{
		private readonly List<float> _targetAngles;

		private readonly List<float> _targetRadii;

		private int _lasAngleIndex;

		private int _lastRadiusIndex;

		private const int MaxAngles = 12;

		private float _mul;

		private bool _cooldownAffectedByMovement;

		public override void InitWeapon(CharacterController characterController, WeaponType weaponType)
		{
		}

		public override void CheckArcanas()
		{
		}

		public override void InternalUpdate()
		{
		}

		public override bool LevelUp()
		{
			return false;
		}

		public float GetAngle()
		{
			return 0f;
		}

		public float GetRadius()
		{
			return 0f;
		}

		public override float PPower()
		{
			return 0f;
		}

		public override void ResetFiringTimer()
		{
		}
	}
}
