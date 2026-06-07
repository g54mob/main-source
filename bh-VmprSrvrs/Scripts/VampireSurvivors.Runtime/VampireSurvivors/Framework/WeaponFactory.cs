using System;
using System.Collections.Generic;
using Sirenix.OdinInspector;
using UnityEngine;
using VampireSurvivors.App.Tools;
using VampireSurvivors.Data;
using VampireSurvivors.Framework.Validation;
using VampireSurvivors.Objects.Weapons;

namespace VampireSurvivors.Framework
{
	[CreateAssetMenu(fileName = "WeaponFactory", menuName = "VampireSurvivors/New WeaponFactory")]
	public class WeaponFactory : SerializedScriptableObject, IValidateReferences
	{
		[Serializable]
		public class WeaponsDictionary : UnitySerializedDictionary<WeaponType, Weapon>
		{
		}

		[SerializeField]
		private WeaponsDictionary _weapons;

		[SerializeField]
		private List<WeaponFactory> _LinkedFactories;

		public Weapon GetWeaponPrefab(WeaponType weaponType, out WeaponType forcedWeaponType)
		{
			forcedWeaponType = default(WeaponType);
			return null;
		}

		public List<string> ValidateReferences()
		{
			return null;
		}
	}
}
