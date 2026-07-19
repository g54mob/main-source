using System;
using System.Collections;
using System.IO;
using UnityEngine;
using UnityEngine.Networking;

namespace UniGLTF
{
	public class UnityWebRequestTextureLoader : ITextureLoader, IDisposable
	{
		private class Deleter : IDisposable
		{
			private string m_path;

			public Deleter(string path)
			{
				m_path = path;
			}

			public void Dispose()
			{
				if (File.Exists(m_path))
				{
					File.Delete(m_path);
				}
			}
		}

		private int m_textureIndex;

		private UnityWebRequest m_uwr;

		private ArraySegment<byte> m_segments;

		private string m_textureName;

		public Texture2D Texture { get; private set; }

		public UnityWebRequestTextureLoader(int textureIndex)
		{
			m_textureIndex = textureIndex;
		}

		public void Dispose()
		{
			if (m_uwr != null)
			{
				m_uwr.Dispose();
				m_uwr = null;
			}
		}

		public void ProcessOnAnyThread(glTF gltf, IStorage storage)
		{
			int imageIndexFromTextureIndex = gltf.GetImageIndexFromTextureIndex(m_textureIndex);
			m_segments = gltf.GetImageBytes(storage, imageIndexFromTextureIndex, out m_textureName);
		}

		public IEnumerator ProcessOnMainThread(bool isLinear)
		{
			string tempFileName = Path.GetTempFileName();
			using (FileStream fileStream = new FileStream(tempFileName, FileMode.Create))
			{
				fileStream.Write(m_segments.Array, m_segments.Offset, m_segments.Count);
			}
			using (new Deleter(tempFileName))
			{
				string text = "file:///" + tempFileName.Replace("\\", "/");
				Debug.LogFormat("UnityWebRequest: {0}", text);
				using UnityWebRequest m_uwr = UnityWebRequestTexture.GetTexture(text, nonReadable: true);
				yield return m_uwr.SendWebRequest();
				if (m_uwr.isNetworkError || m_uwr.isHttpError)
				{
					Debug.LogWarning(m_uwr.error);
					yield break;
				}
				Texture = ((DownloadHandlerTexture)m_uwr.downloadHandler).texture;
				Texture.name = m_textureName;
			}
		}
	}
}
