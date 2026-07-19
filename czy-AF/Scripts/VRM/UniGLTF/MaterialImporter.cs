using System;
using UniGLTF.UniUnlit;
using UnityEngine;

namespace UniGLTF
{
	public class MaterialImporter : IMaterialImporter
	{
		private enum BlendMode
		{
			Opaque = 0,
			Cutout = 1,
			Fade = 2,
			Transparent = 3
		}

		private IShaderStore m_shaderStore;

		protected Func<int, TextureItem> GetTextureFunc;

		public MaterialImporter(IShaderStore shaderStore, Func<int, TextureItem> getTextureFunc)
		{
			m_shaderStore = shaderStore;
			GetTextureFunc = getTextureFunc;
		}

		public virtual Material CreateMaterial(int i, glTFMaterial x, bool hasVertexColor)
		{
			Material material = new Material(m_shaderStore.GetShader(x));
			material.name = ((x == null || string.IsNullOrEmpty(x.name)) ? $"material_{i:00}" : x.name);
			if (x == null)
			{
				Debug.LogWarning("glTFMaterial is empty");
				return material;
			}
			if (x.extensions != null && x.extensions.KHR_materials_unlit != null)
			{
				if (x.pbrMetallicRoughness.baseColorTexture != null)
				{
					TextureItem textureItem = GetTextureFunc(x.pbrMetallicRoughness.baseColorTexture.index);
					if (textureItem != null)
					{
						material.mainTexture = textureItem.Texture;
					}
					SetTextureOffsetAndScale(material, x.pbrMetallicRoughness.baseColorTexture, "_MainTex");
				}
				if (x.pbrMetallicRoughness.baseColorFactor != null && x.pbrMetallicRoughness.baseColorFactor.Length == 4)
				{
					float[] baseColorFactor = x.pbrMetallicRoughness.baseColorFactor;
					material.color = new Color(baseColorFactor[0], baseColorFactor[1], baseColorFactor[2], baseColorFactor[3]).gamma;
				}
				if (x.alphaMode == "OPAQUE")
				{
					Utils.SetRenderMode(material, UniUnlitRenderMode.Opaque);
				}
				else if (x.alphaMode == "BLEND")
				{
					Utils.SetRenderMode(material, UniUnlitRenderMode.Transparent);
				}
				else if (x.alphaMode == "MASK")
				{
					Utils.SetRenderMode(material, UniUnlitRenderMode.Cutout);
				}
				else
				{
					Utils.SetRenderMode(material, UniUnlitRenderMode.Opaque);
				}
				if (x.doubleSided)
				{
					Utils.SetCullMode(material, UniUnlitCullMode.Off);
				}
				else
				{
					Utils.SetCullMode(material, UniUnlitCullMode.Back);
				}
				if (hasVertexColor)
				{
					Utils.SetVColBlendMode(material, UniUnlitVertexColorBlendOp.Multiply);
				}
				Utils.ValidateProperties(material, isRenderModeChangedByUser: true);
				return material;
			}
			if (x.pbrMetallicRoughness != null)
			{
				if (x.pbrMetallicRoughness.baseColorFactor != null && x.pbrMetallicRoughness.baseColorFactor.Length == 4)
				{
					float[] baseColorFactor2 = x.pbrMetallicRoughness.baseColorFactor;
					material.color = new Color(baseColorFactor2[0], baseColorFactor2[1], baseColorFactor2[2], baseColorFactor2[3]).gamma;
				}
				if (x.pbrMetallicRoughness.baseColorTexture != null && x.pbrMetallicRoughness.baseColorTexture.index != -1)
				{
					TextureItem textureItem2 = GetTextureFunc(x.pbrMetallicRoughness.baseColorTexture.index);
					if (textureItem2 != null)
					{
						material.mainTexture = textureItem2.Texture;
					}
					SetTextureOffsetAndScale(material, x.pbrMetallicRoughness.baseColorTexture, "_MainTex");
				}
				if (x.pbrMetallicRoughness.metallicRoughnessTexture != null && x.pbrMetallicRoughness.metallicRoughnessTexture.index != -1)
				{
					material.EnableKeyword("_METALLICGLOSSMAP");
					TextureItem textureItem3 = GetTextureFunc(x.pbrMetallicRoughness.metallicRoughnessTexture.index);
					if (textureItem3 != null)
					{
						string text = "_MetallicGlossMap";
						material.SetTexture(text, textureItem3.ConvertTexture(text, x.pbrMetallicRoughness.roughnessFactor));
					}
					material.SetFloat("_Metallic", 1f);
					material.SetFloat("_GlossMapScale", 1f);
					SetTextureOffsetAndScale(material, x.pbrMetallicRoughness.metallicRoughnessTexture, "_MetallicGlossMap");
				}
				else
				{
					material.SetFloat("_Metallic", x.pbrMetallicRoughness.metallicFactor);
					material.SetFloat("_Glossiness", 1f - x.pbrMetallicRoughness.roughnessFactor);
				}
			}
			if (x.normalTexture != null && x.normalTexture.index != -1)
			{
				material.EnableKeyword("_NORMALMAP");
				TextureItem textureItem4 = GetTextureFunc(x.normalTexture.index);
				if (textureItem4 != null)
				{
					string text2 = "_BumpMap";
					material.SetTexture(text2, textureItem4.ConvertTexture(text2));
					material.SetFloat("_BumpScale", x.normalTexture.scale);
				}
				SetTextureOffsetAndScale(material, x.normalTexture, "_BumpMap");
			}
			if (x.occlusionTexture != null && x.occlusionTexture.index != -1)
			{
				TextureItem textureItem5 = GetTextureFunc(x.occlusionTexture.index);
				if (textureItem5 != null)
				{
					string text3 = "_OcclusionMap";
					material.SetTexture(text3, textureItem5.ConvertTexture(text3));
					material.SetFloat("_OcclusionStrength", x.occlusionTexture.strength);
				}
				SetTextureOffsetAndScale(material, x.occlusionTexture, "_OcclusionMap");
			}
			if (x.emissiveFactor != null || (x.emissiveTexture != null && x.emissiveTexture.index != -1))
			{
				material.EnableKeyword("_EMISSION");
				material.globalIlluminationFlags &= ~MaterialGlobalIlluminationFlags.EmissiveIsBlack;
				if (x.emissiveFactor != null && x.emissiveFactor.Length == 3)
				{
					material.SetColor("_EmissionColor", new Color(x.emissiveFactor[0], x.emissiveFactor[1], x.emissiveFactor[2]));
				}
				if (x.emissiveTexture != null && x.emissiveTexture.index != -1)
				{
					TextureItem textureItem6 = GetTextureFunc(x.emissiveTexture.index);
					if (textureItem6 != null)
					{
						material.SetTexture("_EmissionMap", textureItem6.Texture);
					}
					SetTextureOffsetAndScale(material, x.emissiveTexture, "_EmissionMap");
				}
			}
			BlendMode blendMode = BlendMode.Opaque;
			string alphaMode = x.alphaMode;
			if (!(alphaMode == "BLEND"))
			{
				if (alphaMode == "MASK")
				{
					blendMode = BlendMode.Cutout;
					material.SetOverrideTag("RenderType", "TransparentCutout");
					material.SetInt("_SrcBlend", 1);
					material.SetInt("_DstBlend", 0);
					material.SetInt("_ZWrite", 1);
					material.SetFloat("_Cutoff", x.alphaCutoff);
					material.EnableKeyword("_ALPHATEST_ON");
					material.DisableKeyword("_ALPHABLEND_ON");
					material.DisableKeyword("_ALPHAPREMULTIPLY_ON");
					material.renderQueue = 2450;
				}
				else
				{
					blendMode = BlendMode.Opaque;
					material.SetOverrideTag("RenderType", "");
					material.SetInt("_SrcBlend", 1);
					material.SetInt("_DstBlend", 0);
					material.SetInt("_ZWrite", 1);
					material.DisableKeyword("_ALPHATEST_ON");
					material.DisableKeyword("_ALPHABLEND_ON");
					material.DisableKeyword("_ALPHAPREMULTIPLY_ON");
					material.renderQueue = -1;
				}
			}
			else
			{
				blendMode = BlendMode.Fade;
				material.SetOverrideTag("RenderType", "Transparent");
				material.SetInt("_SrcBlend", 5);
				material.SetInt("_DstBlend", 10);
				material.SetInt("_ZWrite", 0);
				material.DisableKeyword("_ALPHATEST_ON");
				material.EnableKeyword("_ALPHABLEND_ON");
				material.DisableKeyword("_ALPHAPREMULTIPLY_ON");
				material.renderQueue = 3000;
			}
			material.SetFloat("_Mode", (float)blendMode);
			return material;
		}

		private static void SetTextureOffsetAndScale(Material material, glTFTextureInfo textureInfo, string propertyName)
		{
			if (textureInfo.extensions != null && textureInfo.extensions.KHR_texture_transform != null)
			{
				glTF_KHR_texture_transform kHR_texture_transform = textureInfo.extensions.KHR_texture_transform;
				Vector2 value = new Vector2(0f, 0f);
				Vector2 value2 = new Vector2(1f, 1f);
				if (kHR_texture_transform.offset != null && kHR_texture_transform.offset.Length == 2)
				{
					value = new Vector2(kHR_texture_transform.offset[0], kHR_texture_transform.offset[1]);
				}
				if (kHR_texture_transform.scale != null && kHR_texture_transform.scale.Length == 2)
				{
					value2 = new Vector2(kHR_texture_transform.scale[0], kHR_texture_transform.scale[1]);
				}
				value.y = (value.y + value2.y - 1f) * -1f;
				material.SetTextureOffset(propertyName, value);
				material.SetTextureScale(propertyName, value2);
			}
		}
	}
}
