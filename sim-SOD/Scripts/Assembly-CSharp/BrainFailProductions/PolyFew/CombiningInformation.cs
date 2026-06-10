using System;
using System.Collections.Generic;
using UnityEngine;

namespace BrainFailProductions.PolyFew
{
	public class CombiningInformation
	{
		public enum DiffuseColorSpace
		{
			NON_LINEAR = 0,
			LINEAR = 1
		}

		public enum CompressionType
		{
			UNCOMPRESSED = 0,
			DXT1 = 1,
			ETC2_RGB = 2,
			PVRTC_RGB4 = 3,
			ASTC_RGB = 4
		}

		public enum CompressionQuality
		{
			LOW = 0,
			MEDIUM = 1,
			HIGH = 2
		}

		[Serializable]
		public struct Resolution
		{
			public int width;

			public int height;
		}

		[Serializable]
		public class TextureArrayUserSettings
		{
			public Resolution resolution;

			public FilterMode filteringMode;

			public CompressionType compressionType;

			public CompressionQuality compressionQuality;

			public int anisotropicFilteringLevel;

			public int choiceResolutionW;

			public int choiceResolutionH;

			public int choiceFilteringMode;

			public int choiceCompressionQuality;

			public int choiceCompressionType;

			public TextureArrayUserSettings(Resolution resolution, FilterMode filteringMode, CompressionType compressionType, CompressionQuality compressionQuality = CompressionQuality.MEDIUM, int anisotropicFilteringLevel = 1)
			{
			}
		}

		[Serializable]
		public class TextureArrayGroup
		{
			public TextureArrayUserSettings diffuseArraySettings;

			public TextureArrayUserSettings metallicArraySettings;

			public TextureArrayUserSettings specularArraySettings;

			public TextureArrayUserSettings normalArraySettings;

			public TextureArrayUserSettings heightArraySettings;

			public TextureArrayUserSettings occlusionArraySettings;

			public TextureArrayUserSettings emissiveArraySettings;

			public TextureArrayUserSettings detailMaskArraySettings;

			public TextureArrayUserSettings detailAlbedoArraySettings;

			public TextureArrayUserSettings detailNormalArraySettings;

			public void InitializeDefaultArraySettings(Resolution resolution, FilterMode filteringMode, CompressionType compressionType, CompressionQuality compressionQuality = CompressionQuality.MEDIUM, int anisotropicFilteringLevel = 1)
			{
			}
		}

		[Serializable]
		public class MaterialProperties
		{
			public bool foldOut;

			public int texArrIndex;

			public int matIndex;

			public string materialName;

			public Material originalMaterial;

			public Color albedoTint;

			public Vector4 uvTileOffset;

			public float normalIntensity;

			public float occlusionIntensity;

			public float smoothnessIntensity;

			public float glossMapScale;

			public float metalIntensity;

			public Color emissionColor;

			public Vector4 detailUVTileOffset;

			public float alphaCutoff;

			public Color specularColor;

			public float detailNormalScale;

			public float heightIntensity;

			public float uvSec;

			public int alphaMode;

			public bool specularWorkflow;

			public bool IsSameAs(MaterialProperties toCompare)
			{
				return false;
			}

			public static Texture2D NewTexture()
			{
				return null;
			}

			public void BurnAttrToImg(ref Texture2D burnOn, int index, int textureArrayIndex)
			{
			}

			public void FillPropertiesFromMaterial(Material material, CombiningInformation combineInfo)
			{
			}
		}

		[Serializable]
		public class MeshData
		{
			public List<MeshFilter> meshFilters;

			public List<MeshRenderer> meshRenderers;

			public List<SkinnedMeshRenderer> skinnedMeshRenderers;

			public Material[] originalMaterials;

			public Mesh[] outputMeshes;

			public Matrix4x4[] outputMatrices;
		}

		[Serializable]
		public class CombineMetaData
		{
			public Material material;

			public MaterialProperties materialProperties;

			public MaterialProperties tempMaterialProperties;

			public List<MeshData> meshesData;
		}

		[Serializable]
		public class MaterialEntity
		{
			public List<CombineMetaData> combinedMats;

			public int textArrIndex;

			public Texture2D diffuseMap;

			public Texture2D metallicMap;

			public Texture2D specularMap;

			public Texture2D normalMap;

			public Texture2D heightMap;

			public Texture2D occlusionMap;

			public Texture2D emissionMap;

			public Texture2D detailMaskMap;

			public Texture2D detailAlbedoMap;

			public Texture2D detailNormalMap;

			public bool HasAnyTextures()
			{
				return false;
			}
		}

		public List<MaterialEntity> materialEntities;

		public TextureArrayGroup textureArraysSettings;

		public DiffuseColorSpace diffuseColorSpace;

		public Material[] combinedMaterials;

		public bool ShouldGenerateMetallicArray()
		{
			return false;
		}

		public bool ShouldGenerateSpecularArray()
		{
			return false;
		}

		public bool ShouldGenerateNormalArray()
		{
			return false;
		}

		public bool ShouldGenerateHeightArray()
		{
			return false;
		}

		public bool ShouldGenerateOcclusionArray()
		{
			return false;
		}

		public bool ShouldGenerateEmissionArray()
		{
			return false;
		}

		public bool ShouldGenerateDetailMaskArray()
		{
			return false;
		}

		public bool ShouldGenerateDetailAlbedoArray()
		{
			return false;
		}

		public bool ShouldGenerateDetailNormalArray()
		{
			return false;
		}
	}
}
