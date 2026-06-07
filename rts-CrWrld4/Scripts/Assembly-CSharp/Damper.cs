using NBT.Tags;
using UnityEngine;

public class Damper : UnitManager
{
	public GameObject dropObject;

	public Ring ring;

	private int TIME_TO_LIVE;

	private float DROP_RATE;

	private bool dropping;

	private float ringRange;

	private float RING_RATE;

	private ParticleTrailManager trail;

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

	private void Damp()
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
