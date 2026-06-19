using System;
using System.Collections.Generic;
using JetBrains.Annotations;
using UnityEngine;
using UnityEngine.Serialization;

namespace TH20
{
	[CreateAssetMenu(menuName = "TH20/Character Module", order = 1024)]
	public class CharModule : ScriptableObjectWithID
	{
		[Flags]
		public enum Category
		{
			[UsedImplicitly]
			Male = 1,
			[UsedImplicitly]
			Female = 2,
			[UsedImplicitly]
			Doctor = 4,
			[UsedImplicitly]
			Nurse = 8,
			[UsedImplicitly]
			Assistant = 0x10,
			[UsedImplicitly]
			Janitor = 0x20,
			[UsedImplicitly]
			Patient = 0x40,
			[UsedImplicitly]
			Summer = 0x40000000,
			[UsedImplicitly]
			Winter = int.MinValue
		}

		[Flags]
		public enum Tags
		{
			[UsedImplicitly]
			Face = 1,
			[UsedImplicitly]
			Body = 2
		}

		public enum MaterialMode
		{
			[UsedImplicitly]
			Selection = 0,
			[UsedImplicitly]
			SelectionMatchesSkin = 4,
			[UsedImplicitly]
			Skin = 1,
			[UsedImplicitly]
			Hair = 2,
			[UsedImplicitly]
			Eye = 3
		}

		[Serializable]
		[UsedImplicitly(ImplicitUseKindFlags.Assign | ImplicitUseKindFlags.InstantiatedNoFixedConstructorSignature, ImplicitUseTargetFlags.Members)]
		public struct CharModuleAssets
		{
			public static readonly int InitListCapicity = 12;

			public readonly GameObject Prefab;

			public readonly Material Material0;

			public readonly Material Material1;

			public readonly MaterialMode MaterialMode0;

			public readonly MaterialMode MaterialMode1;

			public readonly Tags Tags;

			public CharModuleAssets(GameObject prefab, Tags tags, Material material0, Material material1, MaterialMode materialMode0, MaterialMode materialMode1)
			{
				Prefab = prefab;
				Tags = tags;
				Material0 = material0;
				Material1 = material1;
				MaterialMode0 = materialMode0;
				MaterialMode1 = materialMode1;
			}

			public override bool Equals(object obj)
			{
				if (obj is CharModuleAssets)
				{
					return this == (CharModuleAssets)obj;
				}
				return false;
			}

			public override int GetHashCode()
			{
				return Prefab.GetHashCode() ^ Tags.GetHashCode() ^ Material0.GetHashCode() ^ Material1.GetHashCode();
			}

			public static bool operator ==(CharModuleAssets x, CharModuleAssets y)
			{
				if (x.Prefab == y.Prefab && x.Material0 == y.Material0)
				{
					return x.Material1 == y.Material1;
				}
				return false;
			}

			public static bool operator !=(CharModuleAssets x, CharModuleAssets y)
			{
				return !(x == y);
			}
		}

		[Serializable]
		[UsedImplicitly(ImplicitUseKindFlags.Assign | ImplicitUseKindFlags.InstantiatedNoFixedConstructorSignature, ImplicitUseTargetFlags.Members)]
		public class Geometry
		{
			public GameObject Prefab;

			public Tags Tags;

			[FormerlySerializedAs("MaterialMode")]
			public MaterialMode MaterialMode0;

			[FormerlySerializedAs("MaterialSelection")]
			public ModularMaterialSelection MaterialSelection0;

			public ModularSkinMaterialSelection ModularSkinMaterialSelection0;

			public MaterialMode MaterialMode1;

			public ModularMaterialSelection MaterialSelection1;

			public ModularSkinMaterialSelection ModularSkinMaterialSelection1;
		}

		[Serializable]
		[UsedImplicitly(ImplicitUseKindFlags.Assign | ImplicitUseKindFlags.InstantiatedNoFixedConstructorSignature, ImplicitUseTargetFlags.Members)]
		public class GeometryCollection
		{
			public float Weight = 1f;

			public Category Categories;

			[FormerlySerializedAs("MeshData")]
			[FormerlySerializedAs("VisualElem")]
			public List<Geometry> Geometries = new List<Geometry>();
		}

		[Serializable]
		[UsedImplicitly(ImplicitUseKindFlags.Assign | ImplicitUseKindFlags.InstantiatedNoFixedConstructorSignature, ImplicitUseTargetFlags.Members)]
		public class ChildModuleChoice
		{
			public float Weight = 1f;

			public Category OptionalCategories;

			[FormerlySerializedAs("Node")]
			public CharModule Module;
		}

		[Serializable]
		[UsedImplicitly(ImplicitUseKindFlags.Assign | ImplicitUseKindFlags.InstantiatedNoFixedConstructorSignature, ImplicitUseTargetFlags.Members)]
		public class ChildModuleSelection
		{
			public Category Categories;

			[FormerlySerializedAs("Choices")]
			public List<ChildModuleChoice> Choices = new List<ChildModuleChoice>();
		}

		[Serializable]
		[UsedImplicitly(ImplicitUseKindFlags.Assign | ImplicitUseKindFlags.InstantiatedNoFixedConstructorSignature, ImplicitUseTargetFlags.Members)]
		public class Mask
		{
			public readonly Tags Tags;

			public readonly CharModule CharacterModule;

			public readonly ModularSkinMaterialSelection EyeLidMaterialSelectionOverride;
		}

		public struct ModuleInstance
		{
			public readonly Tags Tags;

			public readonly Renderer Renderer;

			public readonly GameObject GameObject;

			public readonly Material[] OriginalMaterials;

			public readonly Material[] FadeMaterials;

			public readonly MaterialMode[] MaterialModes;

			public ModuleInstance(Tags tags, GameObject gameObject, Renderer renderer, Material[] originalMaterials, MaterialMode[] materialModes)
			{
				Tags = tags;
				Renderer = renderer;
				GameObject = gameObject;
				OriginalMaterials = originalMaterials;
				MaterialModes = materialModes;
				if (OriginalMaterials != null)
				{
					FadeMaterials = new Material[OriginalMaterials.Length];
					for (int i = 0; i < FadeMaterials.Length; i++)
					{
						FadeMaterials[i] = new Material(OriginalMaterials[i]);
						FadeMaterials[i].EnableKeyword("CHARACTER_CULL_FADE");
						TH20Standard.SetBlendMode(FadeMaterials[i], TH20Standard.BlendMode.Dithered);
					}
				}
				else
				{
					FadeMaterials = null;
				}
			}
		}

		[SerializeField]
		private string _descriptiveName = "";

		[SerializeField]
		private List<GeometryCollection> _meshes = new List<GeometryCollection>();

		[SerializeField]
		[FormerlySerializedAs("_requiredChildren2")]
		[FormerlySerializedAs("_childNodeSelections")]
		private List<ChildModuleSelection> _childModuleSelections = new List<ChildModuleSelection>();

		public List<ChildModuleSelection> ChildModuleSelections => _childModuleSelections;

		public List<GeometryCollection> Visuals => _meshes;

		public string DescriptiveName
		{
			get
			{
				return _descriptiveName;
			}
			set
			{
				_descriptiveName = value;
			}
		}

		private static Category GetOptionalCategories(Category category)
		{
			return category & (Category)(-65536);
		}

		private static Category GetMandatoryCategories(Category category)
		{
			return category & (Category)65535;
		}

		public void GetRandomCharacterData(Category categories, Material eyeMaterial, Material skinMaterial, ModularMeshMaterialBindings hairMeshMaterialBindings, List<CharModuleAssets> results)
		{
			Category mandatoryCategories = GetMandatoryCategories(categories);
			Category optionalCategories = GetOptionalCategories(categories);
			if (_meshes.Count > 0)
			{
				GeometryCollection geometryCollection = _meshes.WeightedRandomItem(delegate(GeometryCollection geometry)
				{
					Category optionalCategories3 = GetOptionalCategories(geometry.Categories);
					bool num5 = (geometry.Categories & mandatoryCategories) == mandatoryCategories;
					bool flag2 = optionalCategories3 == (Category)0 || (optionalCategories3 & optionalCategories) != 0;
					return (num5 && flag2) ? geometry.Weight : 0f;
				});
				if (geometryCollection != null)
				{
					foreach (Geometry geometry in geometryCollection.Geometries)
					{
						GameObject prefab = geometry.Prefab;
						Material material = null;
						switch (geometry.MaterialMode0)
						{
						case MaterialMode.Selection:
							if (geometry.MaterialSelection0 != null)
							{
								material = geometry.MaterialSelection0.GetRandomMaterial();
							}
							break;
						case MaterialMode.SelectionMatchesSkin:
						{
							if (!(geometry.ModularSkinMaterialSelection0 != null))
							{
								break;
							}
							for (int num = 0; num < geometry.ModularSkinMaterialSelection0.Materials.Count; num++)
							{
								if (geometry.ModularSkinMaterialSelection0.Materials[num].SkinMaterial == skinMaterial)
								{
									material = geometry.ModularSkinMaterialSelection0.Materials[num].Material;
									break;
								}
							}
							break;
						}
						case MaterialMode.Hair:
							material = hairMeshMaterialBindings.GetMaterial(prefab);
							break;
						case MaterialMode.Skin:
							material = skinMaterial;
							break;
						case MaterialMode.Eye:
							material = eyeMaterial;
							break;
						}
						_ = material == null;
						Material material2 = null;
						switch (geometry.MaterialMode1)
						{
						case MaterialMode.Selection:
							if (geometry.MaterialSelection1 != null)
							{
								material2 = geometry.MaterialSelection1.GetRandomMaterial();
							}
							break;
						case MaterialMode.SelectionMatchesSkin:
						{
							if (!(geometry.ModularSkinMaterialSelection1 != null))
							{
								break;
							}
							for (int num2 = 0; num2 < geometry.ModularSkinMaterialSelection1.Materials.Count; num2++)
							{
								if (geometry.ModularSkinMaterialSelection1.Materials[num2].SkinMaterial == skinMaterial)
								{
									material2 = geometry.ModularSkinMaterialSelection1.Materials[num2].Material;
									break;
								}
							}
							break;
						}
						case MaterialMode.Hair:
							material2 = hairMeshMaterialBindings.GetMaterial(prefab);
							break;
						case MaterialMode.Skin:
							material2 = skinMaterial;
							break;
						case MaterialMode.Eye:
							material2 = eyeMaterial;
							break;
						}
						results.Add(new CharModuleAssets(prefab, geometry.Tags, material, material2, geometry.MaterialMode0, geometry.MaterialMode1));
					}
				}
			}
			for (int num3 = 0; num3 < _childModuleSelections.Count; num3++)
			{
				if (_childModuleSelections[num3] == null)
				{
					continue;
				}
				Category optionalCategories2 = GetOptionalCategories(_childModuleSelections[num3].Categories);
				bool num4 = (_childModuleSelections[num3].Categories & mandatoryCategories) == mandatoryCategories;
				bool flag = optionalCategories2 == (Category)0 || (optionalCategories2 & optionalCategories) != 0;
				if (num4 && flag)
				{
					ChildModuleChoice childModuleChoice = _childModuleSelections[num3].Choices.WeightedRandomItem((ChildModuleChoice c) => (c.OptionalCategories == (Category)0 || (c.OptionalCategories & optionalCategories) != 0) ? c.Weight : 0f);
					if (childModuleChoice != null && childModuleChoice.Module != null)
					{
						childModuleChoice.Module.GetRandomCharacterData(categories, eyeMaterial, skinMaterial, hairMeshMaterialBindings, results);
					}
				}
			}
		}
	}
}
