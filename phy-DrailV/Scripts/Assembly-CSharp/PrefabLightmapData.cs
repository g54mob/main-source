using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

[ExecuteAlways]
public class PrefabLightmapData : MonoBehaviour
{
	[Serializable]
	private struct RendererInfo
	{
		public Renderer renderer;

		public int lightmapIndex;

		public Vector4 lightmapOffsetScale;
	}

	[Serializable]
	private struct LightInfo
	{
		public Light light;

		public int lightmapBaketype;

		public int mixedLightingMode;
	}

	[SerializeField]
	private RendererInfo[] m_RendererInfo;

	[SerializeField]
	private Texture2D[] m_Lightmaps;

	[SerializeField]
	private Texture2D[] m_LightmapsDir;

	[SerializeField]
	private Texture2D[] m_ShadowMasks;

	[SerializeField]
	private LightInfo[] m_LightInfo;

	private void Awake()
	{
		Init();
	}

	private void Init()
	{
		if (m_RendererInfo == null || m_RendererInfo.Length == 0)
		{
			return;
		}
		LightmapData[] lightmaps = LightmapSettings.lightmaps;
		int[] array = new int[m_Lightmaps.Length];
		int num = lightmaps.Length;
		List<LightmapData> list = new List<LightmapData>();
		for (int i = 0; i < m_Lightmaps.Length; i++)
		{
			bool flag = false;
			for (int j = 0; j < lightmaps.Length; j++)
			{
				if (m_Lightmaps[i] == lightmaps[j].lightmapColor)
				{
					flag = true;
					array[i] = j;
				}
			}
			if (!flag)
			{
				array[i] = num;
				LightmapData item = new LightmapData
				{
					lightmapColor = m_Lightmaps[i],
					lightmapDir = ((m_LightmapsDir.Length == m_Lightmaps.Length) ? m_LightmapsDir[i] : null),
					shadowMask = ((m_ShadowMasks.Length == m_Lightmaps.Length) ? m_ShadowMasks[i] : null)
				};
				list.Add(item);
				num++;
			}
		}
		LightmapData[] array2 = new LightmapData[num];
		lightmaps.CopyTo(array2, 0);
		list.ToArray().CopyTo(array2, lightmaps.Length);
		bool flag2 = true;
		Texture2D[] lightmapsDir = m_LightmapsDir;
		for (int k = 0; k < lightmapsDir.Length; k++)
		{
			if (lightmapsDir[k] == null)
			{
				flag2 = false;
				break;
			}
		}
		LightmapSettings.lightmapsMode = ((m_LightmapsDir.Length == m_Lightmaps.Length && flag2) ? LightmapsMode.CombinedDirectional : LightmapsMode.NonDirectional);
		ApplyRendererInfo(m_RendererInfo, array, m_LightInfo);
		LightmapSettings.lightmaps = array2;
	}

	private void OnEnable()
	{
		SceneManager.sceneLoaded += OnSceneLoaded;
	}

	private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
	{
		Init();
	}

	private void OnDisable()
	{
		SceneManager.sceneLoaded -= OnSceneLoaded;
	}

	private static void ApplyRendererInfo(RendererInfo[] infos, int[] lightmapOffsetIndex, LightInfo[] lightsInfo)
	{
		for (int i = 0; i < infos.Length; i++)
		{
			RendererInfo rendererInfo = infos[i];
			rendererInfo.renderer.lightmapIndex = lightmapOffsetIndex[rendererInfo.lightmapIndex];
			rendererInfo.renderer.lightmapScaleOffset = rendererInfo.lightmapOffsetScale;
			Material[] sharedMaterials = rendererInfo.renderer.sharedMaterials;
			for (int j = 0; j < sharedMaterials.Length; j++)
			{
				if (sharedMaterials[j] != null && Shader.Find(sharedMaterials[j].shader.name) != null)
				{
					sharedMaterials[j].shader = Shader.Find(sharedMaterials[j].shader.name);
				}
			}
		}
		for (int k = 0; k < lightsInfo.Length; k++)
		{
			LightBakingOutput bakingOutput = new LightBakingOutput
			{
				isBaked = true,
				lightmapBakeType = (LightmapBakeType)lightsInfo[k].lightmapBaketype,
				mixedLightingMode = (MixedLightingMode)lightsInfo[k].mixedLightingMode
			};
			lightsInfo[k].light.bakingOutput = bakingOutput;
		}
	}
}
