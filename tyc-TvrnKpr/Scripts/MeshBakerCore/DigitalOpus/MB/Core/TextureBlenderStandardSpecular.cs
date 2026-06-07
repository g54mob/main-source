using UnityEngine;

namespace DigitalOpus.MB.Core
{
	public class TextureBlenderStandardSpecular : TextureBlender
	{
		private enum Prop
		{
			doColor = 0,
			doSpecular = 1,
			doEmission = 2,
			doBump = 3,
			doNone = 4
		}

		private static Color NeutralNormalMap;

		private TextureBlenderMaterialPropertyCacheHelper sourceMaterialPropertyCache;

		private Color m_tintColor;

		private bool m_doScaleAlphaCutoff;

		private float m_alphaCutoff;

		private float m_glossiness;

		private float m_SpecGlossMapScale;

		private Color m_specColor;

		private bool m_hasSpecGlossMap;

		private float m_bumpScale;

		private bool m_shaderDoesEmission;

		private Color m_emissionColor;

		private Prop propertyToDo;

		private Color m_generatingTintedAtlaColor;

		private Color m_generatingTintedAtlaSpecular;

		private float m_generatingTintedAtlaGlossiness;

		private float m_generatingTintedAtlaSpecGlossMapScale;

		private float m_generatingTintedAtlaBumpScale;

		private Color m_generatingTintedAtlaEmission;

		private const float m_generatedAlphaCutoff = 0.5f;

		private Color m_notGeneratingAtlasDefaultColor;

		private Color m_notGeneratingAtlasDefaultSpecularColor;

		private float m_notGeneratingAtlasDefaultGlossiness;

		private Color m_notGeneratingAtlasDefaultEmisionColor;

		public bool DoesShaderNameMatch(string shaderName)
		{
			return false;
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
