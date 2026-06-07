using System;

public class PodBuildGhost : UnitBuildGhost
{
	[NonSerialized]
	public bool buildComplete;

	[NonSerialized]
	public int mverseResourceType;

	protected override UnitManager CreateUnit(UnitBuildGhost ubg)
	{
		return null;
	}
}
