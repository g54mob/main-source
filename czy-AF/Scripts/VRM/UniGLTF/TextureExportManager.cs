using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace UniGLTF
{
	public class TextureExportManager
	{
		private List<Texture> m_textures;

		private List<Texture> m_exportTextures;

		public List<Texture> Textures => m_textures;

		public Texture GetExportTexture(int index)
		{
			if (index < 0 || index >= m_exportTextures.Count)
			{
				return null;
			}
			if (m_exportTextures[index] != null)
			{
				return m_exportTextures[index];
			}
			return m_textures[index];
		}

		public TextureExportManager(IEnumerable<Texture> textures)
		{
			m_textures = textures.ToList();
			m_exportTextures = new List<Texture>(Enumerable.Repeat<Texture>(null, m_textures.Count));
		}

		public int CopyAndGetIndex(Texture texture, RenderTextureReadWrite readWrite)
		{
			if (texture == null)
			{
				return -1;
			}
			int num = m_textures.IndexOf(texture);
			if (num == -1)
			{
				return -1;
			}
			m_exportTextures[num] = TextureItem.CopyTexture(texture, readWrite, null);
			return num;
		}

		public int ConvertAndGetIndex(Texture texture, ITextureConverter converter)
		{
			if (texture == null)
			{
				return -1;
			}
			int num = m_textures.IndexOf(texture);
			if (num == -1)
			{
				return -1;
			}
			m_exportTextures[num] = converter.GetExportTexture(texture as Texture2D);
			return num;
		}
	}
}
