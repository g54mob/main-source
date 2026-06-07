using System;
using UnityEngine;

public class CubeBar : MonoBehaviour
{
	private enum FACE
	{
		BACK = 0,
		LEFT = 1,
		FORWARD = 2,
		RIGHT = 3,
		DOWN = 4,
		UP = 5
	}

	private bool ammoBar;

	[NonSerialized]
	public float BOX_SIZE;

	[NonSerialized]
	public float GAP;

	private Mesh lmesh;

	private Vector3 p0;

	private Vector3 p1;

	private Vector3 p2;

	private Vector3 p3;

	private Vector3 p4;

	private Vector3 p5;

	private Vector3 p6;

	private Vector3 p7;

	private Vector3[] v;

	private Color32[] c;

	private Vector3[] n;

	private Vector2[] u;

	private int[] t;

	public int startValue;

	public bool startAmmoBar;

	public bool startBuilding;

	public int startBoxCount;

	private int _boxCount;

	private UnitManager parentUnit;

	private Color32 visibleColor;

	private Color32 invisibleColor;

	private bool inited;

	private AmmoTypeIndicator ammoTypeIndicator;

	private float lastAngle;

	private bool lastIsBuilding;

	[NonSerialized]
	public bool forceRefresh;

	private float val;

	private float max;

	public int BoxCount
	{
		get
		{
			return 0;
		}
		set
		{
		}
	}

	private void Awake()
	{
	}

	public void Init(UnitManager parentUnit, bool isAmmoBar)
	{
	}

	public void RefreshAmmoBarType()
	{
	}

	private void OnDestroy()
	{
	}

	private void GetVertices(FACE face, out Vector3 v0, out Vector3 v1, out Vector3 v2, out Vector3 v3)
	{
		v0 = default(Vector3);
		v1 = default(Vector3);
		v2 = default(Vector3);
		v3 = default(Vector3);
	}

	private Vector3 GetNormal(FACE face)
	{
		return default(Vector3);
	}

	private void CreateCubes()
	{
	}

	private void CreateCube(int cubeNum)
	{
	}

	private void SetFace(int cubeNum, FACE face, int faceOffset)
	{
	}

	private void SetBoxColor(int cubeNum, Color32 color)
	{
	}

	private void SetVisibleBlocks(int count)
	{
	}

	public void LateUpdate()
	{
	}

	public void SetValue(float val, float max, bool force = false)
	{
	}
}
