using System;
using UnityEngine;

namespace TH20
{
	public static class TH20Standard
	{
		public enum WorkflowMode
		{
			Specular = 0,
			Metallic = 1,
			Dielectric = 2
		}

		public enum SmoothnessMapChannel
		{
			SpecularMetallicAlpha = 0,
			AlbedoAlpha = 1
		}

		public enum BlendMode
		{
			Opaque = 0,
			Cutout = 1,
			Fade = 2,
			Transparent = 3,
			Dithered = 4
		}

		public static readonly string ShaderName = "TH20 Standard";

		private static readonly string _modeString = "_Mode";

		private static readonly string _highlightableString = "_Highlightable";

		private static readonly string _grayAnatomyString = "_GrayAnatomyEffect";

		private static readonly string _grayAnatomyStrengthString = "_GrayAnatomyRGB";

		private static readonly string _grayAnatomyKeywordString = "_GRAYANATOMYEFFECT_ON";

		private static readonly string _emissionColorString = "_EmissionColor";

		private static readonly string _roomLightingOffString = "_APPLYROOMLIGHTING_OFF";

		private static Shader _th20Shader;

		private static bool _hasBuildEffectID;

		private static bool _hasStartTimeID;

		private static int _buildEffectID;

		private static int _startTimeID;

		public static bool IsTH20Standard(Material material)
		{
			if (_th20Shader == null)
			{
				_th20Shader = Shader.Find(ShaderName);
			}
			return material.shader == _th20Shader;
		}

		public static bool IsHighlightable(Material material)
		{
			return Mathf.Approximately(material.GetFloat(_highlightableString), 1f);
		}

		public static bool IsPlayingBuildingEffect(Material material)
		{
			if (!_hasBuildEffectID)
			{
				_buildEffectID = Shader.PropertyToID("_BuildEffect");
				_hasBuildEffectID = true;
			}
			if (!_hasStartTimeID)
			{
				_startTimeID = Shader.PropertyToID("_StartTime");
				_hasStartTimeID = true;
			}
			if (Mathf.Approximately(material.GetFloat(_buildEffectID), 1f))
			{
				return GameTime.unscaledTime - material.GetFloat(_startTimeID) < 1.2f;
			}
			return false;
		}

		public static Color GetEmissiveColor(Material material)
		{
			return material.GetColor(_emissionColorString);
		}

		public static void SetEmissiveColor(Material material, Color color)
		{
			material.SetColor(_emissionColorString, color);
		}

		public static BlendMode GetBlendMode(Material material)
		{
			return (BlendMode)material.GetFloat(_modeString);
		}

		public static bool GetGrayAnatomyEffectState(Material material)
		{
			return Mathf.Approximately(material.GetFloat(_grayAnatomyString), 1f);
		}

		public static void SetGrayAnatomyEffectState(Material material, bool state)
		{
			SetKeyword(material, _grayAnatomyKeywordString, state);
			material.SetFloat(_grayAnatomyString, state ? 1f : 0f);
		}

		public static void SetGrayAnatomyRGBStrength(Material material, Vector3 strength)
		{
			material.SetVector(_grayAnatomyStrengthString, strength);
		}

		public static void SetBlendMode(Material material, BlendMode blendMode)
		{
			material.SetFloat(_modeString, (float)blendMode);
			switch (blendMode)
			{
			case BlendMode.Opaque:
				material.SetOverrideTag("RenderType", "");
				material.SetInt("_SrcBlend", 1);
				material.SetInt("_DstBlend", 0);
				material.SetInt("_ZWrite", 1);
				material.DisableKeyword("_ALPHATEST_ON");
				material.DisableKeyword("_ALPHABLEND_ON");
				material.DisableKeyword("_ALPHAPREMULTIPLY_ON");
				material.DisableKeyword("_ALPHADITHERED_ON");
				material.renderQueue = -1;
				break;
			case BlendMode.Cutout:
				material.SetOverrideTag("RenderType", "TransparentCutout");
				material.SetInt("_SrcBlend", 1);
				material.SetInt("_DstBlend", 0);
				material.SetInt("_ZWrite", 1);
				material.EnableKeyword("_ALPHATEST_ON");
				material.DisableKeyword("_ALPHABLEND_ON");
				material.DisableKeyword("_ALPHAPREMULTIPLY_ON");
				material.DisableKeyword("_ALPHADITHERED_ON");
				material.renderQueue = 2450;
				break;
			case BlendMode.Fade:
				material.SetOverrideTag("RenderType", "Transparent");
				material.SetInt("_SrcBlend", 5);
				material.SetInt("_DstBlend", 10);
				material.SetInt("_ZWrite", 0);
				material.DisableKeyword("_ALPHATEST_ON");
				material.EnableKeyword("_ALPHABLEND_ON");
				material.DisableKeyword("_ALPHAPREMULTIPLY_ON");
				material.DisableKeyword("_ALPHADITHERED_ON");
				material.renderQueue = 3000;
				break;
			case BlendMode.Transparent:
				material.SetOverrideTag("RenderType", "Transparent");
				material.SetInt("_SrcBlend", 1);
				material.SetInt("_DstBlend", 10);
				material.SetInt("_ZWrite", 0);
				material.DisableKeyword("_ALPHATEST_ON");
				material.DisableKeyword("_ALPHABLEND_ON");
				material.EnableKeyword("_ALPHAPREMULTIPLY_ON");
				material.DisableKeyword("_ALPHADITHERED_ON");
				material.renderQueue = 3000;
				break;
			case BlendMode.Dithered:
				material.SetOverrideTag("RenderType", "");
				material.SetInt("_SrcBlend", 1);
				material.SetInt("_DstBlend", 0);
				material.SetInt("_ZWrite", 1);
				material.DisableKeyword("_ALPHATEST_ON");
				material.DisableKeyword("_ALPHABLEND_ON");
				material.DisableKeyword("_ALPHAPREMULTIPLY_ON");
				material.EnableKeyword("_ALPHADITHERED_ON");
				material.renderQueue = -1;
				break;
			}
			if (material.HasProperty("_ForceZWrite"))
			{
				int num = material.GetInt("_ForceZWrite");
				if (num != 0)
				{
					material.SetInt("_ZWrite", num);
				}
			}
		}

		public static void SetMaterialKeywords(Material material, WorkflowMode workflowMode = WorkflowMode.Metallic)
		{
			SetKeyword(material, "_NORMALMAP", (bool)material.GetTexture("_BumpMap") || (bool)material.GetTexture("_DetailNormalMap"));
			switch (workflowMode)
			{
			case WorkflowMode.Specular:
				SetKeyword(material, "_SPECGLOSSMAP", material.GetTexture("_SpecGlossMap"));
				break;
			case WorkflowMode.Metallic:
				SetKeyword(material, "_METALLICGLOSSMAP", material.GetTexture("_MetallicGlossMap"));
				break;
			}
			SetKeyword(material, "_PARALLAXMAP", material.GetTexture("_ParallaxMap"));
			SetKeyword(material, "_DETAIL_MULX2", (bool)material.GetTexture("_DetailAlbedoMap") || (bool)material.GetTexture("_DetailNormalMap"));
			FixupEmissiveFlag(material);
			bool state = (material.globalIlluminationFlags & MaterialGlobalIlluminationFlags.EmissiveIsBlack) == 0;
			SetKeyword(material, "_EMISSION", state);
			if (material.HasProperty("_SmoothnessTextureChannel"))
			{
				SetKeyword(material, "_SMOOTHNESS_TEXTURE_ALBEDO_CHANNEL_A", GetSmoothnessMapChannel(material) == SmoothnessMapChannel.AlbedoAlpha);
			}
		}

		public static void FixupEmissiveFlag(Material mat)
		{
			if (mat == null)
			{
				throw new ArgumentNullException("mat");
			}
			mat.globalIlluminationFlags = FixupEmissiveFlag(mat.GetColor("_EmissionColor"), mat.globalIlluminationFlags);
		}

		public static MaterialGlobalIlluminationFlags FixupEmissiveFlag(Color col, MaterialGlobalIlluminationFlags flags)
		{
			if ((flags & MaterialGlobalIlluminationFlags.BakedEmissive) != MaterialGlobalIlluminationFlags.None && (double)col.maxColorComponent == 0.0)
			{
				flags |= MaterialGlobalIlluminationFlags.EmissiveIsBlack;
			}
			else if (flags != MaterialGlobalIlluminationFlags.EmissiveIsBlack)
			{
				flags &= MaterialGlobalIlluminationFlags.AnyEmissive;
			}
			return flags;
		}

		public static SmoothnessMapChannel GetSmoothnessMapChannel(Material material)
		{
			if ((int)material.GetFloat("_SmoothnessTextureChannel") == 1)
			{
				return SmoothnessMapChannel.AlbedoAlpha;
			}
			return SmoothnessMapChannel.SpecularMetallicAlpha;
		}

		private static void SetKeyword(Material m, string keyword, bool state)
		{
			if (state)
			{
				m.EnableKeyword(keyword);
			}
			else
			{
				m.DisableKeyword(keyword);
			}
		}

		public static bool ShouldEmissionBeEnabled(Material mat, Color color)
		{
			bool flag = (mat.globalIlluminationFlags & MaterialGlobalIlluminationFlags.RealtimeEmissive) > MaterialGlobalIlluminationFlags.None;
			return color.maxColorComponent > 0.00039215686f || flag;
		}

		public static bool IsRoomLightingEnabled(Material material)
		{
			return !material.IsKeywordEnabled(_roomLightingOffString);
		}

		public static void EnableRoomLighting(Material material)
		{
			material.DisableKeyword(_roomLightingOffString);
		}

		public static void DisableRoomLighting(Material material)
		{
			material.EnableKeyword(_roomLightingOffString);
		}
	}
}
