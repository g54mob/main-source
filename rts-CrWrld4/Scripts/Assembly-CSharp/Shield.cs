using System;
using NBT.Tags;

public class Shield : UnitManager
{
	private float FIRE_COST;

	private bool lastOPZ;

	private int standardRange;

	private int PZRange;

	[NonSerialized]
	public bool shieldActivated;

	public override void Awake()
	{
	}

	public override void Start()
	{
	}

	public void CreateMVerseUnit()
	{
	}

	public override void Update()
	{
	}

	public override void GameUpdate()
	{
	}

	public void ActivateShield(bool value)
	{
	}

	public override void DamageShield()
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
