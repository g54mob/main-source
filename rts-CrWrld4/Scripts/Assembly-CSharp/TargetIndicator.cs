using System;
using System.Collections.Generic;
using UnityEngine;

public class TargetIndicator : MonoBehaviour
{
	public byte targetIndicatorType;

	[NonSerialized]
	public string trueGUID;

	[NonSerialized]
	public bool mverseOwned;

	[NonSerialized]
	public int cellX;

	[NonSerialized]
	public int cellY;

	[NonSerialized]
	public UnitManager ownerUnit;

	[NonSerialized]
	public bool temp;

	[NonSerialized]
	public Vector2 specifiedIgnorePosition;

	[NonSerialized]
	public bool deploysFootprint;

	[NonSerialized]
	public bool showsPath;

	[NonSerialized]
	public bool colorChild;

	public int WIDTH;

	public int HEIGHT;

	public GameObject quad;

	public LineRenderer pathLine;

	private PlacementIndicator placementIndicator;

	public bool createPlacementIndicator;

	private Vector2 deployedPosition;

	private int _resourceType;

	private bool _showBackground;

	[NonSerialized]
	public bool checkLegality;

	[NonSerialized]
	public Vector3 sourceUnitOffset;

	private int LINE_SEGMENT_COUNT;

	[NonSerialized]
	public float PATH_MAX_HEIGHT;

	private Vector3 lastOwnerUnitPosition;

	private int mverseLastCellX;

	private int mverseLastCellY;

	private int mverseLastResourceType;

	private bool lastIsLegal;

	private HashSet<Mesh> madeMeshes;

	public int resourceType
	{
		get
		{
			return 0;
		}
		set
		{
		}
	}

	public bool showBackground
	{
		get
		{
			return false;
		}
		set
		{
		}
	}

	public void OnEnable()
	{
	}

	public void UpdatePosition()
	{
	}

	public void Update()
	{
	}

	public void HidePath()
	{
	}

	public void ShowPath()
	{
	}

	public void UpdateColor()
	{
	}

	public bool IsLegal()
	{
		return false;
	}

	public void DeployFootprint(bool deploy)
	{
	}

	private void DeployFootprint(bool deploy, int gsx, int gsy)
	{
	}

	public void SetColor(Color32 color)
	{
	}

	private void SetColor(Color32 color, Mesh m)
	{
	}

	public void DestroyTargetIndicator()
	{
	}
}
