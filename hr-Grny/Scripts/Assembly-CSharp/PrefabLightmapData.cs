using System;
using UnityEngine;

public class PrefabLightmapData : MonoBehaviour
{
	[Serializable]
	private struct RendererInfo
	{
		public Renderer renderer;

		public int lightmapIndex;

		public Vector4 lightmapOffsetScale;
	}

	[SerializeField]
	private RendererInfo[] m_RendererInfo;

	[SerializeField]
	private Texture2D[] m_Lightmaps;

	private void Awake()
	{
	}

	private static void ApplyRendererInfo(RendererInfo[] infos, int lightmapOffsetIndex)
	{
	}
}
