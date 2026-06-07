using System;
using System.Collections.Generic;
using Sirenix.OdinInspector;
using UnityEngine;
using UnityEngine.AddressableAssets;
using VampireSurvivors.App.Tools;
using VampireSurvivors.Data;
using VampireSurvivors.Framework.Validation;
using VampireSurvivors.Objects.Characters;

namespace VampireSurvivors.Framework
{
	[CreateAssetMenu(fileName = "CharacterFactory", menuName = "VampireSurvivors/New CharacterFactory")]
	public class CharacterFactory : SerializedScriptableObject, IValidateReferences
	{
		[Serializable]
		public class CharacterDictionary : UnitySerializedDictionary<CharacterType, VampireSurvivors.Objects.Characters.CharacterController>
		{
		}

		[Serializable]
		public class CharacterRefDictionary : UnitySerializedDictionary<CharacterType, PrefabRefData>
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

		[Serializable]
		public class PrefabPathData
		{
			[SerializeField]
			private string _PrefabPath;

			public string PrefabPath
			{
				get
				{
					return null;
				}
				set
				{
				}
			}

			public string PathWithoutExtension => null;

			public string PathWithExtension => null;
		}

		[SerializeField]
		private CharacterDictionary _characters;

		[SerializeField]
		private VampireSurvivors.Objects.Characters.CharacterController _defaultCharacterController;

		[SerializeField]
		private CharacterRefDictionary _CharacterRefs;

		[SerializeField]
		private List<CharacterFactory> _LinkedFactories;

		public VampireSurvivors.Objects.Characters.CharacterController GetCharacterPrefab(CharacterType characterType)
		{
			return null;
		}

		public bool ContainsCharacter(CharacterType characterType)
		{
			return false;
		}

		public List<string> ValidateReferences()
		{
			return null;
		}
	}
}
