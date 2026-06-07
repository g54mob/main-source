using UnityEngine;

namespace DigitalOpus.MB.Core
{
	public class TextureBlenderHDRPLit : TextureBlender
	{
		private enum Prop
		{
			doColor = 0,
			doMask = 1,
			doSpecular = 2,
			doEmission = 3,
			doNone = 4
		}

		private enum MaterialType
		{
			unknown = 0,
			subsurfaceScattering = 1,
			standard = 2,
			anisotropy = 3,
			iridescence = 4,
			specularColor = 5,
			translucent = 6
		}

		private TextureBlenderMaterialPropertyCacheHelper sourceMaterialPropertyCache;

		private MaterialType m_materialType;

		private Color m_tintColor;

		private bool m_hasMaskMap;

		private float m_smoothness;

		private float m_metallic;

		private bool m_hasSpecMap;

		private Color m_specularColor;

		private Color m_emissiveColor;

		private Prop propertyToDo;

		private Color m_generatingTintedAtlaColor;

		private Color m_generatingTintedAtlaSpecular;

		private Color m_generatingTintedAtlaEmission;

		private Color m_notGeneratingAtlasDefaultColor;

		private float m_notGeneratingAtlasDefaultMetallic;

		private float m_notGeneratingAtlasDefaultSmoothness;

		private Color m_notGeneratingAtlasDefaultSpecular;

		private Color m_notGeneratingAtlasDefaultEmissiveColor;

		public bool DoesShaderNameMatch(string shaderName)
		{
			return false;
		}

		private MaterialType _MapFloatToMaterialType(float materialType)
		{
			return default(MaterialType);
		}

		private float _MapMaterialTypeToFloat(MaterialType materialType)
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
