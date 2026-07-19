using UnityEngine;

namespace UniGLTF
{
	public class NormalConverter : ITextureConverter
	{
		private const string m_extension = ".normal";

		private Material m_decoder;

		private Material m_encoder;

		private Material GetDecoder()
		{
			if (m_decoder == null)
			{
				m_decoder = new Material(Shader.Find("UniGLTF/NormalMapDecoder"));
			}
			return m_decoder;
		}

		private Material GetEncoder()
		{
			if (m_encoder == null)
			{
				m_encoder = new Material(Shader.Find("UniGLTF/NormalMapEncoder"));
			}
			return m_encoder;
		}

		public Texture2D GetImportTexture(Texture2D texture)
		{
			Material encoder = GetEncoder();
			Texture2D texture2D = TextureConverter.Convert(texture, glTFTextureTypes.Normal, null, encoder);
			TextureConverter.AppendTextureExtension(texture2D, ".normal");
			return texture2D;
		}

		public Texture2D GetExportTexture(Texture2D texture)
		{
			Material decoder = GetDecoder();
			Texture2D texture2D = TextureConverter.Convert(texture, glTFTextureTypes.Normal, null, decoder);
			TextureConverter.RemoveTextureExtension(texture2D, ".normal");
			return texture2D;
		}
	}
}
