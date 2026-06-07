using NBT.Tags;
using UnityEngine;

public class Singularity : UnitManager
{
	public GameObject dropObject;

	private int TIME_TO_LIVE;

	private float DROP_RATE;

	private bool dropping;

	private ParticleTrailManager trail;

	private bool deployed;

	private static int STRENGTH;

	public override void Awake()
	{
	}

	public override void Start()
	{
	}

	public override void GameUpdate()
	{
	}

	public void CreateMVerseUnit()
	{
	}

	public override void Update()
	{
	}

	private void Absorb()
	{
	}

	private void DeployField(bool deploy)
	{
	}

	public static void DeployField(bool deploy, int cellX, int cellY, int RANGE)
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
