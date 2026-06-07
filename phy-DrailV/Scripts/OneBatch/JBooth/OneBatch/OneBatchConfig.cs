using System;
using System.Collections.Generic;
using UnityEngine;

namespace JBooth.OneBatch
{
	[CreateAssetMenu(menuName = "OneBatch/Config", order = 1)]
	[ExecuteInEditMode]
	public class OneBatchConfig : ScriptableObject
	{
		public enum PackingMode
		{
			Standard = 0,
			Packed = 1
		}

		public enum Compression
		{
			AutomaticCompressed = 0,
			ForceDXT = 1,
			ForcePVR = 2,
			ForceETC2 = 3,
			ForceASTC = 4,
			ForceCrunch = 5,
			Uncompressed = 6
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

		public enum TextureCompressionQuality
		{
			Low = 0,
			Medium = 1,
			High = 2
		}

		[Serializable]
		public class TextureArraySettings
		{
			public TextureSize textureWidth;

			public TextureSize textureHeight;

			public Compression compression;

			public TextureCompressionQuality quality = TextureCompressionQuality.Medium;

			public FilterMode filterMode;

			[Range(0f, 16f)]
			public int aniso = 1;

			public TextureArraySettings(TextureSize width, TextureSize height, Compression c, TextureCompressionQuality q, FilterMode f, int a = 1)
			{
				textureWidth = width;
				textureHeight = height;
				compression = c;
				quality = q;
				filterMode = f;
				aniso = a;
			}
		}

		[Serializable]
		public class TextureArrayGroup
		{
			public TextureArraySettings albedoSettings = new TextureArraySettings(TextureSize.k1024, TextureSize.k1024, Compression.AutomaticCompressed, TextureCompressionQuality.Medium, FilterMode.Bilinear);

			public TextureArraySettings normalSettings = new TextureArraySettings(TextureSize.k1024, TextureSize.k1024, Compression.AutomaticCompressed, TextureCompressionQuality.Medium, FilterMode.Bilinear);

			public TextureArraySettings metalSmoothSettings = new TextureArraySettings(TextureSize.k1024, TextureSize.k1024, Compression.AutomaticCompressed, TextureCompressionQuality.Medium, FilterMode.Bilinear);

			public TextureArraySettings emissiveSettings = new TextureArraySettings(TextureSize.k1024, TextureSize.k1024, Compression.AutomaticCompressed, TextureCompressionQuality.Medium, FilterMode.Bilinear);

			public TextureArraySettings heightSettings = new TextureArraySettings(TextureSize.k1024, TextureSize.k1024, Compression.AutomaticCompressed, TextureCompressionQuality.Medium, FilterMode.Bilinear);

			public TextureArraySettings aoSettings = new TextureArraySettings(TextureSize.k1024, TextureSize.k1024, Compression.AutomaticCompressed, TextureCompressionQuality.Medium, FilterMode.Bilinear);

			public TextureArraySettings detailAlbedoSettings = new TextureArraySettings(TextureSize.k1024, TextureSize.k1024, Compression.AutomaticCompressed, TextureCompressionQuality.Medium, FilterMode.Bilinear);

			public TextureArraySettings detailNormalSettings = new TextureArraySettings(TextureSize.k1024, TextureSize.k1024, Compression.AutomaticCompressed, TextureCompressionQuality.Medium, FilterMode.Bilinear);

			public TextureArraySettings detailMaskSettings = new TextureArraySettings(TextureSize.k1024, TextureSize.k1024, Compression.AutomaticCompressed, TextureCompressionQuality.Medium, FilterMode.Bilinear);

			public TextureArraySettings specularSettings = new TextureArraySettings(TextureSize.k1024, TextureSize.k1024, Compression.AutomaticCompressed, TextureCompressionQuality.Medium, FilterMode.Bilinear);

			public TextureArraySettings packedSettings = new TextureArraySettings(TextureSize.k1024, TextureSize.k1024, Compression.AutomaticCompressed, TextureCompressionQuality.Medium, FilterMode.Bilinear);
		}

		[Serializable]
		public class PlatformTextureOverride
		{
			public TextureArrayGroup settings = new TextureArrayGroup();
		}

		[Serializable]
		public class MaterialAttributes
		{
			public string sourceMatName;

			public Material originalMaterial;

			public Color tint;

			public Vector4 uvScaleOffset = new Vector4(1f, 1f, 0f, 0f);

			public float normalStrength = 1f;

			public float occlusionStrength = 1f;

			public float specularStrength = 1f;

			public float glossMapScale = 1f;

			public float metalStrength = 1f;

			public Color emissiveColor = Color.black;

			public Vector4 detailUVScaleOffset = new Vector4(1f, 1f, 0f, 0f);

			public float alphaCutoff = 0.5f;

			public Color specularColor = Color.black;

			public float detailNormalMapScale = 1f;

			public float parallaxHeight = 0.05f;

			public float uvSec;

			public int alphaMode;

			public bool specularWorkflow;

			public bool IsSame(MaterialAttributes at)
			{
				if (originalMaterial == at.originalMaterial)
				{
					return true;
				}
				if (at.tint != tint)
				{
					return false;
				}
				if (at.normalStrength != normalStrength)
				{
					return false;
				}
				if (at.occlusionStrength != occlusionStrength)
				{
					return false;
				}
				if (at.specularStrength != specularStrength)
				{
					return false;
				}
				if (at.glossMapScale != glossMapScale)
				{
					return false;
				}
				if (at.uvScaleOffset != uvScaleOffset)
				{
					return false;
				}
				if (at.metalStrength != metalStrength)
				{
					return false;
				}
				if (at.emissiveColor != emissiveColor)
				{
					return false;
				}
				if (at.detailUVScaleOffset != detailUVScaleOffset)
				{
					return false;
				}
				if (at.alphaCutoff != alphaCutoff)
				{
					return false;
				}
				if (at.specularColor != specularColor)
				{
					return false;
				}
				if (at.detailNormalMapScale != detailNormalMapScale)
				{
					return false;
				}
				if (at.parallaxHeight != parallaxHeight)
				{
					return false;
				}
				if (at.uvSec != uvSec)
				{
					return false;
				}
				if (at.alphaMode != alphaMode)
				{
					return false;
				}
				return true;
			}

			public static Texture2D NewTexture()
			{
				Texture2D texture2D = new Texture2D(8, 4, TextureFormat.RGBAHalf, mipChain: false, linear: true);
				for (int i = 0; i < 8; i++)
				{
					for (int j = 0; j < 4; j++)
					{
						texture2D.SetPixel(i, j, Color.black);
					}
				}
				texture2D.Apply();
				return texture2D;
			}

			public void Encode(ref Texture2D tex, int index, int textureArrayIndex)
			{
				if (index >= tex.height)
				{
					Texture2D texture2D = new Texture2D(tex.width, index + 1, TextureFormat.RGBAHalf, mipChain: false, linear: true);
					Color[] pixels = tex.GetPixels();
					texture2D.SetPixels(0, 0, tex.width, tex.height, pixels);
					tex = texture2D;
				}
				if (tex.width < 8)
				{
					Texture2D texture2D2 = new Texture2D(8, tex.height, TextureFormat.RGBAHalf, mipChain: false, linear: true);
					Color[] pixels2 = tex.GetPixels();
					texture2D2.SetPixels(0, 0, tex.width, tex.height, pixels2);
					tex = texture2D2;
				}
				tex.SetPixel(0, index, new Color(uvScaleOffset.x - 1f, uvScaleOffset.y - 1f, uvScaleOffset.z, uvScaleOffset.w));
				tex.SetPixel(1, index, new Color(normalStrength, occlusionStrength, specularStrength, metalStrength));
				tex.SetPixel(2, index, tint);
				tex.SetPixel(3, index, emissiveColor);
				tex.SetPixel(4, index, new Color(specularColor.r, specularColor.g, specularColor.b, glossMapScale));
				tex.SetPixel(5, index, new Color(detailUVScaleOffset.x, detailUVScaleOffset.y, detailUVScaleOffset.z, detailUVScaleOffset.w));
				tex.SetPixel(6, index, new Color(alphaCutoff, detailNormalMapScale, parallaxHeight, uvSec));
				tex.SetPixel(7, index, new Color(textureArrayIndex, textureArrayIndex, textureArrayIndex, textureArrayIndex));
				tex.Apply();
			}

			public void Extract(Material mat, OneBatchConfig cfg)
			{
				sourceMatName = mat.name;
				originalMaterial = mat;
				normalStrength = 1f;
				occlusionStrength = 1f;
				specularStrength = 1f;
				tint = Color.white;
				metalStrength = 1f;
				uvScaleOffset = new Vector4(1f, 1f, 0f, 0f);
				detailUVScaleOffset = new Vector4(1f, 1f, 0f, 0f);
				emissiveColor = Color.black;
				alphaCutoff = 0.5f;
				specularColor = Color.black;
				detailNormalMapScale = 1f;
				parallaxHeight = 0.05f;
				alphaMode = 0;
				glossMapScale = 0f;
				if (mat.shader.name == "Standard (Specular setup)")
				{
					specularWorkflow = true;
				}
				if (mat.HasProperty("_Color"))
				{
					tint = mat.GetColor("_Color");
				}
				if (mat.HasProperty("_MainTex") && mat.HasProperty("_MainTex_ST"))
				{
					uvScaleOffset = mat.GetVector("_MainTex_ST");
				}
				if (mat.HasProperty("_GlossMapScale"))
				{
					glossMapScale = mat.GetFloat("_GlossMapScale");
				}
				if (mat.HasProperty("_Glossiness"))
				{
					specularStrength = mat.GetFloat("_Glossiness");
				}
				if (mat.HasProperty("_Smoothness"))
				{
					specularStrength = mat.GetFloat("_Smoothness");
				}
				if (mat.HasProperty("_MetallicGlossMap") && mat.GetTexture("_MetallicGlossMap") != null)
				{
					specularStrength = glossMapScale;
				}
				if (mat.HasProperty("_SpecColor"))
				{
					specularColor = mat.GetColor("_SpecColor");
				}
				if (mat.HasProperty("_Metallic"))
				{
					metalStrength = mat.GetFloat("_Metallic");
				}
				if (mat.HasProperty("_OcclusionStrength"))
				{
					occlusionStrength = mat.GetFloat("_OcclusionStrength");
				}
				if (mat.HasProperty("_BumpScale"))
				{
					normalStrength = mat.GetFloat("_BumpScale");
				}
				if (mat.HasProperty("_DetailNormalMapScale"))
				{
					detailNormalMapScale = mat.GetFloat("_DetailNormalMapScale");
				}
				if (mat.HasProperty("_EmissionColor") && mat.HasProperty("_EmissionMap") && cfg.HasEmis())
				{
					emissiveColor = Color.black;
				}
				else if (mat.HasProperty("_EmissionColor"))
				{
					emissiveColor = mat.GetColor("_EmissionColor");
				}
				if (mat.HasProperty("_Parallax"))
				{
					parallaxHeight = mat.GetFloat("_Parallax");
				}
				if (mat.HasProperty("_UVSec"))
				{
					uvSec = mat.GetFloat("_UVSec");
				}
				if (mat.HasProperty("_DetailAlbedoMap") && mat.HasProperty("_DetailAlbedoMap_ST"))
				{
					detailUVScaleOffset = mat.GetVector("_DetailAlbedoMap_ST");
				}
				if (mat.HasProperty("_Mode"))
				{
					alphaMode = (int)mat.GetFloat("_Mode");
				}
			}
		}

		[Serializable]
		public class Restore
		{
			public Mesh originalMesh;

			public Material[] originalMaterials;

			public MeshFilter originalFilter;

			public MeshRenderer originalRenderer;

			public SkinnedMeshRenderer originalSkinRenderer;
		}

		[Serializable]
		public class MeshData
		{
			public Mesh[] outputMeshes;

			public Matrix4x4[] outputMatrix;

			public List<MeshFilter> filters;

			public List<MeshRenderer> renderers;

			public List<SkinnedMeshRenderer> skinnedRenderers;

			public Material[] originalMaterials;
		}

		[Serializable]
		public class CombineEntry
		{
			public Material mat;

			public MaterialAttributes meshAttrib;

			public List<MeshData> meshData = new List<MeshData>();
		}

		[Serializable]
		public class TextureEntry
		{
			public Texture2D albedo;

			public Texture2D height;

			public Texture2D normal;

			public Texture2D metalSmooth;

			public Texture2D ao;

			public Texture2D emis;

			public Texture2D detailMask;

			public Texture2D detailNormal;

			public Texture2D detailAlbedo;

			public Texture2D specular;

			public List<Restore> restores = new List<Restore>();

			public List<CombineEntry> combines = new List<CombineEntry>();

			public string displayData;

			public void Reset()
			{
				albedo = null;
				height = null;
				normal = null;
				metalSmooth = null;
				ao = null;
				detailAlbedo = null;
				emis = null;
				specular = null;
				detailNormal = null;
				detailMask = null;
				detailAlbedo = null;
				restores.Clear();
			}

			public bool HasTextures()
			{
				if (!(albedo != null) && !(height != null) && !(normal != null) && !(metalSmooth != null) && !(detailAlbedo != null) && !(detailNormal != null) && !(detailMask != null) && !(emis != null) && !(specular != null))
				{
					return ao != null;
				}
				return true;
			}
		}

		public bool generateLightmapUVs;

		public bool diffuseIsLinear;

		public PackingMode packingMode;

		public Material[] combinedMaterials;

		public List<GameObject> prefabs = new List<GameObject>();

		[HideInInspector]
		public int hash;

		public TextureArrayGroup defaultTextureSettings = new TextureArrayGroup();

		public List<PlatformTextureOverride> platformOverrides = new List<PlatformTextureOverride>();

		[HideInInspector]
		public List<TextureEntry> sourceTextures = new List<TextureEntry>();

		public bool HasNormal()
		{
			foreach (TextureEntry sourceTexture in sourceTextures)
			{
				if (sourceTexture.normal != null)
				{
					return true;
				}
			}
			return false;
		}

		public bool HasAO()
		{
			foreach (TextureEntry sourceTexture in sourceTextures)
			{
				if (sourceTexture.ao != null)
				{
					return true;
				}
			}
			return false;
		}

		public bool HasDetailAlbedo()
		{
			foreach (TextureEntry sourceTexture in sourceTextures)
			{
				if (sourceTexture.detailAlbedo != null)
				{
					return true;
				}
			}
			return false;
		}

		public bool HasDetailNormal()
		{
			foreach (TextureEntry sourceTexture in sourceTextures)
			{
				if (sourceTexture.detailNormal != null)
				{
					return true;
				}
			}
			return false;
		}

		public bool HasDetailMask()
		{
			foreach (TextureEntry sourceTexture in sourceTextures)
			{
				if (sourceTexture.detailMask != null)
				{
					return true;
				}
			}
			return false;
		}

		public bool HasEmis()
		{
			foreach (TextureEntry sourceTexture in sourceTextures)
			{
				if (sourceTexture.emis != null)
				{
					return true;
				}
			}
			return false;
		}

		public bool HasHeight()
		{
			foreach (TextureEntry sourceTexture in sourceTextures)
			{
				if (sourceTexture.height != null)
				{
					return true;
				}
			}
			return false;
		}

		public bool HasSpecular()
		{
			foreach (TextureEntry sourceTexture in sourceTextures)
			{
				if (sourceTexture.specular != null)
				{
					return true;
				}
			}
			return false;
		}

		public bool HasMetalSmooth()
		{
			foreach (TextureEntry sourceTexture in sourceTextures)
			{
				if (sourceTexture.metalSmooth != null)
				{
					return true;
				}
			}
			return false;
		}
	}
}
