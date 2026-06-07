using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

[ExecuteInEditMode]
public class Lightcaster : MonoBehaviour
{
	public enum Mode
	{
		Static = 0,
		Dynamic = 1
	}

	public enum Depth
	{
		Color = 0,
		Monochrome = 1
	}

	public enum Shadows
	{
		None = 0,
		Hard = 1,
		Area = 2,
		PCF = 3,
		VSM = 4,
		PCSS = 5,
		Jitter = 6
	}

	[Serializable]
	public class FamilyBakeStats
	{
		public int lightCount;

		public int lightmapCount;

		public int lightmapBytes;

		public int receiverCount;

		public string text;

		public bool empty
		{
			get
			{
				return string.IsNullOrEmpty(text);
			}
		}

		public override string ToString()
		{
			return (text == null) ? string.Empty : text;
		}

		public void Clear()
		{
			lightCount = 0;
			receiverCount = 0;
			lightmapCount = 0;
			lightmapBytes = 0;
			text = null;
		}
	}

	[Serializable]
	public class Family
	{
		public string id = "Default";

		public bool enabled = true;

		public Depth depth;

		[Range(1f, 150f)]
		public int resolution = 20;

		public Shadows shadows = Shadows.PCSS;

		[Range(0f, 10f)]
		public int softness = 2;

		public Color color = Color.white;

		public bool separateLights;

		[LightcastBaked]
		public FamilyBakeStats bakeStats = new FamilyBakeStats();

		public void Clear()
		{
			bakeStats.Clear();
		}
	}

	[Serializable]
	public class FamilyMemberId
	{
		public string familyId;

		public int indexInFamily;

		public FamilyMemberId()
		{
		}

		public FamilyMemberId(FamilyMemberId src)
		{
			familyId = src.familyId;
			indexInFamily = src.indexInFamily;
		}

		public FamilyMemberId(string familyId_, int indexInFamily_)
		{
			familyId = familyId_;
			indexInFamily = indexInFamily_;
		}

		public override string ToString()
		{
			return string.Format("{0}-{1:D02}", familyId, indexInFamily);
		}

		public override bool Equals(object other)
		{
			FamilyMemberId familyMemberId = other as FamilyMemberId;
			return familyMemberId != null && familyMemberId.familyId == familyId && familyMemberId.indexInFamily == indexInFamily;
		}

		public override int GetHashCode()
		{
			return familyId.GetHashCode() ^ indexInFamily;
		}
	}

	[Serializable]
	public class LightmappedRenderer
	{
		public Renderer renderer;

		public int lightmapIndex;

		public Vector4 lightmapScaleOffset;
	}

	[Serializable]
	public class DynamicLayerAlpha
	{
		public FamilyMemberId familyMemberId;

		public float alpha = 1f;

		public DynamicLayerAlpha(FamilyMemberId familyMemberId_)
		{
			familyMemberId = familyMemberId_;
		}
	}

	private class DynamicLightmapTarget
	{
		public RenderTexture target;

		public MaterialPropertyBlock propertyBlock;

		public DynamicLightmapTarget(LightcastAsset.DynamicLightmap dynamicLightmap)
		{
			target = new RenderTexture(dynamicLightmap.width, dynamicLightmap.height, 0, dynamicLightmap.format, RenderTextureReadWrite.Linear);
			target.useMipMap = false;
			propertyBlock = new MaterialPropertyBlock();
			propertyBlock.SetTexture("_LightcastTex", target);
		}

		public void Destroy()
		{
			propertyBlock = null;
			if (target != null)
			{
				UnityEngine.Object.DestroyImmediate(target);
				target = null;
			}
		}
	}

	public Mode mode;

	public Depth depth;

	public List<Family> families = new List<Family>();

	[LightcastBaked]
	public LightcastAsset asset;

	[LightcastBaked]
	public List<LightmappedRenderer> lightmappedRenderers = new List<LightmappedRenderer>();

	[LightcastBaked]
	public List<DynamicLayerAlpha> dynamicLayerAlphas = new List<DynamicLayerAlpha>();

	[LightcastBaked]
	public string bakeDescription;

	public Camera mainCameraOverride;

	private Plane[] mainCameraFrustumPlanes_ = new Plane[6];

	private int mainCameraFrustumPlanesFrame;

	private CommandBuffer commandBuffer;

	private List<DynamicLightmapTarget> dynamicLightmapTargets = new List<DynamicLightmapTarget>();

	private int dynamicLightmapTargetUpdateRoundRobin;

	private static Lightcaster instance_;

	public const float kAlphaZeroThresh = 0.001f;

	public Camera mainCamera
	{
		get
		{
			return (!(mainCameraOverride != null)) ? Player.instance.mainCamera : mainCameraOverride;
		}
	}

	public Plane[] mainCameraFrustumPlanes
	{
		get
		{
			if (mainCameraFrustumPlanesFrame != Time.frameCount)
			{
				mainCameraFrustumPlanesFrame = Time.frameCount;
				GeometryUtilityAllocFree.CalculateFrustumPlanes(mainCamera, mainCameraFrustumPlanes_);
			}
			return mainCameraFrustumPlanes_;
		}
	}

	public static Lightcaster instance
	{
		get
		{
			if (instance_ == null)
			{
				instance_ = UnityEngine.Object.FindObjectOfType<Lightcaster>();
			}
			return instance_;
		}
	}

	private void OnEnable()
	{
		Shader.SetGlobalTexture("_LightcastTex", Texture2D.blackTexture);
		if (asset != null)
		{
			if (asset.isDynamic)
			{
				List<LightmapData> list = new List<LightmapData>();
				list.Add(new LightmapData
				{
					lightmapColor = Texture2D.blackTexture
				});
				LightmapSettings.lightmaps = list.ToArray();
				LightmapSettings.lightmapsMode = LightmapsMode.NonDirectional;
				commandBuffer = new CommandBuffer();
				foreach (LightcastAsset.DynamicLightmap dynamicLightmap in asset.dynamicLightmaps)
				{
					dynamicLightmapTargets.Add(new DynamicLightmapTarget(dynamicLightmap));
				}
				foreach (LightmappedRenderer lightmappedRenderer in lightmappedRenderers)
				{
					if (!(lightmappedRenderer.renderer == null))
					{
						lightmappedRenderer.renderer.lightmapIndex = 0;
						lightmappedRenderer.renderer.SetPropertyBlock(dynamicLightmapTargets[lightmappedRenderer.lightmapIndex].propertyBlock);
						lightmappedRenderer.renderer.lightmapScaleOffset = lightmappedRenderer.lightmapScaleOffset;
					}
				}
			}
			else
			{
				List<LightmapData> list2 = new List<LightmapData>();
				foreach (Texture2D staticLightmap in asset.staticLightmaps)
				{
					list2.Add(new LightmapData
					{
						lightmapColor = staticLightmap
					});
				}
				LightmapSettings.lightmaps = list2.ToArray();
				LightmapSettings.lightmapsMode = LightmapsMode.NonDirectional;
				foreach (LightmappedRenderer lightmappedRenderer2 in lightmappedRenderers)
				{
					if (!(lightmappedRenderer2.renderer == null))
					{
						lightmappedRenderer2.renderer.lightmapIndex = lightmappedRenderer2.lightmapIndex;
						lightmappedRenderer2.renderer.lightmapScaleOffset = lightmappedRenderer2.lightmapScaleOffset;
						lightmappedRenderer2.renderer.SetPropertyBlock(null);
					}
				}
			}
			bool flag = asset.dynamicLightmaps.Count > 0 || asset.staticLightmaps.Count > 0;
			LightcastLight[] array = UnityEngine.Object.FindObjectsOfType<LightcastLight>();
			foreach (LightcastLight lightcastLight in array)
			{
				LightBakingOutput bakingOutput = new LightBakingOutput
				{
					isBaked = flag,
					lightmapBakeType = ((!flag) ? LightmapBakeType.Realtime : LightmapBakeType.Baked)
				};
				lightcastLight.sourceLight.bakingOutput = bakingOutput;
			}
		}
		if (families.Count == 0)
		{
			families.Add(new Family());
		}
	}

	private void OnDisable()
	{
		if (asset != null && asset.isDynamic)
		{
			foreach (LightmappedRenderer lightmappedRenderer in lightmappedRenderers)
			{
				if (!(lightmappedRenderer.renderer == null))
				{
					lightmappedRenderer.renderer.SetPropertyBlock(null);
				}
			}
		}
		if (commandBuffer != null)
		{
			commandBuffer.Dispose();
			commandBuffer = null;
		}
		foreach (DynamicLightmapTarget dynamicLightmapTarget in dynamicLightmapTargets)
		{
			dynamicLightmapTarget.Destroy();
		}
		dynamicLightmapTargets.Clear();
	}

	private void LateUpdate()
	{
		if (asset != null && asset.isDynamic)
		{
			RenderDynamicLightmaps();
		}
	}

	private void RenderDynamicLightmaps()
	{
		if (asset.dynamicLightmaps.Count == 0)
		{
			return;
		}
		commandBuffer.Clear();
		int num = Mathf.Min(4, asset.dynamicLightmaps.Count);
		for (int i = 0; i < num; i++)
		{
			dynamicLightmapTargetUpdateRoundRobin = (dynamicLightmapTargetUpdateRoundRobin + 1) % asset.dynamicLightmaps.Count;
			LightcastAsset.DynamicLightmap dynamicLightmap = asset.dynamicLightmaps[dynamicLightmapTargetUpdateRoundRobin];
			commandBuffer.SetRenderTarget(dynamicLightmapTargets[dynamicLightmapTargetUpdateRoundRobin].target);
			commandBuffer.ClearRenderTarget(false, true, Color.clear);
			Matrix4x4 identity = Matrix4x4.identity;
			foreach (LightcastAsset.DynamicLightmap.CopyOp copyOp in dynamicLightmap.copyOps)
			{
				float alpha = dynamicLayerAlphas[copyOp.dynamicLayerIndex].alpha;
				if (!(alpha < 0.001f))
				{
					LightcastAsset.DynamicLayer dynamicLayer = asset.dynamicLayers[copyOp.dynamicLayerIndex];
					LightcastAsset.DynamicLayer.Page page = dynamicLayer.pages[copyOp.srcPage];
					commandBuffer.SetGlobalMatrix("_ColorMatrix", Matrix4x4.Scale(alpha * Vector3.one) * page.colorMatrix);
					commandBuffer.DrawMesh(copyOp.dstMesh, identity, page.material);
				}
			}
		}
		Graphics.ExecuteCommandBuffer(commandBuffer);
	}

	public void SetDynamicLayerAlpha(int layerIndex, float alpha)
	{
		if (layerIndex >= 0 && layerIndex < dynamicLayerAlphas.Count)
		{
			dynamicLayerAlphas[layerIndex].alpha = alpha;
		}
	}

	public float GetDynamicLayerAlpha(int layerIndex)
	{
		return (layerIndex < 0 || layerIndex >= dynamicLayerAlphas.Count) ? 1f : dynamicLayerAlphas[layerIndex].alpha;
	}

	public List<int> GetDynamicLayerIndexes(string familyId)
	{
		List<int> list = new List<int>();
		for (int i = 0; i < dynamicLayerAlphas.Count; i++)
		{
			if (dynamicLayerAlphas[i].familyMemberId.familyId == familyId)
			{
				list.Add(i);
			}
		}
		return list;
	}
}
