using System;
using DV.Utils;
using UnityEngine;

namespace DV.VFX
{
	public class MaterialUtils : SingletonBehaviour<MaterialUtils>
	{
		private enum RenderMode : byte
		{
			Opaque = 0,
			Cutout = 1,
			Fade = 2,
			Transparent = 3
		}

		private const string KEYWORD_NORMALMAP = "_NORMALMAP";

		private const string KEYWORD_METALLICGLOSSMAP = "_METALLICGLOSSMAP";

		private const string KEYWORD_ALPHATEST_ON = "_ALPHATEST_ON";

		private const string KEYWORD_ALPHABLEND_ON = "_ALPHABLEND_ON";

		private const string KEYWORD_ALPHAPREMULTIPLY_ON = "_ALPHAPREMULTIPLY_ON";

		private static readonly int prop_mode = Shader.PropertyToID("_Mode");

		private static readonly int prop_srcBlend = Shader.PropertyToID("_SrcBlend");

		private static readonly int prop_dstBlend = Shader.PropertyToID("_DstBlend");

		private static readonly int prop_zWrite = Shader.PropertyToID("_ZWrite");

		private static readonly int tex_BumpMap = Shader.PropertyToID("_BumpMap");

		private static readonly int tex_MetallicGlossMap = Shader.PropertyToID("_MetallicGlossMap");

		private static readonly int tex_OcclusionMap = Shader.PropertyToID("_OcclusionMap");

		public Material transparentMaterial;

		private Shader standardShader;

		private Shader distanceFieldSurfaceShader;

		public Shader StandardShader
		{
			get
			{
				if (standardShader == null)
				{
					standardShader = Shader.Find("Standard");
					if (standardShader == null)
					{
						Debug.LogError("Standard shader not found.");
					}
				}
				return standardShader;
			}
		}

		public Shader DistanceFieldSurfaceShader
		{
			get
			{
				if (distanceFieldSurfaceShader == null)
				{
					distanceFieldSurfaceShader = Shader.Find("TextMeshPro/Distance Field (Surface)");
					if (distanceFieldSurfaceShader == null)
					{
						Debug.LogError("TextMeshPro Distance Field (Surface) shader not found.");
					}
				}
				return distanceFieldSurfaceShader;
			}
		}

		public Material MakeTransparentCopy(Material material)
		{
			Material material2 = new Material(transparentMaterial);
			Color color = material.color;
			color.a = transparentMaterial.color.a;
			material2.color = color;
			material2.mainTexture = material.mainTexture;
			material2.renderQueue = 4995;
			if (material.HasProperty(prop_mode))
			{
				float num = material.GetFloat(prop_mode);
				if (num == 2f || num == 3f)
				{
					SetRenderMode(material2, (RenderMode)num);
				}
			}
			Texture texture = material.GetTexture(tex_BumpMap);
			if ((bool)texture)
			{
				material2.EnableKeyword("_NORMALMAP");
				material2.SetTexture(tex_BumpMap, texture);
			}
			Texture texture2 = material.GetTexture(tex_MetallicGlossMap);
			if ((bool)texture2)
			{
				material2.EnableKeyword("_METALLICGLOSSMAP");
				material2.SetTexture(tex_MetallicGlossMap, texture2);
			}
			Texture texture3 = material.GetTexture(tex_OcclusionMap);
			if ((bool)texture3)
			{
				material2.SetTexture(tex_OcclusionMap, texture3);
			}
			return material2;
		}

		private static void SetRenderMode(Material mat, RenderMode renderMode)
		{
			mat.SetFloat(prop_mode, (int)renderMode);
			switch (renderMode)
			{
			case RenderMode.Fade:
				mat.SetInt(prop_srcBlend, 5);
				mat.SetInt(prop_dstBlend, 10);
				mat.SetInt(prop_zWrite, 0);
				mat.DisableKeyword("_ALPHATEST_ON");
				mat.EnableKeyword("_ALPHABLEND_ON");
				mat.DisableKeyword("_ALPHAPREMULTIPLY_ON");
				break;
			case RenderMode.Transparent:
				mat.SetInt(prop_srcBlend, 1);
				mat.SetInt(prop_dstBlend, 10);
				mat.SetInt(prop_zWrite, 0);
				mat.DisableKeyword("_ALPHATEST_ON");
				mat.DisableKeyword("_ALPHABLEND_ON");
				mat.EnableKeyword("_ALPHAPREMULTIPLY_ON");
				break;
			default:
				throw new ArgumentOutOfRangeException("renderMode", renderMode, null);
			}
		}
	}
}
