using UnityEngine;

namespace VisualDesignCafe.ShaderX.Materials
{
	public class LitMaterial : BaseMaterial
	{
		public enum SurfaceMapMethod
		{
			None = 0,
			MetallicGloss = 1,
			Packed = 2
		}

		public enum DoubleSidedNormals
		{
			Same = 0,
			Flip = 1
		}

		[ShaderProperty("_AlphaTest")]
		public bool AlphaTest
		{
			get
			{
				return false;
			}
			set
			{
			}
		}

		[ShaderProperty("_AlphaTestThreshold")]
		public float AlphaTestThreshold
		{
			get
			{
				return 0f;
			}
			set
			{
			}
		}

		[ShaderProperty("_AlphaToMask")]
		public bool AlphaToMask
		{
			get
			{
				return false;
			}
			set
			{
			}
		}

		[ShaderProperty("_DoubleSidedMode")]
		public bool DoubleSided
		{
			get
			{
				return false;
			}
			set
			{
			}
		}

		[ShaderProperty("_DoubleSidedNormalMode")]
		public DoubleSidedNormals DoubleSidedNormalMode
		{
			get
			{
				return default(DoubleSidedNormals);
			}
			set
			{
			}
		}

		[ShaderProperty("_Tint")]
		public Color Tint
		{
			get
			{
				return default(Color);
			}
			set
			{
			}
		}

		[ShaderProperty("_Albedo")]
		public Texture AlbedoMap
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		[ShaderProperty("_NormalMap")]
		public Texture NormalMap
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		[ShaderProperty("_NormalMapScale")]
		public float NormalMapScale
		{
			get
			{
				return 0f;
			}
			set
			{
			}
		}

		[ShaderProperty("_SurfaceMapMethod")]
		public SurfaceMapMethod SurfaceMap
		{
			get
			{
				return default(SurfaceMapMethod);
			}
			set
			{
			}
		}

		[ShaderProperty("_PackedMap")]
		public Texture PackedMap
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		[ShaderProperty("_MetallicGlossMap")]
		public Texture MetallicGlossMap
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		[ShaderProperty("_OcclusionMap")]
		public Texture OcclusionMap
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		[ShaderProperty("_GlossRemap")]
		public Vector2 GlossRemap
		{
			get
			{
				return default(Vector2);
			}
			set
			{
			}
		}

		[ShaderProperty("_OcclusionRemap")]
		public Vector2 OcclusionRemap
		{
			get
			{
				return default(Vector2);
			}
			set
			{
			}
		}

		[ShaderProperty("_Glossiness")]
		public float Glossiness
		{
			get
			{
				return 0f;
			}
			set
			{
			}
		}

		[ShaderProperty("_Metallic")]
		public float Metallic
		{
			get
			{
				return 0f;
			}
			set
			{
			}
		}

		[ShaderProperty("_EmissionColor")]
		public Color EmissionColor
		{
			get
			{
				return default(Color);
			}
			set
			{
			}
		}

		[ShaderProperty("_EmissionMap")]
		public Texture EmissionMap
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		[ShaderProperty("_EmissionIntensity")]
		public float EmissionIntensity
		{
			get
			{
				return 0f;
			}
			set
			{
			}
		}

		[ShaderProperty("_EmissionExposureWeight")]
		public float EmissionExposureWeight
		{
			get
			{
				return 0f;
			}
			set
			{
			}
		}

		[ShaderProperty("_EmissionAffectedByAlbedo")]
		public bool EmissionAffectedByAlbedo
		{
			get
			{
				return false;
			}
			set
			{
			}
		}

		[ShaderProperty("_Translucency")]
		public bool Translucency
		{
			get
			{
				return false;
			}
			set
			{
			}
		}

		[ShaderProperty("_DiffusionProfileAsset")]
		public string DiffusionProfile
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		[ShaderProperty("_DiffusionProfileHash")]
		public uint DiffusionProfileHash
		{
			get
			{
				return 0u;
			}
			set
			{
			}
		}

		[ShaderProperty("_SpecularHighlights")]
		public bool SpecularHighlights
		{
			get
			{
				return false;
			}
			set
			{
			}
		}

		[ShaderProperty("_MotionVectors")]
		public bool MotionVectors
		{
			get
			{
				return false;
			}
			set
			{
			}
		}

		[ShaderProperty("_Decals")]
		public bool Decals
		{
			get
			{
				return false;
			}
			set
			{
			}
		}

		[ShaderProperty("_TemporalAntiAliasing")]
		public bool TemporalAntiAliasing
		{
			get
			{
				return false;
			}
			set
			{
			}
		}

		public static implicit operator Material(LitMaterial material)
		{
			return null;
		}

		public static implicit operator LitMaterial(Material material)
		{
			return null;
		}

		public LitMaterial(Material material)
			: base(null)
		{
		}

		public override void Validate(bool clean)
		{
		}

		private void ClearKeywords()
		{
		}

		private void ValidateSpecularHighlights()
		{
		}

		private void ValidateAlphaTest()
		{
		}

		private void ValidateNormalMap()
		{
		}

		protected virtual void ValidateTranslucency()
		{
		}

		private void ValidateSurfaceMap()
		{
		}

		private void ValidateEmission()
		{
		}

		private void ValidateDecals()
		{
		}

		private void ValidateAlphaToMask()
		{
		}

		private void ValidateRenderQueue()
		{
		}

		protected override bool GetMotionVectorsEnabled()
		{
			return false;
		}

		protected override void ValidatePasses(bool receivesSSR, bool useSplitLighting)
		{
		}

		private Vector4 ConvertGUIDToVector4(string guid)
		{
			return default(Vector4);
		}

		private string ConvertVector4ToGUID(Vector4 vector)
		{
			return null;
		}

		private float Asfloat(uint val)
		{
			return 0f;
		}

		private float Asfloat(int val)
		{
			return 0f;
		}

		private int Asint(float val)
		{
			return 0;
		}

		private uint Asuint(float val)
		{
			return 0u;
		}

		private uint GetDiffusionProfileHash(string assetGuid)
		{
			return 0u;
		}
	}
}
