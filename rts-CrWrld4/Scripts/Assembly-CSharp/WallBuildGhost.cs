using System;

public class WallBuildGhost : UnitBuildGhost
{
	[NonSerialized]
	public bool crazonium;

	protected override UnitManager CreateUnit(UnitBuildGhost ubg)
	{
		return null;
	}
}
