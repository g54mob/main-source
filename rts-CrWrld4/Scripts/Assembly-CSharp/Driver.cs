using System.Collections.Generic;
using NBT.Tags;
using UnityEngine;

public class Driver : UnitManager
{
	private enum STATE
	{
		CHARGING = 0,
		FIRING = 1
	}

	private class Beam
	{
		public GameObject beam;

		public GameObject beamStart;

		public GameObject beamEnd;

		public bool fired;

		public bool destroyed;

		public void Destroy()
		{
		}
	}

	private STATE state;

	private Dictionary<Resource, Beam> beams;

	public override void Awake()
	{
	}

	public override void Start()
	{
	}

	public override void BuildComplete()
	{
	}

	public override void GameUpdate()
	{
	}

	public List<UnitManager> GetDriverTargets()
	{
		return null;
	}

	public static List<UnitManager> GetDriverTargets(int gsx, int gsy, int range)
	{
		return null;
	}

	private static bool InRange(UnitManager em, int gsx, int gsy, int range)
	{
		return false;
	}

	private bool InRange(UnitManager em)
	{
		return false;
	}

	private void Fire()
	{
	}

	private void FireAtResource(Resource resource)
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
