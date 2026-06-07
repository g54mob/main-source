using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

namespace UMA
{
	public class UMAMaterial : ScriptableObject
	{
		[Serializable]
		public class ShaderParms
		{
			public string ParameterName;

			public string ColorName;
		}

		public enum CompressionSettings
		{
			None = 0,
			Fast = 1,
			HighQuality = 2
		}

		[Serializable]
		public struct SRPMaterial
		{
			[Tooltip("The SRP this material is used for.")]
			public UMAUtils.PipelineType SRP;

			[Tooltip("The material to use for this SRP. If 'Use Existing Textures' is set, this is the first pass material.")]
			public Material material;

			[Tooltip("Used as a second pass when 'Use Existing Textures' is set. Leave null for most cases.")]
			public Material secondPass;

			[Tooltip("The keywords to use for this material")]
			public List<string> alternateKeywords;

			private Dictionary<string, string> _alternateKeywordsLookup;

			public SRPMaterial(UMAUtils.PipelineType SRP, Material material, Material secondPass, List<string> alternateKeywords)
			{
				this.SRP = default(UMAUtils.PipelineType);
				this.material = null;
				this.secondPass = null;
				this.alternateKeywords = null;
				_alternateKeywordsLookup = null;
			}
		}

		public enum MaterialType
		{
			Atlas = 1,
			NoAtlas = 2,
			UseExistingMaterial = 4,
			UseExistingTextures = 8
		}

		public enum ChannelType
		{
			Texture = 0,
			NormalMap = 1,
			MaterialColor = 2,
			TintedTexture = 3,
			DiffuseTexture = 4,
			DetailNormalMap = 5
		}

		[Serializable]
		public struct MaterialChannel
		{
			public ChannelType channelType;

			public RenderTextureFormat textureFormat;

			public string materialPropertyName;

			public string sourceTextureName;

			public CompressionSettings Compression;

			[Range(1f, 128f)]
			public int DownSample;

			public bool ConvertRenderTexture;

			public bool NonShaderTexture;
		}

		public bool translateSRP;

		private bool srpSetup;

		public bool AutoSetSRPMaterials;

		[SerializeField]
		[FormerlySerializedAs("material")]
		private Material _material;

		[SerializeField]
		[FormerlySerializedAs("secondPass")]
		private Material _secondPass;

		public List<SRPMaterial> srpMaterials;

		[Tooltip("Used as a second pass when 'Use Existing Textures' is set. Leave null for most cases.")]
		public MaterialType materialType;

		public MaterialChannel[] channels;

		[Range(-2f, 2f)]
		public float MipMapBias;

		[Range(1f, 16f)]
		public int AnisoLevel;

		public FilterMode MatFilterMode;

		public CompressionSettings Compression;

		[Tooltip("Shader parms can be used to pass colors to shaders. Each entry represents a parameter name and a color name. If neither exists, it is ignored.")]
		public ShaderParms[] shaderParms;

		[Tooltip("If this is checked, the currently assigned color will be used as the background color so edges aren't darkened.")]
		public bool MaskWithCurrentColor;

		[Tooltip("The current color is multiplied by this color to determine the masking color when 'MaskWithCurrentColor' is checked.")]
		public Color maskMultiplier;

		[Tooltip("Used by addressables when stripping materials")]
		public string MaterialName;

		[Tooltip("Used by addressables when stripping materials")]
		public string ShaderName;

		private static Color[] ChannelBackground;

		public Material material
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		public Material secondPass => null;

		public bool IsGeneratedTextures => false;

		public bool IsEmpty => false;

		public void Awake()
		{
		}

		public void SetupSRP(bool forceSetup = false)
		{
		}

		public SRPMaterial CreateSRPMaterial(UMAUtils.PipelineType SRP)
		{
			return default(SRPMaterial);
		}

		public static Color GetBackgroundColor(ChannelType channelType)
		{
			return default(Color);
		}

		public List<string> GetTexturePropertyNames()
		{
			return null;
		}

		public bool IsNoAtlas()
		{
			return false;
		}

		public bool IsProcedural()
		{
			return false;
		}

		public bool Equals(UMAMaterial material)
		{
			return false;
		}
	}
}
