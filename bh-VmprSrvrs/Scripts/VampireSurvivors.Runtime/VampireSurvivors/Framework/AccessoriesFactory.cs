using System;
using System.Collections.Generic;
using Sirenix.OdinInspector;
using UnityEngine;
using VampireSurvivors.App.Tools;
using VampireSurvivors.Data;
using VampireSurvivors.Framework.Validation;
using VampireSurvivors.Objects;

namespace VampireSurvivors.Framework
{
	[CreateAssetMenu(fileName = "AccessoriesFactory", menuName = "VampireSurvivors/New AccessoriesFactory")]
	public class AccessoriesFactory : SerializedScriptableObject, IValidateReferences
	{
		[Serializable]
		public class AccessoryDictionary : UnitySerializedDictionary<WeaponType, Accessory>
		{
		}

		[SerializeField]
		private AccessoryDictionary _accessories;

		[SerializeField]
		private Accessory _defaultAccessory;

		[SerializeField]
		private List<AccessoriesFactory> _LinkedFactories;

		public Accessory GetAccessoryPrefab(WeaponType accessoryType)
		{
			return null;
		}

		public List<string> ValidateReferences()
		{
			return null;
		}
	}
}
