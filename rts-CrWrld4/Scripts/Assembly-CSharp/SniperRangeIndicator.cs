using System;
using UnityEngine;

public class SniperRangeIndicator : MonoBehaviour
{
	[NonSerialized]
	public int range;

	private float rangePZBoost;

	private float rangeUpgradeBoost;

	private LineRenderer lineRenderer;

	private int circlePointCount;

	private const float TAU = (float)Math.PI * 2f;

	private Vector2 deployedHPosition;

	private int deployuedHRange;

	private int lastCellX;

	private int lastCellY;

	private float hilightStartTime;

	private const float LOS_SHOW_TIME = 0.2f;

	private UnitMoveGhost unitMoveGhost;

	private bool suppressLOS;

	private void Awake()
	{
	}

	private void Start()
	{
	}

	private int MyRange(int cellX, int cellY)
	{
		return 0;
	}

	private void OnDisable()
	{
	}

	private void OnDestroy()
	{
	}

	private void Update()
	{
	}

	public void RefreshCircle()
	{
	}

	public void UnHilightTerrain()
	{
	}

	public void HilightTerrain()
	{
	}

	private void HilightTerrain(bool deploy, int cx, int cy, int range, bool suppressLOSUpdate = false)
	{
	}

	private bool IsAdjacentEmpty(bool[] hCache, byte[] terrainCache, int rSize, int x, int y, int x2, int y2)
	{
		return false;
	}
}
