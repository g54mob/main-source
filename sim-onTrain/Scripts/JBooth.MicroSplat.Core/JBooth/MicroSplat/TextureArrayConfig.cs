using System;
using System.Collections.Generic;
using UnityEngine;

namespace JBooth.MicroSplat
{
	[CreateAssetMenu(menuName = "MicroSplat/Texture Array Config", order = 1)]
	[ExecuteInEditMode]
	public class TextureArrayConfig : ScriptableObject
	{
		public enum AllTextureChannel
		{
			R = 0,
			G = 1,
			B = 2,
			A = 3,
			Custom = 4
		}

		public enum TextureChannel
		{
			R = 0,
			G = 1,
			B = 2,
			A = 3
		}

		public enum Compression
		{
			AutomaticCompressed = 0,
			ForceDXT = 1,
			ForceBC7 = 2,
			ForcePVR = 3,
			ForceETC2 = 4,
			ForceASTC = 5,
			ForceCrunch = 6,
			Uncompressed = 7
		}

		public enum CompressionQuality
		{
			High = 0,
			Medium = 1,
			Low = 2
		}

		public enum TextureSize
		{
			k4096 = 4096,
			k2048 = 2048,
			k1024 = 1024,
			k512 = 512,
			k256 = 256,
			k128 = 128,
			k64 = 64,
			k32 = 32
		}

		[Serializable]
		public class TextureArraySettings
		{
			public TextureSize textureSize;

			public Compression compression;

			public CompressionQuality compressionQuality;

			public FilterMode filterMode;

			[Range(0f, 16f)]
			public int Aniso = 1;

			public TextureArraySettings(TextureSize s, Compression c, FilterMode f, int a = 1)
			{
				textureSize = s;
				compression = c;
				compressionQuality = CompressionQuality.Medium;
				filterMode = f;
				Aniso = a;
			}
		}

		public enum PBRWorkflow
		{
			Metallic = 0,
			Specular = 1
		}

		public enum PackingMode
		{
			Fastest = 0,
			Quality = 1
		}

		public enum SourceTextureSize
		{
			Unchanged = 0,
			k32 = 0x20,
			k256 = 0x100
		}

		public enum TextureMode
		{
			Basic = 0,
			PBR = 1
		}

		public enum ClusterMode
		{
			None = 0,
			TwoVariations = 1,
			ThreeVariations = 2
		}

		[Serializable]
		public class TextureArrayGroup
		{
			public TextureArraySettings diffuseSettings = new TextureArraySettings(TextureSize.k1024, Compression.AutomaticCompressed, FilterMode.Bilinear);

			public TextureArraySettings normalSettings = new TextureArraySettings(TextureSize.k1024, Compression.AutomaticCompressed, FilterMode.Trilinear);

			public TextureArraySettings smoothSettings = new TextureArraySettings(TextureSize.k1024, Compression.AutomaticCompressed, FilterMode.Bilinear);

			public TextureArraySettings antiTileSettings = new TextureArraySettings(TextureSize.k1024, Compression.AutomaticCompressed, FilterMode.Bilinear);

			public TextureArraySettings emissiveSettings = new TextureArraySettings(TextureSize.k1024, Compression.AutomaticCompressed, FilterMode.Bilinear);

			public TextureArraySettings specularSettings = new TextureArraySettings(TextureSize.k1024, Compression.AutomaticCompressed, FilterMode.Bilinear);

			public TextureArraySettings traxDiffuseSettings = new TextureArraySettings(TextureSize.k1024, Compression.AutomaticCompressed, FilterMode.Bilinear);

			public TextureArraySettings traxNormalSettings = new TextureArraySettings(TextureSize.k1024, Compression.AutomaticCompressed, FilterMode.Bilinear);

			public TextureArraySettings decalSplatSettings = new TextureArraySettings(TextureSize.k1024, Compression.AutomaticCompressed, FilterMode.Bilinear);
		}

		[Serializable]
		public class PlatformTextureOverride
		{
			public TextureArrayGroup settings = new TextureArrayGroup();
		}

		[Serializable]
		public class TextureEntry
		{
			public TerrainLayer terrainLayer;

			public Texture2D diffuse;

			public Texture2D height;

			public TextureChannel heightChannel = TextureChannel.G;

			public Texture2D normal;

			public Texture2D smoothness;

			public TextureChannel smoothnessChannel = TextureChannel.G;

			public bool isRoughness;

			public Texture2D ao;

			public TextureChannel aoChannel = TextureChannel.G;

			public Texture2D emis;

			public Texture2D metal;

			public TextureChannel metalChannel = TextureChannel.G;

			public Texture2D specular;

			public Texture2D noiseNormal;

			public Texture2D detailNoise;

			public TextureChannel detailChannel = TextureChannel.G;

			public Texture2D distanceNoise;

			public TextureChannel distanceChannel = TextureChannel.G;

			public Texture2D traxDiffuse;

			public Texture2D traxHeight;

			public TextureChannel traxHeightChannel = TextureChannel.G;

			public Texture2D traxNormal;

			public Texture2D traxSmoothness;

			public TextureChannel traxSmoothnessChannel = TextureChannel.G;

			public bool traxIsRoughness;

			public Texture2D traxAO;

			public TextureChannel traxAOChannel = TextureChannel.G;

			public Texture2D splat;

			public void Reset()
			{
				diffuse = null;
				height = null;
				normal = null;
				smoothness = null;
				specular = null;
				ao = null;
				isRoughness = false;
				detailNoise = null;
				distanceNoise = null;
				metal = null;
				emis = null;
				heightChannel = TextureChannel.G;
				smoothnessChannel = TextureChannel.G;
				aoChannel = TextureChannel.G;
				distanceChannel = TextureChannel.G;
				detailChannel = TextureChannel.G;
				traxDiffuse = null;
				traxNormal = null;
				traxHeight = null;
				traxSmoothness = null;
				traxAO = null;
				traxHeightChannel = TextureChannel.G;
				traxSmoothnessChannel = TextureChannel.G;
				traxAOChannel = TextureChannel.G;
				splat = null;
			}

			public bool HasTextures(PBRWorkflow wf)
			{
				if (wf == PBRWorkflow.Specular)
				{
					if (!(diffuse != null) && !(height != null) && !(normal != null) && !(smoothness != null) && !(specular != null))
					{
						return ao != null;
					}
					return true;
				}
				if (!(diffuse != null) && !(height != null) && !(normal != null) && !(smoothness != null) && !(metal != null))
				{
					return ao != null;
				}
				return true;
			}
		}

		public bool diffuseIsLinear;

		[HideInInspector]
		public bool antiTileArray;

		[HideInInspector]
		public bool emisMetalArray;

		public bool traxArray;

		[HideInInspector]
		public TextureMode textureMode = TextureMode.PBR;

		[HideInInspector]
		public ClusterMode clusterMode;

		[HideInInspector]
		public PackingMode packingMode;

		[HideInInspector]
		public PBRWorkflow pbrWorkflow;

		[HideInInspector]
		public int hash;

		[HideInInspector]
		public Texture2DArray splatArray;

		[HideInInspector]
		public Texture2DArray diffuseArray;

		[HideInInspector]
		public Texture2DArray normalSAOArray;

		[HideInInspector]
		public Texture2DArray smoothAOArray;

		[HideInInspector]
		public Texture2DArray specularArray;

		[HideInInspector]
		public Texture2DArray diffuseArray2;

		[HideInInspector]
		public Texture2DArray normalSAOArray2;

		[HideInInspector]
		public Texture2DArray smoothAOArray2;

		[HideInInspector]
		public Texture2DArray specularArray2;

		[HideInInspector]
		public Texture2DArray diffuseArray3;

		[HideInInspector]
		public Texture2DArray normalSAOArray3;

		[HideInInspector]
		public Texture2DArray smoothAOArray3;

		[HideInInspector]
		public Texture2DArray specularArray3;

		[HideInInspector]
		public Texture2DArray emisArray;

		[HideInInspector]
		public Texture2DArray emisArray2;

		[HideInInspector]
		public Texture2DArray emisArray3;

		public TextureArrayGroup defaultTextureSettings = new TextureArrayGroup();

		public List<PlatformTextureOverride> platformOverrides = new List<PlatformTextureOverride>();

		public SourceTextureSize sourceTextureSize;

		[HideInInspector]
		public AllTextureChannel allTextureChannelHeight = AllTextureChannel.G;

		[HideInInspector]
		public AllTextureChannel allTextureChannelSmoothness = AllTextureChannel.G;

		[HideInInspector]
		public AllTextureChannel allTextureChannelAO = AllTextureChannel.G;

		[HideInInspector]
		public List<TextureEntry> sourceTextures = new List<TextureEntry>();

		[HideInInspector]
		public List<TextureEntry> sourceTextures2 = new List<TextureEntry>();

		[HideInInspector]
		public List<TextureEntry> sourceTextures3 = new List<TextureEntry>();

		public bool IsScatter()
		{
			return false;
		}

		public bool IsStarReach()
		{
			return false;
		}

		public bool IsDecal()
		{
			return false;
		}

		public bool IsDecalSplat()
		{
			return false;
		}

		public bool HasTerrainLayer(TerrainLayer l)
		{
			foreach (TextureEntry sourceTexture in sourceTextures)
			{
				if (sourceTexture.diffuse == l.diffuseTexture && sourceTexture.normal == l.normalMapTexture && sourceTexture.diffuse != null)
				{
					return true;
				}
			}
			return false;
		}

		public void AddTerrainLayer(TerrainLayer l)
		{
			TextureEntry textureEntry = new TextureEntry();
			textureEntry.terrainLayer = l;
			textureEntry.diffuse = l.diffuseTexture;
			textureEntry.normal = l.normalMapTexture;
			textureEntry.ao = l.maskMapTexture;
			textureEntry.smoothness = l.maskMapTexture;
			textureEntry.height = l.maskMapTexture;
			textureEntry.aoChannel = TextureChannel.G;
			textureEntry.smoothnessChannel = TextureChannel.A;
			textureEntry.heightChannel = TextureChannel.B;
			sourceTextures.Add(textureEntry);
			if (clusterMode == ClusterMode.TwoVariations)
			{
				sourceTextures2.Add(textureEntry);
			}
			if (clusterMode == ClusterMode.ThreeVariations)
			{
				sourceTextures3.Add(textureEntry);
			}
		}
	}
}
