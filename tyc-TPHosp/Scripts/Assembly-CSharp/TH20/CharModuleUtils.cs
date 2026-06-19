using System;
using System.Collections.Generic;
using UnityEngine;

namespace TH20
{
	public static class CharModuleUtils
	{
		private static Transform[] _cachedBoneArray = new Transform[32];

		public static void GetCoreRandomAssets(ModularSkinMaterialSelection skinHairMaterialDatabase, ModularSkinMaterialSelection eyeMaterialSelection, out Material eyeMaterial, out Material skinToneMaterial, out ModularMeshMaterialBindings hairMeshMaterialBindings)
		{
			ModularSkinMaterialSelection.MaterialPair materialPair = skinHairMaterialDatabase.Materials.RandomItem();
			ModularMaterialSelection.PossibleMaterial possibleMaterial = materialPair.MaterialSelection.Materials.WeightedRandomItem((ModularMaterialSelection.PossibleMaterial x) => x.Weight);
			skinToneMaterial = materialPair.SkinMaterial;
			eyeMaterial = null;
			for (int num = 0; num < eyeMaterialSelection.Materials.Count; num++)
			{
				if (eyeMaterialSelection.Materials[num].SkinMaterial == skinToneMaterial)
				{
					switch (eyeMaterialSelection.Materials[num].Mode)
					{
					case ModularSkinMaterialSelection.Mode.Material:
						eyeMaterial = eyeMaterialSelection.Materials[num].Material;
						break;
					case ModularSkinMaterialSelection.Mode.MaterialSelection:
					{
						Material randomMaterial = eyeMaterialSelection.Materials[num].MaterialSelection.GetRandomMaterial();
						eyeMaterial = randomMaterial;
						break;
					}
					}
					break;
				}
			}
			hairMeshMaterialBindings = possibleMaterial.MeshMaterialBindings;
		}

		public static void BuildModularCharacterGameObject(List<CharModule.CharModuleAssets> charModuleAssets, Transform parent, Transform[] rigBones, bool instantiateMaterials, ModularMeshMaterialBindings meshMaterialBindingsOverride, List<CharModule.ModuleInstance> outInstances)
		{
			Dictionary<string, Transform> dictionary = new Dictionary<string, Transform>();
			for (int i = 0; i < rigBones.Length; i++)
			{
				dictionary.Add(rigBones[i].name, rigBones[i]);
			}
			foreach (CharModule.CharModuleAssets charModuleAsset in charModuleAssets)
			{
				if (charModuleAsset.Prefab == null)
				{
					continue;
				}
				Renderer componentInChildren = charModuleAsset.Prefab.GetComponentInChildren<Renderer>();
				if (componentInChildren == null)
				{
					UnityEngine.Debug.LogErrorFormat("Unable to find Renderer within prefab {0}", charModuleAsset.Prefab.name);
				}
				if (!(componentInChildren != null))
				{
					continue;
				}
				bool num = componentInChildren is SkinnedMeshRenderer && ((SkinnedMeshRenderer)componentInChildren).sharedMesh.blendShapeCount > 0;
				Transform parent2 = parent;
				GameObject gameObject = UnityEngine.Object.Instantiate(componentInChildren.gameObject);
				GameObject gameObject2;
				if (num)
				{
					gameObject2 = new GameObject(componentInChildren.transform.parent.name);
					gameObject2.transform.SetParent(parent, worldPositionStays: false);
					parent2 = gameObject2.transform;
				}
				else
				{
					gameObject2 = gameObject;
				}
				gameObject.transform.SetParent(parent2, worldPositionStays: false);
				gameObject.name = componentInChildren.name;
				Renderer component = gameObject.GetComponent<Renderer>();
				SkinnedMeshRenderer component2 = gameObject.GetComponent<SkinnedMeshRenderer>();
				int num3;
				if (component2 != null)
				{
					if (_cachedBoneArray.Length < component2.bones.Length)
					{
						int num2 = _cachedBoneArray.Length * 2;
						if (num2 < component2.bones.Length)
						{
							num2 = component2.bones.Length;
						}
						_cachedBoneArray = new Transform[num2];
					}
					Transform[] cachedBoneArray = _cachedBoneArray;
					for (int j = 0; j < component2.bones.Length; j++)
					{
						string text = component2.bones[j].name;
						if (text == "BASE_RIG:BASE_SOCKET")
						{
							text = "BASE_RIG:TSM3WorldJoint";
						}
						dictionary.TryGetValue(text, out cachedBoneArray[j]);
					}
					for (int k = component2.bones.Length; k < cachedBoneArray.Length; k++)
					{
						cachedBoneArray[k] = null;
					}
					string rootBoneName = component2.rootBone.name;
					component2.bones = cachedBoneArray;
					component2.rootBone = Array.Find(rigBones, (Transform bone) => bone.name == rootBoneName);
					num3 = component2.sharedMesh.subMeshCount;
					if (num3 == 1)
					{
						component2.sharedMaterial = charModuleAsset.Material0;
						if (meshMaterialBindingsOverride != null)
						{
							Material material = meshMaterialBindingsOverride.GetMaterial(charModuleAsset.Prefab);
							if (material != null)
							{
								component2.sharedMaterial = material;
							}
						}
					}
					else if (num3 > 1)
					{
						component2.sharedMaterials = new Material[2] { charModuleAsset.Material0, charModuleAsset.Material1 };
					}
				}
				else
				{
					component.sharedMaterial = charModuleAsset.Material0;
					num3 = 1;
					if (meshMaterialBindingsOverride != null)
					{
						Material material2 = meshMaterialBindingsOverride.GetMaterial(charModuleAsset.Prefab);
						if (material2 != null)
						{
							component.sharedMaterial = material2;
						}
					}
				}
				if (outInstances != null)
				{
					Material[] originalMaterials = (instantiateMaterials ? component.materials : null);
					CharModule.MaterialMode[] materialModes = null;
					if (num3 == 1)
					{
						materialModes = new CharModule.MaterialMode[1] { charModuleAsset.MaterialMode0 };
					}
					else if (num3 > 1)
					{
						materialModes = new CharModule.MaterialMode[2] { charModuleAsset.MaterialMode0, charModuleAsset.MaterialMode1 };
					}
					outInstances.Add(new CharModule.ModuleInstance(charModuleAsset.Tags, gameObject2, component, originalMaterials, materialModes));
				}
			}
		}

		public static void DestroyModularInstances(IList<CharModule.ModuleInstance> instances)
		{
			if (instances == null)
			{
				return;
			}
			foreach (CharModule.ModuleInstance instance in instances)
			{
				for (int i = 0; i < instance.OriginalMaterials.Length; i++)
				{
					UnityEngine.Object.Destroy(instance.OriginalMaterials[i]);
				}
				UnityEngine.Object.Destroy(instance.GameObject);
			}
			instances.Clear();
		}
	}
}
