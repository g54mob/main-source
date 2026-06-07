using System.Collections.Generic;
using UnityEngine;
using VampireSurvivors.Data;
using VampireSurvivors.Objects.Characters;

namespace VampireSurvivors.Objects.Weapons
{
	public class SpellstringWeapon : Weapon
	{
		private float _range;

		private int _sourceIndex;

		private float _maxSources;

		private List<Transform> _sources;

		public override void InitWeapon(VampireSurvivors.Objects.Characters.CharacterController characterController, WeaponType weaponType)
		{
		}

		public void SetSources(List<Transform> array)
		{
		}

		public override float PPower()
		{
			return 0f;
		}

		public override void Fire(bool skipTriggers = false)
		{
		}

		public override void SetVisible(bool visible)
		{
		}

		private Transform GetSource()
		{
			return null;
		}
	}
}
