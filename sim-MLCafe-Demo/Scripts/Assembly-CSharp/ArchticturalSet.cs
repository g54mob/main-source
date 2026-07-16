using System;
using UnityEngine;

[Serializable]
public class ArchticturalSet
{
	public float dimensionSize = 1f;

	[SerializeField]
	private GameObject floorPrefab;

	[SerializeField]
	private GameObject wallPrefab;

	[SerializeField]
	private GameObject cornerPrefab;

	[SerializeField]
	private GameObject ceilPrefab;

	public Vector3 GetDimensions()
	{
		return new Vector3(dimensionSize, dimensionSize, dimensionSize);
	}

	public GameObject GetFloorPiece()
	{
		return floorPrefab;
	}

	public GameObject GetWallPiece()
	{
		return wallPrefab;
	}

	public GameObject GetCornerPiece()
	{
		return cornerPrefab;
	}

	public GameObject GetCeilPiece()
	{
		return ceilPrefab;
	}
}
