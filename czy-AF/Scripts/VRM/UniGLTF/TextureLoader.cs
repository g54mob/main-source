using System;
using System.Collections;
using UnityEngine;

namespace UniGLTF
{
	public class TextureLoader : ITextureLoader, IDisposable
	{
		private int m_textureIndex;

		private byte[] m_imageBytes;

		private string m_textureName;

		public Texture2D Texture { get; private set; }

		public TextureLoader(int textureIndex)
		{
			m_textureIndex = textureIndex;
		}

		public void Dispose()
		{
		}

		private static byte[] ToArray(ArraySegment<byte> bytes)
		{
			if (bytes.Array == null)
			{
				return new byte[0];
			}
			if (bytes.Offset == 0 && bytes.Count == bytes.Array.Length)
			{
				return bytes.Array;
			}
			byte[] array = new byte[bytes.Count];
			Buffer.BlockCopy(bytes.Array, bytes.Offset, array, 0, array.Length);
			return array;
		}

		public void ProcessOnAnyThread(glTF gltf, IStorage storage)
		{
			int imageIndexFromTextureIndex = gltf.GetImageIndexFromTextureIndex(m_textureIndex);
			ArraySegment<byte> imageBytes = gltf.GetImageBytes(storage, imageIndexFromTextureIndex, out m_textureName);
			m_imageBytes = ToArray(imageBytes);
		}

		public IEnumerator ProcessOnMainThread(bool isLinear)
		{
			Texture = new Texture2D(2, 2, TextureFormat.ARGB32, mipChain: false, isLinear);
			Texture.name = m_textureName;
			if (m_imageBytes != null)
			{
				Texture.LoadImage(m_imageBytes);
			}
			yield break;
		}
	}
}
