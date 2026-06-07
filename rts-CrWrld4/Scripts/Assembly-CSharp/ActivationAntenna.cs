using System;
using ClockStone;
using NBT.Tags;
using UnityEngine;

public class ActivationAntenna : UnitManager
{
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

	public GameObject ring;

	public GameObject fins;

	private AudioObject armingSound;

	private AudioObject firingSound;

	[NonSerialized]
	public float SPAWN_INTERVAL;

	private int fireTime;

	[NonSerialized]
	public bool activationAntennaComplete;

	[NonSerialized]
	public bool firedComplete;

	private bool fired;

	private static int FIRE_TIME;

	private Beam beam;

	public override string officialName => null;

	public override void Awake()
	{
	}

	public void ResetActivationAntenna()
	{
	}

	public override void GameUpdate()
	{
	}

	private void Spawn()
	{
	}

	private bool IsClear(int cx, int cy)
	{
		return false;
	}

	public void FireBeam()
	{
	}

	private void FireAtRift(Vector3 dp)
	{
	}

	public override void Update()
	{
	}

	private void HandleSound()
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
