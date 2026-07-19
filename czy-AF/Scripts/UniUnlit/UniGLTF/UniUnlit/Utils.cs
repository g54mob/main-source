using System;
using UnityEngine;

namespace UniGLTF.UniUnlit
{
	public static class Utils
	{
		public const string ShaderName = "UniGLTF/UniUnlit";

		public const string PropNameMainTex = "_MainTex";

		public const string PropNameColor = "_Color";

		public const string PropNameCutoff = "_Cutoff";

		public const string PropNameBlendMode = "_BlendMode";

		public const string PropNameCullMode = "_CullMode";

		[Obsolete("Use PropNameVColBlendMode")]
		public const string PropeNameVColBlendMode = "_VColBlendMode";

		public const string PropNameVColBlendMode = "_VColBlendMode";

		public const string PropNameSrcBlend = "_SrcBlend";

		public const string PropNameDstBlend = "_DstBlend";

		public const string PropNameZWrite = "_ZWrite";

		public const string PropNameStandardShadersRenderMode = "_Mode";

		public const string KeywordAlphaTestOn = "_ALPHATEST_ON";

		public const string KeywordAlphaBlendOn = "_ALPHABLEND_ON";

		public const string KeywordVertexColMul = "_VERTEXCOL_MUL";

		public const string TagRenderTypeKey = "RenderType";

		public const string TagRenderTypeValueOpaque = "Opaque";

		public const string TagRenderTypeValueTransparentCutout = "TransparentCutout";

		public const string TagRenderTypeValueTransparent = "Transparent";

		public static void SetRenderMode(Material material, UniUnlitRenderMode mode)
		{
			material.SetInt("_BlendMode", (int)mode);
		}

		public static void SetCullMode(Material material, UniUnlitCullMode mode)
		{
			material.SetInt("_CullMode", (int)mode);
		}

		public static void SetVColBlendMode(Material material, UniUnlitVertexColorBlendOp mode)
		{
			material.SetInt("_VColBlendMode", (int)mode);
		}

		public static UniUnlitRenderMode GetRenderMode(Material material)
		{
			return (UniUnlitRenderMode)material.GetInt("_BlendMode");
		}

		public static UniUnlitCullMode GetCullMode(Material material)
		{
			return (UniUnlitCullMode)material.GetInt("_CullMode");
		}

		public static void ValidateProperties(Material material, bool isRenderModeChangedByUser = false)
		{
			SetupBlendMode(material, (UniUnlitRenderMode)material.GetFloat("_BlendMode"), isRenderModeChangedByUser);
			SetupVertexColorBlendOp(material, (UniUnlitVertexColorBlendOp)material.GetFloat("_VColBlendMode"));
		}

		private static void SetupBlendMode(Material material, UniUnlitRenderMode renderMode, bool isRenderModeChangedByUser = false)
		{
			switch (renderMode)
			{
			case UniUnlitRenderMode.Opaque:
				material.SetOverrideTag("RenderType", "Opaque");
				material.SetInt("_SrcBlend", 1);
				material.SetInt("_DstBlend", 0);
				material.SetInt("_ZWrite", 1);
				SetKeyword(material, "_ALPHATEST_ON", required: false);
				SetKeyword(material, "_ALPHABLEND_ON", required: false);
				if (isRenderModeChangedByUser)
				{
					material.renderQueue = -1;
				}
				break;
			case UniUnlitRenderMode.Cutout:
				material.SetOverrideTag("RenderType", "TransparentCutout");
				material.SetInt("_SrcBlend", 1);
				material.SetInt("_DstBlend", 0);
				material.SetInt("_ZWrite", 1);
				SetKeyword(material, "_ALPHATEST_ON", required: true);
				SetKeyword(material, "_ALPHABLEND_ON", required: false);
				if (isRenderModeChangedByUser)
				{
					material.renderQueue = 2450;
				}
				break;
			case UniUnlitRenderMode.Transparent:
				material.SetOverrideTag("RenderType", "Transparent");
				material.SetInt("_SrcBlend", 5);
				material.SetInt("_DstBlend", 10);
				material.SetInt("_ZWrite", 0);
				SetKeyword(material, "_ALPHATEST_ON", required: false);
				SetKeyword(material, "_ALPHABLEND_ON", required: true);
				if (isRenderModeChangedByUser)
				{
					material.renderQueue = 3000;
				}
				break;
			}
		}

		private static void SetupVertexColorBlendOp(Material material, UniUnlitVertexColorBlendOp vColBlendOp)
		{
			switch (vColBlendOp)
			{
			case UniUnlitVertexColorBlendOp.None:
				SetKeyword(material, "_VERTEXCOL_MUL", required: false);
				break;
			case UniUnlitVertexColorBlendOp.Multiply:
				SetKeyword(material, "_VERTEXCOL_MUL", required: true);
				break;
			}
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
