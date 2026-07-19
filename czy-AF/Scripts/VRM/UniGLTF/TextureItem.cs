using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using DepthFirstScheduler;
using UnityEngine;

namespace UniGLTF
{
	public class TextureItem
	{
		private struct ColorSpaceScope : IDisposable
		{
			private bool m_sRGBWrite;

			public ColorSpaceScope(RenderTextureReadWrite colorSpace)
			{
				m_sRGBWrite = GL.sRGBWrite;
				switch (colorSpace)
				{
				case RenderTextureReadWrite.Linear:
					GL.sRGBWrite = false;
					break;
				default:
					GL.sRGBWrite = true;
					break;
				}
			}

			public ColorSpaceScope(bool sRGBWrite)
			{
				m_sRGBWrite = GL.sRGBWrite;
				GL.sRGBWrite = sRGBWrite;
			}

			public void Dispose()
			{
				GL.sRGBWrite = m_sRGBWrite;
			}
		}

		private int m_textureIndex;

		private Dictionary<string, Texture2D> m_converts = new Dictionary<string, Texture2D>();

		private ITextureLoader m_textureLoader;

		public Texture2D Texture => m_textureLoader.Texture;

		public Dictionary<string, Texture2D> Converts => m_converts;

		public bool IsAsset { get; private set; }

		public Texture2D ConvertTexture(string prop, float smoothnessOrRoughness = 1f)
		{
			KeyValuePair<string, Texture2D> keyValuePair = Converts.FirstOrDefault((KeyValuePair<string, Texture2D> x) => x.Key == prop);
			if (keyValuePair.Value != null)
			{
				return keyValuePair.Value;
			}
			if (prop == "_BumpMap")
			{
				if (Application.isPlaying)
				{
					Texture2D importTexture = new NormalConverter().GetImportTexture(Texture);
					m_converts.Add(prop, importTexture);
					return importTexture;
				}
				return Texture;
			}
			if (prop == "_MetallicGlossMap")
			{
				Texture2D importTexture2 = new MetallicRoughnessConverter(smoothnessOrRoughness).GetImportTexture(Texture);
				m_converts.Add(prop, importTexture2);
				return importTexture2;
			}
			if (prop == "_OcclusionMap")
			{
				Texture2D importTexture3 = new OcclusionConverter().GetImportTexture(Texture);
				m_converts.Add(prop, importTexture3);
				return importTexture3;
			}
			return null;
		}

		public IEnumerable<Texture2D> GetTexturesForSaveAssets()
		{
			if (!IsAsset)
			{
				yield return Texture;
			}
			if (!m_converts.Any())
			{
				yield break;
			}
			foreach (KeyValuePair<string, Texture2D> convert in m_converts)
			{
				yield return convert.Value;
			}
		}

		public TextureItem(int index, ITextureLoader textureLoader)
		{
			m_textureIndex = index;
			m_textureLoader = textureLoader;
			if (m_textureLoader == null)
			{
				throw new Exception("ITextureLoader is null.");
			}
		}

		public void Process(glTF gltf, IStorage storage)
		{
			ProcessOnAnyThread(gltf, storage);
			ProcessOnMainThreadCoroutine(gltf).CoroutineToEnd();
		}

		public IEnumerator ProcessCoroutine(glTF gltf, IStorage storage)
		{
			ProcessOnAnyThread(gltf, storage);
			yield return ProcessOnMainThreadCoroutine(gltf);
		}

		public void ProcessOnAnyThread(glTF gltf, IStorage storage)
		{
			m_textureLoader.ProcessOnAnyThread(gltf, storage);
		}

		public IEnumerator ProcessOnMainThreadCoroutine(glTF gltf)
		{
			using (m_textureLoader)
			{
				bool isLinear = TextureIO.GetColorSpace(TextureIO.GetglTFTextureType(gltf, m_textureIndex)) == RenderTextureReadWrite.Linear;
				yield return m_textureLoader.ProcessOnMainThread(isLinear);
				TextureSamplerUtil.SetSampler(Texture, gltf.GetSamplerFromTextureIndex(m_textureIndex));
			}
		}

		public static Texture2D CopyTexture(Texture src, RenderTextureReadWrite colorSpace, Material material)
		{
			RenderTexture renderTexture = new RenderTexture(src.width, src.height, 0, RenderTextureFormat.ARGB32, colorSpace);
			using (new ColorSpaceScope(colorSpace))
			{
				if (material != null)
				{
					Graphics.Blit(src, renderTexture, material);
				}
				else
				{
					Graphics.Blit(src, renderTexture);
				}
			}
			Texture2D texture2D = new Texture2D(src.width, src.height, TextureFormat.ARGB32, mipChain: false, colorSpace == RenderTextureReadWrite.Linear);
			texture2D.ReadPixels(new Rect(0f, 0f, src.width, src.height), 0, 0);
			texture2D.name = src.name;
			texture2D.anisoLevel = src.anisoLevel;
			texture2D.filterMode = src.filterMode;
			texture2D.mipMapBias = src.mipMapBias;
			texture2D.wrapMode = src.wrapMode;
			texture2D.wrapModeU = src.wrapModeU;
			texture2D.wrapModeV = src.wrapModeV;
			texture2D.wrapModeW = src.wrapModeW;
			texture2D.Apply();
			RenderTexture.active = null;
			if (Application.isEditor)
			{
				UnityEngine.Object.DestroyImmediate(renderTexture);
				return texture2D;
			}
			UnityEngine.Object.Destroy(renderTexture);
			return texture2D;
		}
	}
}
