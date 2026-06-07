using System.Collections.Generic;
using UnityEngine;
using VampireSurvivors.Data;
using VampireSurvivors.Objects.Characters;

namespace VampireSurvivors.Objects.Weapons
{
	public class LarobbaWeapon : Weapon
	{
		private readonly List<float> _targetAngles;

		private int _lastAngleIndex;

		private const int MaxAngles = 12;

		private const int MaxFrames = 20;

		private int _lastRobbaIndex;

		[SerializeField]
		private List<Sprite> _robbaFrames;

		public override void CheckArcanas()
		{
		}

		public override void InitWeapon(VampireSurvivors.Objects.Characters.CharacterController characterController, WeaponType weaponType)
		{
		}

		public float GetAngle()
		{
			return 0f;
		}

		public Sprite GetRobbaFrame()
		{
			return null;
		}

		public override bool LevelUp()
		{
			return false;
		}
	}
}
