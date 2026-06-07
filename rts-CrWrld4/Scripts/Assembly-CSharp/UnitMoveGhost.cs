using System;
using UnityEngine;

public class UnitMoveGhost : MonoBehaviour
{
	[NonSerialized]
	public int WIDTH;

	[NonSerialized]
	public int HEIGHT;

	[NonSerialized]
	public UnitManager ownerUM;

	[NonSerialized]
	public bool waypoint;

	[NonSerialized]
	public bool temp;

	[NonSerialized]
	public bool indicated;

	[NonSerialized]
	public bool hoverIndicated;

	private Vector2 deployedPosition;

	private Vector2 deployedSelectionPosition;

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

	private float losStartDistBias;

	private TempPaths tempPaths;

	[NonSerialized]
	public UnitManager.ORIENTATION orientation;

	private Vector3 lastPosition;

	[NonSerialized]
	public bool forceUpdate;

	[NonSerialized]
	public bool lastWaypointKey;

	private int lastCellX;

	private int lastCellY;

	private UnitManager.ORIENTATION lastOrientation;

	private bool setIsLegal;

	public void ShowLOS(bool val)
	{
	}

	public bool IsLegal(bool waypoint)
	{
		return false;
	}

	private void Awake()
	{
	}

	private void Start()
	{
	}

	private void Update()
	{
	}

	private void OnDisable()
	{
	}

	private void UpdatePosition()
	{
	}

	private void SetColor(Color32 color)
	{
	}

	private void SetColor(Color32 color, Mesh m)
	{
	}

	public Vector2 GetDeployedFootprintPosition()
	{
		return default(Vector2);
	}

	public void DeploySelectionFootprint(bool deploy)
	{
	}

	private void DeploySelectionFootprint(bool deploy, int gsx, int gsy)
	{
	}

	public void DeployFootprint(bool deploy)
	{
	}

	private void DeployFootprint(bool deploy, int gsx, int gsy)
	{
	}

	public void DestroyGhost()
	{
	}
}
