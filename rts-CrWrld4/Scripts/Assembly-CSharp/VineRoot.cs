using System;
using NBT.Tags;

public class VineRoot : UnitManager
{
	[NonSerialized]
	public int startTime;

	[NonSerialized]
	public int finishTime;

	[NonSerialized]
	public int productionInterval;

	private Vine vine;

	public Vine.TARGET_BEHAVIOR targetBehavior
	{
		get
		{
			return default(Vine.TARGET_BEHAVIOR);
		}
		set
		{
		}
	}

	public override void Awake()
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
