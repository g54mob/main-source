using System;
using UnityEngine;

public class DenierRangeIndicator : MonoBehaviour
{
	public GameObject cylinder;

	public GameObject cube;

	private int circlePointCount;

	private int squarePointCount;

	private const float TAU = (float)Math.PI * 2f;

	private LineRenderer lineRenderer;

	private int lastCellX;

	private int lastCellY;

	private int lastWidth;

	private int lastHeight;

	private bool lastSquare;

	public Denier denier;

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

	private void RefreshShape()
	{
	}
}
