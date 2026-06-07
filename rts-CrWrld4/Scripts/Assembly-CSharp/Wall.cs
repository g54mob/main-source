using System;
using System.Collections.Generic;
using NBT.Tags;
using UnityEngine;
using mattmc3.dotmore.Collections.Generic;

public class Wall : UnitManager
{
	[NonSerialized]
	public int INITIAL_STRENGTH;

	[NonSerialized]
	public int CRAZONIUM_INITIAL_STRENGTH;

	public bool crazonium;

	[NonSerialized]
	public int RECHARGE_RATE;

	public Transform beamCap;

	public GameObject beam;

	public GameObject indicator;

	private int clearCount;

	public Color32 baseColor;

	public Color32 harmedColor;

	private Mesh beamMesh;

	public bool suppressMV;

	private bool _affectsAC;

	private float lastR;

	public bool affectsAC
	{
		get
		{
			return false;
		}
		set
		{
		}
	}

	public override bool unitEnabled
	{
		get
		{
			return false;
		}
		set
		{
		}
	}

	public override void SetUnitSettings(OrderedDictionary2<string, RplCore.Data> initParams)
	{
	}

	public override OrderedDictionary2<string, RplCore.Data> GetUnitSettings()
	{
		return null;
	}

	public override void Awake()
	{
	}

	private void SetRes(int val)
	{
	}

	private int GetRes()
	{
		return 0;
	}

	public float GetHealth()
	{
		return 0f;
	}

	public override void Start()
	{
	}

	public override void Update()
	{
	}

	public override void GameUpdate()
	{
	}

	private void SetHeightAndColor(int r)
	{
	}

	public void SetCharge(float amt, bool all)
	{
	}

	public static void FloodWalls(Wall wall, HashSet<Wall> wallsSet)
	{
	}

	public override void DestroyUnit(bool suppressEffects)
	{
	}

	public override void ReadData(Tag data)
	{
	}

	public override TagCompound WriteData()
	{
		return null;
	}
}
