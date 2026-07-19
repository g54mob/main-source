using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace UniGLTF.ShaderPropExporter
{
	public static class PreShaderPropExporter
	{
		private static Dictionary<string, ShaderProps> m_shaderPropMap;

		[PreExportShader]
		private static KeyValuePair<string, ShaderProps> Standard => new KeyValuePair<string, ShaderProps>("Standard", new ShaderProps
		{
			Properties = new ShaderProperty[27]
			{
				new ShaderProperty("_Color", ShaderPropertyType.Color),
				new ShaderProperty("_MainTex", ShaderPropertyType.TexEnv),
				new ShaderProperty("_Cutoff", ShaderPropertyType.Range),
				new ShaderProperty("_Glossiness", ShaderPropertyType.Range),
				new ShaderProperty("_GlossMapScale", ShaderPropertyType.Range),
				new ShaderProperty("_SmoothnessTextureChannel", ShaderPropertyType.Float),
				new ShaderProperty("_Metallic", ShaderPropertyType.Range),
				new ShaderProperty("_MetallicGlossMap", ShaderPropertyType.TexEnv),
				new ShaderProperty("_SpecularHighlights", ShaderPropertyType.Float),
				new ShaderProperty("_GlossyReflections", ShaderPropertyType.Float),
				new ShaderProperty("_BumpScale", ShaderPropertyType.Float),
				new ShaderProperty("_BumpMap", ShaderPropertyType.TexEnv),
				new ShaderProperty("_Parallax", ShaderPropertyType.Range),
				new ShaderProperty("_ParallaxMap", ShaderPropertyType.TexEnv),
				new ShaderProperty("_OcclusionStrength", ShaderPropertyType.Range),
				new ShaderProperty("_OcclusionMap", ShaderPropertyType.TexEnv),
				new ShaderProperty("_EmissionColor", ShaderPropertyType.Color),
				new ShaderProperty("_EmissionMap", ShaderPropertyType.TexEnv),
				new ShaderProperty("_DetailMask", ShaderPropertyType.TexEnv),
				new ShaderProperty("_DetailAlbedoMap", ShaderPropertyType.TexEnv),
				new ShaderProperty("_DetailNormalMapScale", ShaderPropertyType.Float),
				new ShaderProperty("_DetailNormalMap", ShaderPropertyType.TexEnv),
				new ShaderProperty("_UVSec", ShaderPropertyType.Float),
				new ShaderProperty("_Mode", ShaderPropertyType.Float),
				new ShaderProperty("_SrcBlend", ShaderPropertyType.Float),
				new ShaderProperty("_DstBlend", ShaderPropertyType.Float),
				new ShaderProperty("_ZWrite", ShaderPropertyType.Float)
			}
		});

		[PreExportShader]
		private static KeyValuePair<string, ShaderProps> UniGLTF_UniUnlit => new KeyValuePair<string, ShaderProps>("UniGLTF/UniUnlit", new ShaderProps
		{
			Properties = new ShaderProperty[9]
			{
				new ShaderProperty("_MainTex", ShaderPropertyType.TexEnv),
				new ShaderProperty("_Color", ShaderPropertyType.Color),
				new ShaderProperty("_Cutoff", ShaderPropertyType.Range),
				new ShaderProperty("_BlendMode", ShaderPropertyType.Float),
				new ShaderProperty("_CullMode", ShaderPropertyType.Float),
				new ShaderProperty("_VColBlendMode", ShaderPropertyType.Float),
				new ShaderProperty("_SrcBlend", ShaderPropertyType.Float),
				new ShaderProperty("_DstBlend", ShaderPropertyType.Float),
				new ShaderProperty("_ZWrite", ShaderPropertyType.Float)
			}
		});

		[PreExportShader]
		private static KeyValuePair<string, ShaderProps> Unlit_Color => new KeyValuePair<string, ShaderProps>("Unlit/Color", new ShaderProps
		{
			Properties = new ShaderProperty[1]
			{
				new ShaderProperty("_Color", ShaderPropertyType.Color)
			}
		});

		[PreExportShader]
		private static KeyValuePair<string, ShaderProps> Unlit_Texture => new KeyValuePair<string, ShaderProps>("Unlit/Texture", new ShaderProps
		{
			Properties = new ShaderProperty[1]
			{
				new ShaderProperty("_MainTex", ShaderPropertyType.TexEnv)
			}
		});

		[PreExportShader]
		private static KeyValuePair<string, ShaderProps> Unlit_Transparent => new KeyValuePair<string, ShaderProps>("Unlit/Transparent", new ShaderProps
		{
			Properties = new ShaderProperty[1]
			{
				new ShaderProperty("_MainTex", ShaderPropertyType.TexEnv)
			}
		});

		[PreExportShader]
		private static KeyValuePair<string, ShaderProps> Unlit_Transparent_Cutout => new KeyValuePair<string, ShaderProps>("Unlit/Transparent Cutout", new ShaderProps
		{
			Properties = new ShaderProperty[2]
			{
				new ShaderProperty("_MainTex", ShaderPropertyType.TexEnv),
				new ShaderProperty("_Cutoff", ShaderPropertyType.Range)
			}
		});

		[PreExportShader]
		private static KeyValuePair<string, ShaderProps> VRM_MToon => new KeyValuePair<string, ShaderProps>("VRM/MToon", new ShaderProps
		{
			Properties = new ShaderProperty[42]
			{
				new ShaderProperty("_Cutoff", ShaderPropertyType.Range),
				new ShaderProperty("_Color", ShaderPropertyType.Color),
				new ShaderProperty("_ShadeColor", ShaderPropertyType.Color),
				new ShaderProperty("_MainTex", ShaderPropertyType.TexEnv),
				new ShaderProperty("_ShadeTexture", ShaderPropertyType.TexEnv),
				new ShaderProperty("_BumpScale", ShaderPropertyType.Float),
				new ShaderProperty("_BumpMap", ShaderPropertyType.TexEnv),
				new ShaderProperty("_ReceiveShadowRate", ShaderPropertyType.Range),
				new ShaderProperty("_ReceiveShadowTexture", ShaderPropertyType.TexEnv),
				new ShaderProperty("_ShadingGradeRate", ShaderPropertyType.Range),
				new ShaderProperty("_ShadingGradeTexture", ShaderPropertyType.TexEnv),
				new ShaderProperty("_ShadeShift", ShaderPropertyType.Range),
				new ShaderProperty("_ShadeToony", ShaderPropertyType.Range),
				new ShaderProperty("_LightColorAttenuation", ShaderPropertyType.Range),
				new ShaderProperty("_IndirectLightIntensity", ShaderPropertyType.Range),
				new ShaderProperty("_RimColor", ShaderPropertyType.Color),
				new ShaderProperty("_RimTexture", ShaderPropertyType.TexEnv),
				new ShaderProperty("_RimLightingMix", ShaderPropertyType.Range),
				new ShaderProperty("_RimFresnelPower", ShaderPropertyType.Range),
				new ShaderProperty("_RimLift", ShaderPropertyType.Range),
				new ShaderProperty("_SphereAdd", ShaderPropertyType.TexEnv),
				new ShaderProperty("_EmissionColor", ShaderPropertyType.Color),
				new ShaderProperty("_EmissionMap", ShaderPropertyType.TexEnv),
				new ShaderProperty("_OutlineWidthTexture", ShaderPropertyType.TexEnv),
				new ShaderProperty("_OutlineWidth", ShaderPropertyType.Range),
				new ShaderProperty("_OutlineScaledMaxDistance", ShaderPropertyType.Range),
				new ShaderProperty("_OutlineColor", ShaderPropertyType.Color),
				new ShaderProperty("_OutlineLightingMix", ShaderPropertyType.Range),
				new ShaderProperty("_UvAnimMaskTexture", ShaderPropertyType.TexEnv),
				new ShaderProperty("_UvAnimScrollX", ShaderPropertyType.Float),
				new ShaderProperty("_UvAnimScrollY", ShaderPropertyType.Float),
				new ShaderProperty("_UvAnimRotation", ShaderPropertyType.Float),
				new ShaderProperty("_MToonVersion", ShaderPropertyType.Float),
				new ShaderProperty("_DebugMode", ShaderPropertyType.Float),
				new ShaderProperty("_BlendMode", ShaderPropertyType.Float),
				new ShaderProperty("_OutlineWidthMode", ShaderPropertyType.Float),
				new ShaderProperty("_OutlineColorMode", ShaderPropertyType.Float),
				new ShaderProperty("_CullMode", ShaderPropertyType.Float),
				new ShaderProperty("_OutlineCullMode", ShaderPropertyType.Float),
				new ShaderProperty("_SrcBlend", ShaderPropertyType.Float),
				new ShaderProperty("_DstBlend", ShaderPropertyType.Float),
				new ShaderProperty("_ZWrite", ShaderPropertyType.Float)
			}
		});

		[PreExportShader]
		private static KeyValuePair<string, ShaderProps> VRM_UnlitCutout => new KeyValuePair<string, ShaderProps>("VRM/UnlitCutout", new ShaderProps
		{
			Properties = new ShaderProperty[2]
			{
				new ShaderProperty("_MainTex", ShaderPropertyType.TexEnv),
				new ShaderProperty("_Cutoff", ShaderPropertyType.Range)
			}
		});

		[PreExportShader]
		private static KeyValuePair<string, ShaderProps> VRM_UnlitTexture => new KeyValuePair<string, ShaderProps>("VRM/UnlitTexture", new ShaderProps
		{
			Properties = new ShaderProperty[1]
			{
				new ShaderProperty("_MainTex", ShaderPropertyType.TexEnv)
			}
		});

		[PreExportShader]
		private static KeyValuePair<string, ShaderProps> VRM_UnlitTransparent => new KeyValuePair<string, ShaderProps>("VRM/UnlitTransparent", new ShaderProps
		{
			Properties = new ShaderProperty[1]
			{
				new ShaderProperty("_MainTex", ShaderPropertyType.TexEnv)
			}
		});

		[PreExportShader]
		private static KeyValuePair<string, ShaderProps> VRM_UnlitTransparentZWrite => new KeyValuePair<string, ShaderProps>("VRM/UnlitTransparentZWrite", new ShaderProps
		{
			Properties = new ShaderProperty[1]
			{
				new ShaderProperty("_MainTex", ShaderPropertyType.TexEnv)
			}
		});

		public static ShaderProps GetPropsForSupportedShader(string shaderName)
		{
			if (m_shaderPropMap == null)
			{
				m_shaderPropMap = new Dictionary<string, ShaderProps>();
				PropertyInfo[] properties = typeof(PreShaderPropExporter).GetProperties(BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic);
				foreach (PropertyInfo propertyInfo in properties)
				{
					if (propertyInfo.GetCustomAttributes(typeof(PreExportShaderAttribute), inherit: true).Any())
					{
						KeyValuePair<string, ShaderProps> keyValuePair = (KeyValuePair<string, ShaderProps>)propertyInfo.GetValue(null, null);
						m_shaderPropMap.Add(keyValuePair.Key, keyValuePair.Value);
					}
				}
			}
			if (m_shaderPropMap.TryGetValue(shaderName, out var value))
			{
				return value;
			}
			return null;
		}
	}
}
