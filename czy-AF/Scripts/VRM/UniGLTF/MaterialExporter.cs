using UniGLTF.UniUnlit;
using UnityEngine;

namespace UniGLTF
{
	public class MaterialExporter : IMaterialExporter
	{
		public virtual glTFMaterial ExportMaterial(Material m, TextureExportManager textureManager)
		{
			glTFMaterial glTFMaterial2 = CreateMaterial(m);
			glTFMaterial2.name = m.name;
			Export_Color(m, textureManager, glTFMaterial2);
			Export_Metallic(m, textureManager, glTFMaterial2);
			Export_Normal(m, textureManager, glTFMaterial2);
			Export_Occlusion(m, textureManager, glTFMaterial2);
			Export_Emission(m, textureManager, glTFMaterial2);
			return glTFMaterial2;
		}

		private static void Export_Color(Material m, TextureExportManager textureManager, glTFMaterial material)
		{
			if (m.HasProperty("_Color"))
			{
				material.pbrMetallicRoughness.baseColorFactor = m.color.linear.ToArray();
			}
			if (m.HasProperty("_MainTex"))
			{
				int num = textureManager.CopyAndGetIndex(m.GetTexture("_MainTex"), RenderTextureReadWrite.sRGB);
				if (num != -1)
				{
					material.pbrMetallicRoughness.baseColorTexture = new glTFMaterialBaseColorTextureInfo
					{
						index = num
					};
					Export_MainTextureTransform(m, material.pbrMetallicRoughness.baseColorTexture);
				}
			}
		}

		private static void Export_Metallic(Material m, TextureExportManager textureManager, glTFMaterial material)
		{
			int num = -1;
			if (m.HasProperty("_MetallicGlossMap"))
			{
				float smoothnessOrRoughness = 0f;
				if (m.HasProperty("_GlossMapScale"))
				{
					smoothnessOrRoughness = m.GetFloat("_GlossMapScale");
				}
				MetallicRoughnessConverter converter = new MetallicRoughnessConverter(smoothnessOrRoughness);
				num = textureManager.ConvertAndGetIndex(m.GetTexture("_MetallicGlossMap"), converter);
				if (num != -1)
				{
					material.pbrMetallicRoughness.metallicRoughnessTexture = new glTFMaterialMetallicRoughnessTextureInfo
					{
						index = num
					};
					Export_MainTextureTransform(m, material.pbrMetallicRoughness.metallicRoughnessTexture);
				}
			}
			if (num != -1)
			{
				material.pbrMetallicRoughness.metallicFactor = 1f;
				material.pbrMetallicRoughness.roughnessFactor = 1f;
				return;
			}
			if (m.HasProperty("_Metallic"))
			{
				material.pbrMetallicRoughness.metallicFactor = m.GetFloat("_Metallic");
			}
			if (m.HasProperty("_Glossiness"))
			{
				material.pbrMetallicRoughness.roughnessFactor = 1f - m.GetFloat("_Glossiness");
			}
		}

		private static void Export_Normal(Material m, TextureExportManager textureManager, glTFMaterial material)
		{
			if (m.HasProperty("_BumpMap"))
			{
				int num = textureManager.ConvertAndGetIndex(m.GetTexture("_BumpMap"), new NormalConverter());
				if (num != -1)
				{
					material.normalTexture = new glTFMaterialNormalTextureInfo
					{
						index = num
					};
					Export_MainTextureTransform(m, material.normalTexture);
				}
				if (num != -1 && m.HasProperty("_BumpScale"))
				{
					material.normalTexture.scale = m.GetFloat("_BumpScale");
				}
			}
		}

		private static void Export_Occlusion(Material m, TextureExportManager textureManager, glTFMaterial material)
		{
			if (m.HasProperty("_OcclusionMap"))
			{
				int num = textureManager.ConvertAndGetIndex(m.GetTexture("_OcclusionMap"), new OcclusionConverter());
				if (num != -1)
				{
					material.occlusionTexture = new glTFMaterialOcclusionTextureInfo
					{
						index = num
					};
					Export_MainTextureTransform(m, material.occlusionTexture);
				}
				if (num != -1 && m.HasProperty("_OcclusionStrength"))
				{
					material.occlusionTexture.strength = m.GetFloat("_OcclusionStrength");
				}
			}
		}

		private static void Export_Emission(Material m, TextureExportManager textureManager, glTFMaterial material)
		{
			if (!m.IsKeywordEnabled("_EMISSION"))
			{
				return;
			}
			if (m.HasProperty("_EmissionColor"))
			{
				Color color = m.GetColor("_EmissionColor");
				if (color.maxColorComponent > 1f)
				{
					color /= color.maxColorComponent;
				}
				material.emissiveFactor = new float[3] { color.r, color.g, color.b };
			}
			if (m.HasProperty("_EmissionMap"))
			{
				int num = textureManager.CopyAndGetIndex(m.GetTexture("_EmissionMap"), RenderTextureReadWrite.sRGB);
				if (num != -1)
				{
					material.emissiveTexture = new glTFMaterialEmissiveTextureInfo
					{
						index = num
					};
					Export_MainTextureTransform(m, material.emissiveTexture);
				}
			}
		}

		private static void Export_MainTextureTransform(Material m, glTFTextureInfo textureInfo)
		{
			Export_TextureTransform(m, textureInfo, "_MainTex");
		}

		private static void Export_TextureTransform(Material m, glTFTextureInfo textureInfo, string propertyName)
		{
			if (textureInfo != null && m.HasProperty(propertyName))
			{
				Vector2 textureOffset = m.GetTextureOffset(propertyName);
				Vector2 textureScale = m.GetTextureScale(propertyName);
				textureOffset.y = (textureOffset.y + textureScale.y - 1f) * -1f;
				textureInfo.extensions = new glTFTextureInfo_extensions
				{
					KHR_texture_transform = new glTF_KHR_texture_transform
					{
						offset = new float[2] { textureOffset.x, textureOffset.y },
						scale = new float[2] { textureScale.x, textureScale.y }
					}
				};
			}
		}

		protected virtual glTFMaterial CreateMaterial(Material m)
		{
			return m.shader.name switch
			{
				"Unlit/Color" => Export_UnlitColor(m), 
				"Unlit/Texture" => Export_UnlitTexture(m), 
				"Unlit/Transparent" => Export_UnlitTransparent(m), 
				"Unlit/Transparent Cutout" => Export_UnlitCutout(m), 
				"UniGLTF/UniUnlit" => Export_UniUnlit(m), 
				_ => Export_Standard(m), 
			};
		}

		private static glTFMaterial Export_UnlitColor(Material m)
		{
			glTFMaterial obj = glTF_KHR_materials_unlit.CreateDefault();
			obj.alphaMode = glTFBlendMode.OPAQUE.ToString();
			return obj;
		}

		private static glTFMaterial Export_UnlitTexture(Material m)
		{
			glTFMaterial obj = glTF_KHR_materials_unlit.CreateDefault();
			obj.alphaMode = glTFBlendMode.OPAQUE.ToString();
			return obj;
		}

		private static glTFMaterial Export_UnlitTransparent(Material m)
		{
			glTFMaterial obj = glTF_KHR_materials_unlit.CreateDefault();
			obj.alphaMode = glTFBlendMode.BLEND.ToString();
			return obj;
		}

		private static glTFMaterial Export_UnlitCutout(Material m)
		{
			glTFMaterial obj = glTF_KHR_materials_unlit.CreateDefault();
			obj.alphaMode = glTFBlendMode.MASK.ToString();
			obj.alphaCutoff = m.GetFloat("_Cutoff");
			return obj;
		}

		private glTFMaterial Export_UniUnlit(Material m)
		{
			glTFMaterial glTFMaterial2 = glTF_KHR_materials_unlit.CreateDefault();
			switch (Utils.GetRenderMode(m))
			{
			case UniUnlitRenderMode.Opaque:
				glTFMaterial2.alphaMode = glTFBlendMode.OPAQUE.ToString();
				break;
			case UniUnlitRenderMode.Transparent:
				glTFMaterial2.alphaMode = glTFBlendMode.BLEND.ToString();
				break;
			case UniUnlitRenderMode.Cutout:
				glTFMaterial2.alphaMode = glTFBlendMode.MASK.ToString();
				break;
			default:
				glTFMaterial2.alphaMode = glTFBlendMode.OPAQUE.ToString();
				break;
			}
			if (Utils.GetCullMode(m) == UniUnlitCullMode.Off)
			{
				glTFMaterial2.doubleSided = true;
			}
			else
			{
				glTFMaterial2.doubleSided = false;
			}
			return glTFMaterial2;
		}

		private static glTFMaterial Export_Standard(Material m)
		{
			glTFMaterial glTFMaterial2 = new glTFMaterial
			{
				pbrMetallicRoughness = new glTFPbrMetallicRoughness()
			};
			string tag = m.GetTag("RenderType", searchFallbacks: true);
			if (!(tag == "Transparent"))
			{
				if (tag == "TransparentCutout")
				{
					glTFMaterial2.alphaMode = glTFBlendMode.MASK.ToString();
					glTFMaterial2.alphaCutoff = m.GetFloat("_Cutoff");
				}
				else
				{
					glTFMaterial2.alphaMode = glTFBlendMode.OPAQUE.ToString();
				}
			}
			else
			{
				glTFMaterial2.alphaMode = glTFBlendMode.BLEND.ToString();
			}
			return glTFMaterial2;
		}
	}
}
