using System;
using NBT.Tags;

public class PterosaurNest : UnitManager
{
	[NonSerialized]
	public int startTime;

	[NonSerialized]
	public int finishTime;

	[NonSerialized]
	public int productionInterval;

	[NonSerialized]
	public int pterosaurCount;

	private int currentPterosaurCount;

	public override void Awake()
	{
	}

	public override void GameUpdate()
	{
	}

	public void OnPterosaurCreated()
	{
	}

	public void OnPterosaurDestroyed()
	{
	}

	private void CreatePterosaur()
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
