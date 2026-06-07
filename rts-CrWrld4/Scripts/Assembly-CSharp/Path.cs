using System;
using UnityEngine;

public class Path : MonoBehaviour
{
	public enum MODE
	{
		NORMAL = 0,
		HALF = 1,
		NEITHER = 2
	}

	private Mesh lmesh;

	[NonSerialized]
	public Color passIdleColor;

	[NonSerialized]
	public Color passHilightColor;

	[NonSerialized]
	public Color specialPassIdleColor;

	[NonSerialized]
	public Color specialPassHilightColor;

	[NonSerialized]
	public Color hyperPathBuildingPassIdleColor;

	[NonSerialized]
	public Color hyperPathBuildingPassHilightColor;

	[NonSerialized]
	public Color nopassIdleColor;

	[NonSerialized]
	public Color nopassHilightColor;

	[NonSerialized]
	public Color transparentColor;

	[NonSerialized]
	public string startUnitPrefabName;

	[NonSerialized]
	public UnitManager startUnit;

	[NonSerialized]
	public UnitManager endUnit;

	private Color lastStartColor;

	private Color lastEndColor;

	private float lastStartUnitX;

	private float lastStartUnitY;

	private float lastStartUnitZ;

	private float lastEndUnitX;

	private float lastEndUnitY;

	private float lastEndUnitZ;

	private const float WIDTH = 0.15f;

	[NonSerialized]
	public MODE mode;

	[NonSerialized]
	public float startX;

	[NonSerialized]
	public float startY;

	[NonSerialized]
	public float startZ;

	[NonSerialized]
	public float endX;

	[NonSerialized]
	public float endY;

	[NonSerialized]
	public float endZ;

	[NonSerialized]
	public bool destroyed;

	public const int HILIGHT_TIME = 120;

	private int hilightCounter;

	[NonSerialized]
	public bool forceUpdate;

	private bool _hyperPath;

	private float _hyperPathPercentComplete;

	private bool _isVisible;

	private bool _overrideVisible;

	private bool _dashed;

	private Renderer rend;

	private bool rendererObtained;

	private Vector3 pathStartPos;

	private Vector3 pathEndPos;

	private int lastHilightCounter;

	public bool hyperPath
	{
		get
		{
			return false;
		}
		set
		{
		}
	}

	public float hyperPathPercentComplete
	{
		get
		{
			return 0f;
		}
		set
		{
		}
	}

	public bool isVisible
	{
		get
		{
			return false;
		}
		set
		{
		}
	}

	public bool overrideVisible
	{
		get
		{
			return false;
		}
		set
		{
		}
	}

	public bool dashed
	{
		get
		{
			return false;
		}
		set
		{
		}
	}

	public void Hilight(int time = 120)
	{
	}

	private void Awake()
	{
	}

	private void Start()
	{
	}

	public void LateUpdate()
	{
	}

	private void SetUVs()
	{
	}

	private void SetPositions(Vector3 s, Vector3 e, float w)
	{
	}

	public void UpdateColors(bool force = false)
	{
	}

	public UnitManager GetOtherEnd(UnitManager unit)
	{
		return null;
	}

	public float GetDistance()
	{
		return 0f;
	}

	public float GetPathDistance()
	{
		return 0f;
	}

	public void DestroyPath()
	{
	}
}
