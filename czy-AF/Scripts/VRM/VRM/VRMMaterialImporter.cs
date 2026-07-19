using System.Collections.Generic;
using System.Linq;
using UniGLTF;
using UnityEngine;

namespace VRM
{
	public class VRMMaterialImporter : MaterialImporter
	{
		private List<glTF_VRM_Material> m_materials;

		private static string[] VRM_SHADER_NAMES = new string[7] { "Standard", "VRM/MToon", "UniGLTF/UniUnlit", "VRM/UnlitTexture", "VRM/UnlitCutout", "VRM/UnlitTransparent", "VRM/UnlitTransparentZWrite" };

		public VRMMaterialImporter(ImporterContext context, List<glTF_VRM_Material> materials)
			: base(new ShaderStore(context), (int index) => context.GetTexture(index))
		{
			m_materials = materials;
		}

		public override Material CreateMaterial(int i, glTFMaterial src, bool hasVertexColor)
		{
			if (i == 0 && m_materials.Count == 0)
			{
				return new Material(Shader.Find("Standard"));
			}
			glTF_VRM_Material glTF_VRM_Material2 = m_materials[i];
			string shader = glTF_VRM_Material2.shader;
			Shader shader2 = Shader.Find(shader);
			if (shader2 == null)
			{
				if (VRM_SHADER_NAMES.Contains(shader))
				{
					Debug.LogErrorFormat("shader {0} not found. set Assets/VRM/Shaders/VRMShaders to Edit - project setting - Graphics - preloaded shaders", shader);
				}
				else
				{
					Debug.LogWarningFormat("unknown shader {0}.", shader);
				}
				return base.CreateMaterial(i, src, hasVertexColor);
			}
			Material material = new Material(shader2);
			material.name = glTF_VRM_Material2.name;
			material.renderQueue = glTF_VRM_Material2.renderQueue;
			foreach (KeyValuePair<string, float> floatProperty in glTF_VRM_Material2.floatProperties)
			{
				material.SetFloat(floatProperty.Key, floatProperty.Value);
			}
			foreach (KeyValuePair<string, float[]> vectorProperty in glTF_VRM_Material2.vectorProperties)
			{
				if (glTF_VRM_Material2.textureProperties.ContainsKey(vectorProperty.Key))
				{
					material.SetTextureOffset(vectorProperty.Key, new Vector2(vectorProperty.Value[0], vectorProperty.Value[1]));
					material.SetTextureScale(vectorProperty.Key, new Vector2(vectorProperty.Value[2], vectorProperty.Value[3]));
				}
				else
				{
					material.SetVector(value: new Vector4(vectorProperty.Value[0], vectorProperty.Value[1], vectorProperty.Value[2], vectorProperty.Value[3]), name: vectorProperty.Key);
				}
			}
			foreach (KeyValuePair<string, int> textureProperty in glTF_VRM_Material2.textureProperties)
			{
				TextureItem textureItem = GetTextureFunc(textureProperty.Value);
				if (textureItem != null)
				{
					Texture2D texture2D = textureItem.ConvertTexture(textureProperty.Key);
					if (texture2D != null)
					{
						material.SetTexture(textureProperty.Key, texture2D);
					}
					else
					{
						material.SetTexture(textureProperty.Key, textureItem.Texture);
					}
				}
			}
			foreach (KeyValuePair<string, bool> item in glTF_VRM_Material2.keywordMap)
			{
				if (item.Value)
				{
					material.EnableKeyword(item.Key);
				}
				else
				{
					material.DisableKeyword(item.Key);
				}
			}
			foreach (KeyValuePair<string, string> item2 in glTF_VRM_Material2.tagMap)
			{
				material.SetOverrideTag(item2.Key, item2.Value);
			}
			if (shader == "VRM/MToon")
			{
				material.SetFloat("_MToonVersion", 33f);
			}
			return material;
		}
	}
}
