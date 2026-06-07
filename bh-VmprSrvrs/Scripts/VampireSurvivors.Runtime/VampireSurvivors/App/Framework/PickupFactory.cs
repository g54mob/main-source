using System;
using System.Collections.Generic;
using QFSW.MOP2;
using Sirenix.OdinInspector;
using UnityEngine;
using UnityEngine.AddressableAssets;
using VampireSurvivors.App.Tools;
using VampireSurvivors.Data;
using VampireSurvivors.Framework.Validation;

namespace VampireSurvivors.App.Framework
{
	[CreateAssetMenu(fileName = "PickupFactory", menuName = "VampireSurvivors/New PickupFactory")]
	public class PickupFactory : SerializedScriptableObject, IValidateReferences
	{
		[Serializable]
		public class PickupsDictionary : UnitySerializedDictionary<ItemType, GameObject>
		{
		}

		[Serializable]
		public class PickupRefsDictionary : UnitySerializedDictionary<ItemType, PrefabRefData>
		{
		}

		[Serializable]
		public class PrefabRefData
		{
			[SerializeField]
			private AssetReferenceT<GameObject> _PrefabRef;

			public AssetReferenceT<GameObject> PrefabRef
			{
				get
				{
					return null;
				}
				set
				{
				}
			}
		}

		[SerializeField]
		private PickupsDictionary _Pickups;

		[SerializeField]
		private PickupRefsDictionary _PickupRefs;

		[SerializeField]
		private List<PickupFactory> _LinkedFactories;

		private readonly Dictionary<ItemType, ObjectPool> _cachedPools;

		public void GeneratePools()
		{
		}

		public ObjectPool GetPool(ItemType itemType)
		{
			return null;
		}

		public void PurgePools()
		{
		}

		private void GeneratePool(ItemType itemType, GameObject prefab, int poolSize = 50)
		{
		}

		private void MergeFactoryAndGenerate(PickupFactory other, DlcType? dlcType)
		{
		}

		public List<string> ValidateReferences()
		{
			return null;
		}
	}
}
