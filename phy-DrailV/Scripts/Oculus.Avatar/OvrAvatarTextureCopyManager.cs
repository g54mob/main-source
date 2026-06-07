using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OvrAvatarTextureCopyManager : MonoBehaviour
{
	[Serializable]
	public struct FallbackTextureSet
	{
		public bool Initialized;

		public Texture2D DiffuseRoughness;

		public Texture2D Normal;
	}

	private struct CopyTextureParams
	{
		public Texture Src;

		public Texture Dst;

		public int Mip;

		public int SrcSize;

		public int DstElement;

		public CopyTextureParams(Texture src, Texture dst, int mip, int srcSize, int dstElement)
		{
			Src = src;
			Dst = dst;
			Mip = mip;
			SrcSize = srcSize;
			DstElement = dstElement;
		}
	}

	public struct TextureSet
	{
		public Dictionary<ulong, bool> TextureIDSingleMeshPair;

		public bool IsProcessed;

		public TextureSet(Dictionary<ulong, bool> textureIDSingleMeshPair, bool isProcessed)
		{
			TextureIDSingleMeshPair = textureIDSingleMeshPair;
			IsProcessed = isProcessed;
		}
	}

	public FallbackTextureSet[] FallbackTextureSets = new FallbackTextureSet[6];

	private Queue<CopyTextureParams> texturesToCopy;

	private Dictionary<int, TextureSet> textureSets;

	private const int TEXTURES_TO_COPY_QUEUE_CAPACITY = 256;

	private const int COPIES_PER_FRAME = 8;

	private readonly string[] FALLBACK_TEXTURE_PATHS_DIFFUSE_ROUGHNESS = new string[6] { "null", "FallbackTextures/fallback_diffuse_roughness_256", "null", "FallbackTextures/fallback_diffuse_roughness_1024", "null", "FallbackTextures/fallback_diffuse_roughness_2048" };

	private readonly string[] FALLBACK_TEXTURE_PATHS_NORMAL = new string[6] { "null", "FallbackTextures/fallback_normal_256", "null", "FallbackTextures/fallback_normal_1024", "null", "FallbackTextures/fallback_normal_2048" };

	private const string PATH_HIGHEST_DIFFUSE_ROUGHNESS = "FallbackTextures/fallback_diffuse_roughness_2048";

	private const string PATH_MEDIUM_DIFFUSE_ROUGHNESS = "FallbackTextures/fallback_diffuse_roughness_1024";

	private const string PATH_LOWEST_DIFFUSE_ROUGHNESS = "FallbackTextures/fallback_diffuse_roughness_256";

	private const string PATH_HIGHEST_NORMAL = "FallbackTextures/fallback_normal_2048";

	private const string PATH_MEDIUM_NORMAL = "FallbackTextures/fallback_normal_1024";

	private const string PATH_LOWEST_NORMAL = "FallbackTextures/fallback_normal_256";

	private const int GPU_TEXTURE_COPY_WAIT_TIME = 10;

	public OvrAvatarTextureCopyManager()
	{
		texturesToCopy = new Queue<CopyTextureParams>(256);
		textureSets = new Dictionary<int, TextureSet>();
	}

	public void Update()
	{
		if (texturesToCopy.Count == 0)
		{
			return;
		}
		lock (texturesToCopy)
		{
			for (int i = 0; i < Mathf.Min(8, texturesToCopy.Count); i++)
			{
				CopyTexture(texturesToCopy.Dequeue());
			}
		}
	}

	public int GetTextureCount()
	{
		return texturesToCopy.Count;
	}

	public void CopyTexture(Texture src, Texture dst, int mipLevel, int mipSize, int dstElement, bool useQueue = true)
	{
		CopyTextureParams copyTextureParams = new CopyTextureParams(src, dst, mipLevel, mipSize, dstElement);
		if (useQueue)
		{
			lock (texturesToCopy)
			{
				if (texturesToCopy.Count < 256)
				{
					texturesToCopy.Enqueue(copyTextureParams);
				}
				else
				{
					CopyTexture(copyTextureParams);
				}
				return;
			}
		}
		CopyTexture(copyTextureParams);
	}

	private void CopyTexture(CopyTextureParams copyTextureParams)
	{
		Graphics.CopyTexture(copyTextureParams.Src, 0, copyTextureParams.Mip, copyTextureParams.Dst, copyTextureParams.DstElement, copyTextureParams.Mip);
	}

	public void AddTextureIDToTextureSet(int gameobjectID, ulong textureID, bool isSingleMesh)
	{
		bool value2;
		if (!textureSets.ContainsKey(gameobjectID))
		{
			TextureSet value = new TextureSet(new Dictionary<ulong, bool>(), isProcessed: false);
			value.TextureIDSingleMeshPair.Add(textureID, isSingleMesh);
			textureSets.Add(gameobjectID, value);
		}
		else if (textureSets[gameobjectID].TextureIDSingleMeshPair.TryGetValue(textureID, out value2))
		{
			if (!value2 && isSingleMesh)
			{
				textureSets[gameobjectID].TextureIDSingleMeshPair[textureID] = true;
			}
		}
		else
		{
			textureSets[gameobjectID].TextureIDSingleMeshPair.Add(textureID, isSingleMesh);
		}
	}

	public void DeleteTextureSet(int gameobjectID)
	{
		if (textureSets.TryGetValue(gameobjectID, out var value) && !value.IsProcessed)
		{
			StartCoroutine(DeleteTextureSetCoroutine(value, gameobjectID));
		}
	}

	private IEnumerator DeleteTextureSetCoroutine(TextureSet textureSetToDelete, int gameobjectID)
	{
		yield return new WaitForSeconds(10f);
		while (OvrAvatarSDKManager.Instance.IsAvatarLoading())
		{
			yield return null;
		}
		foreach (KeyValuePair<ulong, bool> item in textureSetToDelete.TextureIDSingleMeshPair)
		{
			bool flag = !item.Value;
			if (flag)
			{
				foreach (KeyValuePair<int, TextureSet> textureSet in textureSets)
				{
					if (textureSet.Key == gameobjectID)
					{
						continue;
					}
					foreach (KeyValuePair<ulong, bool> item2 in textureSet.Value.TextureIDSingleMeshPair)
					{
						if (item2.Key == item.Key && (!textureSet.Value.IsProcessed || item2.Value))
						{
							flag = false;
							break;
						}
					}
					if (!flag)
					{
						break;
					}
				}
			}
			if (flag)
			{
				Texture2D loadedTexture = OvrAvatarComponent.GetLoadedTexture(item.Key);
				if (loadedTexture != null)
				{
					OvrAvatarSDKManager.Instance.DeleteAssetFromCache(item.Key);
					UnityEngine.Object.Destroy(loadedTexture);
				}
			}
		}
		textureSetToDelete.IsProcessed = true;
		textureSets.Remove(gameobjectID);
	}

	public void CheckFallbackTextureSet(ovrAvatarAssetLevelOfDetail lod)
	{
		if (!FallbackTextureSets[(int)lod].Initialized)
		{
			InitFallbackTextureSet(lod);
		}
	}

	private void InitFallbackTextureSet(ovrAvatarAssetLevelOfDetail lod)
	{
		FallbackTextureSets[(int)lod].DiffuseRoughness = (FallbackTextureSets[(int)lod].DiffuseRoughness = Resources.Load<Texture2D>(FALLBACK_TEXTURE_PATHS_DIFFUSE_ROUGHNESS[(int)lod]));
		FallbackTextureSets[(int)lod].Normal = (FallbackTextureSets[(int)lod].Normal = Resources.Load<Texture2D>(FALLBACK_TEXTURE_PATHS_NORMAL[(int)lod]));
		FallbackTextureSets[(int)lod].Initialized = true;
	}
}
