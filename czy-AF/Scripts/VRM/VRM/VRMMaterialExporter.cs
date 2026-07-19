using System;
using System.Collections.Generic;
using System.Linq;
using UniGLTF;
using UniGLTF.ShaderPropExporter;
using UnityEngine;

namespace VRM
{
	public class VRMMaterialExporter : MaterialExporter
	{
		public static readonly string[] VRMExtensionShaders = new string[2] { "VRM/UnlitTransparentZWrite", "VRM/MToon" };

		private static readonly string[] TAGS = new string[1] { "RenderType" };

		public static bool UseUnlit(string shaderName)
		{
			switch (shaderName)
			{
			case "Unlit/Color":
			case "Unlit/Texture":
			case "Unlit/Transparent":
			case "Unlit/Transparent Cutout":
			case "UniGLTF/UniUnlit":
			case "VRM/UnlitTexture":
			case "VRM/UnlitTransparent":
			case "VRM/UnlitCutout":
				return true;
			default:
				return false;
			}
		}

		protected override glTFMaterial CreateMaterial(Material m)
		{
			return m.shader.name switch
			{
				"VRM/UnlitTexture" => Export_VRMUnlitTexture(m), 
				"VRM/UnlitTransparent" => Export_VRMUnlitTransparent(m), 
				"VRM/UnlitCutout" => Export_VRMUnlitCutout(m), 
				"VRM/UnlitTransparentZWrite" => Export_VRMUnlitTransparentZWrite(m), 
				"VRM/MToon" => Export_VRMMToon(m), 
				_ => base.CreateMaterial(m), 
			};
		}

		private static glTFMaterial Export_VRMUnlitTexture(Material m)
		{
			glTFMaterial obj = glTF_KHR_materials_unlit.CreateDefault();
			obj.alphaMode = "OPAQUE";
			return obj;
		}

		private static glTFMaterial Export_VRMUnlitTransparent(Material m)
		{
			glTFMaterial obj = glTF_KHR_materials_unlit.CreateDefault();
			obj.alphaMode = "BLEND";
			return obj;
		}

		private static glTFMaterial Export_VRMUnlitCutout(Material m)
		{
			glTFMaterial obj = glTF_KHR_materials_unlit.CreateDefault();
			obj.alphaMode = "MASK";
			return obj;
		}

		private static glTFMaterial Export_VRMUnlitTransparentZWrite(Material m)
		{
			glTFMaterial obj = glTF_KHR_materials_unlit.CreateDefault();
			obj.alphaMode = "BLEND";
			return obj;
		}

		private static glTFMaterial Export_VRMMToon(Material m)
		{
			glTFMaterial glTFMaterial2 = glTF_KHR_materials_unlit.CreateDefault();
			string tag = m.GetTag("RenderType", searchFallbacks: true);
			if (!(tag == "Transparent"))
			{
				if (tag == "TransparentCutout")
				{
					glTFMaterial2.alphaMode = "MASK";
					glTFMaterial2.alphaCutoff = m.GetFloat("_Cutoff");
				}
				else
				{
					glTFMaterial2.alphaMode = "OPAQUE";
				}
			}
			else
			{
				glTFMaterial2.alphaMode = "BLEND";
			}
			switch ((int)m.GetFloat("_CullMode"))
			{
			case 0:
				glTFMaterial2.doubleSided = true;
				break;
			case 1:
				Debug.LogWarning("ignore cull front");
				break;
			default:
				throw new NotImplementedException();
			case 2:
				break;
			}
			return glTFMaterial2;
		}

		public static glTF_VRM_Material CreateFromMaterial(Material m, List<Texture> textures)
		{
			glTF_VRM_Material glTF_VRM_Material2 = new glTF_VRM_Material
			{
				name = m.name,
				shader = m.shader.name,
				renderQueue = m.renderQueue
			};
			if (!VRMExtensionShaders.Contains(m.shader.name))
			{
				glTF_VRM_Material2.shader = glTF_VRM_Material.VRM_USE_GLTFSHADER;
				return glTF_VRM_Material2;
			}
			ShaderProps propsForSupportedShader = PreShaderPropExporter.GetPropsForSupportedShader(m.shader.name);
			string[] shaderKeywords;
			if (propsForSupportedShader == null)
			{
				Debug.LogWarningFormat("Fail to export shader: {0}", m.shader.name);
			}
			else
			{
				shaderKeywords = m.shaderKeywords;
				foreach (string text in shaderKeywords)
				{
					glTF_VRM_Material2.keywordMap.Add(text, m.IsKeywordEnabled(text));
				}
				ShaderProperty[] properties = propsForSupportedShader.Properties;
				for (int i = 0; i < properties.Length; i++)
				{
					ShaderProperty shaderProperty = properties[i];
					switch (shaderProperty.ShaderPropertyType)
					{
					case ShaderPropertyType.Color:
					{
						float[] value2 = m.GetColor(shaderProperty.Key).ToArray();
						glTF_VRM_Material2.vectorProperties.Add(shaderProperty.Key, value2);
						break;
					}
					case ShaderPropertyType.Range:
					case ShaderPropertyType.Float:
					{
						float value3 = m.GetFloat(shaderProperty.Key);
						glTF_VRM_Material2.floatProperties.Add(shaderProperty.Key, value3);
						break;
					}
					case ShaderPropertyType.TexEnv:
					{
						Texture texture = m.GetTexture(shaderProperty.Key);
						if (texture != null)
						{
							int num = textures.IndexOf(texture);
							if (num == -1)
							{
								Debug.LogFormat("not found {0}", texture.name);
							}
							else
							{
								glTF_VRM_Material2.textureProperties.Add(shaderProperty.Key, num);
							}
						}
						Vector2 textureOffset = m.GetTextureOffset(shaderProperty.Key);
						Vector2 textureScale = m.GetTextureScale(shaderProperty.Key);
						glTF_VRM_Material2.vectorProperties.Add(shaderProperty.Key, new float[4] { textureOffset.x, textureOffset.y, textureScale.x, textureScale.y });
						break;
					}
					case ShaderPropertyType.Vector:
					{
						float[] value = m.GetVector(shaderProperty.Key).ToArray();
						glTF_VRM_Material2.vectorProperties.Add(shaderProperty.Key, value);
						break;
					}
					default:
						throw new NotImplementedException();
					}
				}
			}
			shaderKeywords = TAGS;
			foreach (string text2 in shaderKeywords)
			{
				string tag = m.GetTag(text2, searchFallbacks: false);
				if (!string.IsNullOrEmpty(tag))
				{
					glTF_VRM_Material2.tagMap.Add(text2, tag);
				}
			}
			return glTF_VRM_Material2;
		}
	}
}
