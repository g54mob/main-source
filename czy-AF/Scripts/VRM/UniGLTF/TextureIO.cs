using System.Collections.Generic;
using System.Linq;
using UniGLTF.ShaderPropExporter;
using UnityEngine;

namespace UniGLTF
{
	public static class TextureIO
	{
		public struct TextureExportItem
		{
			public Texture Texture;

			public glTFTextureTypes TextureType;

			public TextureExportItem(Texture texture, glTFTextureTypes textureType)
			{
				Texture = texture;
				TextureType = textureType;
			}
		}

		private struct BytesWithMime
		{
			public byte[] Bytes;

			public string Mime;
		}

		public static RenderTextureReadWrite GetColorSpace(glTFTextureTypes textureType)
		{
			switch (textureType)
			{
			case glTFTextureTypes.Metallic:
			case glTFTextureTypes.Normal:
			case glTFTextureTypes.Occlusion:
				return RenderTextureReadWrite.Linear;
			case glTFTextureTypes.BaseColor:
			case glTFTextureTypes.Emissive:
				return RenderTextureReadWrite.sRGB;
			default:
				return RenderTextureReadWrite.sRGB;
			}
		}

		public static glTFTextureTypes GetglTFTextureType(string shaderName, string propName)
		{
			return propName switch
			{
				"_Color" => glTFTextureTypes.BaseColor, 
				"_MetallicGlossMap" => glTFTextureTypes.Metallic, 
				"_BumpMap" => glTFTextureTypes.Normal, 
				"_OcclusionMap" => glTFTextureTypes.Occlusion, 
				"_EmissionMap" => glTFTextureTypes.Emissive, 
				_ => glTFTextureTypes.Unknown, 
			};
		}

		public static glTFTextureTypes GetglTFTextureType(glTF glTf, int textureIndex)
		{
			foreach (glTFMaterial material in glTf.materials)
			{
				glTFTextureInfo glTFTextureInfo2 = material.GetTextures().FirstOrDefault((glTFTextureInfo x) => x != null && x.index == textureIndex);
				if (glTFTextureInfo2 != null)
				{
					return glTFTextureInfo2.TextureType;
				}
			}
			return glTFTextureTypes.Unknown;
		}

		public static IEnumerable<TextureExportItem> GetTextures(Material m)
		{
			ShaderProps props = PreShaderPropExporter.GetPropsForSupportedShader(m.shader.name);
			if (props == null)
			{
				yield return new TextureExportItem(m.mainTexture, glTFTextureTypes.BaseColor);
			}
			ShaderProperty[] properties = props.Properties;
			for (int i = 0; i < properties.Length; i++)
			{
				ShaderProperty shaderProperty = properties[i];
				if (shaderProperty.ShaderPropertyType == ShaderPropertyType.TexEnv)
				{
					yield return new TextureExportItem(m.GetTexture(shaderProperty.Key), GetglTFTextureType(m.shader.name, shaderProperty.Key));
				}
			}
		}

		private static BytesWithMime GetBytesWithMime(Texture texture, glTFTextureTypes textureType)
		{
			return new BytesWithMime
			{
				Bytes = TextureItem.CopyTexture(texture, GetColorSpace(textureType), null).EncodeToPNG(),
				Mime = "image/png"
			};
		}

		public static int ExportTexture(glTF gltf, int bufferIndex, Texture texture, glTFTextureTypes textureType)
		{
			BytesWithMime bytesWithMime = GetBytesWithMime(texture, textureType);
			glTFBufferView view = gltf.buffers[bufferIndex].Append(bytesWithMime.Bytes, glBufferTarget.NONE);
			int bufferView = gltf.AddBufferView(view);
			int count = gltf.images.Count;
			gltf.images.Add(new glTFImage
			{
				name = texture.name,
				bufferView = bufferView,
				mimeType = bytesWithMime.Mime
			});
			int count2 = gltf.samplers.Count;
			glTFTextureSampler item = TextureSamplerUtil.Export(texture);
			gltf.samplers.Add(item);
			gltf.textures.Add(new glTFTexture
			{
				sampler = count2,
				source = count
			});
			return count;
		}
	}
}
