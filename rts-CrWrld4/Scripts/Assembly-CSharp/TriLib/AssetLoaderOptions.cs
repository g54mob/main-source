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

		public bool DontLoadLights;

		public bool DontLoadCameras;

		public bool AutoPlayAnimations;

		public WrapMode AnimationWrapMode;

		public bool UseLegacyAnimations;

		public bool EnsureQuaternionContinuity;

		public bool UseOriginalPositionRotationAndScale;

		public RuntimeAnimatorController AnimatorController;

		public Avatar Avatar;

		public bool DontGenerateAvatar;

		public bool DontLoadMetadata;

		public bool DontAddMetadataCollection;

		public bool DontLoadMaterials;

		public bool ApplyColorAlpha;

		public bool ApplyDiffuseColor;

		public bool ApplyEmissionColor;

		public bool ApplySpecularColor;

		public bool ApplyDiffuseTexture;

		public bool ApplyEmissionTexture;

		public bool ApplySpecularTexture;

		public bool ApplyNormalTexture;

		public bool ApplyDisplacementTexture;

		public bool ApplyOcclusionTexture;

		public bool ApplyMetallicTexture;

		public bool ApplyNormalScale;

		public bool ApplyGlossiness;

		public bool ApplyGlossinessScale;

		public bool LoadRawMaterialProperties;

		public bool DisableAlphaMaterials;

		[Obsolete]
		public bool ApplyAlphaMaterials;

		public bool ScanForAlphaMaterials;

		[Obsolete]
		public bool UseCutoutMaterials;

		[Obsolete]
		public bool UseStandardSpecularMaterial;

		public MaterialShadingMode MaterialShadingMode;

		public MaterialTransparencyMode MaterialTransparencyMode;

		public bool DontLoadMeshes;

		public bool DontLoadBlendShapes;

		public bool DontLoadSkinning;

		public bool CombineMeshes;

		public bool Use32BitsIndexFormat;

		public bool GenerateMeshColliders;

		public bool ConvexMeshColliders;

		public Vector3 RotationAngles;

		public float Scale;

		public AssimpPostProcessSteps PostProcessSteps;

		public TextureCompression TextureCompression;

		public FilterMode TextureFilterMode;

		public bool GenerateMipMaps;

		public List<AssetAdvancedConfig> AdvancedConfigs;

		public static AssetLoaderOptions CreateInstance()
		{
			return null;
		}

		public void Deserialize(string json)
		{
		}

		public string Serialize()
		{
			return null;
		}
	}
}
