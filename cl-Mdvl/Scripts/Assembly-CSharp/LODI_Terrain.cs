using System;
using FIMSpace.FOptimizing;
using UnityEngine;
using UnityEngine.Rendering;

[Serializable]
public sealed class LODI_Terrain : ILODInstance
{
	public enum EILODTerrainDisableMode
	{
		[Tooltip("Modifying all parameters visible in the inspector window (beware if you using many terrains, changing all parameters is triggering some terrain reload operations which can be cpu heavy in big numbers)")]
		ModifyParameters = 0,
		[Tooltip("This option will switch Enable / Disable terrain component and collider and doing mesh replacement")]
		NotModifyParameters = 1,
		[Tooltip("Modifying just parameters like: Pixel Error, Draw Heightmap, Draw Foliage, Mode (Shadows)")]
		ModifyOnlyDrawParameters = 2
	}

	internal int index = -1;

	internal string LODName = "";

	[HideInInspector]
	public bool SetDisabled;

	[HideInInspector]
	[SerializeField]
	private bool _Locked;

	[SerializeField]
	[HideInInspector]
	private Terrain cmp;

	[Tooltip("If you have like > 100 terrains you might have to disable / enable just terrain component instead of changing it's parameters to avoid Unity's terrain material update peaks!")]
	public EILODTerrainDisableMode Do;

	public bool DeactivateCollider;

	[Space(3f)]
	[Range(1f, 200f)]
	public float PixelError = 5f;

	[Range(0f, 2000f)]
	public float BasemapDistance = 1250f;

	[Space(3f)]
	[Range(0f, 250f)]
	public float DetailDistance = 100f;

	[Range(0f, 1f)]
	public float DetailDensity = 1f;

	[Space(3f)]
	[Range(0f, 2000f)]
	public float TreeDistance = 2000f;

	[Range(1f, 5f)]
	public float TreeLODBias = 1f;

	[Range(5f, 2000f)]
	public float BillboardStart = 50f;

	[Space(3f)]
	public bool DrawFoliage = true;

	public ShadowCastingMode Mode;

	[HideInInspector]
	public bool CastShadows = true;

	public bool DrawHeightmap = true;

	[Tooltip("Dividing resolution of heightmap")]
	[Range(0f, 3f)]
	public int ResolutionDivider;

	[Space(3f)]
	[Tooltip("Optional - Replace drawing terrain with target gameObject with mesh renderer for final optimization when terrain is far away (terrain collider will still work)")]
	public GameObject MeshReplacement;

	public int Index
	{
		get
		{
			return index;
		}
		set
		{
			index = value;
		}
	}

	public string Name
	{
		get
		{
			return LODName;
		}
		set
		{
			LODName = value;
		}
	}

	public bool CustomEditor => false;

	public bool Disable
	{
		get
		{
			return SetDisabled;
		}
		set
		{
			SetDisabled = value;
		}
	}

	public bool DrawDisableOption => true;

	public bool SupportingTransitions => true;

	public bool DrawLowererSlider => false;

	public float QualityLowerer
	{
		get
		{
			return 1f;
		}
		set
		{
			new NotImplementedException();
		}
	}

	public string HeaderText => "Terrain LOD Settings";

	public float ToCullDelay => 0f;

	public bool SupportVersions => false;

	public int DrawingVersion
	{
		get
		{
			return 1;
		}
		set
		{
			new NotImplementedException();
		}
	}

	public bool LockSettings
	{
		get
		{
			return _Locked;
		}
		set
		{
			_Locked = value;
		}
	}

	public Texture Icon => null;

	public Component TargetComponent => cmp;

	public void SetSameValuesAsComponent(Component component)
	{
		if (component == null)
		{
			Debug.LogError("[OPTIMIZERS] Given component is null instead of Terrain!");
		}
		Terrain terrain = component as Terrain;
		if (terrain != null)
		{
			cmp = terrain;
			PixelError = terrain.heightmapPixelError;
			BasemapDistance = terrain.basemapDistance;
			DetailDistance = terrain.detailObjectDistance;
			DetailDensity = terrain.detailObjectDensity;
			TreeDistance = terrain.treeDistance;
			BillboardStart = terrain.treeBillboardDistance;
			DrawFoliage = terrain.drawTreesAndFoliage;
			Mode = terrain.shadowCastingMode;
			TreeLODBias = terrain.treeLODBiasMultiplier;
			ResolutionDivider = terrain.heightmapMaximumLOD;
			DrawHeightmap = terrain.drawHeightmap;
			MeshReplacement = null;
		}
	}

	public void ApplySettingsToTheComponent(Component component, ILODInstance initialSettingsRef)
	{
		Terrain terrain = component as Terrain;
		if (terrain == null)
		{
			Debug.LogError("[OPTIMIZERS] Target component is null or is not Terrain!");
			return;
		}
		LODI_Terrain lODI_Terrain = initialSettingsRef as LODI_Terrain;
		TerrainCollider component2 = terrain.GetComponent<TerrainCollider>();
		if ((bool)component2)
		{
			component2.enabled = !DeactivateCollider;
		}
		if (MeshReplacement == null)
		{
			if (Disable)
			{
				terrain.enabled = false;
			}
			else
			{
				if (!terrain.enabled)
				{
					terrain.enabled = true;
				}
				if (Do != EILODTerrainDisableMode.NotModifyParameters)
				{
					terrain.heightmapPixelError = PixelError;
					if (Do != EILODTerrainDisableMode.ModifyOnlyDrawParameters)
					{
						if (terrain.detailObjectDistance != BasemapDistance)
						{
							terrain.detailObjectDistance = BasemapDistance;
						}
						if (terrain.detailObjectDensity != DetailDistance)
						{
							terrain.detailObjectDensity = DetailDistance;
						}
						if (terrain.detailObjectDensity != DetailDensity)
						{
							terrain.detailObjectDensity = DetailDensity;
						}
						if (terrain.treeDistance != TreeDistance)
						{
							terrain.treeDistance = TreeDistance;
						}
						if (terrain.treeBillboardDistance != BillboardStart)
						{
							terrain.treeBillboardDistance = BillboardStart;
						}
						terrain.treeLODBiasMultiplier = TreeLODBias;
						if (!terrain.drawTreesAndFoliage || !terrain.drawHeightmap)
						{
							terrain.collectDetailPatches = false;
						}
						else
						{
							terrain.collectDetailPatches = true;
						}
						terrain.heightmapMaximumLOD = ResolutionDivider;
					}
					terrain.drawHeightmap = DrawHeightmap;
					terrain.drawTreesAndFoliage = DrawFoliage;
					terrain.shadowCastingMode = Mode;
				}
			}
			if ((bool)lODI_Terrain.MeshReplacement)
			{
				lODI_Terrain.MeshReplacement.SetActive(value: false);
			}
		}
		else
		{
			terrain.shadowCastingMode = ShadowCastingMode.Off;
			terrain.drawHeightmap = false;
			terrain.drawTreesAndFoliage = false;
			terrain.collectDetailPatches = false;
			Transform transform = terrain.transform.Find(terrain.name);
			if (!transform)
			{
				transform = UnityEngine.Object.Instantiate(MeshReplacement).transform;
				transform.name = terrain.name;
				transform.position = terrain.transform.position;
				transform.SetParent(terrain.transform, worldPositionStays: true);
				lODI_Terrain.MeshReplacement = transform.gameObject;
			}
			transform.gameObject.SetActive(value: true);
		}
	}

	public void AssignAutoSettingsAsForLODLevel(int lodIndex, int lodCount, Component component)
	{
		Terrain terrain = component as Terrain;
		if (terrain == null)
		{
			Debug.LogError("[OPTIMIZERS] Given component for reference values is null or is not Terrain Component!");
		}
		float valueForLODLevel = FLOD.GetValueForLODLevel(1f, 0f, lodIndex, lodCount);
		PixelError = (int)Mathf.Lerp(terrain.heightmapPixelError + 22f, terrain.heightmapPixelError, valueForLODLevel);
		BasemapDistance = Mathf.Lerp(terrain.basemapDistance / 5f, terrain.basemapDistance / 1f, valueForLODLevel);
		DetailDistance = Mathf.Lerp(terrain.detailObjectDistance / 4f, terrain.detailObjectDistance, valueForLODLevel);
		DetailDensity = Mathf.Lerp(terrain.detailObjectDensity / 5f, terrain.detailObjectDensity, valueForLODLevel);
		TreeDistance = terrain.treeDistance;
		BillboardStart = terrain.treeBillboardDistance;
		TreeLODBias = 1f;
		DrawHeightmap = true;
		ResolutionDivider = 0;
		Mode = ShadowCastingMode.Off;
		DrawFoliage = false;
		if (lodIndex >= 1)
		{
			DrawFoliage = false;
			TreeLODBias = Mathf.Lerp(2f, 1f, valueForLODLevel);
			if (lodCount <= 3)
			{
				PixelError = terrain.heightmapPixelError + 16f;
			}
		}
		if (lodIndex >= 2)
		{
			ResolutionDivider = 1;
			PixelError = terrain.heightmapPixelError + 18f;
		}
		Name = "LOD" + (lodIndex + 2);
	}

	public void AssignSettingsAsForCulled(Component component)
	{
		FLOD.AssignDefaultCulledParams(this);
		Disable = false;
		PixelError = 200f;
		BasemapDistance = 500f;
		DetailDistance = 0f;
		DetailDensity = 0f;
		TreeDistance = 0f;
		BillboardStart = 5f;
		DrawFoliage = false;
		Mode = ShadowCastingMode.Off;
		TreeLODBias = 1f;
		ResolutionDivider = 0;
		DrawHeightmap = false;
		Do = EILODTerrainDisableMode.ModifyOnlyDrawParameters;
	}

	public void AssignSettingsAsForNearest(Component component)
	{
		FLOD.AssignDefaultNearestParams(this);
		Terrain sameValuesAsComponent = component as Terrain;
		SetSameValuesAsComponent(sameValuesAsComponent);
	}

	public void AssignSettingsAsForHidden(Component component)
	{
		FLOD.AssignDefaultHiddenParams(this);
		DrawFoliage = false;
		Mode = ShadowCastingMode.Off;
		TreeLODBias = 1f;
		ResolutionDivider = 0;
		DrawHeightmap = false;
		Do = EILODTerrainDisableMode.ModifyOnlyDrawParameters;
	}

	public ILODInstance GetCopy()
	{
		return MemberwiseClone() as ILODInstance;
	}

	public void InterpolateBetween(ILODInstance lodA, ILODInstance lodB, float transitionToB)
	{
		FLOD.DoBaseInterpolation(this, lodA, lodB, transitionToB);
		LODI_Terrain lODI_Terrain = lodA as LODI_Terrain;
		LODI_Terrain lODI_Terrain2 = lodB as LODI_Terrain;
		PixelError = Mathf.Lerp(lODI_Terrain.PixelError, lODI_Terrain2.PixelError, transitionToB);
		BasemapDistance = Mathf.Lerp(lODI_Terrain.BasemapDistance, lODI_Terrain2.BasemapDistance, transitionToB);
		DetailDistance = Mathf.Lerp(lODI_Terrain.DetailDistance, lODI_Terrain2.DetailDistance, transitionToB);
		DetailDensity = Mathf.Lerp(lODI_Terrain.DetailDensity, lODI_Terrain2.DetailDensity, transitionToB);
		TreeDistance = Mathf.Lerp(lODI_Terrain.TreeDistance, lODI_Terrain2.TreeDistance, transitionToB);
		BillboardStart = Mathf.Lerp(lODI_Terrain.BillboardStart, lODI_Terrain2.BillboardStart, transitionToB);
		TreeLODBias = Mathf.Lerp(lODI_Terrain.TreeLODBias, lODI_Terrain2.TreeLODBias, transitionToB);
		ResolutionDivider = (int)Mathf.Lerp(lODI_Terrain.ResolutionDivider, lODI_Terrain2.ResolutionDivider, transitionToB);
		DrawFoliage = FLOD.BoolTransition(DrawFoliage, lODI_Terrain.DrawFoliage, lODI_Terrain2.DrawFoliage, transitionToB);
		if (transitionToB > 0f)
		{
			Mode = lODI_Terrain2.Mode;
		}
		DrawHeightmap = FLOD.BoolTransition(DrawHeightmap, lODI_Terrain.DrawHeightmap, lODI_Terrain2.DrawHeightmap, transitionToB);
		MeshReplacement = (GameObject)FLOD.ObjectTransition(MeshReplacement, lODI_Terrain.MeshReplacement, lODI_Terrain2.MeshReplacement, transitionToB);
	}
}
