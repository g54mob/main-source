using System;
using ClockStone;
using NBT.Tags;
using UnityEngine;
using VLB;

public class CommandBase : UnitManager, IPacketDispatcher
{
	public VolumetricLightBeam vlb;

	public GameObject lightbeam;

	public Light halo;

	public ParticleSystem rematerializeParticles;

	private float materializingAmt;

	private const float REMATERIALIZE_RATE = 0.075f;

	private float minMaterializingAmt;

	private float maxMaterializingAmt;

	private AudioObject rematerializeSound;

	private AudioObject dematerializeSound;

	[NonSerialized]
	public bool dispatchBuildPackets;

	[NonSerialized]
	public bool dispatchAmmoPackets;

	[NonSerialized]
	public bool priorityTower;

	[NonSerialized]
	public bool priorityMiner;

	private bool _rematerializing;

	private bool _dematerializing;

	private new MVerseUnit mvu;

	private int warningCounter;

	public bool rematerializing
	{
		get
		{
			return false;
		}
		set
		{
		}
	}

	public bool dematerializing
	{
		get
		{
			return false;
		}
		set
		{
		}
	}

	public override string officialName => null;

	private void OnRematerializeSoundCompleteleyPlayed(AudioObject audio)
	{
	}

	private void OnDematerializeSoundCompleteleyPlayed(AudioObject audio)
	{
	}

	public override void Awake()
	{
	}

	public override void Start()
	{
	}

	public void CreateMVerseUnit()
	{
	}

	public new void Update()
	{
	}

	private void HandleSound()
	{
	}

	public override void GameUpdate()
	{
	}

	public bool DispatchPacket(UnitManager u, Packet.PACKET_TYPE type)
	{
		return false;
	}

	public override void Damage(float damage)
	{
	}

	public override void DestroyUnit(bool suppressEffects)
	{
	}

	private void FinalDestroy()
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
