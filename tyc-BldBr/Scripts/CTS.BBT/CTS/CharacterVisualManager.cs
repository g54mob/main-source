using System;
using System.Collections.Generic;
using CTS.Core.Utilities;
using CTS.Utilities;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;

namespace CTS
{
	public static class CharacterVisualManager
	{
		private static readonly Dictionary<int, CharacterBodyDataSO> _clothes = new Dictionary<int, CharacterBodyDataSO>();

		private static readonly Dictionary<int, CharacterMaterialDataSO> _bodySkins = new Dictionary<int, CharacterMaterialDataSO>();

		private static readonly Dictionary<int, CharacterMaterialDataSO> _headSkins = new Dictionary<int, CharacterMaterialDataSO>();

		private static readonly Dictionary<int, CharacterMaterialDataSO> _eyes = new Dictionary<int, CharacterMaterialDataSO>();

		private static readonly Dictionary<int, CharacterMeshDataSO> _hairs = new Dictionary<int, CharacterMeshDataSO>();

		private static readonly Dictionary<int, CharacterBlenshapeDataSO> _blendShapes = new Dictionary<int, CharacterBlenshapeDataSO>();

		private static List<CharacterAvatarDataSO> _characterAvatarDatas = new List<CharacterAvatarDataSO>();

		private static bool _loadResources = true;

		public static List<CharacterAvatarDataSO> CharacterAvatarDatas => InitResources(_characterAvatarDatas);

		[RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.BeforeSceneLoad)]
		private static void Reset()
		{
			_clothes.Clear();
			_bodySkins.Clear();
			_headSkins.Clear();
			_eyes.Clear();
			_hairs.Clear();
			_blendShapes.Clear();
			_characterAvatarDatas.Clear();
			_loadResources = true;
		}

		public static void AddClothing(CharacterBodyDataSO body)
		{
			Add(body, _clothes);
		}

		public static void AddBodySkin(CharacterMaterialDataSO skin)
		{
			Add(skin, _bodySkins);
		}

		public static void AddHeadSkin(CharacterMaterialDataSO head)
		{
			Add(head, _headSkins);
		}

		public static void AddEyeSkin(CharacterMaterialDataSO eye)
		{
			Add(eye, _eyes);
		}

		public static void AddHair(CharacterMeshDataSO hair)
		{
			Add(hair, _hairs);
		}

		public static void AddBlendShape(CharacterBlenshapeDataSO blendShape)
		{
			Add(blendShape, _blendShapes);
		}

		public static BodySet? GetBody(CharacterData characterData)
		{
			BodySet bodySet;
			if (TryGetSpecific(out bodySet))
			{
				return bodySet;
			}
			TemporaryCollection.TemporaryList<BodySet> temporaryList = TemporaryCollection.GetTemporaryList<BodySet>();
			try
			{
				foreach (var (_, characterBodyDataSO2) in _clothes)
				{
					if (characterData.IsValid(characterBodyDataSO2.characterData))
					{
						temporaryList.List.Add(ToBodySet(characterBodyDataSO2));
					}
				}
				if (temporaryList.List.Count == 0)
				{
					Debug.LogException(new Exception("Couldn't get a body for " + characterData.ToString()));
					return null;
				}
				return temporaryList.List.GetRandom();
			}
			finally
			{
				temporaryList.Dispose();
			}
			static BodySet ToBodySet(CharacterBodyDataSO bodyData)
			{
				int randomIndex = bodyData.materialsGroup.GetRandomIndex();
				return new BodySet
				{
					mesh = bodyData.mesh,
					materialBodySets = CreateMaterialBodySets(bodyData.materialsGroup[randomIndex].materials),
					meshIndex = bodyData.ID,
					materialIndex = randomIndex
				};
			}
			bool TryGetSpecific(out BodySet outBody)
			{
				outBody = default(BodySet);
				if (characterData.bodyDataIndex == 0)
				{
					return false;
				}
				if (!_clothes.TryGetValue(characterData.bodyDataIndex, out var value))
				{
					return false;
				}
				bodySet.materialIndex = characterData.bodyMaterialGroupIndex;
				if (!bodySet.materialIndex.IsCorrectArrayIndex(value.materialsGroup))
				{
					bodySet.materialIndex = value.materialsGroup.GetRandomIndex();
				}
				bodySet.materialBodySets = CreateMaterialBodySets(value.materialsGroup[bodySet.materialIndex].materials);
				bodySet.mesh = value.mesh;
				bodySet.meshIndex = characterData.bodyDataIndex;
				return true;
			}
		}

		public static IndexedMaterial? GetBodySkin(CharacterData characterData)
		{
			return GetSkin(characterData, _bodySkins, characterData.bodySkinMaterialIndex);
		}

		public static IndexedMaterial? GetHeadSkin(CharacterData characterData)
		{
			return GetSkin(characterData, _headSkins, characterData.headSkinMaterialIndex);
		}

		public static IndexedMaterial? GetEyeSkin(CharacterData characterData)
		{
			return GetSkin(characterData, _eyes, characterData.eyesMaterialIndex);
		}

		private static IndexedMaterial? GetSkin(CharacterData characterData, Dictionary<int, CharacterMaterialDataSO> skins, int specificIndex)
		{
			if (TryGetSpecific(out var outSkin))
			{
				return outSkin;
			}
			TemporaryCollection.TemporaryList<IndexedMaterial> temporaryList = TemporaryCollection.GetTemporaryList<IndexedMaterial>();
			try
			{
				foreach (var (index, characterMaterialDataSO2) in skins)
				{
					if (characterData.IsValid(characterMaterialDataSO2.characterData))
					{
						temporaryList.List.Add(new IndexedMaterial
						{
							material = characterMaterialDataSO2.material,
							index = index
						});
					}
				}
				if (temporaryList.List.Count == 0)
				{
					Debug.LogException(new NullReferenceException("Couldn't get a body for " + characterData.ToString()));
					return null;
				}
				return temporaryList.List.GetRandom();
			}
			finally
			{
				temporaryList.Dispose();
			}
			bool TryGetSpecific(out IndexedMaterial reference)
			{
				reference = default(IndexedMaterial);
				int num2 = specificIndex;
				if (num2 == 0)
				{
					return false;
				}
				reference = default(IndexedMaterial);
				if (!skins.TryGetValue(num2, out var value))
				{
					return false;
				}
				reference.material = value.material;
				reference.index = num2;
				return true;
			}
		}

		public static IndexedCharacterBlenshapeData? GetBlendShape(CharacterData characterData)
		{
			if (TryGetSpecific(out var outSkin))
			{
				return outSkin;
			}
			TemporaryCollection.TemporaryList<IndexedCharacterBlenshapeData> temporaryList = TemporaryCollection.GetTemporaryList<IndexedCharacterBlenshapeData>();
			try
			{
				foreach (var (index, characterBlenshapeDataSO2) in _blendShapes)
				{
					if (characterData.IsValid(characterBlenshapeDataSO2.characterData))
					{
						temporaryList.List.Add(new IndexedCharacterBlenshapeData
						{
							so = characterBlenshapeDataSO2,
							index = index
						});
					}
				}
				if (temporaryList.List.Count == 0)
				{
					Debug.LogException(new NullReferenceException("Couldn't get a blendshape for " + characterData.ToString()));
					return null;
				}
				return temporaryList.List.GetRandom();
			}
			finally
			{
				temporaryList.Dispose();
			}
			bool TryGetSpecific(out IndexedCharacterBlenshapeData reference)
			{
				reference = default(IndexedCharacterBlenshapeData);
				int headBlendIndex = characterData.headBlendIndex;
				if (headBlendIndex == 0)
				{
					return false;
				}
				reference = default(IndexedCharacterBlenshapeData);
				if (!_blendShapes.TryGetValue(headBlendIndex, out var value))
				{
					return false;
				}
				reference.so = value;
				reference.index = headBlendIndex;
				return true;
			}
		}

		public static MeshAndMaterial? GetHair(CharacterData characterData)
		{
			if (TryGetSpecific(out var outHair))
			{
				return outHair;
			}
			TemporaryCollection.TemporaryList<MeshAndMaterial> temporaryList = TemporaryCollection.GetTemporaryList<MeshAndMaterial>();
			try
			{
				foreach (var (meshIndex, characterMeshDataSO2) in _hairs)
				{
					if (characterMeshDataSO2.TryGetMaterial(characterData, out var outMat))
					{
						temporaryList.List.Add(new MeshAndMaterial
						{
							mesh = characterMeshDataSO2.mesh,
							meshIndex = meshIndex,
							material = outMat.material,
							matIndex = outMat.index
						});
					}
				}
				if (temporaryList.List.Count == 0)
				{
					Debug.LogException(new Exception("Couldn't get hair for " + characterData.ToString()));
					return null;
				}
				return temporaryList.List.GetRandom();
			}
			finally
			{
				temporaryList.Dispose();
			}
			bool TryGetSpecific(out MeshAndMaterial reference)
			{
				reference = default(MeshAndMaterial);
				int hairMeshIndex = characterData.hairMeshIndex;
				if (hairMeshIndex == 0)
				{
					return false;
				}
				if (!_hairs.TryGetValue(hairMeshIndex, out var value))
				{
					return false;
				}
				reference.mesh = value.mesh;
				reference.meshIndex = hairMeshIndex;
				if (!value.TryGetSpecificMaterial(characterData.hairMatIndex, out var outMaterial))
				{
					outMaterial = value.GetMaterial(characterData);
				}
				reference.matIndex = outMaterial.index;
				reference.material = outMaterial.material;
				return true;
			}
		}

		public static CharacterAvatarDataSO GetAvatar(EGender genders, ESpecies species, EEthnics ethnics, ESubSpecies subspecies)
		{
			List<CharacterAvatarDataSO> list = new List<CharacterAvatarDataSO>();
			foreach (CharacterAvatarDataSO characterAvatarData in CharacterAvatarDatas)
			{
				if (characterAvatarData.characterData.IsValid(genders, species, ethnics, subspecies))
				{
					list.Add(characterAvatarData);
				}
			}
			if (list.Count == 0)
			{
				Debug.LogError("No Valid Avatar Found!\nGender : " + genders.ToString() + "\nSpecies : " + species.ToString() + "\nEthnics : " + ethnics.ToString() + "\nSubSpecies : " + subspecies);
				return null;
			}
			return list[UnityEngine.Random.Range(0, list.Count)];
		}

		private static void Add<TID>(TID obj, Dictionary<int, TID> dictionary) where TID : IIndentifiable
		{
			int iD = obj.ID;
			if (iD == 0)
			{
				Debug.LogException(new Exception("Cannot add " + obj.ToString() + " because the ID is 0."));
			}
			else if (!dictionary.TryAdd(iD, obj))
			{
				Debug.LogException(new Exception($"Cannot add {obj.ToString()} because the ID {iD} already exists"));
			}
		}

		private static MaterialBodySet[] CreateMaterialBodySets(Material[] materials)
		{
			List<MaterialBodySet> list = new List<MaterialBodySet>();
			foreach (Material material in materials)
			{
				list.Add(MaterialBodySet.Create(material));
			}
			return list.ToArray();
		}

		private static List<T> InitResources<T>(List<T> list)
		{
			if (!_loadResources)
			{
				return list;
			}
			_loadResources = false;
			Load<CharacterAvatarDataSO>(_characterAvatarDatas, "Character_Avatars");
			return list;
			static void Load<T2>(List<T2> list2, string path)
			{
				AsyncOperationHandle<IList<T2>> asyncOperationHandle = Addressables.LoadAssetsAsync<T2>(path);
				asyncOperationHandle.WaitForCompletion();
				foreach (T2 item in asyncOperationHandle.Result)
				{
					if (!list2.Contains(item))
					{
						list2.Add(item);
					}
				}
			}
		}

		public static CharacterAvatarDataSO GetAvatar(CharacterData data)
		{
			return GetAvatar(data.Gender, data.Species, data.Ethnics, data.SubSpecies);
		}

		public static void SaveAll()
		{
		}
	}
}
