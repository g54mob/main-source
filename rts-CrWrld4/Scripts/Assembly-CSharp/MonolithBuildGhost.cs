using System;

public class MonolithBuildGhost : UnitBuildGhost
{
	[NonSerialized]
	public bool playerControlled;

	[NonSerialized]
	public bool buildComplete;

	protected override UnitManager CreateUnit(UnitBuildGhost ubg)
	{
		return null;
	}
}
