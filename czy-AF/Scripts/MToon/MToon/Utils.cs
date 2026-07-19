using System;
using UnityEngine;

namespace MToon
{
	public static class Utils
	{
		public const string ShaderName = "VRM/MToon";

		public const string PropVersion = "_MToonVersion";

		public const string PropDebugMode = "_DebugMode";

		public const string PropOutlineWidthMode = "_OutlineWidthMode";

		public const string PropOutlineColorMode = "_OutlineColorMode";

		public const string PropBlendMode = "_BlendMode";

		public const string PropCullMode = "_CullMode";

		public const string PropOutlineCullMode = "_OutlineCullMode";

		public const string PropCutoff = "_Cutoff";

		public const string PropColor = "_Color";

		public const string PropShadeColor = "_ShadeColor";

		public const string PropMainTex = "_MainTex";

		public const string PropShadeTexture = "_ShadeTexture";

		public const string PropBumpScale = "_BumpScale";

		public const string PropBumpMap = "_BumpMap";

		public const string PropReceiveShadowRate = "_ReceiveShadowRate";

		public const string PropReceiveShadowTexture = "_ReceiveShadowTexture";

		public const string PropShadingGradeRate = "_ShadingGradeRate";

		public const string PropShadingGradeTexture = "_ShadingGradeTexture";

		public const string PropShadeShift = "_ShadeShift";

		public const string PropShadeToony = "_ShadeToony";

		public const string PropLightColorAttenuation = "_LightColorAttenuation";

		public const string PropIndirectLightIntensity = "_IndirectLightIntensity";

		public const string PropRimColor = "_RimColor";

		public const string PropRimTexture = "_RimTexture";

		public const string PropRimLightingMix = "_RimLightingMix";

		public const string PropRimFresnelPower = "_RimFresnelPower";

		public const string PropRimLift = "_RimLift";

		public const string PropSphereAdd = "_SphereAdd";

		public const string PropEmissionColor = "_EmissionColor";

		public const string PropEmissionMap = "_EmissionMap";

		public const string PropOutlineWidthTexture = "_OutlineWidthTexture";

		public const string PropOutlineWidth = "_OutlineWidth";

		public const string PropOutlineScaledMaxDistance = "_OutlineScaledMaxDistance";

		public const string PropOutlineColor = "_OutlineColor";

		public const string PropOutlineLightingMix = "_OutlineLightingMix";

		public const string PropUvAnimMaskTexture = "_UvAnimMaskTexture";

		public const string PropUvAnimScrollX = "_UvAnimScrollX";

		public const string PropUvAnimScrollY = "_UvAnimScrollY";

		public const string PropUvAnimRotation = "_UvAnimRotation";

		public const string PropSrcBlend = "_SrcBlend";

		public const string PropDstBlend = "_DstBlend";

		public const string PropZWrite = "_ZWrite";

		public const string PropAlphaToMask = "_AlphaToMask";

		public const string KeyNormalMap = "_NORMALMAP";

		public const string KeyAlphaTestOn = "_ALPHATEST_ON";

		public const string KeyAlphaBlendOn = "_ALPHABLEND_ON";

		public const string KeyAlphaPremultiplyOn = "_ALPHAPREMULTIPLY_ON";

		public const string KeyOutlineWidthWorld = "MTOON_OUTLINE_WIDTH_WORLD";

		public const string KeyOutlineWidthScreen = "MTOON_OUTLINE_WIDTH_SCREEN";

		public const string KeyOutlineColorFixed = "MTOON_OUTLINE_COLOR_FIXED";

		public const string KeyOutlineColorMixed = "MTOON_OUTLINE_COLOR_MIXED";

		public const string KeyDebugNormal = "MTOON_DEBUG_NORMAL";

		public const string KeyDebugLitShadeRate = "MTOON_DEBUG_LITSHADERATE";

		public const string TagRenderTypeKey = "RenderType";

		public const string TagRenderTypeValueOpaque = "Opaque";

		public const string TagRenderTypeValueTransparentCutout = "TransparentCutout";

		public const string TagRenderTypeValueTransparent = "Transparent";

		public const int DisabledIntValue = 0;

		public const int EnabledIntValue = 1;

		public const string Implementation = "Santarh/MToon";

		public const int VersionNumber = 33;

		public static RenderQueueRequirement GetRenderQueueRequirement(RenderMode renderMode)
		{
			return renderMode switch
			{
				RenderMode.Opaque => new RenderQueueRequirement
				{
					DefaultValue = -1,
					MinValue = -1,
					MaxValue = -1
				}, 
				RenderMode.Cutout => new RenderQueueRequirement
				{
					DefaultValue = 2450,
					MinValue = 2450,
					MaxValue = 2450
				}, 
				RenderMode.Transparent => new RenderQueueRequirement
				{
					DefaultValue = 3000,
					MinValue = 2951,
					MaxValue = 3000
				}, 
				RenderMode.TransparentWithZWrite => new RenderQueueRequirement
				{
					DefaultValue = 2501,
					MinValue = 2501,
					MaxValue = 2550
				}, 
				_ => throw new ArgumentOutOfRangeException("renderMode", renderMode, null), 
			};
		}

		public static MToonDefinition GetMToonParametersFromMaterial(Material material)
		{
			return new MToonDefinition
			{
				Meta = new MetaDefinition
				{
					Implementation = "Santarh/MToon",
					VersionNumber = material.GetInt("_MToonVersion")
				},
				Rendering = new RenderingDefinition
				{
					RenderMode = GetBlendMode(material),
					CullMode = GetCullMode(material),
					RenderQueueOffsetNumber = GetRenderQueueOffset(material, GetRenderQueueOriginMode(material))
				},
				Color = new ColorDefinition
				{
					LitColor = GetColor(material, "_Color"),
					LitMultiplyTexture = GetTexture(material, "_MainTex"),
					ShadeColor = GetColor(material, "_ShadeColor"),
					ShadeMultiplyTexture = GetTexture(material, "_ShadeTexture"),
					CutoutThresholdValue = GetValue(material, "_Cutoff")
				},
				Lighting = new LightingDefinition
				{
					LitAndShadeMixing = new LitAndShadeMixingDefinition
					{
						ShadingShiftValue = GetValue(material, "_ShadeShift"),
						ShadingToonyValue = GetValue(material, "_ShadeToony"),
						ShadowReceiveMultiplierValue = GetValue(material, "_ReceiveShadowRate"),
						ShadowReceiveMultiplierMultiplyTexture = GetTexture(material, "_ReceiveShadowTexture"),
						LitAndShadeMixingMultiplierValue = GetValue(material, "_ShadingGradeRate"),
						LitAndShadeMixingMultiplierMultiplyTexture = GetTexture(material, "_ShadingGradeTexture")
					},
					LightingInfluence = new LightingInfluenceDefinition
					{
						LightColorAttenuationValue = GetValue(material, "_LightColorAttenuation"),
						GiIntensityValue = GetValue(material, "_IndirectLightIntensity")
					},
					Normal = new NormalDefinition
					{
						NormalTexture = GetTexture(material, "_BumpMap"),
						NormalScaleValue = GetValue(material, "_BumpScale")
					}
				},
				Emission = new EmissionDefinition
				{
					EmissionColor = GetColor(material, "_EmissionColor"),
					EmissionMultiplyTexture = GetTexture(material, "_EmissionMap")
				},
				MatCap = new MatCapDefinition
				{
					AdditiveTexture = GetTexture(material, "_SphereAdd")
				},
				Rim = new RimDefinition
				{
					RimColor = GetColor(material, "_RimColor"),
					RimMultiplyTexture = GetTexture(material, "_RimTexture"),
					RimLightingMixValue = GetValue(material, "_RimLightingMix"),
					RimFresnelPowerValue = GetValue(material, "_RimFresnelPower"),
					RimLiftValue = GetValue(material, "_RimLift")
				},
				Outline = new OutlineDefinition
				{
					OutlineWidthMode = GetOutlineWidthMode(material),
					OutlineWidthValue = GetValue(material, "_OutlineWidth"),
					OutlineWidthMultiplyTexture = GetTexture(material, "_OutlineWidthTexture"),
					OutlineScaledMaxDistanceValue = GetValue(material, "_OutlineScaledMaxDistance"),
					OutlineColorMode = GetOutlineColorMode(material),
					OutlineColor = GetColor(material, "_OutlineColor"),
					OutlineLightingMixValue = GetValue(material, "_OutlineLightingMix")
				},
				TextureOption = new TextureUvCoordsDefinition
				{
					MainTextureLeftBottomOriginScale = material.GetTextureScale("_MainTex"),
					MainTextureLeftBottomOriginOffset = material.GetTextureOffset("_MainTex"),
					UvAnimationMaskTexture = GetTexture(material, "_UvAnimMaskTexture"),
					UvAnimationScrollXSpeedValue = GetValue(material, "_UvAnimScrollX"),
					UvAnimationScrollYSpeedValue = GetValue(material, "_UvAnimScrollY"),
					UvAnimationRotationSpeedValue = GetValue(material, "_UvAnimRotation")
				}
			};
		}

		private static float GetValue(Material material, string propertyName)
		{
			return material.GetFloat(propertyName);
		}

		private static Color GetColor(Material material, string propertyName)
		{
			return material.GetColor(propertyName);
		}

		private static Texture2D GetTexture(Material material, string propertyName)
		{
			return (Texture2D)material.GetTexture(propertyName);
		}

		private static RenderMode GetBlendMode(Material material)
		{
			if (material.IsKeywordEnabled("_ALPHATEST_ON"))
			{
				return RenderMode.Cutout;
			}
			if (material.IsKeywordEnabled("_ALPHABLEND_ON"))
			{
				switch (material.GetInt("_ZWrite"))
				{
				case 1:
					return RenderMode.TransparentWithZWrite;
				case 0:
					return RenderMode.Transparent;
				default:
					Debug.LogWarning("Invalid ZWrite Int Value.");
					return RenderMode.Transparent;
				}
			}
			return RenderMode.Opaque;
		}

		private static CullMode GetCullMode(Material material)
		{
			switch ((CullMode)material.GetInt("_CullMode"))
			{
			case CullMode.Off:
				return CullMode.Off;
			case CullMode.Front:
				return CullMode.Front;
			case CullMode.Back:
				return CullMode.Back;
			default:
				Debug.LogWarning("Invalid CullMode.");
				return CullMode.Back;
			}
		}

		private static OutlineWidthMode GetOutlineWidthMode(Material material)
		{
			if (material.IsKeywordEnabled("MTOON_OUTLINE_WIDTH_WORLD"))
			{
				return OutlineWidthMode.WorldCoordinates;
			}
			if (material.IsKeywordEnabled("MTOON_OUTLINE_WIDTH_SCREEN"))
			{
				return OutlineWidthMode.ScreenCoordinates;
			}
			return OutlineWidthMode.None;
		}

		private static OutlineColorMode GetOutlineColorMode(Material material)
		{
			if (material.IsKeywordEnabled("MTOON_OUTLINE_COLOR_FIXED"))
			{
				return OutlineColorMode.FixedColor;
			}
			if (material.IsKeywordEnabled("MTOON_OUTLINE_COLOR_MIXED"))
			{
				return OutlineColorMode.MixedLighting;
			}
			return OutlineColorMode.FixedColor;
		}

		private static RenderMode GetRenderQueueOriginMode(Material material)
		{
			return GetBlendMode(material);
		}

		private static int GetRenderQueueOffset(Material material, RenderMode originMode)
		{
			int renderQueue = material.renderQueue;
			RenderQueueRequirement renderQueueRequirement = GetRenderQueueRequirement(originMode);
			if (renderQueue < renderQueueRequirement.MinValue || renderQueue > renderQueueRequirement.MaxValue)
			{
				return 0;
			}
			return renderQueue - renderQueueRequirement.DefaultValue;
		}

		public static void SetMToonParametersToMaterial(Material material, MToonDefinition parameters)
		{
			MetaDefinition meta = parameters.Meta;
			SetValue(material, "_MToonVersion", meta.VersionNumber);
			RenderingDefinition rendering = parameters.Rendering;
			SetRenderMode(material, rendering.RenderMode, rendering.RenderQueueOffsetNumber, useDefaultRenderQueue: false);
			SetCullMode(material, rendering.CullMode);
			ColorDefinition color = parameters.Color;
			SetColor(material, "_Color", color.LitColor);
			SetTexture(material, "_MainTex", color.LitMultiplyTexture);
			SetColor(material, "_ShadeColor", color.ShadeColor);
			SetTexture(material, "_ShadeTexture", color.ShadeMultiplyTexture);
			SetValue(material, "_Cutoff", color.CutoutThresholdValue);
			LightingDefinition lighting = parameters.Lighting;
			LitAndShadeMixingDefinition litAndShadeMixing = lighting.LitAndShadeMixing;
			SetValue(material, "_ShadeShift", litAndShadeMixing.ShadingShiftValue);
			SetValue(material, "_ShadeToony", litAndShadeMixing.ShadingToonyValue);
			SetValue(material, "_ReceiveShadowRate", litAndShadeMixing.ShadowReceiveMultiplierValue);
			SetTexture(material, "_ReceiveShadowTexture", litAndShadeMixing.ShadowReceiveMultiplierMultiplyTexture);
			SetValue(material, "_ShadingGradeRate", litAndShadeMixing.LitAndShadeMixingMultiplierValue);
			SetTexture(material, "_ShadingGradeTexture", litAndShadeMixing.LitAndShadeMixingMultiplierMultiplyTexture);
			LightingInfluenceDefinition lightingInfluence = lighting.LightingInfluence;
			SetValue(material, "_LightColorAttenuation", lightingInfluence.LightColorAttenuationValue);
			SetValue(material, "_IndirectLightIntensity", lightingInfluence.GiIntensityValue);
			NormalDefinition normal = lighting.Normal;
			SetNormalMapping(material, normal.NormalTexture, normal.NormalScaleValue);
			EmissionDefinition emission = parameters.Emission;
			SetColor(material, "_EmissionColor", emission.EmissionColor);
			SetTexture(material, "_EmissionMap", emission.EmissionMultiplyTexture);
			MatCapDefinition matCap = parameters.MatCap;
			SetTexture(material, "_SphereAdd", matCap.AdditiveTexture);
			RimDefinition rim = parameters.Rim;
			SetColor(material, "_RimColor", rim.RimColor);
			SetTexture(material, "_RimTexture", rim.RimMultiplyTexture);
			SetValue(material, "_RimLightingMix", rim.RimLightingMixValue);
			SetValue(material, "_RimFresnelPower", rim.RimFresnelPowerValue);
			SetValue(material, "_RimLift", rim.RimLiftValue);
			OutlineDefinition outline = parameters.Outline;
			SetValue(material, "_OutlineWidth", outline.OutlineWidthValue);
			SetTexture(material, "_OutlineWidthTexture", outline.OutlineWidthMultiplyTexture);
			SetValue(material, "_OutlineScaledMaxDistance", outline.OutlineScaledMaxDistanceValue);
			SetColor(material, "_OutlineColor", outline.OutlineColor);
			SetValue(material, "_OutlineLightingMix", outline.OutlineLightingMixValue);
			SetOutlineMode(material, outline.OutlineWidthMode, outline.OutlineColorMode);
			TextureUvCoordsDefinition textureOption = parameters.TextureOption;
			material.SetTextureScale("_MainTex", textureOption.MainTextureLeftBottomOriginScale);
			material.SetTextureOffset("_MainTex", textureOption.MainTextureLeftBottomOriginOffset);
			material.SetTexture("_UvAnimMaskTexture", textureOption.UvAnimationMaskTexture);
			material.SetFloat("_UvAnimScrollX", textureOption.UvAnimationScrollXSpeedValue);
			material.SetFloat("_UvAnimScrollY", textureOption.UvAnimationScrollYSpeedValue);
			material.SetFloat("_UvAnimRotation", textureOption.UvAnimationRotationSpeedValue);
			ValidateProperties(material);
		}

		public static void ValidateProperties(Material material, bool isBlendModeChangedByUser = false)
		{
			SetRenderMode(material, (RenderMode)material.GetFloat("_BlendMode"), material.renderQueue - GetRenderQueueRequirement((RenderMode)material.GetFloat("_BlendMode")).DefaultValue, isBlendModeChangedByUser);
			SetNormalMapping(material, material.GetTexture("_BumpMap"), material.GetFloat("_BumpScale"));
			SetOutlineMode(material, (OutlineWidthMode)material.GetFloat("_OutlineWidthMode"), (OutlineColorMode)material.GetFloat("_OutlineColorMode"));
			SetDebugMode(material, (DebugMode)material.GetFloat("_DebugMode"));
			SetCullMode(material, (CullMode)material.GetFloat("_CullMode"));
			Texture texture = material.GetTexture("_MainTex");
			Texture texture2 = material.GetTexture("_ShadeTexture");
			if (texture != null && texture2 == null)
			{
				material.SetTexture("_ShadeTexture", texture);
			}
		}

		private static void SetDebugMode(Material material, DebugMode debugMode)
		{
			SetValue(material, "_DebugMode", (float)debugMode);
			switch (debugMode)
			{
			case DebugMode.None:
				SetKeyword(material, "MTOON_DEBUG_NORMAL", required: false);
				SetKeyword(material, "MTOON_DEBUG_LITSHADERATE", required: false);
				break;
			case DebugMode.Normal:
				SetKeyword(material, "MTOON_DEBUG_NORMAL", required: true);
				SetKeyword(material, "MTOON_DEBUG_LITSHADERATE", required: false);
				break;
			case DebugMode.LitShadeRate:
				SetKeyword(material, "MTOON_DEBUG_NORMAL", required: false);
				SetKeyword(material, "MTOON_DEBUG_LITSHADERATE", required: true);
				break;
			}
		}

		private static void SetRenderMode(Material material, RenderMode renderMode, int renderQueueOffset, bool useDefaultRenderQueue)
		{
			SetValue(material, "_BlendMode", (float)renderMode);
			switch (renderMode)
			{
			case RenderMode.Opaque:
				material.SetOverrideTag("RenderType", "Opaque");
				material.SetInt("_SrcBlend", 1);
				material.SetInt("_DstBlend", 0);
				material.SetInt("_ZWrite", 1);
				material.SetInt("_AlphaToMask", 0);
				SetKeyword(material, "_ALPHATEST_ON", required: false);
				SetKeyword(material, "_ALPHABLEND_ON", required: false);
				SetKeyword(material, "_ALPHAPREMULTIPLY_ON", required: false);
				break;
			case RenderMode.Cutout:
				material.SetOverrideTag("RenderType", "TransparentCutout");
				material.SetInt("_SrcBlend", 1);
				material.SetInt("_DstBlend", 0);
				material.SetInt("_ZWrite", 1);
				material.SetInt("_AlphaToMask", 1);
				SetKeyword(material, "_ALPHATEST_ON", required: true);
				SetKeyword(material, "_ALPHABLEND_ON", required: false);
				SetKeyword(material, "_ALPHAPREMULTIPLY_ON", required: false);
				break;
			case RenderMode.Transparent:
				material.SetOverrideTag("RenderType", "Transparent");
				material.SetInt("_SrcBlend", 5);
				material.SetInt("_DstBlend", 10);
				material.SetInt("_ZWrite", 0);
				material.SetInt("_AlphaToMask", 0);
				SetKeyword(material, "_ALPHATEST_ON", required: false);
				SetKeyword(material, "_ALPHABLEND_ON", required: true);
				SetKeyword(material, "_ALPHAPREMULTIPLY_ON", required: false);
				break;
			case RenderMode.TransparentWithZWrite:
				material.SetOverrideTag("RenderType", "Transparent");
				material.SetInt("_SrcBlend", 5);
				material.SetInt("_DstBlend", 10);
				material.SetInt("_ZWrite", 1);
				material.SetInt("_AlphaToMask", 0);
				SetKeyword(material, "_ALPHATEST_ON", required: false);
				SetKeyword(material, "_ALPHABLEND_ON", required: true);
				SetKeyword(material, "_ALPHAPREMULTIPLY_ON", required: false);
				break;
			}
			if (useDefaultRenderQueue)
			{
				material.renderQueue = GetRenderQueueRequirement(renderMode).DefaultValue;
				return;
			}
			RenderQueueRequirement renderQueueRequirement = GetRenderQueueRequirement(renderMode);
			material.renderQueue = Mathf.Clamp(renderQueueRequirement.DefaultValue + renderQueueOffset, renderQueueRequirement.MinValue, renderQueueRequirement.MaxValue);
		}

		private static void SetOutlineMode(Material material, OutlineWidthMode outlineWidthMode, OutlineColorMode outlineColorMode)
		{
			SetValue(material, "_OutlineWidthMode", (float)outlineWidthMode);
			SetValue(material, "_OutlineColorMode", (float)outlineColorMode);
			bool required = outlineColorMode == OutlineColorMode.FixedColor;
			bool required2 = outlineColorMode == OutlineColorMode.MixedLighting;
			switch (outlineWidthMode)
			{
			case OutlineWidthMode.None:
				SetKeyword(material, "MTOON_OUTLINE_WIDTH_WORLD", required: false);
				SetKeyword(material, "MTOON_OUTLINE_WIDTH_SCREEN", required: false);
				SetKeyword(material, "MTOON_OUTLINE_COLOR_FIXED", required: false);
				SetKeyword(material, "MTOON_OUTLINE_COLOR_MIXED", required: false);
				break;
			case OutlineWidthMode.WorldCoordinates:
				SetKeyword(material, "MTOON_OUTLINE_WIDTH_WORLD", required: true);
				SetKeyword(material, "MTOON_OUTLINE_WIDTH_SCREEN", required: false);
				SetKeyword(material, "MTOON_OUTLINE_COLOR_FIXED", required);
				SetKeyword(material, "MTOON_OUTLINE_COLOR_MIXED", required2);
				break;
			case OutlineWidthMode.ScreenCoordinates:
				SetKeyword(material, "MTOON_OUTLINE_WIDTH_WORLD", required: false);
				SetKeyword(material, "MTOON_OUTLINE_WIDTH_SCREEN", required: true);
				SetKeyword(material, "MTOON_OUTLINE_COLOR_FIXED", required);
				SetKeyword(material, "MTOON_OUTLINE_COLOR_MIXED", required2);
				break;
			}
		}

		private static void SetNormalMapping(Material material, Texture bumpMap, float bumpScale)
		{
			SetTexture(material, "_BumpMap", bumpMap);
			SetValue(material, "_BumpScale", bumpScale);
			SetKeyword(material, "_NORMALMAP", bumpMap != null);
		}

		private static void SetCullMode(Material material, CullMode cullMode)
		{
			SetValue(material, "_CullMode", (float)cullMode);
			switch (cullMode)
			{
			case CullMode.Back:
				material.SetInt("_CullMode", 2);
				material.SetInt("_OutlineCullMode", 1);
				break;
			case CullMode.Front:
				material.SetInt("_CullMode", 1);
				material.SetInt("_OutlineCullMode", 2);
				break;
			case CullMode.Off:
				material.SetInt("_CullMode", 0);
				material.SetInt("_OutlineCullMode", 1);
				break;
			}
		}

		private static void SetValue(Material material, string propertyName, float val)
		{
			material.SetFloat(propertyName, val);
		}

		private static void SetColor(Material material, string propertyName, Color color)
		{
			material.SetColor(propertyName, color);
		}

		private static void SetTexture(Material material, string propertyName, Texture texture)
		{
			material.SetTexture(propertyName, texture);
		}

		private static void SetKeyword(Material mat, string keyword, bool required)
		{
			if (required)
			{
				mat.EnableKeyword(keyword);
			}
			else
			{
				mat.DisableKeyword(keyword);
			}
		}
	}
}
