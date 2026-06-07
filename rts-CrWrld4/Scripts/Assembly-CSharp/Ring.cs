using System;
using UnityEngine;

public class Ring : MonoBehaviour
{
	private int circlePointCount;

	private const float TAU = (float)Math.PI * 2f;

	[NonSerialized]
	public LineRenderer lineRenderer;

	private float _range;

	public bool anchorTerrain;

	public float anchorTerrainOffset;

	public float range
	{
		get
		{
			return 0f;
		}
		set
		{
		}
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

	public void RefreshCircle()
	{
	}
}
