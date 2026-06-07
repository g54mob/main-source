using UnityEngine;

namespace TriLib
{
	public class MaterialData
	{
		public string Name;

		public bool AlphaLoaded;

		public float Alpha;

		public bool DiffuseInfoLoaded;

		public string DiffusePath;

		public TextureWrapMode DiffuseWrapMode;

		public string DiffuseName;

		public float DiffuseBlendMode;

		public uint DiffuseOp;

		public EmbeddedTextureData DiffuseEmbeddedTextureData;

		public bool DiffuseColorLoaded;

		public Color DiffuseColor;

		public bool EmissionInfoLoaded;

		public string EmissionPath;

		public TextureWrapMode EmissionWrapMode;

		public string EmissionName;

		public float EmissionBlendMode;

		public uint EmissionOp;

		public EmbeddedTextureData EmissionEmbeddedTextureData;

		public bool EmissionColorLoaded;

		public Color EmissionColor;

		public bool SpecularInfoLoaded;

		public string SpecularPath;

		public TextureWrapMode SpecularWrapMode;

		public string SpecularName;

		public float SpecularBlendMode;

		public uint SpecularOp;

		public EmbeddedTextureData SpecularEmbeddedTextureData;

		public bool SpecularColorLoaded;

		public Color SpecularColor;

		public bool NormalInfoLoaded;

		public string NormalPath;

		public TextureWrapMode NormalWrapMode;

		public string NormalName;

		public float NormalBlendMode;

		public uint NormalOp;

		public EmbeddedTextureData NormalEmbeddedTextureData;

		public bool HeightInfoLoaded;

		public string HeightPath;

		public TextureWrapMode HeightWrapMode;

		public string HeightName;

		public float HeightBlendMode;

		public uint HeightOp;

		public EmbeddedTextureData HeightEmbeddedTextureData;

		public bool BumpScaleLoaded;

		public float BumpScale;

		public bool GlossinessLoaded;

		public float Glossiness;

		public bool GlossMapScaleLoaded;

		public float GlossMapScale;

		public bool OcclusionInfoLoaded;

		public string OcclusionPath;

		public TextureWrapMode OcclusionWrapMode;

		public string OcclusionName;

		public float OcclusionBlendMode;

		public uint OcclusionOp;

		public EmbeddedTextureData OcclusionEmbeddedTextureData;

		public bool MetallicInfoLoaded;

		public string MetallicPath;

		public TextureWrapMode MetallicWrapMode;

		public string MetallicName;

		public float MetallicBlendMode;

		public uint MetallicOp;

		public EmbeddedTextureData MetallicEmbeddedTextureData;

		public IMaterialProperty[] Properties;

		public Material Material;
	}
}
