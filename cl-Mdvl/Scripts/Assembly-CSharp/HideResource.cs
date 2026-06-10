using System.Collections.Generic;
using FoxyVoxel.Logging;
using NSEipix.Base;
using NSMedieval.Layers;
using NSMedieval.Map;
using NSMedieval.OcclusionCulling;
using NSMedieval.Views.Resources;
using UnityEngine;
using UnityEngine.Rendering;

public class HideResource : HideLayerBase, IMapObjectElevation, IOcclusionObject
{
	[SerializeField]
	private MeshRenderer[] meshes;

	[SerializeField]
	private SkinnedMeshRenderer skinnedMeshRenderer;

	private ResourcePileView resourcePileView;

	private static readonly Bounds occlusionBoundingBox = new Bounds(new Vector3(0f, 0.25f, 0f), new Vector3(1f, 0.5f, 1f));

	private bool hidden;

	private bool isCulled;

	public bool Visible => !hidden;

	public OcclusionCullingMode OcclusionCullingMode => OcclusionCullingMode.CanBeOccludedOnly;

	public Bounds OcclusionLocalSpaceBoundingBox => occlusionBoundingBox;

	public bool IsOcclusionCulled
	{
		get
		{
			return isCulled;
		}
		set
		{
			if (isCulled == value)
			{
				return;
			}
			isCulled = value;
			if (MonoSingleton<World>.IsInstantiated())
			{
				float layerLevel = MonoSingleton<World>.Instance.LayerLevel;
				if (isCulled)
				{
					HideMapObject(layerLevel);
				}
				else
				{
					RefreshVisiblity(layerLevel);
				}
			}
		}
	}

	public Vector3 WorldPosition
	{
		get
		{
			if (!(this == null))
			{
				return base.transform.position;
			}
			return Vector3.zero;
		}
	}

	private void Awake()
	{
		resourcePileView = GetComponent<ResourcePileView>();
	}

	public void SetupMeshes(List<MeshRenderer> meshes)
	{
		this.meshes = meshes.ToArray();
	}

	public void SetSkinnedMeshRenderer(SkinnedMeshRenderer skinnedMeshRenderer)
	{
		this.skinnedMeshRenderer = skinnedMeshRenderer;
		this.skinnedMeshRenderer.shadowCastingMode = ShadowCastingMode.Off;
	}

	public void SetElevationOnShelf(float elevation)
	{
		SetElevation(elevation + base.Offset);
	}

	public void TryForceHide(float realWorldLevel)
	{
		bool num = realWorldLevel - GetElevation() <= 0f;
		bool flag = false;
		if (!num)
		{
			flag = resourcePileView?.ResourcePileInstance?.GetRoom()?.IsContentRenderCulled == true;
		}
		if (num || flag)
		{
			hidden = true;
			base.HideMapObject(realWorldLevel);
			HideMesh(meshes);
			HideSkinMeshRenderer();
		}
	}

	public override void HideMapObject(float realWorldLevel)
	{
		if (!hidden && (GetElevation() >= realWorldLevel || isCulled))
		{
			hidden = true;
			base.HideMapObject(realWorldLevel);
			HideMesh(meshes);
			HideSkinMeshRenderer();
		}
	}

	public override void ShowMapObject(float realWorldLevel)
	{
		if (!isCulled && hidden && GetElevation() < realWorldLevel)
		{
			hidden = false;
			base.ShowMapObject(realWorldLevel);
			ShowMesh(meshes);
			ShowSkinMeshRenderer();
		}
	}

	public void RemoveFromCache()
	{
		if (MonoSingleton<LayerHidingManager>.IsInstantiated())
		{
			MonoSingleton<LayerHidingManager>.Instance.LayerDownConstructablesEvent -= RefreshVisiblity;
			MonoSingleton<LayerHidingManager>.Instance.LayerUpConstructablesEvent -= RefreshVisiblity;
		}
	}

	private void RefreshVisiblity(float layerHeight)
	{
		if (hidden)
		{
			if (!isCulled && GetElevation() < layerHeight && resourcePileView?.ResourcePileInstance?.GetRoom()?.IsContentRenderCulled != true)
			{
				hidden = false;
				base.ShowMapObject(layerHeight);
				ShowMesh(meshes);
				ShowSkinMeshRenderer();
			}
			return;
		}
		bool valueOrDefault = resourcePileView?.ResourcePileInstance?.GetRoom()?.IsContentRenderCulled == true;
		if (GetElevation() >= layerHeight || valueOrDefault)
		{
			hidden = true;
			base.HideMapObject(layerHeight);
			HideMesh(meshes);
			HideSkinMeshRenderer();
		}
	}

	private void OnDestroy()
	{
		if (MonoSingleton<LayerHidingManager>.IsInstantiated())
		{
			RemoveFromCache();
		}
	}

	private void ShowSkinMeshRenderer()
	{
		if (!(skinnedMeshRenderer == null))
		{
			if (ShadowsAvailable)
			{
				skinnedMeshRenderer.shadowCastingMode = ShadowCastingMode.On;
			}
			else
			{
				skinnedMeshRenderer.enabled = true;
			}
		}
	}

	private void HideSkinMeshRenderer()
	{
		if (!(skinnedMeshRenderer == null))
		{
			if (ShadowsAvailable)
			{
				skinnedMeshRenderer.shadowCastingMode = ShadowCastingMode.ShadowsOnly;
			}
			else
			{
				skinnedMeshRenderer.enabled = false;
			}
		}
	}

	private void Start()
	{
		SetElevation(base.transform.position.y / (float)World.MapBlockHeight + base.Offset);
		MonoSingleton<LayerHidingManager>.Instance.LayerDownConstructablesEvent += RefreshVisiblity;
		MonoSingleton<LayerHidingManager>.Instance.LayerUpConstructablesEvent += RefreshVisiblity;
		TryForceHide(MonoSingleton<World>.Instance.LayerLevel);
		ShadowsAvailable = false;
		if (skinnedMeshRenderer != null)
		{
			skinnedMeshRenderer.shadowCastingMode = ShadowCastingMode.Off;
		}
		MeshRenderer[] array = meshes;
		foreach (MeshRenderer meshRenderer in array)
		{
			if (meshRenderer == null)
			{
				Log.Warning("MeshRenderer is null in HideResource.cs for " + base.gameObject.name + ". Must setup prefab properly.", "C:\\GIT\\dev\\Assets\\Scripts\\Layering\\HideResource.cs");
			}
			else
			{
				meshRenderer.shadowCastingMode = ShadowCastingMode.Off;
			}
		}
	}
}
