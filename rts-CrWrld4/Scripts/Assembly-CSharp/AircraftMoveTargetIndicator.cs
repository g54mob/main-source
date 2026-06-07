using System;
using UnityEngine;

public class AircraftMoveTargetIndicator : MonoBehaviour
{
	[NonSerialized]
	public bool secondary;

	[NonSerialized]
	public AircraftMoveTarget moveTarget;

	private int MAX_FADECOUNT;

	private int fadeCount;

	public int cellX => 0;

	public int cellY => 0;

	private void Start()
	{
	}

	private void Update()
	{
	}

	public void ResetFade()
	{
	}

	public void SetColor(Color32 color)
	{
	}

	private void SetColor(Color32 color, Mesh m)
	{
	}
}
