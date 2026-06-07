using System;
using System.Collections.Generic;
using Sirenix.OdinInspector;
using UnityEngine;
using VampireSurvivors.App.Tools;
using VampireSurvivors.Data;
using VampireSurvivors.Framework.Validation;
using VampireSurvivors.Objects.Projectiles;

namespace VampireSurvivors.Framework
{
	[CreateAssetMenu(fileName = "ProjectileFactory", menuName = "VampireSurvivors/New ProjectileFactory")]
	public class ProjectileFactory : SerializedScriptableObject, IValidateReferences
	{
		[Serializable]
		public class ProjectilesDictionary : UnitySerializedDictionary<WeaponType, Projectile>
		{
		}

		[SerializeField]
		private ProjectilesDictionary _Projectiles;

		[SerializeField]
		private List<ProjectileFactory> _LinkedFactories;

		public Projectile GetProjectilePrefab(WeaponType weaponType)
		{
			return null;
		}

		public List<string> ValidateReferences()
		{
			return null;
		}
	}
}
