using System;
using System.Collections.Generic;
using NBT.Tags;
using UnityEngine;

public class Forb : UnitManager
{
	[NonSerialized]
	public MVerseForb mverseController;

	private float FORB_MOVE_SPEED;

	private const int FIRE_RANGE = 15;

	private const float AMMO_USE = 0.1f;

	private const float AMMO_REGEN = 0.05f;

	public LineRenderer beam;

	private List<int> currentCourse;

	private int targetLocation;

	private int currentCourseIndex;

	private bool can_fire;

	private bool firing;

	private AirSacBubble lastASB;

	private float fireDeltaX;

	private float fireDeltaZ;

	private int fireCount;

	private SkimmerFactory factory;

	private int PAYLOAD;

	private float scale;

	private bool initted;

	private UnitManager beamTarget;

	private static HashSet<int> openHashSet;

	private static HashSet<int> closedHashSet;

	public override void Awake()
	{
	}

	public void Init(SkimmerFactory factory, int payload)
	{
	}

	public override void Start()
	{
	}

	public override void GameUpdate()
	{
	}

	public override void Damage(float damage)
	{
	}

	public void OnSniperShot(UnitManager sniper)
	{
	}

	public void LateUpdate()
	{
	}

	private void Drive()
	{
	}

	private bool NearDigitalis()
	{
		return false;
	}

	private void Boom()
	{
	}

	private List<int> GetCourse(int goal)
	{
		return null;
	}

	private int GetNextLocation()
	{
		return 0;
	}

	private bool[] FloodFill(int start, out List<int> list)
	{
		list = null;
		return null;
	}

	public static Dictionary<int, int> PathFind(int start, int goal)
	{
		return null;
	}

	private static float Hfunc(int start, int goal)
	{
		return 0f;
	}

	private bool HasLOS(UnitManager um)
	{
		return false;
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
