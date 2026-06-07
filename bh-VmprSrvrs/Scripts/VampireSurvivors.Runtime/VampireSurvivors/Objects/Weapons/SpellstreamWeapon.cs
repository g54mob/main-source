using System.Collections.Generic;
using UnityEngine;
using VampireSurvivors.Data;
using VampireSurvivors.Objects.Characters;

namespace VampireSurvivors.Objects.Weapons
{
	public class SpellstreamWeapon : Weapon
	{
		private int _sourceIndex;

		private List<Vector3> _sources;

		public override void InitWeapon(VampireSurvivors.Objects.Characters.CharacterController characterController, WeaponType weaponType)
		{
		}

		private void SetSources(List<Vector3> array)
		{
		}

		private Vector3 GetSource()
		{
			return default(Vector3);
		}

		public override float PPower()
		{
			return 0f;
		}

		public override void Fire(bool skipTriggers = false)
		{
		}
	}
}
