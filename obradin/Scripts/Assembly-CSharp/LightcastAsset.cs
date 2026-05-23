using System;
using System.Collections.Generic;
using UnityEngine;

public class LightcastAsset : ScriptableObject
{
	[Serializable]
	public class DynamicLayer
	{
		[Serializable]
		public class Page
		{
			public Texture2D texture;

			public Matrix4x4 colorMatrix;

			public Material material;
		}

		public Lightcaster.FamilyMemberId familyMemberId;

		public List<Page> pages = new List<Page>();

		public List<Texture2D> uniqueTextures
		{
			get
			{
				List<Texture2D> list = new List<Texture2D>();
				int num = -1;
				foreach (Page page in pages)
				{
					if (num != page.texture.GetInstanceID())
					{
						list.Add(page.texture);
					}
					num = page.texture.GetInstanceID();
				}
				return list;
			}
		}
	}

	[Serializable]
	public class DynamicLightmap
	{
		[Serializable]
		public class CopyOp
		{
			public int dynamicLayerIndex;

			public int srcPage;

			public Mesh dstMesh;
		}

		public int width;

		public int height;

		public RenderTextureFormat format;

		public List<CopyOp> copyOps = new List<CopyOp>();
	}

	public List<Texture2D> staticLightmaps;

	public Shader mergeShader;

	public List<DynamicLayer> dynamicLayers;

	public List<DynamicLightmap> dynamicLightmaps;

	public bool isDynamic
	{
		get
		{
			return dynamicLayers.Count != 0;
		}
	}

	public void OnEnable()
	{
		if (staticLightmaps == null)
		{
			staticLightmaps = new List<Texture2D>();
			dynamicLayers = new List<DynamicLayer>();
			dynamicLightmaps = new List<DynamicLightmap>();
		}
	}

	public void Clear()
	{
		staticLightmaps.Clear();
		dynamicLightmaps.Clear();
		dynamicLayers.Clear();
	}

	public int FindDynamicLayerIndex(Lightcaster.FamilyMemberId familyMemberId)
	{
		int num = 0;
		foreach (DynamicLayer dynamicLayer in dynamicLayers)
		{
			if (dynamicLayer.familyMemberId.Equals(familyMemberId))
			{
				return num;
			}
			num++;
		}
		return -1;
	}
}
