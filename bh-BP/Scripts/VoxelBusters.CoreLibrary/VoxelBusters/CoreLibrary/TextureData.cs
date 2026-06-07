using UnityEngine;

namespace VoxelBusters.CoreLibrary
{
	public class TextureData
	{
		private byte[] m_rawData;

		private Texture2D m_texture;

		public TextureData(byte[] rawData)
		{
		}

		public TextureData(Texture2D texture)
		{
		}

		public byte[] GetBytes(TextureEncodingFormat format)
		{
			return null;
		}

		public Texture2D GetTexture()
		{
			return null;
		}

		private Texture2D CreateTexture(byte[] data)
		{
			return null;
		}
	}
}
