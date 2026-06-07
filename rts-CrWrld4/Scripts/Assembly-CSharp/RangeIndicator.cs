using System;
using UnityEngine;

public class RangeIndicator : MonoBehaviour
{
	public GameObject cylinder;

	private int circlePointCount;

	private const float TAU = (float)Math.PI * 2f;

	private LineRenderer lineRenderer;

	public string unit;

	private int lastCellX;

	private int lastCellY;

	public bool anchorTerrain;

	public float anchorTerrainOffset;

	private UnitBuildGhost parentUBG;

	private UnitMoveGhost parentUMG;

	private int RANGE;

	private float UPGRADE_RANGE_BOOST;

	private float PZ_RANGE_BOOST;

	private int MYRANGE => 0;

	public int cellX => 0;

	public int cellY => 0;

	private void Awake()
	{
	}

	private void Start()
	{
	}

	private void Update()
	{
	}

	public void RefreshCircle()
	{
	}
}
