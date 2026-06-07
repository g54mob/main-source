using UnityEngine;

namespace DigitalOpus.MB.Core
{
	public class TextureBlenderURPLit : TextureBlender
	{
		private enum Prop
		{
			doColor = 0,
			doSpecular = 1,
			doMetallic = 2,
			doEmission = 3,
			doBump = 4,
			doNone = 5
		}

		private enum WorkflowMode
		{
			unknown = 0,
			metallic = 1,
			specular = 2
		}

		private enum SmoothnessTextureChannel
		{
			unknown = 0,
			albedo = 1,
			metallicSpecular = 2
		}

		private static Color NeutralNormalMap;

		private TextureBlenderMaterialPropertyCacheHelper sourceMaterialPropertyCache;

		private WorkflowMode m_workflowMode;

		private SmoothnessTextureChannel m_smoothnessTextureChannel;

		private Color m_tintColor;

		private bool m_doScaleAlphaCutoff;

		private float m_alphaCutoff;

		private float m_smoothness;

		private Color m_specColor;

		private bool m_hasSpecGlossMap;

		private float m_metallic;

		private bool m_hasMetallicGlossMap;

		private float m_bumpScale;

		private bool m_shaderDoesEmission;

		private Color m_emissionColor;

		private Prop propertyToDo;

		private Color m_generatingTintedAtlaColor;

		private float m_generatingTintedAtlasMetallic;

		private Color m_generatingTintedAtlaSpecular;

		private float m_generatingTintedAtlasMetallic_smoothness;

		private float m_generatingTintedAtlasSpecular_somoothness;

		private float m_generatingTintedAtlaBumpScale;

		private Color m_generatingTintedAtlaEmission;

		private const float m_generatedAlphaCutoff = 0.5f;

		private Color m_notGeneratingAtlasDefaultColor;

		private float m_notGeneratingAtlasDefaultMetallic;

		private float m_notGeneratingAtlasDefaultSmoothness_MetallicWorkflow;

		private float m_notGeneratingAtlasDefaultSmoothness_SpecularWorkflow;

		private Color m_notGeneratingAtlasDefaultSpecularColor;

		private Color m_notGeneratingAtlasDefaultEmisionColor;

		public bool DoesShaderNameMatch(string shaderName)
		{
			return false;
		}

		private WorkflowMode _MapFloatToWorkflowMode(float workflowMode)
		{
			return default(WorkflowMode);
		}

		private float _MapWorkflowModeToFloat(WorkflowMode workflowMode)
		{
			return 0f;
		}

		private SmoothnessTextureChannel _MapFloatToTextureChannel(float texChannel)
		{
			return default(SmoothnessTextureChannel);
		}

		private float _MapTextureChannelToFloat(SmoothnessTextureChannel workflowMode)
		{
			return 0f;
		}

		public void OnBeforeTintTexture(Material sourceMat, string shaderTexturePropertyName)
		{
		}

		public Color OnBlendTexturePixel(string propertyToDoshaderPropertyName, Color pixelColor)
		{
			return default(Color);
		}

		public bool NonTexturePropertiesAreEqual(Material a, Material b)
		{
			return false;
		}

		public void SetNonTexturePropertyValuesOnResultMaterial(Material resultMaterial)
		{
		}

		public Color GetColorIfNoTexture(Material mat, ShaderTextureProperty texPropertyName)
		{
			return default(Color);
		}
	}
}
