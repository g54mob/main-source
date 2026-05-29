using System;
using UnityEngine;
using VisualDesignCafe.ShaderX;
using VisualDesignCafe.ShaderX.Materials;

namespace VisualDesignCafe.Nature
{
	public class NatureMaterial : LitMaterial
	{
		[Obsolete]
		public enum WindMode
		{
			Off = 0,
			Baked = 1,
			Automatic = 2
		}

		public enum ColorCorrectionMode
		{
			Tint = 0,
			HSL = 1
		}

		public enum InteractionMode
		{
			Off = 0,
			Pivot = 1,
			Vertex = 2
		}

		public enum LightingQuality
		{
			High = 0,
			Low = 1
		}

		public enum BlendMode
		{
			Add = 0,
			Overlay = 1
		}

		[ShaderProperty("_ScaleFade")]
		public Vector2 ScaleFade
		{
			get
			{
				return default(Vector2);
			}
			set
			{
			}
		}

		[ShaderProperty("_NatureRendererDistanceControl")]
		public bool NatureRendererControlsDistance
		{
			get
			{
				return false;
			}
			set
			{
			}
		}

		[ShaderProperty("_ColorCorrection")]
		public ColorCorrectionMode ColorCorrection
		{
			get
			{
				return default(ColorCorrectionMode);
			}
			set
			{
			}
		}

		[ShaderProperty("_HSL")]
		public Vector3 HSL
		{
			get
			{
				return default(Vector3);
			}
			set
			{
			}
		}

		[ShaderProperty("_HSLVariation")]
		public Vector3 HSLVariation
		{
			get
			{
				return default(Vector3);
			}
			set
			{
			}
		}

		[ShaderProperty("_TintVariation")]
		public Color TintVariation
		{
			get
			{
				return default(Color);
			}
			set
			{
			}
		}

		[ShaderProperty("_ColorVariationSpread")]
		public float ColorVariationSpread
		{
			get
			{
				return 0f;
			}
			set
			{
			}
		}

		[ShaderProperty("_VertexNormalStrength")]
		public float VertexNormalStrength
		{
			get
			{
				return 0f;
			}
			set
			{
			}
		}

		[ShaderProperty("_SecondaryMaps")]
		public float SecondaryMaps
		{
			get
			{
				return 0f;
			}
			set
			{
			}
		}

		[ShaderProperty("_SecondaryAlbedo")]
		public Texture SecondaryAlbedoMap
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		[ShaderProperty("_SecondaryGlossiness")]
		public float SecondaryGlossiness
		{
			get
			{
				return 0f;
			}
			set
			{
			}
		}

		[ShaderProperty("_SecondaryGlossRemap")]
		public Vector2 SecondaryGlossRemap
		{
			get
			{
				return default(Vector2);
			}
			set
			{
			}
		}

		[ShaderProperty("_SecondaryMetallic")]
		public float SecondaryMetallic
		{
			get
			{
				return 0f;
			}
			set
			{
			}
		}

		[ShaderProperty("_SecondaryMetallicGlossMap")]
		public Texture SecondaryMetallicGlossMap
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		[ShaderProperty("_SecondaryNormalMap")]
		public Texture SecondaryNormalMap
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		[ShaderProperty("_SecondaryNormalMapScale")]
		public float SecondaryNormalMapScale
		{
			get
			{
				return 0f;
			}
			set
			{
			}
		}

		[ShaderProperty("_SecondaryOcclusionMap")]
		public Texture SecondaryOcclusionMap
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		[ShaderProperty("_SecondaryOcclusionRemap")]
		public Vector2 SecondaryOcclusionRemap
		{
			get
			{
				return default(Vector2);
			}
			set
			{
			}
		}

		[ShaderProperty("_SecondaryPackedMap")]
		public Texture SecondaryPackedMap
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		public bool BakedMeshData
		{
			get
			{
				return false;
			}
			set
			{
			}
		}

		public float ObjectHeight
		{
			get
			{
				return 0f;
			}
			set
			{
			}
		}

		public float ObjectRadius
		{
			get
			{
				return 0f;
			}
			set
			{
			}
		}

		[ShaderProperty("_Wind")]
		public bool WindEnabled
		{
			get
			{
				return false;
			}
			set
			{
			}
		}

		[Obsolete("Use 'WindEnabled' and 'BakedMeshData' instead")]
		public WindMode Wind
		{
			get
			{
				return default(WindMode);
			}
			set
			{
			}
		}

		[ShaderProperty("_WindVariation")]
		public float WindVariation
		{
			get
			{
				return 0f;
			}
			set
			{
			}
		}

		[ShaderProperty("_WindStrength")]
		public float WindStrength
		{
			get
			{
				return 0f;
			}
			set
			{
			}
		}

		[ShaderProperty("_TurbulenceStrength")]
		public float TurbulenceStrength
		{
			get
			{
				return 0f;
			}
			set
			{
			}
		}

		[ShaderProperty("_RecalculateWindNormals")]
		public float RecalculateWindNormals
		{
			get
			{
				return 0f;
			}
			set
			{
			}
		}

		[ShaderProperty("_WindFade")]
		public Vector2 WindFade
		{
			get
			{
				return default(Vector2);
			}
			set
			{
			}
		}

		[ShaderProperty("_TrunkBendFactor")]
		public Vector2 TrunkBendFactor
		{
			get
			{
				return default(Vector2);
			}
			set
			{
			}
		}

		[ShaderProperty("_Interaction")]
		public float Interaction
		{
			get
			{
				return 0f;
			}
			set
			{
			}
		}

		[ShaderProperty("_InteractionDuration")]
		public float InteractionDuration
		{
			get
			{
				return 0f;
			}
			set
			{
			}
		}

		[ShaderProperty("_InteractionStrength")]
		public float InteractionStrength
		{
			get
			{
				return 0f;
			}
			set
			{
			}
		}

		[ShaderProperty("_InteractionPushDown")]
		public float InteractionPushDown
		{
			get
			{
				return 0f;
			}
			set
			{
			}
		}

		[ShaderProperty("_TranslucencyBlendMode")]
		public BlendMode TranslucencyBlendMode
		{
			get
			{
				return default(BlendMode);
			}
			set
			{
			}
		}

		[ShaderProperty("_TranslucencyStrength")]
		public float TranslucencyStrength
		{
			get
			{
				return 0f;
			}
			set
			{
			}
		}

		[ShaderProperty("_TranslucencyDistortion")]
		public float TranslucencyDistortion
		{
			get
			{
				return 0f;
			}
			set
			{
			}
		}

		[ShaderProperty("_TranslucencyScattering")]
		public float TranslucencyScattering
		{
			get
			{
				return 0f;
			}
			set
			{
			}
		}

		[ShaderProperty("_TranslucencyColor")]
		public float TranslucencyColor
		{
			get
			{
				return 0f;
			}
			set
			{
			}
		}

		[ShaderProperty("_TranslucencyAmbient")]
		public float TranslucencyAmbient
		{
			get
			{
				return 0f;
			}
			set
			{
			}
		}

		[ShaderProperty("_ThicknessMap")]
		public Texture ThicknessMap
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		[ShaderProperty("_ThicknessRemap")]
		public Vector2 ThicknessRemap
		{
			get
			{
				return default(Vector2);
			}
			set
			{
			}
		}

		[ShaderProperty("_Overlay")]
		public bool Overlay
		{
			get
			{
				return false;
			}
			set
			{
			}
		}

		[ShaderProperty("_SampleAlphaOverlay")]
		public bool SampleAlphaOverlay
		{
			get
			{
				return false;
			}
			set
			{
			}
		}

		[ShaderProperty("_SampleColorOverlay")]
		public bool SampleColorOverlay
		{
			get
			{
				return false;
			}
			set
			{
			}
		}

		[ShaderProperty("_PerspectiveCorrection")]
		public float PerspectiveCorrection
		{
			get
			{
				return 0f;
			}
			set
			{
			}
		}

		[ShaderProperty("_LightingQuality")]
		public LightingQuality Lighting
		{
			get
			{
				return default(LightingQuality);
			}
			set
			{
			}
		}

		public NatureMaterial(Material material)
			: base(null)
		{
		}

		public override void Validate(bool clean)
		{
		}

		private void ValidateMeshData()
		{
		}

		private void ValidateColorCorrection()
		{
		}

		private void ValidateWind()
		{
		}

		private void ValidateInteraction()
		{
		}

		private void ValidateOverlay()
		{
		}

		protected override void ValidateTranslucency()
		{
		}

		private void ValidateLightingQuality()
		{
		}

		private void ValidateSecondaryMaps()
		{
		}
	}
}
