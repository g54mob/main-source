using System;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

namespace Pug.Sprite
{
	public class SpriteAssetManager : MonoBehaviour
	{
		public const int GRADIENT_MAP_WIDTH = 256;

		public static readonly List<SpriteAssetBase> loadedSpriteAssets = new List<SpriteAssetBase>();

		public static readonly List<GradientMapDataBlock> loadedGradientMaps = new List<GradientMapDataBlock>();

		private static bool m_assetsLoaded;

		public static Dictionary<object, SpriteAsset> assetLookup = new Dictionary<object, SpriteAsset>();

		public static Dictionary<object, SpriteAssetSkin> skinLookup = new Dictionary<object, SpriteAssetSkin>();

		public static Dictionary<object, Texture2D> gradientLookup = new Dictionary<object, Texture2D>();

		private static Dictionary<GradientMapDataBlock, int> s_gradientMapLookup;

		private static Texture2D s_gradientMapAtlas;

		private static List<SpriteAssetBase> m_additionalSpriteAssets = new List<SpriteAssetBase>();

		private static List<GradientMapDataBlock> m_additionalGradientMaps = new List<GradientMapDataBlock>();

		private static List<TransformAnimation> m_additionalTransformAnimations = new List<TransformAnimation>();

		public static bool isLoaded { get; private set; } = false;

		public static event Action<bool> onCompileCompleted;

		[RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.SubsystemRegistration)]
		private static void Init()
		{
			isLoaded = false;
			m_additionalSpriteAssets.Clear();
			m_additionalGradientMaps.Clear();
			m_additionalTransformAnimations.Clear();
		}

		public static int GetGradientIndex(GradientMapDataBlock gradient)
		{
			if (gradient == null || !s_gradientMapLookup.TryGetValue(gradient, out var value))
			{
				return -1;
			}
			return value;
		}

		public static bool IsSpriteAssetLoaded(SpriteAssetBase spriteAsset)
		{
			return loadedSpriteAssets.Contains(spriteAsset);
		}

		public static void AddAdditionalAssets(List<SpriteAssetBase> spriteAssets, List<GradientMapDataBlock> gradientMaps, List<TransformAnimation> transformAnimations)
		{
			if (spriteAssets != null)
			{
				m_additionalSpriteAssets.AddRange(spriteAssets);
			}
			if (gradientMaps != null)
			{
				m_additionalGradientMaps.AddRange(gradientMaps);
			}
			if (transformAnimations != null)
			{
				m_additionalTransformAnimations.AddRange(transformAnimations);
			}
		}

		public static void ClearAdditionalAssets()
		{
			m_additionalSpriteAssets.Clear();
			m_additionalGradientMaps.Clear();
			m_additionalTransformAnimations.Clear();
		}

		private static void ClearLoadedAssets()
		{
			SpriteInstancingManager.ReleaseAtlas();
			loadedSpriteAssets.Clear();
			loadedGradientMaps.Clear();
			assetLookup.Clear();
			skinLookup.Clear();
			gradientLookup.Clear();
			m_assetsLoaded = false;
			isLoaded = false;
		}

		public static void LoadAndCompile()
		{
			ClearLoadedAssets();
			if (!ScriptableData.isLoaded)
			{
				ScriptableData.Load();
			}
			ScriptableData.TryGetDataBlocks(out IReadOnlyList<SpriteAssetBase> dataBlocks);
			ScriptableData.TryGetDataBlocks(out IReadOnlyList<GradientMapDataBlock> dataBlocks2);
			ScriptableData.TryGetDataBlocks(out IReadOnlyList<TransformAnimation> dataBlocks3);
			foreach (SpriteAssetBase item in dataBlocks)
			{
				if (item is SpriteAssetSkin spriteAssetSkin && spriteAssetSkin.targetAsset == null)
				{
					Debug.LogError("SpriteAssetSkin '" + spriteAssetSkin.name + "' has no target SpriteAsset", spriteAssetSkin);
				}
				else
				{
					loadedSpriteAssets.Add(item);
				}
			}
			foreach (GradientMapDataBlock item2 in dataBlocks2)
			{
				if (!item2.hasData)
				{
					Debug.LogWarning(string.Format("{0} '{1}' has no texture!", "GradientMapDataBlock", item2), item2);
				}
				else
				{
					loadedGradientMaps.Add(item2);
				}
			}
			TransformAnimation.BuildAtlas(dataBlocks3);
			m_assetsLoaded = true;
			bool obj = TryCompile();
			SpriteAssetManager.onCompileCompleted?.Invoke(obj);
		}

		private static bool TryCompile()
		{
			if (!m_assetsLoaded)
			{
				return false;
			}
			SpriteInstancingManager.renderAtlas = true;
			foreach (SpriteAssetBase loadedSpriteAsset in loadedSpriteAssets)
			{
				if (loadedSpriteAsset == null)
				{
					Debug.LogWarning("loadedSpriteAssets contained null SpriteAsset");
				}
				else
				{
					loadedSpriteAsset.CreateRuntimeData();
				}
			}
			SpriteInstancingManager.CreateAtlas(loadedSpriteAssets);
			CreateGradientMapAtlas();
			isLoaded = true;
			ClearAdditionalAssets();
			return true;
		}

		private static void ReleaseSourceAssets()
		{
			foreach (SpriteAssetBase loadedSpriteAsset in loadedSpriteAssets)
			{
				loadedSpriteAsset.ReleaseSourceAssets();
			}
		}

		public static void CreateGradientMapAtlas()
		{
			s_gradientMapLookup = new Dictionary<GradientMapDataBlock, int>();
			if (loadedGradientMaps.Count < 1)
			{
				return;
			}
			if (s_gradientMapAtlas == null || s_gradientMapAtlas.height != loadedGradientMaps.Count)
			{
				s_gradientMapAtlas = new Texture2D(256, loadedGradientMaps.Count, TextureFormat.RGB24, mipChain: false, linear: false);
			}
			Color[] array = new Color[256 * loadedGradientMaps.Count];
			for (int i = 0; i < loadedGradientMaps.Count; i++)
			{
				GradientMapDataBlock gradientMapDataBlock = loadedGradientMaps[i];
				if (gradientMapDataBlock == null)
				{
					Debug.LogError("loadedGradientMaps contained null GradientMapDataBlock.");
					continue;
				}
				if (!gradientMapDataBlock.isReadable)
				{
					Debug.LogError("Gradient map " + gradientMapDataBlock.name + " does not have Read/Write import setting enabled.", gradientMapDataBlock);
					continue;
				}
				if (gradientMapDataBlock.textureWidth != 256)
				{
					Debug.LogError($"Gradient map {gradientMapDataBlock.name} is not {256} pixels wide.", gradientMapDataBlock);
					continue;
				}
				s_gradientMapLookup.Add(gradientMapDataBlock, i);
				for (int j = 0; j < 256; j++)
				{
					array[i * 256 + j] = gradientMapDataBlock.GetPixel(j);
				}
			}
			s_gradientMapAtlas.SetPixels(array);
			s_gradientMapAtlas.Apply();
		}

		public static void UpdateShaderParameters()
		{
			if (s_gradientMapAtlas != null)
			{
				Shader.SetGlobalTexture(ShaderIDs.GradientMapAtlas, s_gradientMapAtlas);
			}
			TransformAnimation.UpdateShaderParameters();
		}

		public static bool DumpSpriteData(string path)
		{
			if (SpriteInstancingManager.atlas == null)
			{
				Debug.LogError("Unable to dump sprite data (atlas was null)");
				return false;
			}
			if (!path.EndsWith("/"))
			{
				path += "/";
			}
			Texture2D texture2D = new Texture2D(SpriteInstancingManager.atlas.width, SpriteInstancingManager.atlas.height, TextureFormat.ARGB32, mipChain: false);
			RenderTexture.active = SpriteInstancingManager.atlas;
			texture2D.ReadPixels(new Rect(0f, 0f, texture2D.width, texture2D.height), 0, 0);
			texture2D.Apply();
			byte[] bytes = texture2D.EncodeToPNG();
			File.WriteAllBytes(path + "Atlas.png", bytes);
			RenderTexture.active = SpriteInstancingManager.emissiveAtlas;
			texture2D.ReadPixels(new Rect(0f, 0f, texture2D.width, texture2D.height), 0, 0);
			texture2D.Apply();
			bytes = texture2D.EncodeToPNG();
			File.WriteAllBytes(path + "EmissiveAtlas.png", bytes);
			RenderTexture.active = SpriteInstancingManager.normalAtlas;
			texture2D.ReadPixels(new Rect(0f, 0f, texture2D.width, texture2D.height), 0, 0);
			texture2D.Apply();
			bytes = texture2D.EncodeToPNG();
			File.WriteAllBytes(path + "NormalAtlas.png", bytes);
			if (s_gradientMapAtlas != null)
			{
				bytes = s_gradientMapAtlas.EncodeToPNG();
				File.WriteAllBytes(path + "GradientMapAtlas.png", bytes);
			}
			UnityEngine.Object.Destroy(texture2D);
			return true;
		}

		private void Update()
		{
			SpriteInstancingManager.UpdateAndDraw();
		}
	}
}
