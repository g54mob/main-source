using System;
using System.Collections.Generic;
using UnityEngine;

namespace TriLib
{
	[Serializable]
	public class AssetLoaderOptions : ScriptableObject
	{
		public bool AddAssetUnloader;

		public bool DontLoadAnimations;

		public bool ForceAnimationComponents;

		public bool DontApplyAnimations;

		public bool DontLoadLights = true;

		public bool DontLoadCameras = true;

		public bool AutoPlayAnimations = true;

		public WrapMode AnimationWrapMode = WrapMode.Loop;

		public bool UseLegacyAnimations = true;

		public bool EnsureQuaternionContinuity = true;

		public bool UseOriginalPositionRotationAndScale;

		public RuntimeAnimatorController AnimatorController;

		public Avatar Avatar;

		public bool DontGenerateAvatar;

		public bool DontLoadMetadata;

		public bool DontAddMetadataCollection;

		public bool DontLoadMaterials;

		public bool ApplyColorAlpha = true;

		public bool ApplyDiffuseColor = true;

		public bool ApplyEmissionColor = true;

		public bool ApplySpecularColor = true;

		public bool ApplyDiffuseTexture = true;

		public bool ApplyEmissionTexture = true;

		public bool ApplySpecularTexture = true;

		public bool ApplyNormalTexture = true;

		public bool ApplyDisplacementTexture = true;

		public bool ApplyOcclusionTexture = true;

		public bool ApplyMetallicTexture = true;

		public bool ApplyNormalScale = true;

		public bool ApplyGlossiness = true;

		public bool ApplyGlossinessScale = true;

		public bool LoadRawMaterialProperties;

		public bool DisableAlphaMaterials;

		[Obsolete("Please use ScanForAlphaMaterials instead.")]
		public bool ApplyAlphaMaterials;

		public bool ScanForAlphaMaterials;

		[Obsolete("Please use MaterialTransparencyMode instead.")]
		public bool UseCutoutMaterials;

		[Obsolete("Please use MaterialShadingMode instead.")]
		public bool UseStandardSpecularMaterial;

		public MaterialShadingMode MaterialShadingMode;

		public MaterialTransparencyMode MaterialTransparencyMode;

		public bool DontLoadMeshes;

		public bool DontLoadBlendShapes;

		public bool DontLoadSkinning;

		public bool CombineMeshes = true;

		public bool Use32BitsIndexFormat = true;

		public bool GenerateMeshColliders;

		public bool ConvexMeshColliders;

		public Vector3 RotationAngles = new Vector3(0f, 180f, 0f);

		public float Scale = 1f;

		public AssimpPostProcessSteps PostProcessSteps = AssimpPostProcessSteps.CalcTangentSpace | AssimpPostProcessSteps.JoinIdenticalVertices | AssimpPostProcessSteps.MakeLeftHanded | AssimpPostProcessSteps.Triangulate | AssimpPostProcessSteps.GenSmoothNormals | AssimpPostProcessSteps.LimitBoneWeights | AssimpPostProcessSteps.ImproveCacheLocality | AssimpPostProcessSteps.SortByPType | AssimpPostProcessSteps.FindInvalidData | AssimpPostProcessSteps.GenUvCoords | AssimpPostProcessSteps.FindInstances | AssimpPostProcessSteps.OptimizeMeshes | AssimpPostProcessSteps.FlipWindingOrder;

		public TextureCompression TextureCompression = TextureCompression.NormalQuality;

		public FilterMode TextureFilterMode = FilterMode.Bilinear;

		public bool GenerateMipMaps = true;

		public List<AssetAdvancedConfig> AdvancedConfigs = new List<AssetAdvancedConfig>
		{
			AssetAdvancedConfig.CreateConfig(AssetAdvancedPropertyClassNames.SplitLargeMeshesVertexLimit, 65000),
			AssetAdvancedConfig.CreateConfig(AssetAdvancedPropertyClassNames.FBXImportReadLights, value: false),
			AssetAdvancedConfig.CreateConfig(AssetAdvancedPropertyClassNames.FBXImportReadCameras, value: false)
		};

		public static AssetLoaderOptions CreateInstance()
		{
			return ScriptableObject.CreateInstance<AssetLoaderOptions>();
		}

		public void Deserialize(string json)
		{
			JsonUtility.FromJsonOverwrite(json, this);
		}

		public string Serialize()
		{
			return JsonUtility.ToJson(this);
		}
	}
}
