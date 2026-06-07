using System;
using NBT.Tags;

public class FatMan : UnitManager
{
	public int DAMAGE_COUNT;

	[NonSerialized]
	public int DAMAGE_MAXDIST;

	[NonSerialized]
	public int DAMAGE_AMT;

	public override void Awake()
	{
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
