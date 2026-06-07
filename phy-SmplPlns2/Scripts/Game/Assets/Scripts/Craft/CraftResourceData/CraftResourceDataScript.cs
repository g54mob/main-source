using System;
using Assets.Scripts.Craft.Parts.Modifiers;
using Assets.Scripts.Craft.Parts.Modifiers.Propulsion.Jet;
using Assets.Scripts.Craft.Parts.Modifiers.Propulsion.Propeller;
using Assets.Scripts.Craft.Parts.Modifiers.Weapons;
using Assets.Scripts.Storage;
using UnityEngine;

namespace Assets.Scripts.Craft.CraftResourceData
{
	public class CraftResourceDataScript : MonoBehaviour
	{
		[field: SerializeField]
		public JetEnginePrefabs JetEnginePrefabs { get; private set; }

		[field: SerializeField]
		public MissilePartPrefabs MissilePartPrefabs { get; private set; }

		[field: SerializeField]
		public PedalPrefabs PedalPrefabs { get; private set; }

		[field: SerializeField]
		public PropellerPrefabs PropellerPrefabs { get; private set; }

		[field: SerializeField]
		public WheelPrefabs WheelPrefabs { get; private set; }

		public static CraftResourceDataScript Create(GameObject root, IResourceLoader resourceLoader)
		{
			if (resourceLoader.InstantiatePrefab("Craft/CraftResourceData/CraftResourceData", root.transform).TryGetComponent<CraftResourceDataScript>(out var component))
			{
				component.WheelPrefabs.Initialize();
				component.PropellerPrefabs.Initialize();
				component.MissilePartPrefabs.Initialize();
				component.JetEnginePrefabs.Initialize();
				component.PedalPrefabs.Initialize();
				return component;
			}
			throw new Exception("CraftResourceData prefab is missing CraftResourceData script.");
		}
	}
}
