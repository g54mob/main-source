using System;
using System.Collections.Generic;
using Sirenix.OdinInspector;
using UnityEngine;
using UnityEngine.AddressableAssets;
using VampireSurvivors.App.Tools;
using VampireSurvivors.Data;
using VampireSurvivors.Framework.Validation;

namespace VampireSurvivors.App.Framework
{
	[CreateAssetMenu(fileName = "BestiaryFactory", menuName = "VampireSurvivors/New BestiaryFactory")]
	public class BestiaryFactory : SerializedScriptableObject, IValidateReferences
	{
		[Serializable]
		public class BestiaryEnemyPoolsDictionary : UnitySerializedDictionary<EnemyType, GameObject>
		{
		}

		[Serializable]
		public class BestiaryEnemyRefDictionary : UnitySerializedDictionary<EnemyType, PrefabRefData>
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
		private BestiaryEnemyPoolsDictionary _BestiaryEnemyPools;

		[SerializeField]
		private BestiaryEnemyRefDictionary _BestiaryEnemyRefs;

		[SerializeField]
		private List<BestiaryFactory> _LinkedFactories;

		[HideInInspector]
		public string CACHE_GROUP;

		[HideInInspector]
		public string CACHE_GROUP_UI;

		public GameObject GetBestiaryEnemyPrefab(EnemyType type)
		{
			return null;
		}

		public List<string> ValidateReferences()
		{
			return null;
		}
	}
}
