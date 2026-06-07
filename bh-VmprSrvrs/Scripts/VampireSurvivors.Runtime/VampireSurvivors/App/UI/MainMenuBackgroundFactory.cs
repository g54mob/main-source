using System;
using System.Collections.Generic;
using Sirenix.OdinInspector;
using UnityEngine;
using UnityEngine.AddressableAssets;
using VampireSurvivors.App.Tools;
using VampireSurvivors.Data;
using VampireSurvivors.Framework.Validation;

namespace VampireSurvivors.App.UI
{
	[CreateAssetMenu(fileName = "MainMenuBackgroundFactory", menuName = "VampireSurvivors/New MainMenuBackgroundFactory")]
	public class MainMenuBackgroundFactory : SerializedScriptableObject, IValidateReferences
	{
		[Serializable]
		public class BackgroundDictionary : UnitySerializedDictionary<AdventureType, GameObject>
		{
		}

		[Serializable]
		public class BackgroundRefsDictionary : UnitySerializedDictionary<AdventureType, PrefabRefData>
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
		private BackgroundDictionary _Backgrounds;

		[SerializeField]
		private BackgroundRefsDictionary _BackgroundRefs;

		[SerializeField]
		private List<MainMenuBackgroundFactory> _LinkedFactories;

		private GameObject LoadFromAddressables(DlcType? dlcType, AdventureType adventureType, MainMenuBackgroundFactory factory)
		{
			return null;
		}

		public GameObject GetBackgroundForAdventureType(AdventureType adventureType)
		{
			return null;
		}

		public List<string> ValidateReferences()
		{
			return null;
		}
	}
}
