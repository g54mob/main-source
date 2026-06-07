using System;
using NBT.Tags;
using UnityEngine;

public class SurviveBase : UnitManager
{
	public GameObject badge;

	[NonSerialized]
	public float charge;

	private int warnSoundWait;

	private const float DISCHARGE_RATE = 0.005f;

	private const float CHARGE_RATE = 0.01f;

	public GameObject playerParticles;

	public GameObject creeperParticles;

	private int lastOwnedState;

	public override string officialName => null;

	public override void Awake()
	{
	}

	public override void Start()
	{
	}

	private void UpdateBadge()
	{
	}

	public override void Update()
	{
	}

	public override void GameUpdate()
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
