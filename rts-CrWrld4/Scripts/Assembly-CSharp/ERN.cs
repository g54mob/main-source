using System;
using NBT.Tags;
using UnityEngine;

public class ERN : UnitManager
{
	public enum STATE
	{
		WAITING = 0,
		BURIED = 1,
		MOVING_TO_ASSIGNMENT = 2,
		DOCKING = 3,
		DOCKED = 4,
		PARKING = 5
	}

	private enum FACE
	{
		BACK = 0,
		LEFT = 1,
		FORWARD = 2,
		RIGHT = 3,
		DOWN = 4,
		UP = 5
	}

	public GameObject cube;

	public GameObject buriedIndicator;

	private float ERN_MOVE_SPEED;

	private float ERN_DRIFT_SPEED;

	private float DRIFT_HEIGHT;

	private float WAITING_HEIGHT;

	public float BOX_SIZE;

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

	private Mesh lmesh;

	private float xRate;

	private float yRate;

	private float zRate;

	private STATE state;

	[NonSerialized]
	public UnitManager assignment;

	[NonSerialized]
	public bool beingExcavated;

	private float lastPercentRaised;

	private Vector2 driftDest;

	public override bool selected
	{
		get
		{
			return false;
		}
		set
		{
		}
	}

	public override void Awake()
	{
	}

	public override void Start()
	{
	}

	public override void Update()
	{
	}

	public void LateUpdate()
	{
	}

	public override void GameUpdate()
	{
	}

	public void SetState(STATE state)
	{
	}

	public void SetAssignment(UnitManager um)
	{
	}

	public void ReleaseAssignment()
	{
	}

	public bool IsAvailable()
	{
		return false;
	}

	public bool IsDocked()
	{
		return false;
	}

	private bool Dock()
	{
		return false;
	}

	private bool MoveTowardsAssignment()
	{
		return false;
	}

	private void Drift()
	{
	}

	private void GetRandomDriftDest()
	{
	}

	private float GetMinHeight(int cx, int cy, float extra)
	{
		return 0f;
	}

	private bool MaintainHeight(float extra, bool instantly)
	{
		return false;
	}

	public bool IsBuried()
	{
		return false;
	}

	public void Bury(int absoluteHeight)
	{
	}

	private void CreateCube()
	{
	}

	private void SetFace(FACE face, int faceOffset)
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

	private void OnDestroy()
	{
	}

	public override void DestroyUnit(bool suppressEffects)
	{
	}

	public override void ReadData(Tag data)
	{
	}

	public override void ReadDataLate()
	{
	}

	public override TagCompound WriteData()
	{
		return null;
	}
}
