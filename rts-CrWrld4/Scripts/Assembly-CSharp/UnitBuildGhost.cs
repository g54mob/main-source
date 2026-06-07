using System;
using System.Collections.Generic;
using UnityEngine;

public class UnitBuildGhost : MonoBehaviour
{
	[NonSerialized]
	public bool secondary;

	[NonSerialized]
	public bool pinned;

	[NonSerialized]
	public int secondaryCount;

	public string buildSound;

	public bool createSecondaries;

	public bool singleBuild;

	public bool alwaysLegal;

	public bool onlyOnVoid;

	public float extrVoidVerticalBiasWhenPlanetTexture;

	public bool forceSetColor;

	[NonSerialized]
	public GameObject prefab;

	protected int WIDTH;

	protected int HEIGHT;

	private int PLACEMENTRANGE;

	private int lastCellX;

	private int lastCellY;

	private Color32 legalColor;

	private Color32 illegalColor;

	private List<UnitBuildGhost> secondaries;

	private Stack<UnitBuildGhost> unusedSecondaries;

	[NonSerialized]
	public UnitBuildGhost baseUBG;

	private LOSIndicator losIndicator;

	private PlacementIndicator placementIndicator;

	private int losRange;

	private float losRangePZBoost;

	private float losRangeUpgradeBoost;

	private Vector3 losFireOffset;

	private float losTargetHeightOffset;

	private bool losAlwaysShow;

	private bool losIgnoreTerrain;

	private float losTerrainHeightMod;

	private bool losIndirect;

	private float losIndirectHeightOffset;

	private float startDistBias;

	private Path specialPath;

	private TempPaths tempPaths;

	private UnitManager.ORIENTATION _orientation;

	[NonSerialized]
	public IClonePack clonePack;

	private UnitPopupInfoPane upip;

	[NonSerialized]
	public bool cachedIsLegal;

	public virtual UnitManager.ORIENTATION orientation
	{
		get
		{
			return default(UnitManager.ORIENTATION);
		}
		set
		{
		}
	}

	public void LateUpdate()
	{
	}

	private void RefreshCost()
	{
	}

	public virtual void Init(GameObject prefab, int width, int height, bool secondary, int placementRange)
	{
	}

	public GameObject GetPrefab()
	{
		return null;
	}

	private void ShowLOS(bool val)
	{
	}

	public bool IsSquare()
	{
		return false;
	}

	public bool CanRotate()
	{
		return false;
	}

	public bool IsSupplyLegal(bool countAll)
	{
		return false;
	}

	public bool IsLegal(int cellX, int cellY)
	{
		return false;
	}

	protected virtual void SetPosition(int cellX, int cellY, bool force)
	{
	}

	public bool PinDown(int cellX, int cellY)
	{
		return false;
	}

	public void InformCurrentPosition(int cellX, int cellY, bool force = false)
	{
	}

	private void GetPR(bool primaryX, out int PR, out int minX, out int minY)
	{
		PR = default(int);
		minX = default(int);
		minY = default(int);
	}

	private void ManageSecondaries(int cellX, int cellY)
	{
	}

	private bool CreateSecondaryOnLine(int cellX, int cellY, int prevX, int prevY, bool primaryX, bool connectable)
	{
		return false;
	}

	public bool Build()
	{
		return false;
	}

	protected virtual UnitManager CreateUnit(UnitBuildGhost ubg)
	{
		return null;
	}

	private void SetColor(Color32 color)
	{
	}

	private void SetColor(Color32 color, Mesh m)
	{
	}

	public void DestroyUnitBuildGhost()
	{
	}
}
