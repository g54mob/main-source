using System;
using JetBrains.Annotations;
using Sirenix.OdinInspector;
using UnityEngine;
using UnityEngine.AddressableAssets;
using VampireSurvivors.App.Tools;

namespace VampireSurvivors.Framework
{
	[CreateAssetMenu(fileName = "AssetReferenceLibrary", menuName = "VampireSurvivors/New AssetReferenceLibrary")]
	public class AssetReferenceLibrary : SerializedScriptableObject
	{
		[Serializable]
		public class AssetRefsDictionary : UnitySerializedDictionary<string, PrefabRefData>
		{
		}

		[Serializable]
		public class PrefabRefData
		{
			[SerializeField]
			private AssetReference _PrefabRef;

			public AssetReference PrefabRef
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
		private AssetRefsDictionary _AssetRefs;

		[CanBeNull]
		public AssetReference GetAssetReference(string key)
		{
			return null;
		}
	}
}
